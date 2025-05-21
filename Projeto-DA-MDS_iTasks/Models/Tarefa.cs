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
        public Tarefa(Tarefa tarefa)
        {
            this.Id = tarefa.Id;
            this.idGestor = tarefa.idGestor;
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
        public string ToStringCustom(int tipo)
        {
            if (tipo == 1)
            {
                string ids = $"{this.Id},{this.idGestor},{this.IdProgramador},{this.IdTipoTarefa}";
                string datas = $"{this.DataPrevistaInicio},{this.DataPrevistaFim},{this.DataRealInicio},{this.DataRealFim},{this.DataCriacao}";

                return $"{ids},{this.Descricao},{this.OrdemExecucao},{this.OrdemExecucao},{datas},{this.EstadoAtual},{this.StoryPoints}";
            }
            else
            {
                return $"{this.Descricao}";
            }
        }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
