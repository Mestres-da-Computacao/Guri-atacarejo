using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Guri_atacarejo.forms
{
    public partial class frmAddProdVenda : Form
    {
        public frmPainel painel;

        public frmAddProdVenda(frmPainel Form) // p usar os ngc de frmPainel
        {
            InitializeComponent();
            painel = Form;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id) ||
                !int.TryParse(txtLote.Text, out int lote) ||
                !int.TryParse(txtQuantidade.Text, out int quantidade) ||
                id <= 0 || lote <= 0 || quantidade <= 0)
            {
                MessageBox.Show("Informe IDs válidos e uma quantidade maior que zero.");
                return;
            }

            string sql =
                "SELECT L.FKProduto, P.Nome, P.Preco " +
                "FROM GA_Lote L " +
                "INNER JOIN GA_Produtos P ON L.FKProduto = P.IdProduto " +
                "WHERE L.IdLote = @lote AND L.FKProduto = @id";

            try
            {
                using (var conn = new SqlConnection(
                    "Server=(localdb)\\MSSQLLocalDB;Database=db_250405;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;"))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@lote", SqlDbType.Int).Value = lote;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Produto ou lote não encontrado.");
                            return;
                        }

                        int idProduto = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        decimal preco = reader.GetDecimal(2);

                        if (!painel.TentarAdicionarProduto(
                            idProduto, nome, preco, quantidade, lote, out string erro))
                        {
                            MessageBox.Show(erro);
                            return;
                        }
                    }
                }

                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível consultar o produto ou o estoque: " + ex.Message);
            }
        }

        private void clear()
        {
            txtID.Clear();
            txtLote.Clear();
            txtQuantidade.Clear();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
