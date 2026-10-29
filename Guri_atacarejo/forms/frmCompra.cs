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
            var produtos = new List<Tuple<int, string, decimal>>
    {
        Tuple.Create(1, "Arroz 5kg", 24.90m),
        Tuple.Create(2, "Feijão 1kg", 8.50m),
        Tuple.Create(3, "Óleo de Soja 900ml", 7.20m),
        Tuple.Create(4, "Açúcar 1kg", 4.75m),
        Tuple.Create(5, "Café 500g", 12.30m),
    };

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            foreach (var p in produtos)
            {
                var card = new CardTelaCompra();
                card.CarregarProduto(p.Item1, p.Item2, p.Item3);
                card.Margin = new Padding(0, 0, 0, 3);
                flowLayoutPanel1.Controls.Add(card);
            }

            flowLayoutPanel1.ResumeLayout();
        }
    }
}