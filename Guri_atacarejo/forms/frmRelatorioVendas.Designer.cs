
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
            this.tlpRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCabecalho = new System.Windows.Forms.Panel();
            this.flwBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnPrevia = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.pnlRelatorio = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tlpRaiz.SuspendLayout();
            this.pnlCabecalho.SuspendLayout();
            this.flwBotoes.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRaiz
            // 
            this.tlpRaiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.tlpRaiz.ColumnCount = 1;
            this.tlpRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRaiz.Controls.Add(this.pnlCabecalho, 0, 0);
            this.tlpRaiz.Controls.Add(this.pnlFiltros, 0, 1);
            this.tlpRaiz.Controls.Add(this.pnlRelatorio, 0, 2);
            this.tlpRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRaiz.Location = new System.Drawing.Point(0, 0);
            this.tlpRaiz.Name = "tlpRaiz";
            this.tlpRaiz.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.tlpRaiz.RowCount = 3;
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRaiz.Size = new System.Drawing.Size(1148, 749);
            this.tlpRaiz.TabIndex = 0;
            // 
            // pnlCabecalho
            // 
            this.pnlCabecalho.Controls.Add(this.panel1);
            this.pnlCabecalho.Controls.Add(this.flwBotoes);
            this.pnlCabecalho.Controls.Add(this.lblSubtitulo);
            this.pnlCabecalho.Controls.Add(this.lblTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecalho.Location = new System.Drawing.Point(24, 16);
            this.pnlCabecalho.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlCabecalho.Size = new System.Drawing.Size(1100, 88);
            this.pnlCabecalho.TabIndex = 0;
            // 
            // flwBotoes
            // 
            this.flwBotoes.Controls.Add(this.btnFechar);
            this.flwBotoes.Controls.Add(this.btnPrevia);
            this.flwBotoes.Controls.Add(this.btnImprimir);
            this.flwBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwBotoes.Location = new System.Drawing.Point(683, 19);
            this.flwBotoes.Name = "flwBotoes";
            this.flwBotoes.Size = new System.Drawing.Size(417, 66);
            this.flwBotoes.TabIndex = 2;
            this.flwBotoes.WrapContents = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(284, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnFechar.Size = new System.Drawing.Size(130, 44);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnPrevia
            // 
            this.btnPrevia.Location = new System.Drawing.Point(148, 3);
            this.btnPrevia.Name = "btnPrevia";
            this.btnPrevia.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnPrevia.Size = new System.Drawing.Size(130, 44);
            this.btnPrevia.TabIndex = 0;
            this.btnPrevia.Text = "Previsualizar";
            this.btnPrevia.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevia.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(12, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnImprimir.Size = new System.Drawing.Size(130, 44);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 54);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(268, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Vendas registradas no caixa • Guri Atacarejo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatório de Vendas";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 66);
            this.panel1.TabIndex = 1;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.comboBox2);
            this.pnlFiltros.Controls.Add(this.comboBox1);
            this.pnlFiltros.Controls.Add(this.lblData);
            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Controls.Add(this.btnLimpar);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.lblProduto);
            this.pnlFiltros.Controls.Add(this.mskData);
            this.pnlFiltros.Controls.Add(this.cbPeriodo);
            this.pnlFiltros.Controls.Add(this.lblLote);
            this.pnlFiltros.Controls.Add(this.lblFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.Location = new System.Drawing.Point(24, 120);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1100, 92);
            this.pnlFiltros.TabIndex = 1;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(20, 14);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(54, 17);
            this.lblFiltros.TabIndex = 1;
            this.lblFiltros.Text = "FILTROS";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.BackColor = System.Drawing.SystemColors.Control;
            this.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Items.AddRange(new object[] {
            "Dia",
            "Mês",
            "Ano"});
            this.cbPeriodo.Location = new System.Drawing.Point(98, 53);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(121, 25);
            this.cbPeriodo.TabIndex = 2;
            // 
            // mskData
            // 
            this.mskData.BackColor = System.Drawing.SystemColors.Control;
            this.mskData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mskData.Location = new System.Drawing.Point(279, 53);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(79, 18);
            this.mskData.TabIndex = 3;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(364, 61);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(40, 17);
            this.lblLote.TabIndex = 2;
            this.lblLote.Text = "Lote :";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(548, 61);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(62, 17);
            this.lblProduto.TabIndex = 6;
            this.lblProduto.Text = "Produto :";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(765, 37);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnAplicar.Size = new System.Drawing.Size(130, 44);
            this.btnAplicar.TabIndex = 7;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(901, 37);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btnLimpar.Size = new System.Drawing.Size(130, 44);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(20, 59);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(72, 17);
            this.lblPeriodo.TabIndex = 9;
            this.lblPeriodo.Text = "Filtrar Por :";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(228, 59);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(45, 17);
            this.lblData.TabIndex = 10;
            this.lblData.Text = "Valor :";
            // 
            // pnlRelatorio
            // 
            this.pnlRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRelatorio.Location = new System.Drawing.Point(24, 228);
            this.pnlRelatorio.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRelatorio.Name = "pnlRelatorio";
            this.pnlRelatorio.Padding = new System.Windows.Forms.Padding(2);
            this.pnlRelatorio.Size = new System.Drawing.Size(1100, 497);
            this.pnlRelatorio.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dia",
            "Mês",
            "Ano"});
            this.comboBox1.Location = new System.Drawing.Point(410, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 25);
            this.comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Dia",
            "Mês",
            "Ano"});
            this.comboBox2.Location = new System.Drawing.Point(616, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(128, 25);
            this.comboBox2.TabIndex = 14;
            // 
            // frmRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 749);
            this.Controls.Add(this.tlpRaiz);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1164, 726);
            this.Name = "frmRelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatorio Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpRaiz.ResumeLayout(false);
            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.flwBotoes.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRaiz;
        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.FlowLayoutPanel flwBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnPrevia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.Panel pnlRelatorio;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}