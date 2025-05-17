using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.DataBase;

namespace iTasks.Controllers
{
    class ControllerKanban
    {
        //Buscar utilizadores por id
        public Utilizador ObterUtilizadorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizadores.FirstOrDefault(u => u.Id == id);
            }
            
        }
    }
}
