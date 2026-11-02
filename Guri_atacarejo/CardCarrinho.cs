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

        private bool _ajustando;

        public CardCarrinho()
        {
            InitializeComponent();

            ForeColor = Color.Black;
            lblNome.ForeColor = Color.Black;
            lblQtd.ForeColor = Color.Black;
            lblSubtotal.ForeColor = Color.Black;
            btnRemover.ForeColor = Color.Black;

            lblNome.AutoSize = false;
            lblNome.AutoEllipsis = true;

            btnRemover.Click += BtnRemover_Click;

            SizeChanged += Reforcar;

            foreach (Control c in new Control[] { lblNome, lblQtd, lblSubtotal, btnRemover })
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

        private void AjustarControles()
        {
            if (_ajustando || ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            _ajustando = true;
            try
            {
                int h = ClientSize.Height;
                int m = 8;

                float fonte = Math.Max(9f, Math.Min(h * 0.14f, 13f));
                DefinirFonte(lblNome, fonte);
                DefinirFonte(lblQtd, fonte);
                DefinirFonte(lblSubtotal, fonte);
                DefinirFonte(btnRemover, fonte);

                int lado = Math.Max(28, Math.Min(48, (int)(h * 0.40f)));
                btnRemover.Size = new Size(lado, lado);
                btnRemover.Location = new Point(
                    ClientSize.Width - lado - m,
                    (h - lado) / 2);

                lblNome.Location = new Point(m, m);
                lblNome.Size = new Size(
                    Math.Max(10, btnRemover.Left - 2 * m),
                    lblNome.Font.Height + 2);

                int yBaixo = h - lblQtd.Height - m;
                lblQtd.Location = new Point(m, yBaixo);
                lblSubtotal.Location = new Point(
                    btnRemover.Left - m - lblSubtotal.Width,
                    yBaixo);
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
            AjustarControles();
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