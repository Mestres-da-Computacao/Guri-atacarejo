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
    public partial class frmCadastroFuncionario : Form
    {
        
        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ComboBDep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbdep_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbcargo.Items.Clear();
            string selecionado = cbdep.SelectedIndex.ToString();
            switch (selecionado){
                case "0":
                    cbcargo.Items.Add("Gerente Geral");
                    cbcargo.Items.Add("Subgerente");
                    break;
                case "1":
                    cbcargo.Items.Add("Operador de Caixa");
                    cbcargo.Items.Add("Fiscal de Caixa");
                    break;
                case "2":
                    cbcargo.Items.Add("Repositor");
                    cbcargo.Items.Add("Padeiro");
                    cbcargo.Items.Add("Açougueiro");
                    break;
                case "3":
                    cbcargo.Items.Add("Estoquista");
                    cbcargo.Items.Add("Conferente");
                    break;
                case "4":
                    cbcargo.Items.Add("Recursos Humanos");
                    cbcargo.Items.Add("Limpeza");
                    break;
                default:
                    break;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
