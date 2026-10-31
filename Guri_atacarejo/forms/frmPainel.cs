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

            ResponsividadeForm.Aplicar(this);

            // Tabelas sem a linha vazia de "nova linha" e sem a coluna de seta
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;

            Console.WriteLine("Nível do funcionário: " + Sessao.NivelFuncionario);
            Console.WriteLine("Cliente logado: " + SessaoClientes.NomeCliente);
            Console.WriteLine("CPF do cliente: " + SessaoClientes.Cpf);

            if (Sessao.NivelFuncionario <= 1)
            {
                registrarFuncionárioToolStripMenuItem.Visible = false;
            }
            else if (Sessao.NivelFuncionario > 1)
            {
                registrarFuncionárioToolStripMenuItem.Visible = true;
            }
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
            this.Hide();
            frmLoginCliente frmLoginCliente = new frmLoginCliente();
            frmLoginCliente.ShowDialog();
        }

        private void logoutClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Cpf = null;

            Console.WriteLine("Cliente logado: " + SessaoClientes.NomeCliente);
            Console.WriteLine("CPF do cliente: " + SessaoClientes.Cpf);
        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistro_Cliente registroClienteForm = new frmRegistro_Cliente();
            registroClienteForm.ShowDialog();
        }

        private void registrarFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastroFuncionario cadastroFuncionarioForm = new frmCadastroFuncionario();
            cadastroFuncionarioForm.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}