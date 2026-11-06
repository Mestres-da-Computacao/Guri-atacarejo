using Guri_atacarejo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Guri_atacarejo.forms
{
    public partial class frmPainel : Icone
    {
        int[] IdLotes = new int[0];
        public int qtdProd = 0; // quantidade do produto p mandar p pagina de alterar

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

        public frmPainel()
        {
            InitializeComponent();
            AplicarTemaPainel(); // visual moderno (frmPainel_Tema.cs)
            ResponsividadeForm.Aplicar(this);
            txtReciboDinheiro.TextChanged += txtReciboDinheiro_TextChanged;

            // Tabelas sem a linha vazia de "nova linha" e sem a coluna de seta
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            labelClienteRegistrado.AutoSize = false;
            labelClienteRegistrado.Size = new Size(154, 20);
            labelClienteRegistrado.AutoEllipsis = true;
            AtualizarClienteExibido("Não registrado");

            Console.WriteLine("Nível do funcionário: " + Sessao.NivelFuncionario);

            if (Sessao.NivelFuncionario <= 1)
            {
                maisOpçõesToolStripMenuItem.Visible = false;
                forneceToolStripMenuItem.Visible = false;
            }
            else if (Sessao.NivelFuncionario > 1)
            {
                maisOpçõesToolStripMenuItem.Visible = true;
                forneceToolStripMenuItem.Visible = true;
            }

            this.Text = "Painel de vendas";

            CriarBarraLateral();
        }

        private bool TentarObterEstoque(int idLote, out int estoque, out string erro)
        {
            estoque = 0;
            erro = null;

            DataSet.GA_EstoqueDataTable estoqueLote;
            using (var adapter = new DataSetTableAdapters.GA_EstoqueTableAdapter())
                estoqueLote = adapter.GetDataByLote(idLote);
            if (estoqueLote.Rows.Count == 0)
            {
                erro = "Não há estoque cadastrado para esse lote.";
                return false;
            }

            estoque = estoqueLote[0].QuantidadeAtual;
            return true;
        }

        public bool TentarAdicionarProduto(
            int id, string nome, decimal preco, int quantidade, int idLote, out string erro)
        {
            erro = null;

            if (quantidade <= 0)
            {
                erro = "A quantidade deve ser maior que zero.";
                return false;
            }

            if (IdLotes.Length != dataGridView1.Rows.Count)
            {
                erro = "Não foi possível conferir os lotes dos produtos. Cancele a venda e tente novamente.";
                return false;
            }

            int indiceExistente = -1;
            int quantidadeAtual = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];

                if (row.IsNewRow)
                    continue;

                int idLinha = Convert.ToInt32(row.Cells[0].Value);

                if (idLinha == id && IdLotes[i] == idLote)
                {
                    indiceExistente = i;
                    quantidadeAtual = Convert.ToInt32(row.Cells[2].Value);
                    break;
                }
            }

            if (!TentarObterEstoque(idLote, out int estoque, out erro))
                return false;

            int quantidadeSolicitada = quantidadeAtual + quantidade;

            if (quantidadeSolicitada > estoque)
            {
                erro = $"Estoque insuficiente. Disponível: {estoque}; ";
                return false;
            }

            if (indiceExistente >= 0)
            {
                AttQuantidade(indiceExistente, quantidadeSolicitada);
                return true;
            }

            int indice = dataGridView1.Rows.Add(
                id, nome, quantidade, preco, preco * quantidade);

            Array.Resize(ref IdLotes, dataGridView1.Rows.Count);
            IdLotes[indice] = idLote;

            AtualizarTotal();
            return true;
        }

        public bool TentarAlterarQuantidade(int linha, int quantidade, out string erro)
        {
            erro = null;

            if (linha < 0 || linha >= dataGridView1.Rows.Count ||
                linha >= IdLotes.Length)
            {
                erro = "Selecione um produto válido.";
                return false;
            }

            if (quantidade < 0)
            {
                erro = "A quantidade não pode ser negativa.";
                return false;
            }

            if (quantidade == 0)
            {
                removerProd(linha);
                return true;
            }

            int idLote = IdLotes[linha];

            if (!TentarObterEstoque(idLote, out int estoque, out erro))
                return false;

            if (quantidade > estoque)
            {
                erro = $"Estoque insuficiente para esse lote. Disponível: {estoque}.";
                return false;
            }

            AttQuantidade(linha, quantidade);
            return true;
        }

        private void AttQuantidade(int linha, int quantidade)
        {
            dataGridView1.Rows[linha].Cells[2].Value = quantidade;

            decimal preco = Convert.ToDecimal(dataGridView1.Rows[linha].Cells[3].Value);
            dataGridView1.Rows[linha].Cells[4].Value = preco * quantidade;

            AtualizarTotal();
        }

        // limpa quando um produto é removido
        private void LimparDetalhes()
        {
            dataGridView2.Rows.Clear();
        }

        public void removerProd(int linha)
        {
            dataGridView1.Rows.RemoveAt(linha);

            // remove o lote da mesma posição da linha removida
            var lista = IdLotes.ToList();
            lista.RemoveAt(linha);
            IdLotes = lista.ToArray();

            LimparDetalhes();
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            decimal total = CalcularTotal();
            lblTotal.Text = total.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

            if (cbPag.SelectedIndex == 0)
                AtualizarTroco();
        }

        private decimal CalcularTotal()
        {
            decimal total = 0m;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells[4].Value, CultureInfo.CurrentCulture);
                }
            }

            return total;
        }

        private bool TentarObterValorRecebido(out decimal recebido)
        {
            string valor = txtReciboDinheiro.Text.Trim().Replace('.', ',');
            return decimal.TryParse(
                    valor,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out recebido)
                && recebido >= 0m;
        }

        private void AtualizarTroco()
        {
            if (!TentarObterValorRecebido(out decimal recebido))
            {
                labelTroco.Text = "R$ 0,00";
                return;
            }

            decimal troco = recebido - CalcularTotal();
            labelTroco.Text = troco >= 0m
                ? troco.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                : "Insuficiente";
        }

        private void AtualizarClienteExibido(string nomeCliente)
        {
            labelClienteRegistrado.Text = string.IsNullOrWhiteSpace(nomeCliente)
                ? "Não registrado"
                : nomeCliente;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAddProdVenda Adicionar = new frmAddProdVenda(this);
            Adicionar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Tem certeza que deseja cancelar?", "Confirmar:", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                LimparVenda();

                // clientes deslogando após finalizar venda ou cancelar venda
                AtualizarClienteExibido("Não Registrado");
                SessaoClientes.NomeCliente = null;
                SessaoClientes.Cpf = null;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // evita a excessão de clicar em alterar sem selecionar uma linha
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Selecione um produto para alterar.");
                return;
            }

            int linha = dataGridView1.CurrentCell.RowIndex;
            if (linha >= 0 && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value != null) // pega o valor de quantidade da linha da celulca focada
            {
                frmAlterarPreco Alterar = new frmAlterarPreco(this, linha);
                Alterar.ShowDialog();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            string formaPagamento = "";

            if (cbPag.SelectedItem != null)
            {
                formaPagamento = cbPag.SelectedItem.ToString();
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há produtos para finalizar a venda.");
                return;
            }

            if (cbPag.SelectedIndex < 0)
            {
                MessageBox.Show("Escolha um modo de pagamento para continuar.");
                cbPag.Focus();
                return;
            }

            if (Sessao.IdFuncionario <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário. Faça login novamente.");
                return;
            }

            if (formaPagamento == "Dinheiro")
            {
                if (!TentarObterValorRecebido(out decimal recebido))
                {
                    MessageBox.Show("Informe um valor recebido válido.");
                    txtReciboDinheiro.Focus();
                    return;
                }

                if (recebido < CalcularTotal())
                {
                    MessageBox.Show("O valor recebido é menor que o total da venda.");
                    txtReciboDinheiro.Focus();
                    return;
                }

                AtualizarTroco();
            }

            btnFinalizar.Enabled = false;

            try
            {
                if (IdLotes.Length != dataGridView1.Rows.Count)
                {
                    MessageBox.Show("Os lotes não correspondem aos produtos da venda.");
                    return;
                }

                var itens = new System.Text.StringBuilder("[");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    if (row.IsNewRow)
                        continue;

                    if (!int.TryParse(
                            Convert.ToString(row.Cells[2].Value),
                            out int quantidade) ||
                        quantidade <= 0)
                    {
                        MessageBox.Show("Há uma quantidade inválida no carrinho.");
                        return;
                    }

                    int lote = IdLotes[i];

                    if (lote <= 0)
                    {
                        MessageBox.Show("Há um lote inválido no carrinho.");
                        return;
                    }

                    if (!TentarObterEstoque(lote, out int estoque, out string erro))
                    {
                        MessageBox.Show(erro);
                        return;
                    }

                    if (quantidade > estoque)
                    {
                        MessageBox.Show(
                            $"Estoque insuficiente para o lote {lote}. Disponível: {estoque}.");
                        return;
                    }

                    if (itens.Length > 1)
                        itens.Append(",");

                    itens.Append("{\"FKLote\":")
                         .Append(lote)
                         .Append(",\"Quantidade\":")
                         .Append(quantidade)
                         .Append("}");
                }

                if (itens.Length == 1)
                {
                    MessageBox.Show("Não há produtos válidos para finalizar a venda.");
                    return;
                }

                itens.Append("]");

                DataTable resultadoVenda;
                int? idCliente = SessaoClientes.IdCliente > 0
                    ? SessaoClientes.IdCliente
                    : (int?)null;
                using (var adapter = new DataSetTableAdapters.GA_VendaTableAdapter())
                    resultadoVenda = adapter.GetResultadoVenda(idCliente, Sessao.IdFuncionario, formaPagamento, itens.ToString());
                if (resultadoVenda.Rows.Count > 0)
                {
                    string mensagem = Convert.ToString(resultadoVenda.Rows[0]["Mensagem"]);
                    MessageBox.Show(mensagem);

                    if (mensagem == "Venda realizada com sucesso!")
                    {
                        LimparVenda();

                        // clientes deslogando após finalizar venda ou cancelar venda
                        AtualizarClienteExibido("Não registrado");
                        SessaoClientes.NomeCliente = null;
                        SessaoClientes.Cpf = null;
                    }
                }
                else
                {
                    MessageBox.Show(
                        "A procedure terminou sem retornar a confirmação da venda.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível registrar a venda: " + ex.Message);
            }
            finally
            {
                btnFinalizar.Enabled = true;
            }
        }

        // usado depois de concluir a venda, para limpar as células
        private void LimparVenda()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            IdLotes = new int[0];
            AtualizarTotal();
            txtReciboDinheiro.Text = "00,00";
            labelTroco.Text = "R$ 0,00";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dataGridView1.Rows.Count ||
                e.RowIndex >= IdLotes.Length ||
                !int.TryParse(
                    Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                    out int id))
            {
                return;
            }

            try
            {
                qtdProd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                int lote = IdLotes[e.RowIndex];
                LimparDetalhes();

                DataSet.DataTable1DataTable detalhes;
                using (var adapter = new DataSetTableAdapters.DataTable1TableAdapter())
                    detalhes = adapter.GetProdutoOuLote(lote, id);

                if (detalhes.Rows.Count > 0)
                {
                    DataSet.DataTable1Row detalhe = detalhes[0];
                    dataGridView2.Rows.Add(
                        detalhe.Nome,
                        detalhe.Preco,
                        detalhe.UnidadeMedida,
                        detalhe.DataValidade.ToString("dd/MM/yyyy"));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível carregar os detalhes do produto: " + ex.Message);
            }
        }

        // quando for mergeado, esse label precisa mostrar se o cliente está registrado ou não, e se estiver, mostrar o nome dele. Se não estiver, mostrar "Não registrado"
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sessao.NivelFuncionario = 0;
            Sessao.IdFuncionario = 0;
            Sessao.Usuario = null;
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Cpf = null;
            SessaoClientes.IdCliente = 0;
            Close();
        }

        private void registrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAdicionar adicionarForm = new frmAdicionar())
                adicionarForm.ShowDialog(this);
        }

        private void registrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var compraForm = new frmCompra_())
            {
                compraForm.ShowDialog(this);
            }
        }

        private void loginClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmLoginCliente loginClienteForm = new FrmLoginCliente())
            {
                if (loginClienteForm.ShowDialog(this) == DialogResult.OK)
                    AtualizarClienteExibido(SessaoClientes.NomeCliente);
            }
        }

        private void logoutClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Cpf = null;
            SessaoClientes.IdCliente = 0;
            AtualizarClienteExibido("Não registrado");
        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistro_Cliente registroClienteForm = new frmRegistro_Cliente())
                registroClienteForm.ShowDialog(this);

            AtualizarClienteExibido(SessaoClientes.NomeCliente);
        }

        private void relatórioFinanceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelatorioCompra relaCompra = new frmRelatorioCompra())
                relaCompra.ShowDialog(this);
        }

        private void relatórioDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelatorioEstoque relaEstoque = new frmRelatorioEstoque())
                relaEstoque.ShowDialog(this);
        }

        private void registrarProdutosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmCadastroProduto cadastroProdutoForm = new frmCadastroProduto())
                cadastroProdutoForm.ShowDialog(this);
        }

        private void registrarFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCadastroFuncionario cadastroFuncionarioForm = new frmCadastroFuncionario())
                cadastroFuncionarioForm.ShowDialog(this);
        }

        private void lotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroLote registroLoteForm = new frmRegistroLote())
                registroLoteForm.ShowDialog(this);
        }

        private void relatórioMovimentaçãoFinanceiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelatorioCompra relCompra = new frmRelatorioCompra())
                relCompra.ShowDialog(this);
        }

        private void relatórioFluxoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelatorioEstoque relEstoque = new frmRelatorioEstoque())
                relEstoque.ShowDialog(this);
        }

        private void registoDeLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroLote registroLoteForm = new frmRegistroLote())
                registroLoteForm.ShowDialog(this);
        }

        private void registrarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistroFornecedor registroFornecedorForm = new frmRegistroFornecedor())
                registroFornecedorForm.ShowDialog(this);
        }

        private void compraDeLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCompra_ compraForm = new frmCompra_())
                compraForm.ShowDialog(this);
        }

        private void cbPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPag.SelectedIndex == 0)
            {
                TrocoContainer.Visible = true;
                labelTroco.Visible = true;
                txtReciboDinheiro.Visible = true;
                lblRS.Visible = true;
                AtualizarTroco();
            }
            else
            {
                TrocoContainer.Visible = false;
                labelTroco.Visible = false;
                txtReciboDinheiro.Visible = false;
                lblRS.Visible = false;
                labelTroco.Text = "R$ 0,00";
            }
        }
        private void txtReciboDinheiro_Enter(object sender, EventArgs e)
        {
            if (txtReciboDinheiro.Text == "00,00" || txtReciboDinheiro.Text == "0,00")
            {
                txtReciboDinheiro.Text = "";
            }

        }

        private void txtReciboDinheiro_Leave(object sender, EventArgs e)
        {
            if (txtReciboDinheiro.Text == "")
            {
                txtReciboDinheiro.Text = "0,00";
            }

            AtualizarTroco();
        }

        private void txtReciboDinheiro_TextChanged(object sender, EventArgs e)
        {
            if (cbPag.SelectedIndex == 0)
                AtualizarTroco();
        }

        private void txtReciboDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AtualizarTroco();
                this.ActiveControl = null;
                return;
            }

            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = txtReciboDinheiro.Text.Contains(',')
                    || txtReciboDinheiro.Text.Contains('.');
                return;
            }

            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void funcProdFornToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmexibcaoentidades frmexibcaoentidades = new frmexibcaoentidades())
                frmexibcaoentidades.ShowDialog(this);
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {

        }

        #region Visual moderno (cartões, barra lateral)
        // Antes ficava em frmPainel_Tema.cs.
        // AplicarTemaPainel() e CriarBarraLateral() são chamados no construtor.

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

        #endregion
    }
}