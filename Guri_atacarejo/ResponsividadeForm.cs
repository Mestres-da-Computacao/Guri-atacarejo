using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guri_atacarejo.forms;

namespace Guri_atacarejo
{
    public static class ResponsividadeForm
    {
        // folga mínima à direita quando o conteúdo do designer é maior que o contêiner
        private const int Margem = 24;

        private class Original
        {
            public Rectangle Bounds;
            public float FontSize;
            public Control Pai;

            // Só para rótulos: o campo que está à direita, na mesma linha,
            // e a distância original entre o rótulo e esse campo.
            public Control Vizinho;
            public int Folga;
        }

        private class Estado
        {
            public readonly Dictionary<Control, Original> Originais =
                new Dictionary<Control, Original>();

            // "tamanho de projeto" de cada contêiner: o maior entre o tamanho dele
            // no Load e o espaço que o conteúdo posicionado no designer realmente ocupa.
            // Assim, se o conteúdo é maior que o contêiner (ex.: barra lateral tirou
            // espaço), ele é encolhido para caber em vez de ser cortado.
            public readonly Dictionary<Control, Size> ProjetoPai =
                new Dictionary<Control, Size>();

            public bool Inicializado;
        }

        public static void Aplicar(Form form)
        {
            Estado estado = new Estado();

            form.Load += (s, e) =>
            {
                if (estado.Inicializado)
                    return;

                form.PerformLayout();

                GuardarOriginais(form, estado);

                estado.Inicializado = true;

                Redimensionar(form, estado);

                form.WindowState = FormWindowState.Maximized;
            };

            form.Resize += (s, e) =>
            {
                Redimensionar(form, estado);
            };
        }

        private static void GuardarOriginais(Control pai, Estado estado)
        {
            Size projeto = pai.ClientSize;
            int maxDireita = 0;
            int maxBaixo = 0;

            foreach (Control c in pai.Controls)
            {
                // A barra lateral cuida do próprio layout: não escalar nem ela
                // nem o que há dentro dela (senão o botão e o título se atropelam).
                if (c is BarraLateral)
                    continue;

                Original o = new Original
                {
                    Bounds = c.Bounds,
                    FontSize = c.Font.Size,
                    Pai = pai
                };

                if (c.Dock == DockStyle.None)
                {
                    maxDireita = Math.Max(maxDireita, c.Right);
                    maxBaixo = Math.Max(maxBaixo, c.Bottom);
                }

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

                // Cards (UserControl), listas dinâmicas (FlowLayoutPanel) e o
                // CampoTexto cuidam do próprio layout interno: o controle em si
                // é redimensionado, mas o que há dentro dele NÃO deve ser escalado.
                if (c is UserControl || c is FlowLayoutPanel || c is CampoTexto)
                    continue;

                GuardarOriginais(c, estado);
            }

            bool rolagem = pai is ScrollableControl sc && sc.AutoScroll;
            if (!rolagem)
            {
                if (maxDireita > projeto.Width)
                    projeto.Width = maxDireita + Margem;
                if (maxBaixo > projeto.Height)
                    projeto.Height = maxBaixo + Margem;
            }

            estado.ProjetoPai[pai] = projeto;
        }

        private static bool EhCampo(Control c)
        {
            return c is TextBoxBase
                || c is ComboBox
                || c is NumericUpDown
                || c is DateTimePicker
                || c is CampoTexto;
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
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private static void AjustarLinhasGrid(DataGridView grid)
        {
            int altura = grid.Font.Height + 12;

            grid.RowTemplate.Height = altura;

            foreach (DataGridViewRow linha in grid.Rows)
                linha.Height = altura;

            // cabeçalho sempre alto o bastante para a fonte atual (evita letra cortada)
            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = grid.Font.Height + 24;
        }

        // fatores de escala do contêiner onde o controle mora
        private static void Fatores(Estado estado, Original o, out float fx, out float fy)
        {
            fx = 1f;
            fy = 1f;

            Size projeto;
            if (o.Pai == null || o.Pai.IsDisposed ||
                !estado.ProjetoPai.TryGetValue(o.Pai, out projeto) ||
                projeto.Width <= 0 || projeto.Height <= 0)
                return;

            Size atual = o.Pai.ClientSize;
            if (atual.Width <= 0 || atual.Height <= 0)
                return;

            fx = (float)atual.Width / projeto.Width;
            fy = (float)atual.Height / projeto.Height;
        }

        private static void Redimensionar(Form form, Estado estado)
        {
            if (!estado.Inicializado ||
                form.ClientSize.Width == 0 ||
                form.ClientSize.Height == 0)
                return;

            form.PerformLayout();
            form.SuspendLayout();

            // 1ª passada: posição/tamanho e fonte de todos os controles
            foreach (var par in estado.Originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                if (c.IsDisposed)
                    continue;

                float sx, sy;
                Fatores(estado, o, out sx, out sy);
                float sFonte = Math.Min(sx, sy);

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

                float sx, sy;
                Fatores(estado, o, out sx, out sy);
                float sFonte = Math.Min(sx, sy);

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