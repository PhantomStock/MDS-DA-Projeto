using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.DataBase;
using System.IO;
using System.Collections.ObjectModel;
using iTasks.Models;
using static iTasks.Models.Enums;

namespace iTasks.Controllers
{
    class ControllerKanban
    {
        //Buscar utilizadores por id
        public Utilizador ObterUtilizadorId(int utilizadorId)
        {
            using (var db = new BaseDeDados())
            {
                return db.Utilizadores.FirstOrDefault(u => u.Id == utilizadorId);
            }
            
        }
        //Exportar Tarefas
        public bool ExportarTarefasCSV(string filePath)
        {
            try
            {
                List<Tarefa> tarefas = ObterTodasTarefas();
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    //Vai checar se as tarefas estão concluidas e vai escrever os dados da tarefa(pode-se incrementar mais coisas)
                    foreach (var tarefa in tarefas)
                    {
                        if (tarefa.EstadoAtual == Enums.EstadoAtual.ToDo)
                        {
                            writer.WriteLine(tarefa.ToStringCustom(1));
                        }
                    }
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        // Query base de dados que retorna todas as tarefas função usado no Exportar
        public List<Tarefa> ObterTodasTarefas()
        {
            using (var db = new BaseDeDados())
            {
                return db.Tarefas.ToList();
            }
        }
    }
}
