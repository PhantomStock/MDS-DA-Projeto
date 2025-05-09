using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    class Gestor : Utilizador
    {
        public string Departamento { get; set; }
        // "IT", "Marketing", "Administração"  
        public bool GereUtilizadores { get; set; }
        public List<Programador> Programadores { get; set; }
        public List<Tarefa> TarefasCriadas { get; set; }
    }
}
