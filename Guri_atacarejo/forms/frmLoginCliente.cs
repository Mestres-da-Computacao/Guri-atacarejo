using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;
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
            ValidadorCPF validador = new ValidadorCPF();
            if (!validador.ValidarCPF(cpfNumerico))
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

        private bool formatandoCpf = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (formatandoCpf) return;   // evita chamar o evento de novo ao mudar o texto
            formatandoCpf = true;

            string digitos = Regex.Replace(textBox1.Text, @"\D", "");
            if (digitos.Length > 11)
                digitos = digitos.Substring(0, 11);

            string formatado = digitos;

            if (digitos.Length > 9)
                formatado = digitos.Substring(0, 3) + "." + digitos.Substring(3, 3) + "." +
                            digitos.Substring(6, 3) + "-" + digitos.Substring(9);
            else if (digitos.Length > 6)
                formatado = digitos.Substring(0, 3) + "." + digitos.Substring(3, 3) + "." +
                            digitos.Substring(6);
            else if (digitos.Length > 3)
                formatado = digitos.Substring(0, 3) + "." + digitos.Substring(3);

            textBox1.Text = formatado;
            textBox1.SelectionStart = textBox1.Text.Length;   // cursor sempre no final

            formatandoCpf = false;
        }
    }
}
