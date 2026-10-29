using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistro_Cliente : Form
    {

        string lastTecla;
        long i = 0;
        string cpformatado;
        bool cpffoiformatado = false;
        public frmRegistro_Cliente()
        {
            InitializeComponent();
        }
        

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            cpffoiformatado = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        bool formatando = false;

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            if (formatando)
                return;

            formatando = true;

            string valor = txtCPF.Text.Replace(".", "").Replace("-", "");
            int tamanho = valor.Length;
            if (lastTecla != "Back")
            {
                if (valor.Length > 11)
                    valor = valor.Substring(0, 11);

                if (valor.Length >= 10)
                {
                    txtCPF.Text = valor.Substring(0, 3) + "." +
                                  valor.Substring(3, 3) + "." +
                                  valor.Substring(6, 3) + "-" +
                                  valor.Substring(9, tamanho - 9);

                }
                else if (valor.Length >= 7)
                {
                    txtCPF.Text = valor.Substring(0, 3) + "." +
                                  valor.Substring(3, 3) + "." +
                                  valor.Substring(6);
                }
                else if (valor.Length >= 4)
                {
                    txtCPF.Text = valor.Substring(0, 3) + "." +
                                  valor.Substring(3);
                }
                else
                {
                    txtCPF.Text = valor;
                }
                txtCPF.SelectionStart = txtCPF.Text.Length;
            }

            formatando = false;
        }
        

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            if (formatando)
                return;

            formatando = true;

            string valor = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            

            if (valor.Length > 11) 
            {
                valor = valor.Substring(0, 11);
            }

            if (lastTecla != "Back")
            {
                if (valor.Length >= 7 && txtTelefone.Focused)
                {
                    int r = 4; //r é so um ponto de referencia p saber a posição onde vai colocar o hifen
                    if (txtTelefone.Text.Length > 14)
                    {
                        r = 5;
                    }
                    txtTelefone.Text = "(" +
                                       valor.Substring(0, 2) + ") " +
                                       valor.Substring(2, r) + "-" +
                                       valor.Substring(2 + r);
                    
                }
                else if (valor.Length >= 3)
                {
                    txtTelefone.Text = "(" +
                                       valor.Substring(0, 2) + ") " +
                                       valor.Substring(2);
                }
                else if (valor.Length >= 1)
                {
                    txtTelefone.Text = "(" + valor;
                }
                else
                {
                    txtTelefone.Text = valor;
                }

                txtTelefone.SelectionStart = txtTelefone.Text.Length;
            }

            formatando = false;
        }
        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            lastTecla = e.KeyCode.ToString();
        }
        private void txtCPF_KeyDown(object sender, KeyEventArgs e)
        {
           
            lastTecla = e.KeyCode.ToString();
           
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            string camposVazios = "";
            bool erro = false;
            if (!rbHomem.Checked && !rbMulher.Checked && !rbOutro.Checked)
            {
                camposVazios += "Gênero\n";
                erro = true;
            }
            else
            {
                erro = false;
            }

            foreach (Control controle in groupBox1.Controls)
            {
                if (controle is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    erro = true;
                    camposVazios += controle.Name.ToString().Remove(0, 3) + "\n";
                    Console.WriteLine(camposVazios);
                    controle.BackColor = Color.FromArgb(255, 146, 146);

                    if (controle is GroupBox)
                    {
                        //mudar p mudar a cor da groupbox Genero
                    }
                }
                else
                {
                    if (controle is TextBox)
                    {
                        controle.BackColor = Color.White;
                    }
                    else if (controle is GroupBox)
                    {
                        //mudar p mudar a cor da groupbox Genero
                    }
                }
            }

            if (erro)
            {
                MessageBox.Show("Preencha os campos vazios:\n\n" + camposVazios);
            }

            if (!erro && camposVazios == "")
            {
                if (txtCPF.Text.Length != 14)
                {
                    MessageBox.Show("CPF digitado incorretamente\n\nCPF deve conter 14 caracteres \n\nEx: 123.456.789-00");
                    txtCPF.BackColor = Color.FromArgb(255, 146, 146);
                    erro = true;
                    
                }
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".com"))
                {
                    MessageBox.Show("Email digitado incorretamente\n Email deve conter @ e .com");
                    txtEmail.BackColor = Color.FromArgb(255, 146, 146);
                    erro = true;
                    
                }
                if (txtTelefone.Text.Length < 14)
                {
                    MessageBox.Show("Telefone digitado incorretamente\n\n Ex: (12) 34567-8901 ou (12) 3456-7890");
                    txtTelefone.BackColor = Color.FromArgb(255, 146, 146);
                    erro = true;
                    
                }
                if (!erro) 
                {
                    string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SuperMercado;Trusted_Connection=True;TrustServerCertificate=True;";

                    string query = "INSERT INTO GA_Clientes (Nome, CPF, Genero, Email, Celular) VALUES (@Nome, @CPF, @Gen, @Email, @Celular)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", txtNome.Text);
                            command.Parameters.AddWithValue("@CPF", txtCPF.Text);
                            command.Parameters.AddWithValue("@Gen", rbHomem.Checked ? "M" : rbMulher.Checked ? "F" : "O");
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);
                            command.Parameters.AddWithValue("@Celular", txtTelefone.Text);

                            connection.Open();

                            int linhasAfetadas = command.ExecuteNonQuery();

                            Console.WriteLine($"{linhasAfetadas} linha(s) inserida(s) com sucesso.");

                            MessageBox.Show("Cliente registrado com sucesso!");
                        }
                    }
                }
            }

        }

    }
}
