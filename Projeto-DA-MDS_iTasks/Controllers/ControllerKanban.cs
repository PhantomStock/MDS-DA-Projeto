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
        ControllerDados controllerDados = new ControllerDados();
        //Exportar Tarefas em formato CSV para poder converter para exel
        public bool ExportarTarefasCSV(string filePath)
        {
            try
            {
                List<Tarefa> tarefas = controllerDados.ObterTodasTarefas();
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
    }
}
