using Guri_atacarejo.DataSetTableAdapters;
using Guri_atacarejo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class FrmLogon : Form
    {
        private bool userJacolocou = false;
        private bool passJacolocou = false;
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void Usertxtbox_Click(object sender, EventArgs e)
        {
            if (!userJacolocou)
            {
                Usertxtbox.Text = "";
                userJacolocou = true;
            }
            else
            {
                return;
            }
        }

        private void Usertxtbox_Leave(object sender, EventArgs e)
        {
            if(Usertxtbox.Text == "") 
            {
                Usertxtbox.Text = "Digite o usuário";
                userJacolocou = false;
            }
        }

        private void Passwordtxtbox_Click(object sender, EventArgs e)
        {
            if (!passJacolocou)
            {
                Passwordtxtbox.Text = "";
                passJacolocou = true;
            }
            else
            {
                return;
            }
        }

        private void Passwordtxtbox_Leave(object sender, EventArgs e)
        {
            if (Passwordtxtbox.Text == "")
            {
                Passwordtxtbox.Text = "Digite sua senha";
                passJacolocou = false;
            }
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            bool sucesso = Login(Usertxtbox.Text, Passwordtxtbox.Text);

            if (sucesso)
            {
                this.Hide();
                frmPainel painel = new frmPainel();
                painel.ShowDialog();
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
            var adapter = new GA_FuncionariosTableAdapter();
            var tabela = adapter.VerifyNomeAndSenha(username, senha);

            if (tabela.Rows.Count > 0)
            {
                var adapterNivel = new GA_FuncionariosTableAdapter();
                var tabelaNivel = adapterNivel.GetNivelFuncionario(username);

                if (tabelaNivel.Rows.Count > 0)
                {
                    Sessao.NivelFuncionario =
                        Convert.ToInt32(tabelaNivel.Rows[0]["FKCargo"]);

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
