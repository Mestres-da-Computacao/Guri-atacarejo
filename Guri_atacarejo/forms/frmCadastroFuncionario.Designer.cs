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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxGeneros = new System.Windows.Forms.GroupBox();
            this.radioButtonMulher = new System.Windows.Forms.RadioButton();
            this.radioButtonOutro = new System.Windows.Forms.RadioButton();
            this.radioButtonHomem = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCargo = new Guri_atacarejo.CampoCombo();
            this.cbDepartamento = new Guri_atacarejo.CampoCombo();
            this.dateTimePickerDataNasc = new Guri_atacarejo.CampoData();
            this.numericUpDownSalario = new Guri_atacarejo.CampoNumero();
            this.maskedtxtTelefone = new Guri_atacarejo.CampoMascara();
            this.maskedtxtCpf = new Guri_atacarejo.CampoMascara();
            this.txtSenha = new Guri_atacarejo.CampoTexto();
            this.txtEmail = new Guri_atacarejo.CampoTexto();
            this.txtNome = new Guri_atacarejo.CampoTexto();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBoxGeneros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Guri_atacarejo.Properties.Resources.Logótipo_Guri_Atacarejo_Branco;
            this.pictureBoxLogo.Location = new System.Drawing.Point(1057, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(173, 657);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 24;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(844, 575);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(128, 52);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnCancelar.Location = new System.Drawing.Point(687, 575);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 52);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(659, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 25);
            this.label9.TabIndex = 42;
            this.label9.Text = "Salário:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(333, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "Telefone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(45, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 38;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(645, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 35;
            this.label6.Text = "Cargo:";
            // 
            // groupBoxGeneros
            // 
            this.groupBoxGeneros.Controls.Add(this.radioButtonMulher);
            this.groupBoxGeneros.Controls.Add(this.radioButtonOutro);
            this.groupBoxGeneros.Controls.Add(this.radioButtonHomem);
            this.groupBoxGeneros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGeneros.ForeColor = System.Drawing.Color.White;
            this.groupBoxGeneros.Location = new System.Drawing.Point(39, 456);
            this.groupBoxGeneros.Name = "groupBoxGeneros";
            this.groupBoxGeneros.Size = new System.Drawing.Size(308, 138);
            this.groupBoxGeneros.TabIndex = 9;
            this.groupBoxGeneros.TabStop = false;
            this.groupBoxGeneros.Text = "Gênero";
            // 
            // radioButtonMulher
            // 
            this.radioButtonMulher.AutoSize = true;
            this.radioButtonMulher.Location = new System.Drawing.Point(15, 65);
            this.radioButtonMulher.Name = "radioButtonMulher";
            this.radioButtonMulher.Size = new System.Drawing.Size(81, 24);
            this.radioButtonMulher.TabIndex = 7;
            this.radioButtonMulher.TabStop = true;
            this.radioButtonMulher.Text = "Mulher";
            this.radioButtonMulher.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutro
            // 
            this.radioButtonOutro.AutoSize = true;
            this.radioButtonOutro.Location = new System.Drawing.Point(15, 95);
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
            this.radioButtonHomem.Location = new System.Drawing.Point(15, 36);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 25);
            this.label4.TabIndex = 33;
            this.label4.Text = "Data de Nascimento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(59, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nome:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(141)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.cbCargo);
            this.panel1.Controls.Add(this.cbDepartamento);
            this.panel1.Controls.Add(this.dateTimePickerDataNasc);
            this.panel1.Controls.Add(this.numericUpDownSalario);
            this.panel1.Controls.Add(this.maskedtxtTelefone);
            this.panel1.Controls.Add(this.maskedtxtCpf);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBoxGeneros);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 657);
            this.panel1.TabIndex = 48;
            // 
            // cbCargo
            // 
            this.cbCargo.BackColor = System.Drawing.Color.Transparent;
            this.cbCargo.CorIcone = System.Drawing.Color.White;
            this.cbCargo.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbCargo.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.cbCargo.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbCargo.CorTextoNormal = System.Drawing.Color.White;
            this.cbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCargo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbCargo.Location = new System.Drawing.Point(733, 436);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(239, 32);
            this.cbCargo.TabIndex = 8;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.cbDepartamento.CorIcone = System.Drawing.Color.White;
            this.cbDepartamento.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbDepartamento.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.cbDepartamento.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbDepartamento.CorTextoNormal = System.Drawing.Color.White;
            this.cbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamento.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.cbDepartamento.Location = new System.Drawing.Point(733, 361);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(239, 32);
            this.cbDepartamento.TabIndex = 7;
            // 
            // dateTimePickerDataNasc
            // 
            this.dateTimePickerDataNasc.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePickerDataNasc.CorIcone = System.Drawing.Color.White;
            this.dateTimePickerDataNasc.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.dateTimePickerDataNasc.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.dateTimePickerDataNasc.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.dateTimePickerDataNasc.CorTextoNormal = System.Drawing.Color.White;
            this.dateTimePickerDataNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDataNasc.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.dateTimePickerDataNasc.Location = new System.Drawing.Point(271, 361);
            this.dateTimePickerDataNasc.Mask = "00/00/0000";
            this.dateTimePickerDataNasc.Name = "dateTimePickerDataNasc";
            this.dateTimePickerDataNasc.PlaceholderText = "dd/mm/aaaa";
            this.dateTimePickerDataNasc.Size = new System.Drawing.Size(172, 32);
            this.dateTimePickerDataNasc.TabIndex = 6;
            // 
            // numericUpDownSalario
            // 
            this.numericUpDownSalario.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDownSalario.CorIcone = System.Drawing.Color.Empty;
            this.numericUpDownSalario.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDownSalario.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.numericUpDownSalario.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDownSalario.CorTextoNormal = System.Drawing.Color.White;
            this.numericUpDownSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSalario.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDownSalario.Location = new System.Drawing.Point(758, 280);
            this.numericUpDownSalario.Name = "numericUpDownSalario";
            this.numericUpDownSalario.Size = new System.Drawing.Size(214, 32);
            this.numericUpDownSalario.TabIndex = 5;
            // 
            // maskedtxtTelefone
            // 
            this.maskedtxtTelefone.BackColor = System.Drawing.Color.Transparent;
            this.maskedtxtTelefone.CorIcone = System.Drawing.Color.Empty;
            this.maskedtxtTelefone.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtTelefone.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.maskedtxtTelefone.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtTelefone.CorTextoNormal = System.Drawing.Color.White;
            this.maskedtxtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedtxtTelefone.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtTelefone.Location = new System.Drawing.Point(450, 280);
            this.maskedtxtTelefone.Mask = "\\(00\\) 00000\\-0000";
            this.maskedtxtTelefone.Name = "maskedtxtTelefone";
            this.maskedtxtTelefone.Size = new System.Drawing.Size(171, 32);
            this.maskedtxtTelefone.TabIndex = 4;
            // 
            // maskedtxtCpf
            // 
            this.maskedtxtCpf.BackColor = System.Drawing.Color.Transparent;
            this.maskedtxtCpf.CorIcone = System.Drawing.Color.Empty;
            this.maskedtxtCpf.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtCpf.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.maskedtxtCpf.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtCpf.CorTextoNormal = System.Drawing.Color.White;
            this.maskedtxtCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedtxtCpf.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.maskedtxtCpf.Location = new System.Drawing.Point(129, 280);
            this.maskedtxtCpf.Mask = "000.000.000-00";
            this.maskedtxtCpf.Name = "maskedtxtCpf";
            this.maskedtxtCpf.Size = new System.Drawing.Size(174, 32);
            this.maskedtxtCpf.TabIndex = 3;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.Transparent;
            this.txtSenha.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtSenha.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtSenha.CorTextoNormal = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.IsPassword = true;
            this.txtSenha.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtSenha.Location = new System.Drawing.Point(129, 193);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(843, 37);
            this.txtSenha.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtEmail.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtEmail.CorTextoNormal = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtEmail.Location = new System.Drawing.Point(128, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(844, 37);
            this.txtEmail.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Transparent;
            this.txtNome.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtNome.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtNome.CorTextoNormal = System.Drawing.Color.White;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtNome.Location = new System.Drawing.Point(128, 40);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(844, 37);
            this.txtNome.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(561, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 34;
            this.label5.Text = "Departamento:";
            // 
            // frmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Name = "frmCadastroFuncionario";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxGeneros.ResumeLayout(false);
            this.groupBoxGeneros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxGeneros;
        private System.Windows.Forms.RadioButton radioButtonMulher;
        private System.Windows.Forms.RadioButton radioButtonOutro;
        private System.Windows.Forms.RadioButton radioButtonHomem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CampoTexto txtNome;
        private CampoTexto txtSenha;
        private CampoTexto txtEmail;
        private CampoMascara maskedtxtCpf;
        private CampoMascara maskedtxtTelefone;
        private CampoNumero numericUpDownSalario;
        private CampoCombo cbDepartamento;
        private CampoData dateTimePickerDataNasc;
        private CampoCombo cbCargo;
        private System.Windows.Forms.Label label5;
    }
}