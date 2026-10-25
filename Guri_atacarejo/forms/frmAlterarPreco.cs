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
    
    public partial class frmAlterarPreco : Form
    {
        public frmPainel painel;
        int linhaProduto = 0;
        public frmAlterarPreco(frmPainel Form, int linha)
        {
            painel = Form;
            linhaProduto = linha;
            InitializeComponent();
            txtQtd.Text = painel.qtdProd.ToString();
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            painel.AttQuantidade(linhaProduto, int.Parse(txtQtd.Text));
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            painel.removerProd(linhaProduto);
            this.Hide();
        }
    }
}
