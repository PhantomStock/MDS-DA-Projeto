using iTasks.Controllers;
using iTasks.DataBase;
using iTasks.Models;
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
    public partial class frmConsultaTarefasEmCurso : Form
    {
        BaseDeDados db => BaseDeDados.Instance;
        ControllerDados controllerDados = new ControllerDados();
        ControllerConsultarTarefas controllerConsultarTarefas = new ControllerConsultarTarefas();
        public frmConsultaTarefasEmCurso()
        {
            InitializeComponent();

        }
        private void frmConsultarTarefasEmCurso_Load(object sender, EventArgs e)
        {
            Utilizador utilizadorAtual = SessaoAtual.Utilizador;
            // Verifica se o utilizador atual é um gestor ou programador
            int tipo = controllerDados.GestorOuProgramador(utilizadorAtual.Id);

            if (tipo == 1)
            {
                //Gestor
                var tarefasEmCurso= controllerConsultarTarefas.ConsultarTarefasEmCurso(utilizadorAtual, tipo);

                gvTarefasEmCurso.DataSource = tarefasEmCurso;
            }
            else if (tipo == 2)
            {
                //Programador
                var tarefasEmCurso = controllerConsultarTarefas.ConsultarTarefasEmCurso(utilizadorAtual, tipo);

                gvTarefasEmCurso.DataSource = tarefasEmCurso;
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
