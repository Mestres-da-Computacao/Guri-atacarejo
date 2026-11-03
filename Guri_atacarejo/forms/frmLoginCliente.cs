using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Guri_atacarejo.forms
{
    public partial class FrmLoginCliente : Form
    {
        public FrmLoginCliente()
        {
            InitializeComponent();
        }

        //private void textBox1_Click(object sender, EventArgs e)
        //{
        //    if (!cpfJacolocou)
        //    {
        //        textBox1.Text = "";
        //        cpfJacolocou = true;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (textBox1.Text == "")
        //    {
        //        textBox1.Text = "Digite o cpf";
        //        cpfJacolocou = false;
        //    }
        //}
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
            var cpfNumerico = new string((cpf ?? string.Empty)
                .Where(digito => digito >= '0' && digito <= '9')
                .ToArray());
            if (cpfNumerico.Length != 11)
            {
                MessageBox.Show("Informe um CPF válido com 11 dígitos.");
                textBox1.Focus();
                return false;
            }

            const string query =
                @"SELECT IdCliente, Nome, CPF
                  FROM dbo.GA_Clientes
                  WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @CPF";
            using (SqlConnection connection = new SqlConnection(
                Properties.Settings.Default.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar, 11).Value = cpfNumerico;
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
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
