using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guri_atacarejo;

namespace Guri_atacarejo.forms
{
    public partial class frmAdicionar : Form
    {
        private Dictionary<int, CardCarrinho> cardsNoCarrinho = new Dictionary<int, CardCarrinho>();
        private List<(int Id, string Nome, decimal Preco)> produtosDisponiveis;

        public frmAdicionar()
        {
            InitializeComponent();
            this.Load += frmAdicionar_Load;
        }

        private void frmAdicionar_Load(object sender, EventArgs e)
        {
            produtosDisponiveis = new List<(int Id, string Nome, decimal Preco)>
            {
                (1, "Arroz 5kg", 24.90m),
                (2, "Feijão 1kg", 8.50m),
                (3, "Óleo de Soja 900ml", 7.20m),
                (4, "Açúcar 1kg", 4.75m),
                (5, "Café 500g", 12.30m),
            };

            flpProdutos.Controls.Clear();

            foreach (var p in produtosDisponiveis)
            {
                var card = new CardProduto();
                card.CarregarProduto(p.Id, p.Nome, p.Preco);
                card.QuantidadeAlterada += Card_QuantidadeAlterada;

                flpProdutos.Controls.Add(card);
            }
        }

        private void Card_QuantidadeAlterada(object sender, QuantidadeAlteradaEventArgs e)
        {
            AtualizarCarrinho(e.ProdutoId, e.Quantidade);
        }

        private void AtualizarCarrinho(int produtoId, int quantidade)
        {
            if (quantidade <= 0)
            {
                if (cardsNoCarrinho.TryGetValue(produtoId, out var cardExistente))
                {
                    flpCarrinho.Controls.Remove(cardExistente);
                    cardsNoCarrinho.Remove(produtoId);
                }
                return;
            }

            var produto = produtosDisponiveis.First(p => p.Id == produtoId);

            if (cardsNoCarrinho.TryGetValue(produtoId, out var card))
            {
                card.AtualizarQuantidade(quantidade, produto.Preco);
            }
            else
            {
                var novoCard = new CardCarrinho();
                novoCard.CarregarItem(produto.Id, produto.Nome, quantidade, produto.Preco);
                novoCard.RemoverClicado += CardCarrinho_RemoverClicado;

                flpCarrinho.Controls.Add(novoCard);
                cardsNoCarrinho[produtoId] = novoCard;
            }
        }

        private void CardCarrinho_RemoverClicado(object sender, int produtoId)
        {
            if (cardsNoCarrinho.TryGetValue(produtoId, out var card))
            {
                flpCarrinho.Controls.Remove(card);
                cardsNoCarrinho.Remove(produtoId);
            }

            var cardProduto = flpProdutos.Controls
                .OfType<CardProduto>()
                .FirstOrDefault(c => c.ProdutoId == produtoId);

            if (cardProduto != null)
                cardProduto.AtualizarQuantidade(0);
        }
    }
}