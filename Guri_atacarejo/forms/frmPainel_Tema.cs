using System;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Visual moderno do painel de vendas (cartões, barra lateral).
    /// Chamado pelo construtor de frmPainel: AplicarTemaPainel() e CriarBarraLateral().
    /// </summary>
    public partial class frmPainel : Icone
    {
        private BarraLateral barraLateral;

        // ------------------------------------------------------------------
        // Reorganiza os controles do designer em cartões, dentro de um painel
        // "host" que preenche a área ao lado da barra lateral.
        // ------------------------------------------------------------------
        private void AplicarTemaPainel()
        {
            SuspendLayout();

            BackColor = TemaModerno.Fundo;
            menuStrip1.Visible = false;   // a navegação agora é a barra lateral

            // ---- medidas (área útil = largura do form menos a barra lateral) ----
            const int m = 24;      // margem externa
            const int gap = 16;    // espaço entre cartões
            int W = ClientSize.Width - BarraLateral.LarguraAberta;
            int H = ClientSize.Height;

            int topo = 96;
            int baixo = H - m;
            int acoesH = 96;
            int acoesY = baixo - acoesH;
            int colDirW = 430;
            int leftW = W - 2 * m - gap - colDirW;
            int rightX = m + leftW + gap;
            int meioH = acoesY - gap - topo - gap;          // altura de info + pagamento
            int infoH = meioH * 52 / 100;
            int pagY = topo + infoH + gap;
            int pagH = acoesY - gap - pagY;

            var host = new Panel
            {
                Name = "pnlConteudo",
                Dock = DockStyle.Fill,
                BackColor = TemaModerno.Fundo
            };

            // ---- título da tela ----
            host.Controls.Add(NovoRotulo("Caixa livre", 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Painel de vendas  \u2022  Guri Atacarejo", 10.5f, FontStyle.Regular,
                TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // ---- cartão: LISTA DE PRODUTOS ----
            panel2.Bounds = new Rectangle(m, topo, leftW, acoesY - gap - topo);
            TemaModerno.Cartao(panel2);
            EstilizarTituloCartao(label2);
            ColocarGrid(panel2, dataGridView1);
            TemaModerno.Grid(dataGridView1, direita: new[] { 2, 3, 4 }, moeda: new[] { 3, 4 });
            ConfigurarColunas(dataGridView1,
                new[] { "Id", "Produto", "Qtd.", "Pre\u00E7o un.", "Total" },
                new[] { 50, 250, 70, 110, 110 });
            host.Controls.Add(panel2);

            // ---- cartão: INFORMAÇÕES DO PRODUTO ----
            panel6.Bounds = new Rectangle(rightX, topo, colDirW, infoH);
            TemaModerno.Cartao(panel6);
            EstilizarTituloCartao(label4);
            ColocarGrid(panel6, dataGridView2);
            TemaModerno.Grid(dataGridView2, moeda: new[] { 1 });
            ConfigurarColunas(dataGridView2,
                new[] { "Produto", "Pre\u00E7o un.", "Unidade", "Validade" },
                new[] { 150, 90, 80, 90 });
            host.Controls.Add(panel6);

            // ---- cartão: PAGAMENTO ----
            pnlPagamento.Bounds = new Rectangle(rightX, pagY, colDirW, pagH);
            TemaModerno.Cartao(pnlPagamento);
            int inner = colDirW - 48;

            pnlPagamento.Controls.Add(NovoRotulo("PAGAMENTO", 9.5f, FontStyle.Bold,
                TemaModerno.Verde4, TemaModerno.Card, new Point(24, 16)));

            Estilizar(label6, 10f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card, new Point(24, 50));
            pnlPagamento.Controls.Add(label6);

            TemaModerno.Combo(cbPag);
            cbPag.Location = new Point(24, 76);
            cbPag.Width = inner;
            pnlPagamento.Controls.Add(cbPag);

            // chip "Cliente: ..."
            panel5.Bounds = new Rectangle(24, 118, inner, 36);
            TemaModerno.Cartao(panel5, 8);
            panel5.BackColor = TemaModerno.Campo;
            Estilizar(label3, 10f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Campo, new Point(12, 8));
            Estilizar(labelClienteRegistrado, 10f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Campo, new Point(78, 8));
            pnlPagamento.Controls.Add(panel5);

            // troco (só aparece em "Dinheiro")
            TrocoContainer.Bounds = new Rectangle(24, 172, 190, 36);
            TemaModerno.Arredondar(TrocoContainer, 8);
            TrocoContainer.BackColor = TemaModerno.Campo;
            Estilizar(label7, 10f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Campo, new Point(12, 8));
            Estilizar(labelTroco, 10f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Campo, new Point(68, 8));
            pnlPagamento.Controls.Add(TrocoContainer);

            lblRS.Text = "R$";
            Estilizar(lblRS, 12f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Card, new Point(236, 177));
            pnlPagamento.Controls.Add(lblRS);

            txtReciboDinheiro.BorderStyle = BorderStyle.FixedSingle;
            txtReciboDinheiro.BackColor = TemaModerno.Campo;
            txtReciboDinheiro.ForeColor = TemaModerno.Texto;
            txtReciboDinheiro.Font = TemaModerno.Fonte(12f, FontStyle.Bold);
            txtReciboDinheiro.Location = new Point(268, 175);
            txtReciboDinheiro.Width = 148;
            pnlPagamento.Controls.Add(txtReciboDinheiro);

            host.Controls.Add(pnlPagamento);

            // ---- cartão: AÇÕES ----
            pnlAcoes.Bounds = new Rectangle(m, acoesY, leftW, acoesH);
            TemaModerno.Cartao(pnlAcoes);
            pnlAcoes.Controls.Add(NovoRotulo("A\u00C7\u00D5ES", 9.5f, FontStyle.Bold,
                TemaModerno.Verde4, TemaModerno.Card, new Point(20, 12)));

            int bx = 20, by = 40, bh = 44, bgap = 12;
            int bw = (leftW - 2 * bx - 3 * bgap) / 4;

            TemaModerno.Botao(btnCancelar, Color.FromArgb(250, 228, 230), TemaModerno.Perigo, Color.FromArgb(244, 206, 210));
            TemaModerno.Botao(btnAlterar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnAdicionar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFinalizar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);

            Button[] botoes = { btnCancelar, btnAlterar, btnAdicionar, btnFinalizar };
            for (int i = 0; i < botoes.Length; i++)
            {
                botoes[i].Bounds = new Rectangle(bx + i * (bw + bgap), by, bw, bh);
                pnlAcoes.Controls.Add(botoes[i]);
            }
            host.Controls.Add(pnlAcoes);

            // ---- cartão escuro: SUBTOTAL ----
            panel3.Bounds = new Rectangle(rightX, acoesY, colDirW, acoesH);
            TemaModerno.Cartao(panel3, 12, false);
            panel3.BackColor = TemaModerno.Floresta;

            label8.Text = "SUBTOTAL";
            Estilizar(label8, 9.5f, FontStyle.Bold, TemaModerno.Oliva1, TemaModerno.Floresta, new Point(20, 12));

            lblTotal.AutoSize = false;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Font = TemaModerno.Fonte(24f, FontStyle.Bold);
            lblTotal.ForeColor = TemaModerno.Menta2;
            lblTotal.BackColor = TemaModerno.Floresta;
            lblTotal.Bounds = new Rectangle(20, 36, colDirW - 40, 50);
            host.Controls.Add(panel3);

            // ---- eventos: remove e adiciona de novo, para ficar sempre UMA assinatura ----
            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnAlterar.Click -= btnAlterar_Click;
            btnAlterar.Click += btnAlterar_Click;
            btnAdicionar.Click -= btnAdicionar_Click;
            btnAdicionar.Click += btnAdicionar_Click;
            btnFinalizar.Click -= btnFinalizar_Click;
            btnFinalizar.Click += btnFinalizar_Click;

            cbPag.SelectedIndexChanged -= cbPag_SelectedIndexChanged;
            cbPag.SelectedIndexChanged += cbPag_SelectedIndexChanged;

            txtReciboDinheiro.Enter -= txtReciboDinheiro_Enter;
            txtReciboDinheiro.Enter += txtReciboDinheiro_Enter;
            txtReciboDinheiro.Leave -= txtReciboDinheiro_Leave;
            txtReciboDinheiro.Leave += txtReciboDinheiro_Leave;
            txtReciboDinheiro.KeyPress -= txtReciboDinheiro_KeyPress;
            txtReciboDinheiro.KeyPress += txtReciboDinheiro_KeyPress;

            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;

            // ---- host por último: Fill precisa ser o último a ser "docado" ----
            Controls.Add(host);
            host.BringToFront();

            ResumeLayout(true);
        }

        // ------------------------------------------------------------------
        // Barra lateral fixa, montada a partir do menuStrip1 (que fica oculto).
        // ------------------------------------------------------------------
        private void CriarBarraLateral()
        {
            barraLateral = new BarraLateral(menuStrip1);
            Controls.Add(barraLateral);
            barraLateral.SendToBack();   // docka antes do conteúdo (que é Fill)
        }

        // ------------------------------------------------------------------
        // Auxiliares
        // ------------------------------------------------------------------
        private static Label NovoRotulo(string texto, float tamanho, FontStyle estilo,
            Color cor, Color fundo, Point local)
        {
            return new Label
            {
                AutoSize = true,
                Text = texto,
                Font = TemaModerno.Fonte(tamanho, estilo),
                ForeColor = cor,
                BackColor = fundo,
                Location = local
            };
        }

        private static void Estilizar(Label l, float tamanho, FontStyle estilo,
            Color cor, Color fundo, Point local)
        {
            l.Font = TemaModerno.Fonte(tamanho, estilo);
            l.ForeColor = cor;
            l.BackColor = fundo;
            l.Location = local;
        }

        private static void EstilizarTituloCartao(Label l)
        {
            Estilizar(l, 12f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Card, new Point(20, 14));
        }

        // tabela ocupando o cartão, abaixo do título
        private static void ColocarGrid(Panel cartao, DataGridView grid)
        {
            cartao.Controls.Add(grid);
            grid.Location = new Point(1, 52);
            grid.Size = new Size(cartao.Width - 2, cartao.Height - 53);
        }

        private static void ConfigurarColunas(DataGridView g, string[] titulos, int[] larguras)
        {
            for (int i = 0; i < g.Columns.Count && i < titulos.Length; i++)
            {
                g.Columns[i].HeaderText = titulos[i];
                g.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                g.Columns[i].Width = larguras[i];
            }
        }
    }
}