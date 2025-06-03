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
        //adiciona um tipo tarefa novo atravez do id e da descricao do mesmo
        public void AdicionarTipoTarefa(int id, string desc)
        {

            TipoTarefa tipoTarefa = new TipoTarefa{Id = id,Nome = desc};

            db.TipoTarefa.Add(tipoTarefa);
            db.SaveChanges();
            MessageBox.Show("Tipo de tarefa adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
