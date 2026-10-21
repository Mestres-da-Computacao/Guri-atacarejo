using Guri_atacarejo.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Guri_atacarejo.forms
{
    public partial class FrmLoginCliente : Form
    {
        private bool cpfJacolocou = false;
        public FrmLoginCliente()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!cpfJacolocou)
            {
                textBox1.Text = "";
                cpfJacolocou = true;
            }
            else
            {
                return;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                textBox1.Text = "Digite o cpf";
                cpfJacolocou = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login(textBox1.Text);
        }

        private bool Login(string cpf)
        {
            var adapter = new GA_ClientesTableAdapter();
            var tabela = adapter.verifycpf(cpf);

            if (tabela.Rows.Count > 0)
            {
                Application.Run(new frmAdicionar());
                return true;
            }
            else
            {
                textBox1.Text = "Cpf não encontrado";
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}