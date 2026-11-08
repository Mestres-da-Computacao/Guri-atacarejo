using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace Guri_atacarejo.forms
{
    public partial class frmCadastroProduto : Icone
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

        const int CategoriaPadrao = 1;   // categoria sempre 1 no INSERT
        private readonly string conecta = global::Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        private class Original
        {
            public Rectangle Bounds;
            public float FontSize;
        }

        private readonly Dictionary<Control, Original> _originais = new Dictionary<Control, Original>();
        private Size _tamanhoOriginal;

        public frmCadastroProduto()
        {
            InitializeComponent();

            ConfigurarUnidadeMedida();

            Load += (s, e) =>
            {
                _tamanhoOriginal = ClientSize;   // 950 x 526 do designer
                GuardarOriginais(this);
                WindowState = FormWindowState.Maximized;
            };

            Resize += (s, e) => Redimensionar();

            this.Text = "Cadastro de produtos";
        }

        private void ConfigurarUnidadeMedida()
        {
            // Só dá para escolher um item da lista, não dá para digitar
            cmbunidademedida.DataSource = new[]
            {
                "UN", "KG", "G", "L", "ML", "CX", "PCT", "FD"
            };

            cmbunidademedida.SelectedIndex = -1;
        }

        private void GuardarOriginais(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                _originais[c] = new Original { Bounds = c.Bounds, FontSize = c.Font.Size };

                // Os campos Guri se ajustam sozinhos por dentro: não mexe nos controles internos deles
                if (c is CampoBase || c is CampoTexto)
                    continue;

                GuardarOriginais(c);
            }
        }

        private void Redimensionar()
        {
            if (_tamanhoOriginal.IsEmpty || ClientSize.Width == 0 || ClientSize.Height == 0)
                return;

            float sx = (float)ClientSize.Width / _tamanhoOriginal.Width;
            float sy = (float)ClientSize.Height / _tamanhoOriginal.Height;
            float sFonte = Math.Min(sx, sy);   // fonte segue o menor fator pra não estourar

            SuspendLayout();
            foreach (var par in _originais)
            {
                Control c = par.Key;
                Original o = par.Value;

                c.Bounds = new Rectangle(
                    (int)(o.Bounds.X * sx),
                    (int)(o.Bounds.Y * sy),
                    (int)(o.Bounds.Width * sx),
                    (int)(o.Bounds.Height * sy));

                c.Font = new Font(c.Font.FontFamily, o.FontSize * sFonte, c.Font.Style);
            }
            ResumeLayout(true);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, preencha o nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // O CampoNumero já só aceita número; vazio = 0
            decimal preco = txtPreco.Value;
            if (preco <= 0)
            {
                MessageBox.Show("Informe um preço válido (ex.: 12,50).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return;
            }

            if (cmbunidademedida.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a unidade de medida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbunidademedida.Focus();
                return;
            }

            string sql = "INSERT INTO GA_Produtos (FKCategoria, Nome, UnidadeMedida, Preco) " +
                       "VALUES (@Categoria, @Nome, @Unidade, @Preco)";

            using (SqlConnection conexao = new SqlConnection(conecta))
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.Add("@Nome", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();

                    var pPreco = comando.Parameters.Add("@Preco", SqlDbType.Decimal);
                    pPreco.Precision = 10;
                    pPreco.Scale = 2;
                    pPreco.Value = preco;

                    comando.Parameters.Add("@Categoria", SqlDbType.Int).Value = CategoriaPadrao;
                    comando.Parameters.Add("@Unidade", SqlDbType.VarChar, 20).Value = cmbunidademedida.SelectedItem.ToString();

                    try
                    {
                        conexao.Open();
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("O produto foi registrado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpacampos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ou salvar no banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void limpacampos()
        {
            txtNome.Text = "";
            txtPreco.Value = txtPreco.Minimum;
            txtDescricao.Clear();
            cmbunidademedida.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpacampos();
            Close();
        }

        // ---------------------------------------------------------------
        // Métodos vazios mantidos só para o Designer não reclamar caso ainda
        // existam ligações antigas a eles. O CampoNumero já faz o trabalho
        // (aceita só número e vírgula, e mostra o "R$" fixo).
        // Pode apagar estes métodos junto com as ligações no Designer.cs.
        // ---------------------------------------------------------------
        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e) { }

        private void txtPreco_KeyDown(object sender, KeyEventArgs e) { }

        private void txtPreco_TextChanged(object sender, EventArgs e) { }

        private void txtPreco_Click(object sender, EventArgs e) { }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }
    }
}