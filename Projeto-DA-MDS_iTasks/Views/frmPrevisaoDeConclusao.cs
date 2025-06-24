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
            lbTempoPrevisto.Text = controllerPrevisaoDeConclusao.ExibirPrevisao();
        }

        private void btnRefreshTempoPrevisto_Click(object sender, EventArgs e)
        {

            ControllerPrevisaoDeConclusao controller = new ControllerPrevisaoDeConclusao();
            lbTempoPrevisto.Text = controller.ExibirPrevisao();
        }
    }
}
