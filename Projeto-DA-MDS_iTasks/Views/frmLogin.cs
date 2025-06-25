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
    public partial class frmLogin : Form
    {
        // Controlador responsável pelo login e configuração da base de dados
        ControllerLogin controllerLogin = new ControllerLogin();
        public frmLogin()
        {
            InitializeComponent();
            // Configura a base de dados com um Gestor inicial(nome: admin /username: admin / senha: admin)
            controllerLogin.SetupBaseDeDados(); 
        }


        private void btLogin_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos de texto para o login
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verifica as credenciais inseridas e usamos o FirstOrDefault para ver se o utilizador existe ou não
            var utilizador = controllerLogin.Login(username, password);

            // Se o utilizador for encontrado, armazena-o na sessão atual e abre o formulário principal
            if (utilizador != null)
            {
                // Guarda o utilizador na sessão atual
                SessaoAtual.Utilizador = utilizador;

                // Exibe uma mensagem de sucesso e abre o formulário principal
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre o formulário principal (Kanban)
                new frmKanban().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(sender, e);
            }

        }
    }
}
