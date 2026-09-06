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
    public partial class frmRegistro_Cliente : Form
    {
        long i = 0;
        string cpformatado;
        public frmRegistro_Cliente()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (long.TryParse(textBox2.Text, out i) == false)
            {
                if(textBox2.Text.Length >= 1)
                {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length-1);
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.SelectionLength = 0;
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
            if (textBox2.Text.Length >= 11) 
            {
                textBox2.Text = textBox2.Text.Substring(0, 11);
                cpformatado = textBox2.Text.Substring(0, 3) + "." + textBox2.Text.Substring(3, 3) + "." + textBox2.Text.Substring(6, 3) + "-" + textBox2.Text.Substring(9, 2);
                textBox2.Text = cpformatado;
            }
            else 
            {
                MessageBox.Show("Valor inválido no Cpf");
            }
            
        }

        string FormatarCpf(string cpf) => $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";

    }
}
