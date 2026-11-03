using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistroLote : Form
    {
        string connString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_250405;Integrated Security=True;";

        public frmRegistroLote()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            // Configuração do campo de custo
            nupdDinheiro.DecimalPlaces = 2;
            nupdDinheiro.Minimum = 0;
            nupdDinheiro.Maximum = 99999999.99M;
            nupdDinheiro.Increment = 0.50M;
            nupdDinheiro.ThousandsSeparator = true;

            button1.Click += button1_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fornecedor = textBox2.Text.Trim();
            string produto = textBox1.Text.Trim();

            if (fornecedor.Length == 0)
            {
                MessageBox.Show("Informe o fornecedor.");
                textBox2.Focus();
                return;
            }
            if (produto.Length == 0)
            {
                MessageBox.Show("Informe o produto.");
                textBox1.Focus();
                return;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Informe uma quantidade maior que zero.");
                return;
            }
            if (nupdDinheiro.Value <= 0)
            {
                MessageBox.Show("Informe um custo maior que zero.");
                nupdDinheiro.Focus();
                return;
            }
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("A data de validade não pode ser anterior a hoje.");
                return;
            }

            // GA_Produtos não tem coluna de fornecedor; o vínculo é criado em GA_Lote.
            const string sql = @"
                INSERT INTO GA_Lote (FKFornecedores, FKProduto, Quantidade, DataValidade, [Preço])
                SELECT
                    (SELECT TOP 1 IdFornecedor FROM GA_Fornecedor WHERE Nome = @forn),
                    (SELECT TOP 1 IdProduto    FROM GA_Produtos   WHERE Nome = @prod),
                    @qtd, @validade, @preco
                WHERE EXISTS (SELECT 1 FROM GA_Fornecedor WHERE Nome = @forn)
                  AND EXISTS (SELECT 1 FROM GA_Produtos   WHERE Nome = @prod);";

            try
            {
                int linhas;

                using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@qtd", SqlDbType.Int).Value = (int)numericUpDown1.Value;
                    cmd.Parameters.Add("@validade", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmd.Parameters.Add("@forn", SqlDbType.VarChar, 100).Value = fornecedor;
                    cmd.Parameters.Add("@prod", SqlDbType.VarChar, 100).Value = produto;

                    var pPreco = cmd.Parameters.Add("@preco", SqlDbType.Decimal);
                    pPreco.Precision = 10;
                    pPreco.Scale = 2;
                    pPreco.Value = nupdDinheiro.Value;

                    conn.Open();
                    linhas = cmd.ExecuteNonQuery();
                }

                if (linhas == 0)
                {
                    MessageBox.Show(
                        "Fornecedor ou produto não encontrado.\n" +
                        "Confira os nomes digitados.");
                    return;
                }

                MessageBox.Show("Lote cadastrado com sucesso!");
                LimparCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimparCampos()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            numericUpDown1.Value = 1;
            nupdDinheiro.Value = 0;
            dateTimePicker1.Value = DateTime.Today;
            textBox2.Focus();
        }
    }
}