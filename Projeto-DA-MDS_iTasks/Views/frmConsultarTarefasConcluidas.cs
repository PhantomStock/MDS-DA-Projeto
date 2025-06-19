using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Controllers;
using iTasks.Models;

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        BaseDeDados db => BaseDeDados.Instance;
        ControllerDados controllerDados = new ControllerDados();
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            //Obter Utilizador
            var utilizadorAtual = SessaoAtual.Utilizador;

            int tipo = controllerDados.GestorOuProgramdor(utilizadorAtual.Id);
            //Verifica se e Gestor ou Programador
            if (tipo == 1)
            {
                //è gestor
                //carrega as tarefas que foram concluidas pelos programadores que estão associados a este gestor
                var tarefasConcluidasAssociadosAGestor = db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdGestor == utilizadorAtual.Id)
                    .ToList() // Filtra as tarefas que estão concluídas e associadas ao gestor atual
                    .Select(t => new
                    {
                        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
                        //atribuímos uma string "Tarefa Null"
                        Id = t.Id,
                        IdTipoTarefa = t.IdTipoTarefa != null ? t.IdTipoTarefa.ToString() : "Tarefa Null",
                        IdGestor = t.IdGestor != null ? t.IdGestor.ToString() : "Gestor Null",
                        IdProgramador = t.IdProgramador != null ? t.IdProgramador.ToString() : "Programador Null",
                        //usamos o controllerDados para obter o nome do programador associado a esta tarefa
                        NomeDoProgramador = controllerDados.ObterProgramadorPorId(t.IdProgramador).Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio,
                        DataPrevistaFim = t.DataPrevistaFim,
                        DataRealInicio = t.DataRealInicio,
                        DataRealFim = t.DataRealFim,
                        TempoDemorado = t.DataRealFim.Value.Day - t.DataRealInicio.Value.Day + " dias",
                        TempoEstimado = t.DataPrevistaFim.Value.Day - t.DataPrevistaInicio.Value.Day + " dias",
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",
                    })
                    .ToList();

                gvTarefasConcluidas.DataSource = tarefasConcluidasAssociadosAGestor;
            }
            else if(tipo == 2)
            {
                //é programador 
                //carrega as tarefas que foram concluidas por este programador
                var tarefasConcluidasPorProgramador = db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdProgramador == utilizadorAtual.Id)
                    .Select(t => new
                    {
                        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
                        //atribuímos uma string "Tarefa Null"
                        Id = t.Id,
                        IdTipoTarefa = t.IdTipoTarefa != null ? t.IdTipoTarefa.ToString() : "Tarefa Null",
                        IdGestor = t.IdGestor != null ? t.IdGestor.ToString() : "Gestor Null",
                        IdProgramador = t.IdProgramador != null ? t.IdProgramador.ToString() : "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio,
                        DataPrevistaFim = t.DataPrevistaFim,
                        DataRealInicio = t.DataRealInicio,
                        DataRealFim = t.DataRealFim,
                        TempoDemorado = t.DataRealFim.Value.Day - t.DataRealInicio.Value.Day + " dias",
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",
                    })
                    .ToList();

                gvTarefasConcluidas.DataSource = tarefasConcluidasPorProgramador;
            }
            else
            {
                //não é valido
                MessageBox.Show("Utilizador não tem permissão para consultar tarefas concluídas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //// Carrega as tarefas que estão em curso (Doing) da base de dados
            //var tarefasConcluidas = db.Tarefa
            //    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done )
            //    .Select(t => new
            //    {
            //        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
            //        //atribuímos uma string "Tarefa Null"
            //        Id = t.Id,
            //        IdTipoTarefa = t.IdTipoTarefa != null ? t.IdTipoTarefa.ToString() : "Tarefa Null",
            //        IdGestor = t.IdGestor != null ? t.IdGestor.ToString() : "Gestor Null",
            //        IdProgramador = t.IdProgramador != null ? t.IdProgramador.ToString() : "Programador Null",
            //        Descricao = t.Descricao,
            //        OrdemExecucao = t.OrdemExecucao,
            //        DataPrevistaInicio = t.DataPrevistaInicio,
            //        DataPrevistaFim = t.DataPrevistaFim,
            //        DataRealInicio = t.DataRealInicio,
            //        DataRealFim = t.DataRealFim,
            //        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",

            //    })
            //    .ToList();
                
            //// Loads the data into the gridView
            //gvTarefasConcluidas.DataSource = tarefasConcluidas;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
         }


    }
}
