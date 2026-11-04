using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Barra de navegação lateral verde escura, expansível/recolhível.
    /// É montada automaticamente a partir dos itens de um MenuStrip (o MenuStrip pode
    /// ficar invisível: os cliques são repassados com PerformClick, então todos os
    /// eventos já existentes continuam funcionando).
    /// </summary>
    internal sealed class BarraLateral : Panel
    {
        public const int LarguraAberta = 232;
        public const int LarguraFechada = 64;
        public const int AlturaTopo = 112;   // espaço do título no alto da barra
        private const int MargemTopo = 32;   // respiro acima do botão e do título

        private static readonly Font FonteIcone = new Font("Segoe UI Emoji", 14f, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font FonteIconeSub = new Font("Segoe UI Emoji", 12f, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font FonteMarca = TemaModerno.Fonte(12f, FontStyle.Bold);
        private static readonly Font FonteTitulo = TemaModerno.Fonte(10.5f, FontStyle.Bold);
        private static readonly Font FonteSub = TemaModerno.Fonte(9.75f);
        private static readonly Font FonteGrupo = TemaModerno.Fonte(8f, FontStyle.Bold);

        private readonly FlowLayoutPanel lista;
        private readonly Timer anim;
        private readonly ToolTip dica = new ToolTip();
        private readonly List<Secao> secoes = new List<Secao>();
        private bool aberta = true;
        private int alvo = LarguraAberta;

        private sealed class Secao
        {
            public ItemBotao Cabecalho;
            public Panel Corpo;
            public bool Expandida;
        }

        // ---------- Botão desenhado à mão (ícone fixo à esquerda, título ao lado) ----------
        private sealed class ItemBotao : Button
        {
            public string Icone = "";
            public string Titulo = "";
            public bool Sub, Grupo, Chevron, Aberto;

            public ItemBotao()
            {
                SetStyle(ControlStyles.Selectable, false);
                TabStop = false;
                FlatStyle = FlatStyle.Flat;
                FlatAppearance.BorderSize = 0;
                Cursor = Cursors.Hand;
                Margin = Padding.Empty;
                UseVisualStyleBackColor = false;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                if (Icone.Length > 0)
                    TextRenderer.DrawText(e.Graphics, Icone, Sub ? FonteIconeSub : FonteIcone,
                        Sub ? new Rectangle(22, 0, 44, Height) : new Rectangle(0, 0, LarguraFechada, Height), ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

                if (Width > LarguraFechada + 24 && Titulo.Length > 0)
                {
                    int x = Sub && !Grupo ? 76 : (Grupo ? 68 : LarguraFechada);
                    int direita = Chevron ? 32 : 8;
                    Font f = Grupo ? FonteGrupo : (Sub ? FonteSub : FonteTitulo);
                    string txt = Grupo ? Titulo.ToUpperInvariant() : Titulo;
                    TextRenderer.DrawText(e.Graphics, txt, f,
                        new Rectangle(x, 0, Math.Max(0, Width - x - direita), Height), ForeColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
                }

                if (Chevron && Width > LarguraFechada + 80)
                    TextRenderer.DrawText(e.Graphics, Aberto ? "\u25BE" : "\u25B8", FonteSub,
                        new Rectangle(Width - 32, 0, 26, Height), TemaModerno.Oliva1,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        public BarraLateral(MenuStrip menu)
        {
            Dock = DockStyle.Left;
            Width = LarguraAberta;
            BackColor = TemaModerno.BarraFundo;
            DoubleBuffered = true;

            anim = new Timer { Interval = 12 };
            anim.Tick += Animar;

            // lista com as seções (Fill precisa ser adicionado primeiro)
            lista = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = false,
                BackColor = TemaModerno.BarraFundo,
                Padding = new Padding(0, 16, 0, 0)
            };
            lista.SizeChanged += (s, e) => AjustarLarguras();
            Controls.Add(lista);

            // cabeçalho: botão "hambúrguer" + nome
            var topo = new Panel { Dock = DockStyle.Top, Height = AlturaTopo, BackColor = TemaModerno.BarraFundo };
            topo.SizeChanged += (s, e) => topo.Invalidate();
            topo.Paint += (s, e) =>
            {
                // título em uma linha só (nunca quebra), alinhado com o botão ☰
                if (topo.Width > 60)
                    TextRenderer.DrawText(e.Graphics, "Guri Atacarejo", FonteMarca,
                        new Rectangle(24, MargemTopo, topo.Width - 24 - 8, 48), Color.White,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.SingleLine
                        | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);

                using (var pen = new Pen(TemaModerno.Misturar(TemaModerno.Verde4, TemaModerno.BarraFundo, 0.5)))
                    e.Graphics.DrawLine(pen, 12, topo.Height - 1, topo.Width - 12, topo.Height - 1);
            };
            Controls.Add(topo);

            // filete lima na borda direita: separa a barra do conteúdo claro
            Controls.Add(new Panel { Dock = DockStyle.Right, Width = 3, BackColor = TemaModerno.Lima1 });

            foreach (ToolStripItem ti in menu.Items)
            {
                var mi = ti as ToolStripMenuItem;
                if (mi != null && mi.Available)
                    AdicionarSecao(mi);
            }
        }

        // A barra agora é fixa (sempre aberta). Mantido vazio para não quebrar
        // chamadas existentes em outros arquivos.
        public void Alternar()
        {
        }

        private void Alternar(bool abrir)
        {
            aberta = abrir;
            alvo = abrir ? LarguraAberta : LarguraFechada;
            foreach (Secao s in secoes)
            {
                if (!abrir) DefinirSecao(s, false);
                else s.Corpo.Visible = s.Expandida;
            }
            anim.Start();
        }

        private void Animar(object sender, EventArgs e)
        {
            int d = alvo - Width;
            if (Math.Abs(d) <= 32)
            {
                Width = alvo;
                anim.Stop();
            }
            else
            {
                Width += Math.Sign(d) * 32;
            }
        }

        private void AdicionarSecao(ToolStripMenuItem mi)
        {
            var s = new Secao();
            s.Cabecalho = new ItemBotao
            {
                Icone = IconeDe(mi.Text),
                Titulo = mi.Text,
                Chevron = mi.HasDropDownItems,
                Height = 48,
                Width = LarguraAberta
            };
            Estilizar(s.Cabecalho);
            dica.SetToolTip(s.Cabecalho, mi.Text);

            s.Corpo = new Panel
            {
                Width = LarguraAberta,
                Margin = Padding.Empty,
                BackColor = TemaModerno.BarraSub,
                Visible = false
            };
            int y = 0;
            Preencher(mi, s.Corpo, ref y);
            s.Corpo.Height = y;

            ToolStripMenuItem origem = mi;
            Secao secao = s;
            if (mi.HasDropDownItems)
                s.Cabecalho.Click += (a, b) => AlternarSecao(secao);
            else
                s.Cabecalho.Click += (a, b) => origem.PerformClick();

            secoes.Add(s);
            lista.Controls.Add(s.Cabecalho);
            lista.Controls.Add(s.Corpo);
        }

        // achata os submenus: itens com filhos viram um pequeno título de grupo
        private void Preencher(ToolStripMenuItem pai, Panel corpo, ref int y)
        {
            foreach (ToolStripItem ti in pai.DropDownItems)
            {
                var mi = ti as ToolStripMenuItem;
                if (mi == null || !mi.Available) continue;

                bool grupo = mi.HasDropDownItems;
                var b = new ItemBotao
                {
                    Titulo = mi.Text,
                    Icone = grupo ? "" : IconeSub(mi.Text),
                    Sub = true,
                    Grupo = grupo,
                    Location = new Point(0, y),
                    Size = new Size(corpo.Width, grupo ? 32 : 40)
                };
                Estilizar(b);
                dica.SetToolTip(b, mi.Text);

                if (grupo)
                {
                    b.ForeColor = TemaModerno.Oliva1;
                    b.Cursor = Cursors.Default;
                    b.FlatAppearance.MouseOverBackColor = b.BackColor;
                    b.FlatAppearance.MouseDownBackColor = b.BackColor;
                }
                else
                {
                    ToolStripMenuItem destino = mi;
                    b.Click += (a, e) => destino.PerformClick();
                }

                corpo.Controls.Add(b);
                y += b.Height;
                if (grupo) Preencher(mi, corpo, ref y);
            }
        }

        private void AlternarSecao(Secao s)
        {
            if (!aberta) Alternar(true);   // barra recolhida: primeiro expande a barra
            bool abrir = !s.Expandida;
            foreach (Secao o in secoes) DefinirSecao(o, false);
            DefinirSecao(s, abrir);
        }

        private void DefinirSecao(Secao s, bool expandir)
        {
            s.Expandida = expandir;
            s.Corpo.Visible = expandir && aberta;
            s.Cabecalho.Aberto = expandir;
            s.Cabecalho.BackColor = expandir ? TemaModerno.BarraAtiva : TemaModerno.BarraFundo;
            s.Cabecalho.Invalidate();
        }

        private static void Estilizar(ItemBotao b)
        {
            b.BackColor = b.Sub ? TemaModerno.BarraSub : TemaModerno.BarraFundo;
            b.ForeColor = Color.White;
            b.FlatAppearance.MouseOverBackColor = TemaModerno.BarraHover;
            b.FlatAppearance.MouseDownBackColor = TemaModerno.BarraAtiva;
        }

        private static string IconeDe(string titulo)
        {
            string t = (titulo ?? "").ToLowerInvariant();
            if (t.Contains("funcion")) return "\U0001F464";   // 👤
            if (t.Contains("client")) return "\U0001F465";    // 👥
            if (t.Contains("fornec")) return "\U0001F69A";    // 🚚
            if (t.Contains("mais")) return "\u2699";          // ⚙
            return "\u2022";
        }

        private static string IconeSub(string titulo)
        {
            string t = (titulo ?? "").ToLowerInvariant();
            if (t.Contains("logout")) return "\U0001F6AA";    // 🚪
            if (t.Contains("login")) return "\U0001F511";     // 🔑
            if (t.Contains("financ")) return "\U0001F4B0";    // 💰
            if (t.Contains("estoque")) return "\U0001F4CA";   // 📊
            if (t.Contains("relat")) return "\U0001F4C8";     // 📈
            if (t.Contains("fornec")) return "\U0001F3ED";    // 🏭
            if (t.Contains("compra")) return "\U0001F6D2";    // 🛒
            if (t.Contains("produto")) return "\U0001F4E6";   // 📦
            if (t.Contains("funcion")) return "\U0001F464";   // 👤
            if (t.Contains("lote")) return "\U0001F4CB";      // 📋
            if (t.Contains("consulta")) return "\U0001F50D";  // 🔍
            if (t.Contains("registr")) return "\u2795";       // ➕
            return "\u2022";
        }

        private void AjustarLarguras()
        {
            int w = lista.ClientSize.Width;
            if (w <= 0) return;
            foreach (Secao s in secoes)
            {
                s.Cabecalho.Width = w;
                s.Corpo.Width = w;
                foreach (Control c in s.Corpo.Controls) c.Width = w;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                PerformLayout();
                AjustarLarguras();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                anim.Dispose();
                dica.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}