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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        //Intanciar o controllerDados
        ControllerDados controllerDados = new ControllerDados();
        //Intanciar o controllerRegistar
        ControllerRegistar controllerRegistar = new ControllerRegistar();
        public frmGereUtilizadores()
        {
            InitializeComponent();

            //atualiza as textboxes dos id com o valor do proximo novo id
            AtualizarIdUtilizadores(0);

            //atualizar as listbox dos programadores
            lstListaProgramadores.DataSource = null;
            lstListaProgramadores.DataSource = controllerDados.ObterTodosProgramadores();

            //atualizar as listbox dos gestores
            lstListaGestores.DataSource = null;
            lstListaGestores.DataSource = controllerDados.ObterTodosGestores();

            //obter todos os gestores
            var gestores = controllerDados.ObterTodosGestores();

            //ComboBox Gestor carregar os gestores
            cbGestorProg.DataSource = null;
            cbGestorProg.DataSource = gestores;

            //ComboBox NivelExperiencia carregar os niveis de experiencia
            cbNivelProg.DataSource = null;
            cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));

            // ComboBox Departamento carregar os departamentos
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

            // Verifica se é um update ou um novo registo.
            // Vai buscar o id da textbox se o isUpdate for true significa que é um update, se for false é um novo registo.

            // Obtém o ID do gestor a partir da textbox txtIdGestor
            int idGestor = (int)txtIdGestor.Value;

            // Verifica se o gestor já existe na base de dados
            bool isUpdate = controllerDados.ObterGestorPorId(idGestor) != null;

            //Se não existir ele cria um novo se não ele atualiza o gestor existente
            // Se for um update, atualiza o gestor existente, caso contrário, cria um novo gestor.
            if (isUpdate)
            {
                // Atualiza o gestor existente
                var gestor = new Gestor
                {
                    Id = idGestor,
                    Nome = nome,
                    Username = username,
                    Password = password,
                    Departamento = departamento,
                    GereUtilizadores = gereUtilizadores
                };
                controllerDados.atualizarDadosGestor(gestor);
            }
            else
            {
                // Regista um novo gestor
                controllerRegistar.RegistarGestor(nome, username, password, departamento, gereUtilizadores);
            }
            // Atualiza as listas e limpa os campos
            AtualizarListBox(lstListaGestores, controllerDados.ObterTodosGestores());

            // Atualiza o ComboBox de gestores para programadores poderem selecionar
            AtualizarGestorComboBox();

            // Atualiza o ID dos utilizadores
            AtualizarIdUtilizadores(0);

            // Limpa os campos do gestor
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
                var programadores = controllerDados.ObterTodosProgramadores().Where(p => p.IdGestor == gestor.Id).ToList();
                if (programadores.Count > 0)
                {
                    MessageBox.Show("Não é possível eliminar este gestor porque existem programadores associados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (SessaoAtual.Utilizador.Id == gestor.Id) {
                    MessageBox.Show("Um gestor não se pode eleminar a ele mesmo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var gestoresComPermissao = controllerDados.ObterTodosGestores().Where(g => g.GereUtilizadores).ToList();
                if (gestoresComPermissao.Count == 1 && gestoresComPermissao[0].Id == gestor.Id)
                {
                    MessageBox.Show("Não pode existir menos de 1 gestor com a capacidade de gerir utilizadores!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Elimina o gestor selecionado
                controllerDados.EliminarGestor(gestor.Id);

                // Atualizar lista e limpar campos
                AtualizarListBox(lstListaGestores, controllerDados.ObterTodosGestores());
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

            // Obtém o ID do programador a partir da textbox txtIdProg
            int idProg = (int)txtIdProg.Value;

            // Verifica se o programador já existe na base de dados
            bool isUpdate = controllerDados.ObterProgramadorPorId(idProg) != null;

            //Se não existir ele cria um novo se não ele atualiza o programador existente
            // Se for um update, atualiza o programador existente, caso contrário, cria um novo programador.
            if (isUpdate)
            {
                // Atualiza o programador existente
                var programador = new Programador
                {
                    Id = idProg,
                    Nome = nome,
                    Username = username,
                    Password = password,
                    NivelExperiencia = experiencia,
                    IdGestor = gestor.Id
                };
                controllerDados.AtualizarDadosProgramador(programador);
            }
            else
            {
                // Regista um novo programador
                controllerRegistar.RegistarProgramador(nome, username, password, experiencia, gestor.Id);
            }

            // Atualiza as listas e limpa os campos
            AtualizarListBox(lstListaProgramadores, controllerDados.ObterTodosProgramadores());
            AtualizarIdUtilizadores(0);
            LimparCamposProgramador();
        }
        //boto para criar um novo programador
        //==========================================================================================================================
        private void btnCreateProg_Click(object sender, EventArgs e)
        {
            // Limpar os campos do programador e atualiza o ID
            LimparCamposProgramador();
            AtualizarIdUtilizadores(2);
        }
        //boto para deletar um programador
        //===========================================================================================================================
        private void btnDeleteProg_Click(object sender, EventArgs e)
        {
            if (lstListaProgramadores.SelectedItem is Programador programador)
            {
                // Verifica se existe alguma tarefa associada a este programador
                var tarefas = controllerDados.ObterTarefasPorProgramador(programador.Id);
                if (tarefas.Count > 0)
                {
                    MessageBox.Show("Não é possível eliminar este programador porque existem tarefas associadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                controllerDados.EliminarProgramador(programador.Id);

                // Atualiza lista e limpa os campos
                AtualizarListBox(lstListaProgramadores, controllerDados.ObterTodosProgramadores());
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
                txtIdProg.Value = programador.Id;
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
        // Evento para preencher os campos de texto com os dados do gestor quando um item é selecionado
        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListaGestores.SelectedItem is Gestor gestor)
            {
                // Preencher as text boxes com os dados do gestor
                txtIdGestor.Value = gestor.Id;
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

        //funcoes de atualizações
        public void AtualizarIdUtilizadores(int tipo)
        {
            int proximoId = controllerDados.ObterProximoIdUtilizador();
            
            if (tipo == 0) //0 atualiza os 2
            {
                txtIdGestor.Value = proximoId;
                txtIdProg.Value = proximoId;
            } 
            else if (tipo == 1) //1 atualiza so o gestor
            {
                txtIdGestor.Value = proximoId;
            } else if (tipo == 2) //atualiza so o programador
            {
                txtIdProg.Value = proximoId;
            }
            
        }

        //?????
        //======================================================================
        public void AtualizarListBox<T>(ListBox listBox, List<T> dataSource)
        {
            listBox.DataSource = null;
            listBox.DataSource = dataSource;
        }

        public void AtualizarGestorComboBox()
        {
            cbGestorProg.DataSource = null;
            cbGestorProg.DataSource = controllerDados.ObterTodosGestores();
        }

    }
}
