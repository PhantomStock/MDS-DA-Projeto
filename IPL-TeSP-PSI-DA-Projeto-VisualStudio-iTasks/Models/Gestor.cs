using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public enum Departamento
    {
        IT = 0,
        Marketing = 1,
        Administração = 2
    }
    class Gestor : Utilizador
    {
        public Departamento Departamento { get; set; }
        public bool GereUtilizadores { get; set; }
    }
}
