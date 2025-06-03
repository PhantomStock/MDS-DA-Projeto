using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.DataBase;
using System.IO;
using System.Collections.ObjectModel;
using iTasks.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data.Entity;

namespace iTasks.Controllers
{
    class ControllerTarefa
    {
        BaseDeDados db => BaseDeDados.Instance;
        //recebe um objeto tarefa e adiciona-o à base de dados
        public void CriarTarefa(Tarefa tarefa) 
        { 

            db.Tarefa.Add(tarefa);
            db.SaveChanges();
            MessageBox.Show("Tarefa criada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //recebe um objeto tarefa e faz update da tarefa na base de dados
        public void updateTarefa(Tarefa tarefa) 
        { 
            //pegar na tarefa que vem e fazer update aos dados da base de dados com os novos valores
            using (var db = new BaseDeDados())
            {
                var tarefaDb = db.Tarefa.FirstOrDefault(t => t.Id == tarefa.Id);
                if (tarefaDb != null)
                {
                    tarefaDb.Descricao = tarefa.Descricao;
                    tarefaDb.DataCriacao = tarefa.DataCriacao;
                    tarefaDb.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                    tarefaDb.DataPrevistaFim = tarefa.DataPrevistaFim;
                    tarefaDb.DataRealInicio = tarefa.DataRealInicio;
                    tarefaDb.DataRealFim = tarefa.DataRealFim;
                    tarefaDb.EstadoAtual = tarefa.EstadoAtual;
                    tarefaDb.StoryPoints = tarefa.StoryPoints;
                    tarefaDb.OrdemExecucao = tarefa.OrdemExecucao;
                    tarefaDb.IdTipoTarefa = tarefa.IdTipoTarefa;
                    tarefaDb.IdProgramador = tarefa.IdProgramador;
                    tarefaDb.IdGestor = tarefa.IdGestor;

                    db.SaveChanges();
                    MessageBox.Show("Tarefa atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tarefa não encontrada para atualização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //recebe um id e remove a tarefa correspondente da base de dados
        public Tarefa loadTarefa(int id) 
        {

            var tarefa = db.Tarefa
                .FirstOrDefault(t => t.Id == id);

            return tarefa;
        }

    }
}
