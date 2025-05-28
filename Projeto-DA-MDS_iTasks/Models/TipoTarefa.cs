using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    // Este ficheiro contém a definição da classe TipoTarefa, que representa um tipo de tarefa no sistema de gestão de tarefas.
    public class TipoTarefa
    {
        [Key] public int Id { get; set; }
        public string Nome { get; set; }

        public TipoTarefa() { }

        // construtor que recebe os parâmetros necessários para criar um TipoTarefa
        public TipoTarefa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // override ao ToString para apresentar o nome do tipo de tarefa
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
