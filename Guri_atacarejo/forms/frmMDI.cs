using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // desloga e volta p tela de login
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            frmPainel FormPainel = new frmPainel();
            FormPainel.ShowDialog();
        }
    }
}
