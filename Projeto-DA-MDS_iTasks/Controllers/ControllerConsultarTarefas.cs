using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.Models;
using iTasks.Controllers;
using iTasks.DataBase;
using iTasks.Models;

namespace iTasks.Controllers
{

    class ControllerConsultarTarefas
    {
        BaseDeDados db => BaseDeDados.Instance;
        ControllerDados controllerDados = new ControllerDados();

        public List<object> ConsultarTarefasEmCurso(Utilizador utilizadorAtual, int tipo)
        {
            if (tipo == 1)
            {
                // Gestor
                return db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Doing && t.IdGestor == utilizadorAtual.Id)
                    .ToList()
                    .Select(t => new
                    {
                        Id = t.Id,
                        EstadoAtual = t.EstadoAtual.ToString(),
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio.HasValue ? (object)t.DataPrevistaInicio : "Null",
                        DataPrevistaFim = t.DataPrevistaFim.HasValue ? (object)t.DataPrevistaFim : "Null",
                        DataRealInicio = t.DataRealInicio.HasValue ? (object)t.DataRealInicio : "Null",
                        DataRealFim = t.DataRealFim.HasValue ? (object)t.DataRealInicio : "Null",
                        DuraçãoReal = (t.DataRealFim.HasValue && t.DataRealInicio.HasValue) ? (t.DataRealFim.Value - t.DataRealInicio.Value).Days : 0,
                        DuraçãoEstimada = (t.DataPrevistaFim.HasValue && t.DataPrevistaInicio.HasValue) ? (t.DataPrevistaFim.Value - t.DataPrevistaInicio.Value).Days : 0,
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",
                    })
                    .Cast<object>()
                    .ToList();
            }
            else if (tipo == 2)
            {
                // Programador
                return db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Doing && t.IdProgramador == utilizadorAtual.Id)
                    .ToList()
                    .Select(t => new
                    {
                        Id = t.Id,
                        EstadoAtual = t.EstadoAtual.ToString(),
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio.HasValue ? (object)t.DataPrevistaInicio : "Null",
                        DataPrevistaFim = t.DataPrevistaFim.HasValue ? (object)t.DataPrevistaFim : "Null",
                        DataRealInicio = t.DataRealInicio.HasValue ? (object)t.DataRealInicio : "Null",
                        DataRealFim = t.DataRealFim.HasValue ? (object)t.DataRealInicio : "Null",
                        DuraçãoReal = (t.DataRealFim.HasValue && t.DataRealInicio.HasValue) ? (t.DataRealFim.Value - t.DataRealInicio.Value).Days : 0,
                        DuraçãoEstimada = (t.DataPrevistaFim.HasValue && t.DataPrevistaInicio.HasValue) ? (t.DataPrevistaFim.Value - t.DataPrevistaInicio.Value).Days : 0,
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() : "0",
                    })
                    .Cast<object>()
                    .ToList();
            }
            else
            {
                return new List<object>();
            }
        }

        public List<object> ConsultarTarefasConcluidas(Utilizador utilizadorAtual, int tipo)
        {
            if (tipo == 1)
            {
                // Gestor
                return db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdGestor == utilizadorAtual.Id)
                    .ToList()
                    .Select(t => new
                    {
                        Id = t.Id,
                        EstadoAtual = t.EstadoAtual.ToString(),
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio.HasValue ? (object)t.DataPrevistaInicio : "Null",
                        DataPrevistaFim = t.DataPrevistaFim.HasValue ? (object)t.DataPrevistaFim : "Null",
                        DataRealInicio = t.DataRealInicio.HasValue ? (object)t.DataRealInicio : "Null",
                        DataRealFim = t.DataRealFim.HasValue ? (object)t.DataRealInicio : "Null",
                        DuraçãoReal = t.DataRealFim.Value.Day - t.DataRealInicio.Value.Day + " dias",
                        DuraçãoEstimada = t.DataPrevistaFim.Value.Day - t.DataPrevistaInicio.Value.Day + " dias",
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() + " points" : "0",
                    })
                    .Cast<object>()
                    .ToList();
            }
            else if (tipo == 2)
            {
                // Programador
                return db.Tarefa
                    .Where(t => t.EstadoAtual == iTasks.Models.Enums.EstadoAtual.Done && t.IdProgramador == utilizadorAtual.Id)
                    .ToList()
                    .Select(t => new
                    {
                        Id = t.Id,
                        EstadoAtual = t.EstadoAtual.ToString(),
                        TipoTarefa = controllerDados.ObterTipoTarefaPorId(t.IdTipoTarefa)?.Nome ?? "Gestor Null",
                        NomeDoGestor = controllerDados.ObterGestorPorId(t.IdGestor)?.Nome ?? "Gestor Null",
                        NomeDoProgramdor = controllerDados.ObterProgramadorPorId(t.IdProgramador)?.Nome ?? "Programador Null",
                        Descricao = t.Descricao,
                        OrdemExecucao = t.OrdemExecucao,
                        DataPrevistaInicio = t.DataPrevistaInicio.HasValue ? (object)t.DataPrevistaInicio : "Null",
                        DataPrevistaFim = t.DataPrevistaFim.HasValue ? (object)t.DataPrevistaFim : "Null",
                        DataRealInicio = t.DataRealInicio.HasValue ? (object)t.DataRealInicio : "Null",
                        DataRealFim = t.DataRealFim.HasValue ? (object)t.DataRealInicio : "Null",
                        DuraçãoReal = t.DataRealFim.Value.Day - t.DataRealInicio.Value.Day + " dias",
                        DuraçãoEstimada = t.DataPrevistaFim.Value.Day - t.DataPrevistaInicio.Value.Day + " dias",
                        StoryPointsInicio = t.StoryPoints != 0 ? t.StoryPoints.ToString() + " points" : "0",
                    })
                    .Cast<object>()
                    .ToList();
            }
            else
            {
                return new List<object>();
            }
        }



    }
}
