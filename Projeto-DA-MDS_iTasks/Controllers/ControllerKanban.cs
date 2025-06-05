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

namespace iTasks.Controllers
{
    class ControllerKanban
    {
        ControllerDados controllerDados = new ControllerDados();
        ControllerTarefa controllerTarefa = new ControllerTarefa();
        //Exportar Tarefas em formato CSV para poder converter para exel
        public bool ExportarTarefasCSV(string filePath, string tipo)
        {
            try
            {
                List<Tarefa> tarefas = controllerDados.ObterTodasTarefas();
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    //Escreve o cabeçalho do CSV
                    writer.WriteLine("sep =;");
                    //Escreve o cabeçalho do ficheiro CSV
                    writer.WriteLine("ID;idGestor;IdProgramador;IdTipoTarefa;Descricao;OrdemExecução;DataPrevistaInicio;DataPrevistaFim;DataRealInicio;DataRealFim;DataCriação;EstadoAtual;StoryPoints");
                    //Vai checar se as tarefas estão concluidas e vai escrever os dados da tarefa(pode-se incrementar mais coisas)
                    if (tipo == "Todas")
                    {
                        foreach (var tarefa in tarefas)
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
                    } else
                    {
                        if (Enum.TryParse(tipo, out EstadoAtual tipoEnum)) // Tenta converter a string tipo para o enum EstadoAtual para poder expportar corretamente
                        {
                            foreach (var tarefa in tarefas)
                            {
                                if (tarefa.EstadoAtual == tipoEnum)
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
                        else
                        {
                            MessageBox.Show($"Tipo inválido: {tipo}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
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
        //Importar Tarefas de um ficheiro CSV para a base de dados
        public bool ImportarTarefasCSV(string filePath, string tipo)
        {
            try
            {
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    // Ignora o cabeçalho do CSV
                    reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(';');
                        if (values.Length < 13) continue; // Verifica se a linha tem o número correto de colunas
                        if (tipo == "Todos")
                        {
                            Tarefa tarefa = new Tarefa
                            {
                                Id = int.Parse(values[0]),
                                IdGestor = int.Parse(values[1]),
                                IdProgramador = int.Parse(values[2]),
                                IdTipoTarefa = int.Parse(values[3]),
                                Descricao = values[4],
                                OrdemExecucao = int.Parse(values[5]),
                                DataPrevistaInicio = DateTime.TryParse(values[6], out DateTime dataPrevistaInicio) ? dataPrevistaInicio : (DateTime?)null,
                                DataPrevistaFim = DateTime.TryParse(values[7], out DateTime dataPrevistaFim) ? dataPrevistaFim : (DateTime?)null,
                                DataRealInicio = DateTime.TryParse(values[8], out DateTime dataRealInicio) ? dataRealInicio : (DateTime?)null,
                                DataRealFim = DateTime.TryParse(values[9], out DateTime dataRealFim) ? dataRealFim : (DateTime?)null,
                                DataCriacao = DateTime.TryParse(values[10], out DateTime dataCriacao) ? dataCriacao : DateTime.Now,
                                EstadoAtual = Enum.TryParse<EstadoAtual>(values[11], out EstadoAtual estadoAtual) ? estadoAtual : EstadoAtual.ToDo,
                                StoryPoints = int.Parse(values[12])
                            };
                            // Adiciona a tarefa ao banco de dados ou atualiza se já existir
                            if (controllerDados.ObterTarefaPorId(tarefa.Id) == null)
                            {
                                controllerTarefa.CriarTarefa(tarefa);
                            }
                            else
                            {
                                controllerTarefa.updateTarefa(tarefa);
                            }
                        } else
                        {
                            //guarda so do tipo de  estado atual que foi definido
                            //verifica se o estado atual da tarefa é igual ao tipo definido para importar 
                            if (values[11] == tipo)
                            {
                                Tarefa tarefa = new Tarefa
                                {
                                    Id = int.Parse(values[0]),
                                    IdGestor = int.Parse(values[1]),
                                    IdProgramador = int.Parse(values[2]),
                                    IdTipoTarefa = int.Parse(values[3]),
                                    Descricao = values[4],
                                    OrdemExecucao = int.Parse(values[5]),
                                    DataPrevistaInicio = DateTime.TryParse(values[6], out DateTime dataPrevistaInicio) ? dataPrevistaInicio : (DateTime?)null,
                                    DataPrevistaFim = DateTime.TryParse(values[7], out DateTime dataPrevistaFim) ? dataPrevistaFim : (DateTime?)null,
                                    DataRealInicio = DateTime.TryParse(values[8], out DateTime dataRealInicio) ? dataRealInicio : (DateTime?)null,
                                    DataRealFim = DateTime.TryParse(values[9], out DateTime dataRealFim) ? dataRealFim : (DateTime?)null,
                                    DataCriacao = DateTime.TryParse(values[10], out DateTime dataCriacao) ? dataCriacao : DateTime.Now,
                                    EstadoAtual = Enum.TryParse<EstadoAtual>(values[11], out EstadoAtual estadoAtual) ? estadoAtual : EstadoAtual.ToDo,
                                    StoryPoints = int.Parse(values[12])
                                };
                                if (controllerDados.ObterTarefaPorId(tarefa.Id) == null)
                                {
                                    controllerTarefa.CriarTarefa(tarefa);
                                }
                                else
                                {
                                    controllerTarefa.updateTarefa(tarefa);
                                }
                            } 
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
