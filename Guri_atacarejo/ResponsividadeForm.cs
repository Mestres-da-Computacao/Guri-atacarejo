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

        private static void GuardarOriginais(Control pai, Estado estado)
        {
            foreach (Control c in pai.Controls)
            {
                estado.Originais[c] = new Original
                {
                    Bounds = c.Bounds,
                    FontSize = c.Font.Size
                };

                if (c is DataGridView grid)
                    ConfigurarGrid(grid);

                // Cards (UserControl) e listas dinâmicas (FlowLayoutPanel)
                // cuidam do próprio layout: não escalar o que há dentro deles.
                if (c is UserControl || c is FlowLayoutPanel)
                    continue;

                GuardarOriginais(c, estado);
            }
        }

        // Colunas passam a preencher a largura da grade, proporcionais
        // às larguras definidas no designer.
        private static void ConfigurarGrid(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
                col.FillWeight = Math.Max(1, col.Width);

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private static void AjustarLinhasGrid(DataGridView grid)
        {
            int altura = grid.Font.Height + 12;

            grid.RowTemplate.Height = altura;

            foreach (DataGridViewRow linha in grid.Rows)
                linha.Height = altura;
        }

        private static void Redimensionar(Form form, Estado estado)
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

                // Controles ancorados por Dock (ex.: MenuStrip) não têm
                // posição/tamanho escalados, só a fonte.
                if (c.Dock == DockStyle.None)
                {
                    c.Bounds = new Rectangle(
                        (int)(o.Bounds.X * sx),
                        (int)(o.Bounds.Y * sy),
                        (int)(o.Bounds.Width * sx),
                        (int)(o.Bounds.Height * sy)
                    );
                }

                float novaFonte = Math.Max(1f, o.FontSize * sFonte);

                if (Math.Abs(c.Font.Size - novaFonte) > 0.05f)
                {
                    c.Font = new Font(
                        c.Font.FontFamily,
                        novaFonte,
                        c.Font.Style
                    );
                }

                if (c is DataGridView grid)
                    AjustarLinhasGrid(grid);
            }

            form.ResumeLayout(true);
        }
    }
}