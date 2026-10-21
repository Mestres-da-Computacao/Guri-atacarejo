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
    public partial class frmexibcaoentidades : Form
    {
        public frmexibcaoentidades()
        {
            InitializeComponent();
            cbent.SelectedIndex = 0;
            cbcar.SelectedIndex = 0;
        }

        private void cbent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbcar.Items.Clear();
            string selecionado = cbent.SelectedIndex.ToString();
            switch (selecionado)
            {
                case "0":
                    cbcar.Items.Add("Tudo");
                    cbcar.Items.Add("Nome");
                    cbcar.Items.Add("CPF");
                    cbcar.Items.Add("Idade");
                    cbcar.Items.Add("Cargo");
                    cbcar.Items.Add("Departamento");
                    cbcar.Items.Add("Gênero");
                    cbcar.Items.Add("Telefone");
                    cbcar.Items.Add("Nível");
                    cbcar.SelectedIndex = 0;
                    break;
                case "1":
                    cbcar.Items.Add("Tudo");
                    cbcar.Items.Add("Nome");
                    cbcar.Items.Add("CPF");
                    cbcar.Items.Add("Idade");
                    cbcar.Items.Add("Gênero");
                    cbcar.Items.Add("Celular");
                    cbcar.Items.Add("Total de Compras");
                    cbcar.SelectedIndex = 0;
                    break;
                case "2":
                    cbcar.Items.Add("Tudo");
                    cbcar.Items.Add("Nome");
                    cbcar.Items.Add("CNPJ");
                    cbcar.Items.Add("Telefone");
                    cbcar.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
