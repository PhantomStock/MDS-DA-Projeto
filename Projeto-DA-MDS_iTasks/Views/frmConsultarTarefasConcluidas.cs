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
        private ControllerConsultarTarefas controllerConsultarTarefas = new ControllerConsultarTarefas();
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
                // Gestor
                var tarefasConcluidas = controllerConsultarTarefas.ConsultarTarefasConcluidas(utilizadorAtual, tipo);

                gvTarefasConcluidas.DataSource = tarefasConcluidas;
            }
            else if(tipo == 2)
            {
                //Programador
                var tarefasConcluidas = controllerConsultarTarefas.ConsultarTarefasConcluidas(utilizadorAtual, tipo);


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
