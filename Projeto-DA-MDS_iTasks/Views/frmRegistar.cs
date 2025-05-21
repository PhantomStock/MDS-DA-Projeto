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
using static iTasks.Models.Enums;

namespace iTasks
{
    public partial class frmRegistar: Form
    {
        public frmRegistar()
        {
            InitializeComponent();
            //Intanciar o Controller
            ControllerRegistar Controller = new ControllerRegistar();

            //Realiza o Setup das ComboBoxes
            var gestores = Controller.ObterGestores();

            //Obter Gestores
            cbGestor.DataSource = null;
            cbGestor.DataSource = gestores;


            //ComboBox NivelExperiencia
            cbExperiencia.DataSource = null;
            cbExperiencia.DataSource = Enum.GetValues(typeof(NivelExperiencia));

            // ComboBox Departamento
            cbDepartamento.DataSource = null;
            cbDepartamento.DataSource = Enum.GetValues(typeof(Departamento));

        }

        private void btRegistar_Click(object sender, EventArgs e)
        {
            //Variaveis Base para o Utilizador
            string nome = tbNome.Text;

            string username = tbUsername.Text;

            string password = tbPassword.Text;

            string confirmarPass = tbConfirmarPass.Text;

            //Variavel usado para o gestor
            NivelExperiencia experiencia = (NivelExperiencia)cbExperiencia.SelectedIndex;

            //Variaveis usados para o Programador
            Departamento departamento = (Departamento)cbDepartamento.SelectedIndex;
            bool gereUtilizadores = cbxGereUtilizadores.Checked;

            //Variavel Gestor
            Gestor Gestor = (Gestor)cbGestor.SelectedItem;

            using (var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    if (password == confirmarPass)
                    {
                        ControllerRegistar novoRegisto = new ControllerRegistar();

                        if (rbUtilizadorComum.Checked)
                        {
                            novoRegisto.RegistarUtilizador(nome, username, password);

                        }
                        else if (rbProgramador.Checked)
                        {
                            novoRegisto.RegistarProgramador(nome, username, password, experiencia, Gestor.Id);
                        }
                        else if (rbGestor.Checked)
                        {
                            novoRegisto.RegistarGestor(nome, username, password, departamento, gereUtilizadores);
                        }
                    }
                    else
                    {
                        MessageBox.Show("As passwords não condizem", "Registo Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
