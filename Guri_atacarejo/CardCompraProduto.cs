using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public partial class CardCompraProduto : UserControl
    {
        public CardCompraProduto()
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;
            Size = new Size(333, 179);

            foreach (var lbl in Controls.OfType<Label>())
            {
                lbl.AutoSize = false;
                lbl.AutoEllipsis = true;
                lbl.Size = new Size(Width - lbl.Left - 6, 20);
            }
        }

        public void CarregarProduto(string nome, decimal preco, DateTime validade, string categoria, string fornecedor)
        {
            lblNome.Text = "Nome: " + nome;
            lblPreco.Text = "Preço: " + preco.ToString("C2");
            lblValidade.Text = "Data de validade: " + validade.ToString("dd/MM/yyyy");
            lblCategoria.Text = "Categoria: " + categoria;
            lblFornecedor.Text = "Fornecedor: " + fornecedor;
        }
    }
}