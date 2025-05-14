using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum NivelExperiencia
    {
        Júnior,
        Sénior
    }
    class Programador : Utilizador
    {
        public NivelExperiencia NivelExperiencia { get; set; }
        // "Júnior", "Sénior"

        //Foregeing Key (e necessario instanciar a um gestor e o entiy framework identifica a key)
        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; }
        public List<Tarefa> Tarefas { get; set; }

    }
}
