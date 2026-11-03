using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmexibcaoentidades : Form
    {
        private readonly string _connectionString =
            Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        private DataTable _dadosEntidade;

        public frmexibcaoentidades()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            cbcar.SelectedIndexChanged += cbcar_SelectedIndexChanged;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

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
                        "Tudo", "IdFuncionario", "FKCargo", "FKDepartamento", "Nome",
                        "CPF", "DataNascimento", "Genero", "Telefone", "Email",
                        "DataEmissao", "Salario", "StatusFuncionamento"
                    });
                    break;
                case 1:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdProduto", "FKFornecedor", "FKCategoria",
                        "Nome", "UnidadeMedida", "Preco"
                    });
                    break;
                case 2:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdFornecedor", "Nome", "CNPJ", "Email",
                        "Telefone", "Endereco"
                    });
                    break;
                case 3:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdCliente", "Nome", "CPF", "Genero", "Email",
                        "Celular", "NivelFidelidade", "TotalComprasAcumuladas"
                    });
                    break;
                default:
                    _dadosEntidade = null;
                    dataGridView1.DataSource = null;
                    return;
            }

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
                    consulta = "SELECT IdProduto, FKFornecedor, FKCategoria, Nome, " +
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
    }
}
