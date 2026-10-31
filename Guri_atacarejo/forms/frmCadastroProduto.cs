using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmCadastroProduto : Form
    {
        private class Original
        {
            public Rectangle Bounds;
            public float FontSize;
        }

        private readonly Dictionary<Control, Original> _originais = new Dictionary<Control, Original>();
        private Size _tamanhoOriginal;

        public frmCadastroProduto()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                _tamanhoOriginal = ClientSize;   // 950 x 526 do designer
                GuardarOriginais(this);
                WindowState = FormWindowState.Maximized;
            };

            Resize += (s, e) => Redimensionar();
        }

        private void GuardarOriginais(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                _originais[c] = new Original { Bounds = c.Bounds, FontSize = c.Font.Size };
                GuardarOriginais(c);
            }
        }

        private void Redimensionar()
        {
            if (_tamanhoOriginal.IsEmpty || ClientSize.Width == 0 || ClientSize.Height == 0)
                return;

            float sx = (float)ClientSize.Width / _tamanhoOriginal.Width;
            float sy = (float)ClientSize.Height / _tamanhoOriginal.Height;
            float sFonte = Math.Min(sx, sy);   // fonte segue o menor fator pra não estourar

            SuspendLayout();
            foreach (var par in _originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                c.Bounds = new Rectangle(
                    (int)(o.Bounds.X * sx),
                    (int)(o.Bounds.Y * sy),
                    (int)(o.Bounds.Width * sx),
                    (int)(o.Bounds.Height * sy));

                c.Font = new Font(c.Font.FontFamily, o.FontSize * sFonte, c.Font.Style);
            }
            ResumeLayout(true);
        }
    }
}