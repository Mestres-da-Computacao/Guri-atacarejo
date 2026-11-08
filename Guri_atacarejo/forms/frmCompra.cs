using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmCompra_ : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(System.Drawing.Color fundo, System.Drawing.Color texto)
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

            // Barra do form com a mesma cor do fundo; texto branco (ou preto se o fundo for claro)
            System.Drawing.Color fundo = BackColor;
            bool escuro = fundo.GetBrightness() < 0.6f;
            DefinirCorBarra(fundo, escuro ? System.Drawing.Color.White : System.Drawing.Color.Black);
        }

        private const int MESES_VALIDADE = 10;
        private readonly string _connectionString =
            Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        private ItemCompra[] _itens = new ItemCompra[0];
        private DataTable _fornecedores = CriarTabelaFornecedoresVazia();
        private ItemCompra _itemSelecionado;
        private Label _lblInfoProduto;
        private Label _lblInfoFornecedor;

        public frmCompra_()
        {
            InitializeComponent();
            btnConfirmar.Click += btnConfirmar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnregforn.Click += btnregforn_Click;
            btnreglote.Click += btnreglote_Click;
            ResponsividadeForm.Aplicar(this);

            this.Text = "Compra de lotes";
        }

        private void frmCompra__Load(object sender, EventArgs e)
        {
            // os cards acompanham a largura do painel (ex.: ao maximizar a janela)
            flowLayoutPanel1.ClientSizeChanged += (s, a) => AjustarLarguraCards();

            CriarPainelInformacoes();
            CarregarFornecedores();
            CarregarCards();
            AtualizarTotal();
        }

        // largura do card = área útil do painel menos as margens (10 + 10) do card
        private int LarguraCard()
        {
            return Math.Max(480, flowLayoutPanel1.ClientSize.Width - 20);
        }

        private void AjustarLarguraCards()
        {
            flowLayoutPanel1.SuspendLayout();
            int largura = LarguraCard();
            foreach (Control card in flowLayoutPanel1.Controls)
            {
                card.Width = largura;
            }
            flowLayoutPanel1.ResumeLayout();
        }

        private void CriarPainelInformacoes()
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.AutoScroll = true;

            _lblInfoProduto = CriarLabelInformacao(
                "Clique em um produto para ver as informações dele.");
            _lblInfoFornecedor = CriarLabelInformacao("selecione um fornecedor");
            flowLayoutPanel2.Controls.Add(_lblInfoProduto);
            flowLayoutPanel2.Controls.Add(_lblInfoFornecedor);
        }

        private static Label CriarLabelInformacao(string texto)
        {
            return new Label
            {
                AutoSize = true,
                MaximumSize = new Size(315, 0),
                Margin = new Padding(5),
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Text = texto
            };
        }

        private void CarregarFornecedores()
        {
            var fornecedores = new DataTable();

            // Carrega os dados uma vez; cada card terá sua própria seleção.
            try
            {
                using (var conexao = new SqlConnection(_connectionString))
                using (var adapter = new SqlDataAdapter(
                    "SELECT IdFornecedor, Nome, CNPJ, Email, Telefone, Endereco " +
                    "FROM GA_Fornecedor ORDER BY Nome",
                    conexao))
                {
                    adapter.Fill(fornecedores);
                }
            }
            catch (SqlException ex)
            {
                _fornecedores = CriarTabelaFornecedoresVazia();
                MessageBox.Show(
                    "Não foi possível carregar os fornecedores: " + ex.Message,
                    "Erro ao carregar fornecedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _fornecedores = fornecedores;
        }

        private static DataTable CriarTabelaFornecedoresVazia()
        {
            var tabela = new DataTable();
            tabela.Columns.Add("IdFornecedor", typeof(int));
            tabela.Columns.Add("Nome", typeof(string));
            tabela.Columns.Add("CNPJ", typeof(string));
            tabela.Columns.Add("Email", typeof(string));
            tabela.Columns.Add("Telefone", typeof(string));
            tabela.Columns.Add("Endereco", typeof(string));
            return tabela;
        }

        private void PreencherCombo(ComboBox combo)
        {
            // Uma DataView por combo evita que selecionar um fornecedor altere os outros.
            combo.DataSource = new DataView(_fornecedores);
            combo.DisplayMember = "Nome";
            combo.ValueMember = "IdFornecedor";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void CarregarCards()
        {
            var produtos = new DataTable();

            try
            {
                using (var conexao = new SqlConnection(_connectionString))
                using (var adapter = new SqlDataAdapter(
                    "SELECT p.IdProduto, p.Nome, p.UnidadeMedida, p.Preco, " +
                    "c.Nome AS Categoria " +
                    "FROM GA_Produtos p " +
                    "INNER JOIN GA_Categoria c ON c.IdCategoria = p.FKCategoria " +
                    "ORDER BY p.Nome",
                    conexao))
                {
                    adapter.Fill(produtos);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar os produtos: " + ex.Message,
                    "Erro ao carregar produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            _itens = new ItemCompra[produtos.Rows.Count];
            _itemSelecionado = null;

            for (int i = 0; i < produtos.Rows.Count; i++)
            {
                DataRow linha = produtos.Rows[i];
                var item = new ItemCompra
                {
                    IdProduto = Convert.ToInt32(linha["IdProduto"]),
                    Nome = Convert.ToString(linha["Nome"]),
                    UnidadeMedida = Convert.ToString(linha["UnidadeMedida"]),
                    Categoria = Convert.ToString(linha["Categoria"]),
                    PrecoVenda = Convert.ToDecimal(linha["Preco"])
                };
                var card = CriarCard(item);
                flowLayoutPanel1.Controls.Add(card);
                _itens[i] = item;
            }

            flowLayoutPanel1.ResumeLayout();
            AjustarLarguraCards();

            if (produtos.Rows.Count == 0)
            {
                _lblInfoProduto.Text = "Nenhum produto cadastrado.";
            }
        }

        private Panel CriarCard(ItemCompra item)
        {
            // Cada card guarda os controles usados para calcular e registrar esse produto.
            var card = new Panel
            {
                Size = new Size(LarguraCard(), 120),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            var lblNome = new Label
            {
                Text = item.Nome,
                Location = new Point(10, 10),
                Size = new Size(280, 30),
                AutoEllipsis = true,
                ForeColor = Color.Black,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            var lblPreco = CriarLabelCampo("Preço:", new Point(300, 14));
            var lblQuantidade = CriarLabelCampo("Quantidade:", new Point(10, 72));
            var lblValidade = CriarLabelCampo("Validade:", new Point(200, 72));
            var lblFornecedor = CriarLabelCampo("Fornecedor:", new Point(430, 72));

            var nudPreco = new NumericUpDown
            {
                Location = new Point(420, 10),
                Size = new Size(110, 28),
                DecimalPlaces = 2,
                Increment = 0.5M,
                Minimum = 0,
                Maximum = 999999,
                ForeColor = Color.Black,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            var nudQuantidade = new NumericUpDown
            {
                Location = new Point(110, 68),
                Size = new Size(70, 28),
                Minimum = 0,
                Maximum = 9999,
                ForeColor = Color.Black,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            var dtpValidade = new DateTimePicker
            {
                Location = new Point(280, 68),
                Size = new Size(130, 28),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today,
                Value = DateTime.Today.AddMonths(MESES_VALIDADE),
                ForeColor = Color.Black,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            var cmbFornecedor = new ComboBox
            {
                Location = new Point(535, 68),
                Size = new Size(215, 28),
                ForeColor = Color.Black,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            PreencherCombo(cmbFornecedor);

            item.NudPreco = nudPreco;
            item.NudQuantidade = nudQuantidade;
            item.DtpValidade = dtpValidade;
            item.CmbFornecedor = cmbFornecedor;
            cmbFornecedor.Enabled = false;

            nudPreco.ValueChanged += (sender, args) => AtualizarItem(item);
            nudQuantidade.ValueChanged += (sender, args) => AtualizarItem(item);
            dtpValidade.ValueChanged += (sender, args) => AtualizarItem(item);
            cmbFornecedor.SelectedIndexChanged += (sender, args) => AtualizarItem(item);

            card.Click += (sender, args) => SelecionarItem(item);
            lblNome.Click += (sender, args) => SelecionarItem(item);
            lblPreco.Click += (sender, args) => SelecionarItem(item);
            lblQuantidade.Click += (sender, args) => SelecionarItem(item);
            lblValidade.Click += (sender, args) => SelecionarItem(item);
            lblFornecedor.Click += (sender, args) => SelecionarItem(item);
            nudPreco.Click += (sender, args) => SelecionarItem(item);
            nudQuantidade.Click += (sender, args) => SelecionarItem(item);
            dtpValidade.Click += (sender, args) => SelecionarItem(item);
            cmbFornecedor.Click += (sender, args) => SelecionarItem(item);

            card.Controls.Add(lblNome);
            card.Controls.Add(lblPreco);
            card.Controls.Add(nudPreco);
            card.Controls.Add(lblQuantidade);
            card.Controls.Add(nudQuantidade);
            card.Controls.Add(lblValidade);
            card.Controls.Add(dtpValidade);
            card.Controls.Add(lblFornecedor);
            card.Controls.Add(cmbFornecedor);

            // Reorganiza os campos de acordo com a largura atual do card.
            Action organizar = () =>
            {
                int w = card.ClientSize.Width;
                const int margem = 14;

                // linha de cima: nome à esquerda, preço colado na direita
                nudPreco.Location = new Point(w - margem - nudPreco.Width, 12);
                lblPreco.Location = new Point(nudPreco.Left - 10 - lblPreco.Width, 16);
                lblNome.Location = new Point(margem, 12);
                lblNome.Width = Math.Max(80, lblPreco.Left - 20 - margem);

                // linha de baixo: campos em sequência; o fornecedor ocupa o que sobrar
                int y = 70;
                lblQuantidade.Location = new Point(margem, y + 4);
                nudQuantidade.Location = new Point(lblQuantidade.Right + 6, y);
                lblValidade.Location = new Point(nudQuantidade.Right + 28, y + 4);
                dtpValidade.Location = new Point(lblValidade.Right + 6, y);
                lblFornecedor.Location = new Point(dtpValidade.Right + 28, y + 4);
                cmbFornecedor.Location = new Point(lblFornecedor.Right + 6, y);
                cmbFornecedor.Width = Math.Max(120, w - margem - cmbFornecedor.Left);
            };
            card.SizeChanged += (s, a) => organizar();
            organizar();

            return card;
        }

        private static Label CriarLabelCampo(string texto, Point localizacao)
        {
            return new Label
            {
                Text = texto,
                Location = localizacao,
                AutoSize = true,
                ForeColor = Color.Black,
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
        }

        private void SelecionarItem(ItemCompra item)
        {
            _itemSelecionado = item;
            MostrarInformacoes(item);
        }

        private void MostrarInformacoes(ItemCompra item)
        {
            _lblInfoProduto.Text =
                "PRODUTO" + Environment.NewLine +
                "Id: " + item.IdProduto + Environment.NewLine +
                "Nome: " + item.Nome + Environment.NewLine +
                "Categoria: " + item.Categoria + Environment.NewLine +
                "Unidade: " + item.UnidadeMedida + Environment.NewLine +
                "Preço de venda: " + item.PrecoVenda.ToString("C2");

            if (item.IdFornecedor <= 0)
            {
                _lblInfoFornecedor.Text =
                    "FORNECEDOR" + Environment.NewLine + "selecione um fornecedor";
                return;
            }

            var fornecedor = _fornecedores.Select("IdFornecedor = " + item.IdFornecedor);
            if (fornecedor.Length == 0)
            {
                _lblInfoFornecedor.Text =
                    "FORNECEDOR" + Environment.NewLine + "selecione um fornecedor";
                return;
            }

            var dados = fornecedor[0];
            _lblInfoFornecedor.Text = "FORNECEDOR" + Environment.NewLine + "Id: " + dados["IdFornecedor"] + Environment.NewLine +
                "Nome: " + dados["Nome"] + Environment.NewLine +
                "CNPJ: " + Convert.ToString(dados["CNPJ"]) + Environment.NewLine +
                "Email: " + Convert.ToString(dados["Email"]) + Environment.NewLine +
                "Telefone: " + Convert.ToString(dados["Telefone"]) + Environment.NewLine +
                "Endereço: " + Convert.ToString(dados["Endereco"]);
        }

        private void AtualizarItem(ItemCompra item)
        {
            item.CmbFornecedor.Enabled = item.NudQuantidade.Value > 0;

            if (item == _itemSelecionado)
            {
                MostrarInformacoes(item);
            }

            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            decimal total = 0;
            var fornecedoresExibidos = new int[_itens.Length];
            int quantidadeFornecedores = 0;
            var nomesFornecedores = new StringBuilder();

            foreach (var item in _itens)
            {
                if (item.NudQuantidade == null || item.NudQuantidade.Value <= 0)
                {
                    continue;
                }

                total += item.Preco * item.NudQuantidade.Value;
                // SelectedItem contém a linha do fornecedor escolhida no combo.
                if (item.CmbFornecedor.SelectedItem is DataRowView fornecedor)
                {
                    int idFornecedor = item.IdFornecedor;
                    bool jaAdicionado = false;
                    for (int i = 0; i < quantidadeFornecedores; i++)
                    {
                        if (fornecedoresExibidos[i] == idFornecedor)
                        {
                            jaAdicionado = true;
                            break;
                        }
                    }

                    if (jaAdicionado)
                    {
                        continue;
                    }

                    fornecedoresExibidos[quantidadeFornecedores] = idFornecedor;
                    quantidadeFornecedores++;
                    string nome = Convert.ToString(fornecedor["Nome"]);
                    if (nomesFornecedores.Length > 0)
                    {
                        nomesFornecedores.Append(", ");
                    }
                    nomesFornecedores.Append(nome);
                }
            }

            txtTotal.Text = total.ToString("C2");
            txtFornecedor.Text = nomesFornecedores.ToString();
        }

        private void LimparTudo()
        {
            foreach (var item in _itens)
            {
                item.NudQuantidade.Value = 0;
                item.NudPreco.Value = 0;
                item.DtpValidade.Value = DateTime.Today.AddMonths(MESES_VALIDADE);
                item.CmbFornecedor.SelectedIndex = -1;
            }

            _itemSelecionado = null;
            _lblInfoProduto.Text = "Clique em um produto para ver as informações dele.";
            _lblInfoFornecedor.Text = "selecione um fornecedor";
            AtualizarTotal();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool temProduto = false;
            foreach (var item in _itens)
            {
                if (item.NudQuantidade.Value <= 0)
                {
                    continue;
                }

                temProduto = true;
                if (item.Preco <= 0)
                {
                    MessageBox.Show("Informe o preço do produto: " + item.Nome);
                    item.NudPreco.Focus();
                    return;
                }

                if (item.IdFornecedor <= 0)
                {
                    MessageBox.Show(
                        "Selecione um fornecedor para o produto: " + item.Nome,
                        "Fornecedor obrigatório",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    item.CmbFornecedor.Enabled = true;
                    item.CmbFornecedor.Focus();
                    SelecionarItem(item);
                    return;
                }
            }

            if (!temProduto)
            {
                MessageBox.Show("Não há produtos para comprar.");
                return;
            }

            if (Sessao.IdFuncionario <= 0)
            {
                MessageBox.Show(
                    "Entre novamente com um funcionário para registrar a compra.", "Funcionário não identificado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resposta = MessageBox.Show(
                "Total da compra: " + txtTotal.Text + "\n\nDeseja confirmar a compra?", "Confirmar compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta != DialogResult.Yes)
            {
                return;
            }

            btnConfirmar.Enabled = false;
            string erroRollback = null;

            try
            {
                using (var conexao = new SqlConnection(_connectionString))
                {
                    conexao.Open();
                    using (var transacao = conexao.BeginTransaction())
                    {
                        try
                        {
                            // A procedure registra uma compra por fornecedor.
                            // A transação externa mantém todos os grupos juntos.
                            for (int i = 0; i < _itens.Length; i++)
                            {
                                ItemCompra item = _itens[i];
                                if (item.NudQuantidade.Value <= 0)
                                {
                                    continue;
                                }

                                int idFornecedor = item.IdFornecedor;
                                bool fornecedorJaRegistrado = false;
                                for (int j = 0; j < i; j++)
                                {
                                    if (_itens[j].NudQuantidade.Value > 0 &&
                                        _itens[j].IdFornecedor == idFornecedor)
                                    {
                                        fornecedorJaRegistrado = true;
                                        break;
                                    }
                                }

                                if (fornecedorJaRegistrado)
                                {
                                    continue;
                                }

                                using (var comando = new SqlCommand(
                                    "usp_RegistrarCompra",
                                    conexao,
                                    transacao))
                                {
                                    comando.CommandType = CommandType.StoredProcedure;
                                    comando.Parameters.Add("@FKFornecedor", SqlDbType.Int).Value = idFornecedor;
                                    comando.Parameters.Add("@FKFuncionario", SqlDbType.Int).Value = Sessao.IdFuncionario;
                                    comando.Parameters.Add("@FormaPagamento", SqlDbType.VarChar, 50).Value = "Pix";
                                    comando.Parameters.Add("@DataEntrega", SqlDbType.Date).Value = DateTime.Today;
                                    comando.Parameters.Add("@ItensJson", SqlDbType.NVarChar, -1).Value = CriarItensJson(idFornecedor);
                                    comando.ExecuteNonQuery();
                                }
                            }

                            transacao.Commit();
                        }
                        catch
                        {
                            try
                            {
                                transacao.Rollback();
                            }
                            catch (SqlException erroRollbackSql)
                            {
                                erroRollback = erroRollbackSql.Message;
                            }
                            catch (InvalidOperationException erroRollbackEstado)
                            {
                                erroRollback = erroRollbackEstado.Message;
                            }

                            throw;
                        }
                    }
                }

                MessageBox.Show("Compra registrada com sucesso!");
                LimparTudo();
            }
            catch (SqlException ex)
            {
                string mensagem = "Não foi possível registrar a compra: " + ex.Message;
                if (!string.IsNullOrEmpty(erroRollback))
                {
                    mensagem += Environment.NewLine +
                        "Também não foi possível confirmar o rollback: " + erroRollback;
                }

                MessageBox.Show(mensagem, "Erro ao registrar compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConfirmar.Enabled = true;
            }
        }

        private string CriarItensJson(int idFornecedor)
        {
            // Estes nomes precisam corresponder aos campos lidos por usp_RegistrarCompra.
            var json = new StringBuilder("[");
            foreach (var item in _itens)
            {
                if (item.NudQuantidade.Value <= 0 || item.IdFornecedor != idFornecedor)
                {
                    continue;
                }

                if (json.Length > 1)
                {
                    json.Append(",");
                }

                json.Append("{\"FKProduto\":")
                    .Append(item.IdProduto.ToString(CultureInfo.InvariantCulture))
                    .Append(",\"Quantidade\":")
                    .Append(((int)item.NudQuantidade.Value).ToString(CultureInfo.InvariantCulture))
                    .Append(",\"Preco\":")
                    .Append(item.Preco.ToString(CultureInfo.InvariantCulture))
                    .Append(",\"DataValidade\":\"")
                    .Append(item.DtpValidade.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                    .Append("\"}");
            }

            return json.Append("]").ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Tem certeza que deseja cancelar?",
                "Cancelar compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                LimparTudo();

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnregforn_Click(object sender, EventArgs e)
        {
            using (var form = new frmRegistroFornecedor())
                form.ShowDialog(this);
        }

        private void btnreglote_Click(object sender, EventArgs e)
        {
            using (var form = new frmRegistroLote())
            {
                form.ShowDialog(this);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class ItemCompra
    {
        // PrecoVenda vem do cadastro; Preco é o preço de compra digitado no card.
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public string Categoria { get; set; }
        public decimal PrecoVenda { get; set; }
        public NumericUpDown NudPreco { get; set; }
        public NumericUpDown NudQuantidade { get; set; }
        public DateTimePicker DtpValidade { get; set; }
        public ComboBox CmbFornecedor { get; set; }

        public decimal Preco
        {
            get { return NudPreco.Value; }
        }

        public int IdFornecedor
        {
            get
            {
                if (CmbFornecedor.SelectedValue == null ||
                    CmbFornecedor.SelectedValue == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(CmbFornecedor.SelectedValue);
            }
        }
    }
}