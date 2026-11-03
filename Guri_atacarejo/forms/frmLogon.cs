using Guri_atacarejo.DataSetTableAdapters;
using Guri_atacarejo;
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
    public partial class FrmLogon : Form
    {
        // OBS: não precisa mais de userJacolocou / passJacolocou,
        // o placeholder agora é nativo dentro do CampoTexto.

        public FrmLogon()
        {
            InitializeComponent();

            // Placeholders e modo senha (pode ser feito pelo Designer também)
            Usertxtbox.PlaceholderText = "Digite o usuário";
            Passwordtxtbox.PlaceholderText = "Digite sua senha";
            Passwordtxtbox.IsPassword = true;   // oculta com bolinhas + botão de olho

            // Enter no campo de senha = clicar em Entrar
            Passwordtxtbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnEntrar.PerformClick();
                }
            };

            ResponsividadeForm.Aplicar(this);
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            bool sucesso = Login(Usertxtbox.Text, Passwordtxtbox.Text);

            if (sucesso)
            {
                this.Hide();
                using (frmPainel painel = new frmPainel())
                    painel.ShowDialog(this);

                Sessao.NivelFuncionario = 0;
                Sessao.IdFuncionario = 0;
                Sessao.Usuario = null;
                SessaoClientes.NomeCliente = null;
                SessaoClientes.Cpf = null;
                SessaoClientes.IdCliente = 0;

                Usertxtbox.Text = "";
                Passwordtxtbox.Text = "";
                Passwordtxtbox.MostrarSenha = false;   // volta a ocultar a senha
                this.Show();
            }
            else
            {
                MessageBox.Show("Login inválido. Verifique seu usuário e senha.");
            }
        }

        private void BtnRecupSenha_Click(object sender, EventArgs e)
        {

        }

        private bool Login(string username, string senha)
        {
            var connectionString = new SqlConnectionStringBuilder(
                Properties.Settings.Default.ConnectionString)
            {
                InitialCatalog = "db_250405"
            }.ConnectionString;

            var adapter = new GA_FuncionariosTableAdapter();
            adapter.Connection.ConnectionString = connectionString;
            var tabela = adapter.VerifyNomeAndSenha(username, senha);

            if (tabela.Rows.Count > 0)
            {
                var adapterNivel = new GA_FuncionariosTableAdapter();
                adapterNivel.Connection.ConnectionString = connectionString;
                var tabelaNivel = adapterNivel.GetNivelFuncionario(username);

                if (tabelaNivel.Rows.Count > 0)
                {
                    Sessao.NivelFuncionario =
                        Convert.ToInt32(tabelaNivel.Rows[0]["FKCargo"]);

                    Sessao.IdFuncionario =
                        Convert.ToInt32(tabela.Rows[0]["IdFuncionario"]);
                    Sessao.Usuario = username;
                }

                return true;
            }

            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
            "Deseja realmente sair?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}