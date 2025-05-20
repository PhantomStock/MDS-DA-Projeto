using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTasks.Models.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Controllers
{
    class ControllerRegistar
    {
        BaseDeDados db;

        public void RegistarUtilizador(string nome, string username, string password)
        {
            using (var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    var utilizador = new Utilizador(nome, username, password);
                    db.Utilizadores.Add(utilizador);
                    db.SaveChanges();

                    MessageBox.Show("Utilizador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void RegistarProgramador(string nome, string username, string password, NivelExperiencia experiencia, int idGestor)
        {
            using (var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    var programador = new Programador(nome, username, password, experiencia, idGestor);
                    db.Utilizadores.Add(programador);
                    db.SaveChanges();

                    MessageBox.Show("Programador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void RegistarGestor(string nome, string username, string password, Departamento departamento, bool gereUtilizadores)
        {
            using (var db = new BaseDeDados())
            {
                var user = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    var gestor = new Gestor(nome, username, password, departamento, gereUtilizadores);
                    db.Utilizadores.Add(gestor);
                    db.SaveChanges();

                    MessageBox.Show("Gestor registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Query base de dados que retorna todos os gestores
        public List<Gestor> ObterGestores()
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizadores.OfType<Gestor>().ToList();
            }
        }
    }
}     
   



