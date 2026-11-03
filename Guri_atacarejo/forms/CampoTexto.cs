using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// TextBox estilo "underline": só a barrinha embaixo + placeholder.
    /// Ao focar, vira uma caixa branca de bordas arredondadas (texto verde).
    /// Ao sair do campo, volta pra barrinha (texto branco).
    /// Com IsPassword = true, mostra o botão de olho (senha oculta por padrão).
    /// </summary>
    [DefaultEvent("TextChanged")]
    public class CampoTexto : Control
    {
        // ---------- Constantes de layout ----------
        // Tudo proporcional à altura do campo, pra acompanhar o redimensionamento do form
        // (com altura 40: margem 12, raio 10, olho 22x14).
        private int PadH => Math.Max(4, (int)Math.Round(Height * 0.30));
        private int Raio => Math.Max(3, Height / 4);
        private int OlhoH => Math.Max(6, (int)Math.Round(Height * 0.35));
        private int OlhoW => OlhoH * 11 / 7;

        // ---------- Controles internos ----------
        private readonly TextBox txt = new TextBox();
        private readonly Label lblPlaceholder = new Label();

        // ---------- Estado ----------
        private bool focado;
        private bool isPassword;
        private bool senhaVisivel;
        private bool hoverOlho;
        private string placeholder = "";

        // ---------- Cores ----------
        private Color lineColor = Color.FromArgb(5, 87, 40);
        private Color corTextoFoco = Color.FromArgb(5, 87, 40);        // texto enquanto digita (fundo branco)
        private Color corTextoNormal = Color.White;                     // texto quando sai do campo (fundo do form)
        private Color corPlaceholder = Color.FromArgb(215, 240, 215);   // preview quando o campo está vazio

        public CampoTexto()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Size = new Size(250, 40);

            txt.BorderStyle = BorderStyle.None;
            txt.Font = Font;
            txt.Enter += (s, e) => { focado = true; AtualizarCores(); AtualizarPlaceholder(); Invalidate(); };
            txt.Leave += (s, e) => { focado = false; AtualizarCores(); AtualizarPlaceholder(); Invalidate(); };
            txt.TextChanged += (s, e) => { AtualizarPlaceholder(); OnTextChanged(EventArgs.Empty); };

            // Placeholder: um Label por cima do TextBox, só visível quando
            // o campo está vazio E sem foco. Clicou nele -> foca no TextBox.
            lblPlaceholder.AutoSize = false;
            lblPlaceholder.UseMnemonic = false;
            lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft;
            lblPlaceholder.Padding = new Padding(2, 0, 0, 0);
            lblPlaceholder.Cursor = Cursors.IBeam;
            lblPlaceholder.Font = Font;
            lblPlaceholder.MouseDown += (s, e) => txt.Focus();

            Controls.Add(txt);
            Controls.Add(lblPlaceholder);
            lblPlaceholder.BringToFront();

            AtualizarCores();
            AtualizarPlaceholder();
            AjustarLayout();
        }

        // =====================================================
        //  PROPRIEDADES PÚBLICAS
        // =====================================================

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => txt.Text;
            set => txt.Text = value;
        }

        [Category("Guri"), DefaultValue(""), Description("Texto de preview quando o campo está vazio.")]
        public string PlaceholderText
        {
            get => placeholder;
            set { placeholder = value ?? ""; AtualizarPlaceholder(); }
        }

        [Category("Guri"), DefaultValue(false), Description("Ativa o modo senha com botão de olho.")]
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                senhaVisivel = false;
                txt.UseSystemPasswordChar = value;   // bolinhas por padrão
                AjustarLayout();
                Invalidate();
            }
        }

        [Category("Guri"), DefaultValue(false), Description("Mostra/oculta a senha.")]
        public bool MostrarSenha
        {
            get => senhaVisivel;
            set
            {
                senhaVisivel = value;
                txt.UseSystemPasswordChar = isPassword && !senhaVisivel;
                Invalidate();
            }
        }

        [Category("Guri"), Description("Cor da barrinha, da borda ao focar e do ícone do olho.")]
        public Color LineColor
        {
            get => lineColor;
            set { lineColor = value; Invalidate(); }
        }

        [Category("Guri"), Description("Cor do texto enquanto o campo está focado (caixa branca).")]
        public Color CorTextoFoco
        {
            get => corTextoFoco;
            set { corTextoFoco = value; AtualizarCores(); }
        }

        [Category("Guri"), Description("Cor do texto quando o campo NÃO está focado.")]
        public Color CorTextoNormal
        {
            get => corTextoNormal;
            set { corTextoNormal = value; AtualizarCores(); }
        }

        [Category("Guri"), Description("Cor do texto de preview (placeholder).")]
        public Color CorPlaceholder
        {
            get => corPlaceholder;
            set { corPlaceholder = value; AtualizarCores(); }
        }

        [Category("Guri"), DefaultValue(32767)]
        public int MaxLength
        {
            get => txt.MaxLength;
            set => txt.MaxLength = value;
        }

        // Eventos repassados do TextBox interno (ex.: pra detectar Enter)
        public new event KeyEventHandler KeyDown
        {
            add { txt.KeyDown += value; }
            remove { txt.KeyDown -= value; }
        }

        public new event KeyPressEventHandler KeyPress
        {
            add { txt.KeyPress += value; }
            remove { txt.KeyPress -= value; }
        }

        public new bool Focus() => txt.Focus();

        // =====================================================
        //  LÓGICA INTERNA
        // =====================================================

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

        private void AtualizarCores()
        {
            Color fundo = CorFundoReal();

            txt.BackColor = focado ? Color.White : fundo;
            txt.ForeColor = focado ? corTextoFoco : corTextoNormal;

            lblPlaceholder.BackColor = fundo;
            lblPlaceholder.ForeColor = corPlaceholder;
        }

        private void AtualizarPlaceholder()
        {
            lblPlaceholder.Text = placeholder;
            lblPlaceholder.Visible = !focado && txt.TextLength == 0 && placeholder.Length > 0;
        }

        private void AjustarLayout()
        {
            int direita = isPassword ? OlhoW + 6 : 0;
            txt.Left = PadH;
            txt.Width = Math.Max(10, Width - PadH * 2 - direita);
            txt.Top = Math.Max(0, (Height - 2 - txt.Height) / 2);

            // O Label usa a altura toda do campo (menos a barrinha), e não a do
            // TextBox, que é justa demais e cortava a parte de baixo das letras (g, p, ú...).
            lblPlaceholder.Bounds = new Rectangle(txt.Left, 0, txt.Width, Math.Max(1, Height - 2));
        }

        private Rectangle AreaOlho =>
            new Rectangle(Width - PadH - OlhoW, (Height - OlhoH) / 2 - 1, OlhoW, OlhoH);

        private Rectangle AreaCliqueOlho
        {
            get { var r = AreaOlho; r.Inflate(4, 8); return r; }
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
                // Caixinha branca com bordas arredondadas
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
                // Só a barrinha embaixo
                using (var pen = new Pen(lineColor, 2f))
                    g.DrawLine(pen, 0, Height - 2, Width, Height - 2);
            }

            if (isPassword)
                DesenharOlho(g);
        }

        private void DesenharOlho(Graphics g)
        {
            var r = AreaOlho;
            float cy = r.Y + r.Height / 2f;
            float x0 = r.X;
            float x1 = r.Right;
            float w = r.Width;
            float off = r.Height * 0.65f;

            Color cor = hoverOlho ? lineColor : Color.FromArgb(120, lineColor);

            using (var pen = new Pen(cor, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            using (var path = new GraphicsPath())
            {
                // contorno do olho (amêndoa)
                path.AddBezier(x0, cy, x0 + w * 0.25f, cy - off, x0 + w * 0.75f, cy - off, x1, cy);
                path.AddBezier(x1, cy, x0 + w * 0.75f, cy + off, x0 + w * 0.25f, cy + off, x0, cy);
                g.DrawPath(pen, path);

                // pupila
                g.DrawEllipse(pen, r.X + w / 2f - 3f, cy - 3f, 6f, 6f);

                // risco = senha oculta
                if (!senhaVisivel)
                    g.DrawLine(pen, x0 + 2, r.Bottom + 1, x1 - 2, r.Y - 1);
            }
        }

        // =====================================================
        //  MOUSE
        // =====================================================

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool sobre = isPassword && AreaCliqueOlho.Contains(e.Location);
            if (sobre != hoverOlho)
            {
                hoverOlho = sobre;
                Cursor = sobre ? Cursors.Hand : Cursors.Default;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (hoverOlho)
            {
                hoverOlho = false;
                Cursor = Cursors.Default;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (isPassword && AreaCliqueOlho.Contains(e.Location))
                MostrarSenha = !senhaVisivel;

            txt.Focus();
            txt.SelectionStart = txt.TextLength;
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
            txt.Font = Font;
            lblPlaceholder.Font = Font;
            AjustarLayout();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AjustarLayout();
        }
    }
}