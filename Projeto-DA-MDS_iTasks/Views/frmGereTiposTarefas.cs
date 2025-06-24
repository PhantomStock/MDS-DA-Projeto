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

namespace iTasks
{
    public partial class frmGereTiposTarefas : Form
    {
        BaseDeDados db => BaseDeDados.Instance;
        ControllerDados controllerDados = new ControllerDados();
        ControllerTipoTarefa controllerTipoTarefa = new ControllerTipoTarefa();
        public frmGereTiposTarefas()
        {
            InitializeComponent();
            RefreshDataSourceTipoTarefa();

        }

        // cria um novo tipo de tarefa
        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Preencha a descrição do tipo de tarefa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTipoTarefa;
            bool isUpdate = int.TryParse(txtId.Text, out idTipoTarefa) && controllerDados.ObterTipoTarefaPorId(idTipoTarefa) != null;

            if (isUpdate)
            {
                // Atualizar tipo de tarefa existente
                var tipoTarefa = controllerDados.ObterTipoTarefaPorId(idTipoTarefa);
                tipoTarefa.Nome = txtDesc.Text;
                db.SaveChanges();
                MessageBox.Show("Tipo de tarefa atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Criar novo tipo de tarefa
                controllerTipoTarefa.AdicionarTipoTarefa(idTipoTarefa, txtDesc.Text);
            }

            RefreshDataSourceTipoTarefa();
            LimparCamposTipoTarefa();
        }

        // recarrega o DataSource da lista de tipos de tarefa
        private void RefreshDataSourceTipoTarefa()
        {
            //recebe e carrega na combo box todos os tipos de tarefa
            List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

            lstLista.DataSource = null;
            lstLista.DataSource = TiposTarefas;

            controllerTipoTarefa.AtualizarIdTipoTarefa(txtId);
        }

        private void btnCriarTipoTarefa_Click(object sender, EventArgs e)
        {
            LimparCamposTipoTarefa();
        }

        private void btnEliminarTipoTarefa_Click(object sender, EventArgs e)
        {
            if (lstLista.SelectedItem is TipoTarefa tipoSelecionado)
            {
                controllerTipoTarefa.EliminarTipoTarefa(tipoSelecionado.Id);
            }

            LimparCamposTipoTarefa();
            RefreshDataSourceTipoTarefa();
        }

        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLista.SelectedItem is TipoTarefa tipo)
            {
                txtId.Text = tipo.Id.ToString();
                txtDesc.Text = tipo.Nome;
            }
        }


        private void LimparCamposTipoTarefa() {
            controllerTipoTarefa.AtualizarIdTipoTarefa(txtId);
            txtDesc.Clear();
        }
    }
}
