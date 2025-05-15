using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            using (var db = new BaseDeDados())
            {
                var utilizador1 = new Utilizador
                {
                    Nome = "João",
                    Username = "wil",
                    Password = "1234",
                };
                db.Utilizadores.Add(utilizador1);
                db.SaveChanges();
            }
        }
    }
}
