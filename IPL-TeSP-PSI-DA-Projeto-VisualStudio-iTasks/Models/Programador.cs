using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    class Programador : Utilizador
    {
        [Key] public int Id { get; set; }
        public string NivelExperiencia { get; set; }
        // "Júnior", "Sénior"
        public Gestor Gestor { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public int IdGestor { get; set; }
        
    }
}
