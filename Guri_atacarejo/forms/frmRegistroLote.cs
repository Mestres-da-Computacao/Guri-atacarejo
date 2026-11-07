using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistroLote : Icone
    {
        // ATENCAO: troque "campoData1" pelo nome real do controle CampoData
        // no designer (clique nele e veja a propriedade (Name)).
        // Ele substitui o antigo dateTimePicker1.

        public frmRegistroLote()
        {
            InitializeComponent();
            button2.Click += button2_Click;

            ResponsividadeForm.Aplicar(this);

            // Configuração do campo de custo
            // Increment e ThousandsSeparator removidos: CampoNumero nao tem essas propriedades.
            // (Se quiser, veja o final da resposta para expor na classe.)
            nupdDinheiro.DecimalPlaces = 2;
            nupdDinheiro.Minimum = 0;
            nupdDinheiro.Maximum = 99999999.99M;

            button1.Click += button1_Click;
            Load += frmRegistroLote_Load;
        }

        private void frmRegistroLote_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombo(comboBoxFornecedores,
                    "SELECT IdFornecedor, Nome FROM GA_Fornecedor ORDER BY Nome",
                    "IdFornecedor");

                CarregarCombo(ComboBoxProduto,
                    "SELECT IdProduto, Nome FROM GA_Produtos ORDER BY Nome",
                    "IdProduto");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        // Parametro trocado de ComboBox para CampoCombo (era o erro CS1503)
        private void CarregarCombo(CampoCombo combo, string sql, string colunaId)
        {
            var tabela = new DataTable();

            using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(tabela);
            }

            combo.DisplayMember = "Nome";
            combo.ValueMember = colunaId;
            combo.DataSource = tabela;
            combo.SelectedIndex = -1; // começa sem nada selecionado
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxFornecedores.SelectedValue == null)
            {
                MessageBox.Show("Selecione o fornecedor.");
                comboBoxFornecedores.Focus();
                return;
            }
            if (ComboBoxProduto.SelectedValue == null)
            {
                MessageBox.Show("Selecione o produto.");
                ComboBoxProduto.Focus();
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
            if (campoData1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("A data de validade não pode ser anterior a hoje.");
                return;
            }

            const string sql = @"
                INSERT INTO GA_Lote (FKFornecedores, FKProduto, Quantidade, DataValidade, [Preço])
                VALUES (@forn, @prod, @qtd, @validade, @preco);";

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@forn", SqlDbType.Int).Value = Convert.ToInt32(comboBoxFornecedores.SelectedValue);
                    cmd.Parameters.Add("@prod", SqlDbType.Int).Value = Convert.ToInt32(ComboBoxProduto.SelectedValue);
                    cmd.Parameters.Add("@qtd", SqlDbType.Int).Value = (int)numericUpDown1.Value;
                    cmd.Parameters.Add("@validade", SqlDbType.Date).Value = campoData1.Value.Date;

                    var pPreco = cmd.Parameters.Add("@preco", SqlDbType.Decimal);
                    pPreco.Precision = 10;
                    pPreco.Scale = 2;
                    pPreco.Value = nupdDinheiro.Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
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
            comboBoxFornecedores.SelectedIndex = -1;
            ComboBoxProduto.SelectedIndex = -1;
            numericUpDown1.Value = 1;
            nupdDinheiro.Value = 0;
            campoData1.Value = DateTime.Today;
            comboBoxFornecedores.Focus();
        }
    }
}