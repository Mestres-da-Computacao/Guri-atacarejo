using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Substitui o ComboBox (departamento, cargo...) no estilo underline.
    /// Mantém DataSource, DisplayMember, ValueMember, SelectedIndex, SelectedValue,
    /// SelectedItem, Text e o evento SelectedIndexChanged.
    /// </summary>
    [DesignerCategory("Code"), DefaultEvent("SelectedIndexChanged")]
    public class CampoCombo : CampoBase
    {
        private const int MaxLinhas = 8;

        private readonly ListBox lista = new ListBox();
        private readonly ToolStripDropDown drop;
        private readonly List<object> itens = new List<object>();

        private object dataSource;
        private string displayMember = "";
        private string valueMember = "";
        private int selectedIndex = -1;
        private int hover = -1;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedValueChanged;
        public event EventHandler SelectionChangeCommitted;

        public CampoCombo()
        {
            lista.BorderStyle = BorderStyle.None;
            lista.DrawMode = DrawMode.OwnerDrawFixed;
            lista.IntegralHeight = false;
            lista.BackColor = Color.White;
            lista.DrawItem += DesenharItem;

            lista.MouseMove += (s, e) =>
            {
                int i = lista.IndexFromPoint(e.Location);
                if (i != hover) { hover = i; lista.Invalidate(); }
            };
            lista.MouseLeave += (s, e) => { hover = -1; lista.Invalidate(); };
            lista.MouseClick += (s, e) =>
            {
                int i = lista.IndexFromPoint(e.Location);
                if (i < 0) return;
                drop.Close();
                Escolher(i);
                Focus();
            };

            drop = CriarDropDown(lista);
        }

        // =====================================================
        //  PROPRIEDADES (mesmos nomes do ComboBox)
        // =====================================================

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            get => dataSource;
            set
            {
                dataSource = value;
                selectedIndex = -1;
                Recarregar();
                Invalidate();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayMember
        {
            get => displayMember;
            set { displayMember = value ?? ""; Invalidate(); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValueMember
        {
            get => valueMember;
            set { valueMember = value ?? ""; Invalidate(); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value < -1 || value >= itens.Count) value = -1;
                if (value == selectedIndex) return;

                selectedIndex = value;
                Invalidate();
                lista.Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
                SelectedValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem => selectedIndex >= 0 ? itens[selectedIndex] : null;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get => selectedIndex >= 0 ? ValorDe(itens[selectedIndex]) : null;
            set
            {
                int idx = -1;
                string alvo = Convert.ToString(value);
                for (int i = 0; i < itens.Count; i++)
                {
                    if (Convert.ToString(ValorDe(itens[i])) == alvo) { idx = i; break; }
                }
                SelectedIndex = idx;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => selectedIndex >= 0 ? TextoDe(itens[selectedIndex]) : "";
            set
            {
                int idx = -1;
                for (int i = 0; i < itens.Count; i++)
                {
                    if (TextoDe(itens[i]) == value) { idx = i; break; }
                }
                SelectedIndex = idx;
            }
        }

        // Só existem pra não quebrar o Designer.cs de quem veio de um ComboBox (não fazem nada)
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FormattingEnabled { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBoxStyle DropDownStyle { get; set; } = ComboBoxStyle.DropDownList;

        // =====================================================
        //  DADOS
        // =====================================================

        private void Recarregar()
        {
            itens.Clear();

            if (dataSource != null)
            {
                var fonte = ListBindingHelper.GetList(dataSource) as IEnumerable;
                if (fonte != null)
                    foreach (object o in fonte) itens.Add(o);
            }

            if (selectedIndex >= itens.Count) selectedIndex = -1;
        }

        private string TextoDe(object o)
        {
            if (o == null) return "";
            if (displayMember.Length > 0)
            {
                var p = TypeDescriptor.GetProperties(o)[displayMember];
                if (p != null) return Convert.ToString(p.GetValue(o)) ?? "";
            }
            return o.ToString();
        }

        private object ValorDe(object o)
        {
            if (o == null) return null;
            if (valueMember.Length > 0)
            {
                var p = TypeDescriptor.GetProperties(o)[valueMember];
                if (p != null) return p.GetValue(o);
            }
            return o;
        }

        // Seleção feita pelo usuário (clique ou teclado)
        private void Escolher(int i)
        {
            SelectedIndex = i;
            SelectionChangeCommitted?.Invoke(this, EventArgs.Empty);
        }

        // =====================================================
        //  LISTA SUSPENSA
        // =====================================================

        protected override bool TemIcone => true;

        // O campo inteiro é clicável, não só a setinha
        protected override Rectangle AreaCliqueIcone => ClientRectangle;

        protected override void ClicouIcone()
        {
            Focus();
            Alternar();
        }

        private void Alternar()
        {
            if (DropAberto) { drop.Close(); return; }
            if (DropRecemFechado) return;
            AbrirLista();
        }

        private void AbrirLista()
        {
            if (!Enabled) return;

            Recarregar();

            lista.BeginUpdate();
            lista.Items.Clear();
            foreach (object o in itens) lista.Items.Add(TextoDe(o));
            lista.EndUpdate();

            if (itens.Count == 0) return;

            lista.ItemHeight = Math.Max(22, (int)(Height * 0.8));
            lista.Size = new Size(Width, Math.Min(itens.Count, MaxLinhas) * lista.ItemHeight);
            FixarTamanhoDrop(lista.Size);
            hover = -1;

            drop.Show(this, new Point(0, Height));

            if (selectedIndex >= 0)
                lista.TopIndex = Math.Max(0, selectedIndex - 2);
        }

        private void DesenharItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Color fundo = e.Index == hover ? Color.FromArgb(214, 236, 214)
                        : e.Index == selectedIndex ? Color.FromArgb(236, 246, 236)
                        : Color.White;

            using (var b = new SolidBrush(fundo))
                e.Graphics.FillRectangle(b, e.Bounds);

            var area = new Rectangle(e.Bounds.X + PadH, e.Bounds.Y, e.Bounds.Width - PadH * 2, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, Convert.ToString(lista.Items[e.Index]), Font, area, corTextoFoco,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine);
        }

        // =====================================================
        //  DESENHO
        // =====================================================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);   // barrinha / caixa branca + setinha

            string texto = selectedIndex >= 0 ? TextoDe(itens[selectedIndex]) : "";
            bool vazio = texto.Length == 0;
            if (vazio) texto = PlaceholderEfetivo;
            if (texto.Length == 0) return;

            Color cor = vazio
                ? (focado ? Color.Gray : corPlaceholder)
                : (focado ? corTextoFoco : corTextoNormal);

            var area = new Rectangle(PadH, 0, Math.Max(10, Width - PadH * 2 - IconeLado - 6), Math.Max(1, Height - 2));
            TextRenderer.DrawText(e.Graphics, texto, Font, area, cor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine);
        }

        protected override void DesenharIcone(Graphics g, Rectangle r, Color cor)
        {
            using (var pen = new Pen(cor, 1.8f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            })
            {
                float cx = r.X + r.Width / 2f;
                float cy = r.Y + r.Height / 2f;
                float w = r.Width * 0.32f;
                float h = r.Height * 0.18f;

                g.DrawLines(pen, new[]
                {
                    new PointF(cx - w, cy - h),
                    new PointF(cx, cy + h),
                    new PointF(cx + w, cy - h)
                });
            }
        }

        // =====================================================
        //  TECLADO
        // =====================================================

        protected override bool IsInputKey(Keys keyData)
        {
            Keys k = keyData & Keys.KeyCode;
            if (k == Keys.Up || k == Keys.Down) return true;
            return base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape && DropAberto)
            {
                drop.Close();
                e.Handled = true;
                return;
            }

            if (itens.Count == 0) return;

            if (e.KeyCode == Keys.Down)
            {
                Escolher(Math.Min(selectedIndex + 1, itens.Count - 1));
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Escolher(Math.Max(selectedIndex - 1, 0));
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F4 || e.KeyCode == Keys.Space)
            {
                Alternar();
                e.Handled = true;
            }
        }

        // Digitar uma letra pula pro próximo item que começa com ela
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsControl(e.KeyChar) || e.KeyChar == ' ') return;

            string c = e.KeyChar.ToString();
            for (int k = 1; k <= itens.Count; k++)
            {
                int i = (selectedIndex + k) % itens.Count;
                if (TextoDe(itens[i]).StartsWith(c, StringComparison.CurrentCultureIgnoreCase))
                {
                    Escolher(i);
                    break;
                }
            }
        }
    }
}