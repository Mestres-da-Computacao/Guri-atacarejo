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
        public CardProduto()
        {
            InitializeComponent();

            imagem.Click += (s, e) => this.OnClick(e);
            lblNome.Click += (s, e) => this.OnClick(e);
            lblPreco.Click += (s, e) => this.OnClick(e);
        }

        public string NomeProduto
        {
            get { return lblNome.Text; }
            set { lblNome.Text = value; }
        }

        public decimal PrecoProduto
        {
            get
            {
                decimal.TryParse(
                    lblPreco.Text.Replace("R$", ""),
                    out decimal valor
                );

                return valor;
            }

            set
            {
                lblPreco.Text = value.ToString("C2");
            }
        }

        public Image ImagemProduto
        {
            get { return imagem.Image; }
            set { imagem.Image = value; }
        }

        public int CodigoProduto { get; set; }
    }
}
