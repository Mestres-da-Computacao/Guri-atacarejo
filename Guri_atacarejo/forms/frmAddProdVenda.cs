using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmAddProdVenda : Form
    {
        public frmPainel painel;

        public frmAddProdVenda(frmPainel Form)
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            painel = Form;

            // Conectar os eventos de teclado
            txtID.KeyPress += txtID_KeyPress;
            txtLote.KeyPress += txtLote_KeyPress;
            txtQuantidade.KeyPress += txtQuantidade_KeyPress;
        }

        // Aceitar somente números no campo ID
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Aceitar somente números no campo Lote
        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Aceitar somente números no campo Quantidade
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Adicionar produto à venda
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int id;
            int lote;
            int quantidade;

            // Validar os campos
            if (!int.TryParse(txtID.Text, out id) ||
                !int.TryParse(txtLote.Text, out lote) ||
                !int.TryParse(txtQuantidade.Text, out quantidade) ||
                id <= 0 || lote <= 0 || quantidade <= 0)
            {
                MessageBox.Show(
                    "Informe IDs válidos e uma quantidade maior que zero.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (painel == null)
            {
                MessageBox.Show("O formulário principal não foi inicializado.");
                return;
            }

            try
            {
                DataSet.DataTable1DataTable produtoLote;

                // Consultar produto e lote no banco de dados
                using (var adapter = new DataSetTableAdapters.DataTable1TableAdapter())
                {
                    produtoLote = adapter.GetProdutoOuLote(lote, id);
                }

                // Verificar se encontrou o produto
                if (produtoLote == null || produtoLote.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Produto ou lote não encontrado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Recuperar os dados do produto
                DataSet.DataTable1Row produto = produtoLote[0];

                int idProduto = produto.FKProduto;
                string nome = produto.Nome;
                decimal preco = produto.Preco;

                string erro;

                // Tentar adicionar o produto à venda
                bool sucesso = painel.TentarAdicionarProduto(
                    idProduto,
                    nome,
                    preco,
                    quantidade,
                    lote,
                    out erro
                );

                if (!sucesso)
                {
                    MessageBox.Show(
                        erro,
                        "Não foi possível adicionar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Produto adicionado à venda com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpar os campos após adicionar
                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Erro ao consultar o banco de dados:\n" + ex.Message,
                    "Erro SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao adicionar produto:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Limpar os campos
        // Limpar os campos
        private void clear()
        {
            txtID.Text = "";
            txtLote.Text = "";
            txtQuantidade.Text = "";

            txtID.Focus();
        }

        // Retornar ao formulário anterior
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}