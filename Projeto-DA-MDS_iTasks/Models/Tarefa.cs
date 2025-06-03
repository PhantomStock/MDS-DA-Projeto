using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity; // teste
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTasks.Models.Enums;

namespace iTasks
{
    // Este ficheiro contém a definição da classe Tarefa, que representa uma tarefa no sistema de gestão de tarefas.

    public class Tarefa
    {
        [Key] public int Id { get; set; }
        public int IdGestor { get; set; }
        public int IdProgramador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataPrevistaInicio { get; set; }
        public DateTime? DataPrevistaFim { get; set; }
        public int IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime? DataRealInicio { get; set; }
        public DateTime? DataRealFim { get; set; }
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        public EstadoAtual EstadoAtual { get; set; }

        // Construtor padrão
        public Tarefa(){
            this.EstadoAtual = EstadoAtual.ToDo;
            this.DataCriacao = DateTime.Now;
        }

        // Construtor que recebe uma tarefa existente ou pre formatada (par afazer update)
        public Tarefa(Tarefa tarefa)
        {
            this.Id = tarefa.Id;
            this.IdGestor = tarefa.IdGestor;
            this.IdProgramador = tarefa.IdProgramador;
            this.OrdemExecucao = tarefa.OrdemExecucao;
            this.Descricao = tarefa.Descricao;
            this.DataPrevistaInicio = tarefa.DataPrevistaInicio;
            this.DataPrevistaFim = tarefa.DataPrevistaFim;
            this.IdTipoTarefa = tarefa.IdTipoTarefa;
            this.StoryPoints = tarefa.StoryPoints;
            this.DataRealInicio = tarefa.DataRealInicio;
            this.DataRealFim = tarefa.DataRealFim;
            this.DataCriacao = tarefa.DataCriacao;
            this.EstadoAtual = tarefa.EstadoAtual;
        }
       

        // Override ao toString para apresetnar informação da descricao da tarefa
        public override string ToString()
        {
            return this.Descricao;
        }
    }

    public class TarefaDbContext : DbContext //teste
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public List<Tarefa> GetTarefasWithIncludes()
        {
            return Tarefas
                .Include(t => t.IdGestor)
                .Include(t => t.IdProgramador)
                .Include(t => t.IdTipoTarefa)
                .ToList();
        }
    }
}
