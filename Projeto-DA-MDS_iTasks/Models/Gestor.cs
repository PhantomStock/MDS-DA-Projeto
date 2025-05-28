using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static iTasks.Models.Enums;

namespace iTasks
{
    // Este ficheiro contém a definição da classe Gestor, que herda a classe Utilizador.
    public class Gestor : Utilizador
    {
        public Departamento Departamento { get; set; }
        public bool GereUtilizadores { get; set; }

        public Gestor() { }
        public Gestor (string nome, string username, string password, Departamento departamento,bool gereUtilizador) 
        : base (nome, username, password)
        {

            this.Departamento = Departamento;
            this.GereUtilizadores = GereUtilizadores;
        }

        // override ao tostring para apresentar o nome de utilizador do gestor
        public override string ToString()
        {

            return this.Username;
        }


    }
}
