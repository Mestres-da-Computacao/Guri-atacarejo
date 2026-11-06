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


            maskedtxtCpf.Mask = "000.000.000-00";
            maskedtxtTelefone.Mask = "(00) 00000-0000";

            cbDepartamento.ForeColor = Color.Black;
            cbCargo.ForeColor = Color.Black;
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

        
    }
}