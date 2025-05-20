using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            new frmGereTiposTarefas().Show();
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

        private void btNova_Click(object sender, EventArgs e)
        {
            
            //verificar se current user pode alterar se puder ele pode se nao fds
            ControllerTarefa TarefaController = new ControllerTarefa();

            if (lstTodo.SelectedItem != null) 
            {
                Tarefa tarefa = (Tarefa)lstTodo.SelectedItem;

                TarefaController.CarregaOuCriaTarefa(tarefa.Id);
                //enviar id da tarefa para o controllador das tarefas
            } 
            else if (lstDoing.SelectedItem != null) 
            {
                Tarefa tarefa = (Tarefa)lstDoing.SelectedItem;

                TarefaController.CarregaOuCriaTarefa(tarefa.Id);
                //enviar id da tarefa para o controllador das tarefas
            }
            else if (lstDone.SelectedItem != null)
            {
                Tarefa tarefa = (Tarefa)lstDone.SelectedItem;

                TarefaController.CarregaOuCriaTarefa(tarefa.Id);
                //enviar id da tarefa para o controllador das tarefas
            } else
            {
                Tarefa tarefa = new Tarefa();

                TarefaController.CarregaOuCriaTarefa(tarefa.Id);
            }
        }
    }
            
}
