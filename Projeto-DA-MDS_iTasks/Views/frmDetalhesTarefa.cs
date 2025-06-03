using iTasks.Controllers;
using iTasks.DataBase;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {
        public int IdGestorAtual;
        ControllerDados controllerDados = new ControllerDados();
        ControllerDetalhesTarefa ControllerDetalhesTarefa = new ControllerDetalhesTarefa();
        ControllerTarefa controllerTarefa = new ControllerTarefa();
        public frmDetalhesTarefa(int id, int idGestor)
        {
            InitializeComponent();
            //recebe e carrega na combo box todos os tipos de tarefa
            List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

            cbTipoTarefa.DataSource = null;
            cbTipoTarefa.DataSource = TiposTarefas;

            //recebe e carrega na combo box todos os programadores
            List<Programador> Programadores = controllerDados.ObterTodosProgramdores();
                
            cbProgramador.DataSource = null;
            cbProgramador.DataSource = Programadores;

            IdGestorAtual = idGestor;

            // quando o id for -1, significa que é uma nova tarefa, caso contrário, carrega os dados da tarefa
            if (id == -1)
            {
                NovaTarefa();
            }
            else
            {
                CarregaDadosTarefa(id);
            }
       
        }

        // funcao para criar uma nova tarefa
        public void NovaTarefa()
        {
            controllerDados.AtualizarIdTarefa(txtId);

            txtEstado.Text = Enums.EstadoAtual.ToDo.ToString();
            txtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // funcao para carregar os dados da tarefa
        public void CarregaDadosTarefa(int idTarefa)
        {
          
            var tarefa = controllerDados.ObterTarefaPorId(idTarefa);

            if (tarefa == null)
            {
                MessageBox.Show("Tarefa não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                txtId.Text = tarefa.Id.ToString();
                txtEstado.Text = tarefa.EstadoAtual.ToString();
                txtDataCriacao.Text = tarefa.DataCriacao?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDataRealini.Text = tarefa.DataRealInicio?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDataRealFim.Text = tarefa.DataRealFim?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDesc.Text = tarefa.Descricao;
            }

            //cbTipoTarefa.SelectedItem = tarefa.IdTipoTarefa.ToString(); //?
            //cbProgramador.SelectedItem = tarefa.idGestor.Nome;//?

            txtOrdem.Text = tarefa.OrdemExecucao.ToString();
            txtStoryPoints.Text = tarefa.StoryPoints.ToString();

            if (tarefa.DataPrevistaInicio != null)
            {
                dtInicio.Value = (DateTime)tarefa.DataPrevistaInicio;
            }
            if (tarefa.DataPrevistaFim != null)
            {
                dtFim.Value = (DateTime)tarefa.DataPrevistaFim;
            }
        }

        // funcao para iniciar o processo de gravar dados aqui sao feitas algumas verificações que vao no futuro ser transferidas para o controllador 
        private void btGravar_Click(object sender, EventArgs e)
        {
            //verificar se textbox descricao é nula ou vazia
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("A descrição não pode ser vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                if (cbProgramador.SelectedItem != null)
                {
                    int id = ((Programador)cbProgramador.SelectedItem).Id;
                    //verifica se nao existe tarefas atribuídas ao programador com ordem de execução igual a indicada
                        
                    var listaTarefas = controllerDados.ObterTarefasPorProgramador(id);


                    if (listaTarefas != null)
                    {
                        
                        if (controllerDados.ExisteTarefaComOrdem(Convert.ToInt32(txtOrdem.Text), id))
                        {
                            MessageBox.Show("Já existe uma tarefa atribuída a este programador com a mesma ordem de execução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } else
                        {
                            //verifica se a ordem de execução é maior que 0
                            if (Convert.ToInt32(txtOrdem.Text) <= 0)
                            {
                                MessageBox.Show("A ordem de execução deve ser um número maior que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                //verifica se o numero de story points é maior que 0
                                if (Convert.ToInt32(txtStoryPoints.Text) <= 0)
                                {
                                    MessageBox.Show("O número de story points deve ser um número maior que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    //verifica se a data prevista de inicio é maior que a data prevista de fim
                                    if (dtInicio.Value > dtFim.Value)
                                    {
                                        MessageBox.Show("A data prevista de início não pode ser maior que a data prevista de fim.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrWhiteSpace(txtDataRealFim.Text) && !string.IsNullOrWhiteSpace(txtDataRealini.Text))
                                        {
                                            if (Convert.ToDateTime(txtDataRealini.Text) > Convert.ToDateTime(txtDataRealFim.Text))
                                            {
                                                MessageBox.Show("A data real de início não pode ser maior que a data real de fim.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                //yooooo envia a dizer que é para atualizar a tarefa com os dados todos incluido as datas real de inicio e os caralhos
                                            }
                                        }
                                        else
                                        {
                                            //cria uma tarefa nova sem as datas reais de inicio e fim (porque isso so é atualizado quando sao
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //recebe o id do tipo de tarefa selecionado na combobox e do programador selecionado
                    TipoTarefa TipoTarefaSelecionado = (TipoTarefa)cbTipoTarefa.SelectedItem;
                    Programador programadorSelecionado = (Programador)cbProgramador.SelectedItem;
                    Gestor gestor = controllerDados.ObterGestorPorId(IdGestorAtual);

                    //Criar nova tarefa
                    Tarefa tarefaNova = new Tarefa();

                    tarefaNova.Id = Convert.ToInt32(txtId.Text);
                    tarefaNova.Descricao = txtDesc.Text;
                    tarefaNova.DataCriacao = DateTime.Now;
                    tarefaNova.DataPrevistaInicio = dtInicio.Value;
                    tarefaNova.DataPrevistaFim = dtFim.Value;
                    //tarefaNova.DataRealInicio = ;
                    //tarefaNova.DataRealFim = ;
                    tarefaNova.EstadoAtual = Enums.EstadoAtual.ToDo;
                    tarefaNova.StoryPoints = Convert.ToInt32(txtStoryPoints.Text);
                    tarefaNova.OrdemExecucao = Convert.ToInt32(txtOrdem.Text);
                    tarefaNova.IdTipoTarefa = TipoTarefaSelecionado.Id;
                    tarefaNova.IdProgramador = programadorSelecionado.Id;
                    tarefaNova.IdGestor = gestor.Id; //id do gestor que clicou no buton


                    NovaTarefa();
                    controllerTarefa.CriarTarefa(tarefaNova);
                    //  this.Close();
                }else{
                    //apresenta mensagem de erro caos o programador seja nulo
                    MessageBox.Show("O programador não pode ser nulo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
