using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorio : Form
    {
        private readonly string connStr =
            @"Server=(localdb)\MSSQLLocalDB;Database=SuperMercado;Trusted_Connection=True;";

        public frmRelatorio()
        {
            InitializeComponent();

            cbtempo.Leave += cbtempo_Leave;
            maskData.TextChanged += maskData_TextChanged;

            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;

            cbtempo.SelectedIndex = 0;
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void cbtempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbtempo.SelectedIndex)
            {
                case 0:
                    maskData.Mask = "00/00/0000";
                    break;
                case 1:
                    maskData.Mask = "00/0000";
                    break;
                case 2:
                    maskData.Mask = "0000";
                    break;
            }
        }

        private void CarregarProdutos(DateTime? inicio = null, DateTime? fim = null)
        {

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;

            try
            {
                string sql = @"SELECT IdCompra, DataCompra, StatusCompra, ValorTotal, FormaPagamento, DataEntrega, FKFornecedor, FKFuncionario FROM GA_Compra";

                if (inicio.HasValue && fim.HasValue)
                    sql += " WHERE DataCompra >= @inicio AND DataCompra < @fim";

                sql += " ORDER BY DataCompra DESC";

                using (var conn = new SqlConnection(connStr))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    if (inicio.HasValue && fim.HasValue)
                    {
                        da.SelectCommand.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio.Value;
                        da.SelectCommand.Parameters.Add("@fim", SqlDbType.Date).Value = fim.Value;
                    }

                    var dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "DataCompra",
                        HeaderText = "Data",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StatusCompra",
                        HeaderText = "Tipo"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "ValorTotal",
                        HeaderText = "Valor",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                    });

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        private void AplicarFiltro(bool mostrarAvisos)
        {
            if (!maskData.MaskCompleted)
            {
                if (mostrarAvisos)
                    MessageBox.Show("Preencha a data completa.");
                else
                    CarregarProdutos(); // sem data preenchida, mostra tudo
                return;
            }

            string texto = maskData.Text;
            DateTime inicio, fim;
            bool ok;

            switch (cbtempo.SelectedIndex)
            {
                case 0: // dia
                    ok = DateTime.TryParseExact(texto, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddDays(1);
                    break;

                case 1: // mês
                    ok = DateTime.TryParseExact(texto, "MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddMonths(1);
                    break;

                default: // ano
                    ok = DateTime.TryParseExact(texto, "yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddYears(1);
                    break;
            }

            if (!ok)
            {
                if (mostrarAvisos)
                    MessageBox.Show("Data inválida.");
                return;
            }

            CarregarProdutos(inicio, fim);
        }

        private void cbtempo_Leave(object sender, EventArgs e)
        {
            AplicarFiltro(false);
        }
        private void maskData_TextChanged(object sender, EventArgs e)
        {
            if (maskData.MaskCompleted)
                AplicarFiltro(false);
        }

        private void MostrarDetalhes(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count) return;

            var drv = dataGridView1.Rows[rowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            int idCompra = Convert.ToInt32(drv["IdCompra"]);
            var sb = new StringBuilder();

            sb.AppendLine("COMPRA Nº " + idCompra);
            sb.AppendLine("Data: " + Convert.ToDateTime(drv["DataCompra"]).ToString("dd/MM/yyyy"));
            sb.AppendLine("Status: " + drv["StatusCompra"]);
            sb.AppendLine("Pagamento: " + (drv["FormaPagamento"] == DBNull.Value ? "-" : drv["FormaPagamento"]));
            sb.AppendLine("Fornecedor (Id): " + drv["FKFornecedor"]);
            sb.AppendLine("Funcionário (Id): " + drv["FKFuncionario"]);
            sb.AppendLine("Valor total: " + Convert.ToDecimal(drv["ValorTotal"]).ToString("C2"));
            sb.AppendLine();
            sb.AppendLine("ITENS:");

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(
                    @"SELECT FKLote, Quantidade, PrecoUnitario, Subtotal
              FROM GA_ItensCompra
              WHERE FKCompra = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idCompra;
                    conn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        bool temItens = false;
                        while (rd.Read())
                        {
                            temItens = true;
                            sb.AppendLine(string.Format("- Lote {0}: {1} x {2:C2} = {3:C2}",
                                rd["FKLote"], rd["Quantidade"],
                                rd["PrecoUnitario"], rd["Subtotal"]));
                        }
                        if (!temItens) sb.AppendLine("(nenhum item)");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("Erro ao carregar itens: " + ex.Message);
            }

            textBox2.Text = sb.ToString();
        }

        // Ao passar o mouse por cima da linha
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetalhes(e.RowIndex);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //deslogar o funcionario com a classe sessão que esta na main
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        
    }
}