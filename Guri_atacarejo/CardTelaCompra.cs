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

        // disparado sempre que a quantidade (numQtd) muda
        public event EventHandler<QuantidadeAlteradaEventArgs> QuantidadeAlterada;

        public CardTelaCompra()
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;
            Size = new Size(806, 33);

            numQtd.Maximum = 9999;
            numQtd.ValueChanged += NumQtd_ValueChanged;

            lblNome.AutoSize = false;
            lblNome.AutoEllipsis = true;
            lblNome.Size = new Size(235, 20);

            lblNome.Click += (s, e) => OnClick(e);
            lblPreco.Click += (s, e) => OnClick(e);
        }

        public void CarregarProduto(int id, string nome, decimal preco)
        {
            ProdutoId = id;
            Preco = preco;
            lblNome.Text = nome;
            lblPreco.Text = preco.ToString("C2");
            numQtd.Value = 0;
        }

        private void NumQtd_ValueChanged(object sender, EventArgs e)
        {
            QuantidadeAlterada?.Invoke(this,
                new QuantidadeAlteradaEventArgs(ProdutoId, (int)numQtd.Value));
        }

        private void CardTelaCompra_Load(object sender, EventArgs e)
        {
        }
    }
}