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
    public partial class frmLogin : Form
    {
        BaseDeDados db => BaseDeDados.Instance;
        public frmLogin()
        {
            InitializeComponent();
        }
        //temporario para testes no futuro vai desaparecer esta opçao de registar
        private void btRegistar_Click(object sender, EventArgs e)
        {
            frmRegistar registar = new frmRegistar();
            registar.Show();
            this.Hide();
        }

        // verifica as credenciais inseridas e compara com as da base de dados
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var utilizador = db.Utilizador
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (utilizador != null)
            {
                    
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new frmKanban(utilizador.Id).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // caso o form seja fechado ele encera o programa

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
