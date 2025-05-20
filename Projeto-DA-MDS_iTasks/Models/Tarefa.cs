using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTasks.Models.Enums;

namespace iTasks
{
    public class Tarefa
    {
        [Key] public int Id { get; set; }
        public Gestor idGestor { get; set; }
        public Programador IdProgramador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public TipoTarefa IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public EstadoAtual EstadoAtual { get; set; }

        public Tarefa(){
            this.EstadoAtual = EstadoAtual.ToDo;
            this.DataCriacao = DateTime.Now;
        }
        public Tarefa(int id, Gestor idGestor, Programador idProgramador, int OrdemExecucao, string Descricao,
            DateTime DataPrevistaInicio, DateTime DataPrevistaFim, TipoTarefa idTipoTarefa, int StoryPoints, DateTime DataRealInicio,
            DateTime DataRealFim, DateTime DataCriacao, EstadoAtual EstadoAtual)
        {
            this.Id = id;
            this.idGestor = idGestor;
            this.IdProgramador = idProgramador;
            this.OrdemExecucao = OrdemExecucao;
            this.Descricao = Descricao;
            this.DataPrevistaInicio = DataPrevistaInicio;
            this.DataPrevistaFim = DataPrevistaFim;
            this.IdTipoTarefa = idTipoTarefa;
            this.StoryPoints = StoryPoints;
            this.DataRealInicio = DataRealInicio;
            this.DataRealFim = DataRealFim;
            this.DataCriacao = DataCriacao;
            this.EstadoAtual = EstadoAtual;
        }
    }
}
