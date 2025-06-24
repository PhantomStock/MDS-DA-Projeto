using iTasks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controllers
{
    class ControllerTipoTarefa
    {
        BaseDeDados db => BaseDeDados.Instance;

        private ControllerDados controllerDados = new ControllerDados();
        //adiciona um tipo tarefa novo atravez do id e da descricao do mesmo
        public void AdicionarTipoTarefa(int id, string desc)
        {
            TipoTarefa tipoTarefa = new TipoTarefa { Id = id, Nome = desc };

            db.TipoTarefa.Add(tipoTarefa);
            db.SaveChanges();
            MessageBox.Show("Tipo de tarefa adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //precisamos criar esta query para ir buscar o proximo id, O EF nao vai garantir o proximo id na base de dados
        public int ObterProximoIdTipoTarefa()
        {
            if (!db.TipoTarefa.Any())
                return 1;

            var result = db.Database.SqlQuery<decimal>(
                "SELECT IDENT_CURRENT('TipoTarefas') + IDENT_INCR('TipoTarefas')"
            ).FirstOrDefault();

            // a rasao pela qual separamos é para dar a volta a um pequeno problema da utilização de linq com SQL, o que acontece é:
            //      1. o LINQ as vezes persiste certos valores mesmo a base de dados ter sido resetada o que leva a que se previamente existia um utilizador ele ia confiar nesse dado 
            //  e nao refazer a contagem para verificar assim fazendo com o primeiro input aparecece incorreto (mas dps era feito corretamente, lembramdo que o ID apresentado é 
            //  meramente demonstrativo e nao impacta a inserção de dados por isso era apenas um erro visual)

            return Convert.ToInt32(result);
        }

        public void EliminarTipoTarefa(int idTipoTarefa)
        {
            var tipoTarefa = db.TipoTarefa.Find(idTipoTarefa);
            if (tipoTarefa != null)
            {
                db.TipoTarefa.Remove(tipoTarefa);
                db.SaveChanges();
            }
        }
    }
}
