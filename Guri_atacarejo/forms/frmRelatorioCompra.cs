using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioCompra : Icone
    {
        public frmRelatorioCompra()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

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
                DataSet.GA_CompraRelatorioDataTable compras;
                using (var adapter = new DataSetTableAdapters.GA_CompraRelatorioTableAdapter())
                    compras = adapter.GetCompras(inicio, fim);

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

                dataGridView1.DataSource = compras;
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

            // data inválida (ex.: 67/67/6767): avisa e limpa
            if (!ok)
            {
                MessageBox.Show("Data inválida.", "Data inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskData.Clear();
                maskData.Focus();
                return;
            }

            // data futura: avisa e limpa
            DateTime hoje = DateTime.Today;
            bool futura;

            switch (cbtempo.SelectedIndex)
            {
                case 0: // dia
                    futura = inicio.Date > hoje;
                    break;
                case 1: // mês
                    futura = inicio > new DateTime(hoje.Year, hoje.Month, 1);
                    break;
                default: // ano
                    futura = inicio.Year > hoje.Year;
                    break;
            }

            if (futura)
            {
                MessageBox.Show("Não é possível consultar datas futuras.", "Data inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskData.Clear();
                maskData.Focus();
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
            sb.AppendLine("Fornecedor: " + drv["NomeFornecedor"]);
            sb.AppendLine("Funcionário: " + drv["NomeFuncionario"]);
            sb.AppendLine("Valor total: " + Convert.ToDecimal(drv["ValorTotal"]).ToString("C2"));
            sb.AppendLine();
            sb.AppendLine("ITENS:");

            try
            {
                DataSet.GA_ItensCompraRelatorioDataTable itens;
                using (var adapter = new DataSetTableAdapters.GA_ItensCompraRelatorioTableAdapter())
                    itens = adapter.GetItensPorCompra(idCompra);

                if (itens.Rows.Count == 0)
                    sb.AppendLine("(nenhum item)");
                else
                {
                    foreach (DataRow item in itens.Rows)
                    {
                        sb.AppendLine(string.Format("- {0} (Lote {1}): {2} x {3:C2} = {4:C2}",
                            item["Produto"], item["FKLote"], item["Quantidade"],
                            item["PrecoUnitario"], item["Subtotal"]));
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
        
        // reseta o filtro
        private void btnResetarFiltro_Click(object sender, EventArgs e)
        {
            maskData.Clear();
            cbtempo.SelectedIndex = 0;
            CarregarProdutos();
            textBox2.Clear();
        }
        private void frmImprimirCompras_Load(object sender, EventArgs e)
        {
            DataSet.GA_CompraRelatorioDataTable compras;
            using (var adapter = new DataSetTableAdapters.GA_CompraRelatorioTableAdapter())
                compras = adapter.GetCompras(null, null); // ou passe inicio/fim do filtro

            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Reports", "rptCompras.rdlc");
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Compras", (DataTable)compras));
            reportViewer1.RefreshReport();
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