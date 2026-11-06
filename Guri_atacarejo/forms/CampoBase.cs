using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Base visual dos campos "underline" (CampoMascara, CampoNumero, CampoData, CampoCombo):
    /// só a barrinha embaixo; ao focar vira uma caixa branca de bordas arredondadas.
    /// Mesmo visual do CampoTexto.
    /// </summary>
    [DesignerCategory("Code")]
    public abstract class CampoBase : Control
    {
        // ---------- Layout (proporcional à altura, igual ao CampoTexto) ----------
        protected int PadH => Math.Max(4, (int)Math.Round(Height * 0.30));
        protected int Raio => Math.Max(3, Height / 4);
        protected int IconeLado => Math.Max(10, (int)Math.Round(Height * 0.42));

        // ---------- Controles internos ----------
        protected TextBoxBase txt;                       // null no CampoCombo
        private readonly Label lblPlaceholder = new Label();

        // ---------- Estado ----------
        protected bool focado;
        private bool hoverIcone;
        private string placeholder = "";
        private ToolStripDropDown dropAtual;
        private ToolStripControlHost dropHost;
        private DateTime fechouEm = DateTime.MinValue;

        // ---------- Cores ----------
        protected Color lineColor = Color.White;
        protected Color corTextoFoco = Color.FromArgb(5, 87, 40);
        protected Color corTextoNormal = Color.White;
        protected Color corPlaceholder = Color.FromArgb(215, 240, 215);
        private Color corIcone = Color.Empty;                          // Empty = usa LineColor
        private Color corIconeFoco = Color.FromArgb(5, 87, 40);

        protected CampoBase()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Size = new Size(250, 40);
        }

        // =====================================================
        //  PROPRIEDADES PÚBLICAS
        // =====================================================

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => txt != null ? txt.Text : base.Text;
            set { if (txt != null) txt.Text = value; else base.Text = value; }
        }

        [Category("Guri"), DefaultValue(""), Description("Texto de preview quando o campo está vazio.")]
        public string PlaceholderText
        {
            get => placeholder;
            set { placeholder = value ?? ""; AtualizarPlaceholder(); }
        }

        [Category("Guri"), Description("Cor da barrinha embaixo e da borda ao focar.")]
        public Color LineColor
        {
            get => lineColor;
            set { lineColor = value; Invalidate(); }
        }

        [Category("Guri"), Description("Cor do texto enquanto o campo está focado (caixa branca).")]
        public Color CorTextoFoco
        {
            get => corTextoFoco;
            set { corTextoFoco = value; AtualizarCores(); Invalidate(); }
        }

        [Category("Guri"), Description("Cor do texto quando o campo NÃO está focado.")]
        public Color CorTextoNormal
        {
            get => corTextoNormal;
            set { corTextoNormal = value; AtualizarCores(); Invalidate(); }
        }

        [Category("Guri"), Description("Cor do texto de preview (placeholder).")]
        public Color CorPlaceholder
        {
            get => corPlaceholder;
            set { corPlaceholder = value; AtualizarCores(); Invalidate(); }
        }

        [Category("Guri"), Description("Cor do ícone (seta/calendário) quando NÃO está focado. Vazio = usa LineColor.")]
        public Color CorIcone
        {
            get => corIcone;
            set { corIcone = value; Invalidate(); }
        }

        [Category("Guri"), Description("Cor do ícone (seta/calendário) quando o campo está focado (caixa branca).")]
        public Color CorIconeFoco
        {
            get => corIconeFoco;
            set { corIconeFoco = value; Invalidate(); }
        }

        public new bool Focus() => txt != null ? txt.Focus() : base.Focus();

        // =====================================================
        //  PONTOS DE EXTENSÃO PARA OS CAMPOS FILHOS
        // =====================================================

        protected virtual bool TemIcone => false;
        protected virtual void DesenharIcone(Graphics g, Rectangle area, Color cor) { }
        protected virtual void ClicouIcone() { }

        protected virtual bool TextoVazio => txt == null || txt.TextLength == 0;
        protected virtual string PlaceholderEfetivo => placeholder;

        protected virtual void PosicionarCursor()
        {
            if (txt != null) txt.SelectionStart = txt.TextLength;
        }

        protected virtual Rectangle AreaCliqueIcone
        {
            get { var r = AreaIcone; r.Inflate(4, 8); return r; }
        }

        protected Rectangle AreaIcone =>
            new Rectangle(Width - PadH - IconeLado, (Height - 2 - IconeLado) / 2, IconeLado, IconeLado);

        protected bool DropAberto => dropAtual != null && dropAtual.Visible;

        // true logo depois que o dropdown fechou (evita reabrir no mesmo clique)
        protected bool DropRecemFechado => (DateTime.Now - fechouEm).TotalMilliseconds < 250;

        // =====================================================
        //  LÓGICA INTERNA
        // =====================================================

        protected void AnexarTextBox(TextBoxBase t)
        {
            txt = t;
            txt.BorderStyle = BorderStyle.None;
            txt.Font = Font;
            txt.Enter += (s, e) => MudarFoco(true);
            txt.Leave += (s, e) => MudarFoco(false);
            txt.TextChanged += (s, e) => { AtualizarPlaceholder(); OnTextChanged(EventArgs.Empty); };

            lblPlaceholder.AutoSize = false;
            lblPlaceholder.UseMnemonic = false;
            lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft;
            lblPlaceholder.Padding = new Padding(2, 0, 0, 0);
            lblPlaceholder.Cursor = Cursors.IBeam;
            lblPlaceholder.Font = Font;
            lblPlaceholder.MouseDown += (s, e) => FocarCampo();

            Controls.Add(txt);
            Controls.Add(lblPlaceholder);
            lblPlaceholder.BringToFront();

            AtualizarCores();
            AtualizarPlaceholder();
            AjustarLayout();
        }

        protected ToolStripDropDown CriarDropDown(Control conteudo)
        {
            dropHost = new ToolStripControlHost(conteudo)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = true
            };

            dropAtual = new ToolStripDropDown { Padding = Padding.Empty };
            dropAtual.Items.Add(dropHost);
            dropAtual.Closed += (s, e) =>
            {
                fechouEm = DateTime.Now;
                AplicarFoco(txt != null ? txt.Focused : Focused);
            };
            return dropAtual;
        }

        // Para conteúdo que não calcula o próprio tamanho direito (ex.: ListBox):
        // o dropdown passa a ter exatamente este tamanho.
        protected void FixarTamanhoDrop(Size tamanho)
        {
            if (dropHost == null) return;
            dropHost.AutoSize = false;
            dropHost.Size = tamanho;
        }

        protected void FocarCampo()
        {
            if (txt != null)
            {
                txt.Focus();
                PosicionarCursor();
            }
            else
            {
                Focus();
            }
        }

        // Enquanto o dropdown está aberto o foco "sai" do campo, mas o visual continua focado.
        protected void MudarFoco(bool valor)
        {
            if (!valor && DropAberto) return;
            AplicarFoco(valor);
        }

        private void AplicarFoco(bool valor)
        {
            if (focado == valor) return;
            focado = valor;
            AtualizarCores();
            AtualizarPlaceholder();
            Invalidate();
        }

        // Sobe na hierarquia até achar uma cor de fundo opaca
        // (TextBox não aceita BackColor transparente).
        private Color CorFundoReal()
        {
            Control c = Parent;
            while (c != null)
            {
                if (c.BackColor.A == 255) return c.BackColor;
                c = c.Parent;
            }
            return Color.White;
        }

        protected void AtualizarCores()
        {
            Color fundo = CorFundoReal();

            if (txt != null)
            {
                txt.BackColor = focado ? Color.White : fundo;
                txt.ForeColor = focado ? corTextoFoco : corTextoNormal;
            }

            lblPlaceholder.BackColor = fundo;
            lblPlaceholder.ForeColor = corPlaceholder;
        }

        protected void AtualizarPlaceholder()
        {
            if (txt == null)
            {
                Invalidate();
                return;
            }

            lblPlaceholder.Text = PlaceholderEfetivo;
            lblPlaceholder.Visible = !focado && TextoVazio && PlaceholderEfetivo.Length > 0;
        }

        protected void AjustarLayout()
        {
            if (txt == null) return;

            int direita = TemIcone ? IconeLado + 6 : 0;
            txt.Left = PadH;
            txt.Width = Math.Max(10, Width - PadH * 2 - direita);
            txt.Top = Math.Max(0, (Height - 2 - txt.Height) / 2);

            lblPlaceholder.Bounds = new Rectangle(txt.Left, 0, txt.Width, Math.Max(1, Height - 2));
        }

        private Color CorIconeAtual
        {
            get
            {
                Color baseCor = focado ? corIconeFoco : (corIcone.IsEmpty ? lineColor : corIcone);
                return hoverIcone ? baseCor : Color.FromArgb(170, baseCor);
            }
        }

        private static GraphicsPath RetanguloArredondado(Rectangle r, int raio)
        {
            int d = raio * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        // =====================================================
        //  DESENHO
        // =====================================================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (focado)
            {
                var r = new Rectangle(1, 1, Width - 3, Height - 3);
                using (var path = RetanguloArredondado(r, Raio))
                using (var fill = new SolidBrush(Color.White))
                using (var pen = new Pen(lineColor, 1.5f))
                {
                    g.FillPath(fill, path);
                    g.DrawPath(pen, path);
                }
            }
            else
            {
                using (var pen = new Pen(lineColor, 2f))
                    g.DrawLine(pen, 0, Height - 2, Width, Height - 2);
            }

            if (TemIcone)
                DesenharIcone(g, AreaIcone, CorIconeAtual);
        }

        // =====================================================
        //  MOUSE / FOCO
        // =====================================================

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool sobre = TemIcone && AreaCliqueIcone.Contains(e.Location);
            if (sobre != hoverIcone)
            {
                hoverIcone = sobre;
                Cursor = sobre ? Cursors.Hand : Cursors.Default;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (hoverIcone)
            {
                hoverIcone = false;
                Cursor = Cursors.Default;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            if (TemIcone && AreaCliqueIcone.Contains(e.Location))
                ClicouIcone();
            else
                FocarCampo();
        }

        // Quem chamar campo.Focus() como "Control" (ex.: o método Erro do form)
        // acaba aqui: repassa o foco pro TextBox interno.
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (txt != null) txt.Focus();
            else MudarFoco(true);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (txt == null) MudarFoco(false);
        }

        // =====================================================
        //  SINCRONIA COM O CONTROLE PAI / FONTE / TAMANHO
        // =====================================================

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            AtualizarCores();
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            AtualizarCores();
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (txt != null) txt.Font = Font;
            lblPlaceholder.Font = Font;
            AjustarLayout();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AjustarLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && dropAtual != null) dropAtual.Dispose();
            base.Dispose(disposing);
        }
    }
}