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
        public void AdicionarTipoTarefa(int id, string desc)
        {
           using (var db = new BaseDeDados())
           {
                TipoTarefa tipoTarefa = new TipoTarefa{Id = id,Nome = desc};

                db.TipoTarefas.Add(tipoTarefa);
                db.SaveChanges();
                MessageBox.Show("Tipo de tarefa adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
