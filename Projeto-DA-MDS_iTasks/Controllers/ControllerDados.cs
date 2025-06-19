using iTasks.DataBase;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public List<Programador> ObterTodosProgramadores()
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
            return db.TipoTarefa.ToList();
        }

        //Obtem um utilizador pelo id
        public Utilizador ObterUtilizadorPorId(int id)
        {
            return db.Utilizador.FirstOrDefault(u => u.Id == id);
        }

        //obtem um programdor pelo id
        public Programador ObterProgramadorPorId(int id)
        {
            return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Id == id);
        }

        //obtem um gestor pelo id
        public Gestor ObterGestorPorId(int id)
        {
            return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Id == id);
        }

        //obtem uma tarefa pelo id
        public Tarefa ObterTarefaPorId(int id)
        {
            return db.Tarefa.FirstOrDefault(t => t.Id == id);
        }

        //obtem um tipo de tarefa pelo id
        public TipoTarefa ObterTipoTarefaPorId(int id)
        {

            return db.TipoTarefa.FirstOrDefault(t => t.Id == id);
        }

        //obter gestor por username
        public Gestor ObterGestorPorUsername(string Username)
        {
            return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Username == Username);
        }

        //obter programador por username
        public Programador ObterProgramadorPorUsername(string Username)
        {
            return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Username == Username);
        }

        //obter utilizador por username
        public Utilizador ObterUtilizadorPorUsername(string Username)
        {
            return db.Utilizador.FirstOrDefault(u => u.Username == Username);
        }

        //obter tarefas por programador
        public List<Tarefa> ObterTarefasPorProgramador(int id)
        {
            return db.Tarefa.Where(t => t.IdProgramador == id).ToList();
        }

        //obter tarefas no estado Todo
        public List<Tarefa> ObterTarefasTodo()
        {
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.ToDo).ToList();
        }

        //obter tarfas no estado Doing
        public List<Tarefa> ObterTarefasDoing()
        {
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Doing).ToList();
        }

        //obter tarefas no estado Done
        public List<Tarefa> ObterTarefasDone()
        {
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Done).ToList();
        }

        //obter true or false se já existe uma tarefa com aquela ordem associada ao programador defenido por parametro
        public bool ExisteTarefaComOrdem(int ordem, int idProgramador)
        {
            return db.Tarefa.Any(t => t.OrdemExecucao == ordem && t.IdProgramador == idProgramador);
        }

        public void AtualizarListBox<T>(ListBox listBox, List<T> dataSource)
        {
            listBox.DataSource = null;
            listBox.DataSource = dataSource;

        }

        public void AtualizarIdUtilizadores(TextBox textBox)
        {
            var utilizadores = ObterTodosUtilizadores();
            int proximoId = (utilizadores.Count == 0) ? 1 : utilizadores.Max(u => u.Id) + 1;
            textBox.Text = proximoId.ToString();
        }

        public void AtualizarIdTipoTarefa(TextBox textBox)
        {
            var tipoTarefa = ObterTodosTiposTarefas();
            int proximoId = (tipoTarefa.Count == 0) ? 1 : tipoTarefa.Max(u => u.Id) + 1;
            textBox.Text = proximoId.ToString();
        }

        public void AtualizarIdTarefa(TextBox textBox)
        {
            var Tarefa = ObterTodasTarefas();
            int proximoId = (Tarefa.Count == 0) ? 1 : Tarefa.Max(u => u.Id) + 1;
            textBox.Text = proximoId.ToString();
        }

        public void AtualizarGestorComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = null;
            comboBox.DataSource = ObterTodosGestores();
        }

        public void EliminarGestor(int idGestor)
        {
            var gestor = db.Gestor.Find(idGestor);
            if (gestor != null)
            {
                db.Gestor.Remove(gestor);
                db.SaveChanges();
            }
        }

        public void EliminarProgramador(int idProgramador)
        {
            var programador = db.Programador.Find(idProgramador);
            if (programador != null)
            {
                db.Programador.Remove(programador);
                db.SaveChanges();
            }
        }

        public void AtualizarGestor(Gestor gestor)
        {
            var g = db.Gestor.Find(gestor.Id);
            if (g != null)
            {
                g.Nome = gestor.Nome;
                g.Username = gestor.Username;
                g.Password = gestor.Password;
                g.Departamento = gestor.Departamento;
                g.GereUtilizadores = gestor.GereUtilizadores;
                db.SaveChanges();
            }
        }

        public void AtualizarProgramador(Programador programador)
        {
            var p = db.Programador.Find(programador.Id);
            if (p != null)
            {
                p.Nome = programador.Nome;
                p.Username = programador.Username;
                p.Password = programador.Password;
                p.NivelExperiencia = programador.NivelExperiencia;
                p.IdGestor = programador.IdGestor;
                db.SaveChanges();
            }
        }

        public int GestorOuProgramador(int id)
        {
            var utilizador = db.Utilizador.Find(id);

            if (utilizador is Gestor)
            {
                return 1; // Gestor
            }
            else if (utilizador is Programador)
            {
                return 2; // Programador
            }
            else
            {
                return 0; // Utilizador não encontrado ou outro tipo


            }

        }

    }
}
