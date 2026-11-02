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

            // Só para rótulos: o campo que está à direita, na mesma linha,
            // e a distância original entre o rótulo e esse campo.
            public Control Vizinho;
            public int Folga;
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
                Original o = new Original
                {
                    Bounds = c.Bounds,
                    FontSize = c.Font.Size
                };

                // Rótulo com um campo ao lado: guarda o vínculo
                if (c is Label lbl && lbl.AutoSize)
                {
                    Control campo = AcharCampoADireita(lbl);

                    if (campo != null)
                    {
                        o.Vizinho = campo;
                        o.Folga = Math.Max(0, campo.Left - lbl.Right);
                    }
                }

                estado.Originais[c] = o;

                if (c is DataGridView grid)
                    ConfigurarGrid(grid);

                // Cards (UserControl) e listas dinâmicas (FlowLayoutPanel)
                // cuidam do próprio layout: não escalar o que há dentro deles.
                if (c is UserControl || c is FlowLayoutPanel)
                    continue;

                GuardarOriginais(c, estado);
            }
        }

        private static bool EhCampo(Control c)
        {
            return c is TextBoxBase
                || c is ComboBox
                || c is NumericUpDown
                || c is DateTimePicker;
        }

        // Procura o campo de entrada mais próximo, à direita do rótulo,
        // na mesma linha.
        private static Control AcharCampoADireita(Label lbl)
        {
            Control melhor = null;

            int centroLbl = lbl.Top + lbl.Height / 2;

            foreach (Control irmao in lbl.Parent.Controls)
            {
                if (irmao == lbl || !EhCampo(irmao))
                    continue;

                if (irmao.Left < lbl.Right - 2)
                    continue;

                int centroIrmao = irmao.Top + irmao.Height / 2;

                bool mesmaLinha =
                    (centroLbl >= irmao.Top && centroLbl <= irmao.Bottom) ||
                    (centroIrmao >= lbl.Top && centroIrmao <= lbl.Bottom);

                if (!mesmaLinha)
                    continue;

                if (melhor == null || irmao.Left < melhor.Left)
                    melhor = irmao;
            }

            return melhor;
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

            // 1ª passada: posição/tamanho e fonte de todos os controles
            foreach (var par in estado.Originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                if (c.IsDisposed)
                    continue;

                // Rótulos com campo ao lado são posicionados na 2ª passada.
                // Controles com Dock (ex.: MenuStrip) só têm a fonte escalada.
                if (c.Dock == DockStyle.None && o.Vizinho == null)
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

            // 2ª passada: rótulos coladinhos no campo, com a distância original
            // escalada pela fonte (e não pela largura da janela)
            foreach (var par in estado.Originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                if (o.Vizinho == null || c.IsDisposed || o.Vizinho.IsDisposed)
                    continue;

                Size tamanho = c.PreferredSize;
                int folga = (int)(o.Folga * sFonte);

                int x = o.Vizinho.Left - folga - tamanho.Width;
                int y = o.Vizinho.Top + (o.Vizinho.Height - tamanho.Height) / 2;

                c.Location = new Point(Math.Max(0, x), y);
            }

            form.ResumeLayout(true);
        }
    }
}