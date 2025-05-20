using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.DataBase;
using System.IO;
using System.Collections.ObjectModel;
using iTasks.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data.Entity;

namespace iTasks.Controllers
{
    class ControllerTarefa
    {
        public void CarregaOuCriaTarefa(int id)
        {
            using (var db = new BaseDeDados())
            {
                var Tarefa = db.Tarefas
                    .Where(t => t.Id == id)
                    .FirstOrDefault();
                if (Tarefa == null)
                {
                    //nova tarefa
                    frmDetalhesTarefa frmDetalhesTarefa = new frmDetalhesTarefa(new Tarefa());
                    frmDetalhesTarefa.Show();
                } else
                {
                    //tarefa existente
                    frmDetalhesTarefa frmDetalhesTarefa = new frmDetalhesTarefa(Tarefa);
                    frmDetalhesTarefa.Show();
                }
                
            }
        }
    }
}
