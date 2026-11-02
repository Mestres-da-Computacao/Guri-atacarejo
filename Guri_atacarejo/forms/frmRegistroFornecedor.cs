using System;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guri_atacarejo.DataSetTableAdapters;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistroFornecedor : Form
    {
        public frmRegistroFornecedor()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            textBox1.MaxLength = 100;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.TextChanged += textBox1_TextChanged;

            maskedTextBox1.Mask = "00.000.000/0000-00";
            maskedTextBox1.PromptChar = '_';

            textBox2.MaxLength = 100;

            maskedTextBox2.Mask = "(00) 00000-0000";
            maskedTextBox2.PromptChar = '_';

            textBox3.MaxLength = 200;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Any(char.IsDigit))
                return;

            textBox1.Text = new string(textBox1.Text.Where(caractere => !char.IsDigit(caractere)).ToArray());
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out string email))
                return;

            string telefone = maskedTextBox2.MaskCompleted ? maskedTextBox2.Text : null;

            try
            {
                GA_FornecedorTableAdapter fornecedorTableAdapter = new GA_FornecedorTableAdapter();

                if (fornecedorTableAdapter.CnpjJaCadastrado(maskedTextBox1.Text) > 0)
                {
                    MessageBox.Show(
                        "Já existe um fornecedor cadastrado com esse CNPJ.",
                        "CNPJ já cadastrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    maskedTextBox1.Focus();
                    return;
                }

                fornecedorTableAdapter.InsertQueryFornecedor(
                    textBox1.Text.Trim(),
                    maskedTextBox1.Text,
                    email,
                    telefone,
                    textBox3.Text.Trim());

                MessageBox.Show("Fornecedor registrado com sucesso!");

                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao registrar fornecedor: " + ex.Message);
            }
        }

        private bool ValidarCampos(out string email)
        {
            email = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return Erro("Informe o nome do fornecedor.", textBox1);

            if (!maskedTextBox1.MaskCompleted)
                return Erro("Informe um CNPJ completo.", maskedTextBox1);

            if (string.IsNullOrWhiteSpace(textBox3.Text))
                return Erro("Informe o endereço do fornecedor.", textBox3);

            int arroba = email.IndexOf('@');
            bool emailValido = arroba > 0
                && arroba == email.LastIndexOf('@')
                && email.IndexOf(' ') < 0
                && email.EndsWith(".com", StringComparison.OrdinalIgnoreCase)
                && email.Length > arroba + 5;

            return emailValido || Erro("Digite um e-mail válido com @ e domínio .com.", textBox2);
        }

        private void clear()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox2.Clear();
            maskedTextBox2.Clear();
            textBox3.Clear();
        }

        private bool Erro(string mensagem, Control campo)
        {
            MessageBox.Show(mensagem, "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPainel painel = new frmPainel();
            painel.ShowDialog();
        }
    }
}
