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
            //ComboBox Expericencia
            cbExperiencia.Items.Add(NivelExperiencia.Júnior);
            cbExperiencia.Items.Add(NivelExperiencia.Sénior);

            //ComboBox Departamento
            cbDepartamento.Items.Add(Departamento.IT);
            cbDepartamento.Items.Add(Departamento.Marketing);
            cbDepartamento.Items.Add(Departamento.Administração);

            //ComboBox Gestor Usernames
            using (BaseDeDados db = new BaseDeDados())
            {
                //Query base de dados que atribui o nome de todos os gerentes
                var gestorUsername = db.Gestores
                .ToList();

                //Faz o foreach da base de dados relacioando o id com username
                foreach (var GestorNome in gestorUsername) {
                    cbGestor.Items.Add(GestorNome);
                }
            }

        }

        private void btRegistar_Click(object sender, EventArgs e)
        {
            //Variaveis Base para o Utilizador
            string nome = tbNome.Text;

            string username = tbUsername.Text;

            string password = tbPassword.Text;

            string confirmarPass = tbConfirmarPass.Text;

            //Variaveis Base para o programador
            NivelExperiencia experiencia = (NivelExperiencia)cbExperiencia.SelectedIndex;

            //Variavel Base Gestor
            Departamento departamento = (Departamento)cbDepartamento.SelectedIndex;

            bool gereUtilizadores = cbxGereUtilizadores.Checked;

            Gestor Gestor = (Gestor)cbGestor.SelectedItem;
            





            using (var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    if (password == confirmarPass)
                    {
                        if (rbUtilizadorComum.Checked)
                        {
                            var utilizador = new Utilizador(nome, username, password);
                            db.Utilizadores.Add(utilizador);
                            db.SaveChanges();

                            MessageBox.Show("Utilizador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else if (rbProgramador.Checked)
                        {

                            var programador = new Programador(nome, username, password, experiencia, Gestor.Id);
                            db.Programadores.Add(programador);
                            db.SaveChanges();
                            MessageBox.Show("Programador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(rbGestor.Checked)
                        {
                            var gestor = new Gestor(nome, username, password, departamento, gereUtilizadores);
                            db.Gestores.Add(gestor);
                            db.SaveChanges();
                            MessageBox.Show("Gestor registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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














        //Radio Buttons Check
        private void rbProgramador_CheckedChanged(object sender, EventArgs e)
        {
            gbProgramador.Enabled = true;
            gbGestor.Enabled = false;
        }

        private void rbGestor_CheckedChanged(object sender, EventArgs e)
        {
            gbProgramador.Enabled = false;
            gbGestor.Enabled = true;
        }

        private void rbUtilizadorComum_CheckedChanged(object sender, EventArgs e)
        {
            gbProgramador.Enabled = false;
            gbGestor.Enabled = false;
        }
    }
}
