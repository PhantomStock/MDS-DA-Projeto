using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Controllers;
using iTasks.DataBase;

namespace iTasks
{
    public partial class frmKanban : Form
    {
        public frmKanban(int utilizadorId)
        {
            InitializeComponent();

            var controller = new ControllerKanban();
            var utilizador = controller.ObterUtilizadorId(utilizadorId);

            if (utilizador != null)
            {
                labelNomeUtilizador.Text = $"Bem vindo: {utilizador.Nome}";
            }
        }
    }
                
}
