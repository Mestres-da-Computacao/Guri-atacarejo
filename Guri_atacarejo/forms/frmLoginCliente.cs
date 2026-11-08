using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class FrmLoginCliente : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(System.Drawing.Color fundo, System.Drawing.Color texto)
        {
            // O DWM espera o formato COLORREF: 0x00BBGGRR
            int corFundo = fundo.R | (fundo.G << 8) | (fundo.B << 16);
            int corTexto = texto.R | (texto.G << 8) | (texto.B << 16);

            DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref corFundo, sizeof(int));
            DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref corTexto, sizeof(int));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Barra do form com a mesma cor do fundo; texto branco (ou preto se o fundo for claro)
            System.Drawing.Color fundo = BackColor;
            bool escuro = fundo.GetBrightness() < 0.6f;
            DefinirCorBarra(fundo, escuro ? System.Drawing.Color.White : System.Drawing.Color.Black);
        }

        public FrmLoginCliente()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            ResponsividadeForm.Aplicar(this);

            this.Text = "Login do Cliente";
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
                        SelecionarTudoCpf();
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

            // só reescreve se mudou (evita o cursor pular sem necessidade)
            if (textBox1.Text != formatado)
                textBox1.Text = formatado;

            ColocarCursorNoFimCpf();   // cursor sempre no final

            formatandoCpf = false;
        }

        // ------------------------------------------------------------------
        // O CampoTexto não tem SelectAll nem SelectionStart (isso é do TextBox).
        // Por isso procuramos a caixa de texto que fica dentro dele e usamos ela.
        // ------------------------------------------------------------------
        private TextBox CaixaDoCpf()
        {
            return AcharTextBox(textBox1);
        }

        private static TextBox AcharTextBox(Control pai)
        {
            foreach (Control filho in pai.Controls)
            {
                TextBox caixa = filho as TextBox;
                if (caixa != null) return caixa;

                caixa = AcharTextBox(filho);
                if (caixa != null) return caixa;
            }
            return null;
        }

        private void SelecionarTudoCpf()
        {
            TextBox caixa = CaixaDoCpf();
            if (caixa != null) caixa.SelectAll();
        }

        private void ColocarCursorNoFimCpf()
        {
            TextBox caixa = CaixaDoCpf();
            if (caixa != null) caixa.SelectionStart = caixa.Text.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}