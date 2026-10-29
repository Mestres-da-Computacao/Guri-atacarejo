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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.flpProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.flpCarrinho = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.picLupa = new System.Windows.Forms.PictureBox();
            this.gpbNome = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLupa)).BeginInit();
            this.gpbNome.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(22, 660);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(280, 28);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(551, 35);
            this.txtPesquisar.Multiline = true;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(358, 27);
            this.txtPesquisar.TabIndex = 2;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // flpProdutos
            // 
            this.flpProdutos.AutoScroll = true;
            this.flpProdutos.BackColor = System.Drawing.Color.White;
            this.flpProdutos.Location = new System.Drawing.Point(17, 79);
            this.flpProdutos.Name = "flpProdutos";
            this.flpProdutos.Size = new System.Drawing.Size(930, 529);
            this.flpProdutos.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(18, 621);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(168, 24);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Código do produto";
            // 
            // flpCarrinho
            // 
            this.flpCarrinho.AutoScroll = true;
            this.flpCarrinho.BackColor = System.Drawing.Color.White;
            this.flpCarrinho.Location = new System.Drawing.Point(962, 156);
            this.flpCarrinho.Name = "flpCarrinho";
            this.flpCarrinho.Size = new System.Drawing.Size(303, 452);
            this.flpCarrinho.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnConfirmar.Location = new System.Drawing.Point(1122, 630);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(143, 58);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(962, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(303, 115);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(973, 630);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 58);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // picLupa
            // 
            this.picLupa.BackColor = System.Drawing.Color.White;
            this.picLupa.Image = ((System.Drawing.Image)(resources.GetObject("picLupa.Image")));
            this.picLupa.Location = new System.Drawing.Point(908, 35);
            this.picLupa.Name = "picLupa";
            this.picLupa.Size = new System.Drawing.Size(39, 27);
            this.picLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLupa.TabIndex = 9;
            this.picLupa.TabStop = false;
            // 
            // gpbNome
            // 
            this.gpbNome.Controls.Add(this.picLupa);
            this.gpbNome.Controls.Add(this.picLogo);
            this.gpbNome.Controls.Add(this.btnConfirmar);
            this.gpbNome.Controls.Add(this.btnCancelar);
            this.gpbNome.Controls.Add(this.flpCarrinho);
            this.gpbNome.Controls.Add(this.lblCodigo);
            this.gpbNome.Controls.Add(this.flpProdutos);
            this.gpbNome.Controls.Add(this.txtPesquisar);
            this.gpbNome.Controls.Add(this.txtCodigo);
            this.gpbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbNome.ForeColor = System.Drawing.Color.White;
            this.gpbNome.Location = new System.Drawing.Point(12, 12);
            this.gpbNome.Name = "gpbNome";
            this.gpbNome.Size = new System.Drawing.Size(1283, 715);
            this.gpbNome.TabIndex = 10;
            this.gpbNome.TabStop = false;
            this.gpbNome.Text = "Adicionar Produtos";
            // 
            // frmAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1308, 742);
            this.Controls.Add(this.gpbNome);
            this.Name = "frmAdicionar";
            this.Text = "frmAdicionar";
            this.Load += new System.EventHandler(this.frmAdicionar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLupa)).EndInit();
            this.gpbNome.ResumeLayout(false);
            this.gpbNome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.FlowLayoutPanel flpProdutos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.FlowLayoutPanel flpCarrinho;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox picLupa;
        private System.Windows.Forms.GroupBox gpbNome;
    }
}