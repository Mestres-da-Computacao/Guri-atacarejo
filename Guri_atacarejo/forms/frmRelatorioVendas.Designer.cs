
namespace Guri_atacarejo.forms
{
    partial class frmRelatorioVendas
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
            this.tblRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCabecalho = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.flwBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevia = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblRaiz.SuspendLayout();
            this.pnlCabecalho.SuspendLayout();
            this.flwBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRaiz
            // 
            this.tblRaiz.ColumnCount = 1;
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRaiz.Controls.Add(this.pnlCabecalho, 0, 1);
            this.tblRaiz.Controls.Add(this.panel1, 0, 0);
            this.tblRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRaiz.Location = new System.Drawing.Point(0, 0);
            this.tblRaiz.Name = "tblRaiz";
            this.tblRaiz.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.tblRaiz.RowCount = 4;
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblRaiz.Size = new System.Drawing.Size(1148, 749);
            this.tblRaiz.TabIndex = 0;
            // 
            // pnlCabecalho
            // 
            this.pnlCabecalho.Controls.Add(this.flwBotoes);
            this.pnlCabecalho.Controls.Add(this.lblSubtitulo);
            this.pnlCabecalho.Controls.Add(this.lblTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecalho.Location = new System.Drawing.Point(23, 0);
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Size = new System.Drawing.Size(1103, 88);
            this.pnlCabecalho.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(16, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatório de Vendas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(16, 35);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(268, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Vendas registradas no caixa • Guri Atacarejo";
            // 
            // flwBotoes
            // 
            this.flwBotoes.Controls.Add(this.btnFechar);
            this.flwBotoes.Controls.Add(this.btnPrevia);
            this.flwBotoes.Controls.Add(this.btnImprimir);
            this.flwBotoes.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwBotoes.Location = new System.Drawing.Point(616, 0);
            this.flwBotoes.Name = "flwBotoes";
            this.flwBotoes.Size = new System.Drawing.Size(487, 88);
            this.flwBotoes.TabIndex = 2;
            this.flwBotoes.WrapContents = false;
            // 
            // btnPrevia
            // 
            this.btnPrevia.Location = new System.Drawing.Point(218, 3);
            this.btnPrevia.Name = "btnPrevia";
            this.btnPrevia.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnPrevia.Size = new System.Drawing.Size(130, 44);
            this.btnPrevia.TabIndex = 0;
            this.btnPrevia.Text = "Previsualizar";
            this.btnPrevia.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(82, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnImprimir.Size = new System.Drawing.Size(130, 44);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(354, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnFechar.Size = new System.Drawing.Size(130, 44);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 120);
            this.panel1.TabIndex = 1;
            // 
            // frmRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 749);
            this.Controls.Add(this.tblRaiz);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1164, 726);
            this.Name = "frmRelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatorio Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tblRaiz.ResumeLayout(false);
            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.flwBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblRaiz;
        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.FlowLayoutPanel flwBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnPrevia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
    }
}