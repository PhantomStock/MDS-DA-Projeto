using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    public class TipoTarefa
    {
        //Primary Key
        [Key] public int Id { get; set; }
        public string Nome { get; set; }

        public TipoTarefa() { }

        public TipoTarefa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
