namespace Guri_atacarejo.forms
{
    partial class frmRegistroLote
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
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFornecedores = new Guri_atacarejo.CampoCombo();
            this.ComboBoxProduto = new Guri_atacarejo.CampoCombo();
            this.campoData1 = new Guri_atacarejo.CampoData();
            this.numericUpDown1 = new Guri_atacarejo.CampoNumero();
            this.nupdDinheiro = new Guri_atacarejo.CampoNumero();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(534, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Custo :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.button1.Location = new System.Drawing.Point(693, 565);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(823, 565);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 54);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cadastrar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(64, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Quantia :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Data de Validade :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(534, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Produto :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fornecedor :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(141)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.nupdDinheiro);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.campoData1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ComboBoxProduto);
            this.panel1.Controls.Add(this.comboBoxFornecedores);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 657);
            this.panel1.TabIndex = 31;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Guri_atacarejo.Properties.Resources.Logótipo_Guri_Atacarejo_Branco;
            this.pictureBox2.Location = new System.Drawing.Point(1045, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 657);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(63, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 31);
            this.label6.TabIndex = 31;
            this.label6.Text = "Registro de lote";
            // 
            // comboBoxFornecedores
            // 
            this.comboBoxFornecedores.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxFornecedores.CorIcone = System.Drawing.Color.Empty;
            this.comboBoxFornecedores.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.comboBoxFornecedores.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.comboBoxFornecedores.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.comboBoxFornecedores.CorTextoNormal = System.Drawing.Color.White;
            this.comboBoxFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFornecedores.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.comboBoxFornecedores.Location = new System.Drawing.Point(69, 164);
            this.comboBoxFornecedores.Name = "comboBoxFornecedores";
            this.comboBoxFornecedores.Size = new System.Drawing.Size(408, 40);
            this.comboBoxFornecedores.TabIndex = 32;
            // 
            // ComboBoxProduto
            // 
            this.ComboBoxProduto.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxProduto.CorIcone = System.Drawing.Color.Empty;
            this.ComboBoxProduto.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.ComboBoxProduto.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.ComboBoxProduto.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.ComboBoxProduto.CorTextoNormal = System.Drawing.Color.White;
            this.ComboBoxProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxProduto.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.ComboBoxProduto.Location = new System.Drawing.Point(539, 164);
            this.ComboBoxProduto.Name = "ComboBoxProduto";
            this.ComboBoxProduto.Size = new System.Drawing.Size(408, 40);
            this.ComboBoxProduto.TabIndex = 33;
            // 
            // campoData1
            // 
            this.campoData1.BackColor = System.Drawing.Color.Transparent;
            this.campoData1.CorIcone = System.Drawing.Color.Empty;
            this.campoData1.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.campoData1.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.campoData1.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.campoData1.CorTextoNormal = System.Drawing.Color.White;
            this.campoData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoData1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.campoData1.Location = new System.Drawing.Point(69, 483);
            this.campoData1.Mask = "00/00/0000";
            this.campoData1.Name = "campoData1";
            this.campoData1.PlaceholderText = "dd/mm/aaaa";
            this.campoData1.Size = new System.Drawing.Size(180, 40);
            this.campoData1.TabIndex = 34;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDown1.CorIcone = System.Drawing.Color.Empty;
            this.numericUpDown1.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDown1.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.numericUpDown1.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDown1.CorTextoNormal = System.Drawing.Color.White;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.numericUpDown1.Location = new System.Drawing.Point(69, 327);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(408, 40);
            this.numericUpDown1.TabIndex = 35;
            // 
            // nupdDinheiro
            // 
            this.nupdDinheiro.BackColor = System.Drawing.Color.Transparent;
            this.nupdDinheiro.CorIcone = System.Drawing.Color.Empty;
            this.nupdDinheiro.CorIconeFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.nupdDinheiro.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.nupdDinheiro.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.nupdDinheiro.CorTextoNormal = System.Drawing.Color.White;
            this.nupdDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdDinheiro.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.nupdDinheiro.Location = new System.Drawing.Point(539, 327);
            this.nupdDinheiro.Name = "nupdDinheiro";
            this.nupdDinheiro.Size = new System.Drawing.Size(408, 40);
            this.nupdDinheiro.TabIndex = 36;
            // 
            // frmRegistroLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRegistroLote";
            this.Text = "frmRegistroLote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CampoCombo ComboBoxProduto;
        private CampoCombo comboBoxFornecedores;
        private System.Windows.Forms.Label label6;
        private CampoData campoData1;
        private CampoNumero nupdDinheiro;
        private CampoNumero numericUpDown1;
    }
}