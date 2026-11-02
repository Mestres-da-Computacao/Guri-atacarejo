using System;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public partial class CardProduto : UserControl
    {
        public int ProdutoId { get; private set; }
        public decimal Preco { get; private set; }

        public event EventHandler<QuantidadeAlteradaEventArgs> QuantidadeAlterada;

        private bool _ajustando;

        public CardProduto()
        {
            InitializeComponent();

            numQtd.ValueChanged += NumQtd_ValueChanged;

            // Reposiciona quando o card mudar de tamanho
            SizeChanged += Reforcar;

            // Se algo externo (ex.: ResponsividadeForm) mexer nos controles
            // internos, o card recoloca tudo no lugar.
            foreach (Control c in new Control[] { lblNome, lblPreco, numQtd })
            {
                c.FontChanged += Reforcar;
                c.SizeChanged += Reforcar;
                c.LocationChanged += Reforcar;
            }

            AjustarControles();
        }

        private void Reforcar(object sender, EventArgs e)
        {
            AjustarControles();
        }

        public void CarregarProduto(int id, string nome, decimal preco)
        {
            ProdutoId = id;
            Preco = preco;

            lblNome.Text = nome;
            lblPreco.Text = preco.ToString("C2");

            numQtd.Value = 0;

            AjustarControles();
        }

        private void AjustarControles()
        {
            if (_ajustando || ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            _ajustando = true;
            try
            {
                int h = ClientSize.Height;
                int margem = 12;

                // Fontes proporcionais à altura do card, com limites
                float fonteTexto = Math.Max(10f, Math.Min(h * 0.20f, 16f));
                float fonteQtd = Math.Max(10f, Math.Min(h * 0.18f, 13f));

                DefinirFonte(lblNome, fonteTexto);
                DefinirFonte(lblPreco, fonteTexto);
                DefinirFonte(numQtd, fonteQtd);

                // Largura do seletor: ~10% do card, entre 70 e 100 px
                numQtd.Visible = true;
                numQtd.Width = Math.Max(70, Math.Min(100, ClientSize.Width / 10));

                // Seletor de quantidade sempre à direita
                numQtd.Location = new Point(
                    ClientSize.Width - numQtd.Width - margem,
                    (h - numQtd.Height) / 2);

                // Preço antes do seletor de quantidade
                lblPreco.Location = new Point(
                    numQtd.Left - lblPreco.Width - 20,
                    (h - lblPreco.Height) / 2);

                // Nome do produto
                lblNome.Location = new Point(
                    margem,
                    (h - lblNome.Height) / 2);

                numQtd.BringToFront();
            }
            finally
            {
                _ajustando = false;
            }
        }

        private static void DefinirFonte(Control c, float tamanho)
        {
            if (Math.Abs(c.Font.Size - tamanho) < 0.1f)
                return;

            c.Font = new Font(c.Font.FontFamily, tamanho, c.Font.Style);
        }

        public void AtualizarQuantidade(int quantidade)
        {
            numQtd.ValueChanged -= NumQtd_ValueChanged;

            numQtd.Value = quantidade;

            numQtd.ValueChanged += NumQtd_ValueChanged;
        }

        private void NumQtd_ValueChanged(object sender, EventArgs e)
        {
            QuantidadeAlterada?.Invoke(
                this,
                new QuantidadeAlteradaEventArgs(
                    ProdutoId,
                    (int)numQtd.Value
                )
            );
        }

        private void CardProduto_Load(object sender, EventArgs e)
        {
            AjustarControles();
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