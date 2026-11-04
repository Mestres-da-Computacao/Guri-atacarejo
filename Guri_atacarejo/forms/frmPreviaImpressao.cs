using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Pré-visualização de impressão no tema verde. Montada só por código
    /// (não tem Designer): new frmPreviaImpressao(documento).ShowDialog(this).
    /// </summary>
    [DesignerCategory("Code")]
    internal sealed class frmPreviaImpressao : Form
    {
        private readonly RelatorioImpressao documento;
        private readonly PrintPreviewControl previa;
        private readonly Label lblPagina;
        private readonly Label lblZoom;
        private readonly Button btnAnterior, btnProxima;

        public frmPreviaImpressao(RelatorioImpressao doc)
        {
            documento = doc;

            SuspendLayout();
            Text = "Pré-visualização  \u2022  " + doc.Titulo;
            BackColor = TemaModerno.Fundo;
            Font = TemaModerno.Fonte(9.5f);
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(860, 560);
            KeyPreview = true;

            // ---------- barra de ferramentas (cartão no topo) ----------
            var barra = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = TemaModerno.Fundo };
            var cartao = new Panel { Location = new Point(24, 12), Height = 52, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            cartao.Width = ClientSize.Width - 48;
            cartao.Padding = new Padding(2);   // deixa o contorno do cartão aparecer
            TemaModerno.Cartao(cartao);
            barra.Controls.Add(cartao);

            var fluxo = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = TemaModerno.Card,
                Padding = new Padding(10, 6, 10, 0),
                WrapContents = false
            };
            cartao.Controls.Add(fluxo);

            Button btnImprimir = NovoBotao("Imprimir", 120, true);
            Button btnConfig = NovoBotao("Configurar página", 160, false);
            btnAnterior = NovoBotao("\u25C0", 44, false);
            btnProxima = NovoBotao("\u25B6", 44, false);
            lblPagina = NovoRotulo(130);
            Button btnMenos = NovoBotao("\u2212", 44, false);
            Button btnMais = NovoBotao("+", 44, false);
            lblZoom = NovoRotulo(70);
            Button btnAjustar = NovoBotao("Ajustar à tela", 130, false);
            Button btnFechar = NovoBotao("Fechar", 100, false);

            fluxo.Controls.Add(btnImprimir);
            fluxo.Controls.Add(btnConfig);
            fluxo.Controls.Add(Espacador());
            fluxo.Controls.Add(btnAnterior);
            fluxo.Controls.Add(lblPagina);
            fluxo.Controls.Add(btnProxima);
            fluxo.Controls.Add(Espacador());
            fluxo.Controls.Add(btnMenos);
            fluxo.Controls.Add(lblZoom);
            fluxo.Controls.Add(btnMais);
            fluxo.Controls.Add(btnAjustar);
            fluxo.Controls.Add(btnFechar);

            // ---------- a "mesa" onde a folha aparece ----------
            previa = new PrintPreviewControl
            {
                Dock = DockStyle.Fill,
                Document = doc,
                AutoZoom = true,
                UseAntiAlias = true,
                BackColor = TemaModerno.Misturar(TemaModerno.Borda, TemaModerno.Fundo, 0.55)
            };

            Controls.Add(previa);   // Fill primeiro...
            Controls.Add(barra);    // ...Top depois (docka antes)

            // ---------- eventos ----------
            btnImprimir.Click += (s, e) => Imprimir();
            btnConfig.Click += (s, e) => ConfigurarPagina();
            btnAnterior.Click += (s, e) => IrPara(previa.StartPage - 1);
            btnProxima.Click += (s, e) => IrPara(previa.StartPage + 1);
            btnMenos.Click += (s, e) => AplicarZoom(previa.Zoom - 0.15);
            btnMais.Click += (s, e) => AplicarZoom(previa.Zoom + 0.15);
            btnAjustar.Click += (s, e) => { previa.AutoZoom = true; AtualizarInfo(); };
            btnFechar.Click += (s, e) => Close();
            previa.StartPageChanged += (s, e) => AtualizarInfo();

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
                else if (e.Control && e.KeyCode == Keys.P) Imprimir();
                else if (e.KeyCode == Keys.PageDown) IrPara(previa.StartPage + 1);
                else if (e.KeyCode == Keys.PageUp) IrPara(previa.StartPage - 1);
            };

            ResumeLayout(true);
            AtualizarInfo();
        }

        // ------------------------------------------------------------------
        private void Imprimir()
        {
            using (var dlg = new PrintDialog { Document = documento, UseEXDialog = true })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    documento.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível imprimir: " + ex.Message, "Impressão",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ConfigurarPagina()
        {
            using (var dlg = new PageSetupDialog { Document = documento })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                previa.InvalidatePreview();
                IrPara(0);
            }
        }

        private void IrPara(int pagina)
        {
            int total = documento.ContarPaginas();
            previa.StartPage = Math.Max(0, Math.Min(pagina, total - 1));
            AtualizarInfo();
        }

        private void AplicarZoom(double zoom)
        {
            previa.AutoZoom = false;
            previa.Zoom = Math.Max(0.25, Math.Min(zoom, 3.0));
            AtualizarInfo();
        }

        private void AtualizarInfo()
        {
            int total = documento.ContarPaginas();
            int atual = Math.Min(previa.StartPage, total - 1) + 1;
            lblPagina.Text = "Página " + atual + " de " + total;
            lblZoom.Text = previa.AutoZoom ? "Ajustado" : Math.Round(previa.Zoom * 100) + "%";
            btnAnterior.Enabled = atual > 1;
            btnProxima.Enabled = atual < total;
        }

        // ------------------------------------------------------------------
        private static Button NovoBotao(string texto, int largura, bool principal)
        {
            var b = new Button { Text = texto, Size = new Size(largura, 40), Margin = new Padding(0, 0, 8, 0) };
            if (principal)
                TemaModerno.Botao(b, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            else
                TemaModerno.Botao(b, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            return b;
        }

        private static Label NovoRotulo(int largura)
        {
            return new Label
            {
                AutoSize = false,
                Size = new Size(largura, 40),
                Margin = new Padding(0, 0, 8, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = TemaModerno.Texto,
                BackColor = TemaModerno.Card,
                Font = TemaModerno.Fonte(10f, FontStyle.Bold)
            };
        }

        private static Panel Espacador()
        {
            return new Panel { Size = new Size(14, 40), Margin = new Padding(0), BackColor = TemaModerno.Card };
        }
    }
}
