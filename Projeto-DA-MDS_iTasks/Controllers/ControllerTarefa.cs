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

        public void CriarTarefa(Tarefa tarefa) 
        { 
            using (var db = new BaseDeDados())
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                MessageBox.Show("Tarefa criada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public void updateTarefa() 
        { 
        
        }

        public Tarefa loadTarefa(int id) 
        {
            using (var db = new BaseDeDados()) 
            {
                var tarefa = db.Tarefas
                    .FirstOrDefault(t => t.Id == id);

                return tarefa;
            }
        }

    }
}
