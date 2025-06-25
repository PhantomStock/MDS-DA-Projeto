using iTasks.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Views
{
    public partial class frmPrevisaoDeConclusao : Form
    {
        ControllerPrevisaoDeConclusao controllerPrevisaoDeConclusao = new ControllerPrevisaoDeConclusao();
        public frmPrevisaoDeConclusao()
        {
            InitializeComponent();
            // Inicializa os campos de horas e minutos com a previsão de conclusão
            string tempoPrevistoCompleto = controllerPrevisaoDeConclusao.ExibirPrevisao();

            // Divide o tempo previsto em horas e minutos
            string[] partes = tempoPrevistoCompleto.Split(';');
            //Horas
            txbHoras.Text = partes[0];
            //Minutos
            txbMinutos.Text = partes[1];
        }

        private void btnRefreshTempoPrevisto_Click(object sender, EventArgs e)
        {
            // Atualiza os campos de horas e minutos com a previsão de conclusão atualizada
            ControllerPrevisaoDeConclusao controller = new ControllerPrevisaoDeConclusao();

            // Obtém a previsão de conclusão atualizada
            string tempoPrevistoCompleto = controllerPrevisaoDeConclusao.ExibirPrevisao();

            // Divide o tempo previsto em horas e minutos
            string[] partes = tempoPrevistoCompleto.Split(';');

            //Horas
            txbHoras.Text = partes[0];
            //Minutos
            txbMinutos.Text = partes[1];
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
