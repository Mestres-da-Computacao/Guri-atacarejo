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
        // contsrutor
        public frmAddProdVenda(frmPainel Form) // p usar os ngc de frmPainel
        {
            InitializeComponent();
            painel = Form;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // processo de selecionar produto por id e lote

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SuperMercado;Trusted_Connection=True;TrustServerCertificate=True;";

            int id = int.Parse(txtID.Text);
            int lote = int.Parse(txtLote.Text);

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("select L.FKProduto, P.Nome, P.Preco from GA_Lote L inner join GA_Produtos P on L.FKProduto = P.IdProduto WHERE L.IdLote = @lote AND L.FKProduto = @id", conn))
            {

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@lote", lote);

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idProd = reader.GetInt32(0);
                        string Nome = reader.GetString(1);
                        decimal Valor = reader.GetDecimal(2);
                        int qtd = int.Parse(txtQuantidade.Text);
                        int loteId = int.Parse(txtLote.Text);

                        painel.AtualizarProduto(idProd, Nome, Valor, qtd, loteId);

                    }
                }
            }

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
