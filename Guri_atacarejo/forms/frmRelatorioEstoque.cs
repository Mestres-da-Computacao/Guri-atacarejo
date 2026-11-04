using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioEstoque : Icone
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_250405;Integrated Security=True;TrustServerCertificate=True;";

        int idProduto = 0;          // produto que foi clicado no grid
        string nomeProduto = "";
        DataTable operacoes;        // compras e vendas do produto clicado (vazio até clicarem em um produto)

        public frmRelatorioEstoque()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            cbTipo.SelectedIndex = 0;     // "Compras e vendas"
            cbPeriodo.SelectedIndex = 0;  // "Dia"

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void frmRelatorioEstoque_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            MostrarMensagem("Clique em um produto para ver as compras e vendas.");
        }

        // ------------------------------------------------------
        // GRID DE PRODUTOS
        // ------------------------------------------------------

        private void CarregarProdutos()
        {
            // O estoque é guardado por lote, então somamos os lotes de cada produto.
            // left join = o produto aparece mesmo que ainda não tenha lote (estoque 0).
            string sql = @"select p.IdProduto, p.Nome, p.Preco,
                                  isnull(sum(e.QuantidadeAtual), 0) as QtdEstoque
                           from GA_Produtos p
                           left join GA_Lote l on l.FKProduto = p.IdProduto
                           left join GA_Estoque e on e.FKLote = l.IdLote
                           group by p.IdProduto, p.Nome, p.Preco
                           order by p.Nome";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable tabela = new DataTable();
                    da.Fill(tabela);
                    dataGridView1.DataSource = tabela;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clicou no cabeçalho

            DataRow linha = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;

            idProduto = Convert.ToInt32(linha["IdProduto"]);
            nomeProduto = linha["Nome"].ToString();

            CarregarOperacoes();
            MostrarCards();
        }

        // ------------------------------------------------------
        // BUSCA DAS OPERAÇÕES (COMPRAS E VENDAS) DO PRODUTO
        // ------------------------------------------------------

        private void CarregarOperacoes()
        {
            // Duas consultas com as MESMAS colunas, juntas com "union all":
            // a primeira traz as compras e a segunda traz as vendas do produto.
            // No fim, "order by" coloca tudo em ordem cronológica.
            string sql = @"
                -- COMPRAS (não existe cliente numa compra, por isso null)
                select 'Compra' as Tipo, c.IdCompra as IdOperacao, c.DataCompra as Data,
                       c.StatusCompra as Status, l.IdLote, f.Nome as Fornecedor,
                       fu.Nome as Funcionario, null as IdCliente,
                       i.Quantidade, i.PrecoUnitario, l.DataValidade
                from GA_ItensCompra i
                inner join GA_Compra c on c.IdCompra = i.FKCompra
                inner join GA_Lote l on l.IdLote = i.FKLote
                inner join GA_Fornecedor f on f.IdFornecedor = l.FKFornecedores
                inner join GA_Funcionarios fu on fu.IdFuncionario = c.FKFuncionario
                where l.FKProduto = @idProduto

                union all

                -- VENDAS (se o item foi cancelado sozinho, o status vira 'Cancelado')
                select 'Venda', v.IdVenda, v.DataVenda,
                       case when iv.Cancelado = 1 then 'Cancelado' else v.StatusVenda end,
                       l.IdLote, f.Nome,
                       fu.Nome, v.FKCliente,
                       iv.Quantidade, iv.PrecoUnitario, l.DataValidade
                from GA_ItensVenda iv
                inner join GA_Venda v on v.IdVenda = iv.FKVenda
                inner join GA_Lote l on l.IdLote = iv.FKLote
                inner join GA_Fornecedor f on f.IdFornecedor = l.FKFornecedores
                inner join GA_Funcionarios fu on fu.IdFuncionario = v.FKFuncionario
                where l.FKProduto = @idProduto

                order by Data, Tipo, IdOperacao";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idProduto", idProduto);

                    operacoes = new DataTable();
                    da.Fill(operacoes);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ------------------------------------------------------
        // FILTROS (não consultam o banco: só filtram o que já foi carregado)
        // ------------------------------------------------------

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCards();
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPeriodo.Text == "Dia") maskData.Mask = "00/00/0000";
            if (cbPeriodo.Text == "Mês") maskData.Mask = "00/0000";
            if (cbPeriodo.Text == "Ano") maskData.Mask = "0000";

            maskData.Clear();
            MostrarCards();
        }

        private void maskData_TextChanged(object sender, EventArgs e)
        {
            MostrarCards();
        }

        // Devolve true se a operação deve aparecer, de acordo com os dois filtros
        private bool PassaNoFiltro(DataRow linha)
        {
            string tipo = linha["Tipo"].ToString();       // "Compra" ou "Venda"
            string status = linha["Status"].ToString();
            DateTime data = Convert.ToDateTime(linha["Data"]);

            // filtro de tipo
            if (cbTipo.Text == "Compras" && tipo != "Compra") return false;
            if (cbTipo.Text == "Vendas" && tipo != "Venda") return false;
            if (cbTipo.Text == "Canceladas" && status != "Cancelado") return false;

            // filtro de data: só vale quando a data está completamente preenchida
            if (maskData.MaskCompleted)
            {
                string formato = "dd/MM/yyyy";                 // Dia
                if (cbPeriodo.Text == "Mês") formato = "MM/yyyy";
                if (cbPeriodo.Text == "Ano") formato = "yyyy";

                // compara o texto digitado com a data da operação escrita no mesmo formato
                if (data.ToString(formato) != maskData.Text) return false;
            }

            return true;
        }

        // ------------------------------------------------------
        // CARDS
        // ------------------------------------------------------

        private void LimparCards()
        {
            // Dispose remove o controle do painel e libera a memória dele
            while (flowCards.Controls.Count > 0)
                flowCards.Controls[0].Dispose();
        }

        private void MostrarMensagem(string texto)
        {
            LimparCards();
            AdicionarTexto(flowCards, texto, 0, 0, false);
        }

        private void MostrarCards()
        {
            if (operacoes == null) return; // ainda não clicaram em nenhum produto

            LimparCards();
            AdicionarTexto(flowCards, nomeProduto, 0, 0, true);

            int quantos = 0;
            foreach (DataRow linha in operacoes.Rows)
            {
                if (PassaNoFiltro(linha))
                {
                    flowCards.Controls.Add(CriarCard(linha));
                    quantos++;
                }
            }

            if (quantos == 0)
                AdicionarTexto(flowCards, "Nenhuma operação encontrada.", 0, 0, false);
        }

        private Panel CriarCard(DataRow linha)
        {
            string tipo = linha["Tipo"].ToString();   // "Compra" ou "Venda"

            Panel card = new Panel();
            card.Width = flowCards.ClientSize.Width - 25;
            card.Height = 152;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.BackColor = Color.White;

            // título
            string titulo = tipo.ToUpper() + " Nº " + linha["IdOperacao"];
            if (linha["Status"].ToString() == "Cancelado")
                titulo += " (CANCELADA)";
            AdicionarTexto(card, titulo, 8, 6, true);

            // lote e data
            AdicionarTexto(card, "Id do lote: " + linha["IdLote"], 8, 30, false);
            AdicionarTexto(card, "Data: " + Convert.ToDateTime(linha["Data"]).ToString("dd/MM/yyyy"), 205, 30, false);

            // fornecedor do lote
            AdicionarTexto(card, "Fornecedor: " + linha["Fornecedor"], 8, 54, false);

            // funcionário que registrou a operação
            AdicionarTexto(card, "Funcionário: " + linha["Funcionario"], 8, 78, false);

            // id do cliente: só existe nas vendas (e fica "-" se a venda não teve cliente)
            if (tipo == "Venda")
            {
                string cliente = "-";
                if (linha["IdCliente"] != DBNull.Value)
                    cliente = linha["IdCliente"].ToString();

                AdicionarTexto(card, "Id do cliente: " + cliente, 205, 78, false);
            }

            // quantidade (comprada ou vendida) e preço
            string palavra = "vendida";
            if (tipo == "Compra") palavra = "comprada";

            AdicionarTexto(card, "Quantidade " + palavra + ": " + linha["Quantidade"], 8, 102, false);
            AdicionarTexto(card, "Preço: " + Convert.ToDecimal(linha["PrecoUnitario"]).ToString("C2"), 205, 102, false);

            // validade do lote
            AdicionarTexto(card, "Validade: " + Convert.ToDateTime(linha["DataValidade"]).ToString("dd/MM/yyyy"), 8, 126, false);

            return card;
        }

        // Cria um Label com o texto e coloca dentro do "destino" (um card ou o próprio painel)
        private void AdicionarTexto(Control destino, string texto, int x, int y, bool negrito)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            lbl.ForeColor = Color.Black;

            if (negrito)
                lbl.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            else
                lbl.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular);

            destino.Controls.Add(lbl);
        }

        private void frmImprimirEstoque_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_250405;Integrated Security=True;TrustServerCertificate=True;";

            string sql = @"select p.IdProduto, p.Nome, p.Preco,
            isnull(sum(e.QuantidadeAtual), 0) as QtdEstoque
            from GA_Produtos p
            left join GA_Lote l on l.FKProduto = p.IdProduto
            left join GA_Estoque e on e.FKLote = l.IdLote
            group by p.IdProduto, p.Nome, p.Preco
            order by p.Nome";

            var dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            using (var da = new SqlDataAdapter(sql, conn))
                da.Fill(dt);

            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Reports", "rptEstoque.rdlc");
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Estoque", dt));
            reportViewer1.RefreshReport();
        }
    }
}