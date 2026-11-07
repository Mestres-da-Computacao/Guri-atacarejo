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
    public partial class frmRelatorioEstoqueQtd : Icone
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

        public frmRelatorioEstoqueQtd()
        {
            InitializeComponent();
            AplicarTema();

            btnFechar.Click += (s, e) => Close();

            PadraoTela.AdicionarBarraLateral(this);   // barra lateral fixa
        }

        private void AplicarTema()
        {
            // fundo claro, igual ao do painel
            BackColor = TemaModerno.Fundo;
            tlpRaiz.BackColor = TemaModerno.Fundo;

            // ---- cabecalho: sem cartao, so titulo + subtitulo + botoes ----
            pnlCabecalho.Padding = Padding.Empty;
            pnlCabecalho.BackColor = TemaModerno.Fundo;

            flwBotoes.BackColor = TemaModerno.Fundo;
            flwBotoes.Dock = DockStyle.Right;
            foreach (Button b in new[] { btnImprimir, btnPrevia, btnFechar })
                b.Margin = new Padding(8, 22, 0, 0);

            Rotulo(lblTitulo, 22f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Fundo);
            Rotulo(lblSubtitulo, 10.5f, FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo);
            lblTitulo.Location = new Point(0, 6);
            lblSubtitulo.Location = new Point(2, 52);

            // ---- botoes do cabecalho ----
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnPrevia, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFechar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);

            // ---- cartao de filtro ----
            TemaModerno.Cartao(pnlFiltros);
            Rotulo(lblFiltros, 9.5f, FontStyle.Bold, TemaModerno.Verde4, TemaModerno.Card);
            Rotulo(lblProduto, 9f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);

            TemaModerno.Botao(btnAplicar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnLimpar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            PadraoTela.CentralizarTexto(btnImprimir, btnPrevia, btnFechar, btnAplicar, btnLimpar);

            // ---- cartao do relatorio ----
            TemaModerno.Cartao(pnlRelatorio);
            Rotulo(lblAreaRelatorio, 11f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);
        }

        private static void Rotulo(Label l, float tam, FontStyle est, Color cor, Color fundo)
        {
            l.Font = TemaModerno.Fonte(tam, est);
            l.ForeColor = cor;
            l.BackColor = fundo;
        }

        private void tlpRaiz_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRelatorio_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}