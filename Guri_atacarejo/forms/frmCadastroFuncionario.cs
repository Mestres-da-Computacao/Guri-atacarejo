using Guri_atacarejo.DataSet1TableAdapters;
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
    public partial class frmCadastroFuncionario : Form
    {
        
        public frmCadastroFuncionario()
        {
            InitializeComponent();
            this.Load += FormFuncionarios_Load;

            // se deixar dentro dos eventos não funciona
            txtNome.MaxLength = 100;   // Nome
            txtEmail.MaxLength = 100;   // E-mail
            txtSenha.MaxLength = 255;   // Senha

            maskedtxtCpf.Mask = "000.000.000-00";
            maskedtxtTelefone.Mask = "(00) 00000-0000";

            cbDepartamento.ForeColor = Color.Black;
            cbCargo.ForeColor = Color.Black;
        }

        private DataSet1 guriDataSet = new DataSet1();
        private DataSet1TableAdapters.GA_DepartamentosTableAdapter gA_DepartamentosTableAdapter = new DataSet1TableAdapters.GA_DepartamentosTableAdapter();
        private DataSet1TableAdapters.GA_CargosTableAdapter gA_CargosTableAdapter = new DataSet1TableAdapters.GA_CargosTableAdapter();

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            // dptos
            this.gA_DepartamentosTableAdapter.Fill(this.guriDataSet.GA_Departamentos);
            cbDepartamento.DataSource = this.guriDataSet.GA_Departamentos;
            cbDepartamento.DisplayMember = "Nome";
            cbDepartamento.ValueMember = "IdDepartamento";
            cbDepartamento.SelectedIndex = -1;

            // cargos
            this.gA_CargosTableAdapter.Fill(this.guriDataSet.GA_Cargos);
            cbCargo.DataSource = this.guriDataSet.GA_Cargos;
            cbCargo.DisplayMember = "Nome";
            cbCargo.ValueMember = "IdCargo";
            cbCargo.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private DataSet1TableAdapters.GA_FuncionariosTableAdapter gA_FuncionariosTableAdapter = new DataSet1TableAdapters.GA_FuncionariosTableAdapter();

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // radio bnts
            string genero = radioButtonHomem.Checked ? "M" : radioButtonMulher.Checked ? "F" : "O";

            // Campos opcionais: null vira NULL no banco
            string telefone = maskedtxtTelefone.MaskCompleted ? maskedtxtTelefone.Text : null;
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();

            try
            {
                gA_FuncionariosTableAdapter.InsertQueryFuncionarios(
                    Convert.ToInt32(cbCargo.SelectedValue), // FKCargo
                    Convert.ToInt32(cbDepartamento.SelectedValue), // FKDepartamento
                    txtNome.Text.Trim(), // Nome
                    maskedtxtCpf.Text, // CPF (14 caracteres com a máscara)
                    dateTimePickerDataNasc.Value.Date, // DataNascimento
                    genero, // Genero
                    telefone, // Telefone
                    email, // Email
                    txtSenha.Text, // Senha
                    DateTime.Today, // DataEmissao
                    numericUpDownSalario.Value // Salario
                );

                MessageBox.Show("Funcionário cadastrado com sucesso!");

                LimparCampos();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
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

        }

        private bool ValidarCampos()
        {
            if (txtNome.Text.Trim().Length < 3)
                return Erro("Digite o nome (mínimo 3 caracteres).", txtNome);

            if (!maskedtxtCpf.MaskCompleted)
                return Erro("CPF incompleto.", maskedtxtCpf);

            if (maskedtxtTelefone.Text.Any(char.IsDigit) && !maskedtxtTelefone.MaskCompleted)
                return Erro("Telefone incompleto.", maskedtxtTelefone);

            if (txtEmail.Text.Trim() != "" && !txtEmail.Text.Contains("@"))
                return Erro("E-mail inválido.", txtEmail);

            if (txtSenha.Text.Length < 6)
                return Erro("A senha deve ter pelo menos 6 caracteres.", txtSenha);

            if (cbDepartamento.SelectedIndex < 0 || cbCargo.SelectedIndex < 0)
                return Erro("Selecione o departamento e o cargo.", cbDepartamento);

            if (numericUpDownSalario.Value <= 0)
                return Erro("Informe um salário maior que zero.", numericUpDownSalario);

            if (!radioButtonHomem.Checked && !radioButtonMulher.Checked && !radioButtonOutro.Checked)
                return Erro("Selecione o gênero.", radioButtonHomem);

            return true;
        }

        private bool Erro(string mensagem, Control campo)
        {
            MessageBox.Show(mensagem, "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            return false;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            maskedtxtCpf.Clear();
            maskedtxtTelefone.Clear();
            numericUpDownSalario.Value = numericUpDownSalario.Minimum;
            dateTimePickerDataNasc.Value = DateTime.Today;
            cbDepartamento.SelectedIndex = -1;
            cbCargo.SelectedIndex = -1;
            radioButtonHomem.Checked = radioButtonMulher.Checked = radioButtonOutro.Checked = false;
            txtNome.Focus();
        }
    }
}
