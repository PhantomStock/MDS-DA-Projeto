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
    public partial class frmRegistar: Form
    {
        public frmRegistar()
        {
            InitializeComponent();
        }

        private void btRegistar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;

            string username = tbUsername.Text;

            string password = tbPassword.Text;

            string confirmarPass = tbConfirmarPass.Text;

            using(var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    if (password == confirmarPass)
                    {
                        var utilizador = new Utilizador
                        {
                            Nome = nome,
                            Username = username,
                            Password = password,
                        };
                        db.Utilizadores.Add(utilizador);
                        db.SaveChanges();

                        MessageBox.Show("Registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("As password não condizem", "Registo Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username já registado", "Registo Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                    

            }


        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();

        }
    }
}
