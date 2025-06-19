using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Models;

namespace iTasks.Controllers
{
    class ControllerLogin
    {
        BaseDeDados db => BaseDeDados.Instance;
        public Utilizador Login(string username, string password)
        {
            // verifica as credenciais inseridas e compara com as da base de dados
            var utilizador = db.Utilizador
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            SessaoAtual.Utilizador = utilizador; // Guarda o utilizador na sessão atual

            return utilizador;

        }

    }
}
