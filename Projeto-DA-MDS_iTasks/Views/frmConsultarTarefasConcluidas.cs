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
        private ControllerDados controllerDados = new ControllerDados();
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            Utilizador utilizadorAtual = SessaoAtual.Utilizador;
            // Verifica se o utilizador atual é um gestor ou programador
            int tipo = controllerDados.GestorOuProgramador(utilizadorAtual.Id);
            if (tipo == 1)
            {
                // Se for gestor, carrega as tarefas concluídas
                var tarefasConcluidas = db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdGestor == utilizadorAtual.Id)
                    .ToList()//pra não dar erro de null
                    .Select(t => new
                    {
                        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
                        //atribuímos uma string "Tarefa Null"
                        Id = t.Id,
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio,
                        DataPrevistaFim = t.DataPrevistaFim,
                        DataRealInicio = t.DataRealInicio,
                        DataRealFim = t.DataRealFim,
                        DuraçãoReal = t.DataRealFim.Value.Day - t.DataRealInicio.Value.Day + " dias",
                        DuraçãoEstimada = t.DataPrevistaFim.Value.Day - t.DataPrevistaInicio.Value.Day + " dias",
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() + " points" : "0",

                    })
                    .ToList();

                gvTarefasConcluidas.DataSource = tarefasConcluidas;
            }
            else if(tipo == 2)
            {
                //Programador
                var tarefasConcluidas = db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdProgramador == utilizadorAtual.Id)
                    .ToList()//pra não dar erro de null
                    .Select(t => new
                    {
                        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
                        //atribuímos uma string "Tarefa Null"
                        Id = t.Id,
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio,
                        DataPrevistaFim = t.DataPrevistaFim,
                        DataRealInicio = t.DataRealInicio,
                        DataRealFim = t.DataRealFim,
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",

                    })
                    .ToList();

                gvTarefasConcluidas.DataSource = tarefasConcluidas;
            }
            else
            {
                //Tipo de utilizador não é nem gestor nem programador
                MessageBox.Show("Apenas gestores e programadores podem consultar tarefas concluídas.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
         }


    }
}
