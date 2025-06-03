using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace iTasks.DataBase
{
    // Classe que representa a base de dados, herda de DbContext do Entity Framework
    public class BaseDeDados : DbContext
    {
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Programador> Programador { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<TipoTarefa> TipoTarefa { get; set; }

        public static BaseDeDados _instance;

        public static BaseDeDados Instance 
        { 
            get
            {
                if (_instance == null)
                {
                    _instance = new BaseDeDados();
                    _instance.Utilizador.Load();
                    _instance.Gestor.Load();
                    _instance.Programador.Load();
                    _instance.TipoTarefa.Load();
                    _instance.Tarefa.Load();
                }
                return _instance;
            }

        }
    }
}
