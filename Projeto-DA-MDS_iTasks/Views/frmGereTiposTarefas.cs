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
        ControllerDados controllerDados = new ControllerDados();
        public frmGereTiposTarefas()
        {
            InitializeComponent();
            RefreshDataSourceTipoTarefa();

        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("A Descrição do tipo de tarefa não pode estar vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                ControllerTipoTarefa controllerTarefa = new ControllerTipoTarefa();

                controllerTarefa.AdicionarTipoTarefa(Convert.ToInt32(txtId.Text), txtDesc.Text);

                //refresh ao DataSource
                RefreshDataSourceTipoTarefa();
            }
        }

        private void RefreshDataSourceTipoTarefa()
        {
            using (var db = new BaseDeDados())
            {
                //recebe e carrega na combo box todos os tipos de tarefa
                List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

                lstLista.DataSource = null;
                lstLista.DataSource = TiposTarefas;

                int tipoTarefaIdAnterior = 0;
                foreach (TipoTarefa tipoTarefa in TiposTarefas)
                {
                    if (tipoTarefa.Id > tipoTarefaIdAnterior)
                    {
                        tipoTarefaIdAnterior = tipoTarefa.Id;
                    }
                }

                txtId.Text = (tipoTarefaIdAnterior + 1).ToString();
            }
        }
    }
}
