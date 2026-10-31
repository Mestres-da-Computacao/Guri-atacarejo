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
            this.groupBoxFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFuncionarios.ForeColor = System.Drawing.Color.White;
            this.groupBoxFuncionarios.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFuncionarios.Name = "groupBoxFuncionarios";
            this.groupBoxFuncionarios.Size = new System.Drawing.Size(620, 365);
            this.groupBoxFuncionarios.TabIndex = 0;
            this.groupBoxFuncionarios.TabStop = false;
            this.groupBoxFuncionarios.Text = "Cadastro De Funcionários";
            this.groupBoxFuncionarios.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // maskedtxtTelefone
            // 
            this.maskedtxtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedtxtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedtxtTelefone.Location = new System.Drawing.Point(437, 164);
            this.maskedtxtTelefone.Mask = "\\(00\\) 00000\\-0000";
            this.maskedtxtTelefone.Name = "maskedtxtTelefone";
            this.maskedtxtTelefone.Size = new System.Drawing.Size(163, 22);
            this.maskedtxtTelefone.TabIndex = 25;
            // 
            // maskedtxtCpf
            // 
            this.maskedtxtCpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedtxtCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedtxtCpf.Location = new System.Drawing.Point(437, 86);
            this.maskedtxtCpf.Mask = "000\\.000\\.000\\-00";
            this.maskedtxtCpf.Name = "maskedtxtCpf";
            this.maskedtxtCpf.Size = new System.Drawing.Size(163, 22);
            this.maskedtxtCpf.TabIndex = 24;
            this.maskedtxtCpf.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedtxtCpf_MaskInputRejected);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnConfirmar.Location = new System.Drawing.Point(472, 295);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(128, 52);
            this.btnConfirmar.TabIndex = 23;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(338, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 52);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(363, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Salário:";
            // 
            // numericUpDownSalario
            // 
            this.numericUpDownSalario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownSalario.DecimalPlaces = 2;
            this.numericUpDownSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSalario.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSalario.Location = new System.Drawing.Point(437, 128);
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
            this.numericUpDownSalario.Size = new System.Drawing.Size(163, 22);
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
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(353, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "telefone:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(78, 88);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(261, 23);
            this.txtEmail.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Email:";
            // 
            // cbCargo
            // 
            this.cbCargo.BackColor = System.Drawing.Color.White;
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Items.AddRange(new object[] {
            "Nenhum Departamento Selecionado..."});
            this.cbCargo.Location = new System.Drawing.Point(437, 202);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(163, 28);
            this.cbCargo.TabIndex = 15;
            this.cbCargo.SelectedIndexChanged += new System.EventHandler(this.cbCargo_SelectedIndexChanged);
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.BackColor = System.Drawing.Color.White;
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Items.AddRange(new object[] {
            "Diretoria",
            "Atendimento",
            "Operação de loja",
            "Estoque",
            "Administrativo"});
            this.cbDepartamento.Location = new System.Drawing.Point(141, 202);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(198, 28);
            this.cbDepartamento.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cargo:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Departamento:";
            // 
            // groupBoxGeneros
            // 
            this.groupBoxGeneros.Controls.Add(this.radioButtonMulher);
            this.groupBoxGeneros.Controls.Add(this.radioButtonOutro);
            this.groupBoxGeneros.Controls.Add(this.radioButtonHomem);
            this.groupBoxGeneros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGeneros.ForeColor = System.Drawing.Color.White;
            this.groupBoxGeneros.Location = new System.Drawing.Point(12, 241);
            this.groupBoxGeneros.Name = "groupBoxGeneros";
            this.groupBoxGeneros.Size = new System.Drawing.Size(137, 107);
            this.groupBoxGeneros.TabIndex = 4;
            this.groupBoxGeneros.TabStop = false;
            this.groupBoxGeneros.Text = "Gênero";
            this.groupBoxGeneros.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // radioButtonMulher
            // 
            this.radioButtonMulher.AutoSize = true;
            this.radioButtonMulher.Location = new System.Drawing.Point(16, 46);
            this.radioButtonMulher.Name = "radioButtonMulher";
            this.radioButtonMulher.Size = new System.Drawing.Size(81, 24);
            this.radioButtonMulher.TabIndex = 7;
            this.radioButtonMulher.TabStop = true;
            this.radioButtonMulher.Text = "Mulher";
            this.radioButtonMulher.UseVisualStyleBackColor = true;
            this.radioButtonMulher.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButtonOutro
            // 
            this.radioButtonOutro.AutoSize = true;
            this.radioButtonOutro.Location = new System.Drawing.Point(16, 69);
            this.radioButtonOutro.Name = "radioButtonOutro";
            this.radioButtonOutro.Size = new System.Drawing.Size(72, 24);
            this.radioButtonOutro.TabIndex = 6;
            this.radioButtonOutro.TabStop = true;
            this.radioButtonOutro.Text = "Outro";
            this.radioButtonOutro.UseVisualStyleBackColor = true;
            // 
            // radioButtonHomem
            // 
            this.radioButtonHomem.AutoSize = true;
            this.radioButtonHomem.Location = new System.Drawing.Point(16, 25);
            this.radioButtonHomem.Name = "radioButtonHomem";
            this.radioButtonHomem.Size = new System.Drawing.Size(88, 24);
            this.radioButtonHomem.TabIndex = 5;
            this.radioButtonHomem.TabStop = true;
            this.radioButtonHomem.Text = "Homem";
            this.radioButtonHomem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data de Nascimento:";
            // 
            // dateTimePickerDataNasc
            // 
            this.dateTimePickerDataNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataNasc.Location = new System.Drawing.Point(189, 162);
            this.dateTimePickerDataNasc.Name = "dateTimePickerDataNasc";
            this.dateTimePickerDataNasc.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerDataNasc.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(383, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "CPF:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(78, 130);
            this.txtSenha.Multiline = true;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(261, 23);
            this.txtSenha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(78, 47);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(522, 23);
            this.txtNome.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(628, -8);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(201, 406);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 24;
            this.pictureBoxLogo.TabStop = false;
            // 
            // frmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(829, 389);
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