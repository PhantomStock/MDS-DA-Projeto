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

        public void SetupBaseDeDados()
        {
            // Configura a base de dados com alguns utilizadores iniciais
            if (!db.Utilizador.Any())
            {
                // Adiciona 1 gestor e 3 programadores iniciais
                db.Utilizador.Add(new Gestor
                {
                    Nome = "Admin",
                    Username = "Admin",
                    Password = "Admin",
                    Departamento = Enums.Departamento.IT,
                    GereUtilizadores = true
                });
                db.Utilizador.Add(new Programador
                {
                    Nome = "Pedro",
                    Username = "Pedro",
                    Password = "Pedro",
                    NivelExperiencia = Enums.NivelExperiencia.Júnior,
                    IdGestor = 1
                });
                db.Utilizador.Add(new Programador
                {
                    Nome = "Wilson",
                    Username = "Wilson",
                    Password = "Wilson",
                    NivelExperiencia = Enums.NivelExperiencia.Júnior,
                    IdGestor = 1
                });
                db.Utilizador.Add(new Programador
                {
                    Nome = "Leonardo",
                    Username = "Leonardo",
                    Password = "Leonardo",
                    NivelExperiencia = Enums.NivelExperiencia.Júnior,
                    IdGestor = 1
                });
                // Salva as alterações na base de dados
                db.SaveChanges();
            }
        }

    }
}
