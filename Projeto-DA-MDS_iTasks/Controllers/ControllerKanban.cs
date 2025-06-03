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
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
                    writer.WriteLine("ID;idGestor;IdProgramador;IdTipoTarefa;Descricao;OrdemExecução;DataPrevistaInicio;DataPrevistaFim;DataRealInicio;DataRealFim;DataCriação;EstadoAtual;StoryPoints");
                    //Vai checar se as tarefas estão concluidas e vai escrever os dados da tarefa(pode-se incrementar mais coisas)
                    foreach (var tarefa in tarefas)
                    {
                        if (tarefa.EstadoAtual == Enums.EstadoAtual.ToDo)
                        {
                            string linha = string.Join(";",
                                tarefa.Id.ToString() ?? "N/A",
                                tarefa.IdGestor.ToString() ?? "N/A",
                                tarefa.IdProgramador.ToString() ?? "N/A",
                                tarefa.IdTipoTarefa.ToString() ?? "N/A",
                                tarefa.Descricao ?? "N/A",
                                tarefa.OrdemExecucao.ToString() ?? "N/A",
                                tarefa.DataPrevistaInicio.ToString() ?? "N/A",
                                tarefa.DataPrevistaFim.ToString() ?? "N/A",
                                tarefa.DataRealInicio.ToString() ?? "N/A",
                                tarefa.DataRealFim.ToString() ?? "N/A",
                                tarefa.DataCriacao.ToString() ?? "N/A",
                                tarefa.EstadoAtual.ToString() ?? "N/A",
                                tarefa.StoryPoints.ToString() ?? "N/A"
                            );
                            writer.WriteLine(linha);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Erro ao exportar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
