using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace iTasks.DataBase
{
    class BaseDeDados : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Programador> Programadores { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TipoTarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Utilizador>().ToTable("Utilizadores");
            modelBuilder.Entity<Programador>().ToTable("Programadores");
            modelBuilder.Entity<Gestor>().ToTable("Gestores");

            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Gestor)
                .WithMany(g => g.Tarefas)
                .HasForeignKey(t => t.IdGestor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Programador)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.IdProgramador)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
