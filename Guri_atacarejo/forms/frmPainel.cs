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


        int[] IdLotes = new int[0];
        public int qtdProd = 0; // quantidade do produto p mandar p pagina de alterar

        // get/set p receber os valores
        public frmPainel()
        {
            InitializeComponent();
        }

        public void AtualizarProduto(int id, string nome, decimal preco, int quantidade, int IdLote)
        {
            dataGridView1.Rows.Add(id, nome, quantidade, preco, (preco * quantidade));

            Array.Resize(ref IdLotes, dataGridView1.Rows.Count - 1); // Redimensiona o array para a qnatidade de produtos no DataGridView
            IdLotes[IdLotes.Length - 1] = IdLote;
            AtualizarTotal();
        }

        public void AttQuantidade(int linha, int quantidade)
        {
            dataGridView1.Rows[linha].Cells[2].Value = quantidade;
            decimal preco = Convert.ToDecimal(dataGridView1.Rows[linha].Cells[3].Value);
            dataGridView1.Rows[linha].Cells[4].Value = preco * quantidade;
            AtualizarTotal();
        }

        public void removerProd(int linha)
        {
            dataGridView1.Rows.RemoveAt(linha);
            Array.Resize(ref IdLotes, dataGridView1.Rows.Count - 1); // Redimensiona o array para a qnatidade de produtos no DataGridView
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

        

        // ------------------------------------------------------

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAddProdVenda Adicionar = new frmAddProdVenda(this);
            Adicionar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Tem certeza que deseja cancelar?", "Confirmar:",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) // limita a 0 p so deixar a linha de cima
                {
                    if (!dataGridView1.Rows[i].IsNewRow) dataGridView1.Rows.RemoveAt(i);
                }
                lblTotal.Text = "R$ 0,00";

                dataGridView2.Rows[0].Cells[0].Value = " ";
                dataGridView2.Rows[0].Cells[1].Value = " ";
                dataGridView2.Rows[0].Cells[2].Value = " ";
                dataGridView2.Rows[0].Cells[3].Value = " ";

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dataGridView1.CurrentCell.RowIndex;
            if (linha >= 0 &&   dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value != null) // pega o valor de quantidade da linha da celulca focada
            {
                frmAlterarPreco Alterar = new frmAlterarPreco(this, linha);
                Alterar.ShowDialog();
            }
            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string itensJson = "["; // tem q usar esse ngc em json na procedure

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int lote = IdLotes[row.Index];
                int quantidade = Convert.ToInt32(row.Cells[2].Value);

                if (itensJson != "[")
                    itensJson += ",";

                itensJson += "{\"FKLote\":" + lote +
                             ",\"Quantidade\":" + quantidade + "}";
            }

            itensJson += "]";


            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("usp_RegistrarVenda", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FKCliente", 1);    // falta adicionar
                cmd.Parameters.AddWithValue("@FKFuncionario", 1);           // falta adicionar
                cmd.Parameters.AddWithValue("@FormaPagamento", "Pix");      // talvez precise de um outro form
                cmd.Parameters.AddWithValue("@ItensJson", itensJson);       //json

                

                try
                {
                    conn.Open();
                    MessageBox.Show(itensJson);
                    using (var reader = cmd.ExecuteReader())


                    {
                        if (reader.Read())
                        {
                            MessageBox.Show(reader["Mensagem"].ToString());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //using (var reader = cmd.ExecuteReader())
                //{
                //    if (reader.Read())
                //    {
                //        int idVenda = Convert.ToInt32(reader["IdVendaGerada"]);
                //        string mensagem = reader["Mensagem"].ToString();

                //        MessageBox.Show(mensagem + "\nID da venda: " + idVenda);
                //    }
                //}
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                int lote = 0;
                if (e.RowIndex < IdLotes.Length)
                {
                    qtdProd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);

                    lote = IdLotes[e.RowIndex];
                

                

                    using (var conn = new SqlConnection(connectionString))
                    using (var cmd = new SqlCommand("select P.Nome, P.Preco, P.UnidadeMedida, L.DataValidade from GA_Lote L inner join GA_Produtos P on L.IdLote = @lote and P.IdProduto = @idProduto", conn))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", id);
                        cmd.Parameters.AddWithValue("@lote", lote);
                        conn.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Nome = reader.GetString(0);
                                decimal Valor = reader.GetDecimal(1);
                                string UniProd = reader.GetString(2);
                                string loteVal = reader.GetDateTime(3).ToString("dd/MM/yyyy");

                                dataGridView2.Rows[0].Cells[0].Value = Nome;
                                dataGridView2.Rows[0].Cells[1].Value = Valor;
                                dataGridView2.Rows[0].Cells[2].Value = UniProd;
                                dataGridView2.Rows[0].Cells[3].Value = loteVal;

                            }
                        }

                        // tem que dar um jeito de atribuir algo para o lote, pq nesse form n tem nenhum modo de pegar. Opção: segunda pagina nandar p cá
                    }
                }
            }
        }
    }
}
