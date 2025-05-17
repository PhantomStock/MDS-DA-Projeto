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
using iTasks.DataBase;

namespace iTasks
{
    public partial class frmKanban : Form
    {

        public frmKanban(int utilizadorId)
        {
            InitializeComponent();

            var controller = new ControllerKanban();
            var utilizador = controller.ObterUtilizadorId(utilizadorId);

            if (utilizador != null)
            {
                labelNomeUtilizador.Text = $"Bem vindo: {utilizador.Nome}";
            }
        }

        //Não ta em MVC falta as tarefas para 
        private void exportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Não sei como passar os filtros pro Controller ;-;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ficheiro CSV (*.CSV)|*.CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = "dadosCSV.CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var controller = new ControllerKanban();
                // Assume ControllerKanban has a method ExportarTarefasParaCSV that returns true/false
                bool sucesso = controller.ExportarTarefasCSV(saveFileDialog.FileName);

                if (sucesso)
                {
                    //Sucesso
                    MessageBox.Show("Tarefas exportadas com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Erro
                    MessageBox.Show("Falha ao exportar tarefas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmGereUtilizadores().Show();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDetalhesTarefa().Show();
        }

        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsultarTarefasConcluidas().Show();
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsultaTarefasEmCurso().Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            new frmLogin().Show();
        }
    }
            
}
