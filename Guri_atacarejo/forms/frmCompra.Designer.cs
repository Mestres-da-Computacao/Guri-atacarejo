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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnreglote = new System.Windows.Forms.Button();
            this.btnregforn = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtFornecedor = new Guri_atacarejo.CampoTexto();
            this.txtTotal = new Guri_atacarejo.CampoTexto();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(141)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.txtFornecedor);
            this.panel1.Controls.Add(this.btnreglote);
            this.panel1.Controls.Add(this.btnregforn);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 705);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(924, 74);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(366, 425);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(919, 604);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(919, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fornecedor:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(851, 502);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnreglote
            // 
            this.btnreglote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnreglote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreglote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreglote.ForeColor = System.Drawing.Color.White;
            this.btnreglote.Location = new System.Drawing.Point(35, 612);
            this.btnreglote.Name = "btnreglote";
            this.btnreglote.Size = new System.Drawing.Size(142, 59);
            this.btnreglote.TabIndex = 11;
            this.btnreglote.Text = "Registrar Lote";
            this.btnreglote.UseVisualStyleBackColor = false;
            // 
            // btnregforn
            // 
            this.btnregforn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnregforn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregforn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregforn.ForeColor = System.Drawing.Color.White;
            this.btnregforn.Location = new System.Drawing.Point(183, 612);
            this.btnregforn.Name = "btnregforn";
            this.btnregforn.Size = new System.Drawing.Size(142, 59);
            this.btnregforn.TabIndex = 10;
            this.btnregforn.Text = "Registrar Fornecedor";
            this.btnregforn.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnCancelar.Location = new System.Drawing.Point(596, 611);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 59);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(744, 610);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(142, 60);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BackColor = System.Drawing.Color.Transparent;
            this.txtFornecedor.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtFornecedor.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtFornecedor.CorTextoNormal = System.Drawing.Color.White;
            this.txtFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFornecedor.ForeColor = System.Drawing.Color.White;
            this.txtFornecedor.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtFornecedor.Location = new System.Drawing.Point(924, 548);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(366, 40);
            this.txtFornecedor.TabIndex = 16;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Transparent;
            this.txtTotal.CorPlaceholder = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(240)))), ((int)(((byte)(215)))));
            this.txtTotal.CorTextoFoco = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtTotal.CorTextoNormal = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(87)))), ((int)(((byte)(40)))));
            this.txtTotal.Location = new System.Drawing.Point(924, 632);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(366, 36);
            this.txtTotal.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tela de compra";
            // 
            // frmCompra_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Name = "frmCompra_";
            this.Text = "frmCompra_";
            this.Load += new System.EventHandler(this.frmCompra__Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreglote;
        private System.Windows.Forms.Button btnregforn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CampoTexto txtTotal;
        private CampoTexto txtFornecedor;
        private System.Windows.Forms.Label label3;
    }
}