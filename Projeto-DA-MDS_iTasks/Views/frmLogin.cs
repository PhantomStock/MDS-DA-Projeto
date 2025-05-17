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
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btRegistar_Click(object sender, EventArgs e)
        {
            frmRegistar registar = new frmRegistar();
            registar.Show();
            this.Hide();
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var db = new BaseDeDados())
            {
                var utilizador = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (utilizador != null)
                {
                    
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new frmKanban().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


    }
}
