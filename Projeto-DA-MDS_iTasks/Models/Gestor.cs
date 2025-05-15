using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public Gestor() { }
        public Gestor (string nome, string username, string password, Departamento departamento,bool gereUtilizador) 
        : base (nome, username, password)
        {

            this.Departamento = Departamento;
            this.GereUtilizadores = GereUtilizadores;
        }

        public override string ToString()
        {

            return this.Username;
        }


    }
}
