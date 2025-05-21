using iTasks.DataBase;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controllers
{
    class ControllerDetalhesTarefa
    {
        ControllerDados controllerDados = new ControllerDados();

        //public void NovaTarefa()
        //{
        //    using (var db = new BaseDeDados())
        //    {
        //        var tarefas = controllerDados.ObterTodasTarefas();
        //        int TarefaIdAnterior = 0;

        //        foreach (Tarefa tipoTarefa in tarefas)
        //        {
        //            if (tipoTarefa.Id > TarefaIdAnterior)
        //            {
        //                TarefaIdAnterior = tipoTarefa.Id;
        //            }
        //        }
        //        txtId.Text = (TarefaIdAnterior + 1).ToString();
        //        txtEstado.Text = Enums.EstadoAtual.ToDo.ToString();
        //        txtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");

        //    }
        //}




    }
}
