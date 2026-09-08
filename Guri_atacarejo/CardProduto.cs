using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public partial class CardProduto : UserControl
    {
        public int ProdutoId { get; private set; }
        public decimal Preco { get; private set; }

        public event EventHandler<QuantidadeAlteradaEventArgs> QuantidadeAlterada;

        public CardProduto()
        {
            InitializeComponent();
            numQtd.ValueChanged += NumQtd_ValueChanged;
        }

        public void CarregarProduto(int id, string nome, decimal preco)
        {
            ProdutoId = id;
            Preco = preco;
            lblNome.Text = nome;
            lblPreco.Text = preco.ToString("C2");
            numQtd.Value = 0;
        }

        public void AtualizarQuantidade(int quantidade)
        {
            numQtd.ValueChanged -= NumQtd_ValueChanged;
            numQtd.Value = quantidade;
            numQtd.ValueChanged += NumQtd_ValueChanged;
        }

        private void NumQtd_ValueChanged(object sender, EventArgs e)
        {
            QuantidadeAlterada?.Invoke(this,
                new QuantidadeAlteradaEventArgs(ProdutoId, (int)numQtd.Value));
        }

        private void CardProduto_Load(object sender, EventArgs e)
        {

        }
    }
    public class QuantidadeAlteradaEventArgs : EventArgs
    {
        public int ProdutoId { get; }
        public int Quantidade { get; }

        public QuantidadeAlteradaEventArgs(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}