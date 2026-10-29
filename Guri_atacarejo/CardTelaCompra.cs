using System;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public partial class CardTelaCompra : UserControl
    {
        public int ProdutoId { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get { return (int)numQtd.Value; } }

        public CardTelaCompra()
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;
            Size = new Size(806, 33);

            numQtd.Maximum = 9999;

            lblNome.AutoSize = false;
            lblNome.AutoEllipsis = true;
            lblNome.Size = new Size(235, 20);
        }

        public void CarregarProduto(int id, string nome, decimal preco)
        {
            ProdutoId = id;
            Preco = preco;
            lblNome.Text = nome;
            lblPreco.Text = preco.ToString("C2");
            numQtd.Value = 0;
        }

        private void CardTelaCompra_Load(object sender, EventArgs e)
        {
        }
    }
}