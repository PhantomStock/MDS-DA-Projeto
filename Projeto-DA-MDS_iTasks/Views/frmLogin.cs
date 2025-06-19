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
        BaseDeDados db => BaseDeDados.Instance;
        ControllerLogin controllerLogin = new ControllerLogin();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btRegistar_Click(object sender, EventArgs e)
        {
            frmGereUtilizadores registar = new frmGereUtilizadores();
            registar.Show();
            this.Hide();
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var utilizador = controllerLogin.Login(username, password);

            if (utilizador != null)
            {
                SessaoAtual.Utilizador = utilizador; // Guarda o utilizador na sessão atual

                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
