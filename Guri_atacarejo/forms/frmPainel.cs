using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guri_atacarejo;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmPainel : Form
    {
        public frmPainel()
        {
            InitializeComponent();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogon logonForm = new FrmLogon();
            logonForm.ShowDialog();

            Sessao.NivelFuncionario = 0;
            Sessao.Usuario = null;
        }

        private void registrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdicionar adicionarForm = new frmAdicionar();
            adicionarForm.ShowDialog();
        }

        private void loginClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Senha = null;
        }
    }
}
