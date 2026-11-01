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
        int[] IdLotes = new int[0];
        public int qtdProd = 0; // quantidade do produto p mandar p pagina de alterar

        // get/set p receber os valores
        public frmPainel()
        {
            InitializeComponent();
        }

        private bool TentarObterEstoque(int idLote, out int estoque, out string erro)
        {
            estoque = 0;
            erro = null;

            DataSet.GA_EstoqueDataTable estoqueLote;
            using (var adapter = new DataSetTableAdapters.GA_EstoqueTableAdapter())
                estoqueLote = adapter.GetDataByLote(idLote);
            if (estoqueLote.Rows.Count == 0)
            {
                erro = "Não há estoque cadastrado para esse lote.";
                return false;
            }

            estoque = estoqueLote[0].QuantidadeAtual;
            return true;
        }

        public bool TentarAdicionarProduto(
            int id, string nome, decimal preco, int quantidade, int idLote, out string erro)
        {
            erro = null;

            if (quantidade <= 0)
            {
                erro = "A quantidade deve ser maior que zero.";
                return false;
            }

            if (IdLotes.Length != dataGridView1.Rows.Count)
            {
                erro = "Não foi possível conferir os lotes dos produtos. Cancele a venda e tente novamente.";
                return false;
            }

            int indiceExistente = -1;
            int quantidadeAtual = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];

                if (row.IsNewRow)
                    continue;

                int idLinha = Convert.ToInt32(row.Cells[0].Value);

                if (idLinha == id && IdLotes[i] == idLote)
                {
                    indiceExistente = i;
                    quantidadeAtual = Convert.ToInt32(row.Cells[2].Value);
                    break;
                }
            }

            if (!TentarObterEstoque(idLote, out int estoque, out erro))
                return false;

            int quantidadeSolicitada = quantidadeAtual + quantidade;

            if (quantidadeSolicitada > estoque)
            {
                erro = $"Estoque insuficiente. Disponível: {estoque}; ";
                return false;
            }

            if (indiceExistente >= 0)
            {
                AttQuantidade(indiceExistente, quantidadeSolicitada);
                return true;
            }

            int indice = dataGridView1.Rows.Add(
                id, nome, quantidade, preco, preco * quantidade);

            Array.Resize(ref IdLotes, dataGridView1.Rows.Count);
            IdLotes[indice] = idLote;

            AtualizarTotal();
            return true;
        }

        public bool TentarAlterarQuantidade(int linha, int quantidade, out string erro)
        {
            erro = null;

            if (linha < 0 || linha >= dataGridView1.Rows.Count ||
                linha >= IdLotes.Length)
            {
                erro = "Selecione um produto válido.";
                return false;
            }

            if (quantidade < 0)
            {
                erro = "A quantidade não pode ser negativa.";
                return false;
            }

            if (quantidade == 0)
            {
                removerProd(linha);
                return true;
            }

            int idLote = IdLotes[linha];

            if (!TentarObterEstoque(idLote, out int estoque, out erro))
                return false;

            if (quantidade > estoque)
            {
                erro = $"Estoque insuficiente para esse lote. Disponível: {estoque}.";
                return false;
            }

            AttQuantidade(linha, quantidade);
            return true;
        }

        private void AttQuantidade(int linha, int quantidade)
        {
            dataGridView1.Rows[linha].Cells[2].Value = quantidade;

            decimal preco = Convert.ToDecimal(dataGridView1.Rows[linha].Cells[3].Value);
            dataGridView1.Rows[linha].Cells[4].Value = preco * quantidade;

            AtualizarTotal();
        }

        // limpa quando um produto é removido
        private void LimparDetalhes()
        {
            dataGridView2.Rows.Clear();
        }

        public void removerProd(int linha)
        {
            dataGridView1.Rows.RemoveAt(linha);

            // remove o lote da mesma posição da linha removida
            var lista = IdLotes.ToList();
            lista.RemoveAt(linha);
            IdLotes = lista.ToArray();

            LimparDetalhes();
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAddProdVenda Adicionar = new frmAddProdVenda(this);
            Adicionar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Tem certeza que deseja cancelar?", "Confirmar:", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) // limita a 0 p so deixar a linha de cima
                {
                    if (!dataGridView1.Rows[i].IsNewRow) dataGridView1.Rows.RemoveAt(i);
                }

                IdLotes = new int[0];

                lblTotal.Text = "R$ 0,00";

                dataGridView2.Rows.Clear();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // evita a excessão de clicar em alterar sem selecionar uma linha
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Selecione um produto para alterar.");
                return;
            }

            int linha = dataGridView1.CurrentCell.RowIndex;
            if (linha >= 0 &&   dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value != null) // pega o valor de quantidade da linha da celulca focada
            {
                frmAlterarPreco Alterar = new frmAlterarPreco(this, linha);
                Alterar.ShowDialog();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há produtos para finalizar a venda.");
                return;
            }

            btnFinalizar.Enabled = false;

            try
            {
                if (IdLotes.Length != dataGridView1.Rows.Count)
                {
                    MessageBox.Show("Os lotes não correspondem aos produtos da venda.");
                    return;
                }

                var itens = new System.Text.StringBuilder("[");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    if (row.IsNewRow)
                        continue;

                    if (!int.TryParse(
                            Convert.ToString(row.Cells[2].Value),
                            out int quantidade) ||
                        quantidade <= 0)
                    {
                        MessageBox.Show("Há uma quantidade inválida no carrinho.");
                        return;
                    }

                    int lote = IdLotes[i];

                    if (lote <= 0)
                    {
                        MessageBox.Show("Há um lote inválido no carrinho.");
                        return;
                    }

                    if (!TentarObterEstoque(lote, out int estoque, out string erro))
                    {
                        MessageBox.Show(erro);
                        return;
                    }

                    if (quantidade > estoque)
                    {
                        MessageBox.Show(
                            $"Estoque insuficiente para o lote {lote}. Disponível: {estoque}.");
                        return;
                    }

                    if (itens.Length > 1)
                        itens.Append(",");

                    itens.Append("{\"FKLote\":")
                         .Append(lote)
                         .Append(",\"Quantidade\":")
                         .Append(quantidade)
                         .Append("}");
                }

                if (itens.Length == 1)
                {
                    MessageBox.Show("Não há produtos válidos para finalizar a venda.");
                    return;
                }

                itens.Append("]");

                // SUBSTITUIR PELOS IDS REAIS DO CLIENTE E DO FUNCIONARIO
                DataTable resultadoVenda;
                using (var adapter = new DataSetTableAdapters.GA_VendaTableAdapter())
                    resultadoVenda = adapter.GetResultadoVenda(1, 1, "Pix", itens.ToString());
                if (resultadoVenda.Rows.Count > 0)
                {
                    string mensagem = Convert.ToString(resultadoVenda.Rows[0]["Mensagem"]);
                    MessageBox.Show(mensagem);

                    if (mensagem == "Venda realizada com sucesso!")
                        LimparVenda();
                }
                else
                {
                    MessageBox.Show(
                        "A procedure terminou sem retornar a confirmação da venda.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível registrar a venda: " + ex.Message);
            }
            finally
            {
                btnFinalizar.Enabled = true;
            }
        }

        // usado depois de concluir a venda, para limpar as células
        private void LimparVenda()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            IdLotes = new int[0];
            lblTotal.Text = "R$ 0,00";
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
                
                    DataSet.DataTable1DataTable detalhes;
                    using (var adapter = new DataSetTableAdapters.DataTable1TableAdapter())
                        detalhes = adapter.GetProdutoOuLote(lote, id);
                    if (detalhes.Rows.Count > 0)
                    {
                        DataSet.DataTable1Row detalhe = detalhes[0];
                        string nome = detalhe.Nome;
                        decimal valor = detalhe.Preco;
                        string unidade = detalhe.UnidadeMedida;
                        string validade = detalhe.DataValidade.ToString("dd/MM/yyyy");

                        if (dataGridView2.Rows.Count == 0)
                            dataGridView2.Rows.Add();

                        dataGridView2.Rows[0].Cells[0].Value = nome;
                        dataGridView2.Rows[0].Cells[1].Value = valor;
                        dataGridView2.Rows[0].Cells[2].Value = unidade;
                        dataGridView2.Rows[0].Cells[3].Value = validade;
                    }
                }
            }
        }

        // quando for mergeado, esse label precisa mostrar se o cliente está registrado ou não, e se estiver, mostrar o nome dele. Se não estiver, mostrar "Não registrado"
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
