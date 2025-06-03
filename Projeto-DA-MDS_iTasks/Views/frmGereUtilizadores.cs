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
using iTasks.DataBase;
using static iTasks.Models.Enums;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        //Intanciar o Controller
        ControllerDados Controller = new ControllerDados();
        ControllerRegistar novoRegisto = new ControllerRegistar();
        public frmGereUtilizadores()
        {
                InitializeComponent();

                //atualizar as listbox
                Controller.AtualizarListBox(lstListaProgramadores, Controller.ObterTodosProgramadores());
                Controller.AtualizarListBox(lstListaGestores, Controller.ObterTodosGestores());

                //obter todos os gestores
                var gestores = Controller.ObterTodosGestores();

                //ComboBox Gestor
                cbGestorProg.DataSource = null;
                cbGestorProg.DataSource = gestores;


                //ComboBox NivelExperiencia
                cbNivelProg.DataSource = null;
                cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));

                // ComboBox Departamento
                cbDepartamento.DataSource = null;
                cbDepartamento.DataSource = Enum.GetValues(typeof(Departamento));

                Controller.AtualizarIdUtilizadores(txtIdGestor);
                Controller.AtualizarIdUtilizadores(txtIdProg);
            

        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            //buscar os valores das textbox
            string nome = txtNomeGestor.Text;
            string username = txtUsernameGestor.Text;
            string password = txtPasswordGestor.Text;
            bool gereUtilizadores = chkGereUtilizadores.Checked;

            //departamento selecionado na combobox
            Departamento departamento = (Departamento)cbDepartamento.SelectedIndex;

            //novo registo de um Gestor
            novoRegisto.RegistarGestor(nome, username, password, departamento, gereUtilizadores);

            //atualizar a listbox após inserir dados
            Controller.AtualizarListBox(lstListaGestores, Controller.ObterTodosGestores());
            Controller.AtualizarGestorComboBox(cbGestorProg);

            Controller.AtualizarIdUtilizadores(txtIdGestor);
            Controller.AtualizarIdUtilizadores(txtIdProg);

            LimparCamposGestor();
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            //buscar os valores das textbox
            string nome = txtNomeProg.Text;
            string username = txtUsernameProg.Text;
            string password = txtPasswordProg.Text;

            //gestor selecionado na combobox para ser associado ao programador
            Gestor gestor = (Gestor)cbGestorProg.SelectedItem;

            //NivelExperiencia slecionada na combobox
            NivelExperiencia experiencia = (NivelExperiencia)cbNivelProg.SelectedIndex;

            //novo registo  de um programador
            novoRegisto.RegistarProgramador(nome, username, password, experiencia, gestor.Id);

            //atualizar a listbox após inserir dados
            Controller.AtualizarListBox(lstListaProgramadores, Controller.ObterTodosProgramadores());

            Controller.AtualizarIdUtilizadores(txtIdGestor);
            Controller.AtualizarIdUtilizadores(txtIdProg);

            LimparCamposProgramador();
        }

        private void LimparCamposGestor()
        {
            txtNomeGestor.Text = "";
            txtUsernameGestor.Text = "";
            txtPasswordGestor.Text = "";
        }

        private void LimparCamposProgramador()
        {
            txtNomeProg.Text = "";
            txtUsernameProg.Text = "";
            txtPasswordProg.Text = "";
        }

    }
}
