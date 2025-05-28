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
        ControllerDados controllerDados = new ControllerDados();
        ControllerDetalhesTarefa controllerDetalhesTarefa = new ControllerDetalhesTarefa();
        ControllerTarefa controllerTarefa = new ControllerTarefa();
        public frmDetalhesTarefa(int id)
        {
            InitializeComponent();
            using (var db = new BaseDeDados()) 
            {
                //recebe e carrega na combo box todos os tipos de tarefa
                List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

                cbTipoTarefa.DataSource = null;
                cbTipoTarefa.DataSource = TiposTarefas;

                //recebe e carrega na combo box todos os programadores
                List<Programador> Programadores = controllerDados.ObterTodosProgramdores();
                
                cbProgramador.DataSource = null;
                cbProgramador.DataSource = Programadores;

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
        }

        // funcao para criar uma nova tarefa
        public void NovaTarefa()
        {
            var tarefas = controllerDados.ObterTodasTarefas();
            int TarefaIdAnterior = 0;

            foreach (Tarefa tipoTarefa in tarefas)
            {
                if (tipoTarefa.Id > TarefaIdAnterior)
                {
                    TarefaIdAnterior = tipoTarefa.Id;
                }
            }
            txtId.Text = (TarefaIdAnterior + 1).ToString();
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
                txtDataCriacao.Text = tarefa.DataCriacao.ToString("dd/MM/yyyy");
                txtDataRealini.Text = tarefa.DataRealInicio.ToString("dd/MM/yyyy");
                txtDataRealFim.Text = tarefa.DataRealFim.ToString("dd/MM/yyyy");
                txtDesc.Text = tarefa.Descricao;
            }

            //cbTipoTarefa.SelectedItem = tarefa.IdTipoTarefa.ToString(); //?
            //cbProgramador.SelectedItem = tarefa.idGestor.Nome;//?

            txtOrdem.Text = tarefa.OrdemExecucao.ToString();
            txtStoryPoints.Text = tarefa.StoryPoints.ToString();

            if (tarefa.DataPrevistaInicio != null)
            {
                dtInicio.Value = tarefa.DataPrevistaInicio;
            }
            if (tarefa.DataPrevistaFim != null)
            {
                dtFim.Value = tarefa.DataPrevistaFim;
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
                        int ordermExecucaoInput = Convert.ToInt32(txtOrdem.Text);
                        foreach (var tarefa in listaTarefas)
                        {
                            if (tarefa.OrdemExecucao == ordermExecucaoInput)
                            {
                                MessageBox.Show("Já existe uma tarefa atribuída a este programador com a mesma ordem de execução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    //Criar nova tarefa
                    Tarefa tarefaNova = new Tarefa();

                    tarefaNova.Id = Convert.ToInt32(txtId.Text);
                    tarefaNova.Descricao = txtDesc.Text;
                    tarefaNova.DataCriacao = DateTime.Now;
                    tarefaNova.DataPrevistaInicio = dtInicio.Value;
                    tarefaNova.DataPrevistaFim = dtFim.Value;
                    tarefaNova.DataRealInicio = DateTime.Now;
                    tarefaNova.DataRealFim = DateTime.Now;
                    tarefaNova.EstadoAtual = Enums.EstadoAtual.ToDo;
                    tarefaNova.StoryPoints = Convert.ToInt32(txtStoryPoints.Text);
                    tarefaNova.OrdemExecucao = Convert.ToInt32(txtOrdem.Text);
                    tarefaNova.IdTipoTarefa = new TipoTarefa { Id = ((TipoTarefa)cbTipoTarefa.SelectedItem).Id };
                    tarefaNova.idGestor = new Gestor { Id = ((Programador)cbProgramador.SelectedItem).idGestor };

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
