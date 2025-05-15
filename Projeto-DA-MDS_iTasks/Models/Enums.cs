using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    class Enums
    {
        public enum Departamento
        {
            IT = 0,
            Marketing = 1,
            Administração = 2
        }

        public enum NivelExperiencia
        {
            Júnior = 0,
            Sénior = 1
        }

        public enum EstadoAtual
        {
            ToDo = 0,
            Doing = 1,
            Done = 2
        }
    }
}
