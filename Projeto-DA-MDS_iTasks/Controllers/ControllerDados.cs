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

        //obter programadores do utilizador atual se for gestor 
        public List<Programador> ObterProgramadoresDoGestorAtual()
        {
            int idGestor = SessaoAtual.Utilizador.Id;
            return ObterTodosProgramadores()
                .Where(p => p.IdGestor == idGestor)
                .ToList();
        }

        //funcao para verificar se o programador pode ter mais uma tarefa no estado doing
        public bool PodePassarTarefaDoing(int idProgramador)
        {
            // conta quantas tarefas estão no estado Doing para o programador
            int doing = db.Tarefa.Count(t => t.IdProgramador == idProgramador && t.EstadoAtual == Enums.EstadoAtual.Doing);
            return doing < 2; 
        }

        // Verifica se pode passar para Doing
        public bool PodePassarParaDoingOrdem(Tarefa tarefa)
        {
            // todas as tarefas "ToDo" do programador
            var tarefasToDo = db.Tarefa
                .Where(t => t.IdProgramador == tarefa.IdProgramador && t.EstadoAtual == Enums.EstadoAtual.ToDo)
                .ToList();

            //verifica se não há tarefas ToDo
            if (tarefasToDo.Count == 0)
                return true; 

            // menor ordem das tarefas ToDo
            int menorOrdem = tarefasToDo.Min(t => t.OrdemExecucao);

            // Só pode passar para Doing se a ordem de execucao for igual à menor ordem
            return tarefa.OrdemExecucao == menorOrdem;
        }

        // Verifica se pode passar para Done
        public bool PodePassarParaDoneOrdem(Tarefa tarefa)
        {
            //todas as tarefas "Doing" do programador
            var tarefasDoing = db.Tarefa
                .Where(t => t.IdProgramador == tarefa.IdProgramador && t.EstadoAtual == Enums.EstadoAtual.Doing)
                .ToList();

            if (tarefasDoing.Count == 0)
                return true; // Não há outras tarefas Doing

            // menor ordem das tarefas Doing
            int menorOrdem = tarefasDoing.Min(t => t.OrdemExecucao);

            // Só pode passar para Doing se a ordem de execucao for igual à menor ordem
            return tarefa.OrdemExecucao == menorOrdem;
        }

        //obter true or false se já existe uma tarefa com aquela ordem associada ao programador defenido por parametro
        public bool ExisteTarefaComOrdem(int ordem, int idProgramador)
        {
            return db.Tarefa.Any(t => t.OrdemExecucao == ordem && t.IdProgramador == idProgramador);
        }


        //precisamos criar esta query para ir buscar o proximo id, O EF nao vai garantir o proximo id na base de dados
        public int ObterProximoIdUtilizador()
        {
            //verifica se tem user se nao houver retorna 1
            if (!db.Utilizador.Any())
                return 1;

            // devolve o proximo id disponivel
            var result = db.Database.SqlQuery<decimal>(
                "SELECT IDENT_CURRENT('Utilizadors') + IDENT_INCR('Utilizadors')"
            ).FirstOrDefault();

            // a rasao pela qual separamos é para dar a volta a um pequeno problema da utilização de linq com SQL, o que acontece é:
            //      1. o LINQ as vezes persiste certos valores mesmo a base de dados ter sido resetada o que leva a que se previamente existia um utilizador ele ia confiar nesse dado 
            //  e nao refazer a contagem para verificar assim fazendo com o primeiro input aparecece incorreto (mas dps era feito corretamente, lembramdo que o ID apresentado é 
            //  meramente demonstrativo e nao impacta a inserção de dados por isso era apenas um erro visual)

            return Convert.ToInt32(result);
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

        public void atualizarDadosGestor(Gestor gestor)
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

        public void AtualizarDadosProgramador(Programador programador)
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
