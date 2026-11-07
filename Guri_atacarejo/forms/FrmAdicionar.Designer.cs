namespace Guri_atacarejo.forms
{
    partial class frmAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionar));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.flpCarrinho = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.flpProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPesquisar = new Guri_atacarejo.CampoTexto();
            this.textBox1 = new Guri_atacarejo.CampoTexto();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(964, 26);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(343, 106);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 17;
            this.picLogo.TabStop = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(1164, 623);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(143, 58);
            this.btnConfirmar.TabIndex = 16;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnCancelar.Location = new System.Drawing.Point(964, 623);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 58);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // flpCarrinho
            // 
            this.flpCarrinho.AutoScroll = true;
            this.flpCarrinho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.flpCarrinho.Location = new System.Drawing.Point(964, 149);
            this.flpCarrinho.Name = "flpCarrinho";
            this.flpCarrinho.Size = new System.Drawing.Size(343, 452);
            this.flpCarrinho.TabIndex = 14;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(15, 623);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(168, 24);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código do produto";
            // 
            // flpProdutos
            // 
            this.flpProdutos.AutoScroll = true;
            this.flpProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.flpProdutos.Location = new System.Drawing.Point(19, 72);
            this.flpProdutos.Name = "flpProdutos";
            this.flpProdutos.Size = new System.Drawing.Size(925, 529);
            this.flpProdutos.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(141)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPesquisar);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.flpCarrinho);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.flpProdutos);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 705);
            this.panel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 31);
            this.label2.TabIndex = 21;
            this.label2.Text = "Adicionar produto";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.txtPesquisar.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtPesquisar.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtPesquisar.CorTextoNormal = System.Drawing.Color.White;
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtPesquisar.Location = new System.Drawing.Point(552, 17);
            this.txtPesquisar.MostrarLupa = true;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.PlaceholderText = "Pesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(392, 40);
            this.txtPesquisar.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.textBox1.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.textBox1.CorTextoNormal = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.textBox1.Location = new System.Drawing.Point(19, 653);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 28);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Código do produto";
            // 
            // frmAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdicionar";
            this.Text = "frmAdicionar";
            this.Load += new System.EventHandler(this.frmAdicionar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.FlowLayoutPanel flpCarrinho;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.FlowLayoutPanel flpProdutos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private CampoTexto textBox1;
        private CampoTexto txtPesquisar;
        private System.Windows.Forms.Label label2;
    }
}