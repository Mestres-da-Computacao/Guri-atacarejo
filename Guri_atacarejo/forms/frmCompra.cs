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
    public partial class frmCompra_ : Form
    {
        private readonly Dictionary<int, CardCompraProduto> _detalhes = new Dictionary<int, CardCompraProduto>();

        public frmCompra_()
        {
            InitializeComponent();
            this.Load += frmCompra__Load;
        }

        private void frmCompra__Load(object sender, EventArgs e)
        {
            CarregarCards();
        }

        private void CarregarCards()
        {
            var produtos = new List<ProdutoCompra>
            {
                new ProdutoCompra { Id = 1, Nome = "Arroz 5kg", Preco = 24.90m, Validade = new DateTime(2027, 3, 15), Categoria = "Grãos", Fornecedor = "Distribuidora Sol" },
                new ProdutoCompra { Id = 2, Nome = "Feijão 1kg", Preco = 8.50m, Validade = new DateTime(2027, 1, 10), Categoria = "Grãos", Fornecedor = "Distribuidora Sol" },
                new ProdutoCompra { Id = 3, Nome = "Óleo de Soja 900ml", Preco = 7.20m, Validade = new DateTime(2027, 6, 30), Categoria = "Óleos", Fornecedor = "Atacado Brasil" },
                new ProdutoCompra { Id = 4, Nome = "Açúcar 1kg", Preco = 4.75m, Validade = new DateTime(2027, 9, 1), Categoria = "Mercearia", Fornecedor = "Atacado Brasil" },
                new ProdutoCompra { Id = 5, Nome = "Café 500g", Preco = 12.30m, Validade = new DateTime(2027, 4, 20), Categoria = "Bebidas", Fornecedor = "Café Serra" },
            };

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            _detalhes.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            foreach (var p in produtos)
            {
                var card = new CardTelaCompra();
                card.CarregarProduto(p.Id, p.Nome, p.Preco);
                card.Tag = p;
                card.Margin = new Padding(0, 0, 0, 3);
                card.QuantidadeAlterada += Card_QuantidadeAlterada;
                flowLayoutPanel1.Controls.Add(card);
            }

            flowLayoutPanel1.ResumeLayout();

            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.AutoScroll = true;
        }

        private void Card_QuantidadeAlterada(object sender, QuantidadeAlteradaEventArgs e)
        {
            var card = (CardTelaCompra)sender;
            var produto = (ProdutoCompra)card.Tag;

            if (e.Quantidade > 0)
                AdicionarNoPainel(produto);
            else
                RemoverDoPainel(produto.Id);
        }

        private void AdicionarNoPainel(ProdutoCompra p)
        {
            if (_detalhes.ContainsKey(p.Id))
                return;

            var detalhe = new CardCompraProduto();
            detalhe.Margin = new Padding(0, 0, 0, 3);
            detalhe.CarregarProduto(p.Nome, p.Preco, p.Validade, p.Categoria, p.Fornecedor);

            _detalhes[p.Id] = detalhe;
            flowLayoutPanel2.Controls.Add(detalhe);
        }

        private void RemoverDoPainel(int produtoId)
        {
            CardCompraProduto detalhe;
            if (!_detalhes.TryGetValue(produtoId, out detalhe))
                return;

            _detalhes.Remove(produtoId);
            flowLayoutPanel2.Controls.Remove(detalhe);
            detalhe.Dispose();
        }
    }

    public class ProdutoCompra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime Validade { get; set; }
        public string Categoria { get; set; }
        public string Fornecedor { get; set; }
    }
}