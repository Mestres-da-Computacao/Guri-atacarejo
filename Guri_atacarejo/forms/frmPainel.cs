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
    public partial class frmPainel : Form
    {
        // get/set p receber os valores
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public frmPainel()
        {
            InitializeComponent();
        }

        public void AtualizarProduto(int id, string nome, decimal preco, int quantidade)
        {
            dataGridView1.Rows.Add(id, nome, quantidade, preco, (preco * quantidade)); // obs: falta exibir no datagridview. Ele adiciona o nmr de linha, mas n aparece no visual
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPainel_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // ------------------------------------------------------

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            frmTeste Adicionar = new frmTeste();
            Adicionar.painel = this;
            Adicionar.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
