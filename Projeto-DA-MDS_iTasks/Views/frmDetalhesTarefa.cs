using iTasks.Controllers;
using iTasks.DataBase;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {
        ControllerDados controllerDados = new ControllerDados();
        public frmDetalhesTarefa(int id)
        {
            InitializeComponent();
            using (var db = new BaseDeDados()) 
            {
                //recebe e carrega na combo box todos os tipos de tarefa
                List<TipoTarefa> TiposTarefas = controllerDados.ObterTodosTiposTarefas();

                cbTipoTarefa.DataSource = null;
                cbTipoTarefa.DataSource = TiposTarefas;

                //recebe e carrega na combo boxx todos os programadores
                List<Programador> Programadores = controllerDados.ObterTodosProgramdores();
                
                cbProgramador.DataSource = null;
                cbProgramador.DataSource = Programadores;              

                if (id == -1)
                {
                    NovaTarefa();
                }
                else
                {
                    CarregaDadosTarefa(id);
                }
            }
            

        }

        public void CarregaDadosTarefa(int idTarefa)
        {
            using(var db = new BaseDeDados())
            {
                var tarefa = db.Tarefas
                    .FirstOrDefault(t => t.Id == idTarefa);

                if (tarefa == null)
                {
                    MessageBox.Show("Tarefa não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else {
                    txtId.Text = tarefa.Id.ToString();
                    txtEstado.Text = tarefa.EstadoAtual.ToString();
                    txtDataCriacao.Text = tarefa.DataCriacao.ToString("dd/MM/yyyy");
                    txtDataRealini.Text = tarefa.DataRealInicio.ToString("dd/MM/yyyy");
                    txtDataRealFim.Text = tarefa.DataRealFim.ToString("dd/MM/yyyy");
                    txtDesc.Text = tarefa.Descricao;


                }


                //cbTipoTarefa.SelectedItem = tarefa.IdTipoTarefa.ToString(); //?
                //cbProgramador.SelectedItem = tarefa.idGestor.Nome;//?

                txtOrdem.Text = tarefa.OrdemExecucao.ToString();
                txtStoryPoints.Text = tarefa.StoryPoints.ToString();

                if (tarefa.DataPrevistaInicio != null)
                {
                    dtInicio.Value = tarefa.DataPrevistaInicio;
                }
                if (tarefa.DataPrevistaFim != null)
                {
                    dtFim.Value = tarefa.DataPrevistaFim;
                }
            }
            
        }

        public void NovaTarefa()
        {
            using (var db = new BaseDeDados())
            {
                var ultimoId = db.Tarefas
                    .OrderByDescending(t => t.Id)
                    .Select(t => t.Id)
                    .FirstOrDefault();

                txtId.Text = ultimoId+1.ToString();
                txtEstado.Text = Enums.EstadoAtual.ToDo.ToString();
                txtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }
        }
    }
}
