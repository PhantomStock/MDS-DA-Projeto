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
        BaseDeDados db => BaseDeDados.Instance;
        //regista um utilizador padrão (vai sair daqui)

        //Não da pra registar utilizadores(Isto fazia parte do FormRegistarAntigo que não foi utilizado!!)
        public void RegistarUtilizador(string nome, string username, string password)
        {
            var user = db.Utilizador
            .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                var utilizador = new Utilizador(nome, username, password);
                db.Utilizador.Add(utilizador);
                db.SaveChanges();

                MessageBox.Show("Utilizador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //regista um programador
        public void RegistarProgramador(string nome, string username, string password, NivelExperiencia experiencia, int idGestor)
        {
            var user = db.Utilizador
            .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                var programador = new Programador(nome, username, password, experiencia, idGestor);
                db.Utilizador.Add(programador);
                db.SaveChanges();

                MessageBox.Show("Programador registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //regista um gestor
        public void RegistarGestor(string nome, string username, string password, Departamento departamento, bool gereUtilizadores)
        {
            var user = db.Utilizador
            .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                var gestor = new Gestor(nome, username, password, departamento, gereUtilizadores);
                db.Utilizador.Add(gestor);
                db.SaveChanges();

                MessageBox.Show("Gestor registado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        
    }
}     
   



