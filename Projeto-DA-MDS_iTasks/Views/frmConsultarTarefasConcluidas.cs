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

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            using (BaseDeDados db = new BaseDeDados())
            {
                // Specifies the state of the task as 'Done'
                var tarefasConcluidas = db.Tarefas
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done)
                    .Select(t => new
                    {
                        //usamos o if inline para verificar se o IdTipoTarefa,idGestor,IdProgramador e se for nulo
                        //atribuímos uma string "Tarefa Null"
                        Id = t.Id,
                        IdTipoTarefa = t.IdTipoTarefa != null ? t.IdTipoTarefa.Id.ToString() : "Tarefa Null",
                        IdGestor = t.idGestor.Id != null ? t.idGestor.Id.ToString() : "Gestor Null",
                        IdProgramador = t.IdProgramador.Id != null ? t.IdProgramador.Id.ToString() : "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio,
                        DataPrevistaFim = t.DataPrevistaFim,
                        DataRealInicio = t.DataRealInicio,
                        DataRealFim = t.DataRealFim,
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",

                    })
                    .ToList();
                // Loads the data into the gridView
                gvTarefasConcluidas.DataSource = tarefasConcluidas;

            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
