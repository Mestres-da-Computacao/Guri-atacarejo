using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioEstoque : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(Color fundo, Color texto)
        {
            // O DWM espera o formato COLORREF: 0x00BBGGRR
            int corFundo = fundo.R | (fundo.G << 8) | (fundo.B << 16);
            int corTexto = texto.R | (texto.G << 8) | (texto.B << 16);

            DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref corFundo, sizeof(int));
            DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref corTexto, sizeof(int));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Cor da barra superior do form
            DefinirCorBarra(Color.FromArgb(19, 83, 46), Color.White);
        }

        string connectionString = Properties.Settings.Default.ConnectionString;

        int idProduto = 0;          // produto que foi clicado no grid
        string nomeProduto = "";
        DataTable operacoes;        // compras e vendas do produto clicado (vazio até clicarem em um produto)

        public frmRelatorioEstoque()
        {
            InitializeComponent();

            CriarControlesRelatorio();

            AplicarTema();   // visual igual ao do frmPainel (TemaModerno)
            AplicarTemaRelatorio("Relat\u00F3rio de estoque");
            ResponsividadeForm.Aplicar(this);

            cbTipo.SelectedIndex = 0;     // "Compras e vendas"
            cbPeriodo.SelectedIndex = 0;  // "Dia"

            PadraoTela.AdicionarBarraLateral(this);   // barra lateral fixa

            this.Text = "Relatório de estoque";
        }

        private void frmRelatorioEstoque_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            MostrarMensagem("Clique em um produto para ver as compras e vendas.");
        }

        // ------------------------------------------------------
        // VISUAL (cartão, barra lateral)
        // ------------------------------------------------------

        // Reorganiza os controles do designer num cartão, dentro de um painel
        // "host" que preenche a área ao lado da barra lateral.
        private void AplicarTema()
        {
            SuspendLayout();

            ClientSize = new Size(1180, 640);
            BackColor = TemaModerno.Fundo;
            Text = "Relat\u00F3rio de estoque";

            const int m = 24;
            int W = ClientSize.Width - BarraLateral.LarguraAberta;
            int H = ClientSize.Height;

            int topo = 96;
            int cartaoW = W - 2 * m;
            int cartaoH = H - topo - m;

            var host = new Panel
            {
                Name = "pnlConteudo",
                Dock = DockStyle.Fill,
                BackColor = TemaModerno.Fundo
            };

            // ---- título da tela ----
            host.Controls.Add(NovoRotulo("Estoque", 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Relat\u00F3rio de estoque  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // ---- cartão ----
            var cartao = new Panel { Bounds = new Rectangle(m, topo, cartaoW, cartaoH) };
            TemaModerno.Cartao(cartao);

            cartao.Controls.Add(NovoRotulo("Produtos e movimenta\u00E7\u00F5es", 12f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Card, new Point(20, 14)));

            int areaY = 108;
            int areaH = cartaoH - areaY - 20;
            int gridW = (cartaoW - 40 - 16) * 40 / 100;
            int detX = 20 + gridW + 16;
            int detW = cartaoW - 20 - detX;

            // filtros (ficam acima dos cards, porque é neles que eles atuam)
            TemaModerno.Combo(cbTipo);
            TemaModerno.Combo(cbPeriodo);
            PadraoTela.AjustarAlturaCombo(cbTipo, cbPeriodo);

            cbTipo.Location = new Point(detX, 56);
            cbTipo.Width = 210;
            cartao.Controls.Add(cbTipo);

            cbPeriodo.Location = new Point(detX + 226, 56);
            cbPeriodo.Width = 110;
            cartao.Controls.Add(cbPeriodo);

            maskData.BorderStyle = BorderStyle.FixedSingle;
            maskData.Font = TemaModerno.Fonte(11f);
            maskData.BackColor = TemaModerno.Campo;
            maskData.ForeColor = TemaModerno.Texto;
            maskData.Location = new Point(detX + 352, 58);
            maskData.Width = 140;
            cartao.Controls.Add(maskData);

            PadraoTela.AlinharNoEixo(cbTipo, cbPeriodo, maskData);

            // tabela de produtos (esquerda)
            cartao.Controls.Add(dataGridView1);
            dataGridView1.Bounds = new Rectangle(20, areaY, gridW, areaH);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            TemaModerno.Grid(dataGridView1);
            dataGridView1.DefaultCellStyle.ForeColor = TemaModerno.Texto;
            dataGridView1.DefaultCellStyle.SelectionForeColor = TemaModerno.Texto;

            // cards das operações (direita)
            cartao.Controls.Add(flowCards);
            flowCards.BackColor = TemaModerno.Card;
            flowCards.BorderStyle = BorderStyle.None;
            flowCards.Bounds = new Rectangle(detX, areaY, detW, areaH);

            // botão "Imprimir relatório" no canto direito do cabeçalho
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            btnImprimir.Text = "Imprimir relat\u00F3rio";
            btnImprimir.Size = new Size(180, 44);
            PadraoTela.CentralizarTexto(btnImprimir);
            host.Controls.Add(btnImprimir);
            Action posicionarImprimir = () =>
                btnImprimir.Location = new Point(host.ClientSize.Width - btnImprimir.Width - m, 22);
            host.Resize += (s, e) => posicionarImprimir();
            posicionarImprimir();

            host.Controls.Add(cartao);

            // esconde a caixa laranja do designer
            groupBox1.Visible = false;

            // ---- host por último: Fill precisa ser o último a ser "docado" ----
            Controls.Add(host);
            host.BringToFront();

            ResumeLayout(true);
        }

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

        // títulos, alinhamento e formato das colunas da tabela de produtos
        private void FormatarColunasProdutos()
        {
            DataGridView g = dataGridView1;

            ConfigurarColuna(g, "IdProduto", "Id", 60, false, null);
            ConfigurarColuna(g, "Nome", "Produto", 0, false, null);
            ConfigurarColuna(g, "Preco", "Pre\u00E7o", 0, true, "C2");
            ConfigurarColuna(g, "QtdEstoque", "Estoque", 0, true, null);
        }

        private static void ConfigurarColuna(DataGridView g, string nome, string titulo,
            int largura, bool direita, string formato)
        {
            if (!g.Columns.Contains(nome)) return;

            DataGridViewColumn c = g.Columns[nome];
            c.HeaderText = titulo;

            if (largura > 0)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c.Width = largura;
            }
            else if (nome == "Nome")
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            else
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (direita)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (formato != null)
                c.DefaultCellStyle.Format = formato;
        }

        // ------------------------------------------------------
        // GRID DE PRODUTOS
        // ------------------------------------------------------

        private void CarregarProdutos()
        {
            // O estoque é guardado por lote, então somamos os lotes de cada produto.
            // left join = o produto aparece mesmo que ainda não tenha lote (estoque 0).
            string sql = @"select p.IdProduto, p.Nome, p.Preco,
                                  isnull(sum(e.QuantidadeAtual), 0) as QtdEstoque
                           from GA_Produtos p
                           left join GA_Lote l on l.FKProduto = p.IdProduto
                           left join GA_Estoque e on e.FKLote = l.IdLote
                           group by p.IdProduto, p.Nome, p.Preco
                           order by p.Nome";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable tabela = new DataTable();
                    da.Fill(tabela);
                    dataGridView1.DataSource = tabela;
                    FormatarColunasProdutos();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clicou no cabeçalho

            DataRow linha = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;

            idProduto = Convert.ToInt32(linha["IdProduto"]);
            nomeProduto = linha["Nome"].ToString();

            CarregarOperacoes();
            MostrarCards();
        }

        // ------------------------------------------------------
        // BUSCA DAS OPERAÇÕES (COMPRAS E VENDAS) DO PRODUTO
        // ------------------------------------------------------

        private void CarregarOperacoes()
        {
            // Duas consultas com as MESMAS colunas, juntas com "union all":
            // a primeira traz as compras e a segunda traz as vendas do produto.
            // No fim, "order by" coloca tudo em ordem cronológica.
            string sql = @"
                -- COMPRAS (não existe cliente numa compra, por isso null)
                select 'Compra' as Tipo, c.IdCompra as IdOperacao, c.DataCompra as Data,
                       c.StatusCompra as Status, l.IdLote, f.Nome as Fornecedor,
                       fu.Nome as Funcionario, null as IdCliente,
                       i.Quantidade, i.PrecoUnitario, l.DataValidade
                from GA_ItensCompra i
                inner join GA_Compra c on c.IdCompra = i.FKCompra
                inner join GA_Lote l on l.IdLote = i.FKLote
                inner join GA_Fornecedor f on f.IdFornecedor = l.FKFornecedores
                inner join GA_Funcionarios fu on fu.IdFuncionario = c.FKFuncionario
                where l.FKProduto = @idProduto

                union all

                -- VENDAS (se o item foi cancelado sozinho, o status vira 'Cancelado')
                select 'Venda', v.IdVenda, v.DataVenda,
                       case when iv.Cancelado = 1 then 'Cancelado' else v.StatusVenda end,
                       l.IdLote, f.Nome,
                       fu.Nome, v.FKCliente,
                       iv.Quantidade, iv.PrecoUnitario, l.DataValidade
                from GA_ItensVenda iv
                inner join GA_Venda v on v.IdVenda = iv.FKVenda
                inner join GA_Lote l on l.IdLote = iv.FKLote
                inner join GA_Fornecedor f on f.IdFornecedor = l.FKFornecedores
                inner join GA_Funcionarios fu on fu.IdFuncionario = v.FKFuncionario
                where l.FKProduto = @idProduto

                order by Data, Tipo, IdOperacao";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idProduto", idProduto);

                    operacoes = new DataTable();
                    da.Fill(operacoes);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ------------------------------------------------------
        // FILTROS (não consultam o banco: só filtram o que já foi carregado)
        // ------------------------------------------------------

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCards();
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPeriodo.Text == "Dia") maskData.Mask = "00/00/0000";
            if (cbPeriodo.Text == "Mês") maskData.Mask = "00/0000";
            if (cbPeriodo.Text == "Ano") maskData.Mask = "0000";

            maskData.Clear();
            MostrarCards();
        }

        private void maskData_TextChanged(object sender, EventArgs e)
        {
            MostrarCards();
        }

        // Devolve true se a operação deve aparecer, de acordo com os dois filtros
        private bool PassaNoFiltro(DataRow linha)
        {
            string tipo = linha["Tipo"].ToString();       // "Compra" ou "Venda"
            string status = linha["Status"].ToString();
            DateTime data = Convert.ToDateTime(linha["Data"]);

            // filtro de tipo
            if (cbTipo.Text == "Compras" && tipo != "Compra") return false;
            if (cbTipo.Text == "Vendas" && tipo != "Venda") return false;
            if (cbTipo.Text == "Canceladas" && status != "Cancelado") return false;

            // filtro de data: só vale quando a data está completamente preenchida
            if (maskData.MaskCompleted)
            {
                string formato = "dd/MM/yyyy";                 // Dia
                if (cbPeriodo.Text == "Mês") formato = "MM/yyyy";
                if (cbPeriodo.Text == "Ano") formato = "yyyy";

                // compara o texto digitado com a data da operação escrita no mesmo formato
                if (data.ToString(formato) != maskData.Text) return false;
            }

            return true;
        }

        // ------------------------------------------------------
        // CARDS
        // ------------------------------------------------------

        private void LimparCards()
        {
            // Dispose remove o controle do painel e libera a memória dele
            while (flowCards.Controls.Count > 0)
                flowCards.Controls[0].Dispose();
        }

        private void MostrarMensagem(string texto)
        {
            LimparCards();
            AdicionarTexto(flowCards, texto, 0, 0, false);
        }

        private void MostrarCards()
        {
            if (operacoes == null) return; // ainda não clicaram em nenhum produto

            LimparCards();
            AdicionarTexto(flowCards, nomeProduto, 0, 0, true);

            int quantos = 0;
            foreach (DataRow linha in operacoes.Rows)
            {
                if (PassaNoFiltro(linha))
                {
                    flowCards.Controls.Add(CriarCard(linha));
                    quantos++;
                }
            }

            if (quantos == 0)
                AdicionarTexto(flowCards, "Nenhuma operação encontrada.", 0, 0, false);
        }

        private Panel CriarCard(DataRow linha)
        {
            string tipo = linha["Tipo"].ToString();   // "Compra" ou "Venda"

            Panel card = new Panel();
            card.Width = flowCards.ClientSize.Width - 25;
            card.Height = 152;
            card.BorderStyle = BorderStyle.None;
            card.BackColor = TemaModerno.Campo;

            // título
            string titulo = tipo.ToUpper() + " Nº " + linha["IdOperacao"];
            if (linha["Status"].ToString() == "Cancelado")
                titulo += " (CANCELADA)";
            AdicionarTexto(card, titulo, 8, 6, true);

            // lote e data
            AdicionarTexto(card, "Id do lote: " + linha["IdLote"], 8, 30, false);
            AdicionarTexto(card, "Data: " + Convert.ToDateTime(linha["Data"]).ToString("dd/MM/yyyy"), 205, 30, false);

            // fornecedor do lote
            AdicionarTexto(card, "Fornecedor: " + linha["Fornecedor"], 8, 54, false);

            // funcionário que registrou a operação
            AdicionarTexto(card, "Funcionário: " + linha["Funcionario"], 8, 78, false);

            // id do cliente: só existe nas vendas (e fica "-" se a venda não teve cliente)
            if (tipo == "Venda")
            {
                string cliente = "-";
                if (linha["IdCliente"] != DBNull.Value)
                    cliente = linha["IdCliente"].ToString();

                AdicionarTexto(card, "Id do cliente: " + cliente, 205, 78, false);
            }

            // quantidade (comprada ou vendida) e preço
            string palavra = "vendida";
            if (tipo == "Compra") palavra = "comprada";

            AdicionarTexto(card, "Quantidade " + palavra + ": " + linha["Quantidade"], 8, 102, false);
            AdicionarTexto(card, "Preço: " + Convert.ToDecimal(linha["PrecoUnitario"]).ToString("C2"), 205, 102, false);

            // validade do lote
            AdicionarTexto(card, "Validade: " + Convert.ToDateTime(linha["DataValidade"]).ToString("dd/MM/yyyy"), 8, 126, false);

            return card;
        }

        // Cria um Label com o texto e coloca dentro do "destino" (um card ou o próprio painel)
        private void AdicionarTexto(Control destino, string texto, int x, int y, bool negrito)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            lbl.ForeColor = TemaModerno.Texto;
            lbl.Font = TemaModerno.Fonte(9.5f, negrito ? FontStyle.Bold : FontStyle.Regular);

            destino.Controls.Add(lbl);
        }

        // ------------------------------------------------------
        // TELA DO RELATÓRIO (RDLC): mesmo visual das outras telas
        // ------------------------------------------------------

        // ------------------------------------------------------
        // Controles da tela do relatório, criados por código
        // (assim o Designer desta tela não precisa mudar)
        // ------------------------------------------------------
        private Panel pnlRelatorio;
        private Button btnImprimir;
        private Button btnVoltar;
        private ReportViewer reportViewer1;

        private void CriarControlesRelatorio()
        {
            reportViewer1 = new ReportViewer();
            btnImprimir = new Button { Name = "btnImprimir" };
            btnVoltar = new Button { Name = "btnVoltar" };
            btnImprimir.Click += btnImprimir_Click;
            btnVoltar.Click += btnVoltar_Click;

            pnlRelatorio = new Panel { Name = "pnlRelatorio", Dock = DockStyle.Fill, Visible = false };
            Controls.Add(pnlRelatorio);
        }

        private Button btnImprimirRel;   // botão "Imprimir" dentro da tela do relatório

        private void AplicarTemaRelatorio(string titulo)
        {
            pnlRelatorio.BackColor = TemaModerno.Fundo;
            pnlRelatorio.Padding = new Padding(24, 16, 24, 24);

            // barra do topo: título + botões
            var barra = new Panel { Dock = DockStyle.Top, Height = 84, BackColor = TemaModerno.Fundo };
            barra.Controls.Add(NovoRotulo(titulo, 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(0, 6)));
            barra.Controls.Add(NovoRotulo("Pr\u00E9-visualiza\u00E7\u00E3o  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(2, 52)));

            var botoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 300,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = TemaModerno.Fundo
            };
            barra.Controls.Add(botoes);

            btnImprimirRel = new Button { Text = "Imprimir", Size = new Size(140, 44), Margin = new Padding(8, 18, 0, 0) };
            TemaModerno.Botao(btnImprimirRel, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            btnImprimirRel.Click += (s, e) => reportViewer1.PrintDialog();

            // o "Voltar" do designer era uma barra branca no topo: vira um botão igual aos outros
            btnVoltar.Dock = DockStyle.None;
            btnVoltar.Text = "Voltar";
            btnVoltar.Size = new Size(120, 44);
            btnVoltar.Margin = new Padding(8, 18, 0, 0);
            TemaModerno.Botao(btnVoltar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);

            botoes.Controls.Add(btnImprimirRel);
            botoes.Controls.Add(btnVoltar);
            PadraoTela.CentralizarTexto(btnImprimirRel, btnVoltar);

            // o relatório fica dentro de um cartão
            var cartao = new Panel { Dock = DockStyle.Fill, Padding = new Padding(2) };
            TemaModerno.Cartao(cartao);
            reportViewer1.Dock = DockStyle.Fill;
            cartao.Controls.Add(reportViewer1);

            pnlRelatorio.Controls.Add(cartao);   // Fill primeiro...
            pnlRelatorio.Controls.Add(barra);    // ...Top depois (docka antes)
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlRelatorio.Visible = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // o relatório usa a mesma tabela que está na tela
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Não há produtos para imprimir.");
                    return;
                }

                pnlRelatorio.Visible = true;
                pnlRelatorio.BringToFront();
                RelatorioRdlc.Mostrar(reportViewer1, "rptEstoque.rdlc", "Estoque", dt, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar o relatório: " + ex.Message);
            }
        }
    }
}