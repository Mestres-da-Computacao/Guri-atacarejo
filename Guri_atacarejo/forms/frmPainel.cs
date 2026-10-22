using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmPainel : Form
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SuperMercado;Trusted_Connection=True;TrustServerCertificate=True;";

        // get/set p receber os valores
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public frmPainel()
        {
            InitializeComponent();
        }

        public void AtualizarProduto(int id, string nome, decimal preco, int quantidade)
        {
            dataGridView1.Rows.Add(id, nome, quantidade, preco, (preco * quantidade)); // obs: falta exibir no datagridview. Ele adiciona o nmr de linha, mas n aparece no visual
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }
            lblTotal.Text = $"R$ {total:F2}";
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPainel_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // ------------------------------------------------------

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmTeste Adicionar = new frmTeste(this);
            Adicionar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tem certeza que deseja cancelar?");
            DialogResult resposta = MessageBox.Show(
                "Tem certeza que deseja cancelar?", "Confirmar:",
                MessageBoxButtons.YesNo
            );

            if (resposta == DialogResult.Yes)
            {
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) // limita a 0 p so deixar a linha de cima
                {
                    if (!dataGridView1.Rows[i].IsNewRow) dataGridView1.Rows.RemoveAt(i);
                }
                lblTotal.Text = "R$ 0,00";

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                int lote = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("select P.Nome, P.Preco, P.UnidadeMedida, L.DataValidade from GA_Lote L inner join GA_Produtos P on L.IdLote = @lote and P.IdProduto = @idProduto", conn))
                {
                    cmd.Parameters.AddWithValue("@idProduto", id);
                    cmd.Parameters.AddWithValue("@lote", dataGridView1.Rows[e.RowIndex].Cells[1].Value); // Assuming the lote is in the second column
                    conn.Open();
                    
                    // tem que dar um jeito de atribuir algo para o lote, pq nesse form n tem nenhum modo de pegar. Opção: segunda pagina nandar p cá
                }
            }
        }
    }
}
