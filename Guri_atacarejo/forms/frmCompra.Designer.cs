namespace Guri_atacarejo.forms
{
    partial class frmCompra_
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ações = new System.Windows.Forms.GroupBox();
            this.btnreglote = new System.Windows.Forms.Button();
            this.btnaddforn = new System.Windows.Forms.Button();
            this.btnregforn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Ações.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(806, 430);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(497, 34);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 59);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnConfirmar.Location = new System.Drawing.Point(645, 34);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(142, 59);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Ações);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1213, 654);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tela de compra";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(846, 53);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(350, 430);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(846, 598);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(350, 26);
            this.txtTotal.TabIndex = 8;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFornecedor.Location = new System.Drawing.Point(846, 537);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(350, 26);
            this.txtFornecedor.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(842, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(842, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fornecedor:";
            // 
            // Ações
            // 
            this.Ações.Controls.Add(this.btnreglote);
            this.Ações.Controls.Add(this.btnaddforn);
            this.Ações.Controls.Add(this.btnregforn);
            this.Ações.Controls.Add(this.btnCancelar);
            this.Ações.Controls.Add(this.btnConfirmar);
            this.Ações.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ações.ForeColor = System.Drawing.Color.White;
            this.Ações.Location = new System.Drawing.Point(20, 510);
            this.Ações.Name = "Ações";
            this.Ações.Size = new System.Drawing.Size(803, 112);
            this.Ações.TabIndex = 4;
            this.Ações.TabStop = false;
            this.Ações.Text = "Ações";
            // 
            // btnreglote
            // 
            this.btnreglote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnreglote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreglote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreglote.ForeColor = System.Drawing.Color.White;
            this.btnreglote.Location = new System.Drawing.Point(311, 34);
            this.btnreglote.Name = "btnreglote";
            this.btnreglote.Size = new System.Drawing.Size(142, 59);
            this.btnreglote.TabIndex = 7;
            this.btnreglote.Text = "Registrar Lote";
            this.btnreglote.UseVisualStyleBackColor = false;
            this.btnreglote.Click += new System.EventHandler(this.btnreglote_Click);
            // 
            // btnaddforn
            // 
            this.btnaddforn.BackColor = System.Drawing.Color.White;
            this.btnaddforn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddforn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddforn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnaddforn.Location = new System.Drawing.Point(15, 34);
            this.btnaddforn.Name = "btnaddforn";
            this.btnaddforn.Size = new System.Drawing.Size(142, 59);
            this.btnaddforn.TabIndex = 6;
            this.btnaddforn.Text = "Adicionar Fornecedor";
            this.btnaddforn.UseVisualStyleBackColor = false;
            this.btnaddforn.Click += new System.EventHandler(this.btnregforn_Click);
            // 
            // btnregforn
            // 
            this.btnregforn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.btnregforn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregforn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregforn.ForeColor = System.Drawing.Color.White;
            this.btnregforn.Location = new System.Drawing.Point(163, 34);
            this.btnregforn.Name = "btnregforn";
            this.btnregforn.Size = new System.Drawing.Size(142, 59);
            this.btnregforn.TabIndex = 5;
            this.btnregforn.Text = "Registrar Fornecedor";
            this.btnregforn.UseVisualStyleBackColor = false;
            this.btnregforn.Click += new System.EventHandler(this.btnregforn_Click);
            // 
            // frmCompra_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1238, 678);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCompra_";
            this.Text = "frmCompra_";
            this.Load += new System.EventHandler(this.frmCompra__Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Ações.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Ações;
        private System.Windows.Forms.Button btnaddforn;
        private System.Windows.Forms.Button btnregforn;
        private System.Windows.Forms.Button btnreglote;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}