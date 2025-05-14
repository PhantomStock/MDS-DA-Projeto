using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum EstadoAtual
    {
        ToDo = 0,
        Doing = 1,
        Done = 2
    }
    class Tarefa
    {
        //Primary Key
        [Key] public int Id { get; set; }
        //Foregeing Key (e necessario instanciar a um gestor e o entiy framework identifica a key)
        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; }
        //Foregeing Key (e necessario instanciar a um gestor e o entiy framework identifica a key)
        public int IdProgramador { get; set; }
        public Programador Programador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public int IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public EstadoAtual EstadoAtual { get; set; }
        // "ToDo", "Doing", "Done"
    }
}

