using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controllers
{
    class ControllerPrevisaoDeConclusao
    {
        ControllerDados controllerDados = new ControllerDados();
        public string ExibirPrevisao()
        {
            string texto;

            double tempoPrevisto = CalcularTempoPrevistoTodasTarefasTodo();
            int totalMinutos = (int)Math.Round(tempoPrevisto * 60);
            int horas = totalMinutos / 60;
            int minutos = totalMinutos % 60;
            return $"Tempo previsto para concluir todas as tarefas ToDo: {horas}h {minutos}min";
        }

        public double CalcularTempoPrevistoTodasTarefasTodo()
        {
            // Obter todas as tarefas Done e Todo para calcular a média de tempo gasto por Story Points
            var tarefasDone = controllerDados.ObterTarefasDone();

            // Obter todas as tarefas Todo para calcular o tempo previsto
            var tarefasTodo = controllerDados.ObterTarefasTodo();

            // Agrupar as tarefas Done por Story Points e calcular a média de tempo gasto por Story Points
            var mediasPorStoryPoints = tarefasDone
                .Where(t => t.StoryPoints > 0 && t.DataRealInicio.HasValue && t.DataRealFim.HasValue)
                .GroupBy(t => t.StoryPoints)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(t => (t.DataRealFim.Value - t.DataRealInicio.Value).TotalHours)
                );

            // Calcular a média de tempo gasto por Story Points
            double tempoTotalPrevisto = 0;

            // Para cada tarefa Todo, calcular o tempo previsto com base na média de tempo gasto por Story Points
            foreach (var tarefa in tarefasTodo)
            {
                double tempoPrevisto = 0;
                if (tarefa.StoryPoints > 0)
                {
                    //Verifica se se o calculo da media de tempo gasto por story poins foi feito
                    if (mediasPorStoryPoints.ContainsKey(tarefa.StoryPoints))
                    {
                        // Se a média de tempo gasto por Story Points foi calculada, usa essa média
                        tempoPrevisto = mediasPorStoryPoints[tarefa.StoryPoints];
                    }
                    // Se não foi calculada, tenta encontrar a média mais proxima
                    else if (mediasPorStoryPoints.Count > 0)
                    {
                        // Encontra a mediaa de tempo gasto por Story Points mais prioxima
                        var spMaisProximo = mediasPorStoryPoints.Keys
                            .OrderBy(sp => Math.Abs(sp - tarefa.StoryPoints))
                            .First();
                        tempoPrevisto = mediasPorStoryPoints[spMaisProximo];
                    }
                }
                // Adiciona o tempo previsto para a tarefa atual ao total
                tempoTotalPrevisto += tempoPrevisto;
            }

            return tempoTotalPrevisto;
        }












    }
}
