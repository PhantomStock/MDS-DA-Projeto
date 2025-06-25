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
            //retorna uma lista de gestores filtrando os utilizadores que são do tipo Gestor
            return db.Utilizador.OfType<Gestor>().ToList();
        }

        //obtem uma list com todos os programadores
        public List<Programador> ObterTodosProgramadores()
        {
            //retorna uma lista de programadores filtrando os utilizadores que são do tipo Programador
            return db.Utilizador.OfType<Programador>().ToList();
        }

        //Função pode ser usada 
        //======================================================================
        //obtem uma list com todos os utilizadores
        public List<Utilizador> ObterTodosUtilizadores()
        {
            return db.Utilizador.ToList();
        }
        //======================================================================

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

        //Função pode ser usada
        //==============================================================================
        //Obtem um utilizador pelo id
        public Utilizador ObterUtilizadorPorId(int id)
        {
            //retorna o primeiro utilizador que tem o id especificado
            return db.Utilizador.FirstOrDefault(u => u.Id == id);
        }
        //==============================================================================

        //obtem um programdor pelo id
        public Programador ObterProgramadorPorId(int id)
        {
            //retorna o primeiro programador que tem o id especificado
            return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Id == id);
        }

        //obtem um gestor pelo id
        public Gestor ObterGestorPorId(int id)
        {
            //retorna o primeiro gestor que tem o id especificado
            return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Id == id);
        }

        //obtem uma tarefa pelo id
        public Tarefa ObterTarefaPorId(int id)
        {
            //retorna a primeira tarefa que tem o id especificado
            return db.Tarefa.FirstOrDefault(t => t.Id == id);
        }

        //obtem um tipo de tarefa pelo id
        public TipoTarefa ObterTipoTarefaPorId(int id)
        {
            //retorna o primeiro tipo de tarefa que tem o id especificado
            return db.TipoTarefa.FirstOrDefault(t => t.Id == id);
        }

        //Funções que obtêm utilizadores, programadores e gestores por username
        ///===================================================================================================
        //obter gestor por username
        public Gestor ObterGestorPorUsername(string Username)
        {
            //retorna o primeiro gestor que tem o username especificado
            return db.Utilizador.OfType<Gestor>().FirstOrDefault(u => u.Username == Username);
        }

        //obter programador por username
        public Programador ObterProgramadorPorUsername(string Username)
        {
            //retorna o primeiro programador que tem o username especificado
            return db.Utilizador.OfType<Programador>().FirstOrDefault(u => u.Username == Username);
        }

        //obter utilizador por username
        public Utilizador ObterUtilizadorPorUsername(string Username)
        {
            //retorna o primeiro utilizador que tem o username especificado
            return db.Utilizador.FirstOrDefault(u => u.Username == Username);
        }
        ///===================================================================================================
        
        //obter tarefas por programador
        public List<Tarefa> ObterTarefasPorProgramador(int id)
        {
            //retorna todas as tarefas associadas ao programador com o id especificado
            return db.Tarefa.Where(t => t.IdProgramador == id).ToList();
        }

        //obter tarefas no estado Todo
        public List<Tarefa> ObterTarefasTodo()
        {
            //retorna todas as tarefas que estão no estado ToDo
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.ToDo).ToList();
        }

        //obter tarfas no estado Doing
        public List<Tarefa> ObterTarefasDoing()
        {
            //retorna todas as tarefas que estão no estado Doing
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Doing).ToList();
        }

        //obter tarefas no estado Done
        public List<Tarefa> ObterTarefasDone()
        {
            //retorna todas as tarefas que estão no estado Done
            return db.Tarefa.Where(t => t.EstadoAtual == Enums.EstadoAtual.Done).ToList();
        }

        //obter programadores do utilizador atual se for gestor 
        public List<Programador> ObterProgramadoresDoGestorAtual()
        {
            //verifica se o utilizador atual é um gestor
            int idGestor = SessaoAtual.Utilizador.Id;

            // se não for gestor, retorna uma lista vazia
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
            {
                return 1;
            }
            
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

        // Função para adicionar um gestor
        public void EliminarGestor(int idGestor)
        {
            // Verifica se o gestor existe e o elimina
            var gestor = db.Gestor.Find(idGestor);
            // Se o gestor não existir, não faz nada
            if (gestor != null)
            {
                db.Gestor.Remove(gestor);
                db.SaveChanges();
            }
        }

        // Função para eliminar um programador
        public void EliminarProgramador(int idProgramador)
        {
            // Verifica se o programador existe e o elimina
            var programador = db.Programador.Find(idProgramador);
            // Se o programador não existir, não faz nada
            if (programador != null)
            {
                db.Programador.Remove(programador);
                db.SaveChanges();
            }
        }

        // Função para atualizar os dados de um gestor
        public void AtualizarDadosGestor(Gestor gestor)
        {
            // Verifica se o gestor existe e atualiza os dados
            var g = db.Gestor.Find(gestor.Id);
            // Se o gestor não existir, não faz nada
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

        // Função para atualizar os dados de um programador
        public void AtualizarDadosProgramador(Programador programador)
        {
            // Verifica se o programador existe e atualiza os dados
            var p = db.Programador.Find(programador.Id);
            // Se o programador não existir, não faz nada
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

        // Função para verificar se o utilizador é um Gestor ou Programador usado nas grelhas
        public int GestorOuProgramador(int id)
        {
            // Verifica se o utilizador existe
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
