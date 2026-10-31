
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public static class ResponsividadeForm
    {
        private class Original
        {
            public Rectangle Bounds;
            public float FontSize;
        }

        private class Estado
        {
            public readonly Dictionary<Control, Original> Originais =
                new Dictionary<Control, Original>();

            public Size TamanhoOriginal;
            public bool Inicializado;
        }

        public static void Aplicar(Form form)
        {
            Estado estado = new Estado();

            form.Load += (s, e) =>
            {
                if (estado.Inicializado)
                    return;

                estado.TamanhoOriginal = form.ClientSize;

                GuardarOriginais(form, estado);

                estado.Inicializado = true;

                form.WindowState = FormWindowState.Maximized;
            };

            form.Resize += (s, e) =>
            {
                Redimensionar(form, estado);
            };
        }

        private static void GuardarOriginais(
            Control pai, Estado estado)
        {
            foreach (Control c in pai.Controls)
            {
                estado.Originais[c] = new Original
                {
                    Bounds = c.Bounds,
                    FontSize = c.Font.Size
                };

                GuardarOriginais(c, estado);
            }
        }

        private static void Redimensionar(
            Form form, Estado estado)
        {
            if (!estado.Inicializado ||
                estado.TamanhoOriginal.IsEmpty ||
                form.ClientSize.Width == 0 ||
                form.ClientSize.Height == 0)
                return;

            float sx = (float)form.ClientSize.Width /
                       estado.TamanhoOriginal.Width;

            float sy = (float)form.ClientSize.Height /
                       estado.TamanhoOriginal.Height;

            float sFonte = Math.Min(sx, sy);

            form.SuspendLayout();

            foreach (var par in estado.Originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                if (c.IsDisposed)
                    continue;

                c.Bounds = new Rectangle(
                    (int)(o.Bounds.X * sx),
                    (int)(o.Bounds.Y * sy),
                    (int)(o.Bounds.Width * sx),
                    (int)(o.Bounds.Height * sy)
                );

                c.Font = new Font(
                    c.Font.FontFamily,
                    Math.Max(1f, o.FontSize * sFonte),
                    c.Font.Style
                );
            }

            form.ResumeLayout(true);
        }
    }
}
