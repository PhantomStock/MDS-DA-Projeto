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
        //ToolStripMenu
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
    }
            
}
