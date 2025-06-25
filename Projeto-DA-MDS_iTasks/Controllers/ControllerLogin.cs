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

            return utilizador;
        }

        //carrega a base de dados com utilizadores iniciais
        public void SetupBaseDeDados()
        {
            // Configura a base de dados com alguns utilizadores iniciais
            if (!db.Gestor.Any(g => g.GereUtilizadores))
            {
                // Adiciona 1 gestor e 3 programadores iniciais
                db.Utilizador.Add(new Gestor
                {
                    Nome = "admin",
                    Username = "admin",
                    Password = "admin",
                    Departamento = Enums.Departamento.Administração,
                    GereUtilizadores = true
                });
                // Salva as alterações na base de dados
                db.SaveChanges();
            }
        }
    }
}
