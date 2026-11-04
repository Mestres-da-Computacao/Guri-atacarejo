using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmexibcaoentidades : Icone
    {
        string tipo = "";
        private readonly string _connectionString =
            Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        private DataTable _dadosEntidade;

        public frmexibcaoentidades()
        {
            InitializeComponent();

            AplicarTema(); // visual igual ao do frmPainel (TemaModerno)
            ResponsividadeForm.Aplicar(this);

            cbcar.SelectedIndexChanged += cbcar_SelectedIndexChanged;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            cbent.SelectedIndex = 0;
        }

        private void cbent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbcar.Items.Clear();

            switch (cbent.SelectedIndex)
            {
                case 0:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdFuncionario", "FKCargo", "FKDepartamento",
                        "Nome", "CPF", "DataNascimento", "Genero", "Telefone",
                        "Email", "DataEmissao", "Salario", "StatusFuncionamento"
                    });
                    break;

                case 1:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdProduto", "FKCategoria",
                        "Nome", "UnidadeMedida", "Preco"
                    });
                    break;

                case 2:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdFornecedor", "Nome", "CNPJ",
                        "Email", "Telefone", "Endereco"
                    });
                    break;

                case 3:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdCliente", "Nome", "CPF", "Genero",
                        "Email", "Celular", "NivelFidelidade",
                        "TotalComprasAcumuladas"
                    });
                    break;

                default:
                    _dadosEntidade = null;
                    dataGridView1.DataSource = null;
                    return;
            }

            tipo = cbent.SelectedItem.ToString();

            cbcar.SelectedIndex = 0;
            CarregarEntidade();
        }

        private void cbcar_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarColunasVisiveis();
        }

        private void CarregarEntidade()
        {
            string consulta;

            switch (cbent.SelectedIndex)
            {
                case 0:
                    consulta = "SELECT IdFuncionario, FKCargo, FKDepartamento, Nome, CPF, " +
                               "DataNascimento, Genero, Telefone, Email, DataEmissao, " +
                               "Salario, StatusFuncionamento FROM GA_Funcionarios " +
                               "ORDER BY Nome";
                    break;

                case 1:
                    consulta = "SELECT IdProduto, FKCategoria, Nome, " +
                               "UnidadeMedida, Preco FROM GA_Produtos ORDER BY Nome";
                    break;

                case 2:
                    consulta = "SELECT IdFornecedor, Nome, CNPJ, Email, Telefone, " +
                               "Endereco FROM GA_Fornecedor ORDER BY Nome";
                    break;

                case 3:
                    consulta = "SELECT IdCliente, Nome, CPF, Genero, Email, Celular, " +
                               "NivelFidelidade, TotalComprasAcumuladas " +
                               "FROM GA_Clientes ORDER BY Nome";
                    break;

                default:
                    _dadosEntidade = null;
                    dataGridView1.DataSource = null;
                    return;
            }

            var dados = new DataTable();

            try
            {
                using (var conexao = new SqlConnection(_connectionString))
                using (var adaptador = new SqlDataAdapter(consulta, conexao))
                {
                    adaptador.Fill(dados);
                }
            }
            catch (SqlException ex)
            {
                _dadosEntidade = null;
                dataGridView1.DataSource = null;

                MessageBox.Show(
                    "Não foi possível carregar os dados: " + ex.Message,
                    "Erro ao carregar dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _dadosEntidade = dados;
            dataGridView1.DataSource = _dadosEntidade;

            AtualizarColunasVisiveis();
        }

        private void AtualizarColunasVisiveis()
        {
            if (_dadosEntidade == null || dataGridView1.Columns.Count == 0)
            {
                return;
            }

            string atributoSelecionado = cbcar.SelectedItem as string;
            bool mostrarTudo = cbcar.SelectedIndex <= 0;

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                coluna.Visible = mostrarTudo ||
                                 coluna.DataPropertyName == atributoSelecionado ||
                                 coluna.Name == atributoSelecionado;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = e.RowIndex >= 0 && e.ColumnIndex >= 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataRowView linha = dataGridView1.CurrentRow == null
                ? null
                : dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (linha == null) return;

            using (frmEditEntidade editar = new frmEditEntidade(tipo, linha.Row))
            {
                // OK = editou ou excluiu, então recarrega o grid
                if (editar.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarEntidade();
                    btnEditar.Enabled = false;
                }
            }
        }

        // ------------------------------------------------------------------
        // Visual igual ao do frmPainel: fundo claro, cartões arredondados,
        // botões e tabela do TemaModerno. Os controles do designer são só reorganizados.
        // ------------------------------------------------------------------
        private void AplicarTema()
        {
            SuspendLayout();

            ClientSize = new Size(900, 560);
            BackColor = TemaModerno.Fundo;
            Text = "Entidades";
            menuStrip1.Visible = false;   // não tem itens
            pictureBox1.Visible = false;  // a imagem laranja não combina com o tema

            const int m = 24;
            int largura = ClientSize.Width - 2 * m;
            int acoesH = 72;
            int acoesY = ClientSize.Height - m - acoesH;

            Panel host = new Panel();
            host.Dock = DockStyle.Fill;
            host.BackColor = TemaModerno.Fundo;

            host.Controls.Add(NovoRotulo("Entidades", 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Consulta e edi\u00E7\u00E3o  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // ---- cartão: PESQUISA (o GroupBox vira um Panel) ----
            Panel pesquisa = TemaModerno.GroupBoxParaPainel(Pesquisa, TemaModerno.Card);
            pesquisa.Bounds = new Rectangle(m, 96, largura, acoesY - 16 - 96);
            TemaModerno.Cartao(pesquisa);

            pesquisa.Controls.Add(NovoRotulo("Pesquisa", 12f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Card, new Point(20, 14)));

            Estilizar(label1, new Point(20, 58));
            TemaModerno.Combo(cbent);
            cbent.Location = new Point(110, 54);
            cbent.Width = 200;

            Estilizar(label2, new Point(340, 58));
            TemaModerno.Combo(cbcar);
            cbcar.Location = new Point(410, 54);
            cbcar.Width = 220;

            pesquisa.Controls.Add(dataGridView1);
            dataGridView1.Location = new Point(1, 100);
            dataGridView1.Size = new Size(pesquisa.Width - 2, pesquisa.Height - 101);
            TemaModerno.Grid(dataGridView1);
            host.Controls.Add(pesquisa);

            // ---- cartão: AÇÕES ----
            Panel acoes = new Panel();
            acoes.Bounds = new Rectangle(m, acoesY, largura, acoesH);
            TemaModerno.Cartao(acoes);
            acoes.Controls.Add(NovoRotulo("A\u00C7\u00D5ES", 9.5f, FontStyle.Bold,
                TemaModerno.Verde4, TemaModerno.Card, new Point(20, 10)));

            TemaModerno.Botao(btnEditar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            btnEditar.Bounds = new Rectangle(20, 30, 150, 34);
            TemaModerno.Botao(btnVoltar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            btnVoltar.Bounds = new Rectangle(182, 30, 150, 34);
            acoes.Controls.Add(btnEditar);
            acoes.Controls.Add(btnVoltar);
            host.Controls.Add(acoes);

            Controls.Add(host);
            host.BringToFront();
            ResumeLayout(true);
        }

        private static Label NovoRotulo(string texto, float tamanho, FontStyle estilo,
            Color cor, Color fundo, Point local)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.Text = texto;
            l.Font = TemaModerno.Fonte(tamanho, estilo);
            l.ForeColor = cor;
            l.BackColor = fundo;
            l.Location = local;
            return l;
        }

        // rótulo do designer ("Pesquisar:", "O Que:") com o estilo dos cartões
        private static void Estilizar(Label l, Point local)
        {
            l.Font = TemaModerno.Fonte(10f);
            l.ForeColor = TemaModerno.TextoSuave;
            l.BackColor = TemaModerno.Card;
            l.Location = local;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}