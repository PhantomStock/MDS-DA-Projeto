using iTasks.Controllers;
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
    public partial class frmDetalhesTarefa : Form
    {
        Tarefa Tarefa;
        public frmDetalhesTarefa(Tarefa tarefa)
        {
            InitializeComponent();
            this.Tarefa = tarefa;
            CarregaDadosTarefa(tarefa);
        }

        public void CarregaDadosTarefa(Tarefa tarefa)
        {
            txtId.Text = tarefa.Id.ToString();
            txtEstado.Text = tarefa.EstadoAtual.ToString();
            txtDataCriacao.Text = tarefa.DataCriacao.ToString("dd/MM/yyyy");
            txtDataRealini.Text = tarefa.DataRealInicio.ToString("dd/MM/yyyy");
            txtDataRealFim.Text = tarefa.DataRealFim.ToString("dd/MM/yyyy");
            txtDesc.Text = tarefa.Descricao;

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
        

        private void frmDetalhesTarefa_Load(object sender, EventArgs e)
        {
            
        }
    }
}
