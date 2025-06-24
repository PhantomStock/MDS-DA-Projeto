using iTasks.Controllers;
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
using static iTasks.Models.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            //atualiza as textboxes dos id com o valor do proximo novo id
            AtualizarIdUtilizadores(0);

            //atualizar as listbox
            lstListaProgramadores.DataSource = null;
            lstListaProgramadores.DataSource = Controller.ObterTodosProgramadores();

            lstListaGestores.DataSource = null;
            lstListaGestores.DataSource = Controller.ObterTodosGestores();

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

            

        }

        //===========================================================================================================
        //CRUD GESTOR
        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeGestor.Text) ||
                string.IsNullOrWhiteSpace(txtUsernameGestor.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordGestor.Text))
            {
                MessageBox.Show("Preencha todos os campos do Gestor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtém os dados do gestor a partir dos campos de texto e checkbox
            string nome = txtNomeGestor.Text;
            string username = txtUsernameGestor.Text;
            string password = txtPasswordGestor.Text;
            bool gereUtilizadores = chkGereUtilizadores.Checked;
            Departamento departamento = (Departamento)cbDepartamento.SelectedIndex;

            // Verifica se é um update ou um novo registo. Vai buscar o id da textbox se o isUpdate for true significa que é um update, se for false é um novo registo.
            int idGestor;
            bool isUpdate = int.TryParse(txtIdGestor.Text, out idGestor) && Controller.ObterGestorPorId(idGestor) != null;

            // Se for um update, atualiza o gestor existente, caso contrário, cria um novo gestor.
            if (isUpdate)
            {
                var gestor = new Gestor
                {
                    Id = idGestor,
                    Nome = nome,
                    Username = username,
                    Password = password,
                    Departamento = departamento,
                    GereUtilizadores = gereUtilizadores
                };
                Controller.AtualizarGestor(gestor);
            }
            else
            {
                // Regista um novo gestor
                novoRegisto.RegistarGestor(nome, username, password, departamento, gereUtilizadores);
            }
            // Atualiza as listas e limpa os campos
            AtualizarListBox(lstListaGestores, Controller.ObterTodosGestores());
            AtualizarGestorComboBox();
    
            AtualizarIdUtilizadores(0);
            LimparCamposGestor();
        }

        private void btnCreateGestor_Click(object sender, EventArgs e)
        {
            // Limpar os campos do gestor e atualiza o ID
            LimparCamposGestor();
            AtualizarIdUtilizadores(1);
        }

        private void btnDeleteGestor_Click(object sender, EventArgs e)
        {
            if (lstListaGestores.SelectedItem is Gestor gestor)
            {
                // Verifica se existe algum programador associado a este gestor
                var programadores = Controller.ObterTodosProgramadores().Where(p => p.IdGestor == gestor.Id).ToList();
                if (programadores.Count > 0)
                {
                    MessageBox.Show("Não é possível eliminar este gestor porque existem programadores associados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Elimina o gestor selecionado
                Controller.EliminarGestor(gestor.Id);

                // Atualizar lista e limpar campos
                AtualizarListBox(lstListaGestores, Controller.ObterTodosGestores());
                AtualizarGestorComboBox();
                LimparCamposGestor();
                AtualizarIdUtilizadores(1);
            }
        }

        //===========================================================================================================
        //CRUD PROGRAMADOR
        private void btGravarProg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeProg.Text) ||
                string.IsNullOrWhiteSpace(txtUsernameProg.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordProg.Text))
            {
                MessageBox.Show("Preencha todos os campos do Programador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém os dados do programador a partir dos campos de texto e combobox
            string nome = txtNomeProg.Text;
            string username = txtUsernameProg.Text;
            string password = txtPasswordProg.Text;
            Gestor gestor = (Gestor)cbGestorProg.SelectedItem;
            NivelExperiencia experiencia = (NivelExperiencia)cbNivelProg.SelectedIndex;

            // Verifica se é um update ou um novo registo. Vai buscar o id da textbox se o isUpdate for true significa que é um update, se for false é um novo registo
            int idProg;
            bool isUpdate = int.TryParse(txtIdProg.Text, out idProg) && Controller.ObterProgramadorPorId(idProg) != null;

            // Se for um update, atualiza o programador existente, caso contrário, cria um novo programador.
            if (isUpdate)
            {
                var programador = new Programador
                {
                    Id = idProg,
                    Nome = nome,
                    Username = username,
                    Password = password,
                    NivelExperiencia = experiencia,
                    IdGestor = gestor.Id
                };
                Controller.AtualizarProgramador(programador);
            }
            else
            {
                // Regista um novo programador
                novoRegisto.RegistarProgramador(nome, username, password, experiencia, gestor.Id);
            }

            // Atualiza as listas e limpa os campos
            AtualizarListBox(lstListaProgramadores, Controller.ObterTodosProgramadores());
            AtualizarIdUtilizadores(0);
            LimparCamposProgramador();
        }

        private void btnCreateProg_Click(object sender, EventArgs e)
        {
            // Limpar os campos do programador e atualiza o ID
            LimparCamposProgramador();
            AtualizarIdUtilizadores(2);
        }

        private void btnDeleteProg_Click(object sender, EventArgs e)
        {
            if (lstListaProgramadores.SelectedItem is Programador programador)
            {
                // Verifica se existe alguma tarefa associada a este programador
                var tarefas = Controller.ObterTarefasPorProgramador(programador.Id);
                if (tarefas.Count > 0)
                {
                    MessageBox.Show("Não é possível eliminar este programador porque existem tarefas associadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Controller.EliminarProgramador(programador.Id);

                // Atualiza lista e limpa os campos
                AtualizarListBox(lstListaProgramadores, Controller.ObterTodosProgramadores());
                LimparCamposProgramador(); 
                AtualizarIdUtilizadores(2);
            }
        }


        //===========================================================================================================
        // Métodos para limpar os campos de texto
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


        //===========================================================================================================
        // Eventos para preencher os campos de texto com os dados dos utilizadores quando um item é selecionado 
        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListaProgramadores.SelectedItem is Programador programador)
            {
                // Preencher as text boxes com os dados do programador
                txtIdProg.Text = programador.Id.ToString();
                txtNomeProg.Text = programador.Nome;
                txtUsernameProg.Text = programador.Username;
                txtPasswordProg.Text = programador.Password;
                cbNivelProg.SelectedItem = programador.NivelExperiencia;

                // Selecionar o gestor correspondente no ComboBox
                foreach (Gestor gestor in cbGestorProg.Items)
                {
                    if (gestor.Id == programador.IdGestor)
                    {
                        cbGestorProg.SelectedItem = gestor;
                        break;
                    }
                }
            }
        }

        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListaGestores.SelectedItem is Gestor gestor)
            {
                // Preencher as text boxes com os dados do gestor
                txtIdGestor.Text = gestor.Id.ToString();
                txtNomeGestor.Text = gestor.Nome;
                txtUsernameGestor.Text = gestor.Username;
                txtPasswordGestor.Text = gestor.Password;
                cbDepartamento.SelectedItem = gestor.Departamento;
                chkGereUtilizadores.Checked = gestor.GereUtilizadores;
            }
        }


        //btn de voltar para o form kanban
        private void btVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //funcoes de atualização
        public void AtualizarIdUtilizadores(int tipo)
        {
            int proximoId = Controller.ObterProximoIdUtilizador();
            
            if (tipo == 0) //0 atualiza os 2
            {
                txtIdGestor.Text = proximoId.ToString();
                txtIdProg.Text = proximoId.ToString();
            } 
            else if (tipo == 1) //1 atualiza so o gestor
            {
                txtIdGestor.Text = proximoId.ToString();
            } else if (tipo == 2) //atualiza so o programador
            {
                txtIdProg.Text = proximoId.ToString();
            }
            
        }


        public void AtualizarListBox<T>(ListBox listBox, List<T> dataSource)
        {
            listBox.DataSource = null;
            listBox.DataSource = dataSource;
        }

        public void AtualizarGestorComboBox()
        {
            cbGestorProg.DataSource = null;
            cbGestorProg.DataSource = Controller.ObterTodosGestores();
        }

        private void frmGereUtilizadores_Load(object sender, EventArgs e)
        {

        }
    }
}
