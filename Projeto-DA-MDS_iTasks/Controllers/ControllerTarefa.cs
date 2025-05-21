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

        public void criarTarefa(int id) 
        { 
            using (var db = new BaseDeDados())
            {

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
