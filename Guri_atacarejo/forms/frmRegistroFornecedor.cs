using System;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guri_atacarejo.DataSetTableAdapters;

namespace Guri_atacarejo.forms
{
    public partial class frmRegistroFornecedor : Icone
    {
        public frmRegistroFornecedor()
        {
            InitializeComponent();
            button2.Click += button2_Click;
            button1.Click += button1_Click;

            ResponsividadeForm.Aplicar(this);

            textBox1.MaxLength = 100;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.TextChanged += textBox1_TextChanged;

            // PromptChar removido: CampoMascara nao expoe essa propriedade.
            // Se quiser '_', defina dentro da classe CampoMascara.
            maskedTextBox1.Mask = "00.000.000/0000-00";

            textBox2.MaxLength = 100;

            maskedTextBox2.Mask = "(00) 00000-0000";

            textBox3.MaxLength = 200;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Remove digitos colados (ex.: Ctrl+V). SelectionStart removido,
            // pois CampoTexto nao expoe essa propriedade.
            if (!textBox1.Text.Any(char.IsDigit))
                return;

            textBox1.Text = new string(textBox1.Text.Where(caractere => !char.IsDigit(caractere)).ToArray());
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

            if (!ValidarCNPJ(maskedTextBox1.Text))
                return Erro("Informe um CNPJ válido.", maskedTextBox1);

            if (string.IsNullOrWhiteSpace(textBox3.Text))
                return Erro("Informe o endereço do fornecedor.", textBox3);

            int arroba = email.IndexOf('@');
            bool emailValido = arroba > 0
                && arroba == email.LastIndexOf('@')
                && email.IndexOf(' ') < 0
                && email.IndexOf('.', arroba) > arroba + 1
                && !email.EndsWith(".");

            return emailValido || Erro("Digite um e-mail válido. Ex: nome@dominio.com", textBox2);
        }

        // Validador de CNPJ (o ValidadorCPF nao serve: CPF tem 11 digitos, CNPJ tem 14)
        private static bool ValidarCNPJ(string cnpj)
        {
            string digitos = new string((cnpj ?? "").Where(char.IsDigit).ToArray());

            if (digitos.Length != 14)
                return false;

            // Rejeita sequencias repetidas (00000000000000, 11111111111111, ...)
            if (digitos.Distinct().Count() == 1)
                return false;

            int[] peso1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] peso2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int d1 = CalcularDigitoCNPJ(digitos, peso1);
            int d2 = CalcularDigitoCNPJ(digitos, peso2);

            return digitos[12] - '0' == d1 && digitos[13] - '0' == d2;
        }

        private static int CalcularDigitoCNPJ(string digitos, int[] pesos)
        {
            int soma = 0;
            for (int i = 0; i < pesos.Length; i++)
                soma += (digitos[i] - '0') * pesos[i];

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        private void clear()
        {
            // Clear() nao existe nos controles customizados; usa-se Text = "".
            // Se algum campo mascarado nao limpar, adicione um metodo Clear()
            // em CampoMascara que chame o Clear() do MaskedTextBox interno.
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox2.Text = "";
            textBox3.Text = "";
        }

        private bool Erro(string mensagem, Control campo)
        {
            MessageBox.Show(mensagem, "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}