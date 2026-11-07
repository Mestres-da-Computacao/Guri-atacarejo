using Guri_atacarejo.DataSetTableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmCadastroFuncionario : Form
    {
        private DataSet guriDataSet = new DataSet();

        private DataSetTableAdapters.GA_DepartamentosTableAdapter
            gA_DepartamentosTableAdapter =
            new DataSetTableAdapters.GA_DepartamentosTableAdapter();

        private DataSetTableAdapters.GA_CargosTableAdapter
            gA_CargosTableAdapter =
            new DataSetTableAdapters.GA_CargosTableAdapter();

        private DataSetTableAdapters.GA_FuncionariosTableAdapter
            gA_FuncionariosTableAdapter =
            new DataSetTableAdapters.GA_FuncionariosTableAdapter();

        public frmCadastroFuncionario()
        {
            InitializeComponent();

            ResponsividadeForm.Aplicar(this);

            this.Load += FormFuncionarios_Load;

            txtNome.MaxLength = 100;
            txtEmail.MaxLength = 100;
            txtSenha.MaxLength = 255;

            // SENHA COM BOLINHAS E BOTÃO DE OLHO
            txtSenha.IsPassword = true;
            txtSenha.MostrarSenha = false;

            maskedtxtCpf.Mask = "000.000.000-00";
            maskedtxtTelefone.Mask = "(00) 00000-0000";

            // Data de nascimento não pode ser no futuro
            dateTimePickerDataNasc.MaxDate = DateTime.Today;

            // (as cores dos combos agora vêm do próprio CampoCombo)
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            // Departamentos
            gA_DepartamentosTableAdapter.Fill(
                guriDataSet.GA_Departamentos
            );

            cbDepartamento.DataSource = guriDataSet.GA_Departamentos;
            cbDepartamento.DisplayMember = "Nome";
            cbDepartamento.ValueMember = "IdDepartamento";
            cbDepartamento.SelectedIndex = -1;

            // Cargos
            gA_CargosTableAdapter.Fill(
                guriDataSet.GA_Cargos
            );

            cbCargo.DataSource = guriDataSet.GA_Cargos;
            cbCargo.DisplayMember = "Nome";
            cbCargo.ValueMember = "IdCargo";
            cbCargo.SelectedIndex = -1;
        }

        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            try
            {
                var endereco = new MailAddress(email);

                if (endereco.Address != email)
                    return false;

                string dominio = endereco.Host;

                return dominio.Contains(".")
                    && !dominio.StartsWith(".")
                    && !dominio.EndsWith(".")
                    && dominio.Split('.').Last().Length >= 2;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string genero =
                radioButtonHomem.Checked ? "M" :
                radioButtonMulher.Checked ? "F" : "O";

            string telefone = maskedtxtTelefone.MaskCompleted
                ? maskedtxtTelefone.Text
                : null;

            string email = string.IsNullOrWhiteSpace(txtEmail.Text)
                ? null
                : txtEmail.Text.Trim();

            string nomeFuncionario = txtNome.Text.Trim();

            try
            {
                gA_FuncionariosTableAdapter.InsertQueryFuncionarios(
                    Convert.ToInt32(cbCargo.SelectedValue),
                    Convert.ToInt32(cbDepartamento.SelectedValue),
                    nomeFuncionario,
                    maskedtxtCpf.Text,
                    dateTimePickerDataNasc.Value.Date,
                    genero,
                    telefone,
                    email,
                    txtSenha.Text,
                    DateTime.Today,
                    numericUpDownSalario.Value
                );

                MessageBox.Show(
                    "Funcionário cadastrado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();
                Close();
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Já existe um funcionário com esse CPF.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidarCampos()
        {
            if (txtNome.Text.Trim().Length < 3)
                return Erro(
                    "Digite o nome (mínimo 3 caracteres).",
                    txtNome
                );

            if (!maskedtxtCpf.MaskCompleted)
                return Erro("CPF incompleto.", maskedtxtCpf);

            ValidadorCPF validador = new ValidadorCPF();

            if (!validador.ValidarCPF(maskedtxtCpf.Text))
                return Erro("CPF inválido.", maskedtxtCpf);

            if (!dateTimePickerDataNasc.DataValida)
                return Erro(
                    "Data de nascimento inválida.\nEx: 25/12/1990",
                    dateTimePickerDataNasc
                );

            if (maskedtxtTelefone.Text.Any(char.IsDigit)
                && !maskedtxtTelefone.MaskCompleted)
            {
                return Erro("Telefone incompleto.", maskedtxtTelefone);
            }

            if (txtEmail.Text.Trim() != ""
                && !EmailValido(txtEmail.Text))
            {
                return Erro(
                    "E-mail inválido ou incompleto.\nEx: nome@dominio.com",
                    txtEmail
                );
            }

            if (txtSenha.Text.Length < 6)
                return Erro(
                    "A senha deve ter pelo menos 6 caracteres.",
                    txtSenha
                );

            if (cbDepartamento.SelectedIndex < 0
                || cbCargo.SelectedIndex < 0)
            {
                return Erro(
                    "Selecione o departamento e o cargo.",
                    cbDepartamento
                );
            }

            if (numericUpDownSalario.Value <= 0)
                return Erro(
                    "Informe um salário maior que zero.",
                    numericUpDownSalario
                );

            if (!radioButtonHomem.Checked
                && !radioButtonMulher.Checked
                && !radioButtonOutro.Checked)
            {
                return Erro("Selecione o gênero.", radioButtonHomem);
            }

            return true;
        }

        private bool Erro(string mensagem, Control campo)
        {
            MessageBox.Show(
                mensagem,
                "Campo inválido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            campo.Focus();
            return false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";

            // Sempre voltar a esconder a senha
            txtSenha.MostrarSenha = false;

            maskedtxtCpf.Text = "";
            maskedtxtTelefone.Text = "";

            numericUpDownSalario.Value =
                numericUpDownSalario.Minimum;

            dateTimePickerDataNasc.Limpar();

            cbDepartamento.SelectedIndex = -1;
            cbCargo.SelectedIndex = -1;

            radioButtonHomem.Checked = false;
            radioButtonMulher.Checked = false;
            radioButtonOutro.Checked = false;

            txtNome.Focus();
        }
        private void maskedtxtCpf_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
        { }

        private void campoTexto1_TextChanged(object sender, EventArgs e) { }

        private void maskedtxtTelefone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}