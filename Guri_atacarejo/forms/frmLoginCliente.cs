using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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
            if (textBox1.Text == "")
            {
                textBox1.Text = "Digite o cpf";
                cpfJacolocou = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login(textBox1.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível consultar o cliente: " + ex.Message);
            }
        }

        private bool Login(string cpf)
        {
            cpf = cpf.Trim();
            if (string.IsNullOrWhiteSpace(cpf) || cpf == "Digite o cpf")
            {
                MessageBox.Show("Informe o CPF do cliente.");
                textBox1.Focus();
                return false;
            }

            const string query =
                "SELECT IdCliente, Nome, CPF FROM dbo.GA_Clientes WHERE CPF = @CPF";
            using (SqlConnection connection = new SqlConnection(
                Properties.Settings.Default.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CPF", cpf);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("CPF não encontrado.");
                        textBox1.Focus();
                        textBox1.SelectAll();
                        return false;
                    }

                    SessaoClientes.IdCliente = reader.GetInt32(0);
                    SessaoClientes.NomeCliente = reader.GetString(1);
                    SessaoClientes.Cpf = reader.GetString(2);
                    return true;
                }
            }
        }
        //private bool Login(string cpf)
        //{
        //    var adapter = new GA_ClientesTableAdapter();
        //    var tabela = adapter.verifycpf(cpf);

        //    if (tabela.Rows.Count > 0)
        //    {
        //        Application.Run(new frmAdicionar());
        //        return true;
        //    }
        //    else
        //    {
        //        textBox1.Text = "Cpf não encontrado";
        //        return false;
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
