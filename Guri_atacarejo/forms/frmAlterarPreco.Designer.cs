namespace Guri_atacarejo.forms
{
    partial class frmAlterarPreco
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
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.campoTexto1 = new Guri_atacarejo.CampoTexto();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(17, 41);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(288, 20);
            this.txtQtd.TabIndex = 1;
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.White;
            this.lblQuantidade.Location = new System.Drawing.Point(14, 22);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(87, 16);
            this.lblQuantidade.TabIndex = 1;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.White;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnFinalizar.Location = new System.Drawing.Point(19, 105);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 2;
            this.btnFinalizar.Text = "Alterar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnCancelar.Location = new System.Drawing.Point(100, 105);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.ForeColor = System.Drawing.Color.White;
            this.btnRemover.Location = new System.Drawing.Point(212, 68);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover Produto";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.campoTexto1);
            this.panel1.Controls.Add(this.btnRemover);
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblQuantidade);
            this.panel1.Controls.Add(this.txtQtd);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 297);
            this.panel1.TabIndex = 5;
            // 
            // campoTexto1
            // 
            this.campoTexto1.BackColor = System.Drawing.Color.Transparent;
            this.campoTexto1.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.campoTexto1.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.campoTexto1.CorTextoNormal = System.Drawing.Color.White;
            this.campoTexto1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.campoTexto1.Location = new System.Drawing.Point(244, 128);
            this.campoTexto1.Name = "campoTexto1";
            this.campoTexto1.Size = new System.Drawing.Size(250, 40);
            this.campoTexto1.TabIndex = 5;
            this.campoTexto1.Text = "campoTexto1";
            // 
            // frmAlterarPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.panel1);
            this.Name = "frmAlterarPreco";
            this.Text = "frmAlterarPreco";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Panel panel1;
        private CampoTexto campoTexto1;
    }
}