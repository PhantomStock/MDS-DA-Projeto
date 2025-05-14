using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum Departamento
    {
        IT,
        Marketing,
        Administração
    }

    class Gestor : Utilizador
    {
        public Departamento Departamento { get; set; }
        // "IT", "Marketing", "Administração"  
        public bool GereUtilizadores { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public List<Programador> Programadores { get; set; }
    }
}
