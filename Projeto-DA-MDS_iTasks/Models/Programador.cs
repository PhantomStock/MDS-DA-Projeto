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
    // Este ficheiro contém a definição da classe Programador, que herda a classe Utilizador.
    public class Programador : Utilizador
    {
        public NivelExperiencia NivelExperiencia { get; set; }
        public int idGestor { get; set; }

        public Programador() { }

        public Programador(string nome, string username, string password, NivelExperiencia experiencia, int idGestor)
        : base(nome, username, password)
        {
            this.NivelExperiencia = experiencia;
            this.idGestor = idGestor;
        }

        // Override ao tostring para apresentar o nome de utilizador do programador
        public override string ToString()
        {
            return this.Username;

        }

    }
}
