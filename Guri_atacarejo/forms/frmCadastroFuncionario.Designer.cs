namespace Guri_atacarejo.forms
{
    partial class frmCadastroFuncionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFuncionario));
            this.groupBoxFuncionarios = new System.Windows.Forms.GroupBox();
            this.maskedtxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.maskedtxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownSalario = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxGeneros = new System.Windows.Forms.GroupBox();
            this.radioButtonMulher = new System.Windows.Forms.RadioButton();
            this.radioButtonOutro = new System.Windows.Forms.RadioButton();
            this.radioButtonHomem = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDataNasc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSalario)).BeginInit();
            this.groupBoxGeneros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFuncionarios
            // 
            this.groupBoxFuncionarios.Controls.Add(this.maskedtxtTelefone);
            this.groupBoxFuncionarios.Controls.Add(this.maskedtxtCpf);
            this.groupBoxFuncionarios.Controls.Add(this.btnConfirmar);
            this.groupBoxFuncionarios.Controls.Add(this.btnCancelar);
            this.groupBoxFuncionarios.Controls.Add(this.label9);
            this.groupBoxFuncionarios.Controls.Add(this.numericUpDownSalario);
            this.groupBoxFuncionarios.Controls.Add(this.label8);
            this.groupBoxFuncionarios.Controls.Add(this.txtEmail);
            this.groupBoxFuncionarios.Controls.Add(this.label7);
            this.groupBoxFuncionarios.Controls.Add(this.cbCargo);
            this.groupBoxFuncionarios.Controls.Add(this.cbDepartamento);
            this.groupBoxFuncionarios.Controls.Add(this.label6);
            this.groupBoxFuncionarios.Controls.Add(this.label5);
            this.groupBoxFuncionarios.Controls.Add(this.groupBoxGeneros);
            this.groupBoxFuncionarios.Controls.Add(this.label4);
            this.groupBoxFuncionarios.Controls.Add(this.dateTimePickerDataNasc);
            this.groupBoxFuncionarios.Controls.Add(this.label3);
            this.groupBoxFuncionarios.Controls.Add(this.txtSenha);
            this.groupBoxFuncionarios.Controls.Add(this.label2);
            this.groupBoxFuncionarios.Controls.Add(this.txtNome);
            this.groupBoxFuncionarios.Controls.Add(this.label1);
            this.groupBoxFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFuncionarios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxFuncionarios.Location = new System.Drawing.Point(12, 4);
            this.groupBoxFuncionarios.Name = "groupBoxFuncionarios";
            this.groupBoxFuncionarios.Size = new System.Drawing.Size(601, 310);
            this.groupBoxFuncionarios.TabIndex = 0;
            this.groupBoxFuncionarios.TabStop = false;
            this.groupBoxFuncionarios.Text = "Cadastro De Funcionários";
            this.groupBoxFuncionarios.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // maskedtxtTelefone
            // 
            this.maskedtxtTelefone.Location = new System.Drawing.Point(426, 139);
            this.maskedtxtTelefone.Mask = "\\(00\\) 00000\\-0000";
            this.maskedtxtTelefone.Name = "maskedtxtTelefone";
            this.maskedtxtTelefone.Size = new System.Drawing.Size(161, 26);
            this.maskedtxtTelefone.TabIndex = 25;
            // 
            // maskedtxtCpf
            // 
            this.maskedtxtCpf.Location = new System.Drawing.Point(426, 72);
            this.maskedtxtCpf.Mask = "000\\.000\\.000\\-00";
            this.maskedtxtCpf.Name = "maskedtxtCpf";
            this.maskedtxtCpf.Size = new System.Drawing.Size(161, 26);
            this.maskedtxtCpf.TabIndex = 24;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Location = new System.Drawing.Point(353, 234);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(97, 52);
            this.btnConfirmar.TabIndex = 23;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(250, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 52);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Salário:";
            // 
            // numericUpDownSalario
            // 
            this.numericUpDownSalario.DecimalPlaces = 2;
            this.numericUpDownSalario.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSalario.Location = new System.Drawing.Point(426, 104);
            this.numericUpDownSalario.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownSalario.Minimum = new decimal(new int[] {
            1621,
            0,
            0,
            0});
            this.numericUpDownSalario.Name = "numericUpDownSalario";
            this.numericUpDownSalario.Size = new System.Drawing.Size(161, 26);
            this.numericUpDownSalario.TabIndex = 20;
            this.numericUpDownSalario.Value = new decimal(new int[] {
            1621,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "telefone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(71, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 26);
            this.txtEmail.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Email:";
            // 
            // cbCargo
            // 
            this.cbCargo.BackColor = System.Drawing.SystemColors.Info;
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Items.AddRange(new object[] {
            "Nenhum Departamento Selecionado..."});
            this.cbCargo.Location = new System.Drawing.Point(426, 170);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(161, 28);
            this.cbCargo.TabIndex = 15;
            this.cbCargo.SelectedIndexChanged += new System.EventHandler(this.cbCargo_SelectedIndexChanged);
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Items.AddRange(new object[] {
            "Diretoria",
            "Atendimento",
            "Operação de loja",
            "Estoque",
            "Administrativo"});
            this.cbDepartamento.Location = new System.Drawing.Point(135, 167);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(209, 28);
            this.cbDepartamento.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cargo:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Departamento:";
            // 
            // groupBoxGeneros
            // 
            this.groupBoxGeneros.Controls.Add(this.radioButtonMulher);
            this.groupBoxGeneros.Controls.Add(this.radioButtonOutro);
            this.groupBoxGeneros.Controls.Add(this.radioButtonHomem);
            this.groupBoxGeneros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGeneros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxGeneros.Location = new System.Drawing.Point(17, 202);
            this.groupBoxGeneros.Name = "groupBoxGeneros";
            this.groupBoxGeneros.Size = new System.Drawing.Size(96, 98);
            this.groupBoxGeneros.TabIndex = 4;
            this.groupBoxGeneros.TabStop = false;
            this.groupBoxGeneros.Text = "Gênero";
            this.groupBoxGeneros.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // radioButtonMulher
            // 
            this.radioButtonMulher.AutoSize = true;
            this.radioButtonMulher.Location = new System.Drawing.Point(6, 46);
            this.radioButtonMulher.Name = "radioButtonMulher";
            this.radioButtonMulher.Size = new System.Drawing.Size(75, 24);
            this.radioButtonMulher.TabIndex = 7;
            this.radioButtonMulher.TabStop = true;
            this.radioButtonMulher.Text = "Mulher";
            this.radioButtonMulher.UseVisualStyleBackColor = true;
            this.radioButtonMulher.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButtonOutro
            // 
            this.radioButtonOutro.AutoSize = true;
            this.radioButtonOutro.Location = new System.Drawing.Point(6, 69);
            this.radioButtonOutro.Name = "radioButtonOutro";
            this.radioButtonOutro.Size = new System.Drawing.Size(67, 24);
            this.radioButtonOutro.TabIndex = 6;
            this.radioButtonOutro.TabStop = true;
            this.radioButtonOutro.Text = "Outro";
            this.radioButtonOutro.UseVisualStyleBackColor = true;
            // 
            // radioButtonHomem
            // 
            this.radioButtonHomem.AutoSize = true;
            this.radioButtonHomem.Location = new System.Drawing.Point(6, 25);
            this.radioButtonHomem.Name = "radioButtonHomem";
            this.radioButtonHomem.Size = new System.Drawing.Size(83, 24);
            this.radioButtonHomem.TabIndex = 5;
            this.radioButtonHomem.TabStop = true;
            this.radioButtonHomem.Text = "Homem";
            this.radioButtonHomem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data de Nascimento:";
            // 
            // dateTimePickerDataNasc
            // 
            this.dateTimePickerDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataNasc.Location = new System.Drawing.Point(177, 100);
            this.dateTimePickerDataNasc.Name = "dateTimePickerDataNasc";
            this.dateTimePickerDataNasc.Size = new System.Drawing.Size(100, 26);
            this.dateTimePickerDataNasc.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "CPF:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(71, 135);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(273, 26);
            this.txtSenha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(71, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(516, 26);
            this.txtNome.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(563, -54);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(259, 450);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 24;
            this.pictureBoxLogo.TabStop = false;
            // 
            // frmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(788, 319);
            this.Controls.Add(this.groupBoxFuncionarios);
            this.Controls.Add(this.pictureBoxLogo);
            this.Name = "frmCadastroFuncionario";
            this.Text = "Form1";
            this.groupBoxFuncionarios.ResumeLayout(false);
            this.groupBoxFuncionarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSalario)).EndInit();
            this.groupBoxGeneros.ResumeLayout(false);
            this.groupBoxGeneros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFuncionarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxGeneros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataNasc;
        private System.Windows.Forms.RadioButton radioButtonMulher;
        private System.Windows.Forms.RadioButton radioButtonOutro;
        private System.Windows.Forms.RadioButton radioButtonHomem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCargo;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownSalario;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.MaskedTextBox maskedtxtTelefone;
        private System.Windows.Forms.MaskedTextBox maskedtxtCpf;
    }
}