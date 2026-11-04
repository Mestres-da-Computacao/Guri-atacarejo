using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>Descreve uma coluna do relatório (serve para a tela E para a impressão).</summary>
    internal sealed class ColunaRelatorio
    {
        public string Titulo;
        public string Campo;                 // nome da coluna no DataTable
        public float Peso;                   // largura relativa (2 = o dobro de 1)
        public HorizontalAlignment Alinhamento;
        public string Formato;               // ex.: "C2", "dd/MM/yyyy"

        public ColunaRelatorio(string titulo, string campo, float peso = 1f,
            HorizontalAlignment alinhamento = HorizontalAlignment.Left, string formato = null)
        {
            Titulo = titulo;
            Campo = campo;
            Peso = peso;
            Alinhamento = alinhamento;
            Formato = formato;
        }

        public string Formatar(object valor)
        {
            if (valor == null || valor == DBNull.Value) return "-";
            var f = valor as IFormattable;
            if (f != null && !string.IsNullOrEmpty(Formato))
                return f.ToString(Formato, TemaModerno.PtBr);
            return Convert.ToString(valor, TemaModerno.PtBr);
        }
    }

    /// <summary>Um cartão de resumo (ex.: "TOTAL VENDIDO" / "R$ 1.250,00").</summary>
    internal sealed class ItemResumo
    {
        public string Rotulo;
        public string Valor;

        public ItemResumo(string rotulo, string valor)
        {
            Rotulo = rotulo;
            Valor = valor;
        }
    }

    /// <summary>
    /// Documento de impressão no estilo verde do Guri Atacarejo.
    /// Uso: preencher as propriedades e chamar Print() ou passar para a pré-visualização.
    /// Todas as medidas estão em centésimos de polegada (unidade da impressão do .NET).
    /// </summary>
    internal sealed class RelatorioImpressao : PrintDocument
    {
        // ---------- conteúdo ----------
        public string Titulo = "Relatório";
        public string Subtitulo = "";
        public string Emissor = "";
        public DataTable Dados;
        public readonly List<ColunaRelatorio> Colunas = new List<ColunaRelatorio>();
        public readonly List<ItemResumo> Resumo = new List<ItemResumo>();
        public readonly List<string> Filtros = new List<string>();

        // ---------- medidas fixas (por isso dá para saber o total de páginas antes) ----------
        private const int AltFaixa = 78;        // faixa verde com logo e título
        private const int AltFiltros = 40;      // caixa "filtros aplicados"
        private const int AltResumo = 58;       // linha de cartões de resumo
        private const int Espaco = 10;
        private const int AltCompacto = 34;     // cabeçalho das páginas 2, 3, ...
        private const int AltCabTabela = 28;
        private const int AltLinha = 24;
        private const int AltRodape = 30;
        private const int Pad = 6;              // respiro interno das células

        private int linhaAtual;
        private int pagina;
        private int totalPaginas;

        private Font fTitulo, fSub, fCab, fCel, fRot, fVal, fPeq, fMed;
        private StringFormat sfEsq, sfDir, sfCentro;

        public RelatorioImpressao()
        {
            DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            DefaultPageSettings.Landscape = true;
        }

        public bool Paisagem
        {
            get { return DefaultPageSettings.Landscape; }
            set { DefaultPageSettings.Landscape = value; }
        }

        /// <summary>Total de páginas com as configurações de página atuais (para a tela de pré-visualização).</summary>
        public int ContarPaginas()
        {
            Rectangle b = DefaultPageSettings.Bounds;
            Margins m = DefaultPageSettings.Margins;
            return ContarPaginas(b.Height - m.Top - m.Bottom);
        }

        // ------------------------------------------------------------------
        // Ciclo de vida da impressão
        // ------------------------------------------------------------------
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);
            linhaAtual = 0;
            pagina = 0;
            totalPaginas = 0;

            fTitulo = TemaModerno.Fonte(18f, FontStyle.Bold);
            fSub = TemaModerno.Fonte(9.5f);
            fCab = TemaModerno.Fonte(8.5f, FontStyle.Bold);
            fCel = TemaModerno.Fonte(8.5f);
            fRot = TemaModerno.Fonte(7.5f, FontStyle.Bold);
            fVal = TemaModerno.Fonte(14f, FontStyle.Bold);
            fPeq = TemaModerno.Fonte(8f);
            fMed = TemaModerno.Fonte(11f, FontStyle.Bold);

            sfEsq = NovoFormato(StringAlignment.Near);
            sfDir = NovoFormato(StringAlignment.Far);
            sfCentro = NovoFormato(StringAlignment.Center);
        }

        protected override void OnEndPrint(PrintEventArgs e)
        {
            base.OnEndPrint(e);
            foreach (var f in new[] { fTitulo, fSub, fCab, fCel, fRot, fVal, fPeq, fMed })
                if (f != null) f.Dispose();
            foreach (var s in new[] { sfEsq, sfDir, sfCentro })
                if (s != null) s.Dispose();
            fTitulo = fSub = fCab = fCel = fRot = fVal = fPeq = fMed = null;
            sfEsq = sfDir = sfCentro = null;
        }

        private static StringFormat NovoFormato(StringAlignment horizontal)
        {
            return new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = horizontal,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
        }

        // ------------------------------------------------------------------
        // Paginação
        // ------------------------------------------------------------------
        private int AlturaCabecalhoCompleto()
        {
            int h = AltFaixa + Espaco;
            if (Filtros.Count > 0) h += AltFiltros + Espaco;
            if (Resumo.Count > 0) h += AltResumo + Espaco;
            return h;
        }

        private int LinhasPorPagina(int alturaUtil, bool primeira)
        {
            int reservado = (primeira ? AlturaCabecalhoCompleto() : AltCompacto + Espaco)
                            + AltCabTabela + AltRodape;
            return Math.Max(1, (alturaUtil - reservado) / AltLinha);
        }

        private int ContarPaginas(int alturaUtil)
        {
            int n = Dados == null ? 0 : Dados.Rows.Count;
            int primeira = LinhasPorPagina(alturaUtil, true);
            if (n <= primeira) return 1;
            int demais = LinhasPorPagina(alturaUtil, false);
            return 1 + (int)Math.Ceiling((n - primeira) / (double)demais);
        }

        // ------------------------------------------------------------------
        // Desenho da página
        // ------------------------------------------------------------------
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Rectangle area = e.MarginBounds;
            if (pagina == 0) totalPaginas = ContarPaginas(area.Height);
            pagina++;
            bool primeira = pagina == 1;

            int y = area.Top;
            if (primeira) y = CabecalhoCompleto(g, area, y);
            else y = CabecalhoCompacto(g, area, y);

            float[] larguras = CalcularLarguras(area.Width);
            CabecalhoTabela(g, area.Left, y, larguras);
            y += AltCabTabela;

            int total = Dados == null ? 0 : Dados.Rows.Count;
            int capacidade = LinhasPorPagina(area.Height, primeira);

            if (total == 0)
            {
                var vazio = new Rectangle(area.Left, y, area.Width, AltLinha * 2);
                using (var b = new SolidBrush(TemaModerno.TextoSuave))
                    g.DrawString("Nenhum registro encontrado para os filtros informados.",
                        fCel, b, vazio, sfCentro);
            }

            int desenhadas = 0;
            while (linhaAtual < total && desenhadas < capacidade)
            {
                Linha(g, area.Left, y, larguras, Dados.Rows[linhaAtual], desenhadas % 2 == 1);
                y += AltLinha;
                linhaAtual++;
                desenhadas++;
            }

            Rodape(g, area);
            e.HasMorePages = linhaAtual < total;
        }

        // ---------- cabeçalho da primeira página ----------
        private int CabecalhoCompleto(Graphics g, Rectangle area, int y)
        {
            // faixa verde escura com a logo
            var faixa = new Rectangle(area.Left, y, area.Width, AltFaixa);
            using (var p = Caminho(faixa, 10))
            using (var b = new SolidBrush(TemaModerno.Floresta))
                g.FillPath(b, p);

            int xTexto = faixa.Left + 18;
            Image logo = Guri_atacarejo.Properties.Resources.FullLogo_verde;
            if (logo != null)
            {
                int altLogo = AltFaixa - 14;
                int largLogo = (int)(altLogo * (logo.Width / (float)logo.Height));
                g.DrawImage(logo, new Rectangle(faixa.Left + 12, faixa.Top + 7, largLogo, altLogo));
                xTexto = faixa.Left + 12 + largLogo + 16;
            }

            using (var bTit = new SolidBrush(TemaModerno.Menta2))
            using (var bSub = new SolidBrush(TemaModerno.Oliva1))
            {
                g.DrawString(Titulo, fTitulo, bTit, new Rectangle(xTexto, faixa.Top + 12, faixa.Width / 2, 32), sfEsq);
                g.DrawString(Subtitulo, fSub, bSub, new Rectangle(xTexto, faixa.Top + 44, faixa.Width / 2, 22), sfEsq);

                var dir = new Rectangle(faixa.Right - 260, faixa.Top + 14, 244, 24);
                g.DrawString("Emitido em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fSub, bSub, dir, sfDir);
                if (!string.IsNullOrEmpty(Emissor))
                    g.DrawString("por " + Emissor, fSub, bSub,
                        new Rectangle(dir.Left, dir.Top + 24, dir.Width, 24), sfDir);
            }

            // filete lima embaixo da faixa
            using (var b = new SolidBrush(TemaModerno.Lima1))
                g.FillRectangle(b, faixa.Left + 14, faixa.Bottom - 3, faixa.Width - 28, 3);

            y = faixa.Bottom + Espaco;

            if (Filtros.Count > 0)
            {
                var caixa = new Rectangle(area.Left, y, area.Width, AltFiltros);
                using (var p = Caminho(caixa, 8))
                using (var fundo = new SolidBrush(TemaModerno.Menta1))
                using (var pen = new Pen(TemaModerno.Borda, 1f))
                {
                    g.FillPath(fundo, p);
                    g.DrawPath(pen, p);
                }
                using (var rot = new SolidBrush(TemaModerno.Verde4))
                using (var txt = new SolidBrush(TemaModerno.Texto))
                {
                    g.DrawString("FILTROS APLICADOS", fRot, rot,
                        new Rectangle(caixa.Left + 12, caixa.Top + 4, caixa.Width - 24, 14), sfEsq);
                    var wrap = new StringFormat { Trimming = StringTrimming.EllipsisWord };
                    g.DrawString(string.Join("   \u2022   ", Filtros), fCel, txt,
                        new RectangleF(caixa.Left + 12, caixa.Top + 19, caixa.Width - 24, caixa.Height - 21), wrap);
                    wrap.Dispose();
                }
                y = caixa.Bottom + Espaco;
            }

            if (Resumo.Count > 0)
            {
                int gap = 10;
                int largCard = (area.Width - gap * (Resumo.Count - 1)) / Resumo.Count;
                for (int i = 0; i < Resumo.Count; i++)
                {
                    var card = new Rectangle(area.Left + i * (largCard + gap), y, largCard, AltResumo);
                    bool escuro = i == 0;   // o primeiro cartão é o destaque (como o SUBTOTAL do caixa)
                    using (var p = Caminho(card, 8))
                    using (var fundo = new SolidBrush(escuro ? TemaModerno.Floresta : Color.White))
                    {
                        g.FillPath(fundo, p);
                        if (!escuro)
                            using (var pen = new Pen(TemaModerno.Borda, 1.5f))
                                g.DrawPath(pen, p);
                    }
                    using (var rot = new SolidBrush(escuro ? TemaModerno.Oliva1 : TemaModerno.Verde4))
                    using (var val = new SolidBrush(escuro ? TemaModerno.Menta2 : TemaModerno.Texto))
                    {
                        g.DrawString(Resumo[i].Rotulo.ToUpper(TemaModerno.PtBr), fRot, rot,
                            new Rectangle(card.Left + 12, card.Top + 7, card.Width - 24, 14), sfEsq);
                        g.DrawString(Resumo[i].Valor, fVal, val,
                            new Rectangle(card.Left + 12, card.Top + 23, card.Width - 24, 28), sfEsq);
                    }
                }
                y += AltResumo + Espaco;
            }

            return y;
        }

        // ---------- cabeçalho das demais páginas ----------
        private int CabecalhoCompacto(Graphics g, Rectangle area, int y)
        {
            using (var b = new SolidBrush(TemaModerno.Verde2))
                g.DrawString(Titulo, fMed, b,
                    new Rectangle(area.Left, y, area.Width / 2, AltCompacto - 8), sfEsq);
            using (var b = new SolidBrush(TemaModerno.TextoSuave))
                g.DrawString("Guri Atacarejo  \u2022  continuação", fPeq, b,
                    new Rectangle(area.Left + area.Width / 2, y, area.Width / 2, AltCompacto - 8), sfDir);
            using (var b = new SolidBrush(TemaModerno.Lima1))
                g.FillRectangle(b, area.Left, y + AltCompacto - 6, area.Width, 3);
            return y + AltCompacto + Espaco;
        }

        // ---------- tabela ----------
        private float[] CalcularLarguras(int larguraTotal)
        {
            float soma = 0;
            foreach (var c in Colunas) soma += c.Peso;
            if (soma <= 0) soma = 1;
            var r = new float[Colunas.Count];
            for (int i = 0; i < r.Length; i++) r[i] = larguraTotal * Colunas[i].Peso / soma;
            return r;
        }

        private StringFormat FormatoDe(HorizontalAlignment a)
        {
            if (a == HorizontalAlignment.Right) return sfDir;
            if (a == HorizontalAlignment.Center) return sfCentro;
            return sfEsq;
        }

        private void CabecalhoTabela(Graphics g, int x, int y, float[] larguras)
        {
            float total = 0;
            foreach (float l in larguras) total += l;

            var faixa = new RectangleF(x, y, total, AltCabTabela);
            using (var b = new SolidBrush(TemaModerno.Cabecalho))
                g.FillRectangle(b, faixa);
            using (var pen = new Pen(TemaModerno.Borda, 1.5f))
                g.DrawLine(pen, x, y + AltCabTabela, x + total, y + AltCabTabela);

            float cx = x;
            using (var b = new SolidBrush(TemaModerno.Verde2))
                for (int i = 0; i < Colunas.Count; i++)
                {
                    var r = new RectangleF(cx + Pad, y, larguras[i] - 2 * Pad, AltCabTabela);
                    g.DrawString(Colunas[i].Titulo, fCab, b, r, FormatoDe(Colunas[i].Alinhamento));
                    cx += larguras[i];
                }
        }

        private void Linha(Graphics g, int x, int y, float[] larguras, DataRow linha, bool alternada)
        {
            float total = 0;
            foreach (float l in larguras) total += l;

            if (alternada)
                using (var b = new SolidBrush(TemaModerno.CardAlt))
                    g.FillRectangle(b, x, y, total, AltLinha);
            using (var pen = new Pen(TemaModerno.Linha, 1f))
                g.DrawLine(pen, x, y + AltLinha, x + total, y + AltLinha);

            float cx = x;
            using (var b = new SolidBrush(TemaModerno.Texto))
                for (int i = 0; i < Colunas.Count; i++)
                {
                    object valor = Dados.Columns.Contains(Colunas[i].Campo) ? linha[Colunas[i].Campo] : null;
                    var r = new RectangleF(cx + Pad, y, larguras[i] - 2 * Pad, AltLinha);
                    g.DrawString(Colunas[i].Formatar(valor), fCel, b, r, FormatoDe(Colunas[i].Alinhamento));
                    cx += larguras[i];
                }
        }

        // ---------- rodapé ----------
        private void Rodape(Graphics g, Rectangle area)
        {
            int topo = area.Bottom - AltRodape + 8;
            using (var pen = new Pen(TemaModerno.Borda, 1f))
                g.DrawLine(pen, area.Left, topo, area.Right, topo);
            using (var b = new SolidBrush(TemaModerno.TextoSuave))
            {
                g.DrawString("Guri Atacarejo  \u2022  " + Titulo, fPeq, b,
                    new Rectangle(area.Left, topo + 2, area.Width / 2, 18), sfEsq);
                g.DrawString("P\u00E1gina " + pagina + " de " + totalPaginas, fPeq, b,
                    new Rectangle(area.Left + area.Width / 2, topo + 2, area.Width / 2, 18), sfDir);
            }
        }

        // ---------- utilitário ----------
        private static GraphicsPath Caminho(Rectangle r, int raio)
        {
            int d = raio * 2;
            var p = new GraphicsPath();
            p.AddArc(r.Left, r.Top, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Top, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
