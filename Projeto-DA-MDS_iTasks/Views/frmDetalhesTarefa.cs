﻿using iTasks.Controllers;
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
using static iTasks.Models.Enums;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {
        public int IdGestorAtual;
        public int idTarefaAtualUpdate;
        ControllerDados controllerDados = new ControllerDados();
        private frmKanban kanban;
        ControllerTarefa controllerTarefa = new ControllerTarefa();
        public frmDetalhesTarefa(int id, frmKanban kanbanfrm)
        {
            InitializeComponent();

            kanban = kanbanfrm;

            if (SessaoAtual.Utilizador is  Programador)
            {
                SetReadOnly();
            }

            //recebe e carrega na combo box todos os tipos de tarefa
            List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

            cbTipoTarefa.DataSource = null;
            cbTipoTarefa.DataSource = TiposTarefas;

            //recebe e carrega na combo box todos os programadores
            List<Programador> ProgramadoresDoGestor = controllerDados.ObterProgramadoresDoGestorAtual();
                
            cbProgramador.DataSource = null;
            cbProgramador.DataSource = ProgramadoresDoGestor;

            //recebe o utilizador atual
            Utilizador utilizadorAtual = SessaoAtual.Utilizador;

            idTarefaAtualUpdate = id;

            //verifica se é um gestor ou programador a aceder aos detalhes da tarefa
            if (utilizadorAtual is Gestor gestorAtual)
            {
                IdGestorAtual = gestorAtual.Id;
            }
            else if (utilizadorAtual is Programador programadorAtual)
            {
                IdGestorAtual = programadorAtual.IdGestor; 
            }
            

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

        // funcao para definir os campos como read only
        //
        private void SetReadOnly()
        {
            txtDesc.ReadOnly = true;
            cbTipoTarefa.Enabled = false;
            cbProgramador.Enabled = false;

            txtOrdem.Enabled = false;
            txtStoryPoints.Enabled = false;

            dtInicio.Enabled = false;
            dtFim.Enabled = false;

            btGravar.Enabled = false;
            btFechar.Enabled = true;
        }

        // funcao para criar uma nova tarefa
        public void NovaTarefa()
        {
            int Id = (int)txtId.Value;

            AtualizarIdTarefa(Id);

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
                txtId.Value = tarefa.Id;
                txtEstado.Text = tarefa.EstadoAtual.ToString();
                txtDataCriacao.Text = tarefa.DataCriacao?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDataRealini.Text = tarefa.DataRealInicio?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDataRealFim.Text = tarefa.DataRealFim?.ToString("dd/MM/yyyy") ?? string.Empty;
                txtDesc.Text = tarefa.Descricao;
            }

            //cbTipoTarefa.SelectedItem = tarefa.IdTipoTarefa.ToString(); //?
            //cbProgramador.SelectedItem = tarefa.idGestor.Nome;//?

            txtOrdem.Value = tarefa.OrdemExecucao;
            txtStoryPoints.Value = tarefa.StoryPoints;

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
                    int idProgramador = ((Programador)cbProgramador.SelectedItem).Id;
                    //verifica se nao existe tarefas atribuídas ao programador com ordem de execução igual a indicada
                        
                    var listaTarefas = controllerDados.ObterTarefasPorProgramador(idProgramador);

                    if (listaTarefas != null)
                    {
                        if (txtStoryPoints.Value <= 0)
                        {
                            MessageBox.Show("A ordem de execução deve ser um número maior que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                            //FIX FIX FIX MESMO BLOCO DO ANTERIOR

                        } else
                        {

                            //verifica se o numero de story points é maior que 0
                            if (txtOrdem.Value <= 0)
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
                                    //recebe o id do tipo de tarefa selecionado na combobox e do programador selecionado
                                    TipoTarefa TipoTarefaSelecionado = (TipoTarefa)cbTipoTarefa.SelectedItem;
                                    Programador programadorSelecionado = (Programador)cbProgramador.SelectedItem;
                                    Gestor gestor = controllerDados.ObterGestorPorId(IdGestorAtual);

                                    //verifica se as datas reais de inicio e fim foram preenchidas automaticamente (basicamente define se esta a atualizar ou nao)
                                    if (idTarefaAtualUpdate > 0)
                                    {
                                        //verifica se a ordem na textbox é igual a que veida da tarefa que está a ser atualizada se for deixa, se nao for verifica se já existe alguma tarefa atribuída ao programador com a mesma ordem de execução
                                        if (Convert.ToInt32(txtOrdem.Value) != controllerDados.ObterTarefaPorId(idTarefaAtualUpdate).OrdemExecucao && controllerDados.ExisteTarefaComOrdem(Convert.ToInt16(txtOrdem.Value), idProgramador))
                                        {
                                            MessageBox.Show("Já existe uma tarefa atribuída a este programador com a mesma ordem de execução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            if (Enum.TryParse(txtEstado.Text, out EstadoAtual tipoEnum)) {
                                                //Criar nova tarefa para depois atualizar
                                                Tarefa tarefaUpdate = controllerDados.ObterTarefaPorId(idTarefaAtualUpdate);

                                                tarefaUpdate.Descricao = txtDesc.Text;
                                                tarefaUpdate.DataCriacao = DateTime.Now;
                                                tarefaUpdate.DataPrevistaInicio = dtInicio.Value;
                                                tarefaUpdate.DataPrevistaFim = dtFim.Value;
                                                if (string.IsNullOrEmpty(txtDataRealini.Text))
                                                {
                                                    tarefaUpdate.DataRealInicio = null;
                                                }
                                                else
                                                {
                                                    tarefaUpdate.DataRealInicio = Convert.ToDateTime(txtDataRealini.Text);
                                                }
                                                if (string.IsNullOrEmpty(txtDataRealFim.Text))
                                                {
                                                    tarefaUpdate.DataRealFim = null;
                                                }
                                                else
                                                {
                                                    tarefaUpdate.DataRealFim = Convert.ToDateTime(txtDataRealFim.Text);
                                                }
                                                tarefaUpdate.EstadoAtual = tipoEnum;
                                                tarefaUpdate.StoryPoints = (int)txtStoryPoints.Value;
                                                tarefaUpdate.OrdemExecucao = (int)txtOrdem.Value;
                                                tarefaUpdate.IdTipoTarefa = TipoTarefaSelecionado.Id;
                                                tarefaUpdate.IdProgramador = programadorSelecionado.Id;

                                                controllerTarefa.updateTarefa(tarefaUpdate);
                                                MessageBox.Show("Tarefa atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            } else
                                            {
                                                MessageBox.Show("Tipo de tarefa não encontrado!" + tipoEnum, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (controllerDados.ExisteTarefaComOrdem((int)txtOrdem.Value, idProgramador))
                                        {
                                            MessageBox.Show("Já existe uma tarefa atribuída a este programador com a mesma ordem de execução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            if (cbTipoTarefa.SelectedItem == null)
                                            {
                                                MessageBox.Show("Falta selecionar um tipo de tarefa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                //Criar nova tarefa
                                                Tarefa tarefaNova = new Tarefa();

                                                tarefaNova.Id = (int)txtId.Value;
                                                tarefaNova.Descricao = txtDesc.Text;
                                                tarefaNova.DataCriacao = DateTime.Now;
                                                tarefaNova.DataPrevistaInicio = dtInicio.Value;
                                                tarefaNova.DataPrevistaFim = dtFim.Value;
                                                tarefaNova.DataRealInicio = null;
                                                tarefaNova.DataRealFim = null;
                                                tarefaNova.EstadoAtual = Enums.EstadoAtual.ToDo;
                                                tarefaNova.StoryPoints = (int)txtStoryPoints.Value;
                                                tarefaNova.OrdemExecucao = (int)txtOrdem.Value;
                                                tarefaNova.IdTipoTarefa = TipoTarefaSelecionado.Id;
                                                tarefaNova.IdProgramador = programadorSelecionado.Id;
                                                tarefaNova.IdGestor = gestor.Id;

                                                controllerTarefa.CriarTarefa(tarefaNova);

                                                //campo Id é atualizado para o mesmo que o id da tarefa que está a ser atualizada
                                                int Id = (int)txtId.Value;

                                                //atualiza o id da tarefa para o mesmo que o id da tarefa que está a ser atualizada
                                                AtualizarIdTarefa(Id);

                                                kanban.RefreshDadosListBoxes();
                                                MessageBox.Show("Tarefa criada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                LimparCampos();
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                    //  this.Close();
                }else{
                    //apresenta mensagem de erro caos o programador seja nulo
                    MessageBox.Show("Programador selecionado é inválido ou está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txtDesc.Text = "";
            txtDataRealini.Text = "";
            txtDataRealFim.Text = "";
            txtOrdem.Value = 1;
            txtStoryPoints.Value = 1;
            cbTipoTarefa.SelectedIndex = 0;
            cbProgramador.SelectedIndex = 0;
            dtInicio.Value = DateTime.Now;
            dtFim.Value = DateTime.Now;
        }

        //instancia uma nova tarefa
        public void AtualizarIdTarefa(int valorId)
        {
            var Tarefa = controllerDados.ObterTodasTarefas();
            int proximoId = (Tarefa.Count == 0 || Tarefa.Count == null) ? 1 : Tarefa.Max(u => u.Id) + 1;
            txtId.Value = proximoId;
        }


    }
}
