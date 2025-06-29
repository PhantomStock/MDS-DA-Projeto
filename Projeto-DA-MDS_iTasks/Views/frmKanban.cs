﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Controllers;
using iTasks.DataBase;
using iTasks.Models;
using iTasks.Views;
using static iTasks.Models.Enums;

namespace iTasks
{
    public partial class frmKanban : Form
    {
        // Propriedade para acessar a instância da base de dados
        BaseDeDados db => BaseDeDados.Instance;

        // Variável para armazenar o utilizador atual
        public Utilizador utilizadorAtual;

        // Instancia do controller de dados
        ControllerDados controllerDados = new ControllerDados();
        public frmKanban()
        {
            InitializeComponent();
            // Carrega o utilizador atual da sessão
            var utilizador = SessaoAtual.Utilizador;

            utilizadorAtual = utilizador;

            //se o utilizador for um programador o strip menu de gerir da aplicacao deixa de ficar visivel
            if (utilizador is Programador)
            {
                utilizadoresToolStripMenuItem.Enabled = false;
                btNova.Enabled = false;
                btnEliminarTarefa.Enabled = false;
                btnPrevisao.Enabled = false;
            } else
            {
                //se o utilizador for um gestor o strip menu de gerir da aplicacao fica visivel e aparece como Detalhes Tarefas em Curso
                tarefasEmCursoToolStripMenuItem.Text = "Detalhes Tarefas em Curso";
            }

            // Verifica se o utilizador não é nulo antes de acessar suas propriedades para colocar o nome no label
            if (utilizador != null)
            {
                labelNomeUtilizador.Text = $"Bem vindo: {utilizadorAtual.Nome}";
            }

            // Carrega as tarefas iniciais
            RefreshDadosListBoxes();
        }

        //ToolStripMenu
        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se o form frmGereUtilizadores tiver aberto ele nao executa o codigo
            //(a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true)
            if (!Application.OpenForms.OfType<frmGereUtilizadores>().Any())  
            {
                if (controllerDados.ObterGestorPorId(utilizadorAtual.Id).GereUtilizadores)
                {
                    new frmGereUtilizadores().Show();
                }
                else
                {
                    MessageBox.Show("Apenas um gestor que tem a opção gere utilizadores pode gerir utilizadores.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmGereUtilizadores>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
        }
        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se o form frmGereTiposTarefas tiver aberto ele nao executa o codigo
            //(a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true)
            if (!Application.OpenForms.OfType<frmGereTiposTarefas>().Any())  
            {
                if (controllerDados.ObterGestorPorId(utilizadorAtual.Id).GereUtilizadores)
                {
                    new frmGereTiposTarefas().Show();
                }
                else
                {
                    MessageBox.Show("Apenas um gestor pode gerir Tipos de Tarefa.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmGereTiposTarefas>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
        }
        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se o form frmConsultarTarefasConcluidas tiver aberto ele nao executa o codigo
            //(a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true)
            if (!Application.OpenForms.OfType<frmConsultarTarefasConcluidas>().Any())  
            {
                new frmConsultarTarefasConcluidas().Show();
            }
            else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmConsultarTarefasConcluidas>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
            
        }
        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se o form frmConsultaTarefasEmCurso tiver aberto ele nao executa o codigo
            //(a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true)
            if (!Application.OpenForms.OfType<frmConsultaTarefasEmCurso>().Any())  
            {
                new frmConsultaTarefasEmCurso().Show();
            }
            else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmConsultaTarefasEmCurso>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
            
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Botão para criar uma nova tarefa
        //================================================================================================
        private void btNova_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<frmDetalhesTarefa>().Any()) //se o form frmGereUtilizadores tiver aberto ele nao executa o codigo (a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true) 
            {
                if (SessaoAtual.Utilizador is Programador)
                {
                    MessageBox.Show("Apenas gestores podem criar novas tarefas.", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else
                {
                    //chama o form para uma nova tarefa
                    new frmDetalhesTarefa(-1, this).Show();
                }
            }
            else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmDetalhesTarefa>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
        }

        //Evento para quando o utilizador dá double click numa tarefa para ver os detalhes
        //================================================================================================
        private void lstTodo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTodo.SelectedIndex > -1)
            {
                DoubleClickLst(lstTodo);
            }
        }

        private void lstDoing_DoubleClick(object sender, EventArgs e)
        {
            if (lstDoing.SelectedIndex > -1)
            {
                DoubleClickLst(lstDoing);
            }
        }

        private void lstDone_DoubleClick(object sender, EventArgs e)
        {
            if (lstDone.SelectedIndex > -1)
            {
                DoubleClickLst(lstDone);
            }
        }

        private void DoubleClickLst(ListBox lb)
        {
            // Verifica se há um item selecionado
            Tarefa tarefa = lb.SelectedItem as Tarefa;
            new frmDetalhesTarefa(tarefa.Id, this).Show();

        }
        // Método para atualizar as ListBoxes com as tarefas
        //================================================================================================
        public void RefreshDadosListBoxes()
        {
            //Carrega as tarefas
            controllerDados = new ControllerDados();
            List<Tarefa> tarefasTodo = controllerDados.ObterTarefasTodo();
            List<Tarefa> tarefasDoing = controllerDados.ObterTarefasDoing();
            List<Tarefa> tarefasDone = controllerDados.ObterTarefasDone();

            //faz refresh as data source das listboxes
            lstTodo.DataSource = null;
            lstTodo.DataSource = tarefasTodo;

            lstDoing.DataSource = null;
            lstDoing.DataSource = tarefasDoing;

            lstDone.DataSource = null;
            lstDone.DataSource = tarefasDone;
        }
        //EXPORTAR TAREFAS PARA CSV
        //================================================================================================
        private void exportarTarefaPorFazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(1); //exporta para csv as tarefas por fazer
        }
        private void exportarTarefaEmExecuçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(2); //exporta para csv as em execução
        }
        private void exportarTarefaConcluidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportarParaCSV(3); //exporta para csv as tarefas concluidas
        }
        private void exportarTodasAsTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarParaCSV(4); //exporta para csv todas as tarefas
        }
        private void exportarParaCSV(int tipo)
        {
            //switch case para fazer defenir qual o tipo de tarefa a exportar para texto para apresentar no filename
            string tipoString = "ToDo";
            switch (tipo)
            {
                case 1:
                    tipoString = "ToDo";
                    break;
                case 2:
                    tipoString = "Doing";
                    break;
                case 3:
                    tipoString = "Done";
                    break;
                case 4:
                    tipoString = "Todas";
                    break;
                default:
                    tipo = -1;
                    break;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ficheiro CSV (*.CSV)|*.CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = "Tarefas" + tipoString + ".CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var controller = new ControllerKanban();
                // Assume ControllerKanban has a method ExportarTarefasParaCSV that returns true/false
                bool sucesso = controller.ExportarTarefasCSV(saveFileDialog.FileName, tipoString);

                if (sucesso)
                {
                    //Sucesso
                    MessageBox.Show("Tarefas exportadas com sucesso!", "Exportação bem sucessida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Erro
                    MessageBox.Show("Falha ao exportar tarefas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshDadosListBoxes();
            }
        }
        //IMPORTAR TAREFAS PARA CSV
        //================================================================================================
        private void importarTodasAsTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarDeSVC(4); //importa todas as tarefas
        }

        private void importarTarefasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            importarDeSVC(1); //importa as tarefas por fazer
        }

        private void importarTarefasEmExecuçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarDeSVC(2); //importa as tarefas em execução
        }

        private void importarTarefasConcluidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarDeSVC(3); //importa as tarefas concluidas
        }

        private void importarDeSVC(int tipo)
        {
            //switch case para fazer defenir qual o tipo de tarefa a exportar para texto para apresentar no filename
            string tipoString = "ToDo";
            switch (tipo)
            {
                case 1:
                    tipoString = "ToDo";
                    break;
                case 2:
                    tipoString = "Doing";
                    break;
                case 3:
                    tipoString = "Done";
                    break;
                case 4:
                    tipoString = "Todas";
                    break;
                default:
                    tipo = -1;
                    break;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ficheiro CSV (*.CSV)|*.CSV";
            openFileDialog.DefaultExt = "csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var controller = new ControllerKanban();
                // Assume ControllerKanban has a method ExportarTarefasParaCSV that returns true/false
                bool sucesso = controller.ImportarTarefasCSV(openFileDialog.FileName, tipoString);

                if (sucesso)
                {
                    //Sucesso
                    MessageBox.Show("Tarefas importadas com sucesso!", "Exportação bem sucessida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Erro
                    MessageBox.Show("Falha ao importar tarefas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshDadosListBoxes();
            }
        }

        //Botão para Refresh das ListBoxes
        //================================================================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDadosListBoxes();
        }


        //Botões para mudar o estado de uma tarefa
        //================================================================================================
        private void btSetDoing_Click(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem is Tarefa tarefa)
            {
                // Validação: só pode passar para Doing se for a de menor ordem
                if (!controllerDados.PodePassarParaDoingOrdem(tarefa))
                {
                    MessageBox.Show("Só pode iniciar a tarefa de menor ordem que ainda está por fazer.", "Ordem obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!controllerDados.PodePassarTarefaDoing(tarefa.IdProgramador))
                {
                    MessageBox.Show("Este programador já tem 2 tarefas em execução (Doing).", "Limite atingido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    tarefa.EstadoAtual = EstadoAtual.Doing;

                    var doingList = (List<Tarefa>)lstDoing.DataSource;

                    doingList.Add(tarefa);

                    tarefa.DataRealInicio = DateTime.Now;

                    db.SaveChanges();

                    RefreshDadosListBoxes();
                }
            }
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            if (lstDone.SelectedItem is Tarefa tarefaDone)
            {
                MessageBox.Show("Não é possível reiniciar uma tarefa já concluída.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstDoing.SelectedItem is Tarefa tarefaDoing)
            {
                tarefaDoing.EstadoAtual = EstadoAtual.ToDo;

                var toDoList = (List<Tarefa>)lstTodo.DataSource;

                toDoList.Add(tarefaDoing);

                tarefaDoing.DataRealInicio = null;

                db.SaveChanges();
                RefreshDadosListBoxes();
            }

        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem is Tarefa tarefa)
            {
                // Validação: só pode passar para Done se for a de menor ordem em Doing
                if (!controllerDados.PodePassarParaDoneOrdem(tarefa))
                {
                    MessageBox.Show("Só pode concluir a tarefa de menor ordem que está em execução.", "Ordem obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tarefa.EstadoAtual = EstadoAtual.Done;

                var doneList = (List<Tarefa>)lstDone.DataSource;

                doneList.Add(tarefa);

                tarefa.DataRealFim = DateTime.Now;

                db.SaveChanges();
                RefreshDadosListBoxes();
            }
            
        }

        //Eventos para limpar a seleção de outras listas quando uma lista é selecionada
        //================================================================================================
        private void lstTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o índice selecionado é válido
            if (lstTodo.SelectedIndex > -1)
            {
                lstDone.ClearSelected(); // Limpa a seleção da lista Done
                lstDoing.ClearSelected(); // Limpa a seleção da lista Doing
            }
        }

        private void lstDoing_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o índice selecionado é válido
            if (lstDoing.SelectedIndex > -1)
            {
                lstDone.ClearSelected(); // Limpa a seleção da lista Done
                lstTodo.ClearSelected(); // Limpa a seleção da lista Todo
            }
        }

        private void lstDone_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o índice selecionado é válido
            if (lstDone.SelectedIndex > -1)
            {
                lstDoing.ClearSelected(); // Limpa a seleção da lista Doing
                lstTodo.ClearSelected(); // Limpa a seleção da lista Todo
            }
        }

        //Botão para eliminar uma tarefa
        //================================================================================================
        private void EliminarTarefa_Click(object sender, EventArgs e)
        {
            // Verifica se o utilizador é um programador
            if (SessaoAtual.Utilizador is Programador)
            {
                MessageBox.Show("Apenas gestores podem eliminar tarefas", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Verifica se alguma tarefa está selecionada em alguma das listas
            Tarefa tarefaSelecionada = null;
            if (lstTodo.SelectedItem is Tarefa t1)
            {
                tarefaSelecionada = t1;
            }
            else if (lstDoing.SelectedItem is Tarefa t2)
            {
                tarefaSelecionada = t2;
            }
            else if (lstDone.SelectedItem is Tarefa t3)
            {
                tarefaSelecionada = t3;
            }
            //verifica se a tarefa selecionada é nula
            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tarefaSelecionada.EstadoAtual != EstadoAtual.ToDo)
            {
                MessageBox.Show("Só é possível eliminar tarefas que estão por fazer (ToDo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.Tarefa.Remove(tarefaSelecionada);
            db.SaveChanges();
            RefreshDadosListBoxes();
            MessageBox.Show("Tarefa eliminada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Botão para Ver Previsão de Conclusão(Somente Gestor)
        //================================================================================================
        private void btnPrevisao_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<frmPrevisaoDeConclusao>().Any()) //se o form frmPrevisaoDeConclusao tiver aberto ele nao executa o codigo (a funao Open Forms procura por um form daquele tipo e se nao encontrar retorna false, se encontrar retorna true) 
            {
                if (controllerDados.ObterGestorPorId(utilizadorAtual.Id).GereUtilizadores)
                {
                    new frmPrevisaoDeConclusao().Show();
                }
                else
                {
                    MessageBox.Show("Apenas um gestor pode ver a previsao de termino.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Traz o formulário já aberto para frente e dá foco
                var frmAberto = Application.OpenForms.OfType<frmPrevisaoDeConclusao>().FirstOrDefault();
                if (frmAberto != null)
                {
                    frmAberto.BringToFront();
                    frmAberto.Activate();
                }
            }
        }
        //Evento para fechar o form Kanban e abrir o form Login
        //================================================================================================
        private void frmKanban_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sair();
        }
        // Método para fechar o formulário atual e abrir o formulário de login
        private void Sair()
        {
            //Fecha todos os forms abertos, exceto o frmLogin que é reaberto
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (!(form is frmLogin))
                {
                    form.Close();
                }
            }
            //Reabre o frmLogin
            new frmLogin().Show();
        }

    }
            
}
