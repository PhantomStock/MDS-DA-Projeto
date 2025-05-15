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
        Júnior = 0,
        Sénior = 1
    }
    class Programador : Utilizador
    {
        public NivelExperiencia NivelExperiencia { get; set; }
        public Gestor idGestor { get; set; }
    }
}
