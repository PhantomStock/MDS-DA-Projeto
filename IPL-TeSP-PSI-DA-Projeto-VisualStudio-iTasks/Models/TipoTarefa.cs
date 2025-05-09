using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    class TipoTarefa
    {
        [Key] public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public List<Tarefa> Tarefas { get; set; }
    }
}
