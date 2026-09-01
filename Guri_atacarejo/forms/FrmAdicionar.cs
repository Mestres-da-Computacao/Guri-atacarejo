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
    public partial class FrmAdicionar : Form
    {
        public FrmAdicionar()
        {
            InitializeComponent();
        }

        private void FrmAdicionar_Load(object sender, EventArgs e)
        {
            CardProduto cajuita = new CardProduto();

            cajuita.CodigoProduto = 1;
            cajuita.NomeProduto = "Cajuita 67 litros";
            cajuita.PrecoProduto = 67.00m;
            cajuita.ImagemProduto = Properties.Resources.Cajuita;

            cajuita.Click += Card_Click;

            flowLayoutPanel1.Controls.Add(cajuita);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            CardProduto card = (CardProduto)sender;

            txtCodigo.Text = card.CodigoProduto.ToString();

            MessageBox.Show("BANZAAAAAAI");
        }
    }
}
