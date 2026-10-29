using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class CardCarrinho : UserControl
    {
        public int ProdutoId { get; private set; }

        public event EventHandler<int> RemoverClicado;

        public CardCarrinho()
        {
            InitializeComponent();
            btnRemover.Click += BtnRemover_Click;
        }

        public void CarregarItem(int produtoId, string nome, int quantidade, decimal preco)
        {
            ProdutoId = produtoId;
            lblNome.Text = nome;
            AtualizarQuantidade(quantidade, preco);
        }

        public void AtualizarQuantidade(int quantidade, decimal preco)
        {
            lblQtd.Text = $"Qtd: {quantidade}";
            lblSubtotal.Text = (quantidade * preco).ToString("C2");
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            RemoverClicado?.Invoke(this, ProdutoId);
        }

        private void CardCarrinho_Load(object sender, EventArgs e)
        {

        }

        private void lblSubtotal_Click(object sender, EventArgs e)
        {

        }
    }
}