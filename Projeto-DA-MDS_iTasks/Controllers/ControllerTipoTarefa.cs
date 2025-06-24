using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controllers
{
    class ControllerTipoTarefa
    {
        BaseDeDados db => BaseDeDados.Instance;

        private ControllerDados controllerDados = new ControllerDados();
        //adiciona um tipo tarefa novo atravez do id e da descricao do mesmo
        public void AdicionarTipoTarefa(int id, string desc)
        {
            TipoTarefa tipoTarefa = new TipoTarefa { Id = id, Nome = desc };

            db.TipoTarefa.Add(tipoTarefa);
            db.SaveChanges();
            MessageBox.Show("Tipo de tarefa adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AtualizarIdTipoTarefa(TextBox textBox)
        {
            int proximoId = ObterProximoIdTipoTarefa();
            textBox.Text = proximoId.ToString();
        }

        //precisamos criar esta query para ir buscar o proximo id, O EF nao vai garantir o proximo id na base de dados
        public int ObterProximoIdTipoTarefa()
        {
            var result = db.Database.SqlQuery<decimal>(
                "SELECT IDENT_CURRENT('TipoTarefas') + IDENT_INCR('TipoTarefas')"
            ).FirstOrDefault();
            return Convert.ToInt32(result);

        }

        public void EliminarTipoTarefa(int idTipoTarefa)
        {
            var tipoTarefa = db.TipoTarefa.Find(idTipoTarefa);
            if (tipoTarefa != null)
            {
                db.TipoTarefa.Remove(tipoTarefa);
                db.SaveChanges();
            }
        }
    }
}
