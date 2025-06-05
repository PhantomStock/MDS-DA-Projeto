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
        BaseDeDados db => BaseDeDados.Instance;
        public int IdUtilizadorAtual;
        ControllerDados controllerDados = new ControllerDados();
        public frmKanban(int utilizadorId)
        {
            
                InitializeComponent();
                // inicializa o form kanbar e atribui a uma variavel o utilizador que está a iniciar sessão
                var utilizador = controllerDados.ObterUtilizadorPorId(utilizadorId);
                IdUtilizadorAtual = utilizadorId;

                if (utilizador != null)
                {
                    labelNomeUtilizador.Text = $"Bem vindo: {utilizador.Nome}";
                }

                RefreshDadosListBoxes();
           
  
            
        }

        //Não ta em MVC falta as tarefas para 
        private void exportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //ToolStripMenu
        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controllerDados.ObterGestorPorId(IdUtilizadorAtual).GereUtilizadores )
            {
                new frmGereUtilizadores().Show();
            }
            else
            {
                MessageBox.Show("Apenas um gestor pode gerir utilizadores.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            new frmLogin().Show();
            this.Close();
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            //chama o form para uma nova tarefa
            new frmDetalhesTarefa(-1, IdUtilizadorAtual).Show();
        }

        private void lstTodo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickLst(lstTodo);
        }

        private void lstDoing_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickLst(lstDoing);
        }

        private void lstDone_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickLst(lstDone);
        }

        //evento para quando o utilizador seleciona uma tarefa para "abrir" com double click
        private void DoubleClickLst(ListBox lb)
        {
            // Verifica se há um item selecionado
            Tarefa tarefa = lb.SelectedItem as Tarefa;

            new frmDetalhesTarefa(tarefa.Id, IdUtilizadorAtual).Show();
        }

        private void RefreshDadosListBoxes()
        {
            //Carrega as tarefas
            controllerDados = new ControllerDados();
            List<Tarefa> tarefasTodo = controllerDados.ObterTarefasTodo();
            List<Tarefa> tarefasDoing = controllerDados.ObterTarefasDoing();
            List<Tarefa> tarefasDone = controllerDados.ObterTarefasDone();

            //faz refresh as data source das listboxes
            lstTodo.DataSource = null;
            lstTodo.DataSource = tarefasTodo;
           
            lstDoing.DataSource = null;
            lstDoing.DataSource = tarefasDoing;

            lstDone.DataSource = null;
            lstDone.DataSource = tarefasDone;
        }

        private void lblRefreshbtnSim_Click(object sender, EventArgs e)
        {
            RefreshDadosListBoxes();
        }


        private void importarTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //importa as tarefas de um ficheiro CSV
        }
        private void exportarTarefaPorFazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(1); //exporta para csv as tarefas por fazer
        }
        private void exportarTarefaEmExecuçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(2); //exporta para csv as em execução
        }
        private void exportarTarefaConcluidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportarParaCSV(3); //exporta para csv as tarefas concluidas
        }
        private void exportarTodasAsTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(4); //exporta para csv todas as tarefas
        }

        private void exportarParaCSV(int tipo)
        {
            //switch case para fazer defenir qual o tipo de tarefa a exportar para texto para apresentar no filename
            string tipoString = "ToDo";
            switch (tipo)
            {
                case 1:
                    tipoString = "ToDo";
                    break;
                case 2:
                    tipoString = "Doing";
                    break;
                case 3:
                    tipoString = "Done";
                    break;
                case 4:
                    tipoString = "Todas";
                    break;
                default:
                    tipo = -1;
                    break;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ficheiro CSV (*.CSV)|*.CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = "Tarefas" + tipoString + ".CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var controller = new ControllerKanban();
                // Assume ControllerKanban has a method ExportarTarefasParaCSV that returns true/false
                bool sucesso = controller.ExportarTarefasCSV(saveFileDialog.FileName, tipoString);

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

        private void importarTodasAsTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarDeSVC(4); //importa todas as tarefas
        }

        private void importarDeSVC(int tipo)
        {
            //switch case para fazer defenir qual o tipo de tarefa a exportar para texto para apresentar no filename
            string tipoString = "ToDo";
            switch (tipo)
            {
                case 1:
                    tipoString = "ToDo";
                    break;
                case 2:
                    tipoString = "Doing";
                    break;
                case 3:
                    tipoString = "Done";
                    break;
                case 4:
                    tipoString = "Todas";
                    break;
                default:
                    tipo = -1;
                    break;
            }


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ficheiro CSV (*.CSV)|*.CSV";
            openFileDialog.DefaultExt = "csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var controller = new ControllerKanban();
                // Assume ControllerKanban has a method ExportarTarefasParaCSV that returns true/false
                bool sucesso = controller.ImportarTarefasCSV(openFileDialog.FileName, tipoString);

                if (sucesso)
                {
                    //Sucesso
                    MessageBox.Show("Tarefas importadas com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Erro
                    MessageBox.Show("Falha ao importar tarefas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
            
}
