using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    class Tarefa
    {
        [Key] public int Id { get; set; }
        public string Descricao { get; set; }
        public int OrdemExecucao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string EstadoAtual { get; set; } = "ToDo"; 
        // "ToDo", "Doing", "Done"
        public int StoryPoints { get; set; }
        public int IdTipoTarefa { get; set; }
        public TipoTarefa TipoTarefa { get; set; }
        /*============================================*/
        public int IdGestor { get; set; }
        [ForeignKey("IdGestor")]
        /*============================================*/
        public int IdProgramador { get; set; }
        [ForeignKey("IdProgramador")]
        /*============================================*/
        public Programador Programador { get; set; }
        public Gestor Gestor { get; set; }




        /*Ainda falta coisas, consultar o mestre Pedro */

    }
}
