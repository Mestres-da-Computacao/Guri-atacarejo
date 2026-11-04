using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Tema claro (branco esverdeado) com barra lateral verde escura. Reutilizável:
    /// TemaModerno.Grid(dgv), TemaModerno.Botao(...), TemaModerno.Cartao(panel),
    /// TemaModerno.Combo(comboBox). A navegação é feita pela BarraLateral.
    /// </summary>
    internal static class TemaModerno
    {
        // ---------- Paleta base ----------
        public static readonly Color Verde1 = ColorTranslator.FromHtml("#0b9d18"); // verde vivo
        public static readonly Color Verde2 = ColorTranslator.FromHtml("#025f28"); // verde escuro
        public static readonly Color Lima1 = ColorTranslator.FromHtml("#98c022"); // lima
        public static readonly Color Verde3 = ColorTranslator.FromHtml("#48972c");
        public static readonly Color Menta1 = ColorTranslator.FromHtml("#f1fbf0"); // quase branco
        public static readonly Color Menta2 = ColorTranslator.FromHtml("#e3ffe2");
        public static readonly Color Verde4 = ColorTranslator.FromHtml("#388d3c");
        public static readonly Color Floresta = ColorTranslator.FromHtml("#13532e");
        public static readonly Color Oliva1 = ColorTranslator.FromHtml("#d2e297");
        public static readonly Color Oliva2 = ColorTranslator.FromHtml("#a3be55");

        // ---------- Paleta do tema claro ----------
        public static readonly Color Fundo = ColorTranslator.FromHtml("#eaf2ea"); // fundo da tela (branco esverdeado)
        public static readonly Color Card = Color.White;                         // cartões
        public static readonly Color CardAlt = ColorTranslator.FromHtml("#f4f9f4"); // linhas alternadas
        public static readonly Color Cabecalho = ColorTranslator.FromHtml("#dcebdc"); // cabeçalho das tabelas
        public static readonly Color Campo = ColorTranslator.FromHtml("#e6f0e6"); // campos / chips
        public static readonly Color Linha = ColorTranslator.FromHtml("#dbe7db"); // linhas da tabela
        public static readonly Color Borda = ColorTranslator.FromHtml("#b9d0ba"); // contorno dos cartões
        public static readonly Color Texto = ColorTranslator.FromHtml("#14301d");
        public static readonly Color TextoSuave = ColorTranslator.FromHtml("#5b7262");
        public static readonly Color Accent = Misturar(Verde1, Verde2, 0.80);      // botões principais
        public static readonly Color AccentClaro = Verde2;                              // títulos / valores destacados
        public static readonly Color Perigo = Color.FromArgb(200, 45, 58);
        public static readonly Color Sucesso = Verde4;
        public static readonly Color Selecao = ColorTranslator.FromHtml("#cfe8cf");

        // ---------- Barra lateral ----------
        public static readonly Color BarraFundo = Floresta;
        public static readonly Color BarraHover = Misturar(Verde4, Floresta, 0.40);
        public static readonly Color BarraAtiva = Misturar(Verde1, Floresta, 0.30);
        public static readonly Color BarraSub = Misturar(Floresta, Color.Black, 0.72);

        // mantido por compatibilidade com Menu()
        public static readonly Color MenuFundo = Floresta;

        public static readonly CultureInfo PtBr = CultureInfo.GetCultureInfo("pt-BR");

        // ---------- Utilitários ----------
        public static Font Fonte(float tamanho, FontStyle estilo = FontStyle.Regular)
        {
            return new Font("Segoe UI", tamanho, estilo, GraphicsUnit.Point);
        }

        public static Color Misturar(Color a, Color b, double quantidadeDeA)
        {
            return Color.FromArgb(
                (int)(a.R * quantidadeDeA + b.R * (1 - quantidadeDeA)),
                (int)(a.G * quantidadeDeA + b.G * (1 - quantidadeDeA)),
                (int)(a.B * quantidadeDeA + b.B * (1 - quantidadeDeA)));
        }

        private static GraphicsPath CaminhoArredondado(int largura, int altura, int raio)
        {
            int d = Math.Max(2, raio * 2);
            var p = new GraphicsPath();
            p.AddArc(0, 0, d, d, 180, 90);
            p.AddArc(largura - d, 0, d, d, 270, 90);
            p.AddArc(largura - d, altura - d, d, d, 0, 90);
            p.AddArc(0, altura - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        /// <summary>Deixa os cantos do controle arredondados (e mantém assim ao redimensionar).</summary>
        public static void Arredondar(Control c, int raio)
        {
            Action ajustar = () =>
            {
                if (c.Width <= 0 || c.Height <= 0) return;
                Region antiga = c.Region;
                using (GraphicsPath p = CaminhoArredondado(c.Width, c.Height, raio))
                    c.Region = new Region(p);
                if (antiga != null) antiga.Dispose();
            };
            c.SizeChanged += (s, e) => ajustar();
            ajustar();
        }

        /// <summary>Cartão branco arredondado, com contorno para demarcar do fundo.</summary>
        public static void Cartao(Panel p, int raio = 12, bool borda = true)
        {
            p.BackColor = Card;
            Arredondar(p, raio);
            if (!borda) return;

            p.Paint += (s, e) =>
            {
                if (p.Width < 4 || p.Height < 4) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = CaminhoArredondado(p.Width - 1, p.Height - 1, raio))
                using (var pen = new Pen(Borda, 2f))
                    e.Graphics.DrawPath(pen, path);
            };
            p.Invalidate();
        }

        public static Label Titulo(string texto, float tamanho, Color cor, Color fundo)
        {
            return new Label
            {
                AutoSize = true,
                Text = texto,
                Font = Fonte(tamanho, FontStyle.Bold),
                ForeColor = cor,
                BackColor = fundo
            };
        }

        // ---------- Botões ----------
        public static void Botao(Button b, Color fundo, Color texto, Color hover)
        {
            b.UseVisualStyleBackColor = false;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = hover;
            b.FlatAppearance.MouseDownBackColor = Misturar(hover, Color.Black, 0.85);
            b.BackColor = fundo;
            b.ForeColor = texto;
            b.Font = Fonte(9.5f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            Arredondar(b, 10);
        }

        // ---------- ComboBox ----------
        public static void Combo(ComboBox c)
        {
            c.FlatStyle = FlatStyle.Flat;
            c.BackColor = Campo;
            c.ForeColor = Texto;
            c.Font = Fonte(10f);
            c.DrawMode = DrawMode.OwnerDrawFixed;
            c.ItemHeight = 22;
            c.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                bool sel = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                           && (e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit;
                using (var fundo = new SolidBrush(sel ? Selecao : Campo))
                    e.Graphics.FillRectangle(fundo, e.Bounds);
                TextRenderer.DrawText(e.Graphics, c.Items[e.Index].ToString(), c.Font,
                    new Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height),
                    Texto, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            };
        }

        // ---------- Tabela ----------
        /// <param name="direita">índices das colunas alinhadas à direita</param>
        /// <param name="moeda">índices das colunas formatadas como R$ (só afeta a exibição)</param>
        public static void Grid(DataGridView g, int[] direita = null, int[] moeda = null)
        {
            typeof(DataGridView).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic).SetValue(g, true, null);

            g.EnableHeadersVisualStyles = false;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Card;
            g.GridColor = Linha;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.AllowUserToResizeColumns = false;

            // altura do cabeçalho acompanha a fonte (evita a letra cortada)
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            g.RowTemplate.Height = 38;
            g.RowTemplate.MinimumHeight = 38;

            var cab = g.ColumnHeadersDefaultCellStyle;
            cab.BackColor = Cabecalho;
            cab.ForeColor = Verde2;
            cab.SelectionBackColor = Cabecalho;
            cab.SelectionForeColor = Verde2;
            cab.Font = null;   // herda de g.Font, para escalar junto com a janela
            cab.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cab.Padding = new Padding(10, 8, 8, 8);
            cab.WrapMode = DataGridViewTriState.False;

            var cel = g.DefaultCellStyle;
            cel.BackColor = Card;
            cel.ForeColor = Texto;
            cel.SelectionBackColor = Selecao;
            cel.SelectionForeColor = Texto;
            cel.Font = null;   // herda de g.Font
            g.Font = Fonte(9.5f);
            cel.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cel.Padding = new Padding(10, 0, 8, 0);
            cel.WrapMode = DataGridViewTriState.False;

            var alt = g.AlternatingRowsDefaultCellStyle;
            alt.BackColor = CardAlt;
            alt.ForeColor = Texto;
            alt.SelectionBackColor = Selecao;
            alt.SelectionForeColor = Texto;

            if (direita != null)
                foreach (int i in direita)
                {
                    g.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    g.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

            if (moeda != null)
                foreach (int i in moeda)
                {
                    g.Columns[i].DefaultCellStyle.Format = "C2";
                    g.Columns[i].DefaultCellStyle.FormatProvider = PtBr;
                }
        }

        // ---------- Menu (legado; a navegação agora é a BarraLateral) ----------
        public static void Menu(MenuStrip m)
        {
            m.Renderer = new ToolStripProfessionalRenderer(new CoresMenu()) { RoundedEdges = false };
            m.BackColor = MenuFundo;
            m.ForeColor = Color.White;
            m.Font = Fonte(9.5f);
            foreach (ToolStripItem item in m.Items)
                EstilizarItemMenu(item);
        }

        private static void EstilizarItemMenu(ToolStripItem item)
        {
            item.ForeColor = Color.White;
            var mi = item as ToolStripMenuItem;
            if (mi == null) return;
            mi.DropDown.BackColor = MenuFundo;
            foreach (ToolStripItem sub in mi.DropDownItems)
                EstilizarItemMenu(sub);
        }

        private sealed class CoresMenu : ProfessionalColorTable
        {
            public override Color MenuItemSelected { get { return BarraHover; } }
            public override Color MenuItemSelectedGradientBegin { get { return MenuItemSelected; } }
            public override Color MenuItemSelectedGradientEnd { get { return MenuItemSelected; } }
            public override Color MenuItemPressedGradientBegin { get { return BarraAtiva; } }
            public override Color MenuItemPressedGradientMiddle { get { return BarraAtiva; } }
            public override Color MenuItemPressedGradientEnd { get { return BarraAtiva; } }
            public override Color MenuItemBorder { get { return Verde4; } }
            public override Color MenuBorder { get { return Verde4; } }
            public override Color ToolStripDropDownBackground { get { return MenuFundo; } }
            public override Color ImageMarginGradientBegin { get { return MenuFundo; } }
            public override Color ImageMarginGradientMiddle { get { return MenuFundo; } }
            public override Color ImageMarginGradientEnd { get { return MenuFundo; } }
            public override Color MenuStripGradientBegin { get { return MenuFundo; } }
            public override Color MenuStripGradientEnd { get { return MenuFundo; } }
            public override Color SeparatorDark { get { return Verde4; } }
            public override Color SeparatorLight { get { return Verde4; } }
        }

        // ---------- GroupBox -> Panel ----------
        public static Panel GroupBoxParaPainel(GroupBox gb, Color fundo)
        {
            Control pai = gb.Parent;
            Point desloc = gb.DisplayRectangle.Location;

            var painel = new Panel
            {
                Name = gb.Name + "Painel",
                Bounds = gb.Bounds,
                BackColor = fundo,
                TabIndex = gb.TabIndex
            };
            if (gb.Dock != DockStyle.None) painel.Dock = gb.Dock; else painel.Anchor = gb.Anchor;

            painel.SuspendLayout();
            foreach (Control c in gb.Controls.Cast<Control>().ToList())
            {
                Point p = c.Location;
                gb.Controls.Remove(c);
                c.Location = new Point(p.X + desloc.X, p.Y + desloc.Y);
                painel.Controls.Add(c);
            }

            int indice = pai.Controls.GetChildIndex(gb);
            pai.Controls.Add(painel);
            pai.Controls.SetChildIndex(painel, indice);
            pai.Controls.Remove(gb);
            gb.Dispose();
            painel.ResumeLayout(false);
            return painel;
        }
    }
}