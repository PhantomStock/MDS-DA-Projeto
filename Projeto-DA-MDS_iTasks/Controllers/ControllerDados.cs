using iTasks.DataBase;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controllers
{
    class ControllerDados
    {
        BaseDeDados db => BaseDeDados.Instance;
        //obtem uma list com todos os gestores
        public List<Gestor> ObterTodosGestores()
        {
            return db.Utilizador.OfType<Gestor>().ToList();
    
        }

        //obtem uma list com todos os programadores
        public List<Programador> ObterTodosProgramdores()
        {
            return db.Utilizador.OfType<Programador>().ToList();
        }

        //obtem uma list com todos os utilizadores
        public List<Utilizador> ObterTodosUtilizadores()
        {
           return db.Utilizador.ToList();
        }

        //obtem um list com todas as tarefas
        public List<Tarefa> ObterTodasTarefas()
        {

              return db.Tarefa.ToList();

        }

        //Obtem uma list com todos os tipos de tarefa
        public List<TipoTarefa> ObterTodosTiposTarefas()
        {
            using (var db = new BaseDeDados())
            {
                return db.TipoTarefa.ToList();
            }
        }

        //Obtem um utilizador pelo id
        public Utilizador ObterUtilizadorPorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.FirstOrDefault(u => u.Id == id);
            }
        }

        //obtem um programdor pelo id
        public Programador ObterProgramadorPorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Id == id);
            }
        }

        //obtem um gestor pelo id
        public Gestor ObterGestorPorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Id == id);
            }
        }

        //obtem uma tarefa pelo id
        public Tarefa ObterTarefaPorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.FirstOrDefault(t => t.Id == id);
            }
        }

        //obtem um tipo de tarefa pelo id
        public TipoTarefa ObterTipoTarefaPorId(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.TipoTarefa.FirstOrDefault(t => t.Id == id);
            }
        }

        //obter gestor por username
        public Gestor ObterGestorPorUsername(string Username)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Username == Username);
            }
        }

        //obter programador por username
        public Programador ObterProgramadorPorUsername(string Username)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Username == Username);
            }
        }

        //obter utilizador por username
        public Utilizador ObterUtilizadorPorUsername(string Username)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizador.FirstOrDefault(u => u.Username == Username);
            }
        }

        //obter tarefas por programador
        public List<Tarefa> ObterTarefasPorProgramador(int id)
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.Where(t => t.IdProgramador == id).ToList();
            }
        }

        //obter tarefas no estado Todo
        public List<Tarefa> ObterTarefasTodo()
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.ToDo).ToList();
            }
        }

        //obter tarfas no estado Doing
        public List<Tarefa> ObterTarefasDoing()
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Doing).ToList();
            }
        }

        //obter tarefas no estado Done
        public List<Tarefa> ObterTarefasDone()
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Done).ToList();
            }
        }

        //obter true or false se já existe uma tarefa com aquela ordem associada ao programador defenido por parametro
        public bool ExisteTarefaComOrdem(int ordem, int idProgramador)
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefa.Any(t => t.OrdemExecucao == ordem && t.IdProgramador == idProgramador);
            }
        }
    }
}
