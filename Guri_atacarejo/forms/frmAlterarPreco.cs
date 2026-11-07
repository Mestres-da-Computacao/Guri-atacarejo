using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    
    public partial class frmAlterarPreco : Icone
    {
        public frmPainel painel;

        int linhaProduto = 0;

        public frmAlterarPreco(frmPainel Form, int linha)
        {
            painel = Form;
            linhaProduto = linha;
            InitializeComponent();
            txtQtd.KeyPress += txtQtd_KeyPress;
            txtQtd.Text = painel.qtdProd.ToString();
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQtd.Text, out int quantidade) || quantidade < 0)
            {
                MessageBox.Show("Digite uma quantidade válida. Use zero para remover o produto.");
                return;
            }

            try
            {
                if (!painel.TentarAlterarQuantidade(
                    linhaProduto, quantidade, out string erro))
                {
                    MessageBox.Show(erro);
                    return;
                }

                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível consultar o estoque: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            painel.removerProd(linhaProduto);
            Close();
        }
    }
}
