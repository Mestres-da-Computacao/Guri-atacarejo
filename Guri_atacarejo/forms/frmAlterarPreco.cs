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
        // ---- Barra de título colorida (Windows 11) ----
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(System.Drawing.Color fundo, System.Drawing.Color texto)
        {
            // O DWM espera o formato COLORREF: 0x00BBGGRR
            int corFundo = fundo.R | (fundo.G << 8) | (fundo.B << 16);
            int corTexto = texto.R | (texto.G << 8) | (texto.B << 16);

            DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref corFundo, sizeof(int));
            DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref corTexto, sizeof(int));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Barra do form com a mesma cor do fundo; texto branco (ou preto se o fundo for claro)
            System.Drawing.Color fundo = BackColor;
            bool escuro = fundo.GetBrightness() < 0.6f;
            DefinirCorBarra(fundo, escuro ? System.Drawing.Color.White : System.Drawing.Color.Black);
        }

        public frmPainel painel;

        int linhaProduto = 0;

        public frmAlterarPreco(frmPainel Form, int linha)
        {
            painel = Form;
            linhaProduto = linha;
            InitializeComponent();
            txtQtd.KeyPress += txtQtd_KeyPress;
            txtQtd.Text = painel.qtdProd.ToString();

            this.Text = "Altera preço";
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
