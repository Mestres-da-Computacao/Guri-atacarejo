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
        bool cpffoiformatado = false;
        public frmRegistro_Cliente()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 14) 
            {
                textBox2.Text = textBox2.Text.Substring(0, 14);
                if (textBox2.Text[3].ToString() == "." && textBox2.Text[7].ToString() == "." && textBox2.Text[11].ToString() == "-" && textBox2.Text.Length == 14)
                {
                    cpffoiformatado = true;
                }
            }
            else 
            {
                cpffoiformatado = false;
            }
            if (textBox2.Text.Length >= 11 && !cpffoiformatado)
            {
                textBox2.Text = textBox2.Text.Substring(0, 11);
                if (long.TryParse(textBox2.Text, out i))
                {
                    cpformatado = textBox2.Text.Substring(0, 3) + "." + textBox2.Text.Substring(3, 3) + "." + textBox2.Text.Substring(6, 3) + "-" + textBox2.Text.Substring(9, 2);
                    textBox2.Text = cpformatado;
                    cpffoiformatado = true;
                }
                else
                {
                    MessageBox.Show("Valor inválido no Cpf");
                    cpffoiformatado = false;
                    textBox2.Text = string.Empty;
                }
            }
            else if (!cpffoiformatado)
            {
                MessageBox.Show("Valor inválido no Cpf");
                cpffoiformatado = false;
                textBox2.Text = string.Empty;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cpffoiformatado = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
