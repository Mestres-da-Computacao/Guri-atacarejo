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
