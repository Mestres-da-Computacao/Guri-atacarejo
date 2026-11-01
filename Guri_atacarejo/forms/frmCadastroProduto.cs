using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Guri_atacarejo.forms
{
    public partial class frmCadastroProduto : Form
    {
        private readonly string conecta = @"Server=(localdb)\MSSQLLocalDB;Database=SuperMercado;Trusted_Connection=True;";
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

            Load += (s, e) =>
            {
                _tamanhoOriginal = ClientSize;   // 950 x 526 do designer
                GuardarOriginais(this);
                WindowState = FormWindowState.Maximized;
            };

            Resize += (s, e) => Redimensionar();
        }

        private void GuardarOriginais(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                _originais[c] = new Original { Bounds = c.Bounds, FontSize = c.Font.Size };
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
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text) ||
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                MessageBox.Show("Por favor, preencha todos os dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO Produtos (Nome, Preco, Descricao, Quantidade, FKCategoria) " +
                       "VALUES (@Nome, @Preco, @Descricao, @Quantidade, @Categoria)";

            using (SqlConnection conexao = new SqlConnection(conecta))
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                    comando.Parameters.AddWithValue("@Preco", Convert.ToDecimal(txtPreco.Text));
                    comando.Parameters.AddWithValue("@Descricao", txtDescricao.Text.Trim());
                    comando.Parameters.AddWithValue("@Quantidade", Convert.ToInt32(txtQuantidade.Text));
                    comando.Parameters.AddWithValue("@Categoria", cmbCategoria.SelectedItem?.ToString() ?? "Geral");

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
            txtNome.Clear();
            txtPreco.Clear();
            txtDescricao.Clear();
            txtQuantidade.Text = "";
            cmbCategoria.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpacampos();
        }
        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                return;
            }

            if (e.KeyChar == ',' && !txtPreco.Text.Contains(","))
            {
                return;
            }
            e.Handled = true;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                return;
            }
            e.Handled = true;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT FKCategoria from GA_Produtos";
            using (SqlConnection conexao = new SqlConnection(conecta))
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexao);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "FKCategoria";
            }

        }
    }
}

