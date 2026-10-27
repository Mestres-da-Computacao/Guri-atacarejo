using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistroLote : Form
    {
        string connString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperMercado;Integrated Security=True;";

        public frmRegistroLote()
        {
            InitializeComponent();
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
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("A data de validade não pode ser anterior a hoje.");
                return;
            }

            const string sql = @"
                INSERT INTO GA_Lote (FKFornecedores, FKProduto, Quantidade, DataValidade)
                SELECT f.IdFornecedor, p.IdProduto, @qtd, @validade
                FROM GA_Fornecedor f
                INNER JOIN GA_Produtos p ON p.FKFornecedor = f.IdFornecedor
                WHERE f.Nome = @forn
                  AND p.Nome = @prod;";

            try
            {
                int linhas;

                using (var conn = new SqlConnection(connString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@qtd", SqlDbType.Int).Value = (int)numericUpDown1.Value;
                    cmd.Parameters.Add("@validade", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmd.Parameters.Add("@forn", SqlDbType.VarChar, 100).Value = fornecedor;
                    cmd.Parameters.Add("@prod", SqlDbType.VarChar, 100).Value = produto;

                    conn.Open();
                    linhas = cmd.ExecuteNonQuery();
                }

                if (linhas == 0)
                {
                    MessageBox.Show(
                        "Fornecedor ou produto não encontrado.\n" +
                        "Confira os nomes digitados e se o produto pertence a esse fornecedor.");
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
            this.Close();

        }

        private void LimparCampos()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            numericUpDown1.Value = 1;
            dateTimePicker1.Value = DateTime.Today;
            textBox2.Focus();
        }
    }
}