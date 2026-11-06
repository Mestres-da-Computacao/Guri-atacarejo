
namespace Guri_atacarejo.forms
{
    partial class frmRelatorioEstoqueQtd
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cbProduto = new Guri_atacarejo.RoundComboBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.pnlRelatorio = new System.Windows.Forms.Panel();
            this.lblAreaRelatorio = new System.Windows.Forms.Label();
            this.pnlCabecalho = new System.Windows.Forms.Panel();
            this.flwBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPrevia = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpRaiz.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlRelatorio.SuspendLayout();
            this.pnlCabecalho.SuspendLayout();
            this.flwBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRaiz
            // 
            this.tlpRaiz.ColumnCount = 1;
            this.tlpRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRaiz.Controls.Add(this.pnlFiltros, 0, 1);
            this.tlpRaiz.Controls.Add(this.pnlRelatorio, 0, 2);
            this.tlpRaiz.Controls.Add(this.pnlCabecalho, 0, 0);
            this.tlpRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRaiz.Location = new System.Drawing.Point(0, 0);
            this.tlpRaiz.Name = "tlpRaiz";
            this.tlpRaiz.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.tlpRaiz.RowCount = 3;
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRaiz.Size = new System.Drawing.Size(1264, 681);
            this.tlpRaiz.TabIndex = 0;
            this.tlpRaiz.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpRaiz_Paint);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.cbProduto);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.btnLimpar);
            this.pnlFiltros.Controls.Add(this.lblProduto);
            this.pnlFiltros.Controls.Add(this.lblFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.Location = new System.Drawing.Point(24, 136);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1216, 100);
            this.pnlFiltros.TabIndex = 1;
            // 
            // cbProduto
            // 
            this.cbProduto.BackColor = System.Drawing.Color.Transparent;
            this.cbProduto.BackgroundColor = System.Drawing.Color.Transparent;
            this.cbProduto.BorderColor = System.Drawing.Color.Silver;
            this.cbProduto.BorderWidth = 1F;
            this.cbProduto.Location = new System.Drawing.Point(68, 28);
            this.cbProduto.Margin = new System.Windows.Forms.Padding(1);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Radius = 10;
            this.cbProduto.Size = new System.Drawing.Size(195, 59);
            this.cbProduto.TabIndex = 5;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(1047, 40);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(150, 40);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar filtro";
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Location = new System.Drawing.Point(941, 40);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 40);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(20, 54);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "Produto";
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(20, 14);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(52, 13);
            this.lblFiltros.TabIndex = 0;
            this.lblFiltros.Text = "FILTROS";
            // 
            // pnlRelatorio
            // 
            this.pnlRelatorio.Controls.Add(this.lblAreaRelatorio);
            this.pnlRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRelatorio.Location = new System.Drawing.Point(24, 252);
            this.pnlRelatorio.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRelatorio.Name = "pnlRelatorio";
            this.pnlRelatorio.Padding = new System.Windows.Forms.Padding(2);
            this.pnlRelatorio.Size = new System.Drawing.Size(1216, 405);
            this.pnlRelatorio.TabIndex = 2;
            // 
            // lblAreaRelatorio
            // 
            this.lblAreaRelatorio.AutoSize = true;
            this.lblAreaRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAreaRelatorio.Location = new System.Drawing.Point(2, 2);
            this.lblAreaRelatorio.Name = "lblAreaRelatorio";
            this.lblAreaRelatorio.Size = new System.Drawing.Size(120, 13);
            this.lblAreaRelatorio.TabIndex = 0;
            this.lblAreaRelatorio.Text = "O relatório aparece aqui";
            this.lblAreaRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            this.pnlCabecalho.Controls.Add(this.flwBotoes);
            this.pnlCabecalho.Controls.Add(this.lblSubtitulo);
            this.pnlCabecalho.Controls.Add(this.lblTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecalho.Location = new System.Drawing.Point(24, 38);
            this.pnlCabecalho.Margin = new System.Windows.Forms.Padding(0, 22, 0, 16);
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlCabecalho.Size = new System.Drawing.Size(1216, 82);
            this.pnlCabecalho.TabIndex = 0;
            // 
            // flwBotoes
            // 
            this.flwBotoes.Controls.Add(this.btnImprimir);
            this.flwBotoes.Controls.Add(this.btnPrevia);
            this.flwBotoes.Controls.Add(this.btnFechar);
            this.flwBotoes.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwBotoes.Location = new System.Drawing.Point(776, 0);
            this.flwBotoes.Name = "flwBotoes";
            this.flwBotoes.Size = new System.Drawing.Size(420, 82);
            this.flwBotoes.TabIndex = 2;
            this.flwBotoes.WrapContents = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(290, 22);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(8, 22, 0, 0);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(130, 44);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnPrevia
            // 
            this.btnPrevia.Location = new System.Drawing.Point(132, 22);
            this.btnPrevia.Margin = new System.Windows.Forms.Padding(8, 22, 0, 0);
            this.btnPrevia.Name = "btnPrevia";
            this.btnPrevia.Size = new System.Drawing.Size(150, 44);
            this.btnPrevia.TabIndex = 1;
            this.btnPrevia.Text = "Pré-visualizar";
            this.btnPrevia.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(24, 22);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(8, 22, 0, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 44);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 54);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(256, 13);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Quantidade em estoque por produto • Guri Atacarejo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(105, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatório de estoque";
            // 
            // frmRelatorioEstoqueQtd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tlpRaiz);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmRelatorioEstoqueQtd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatorio de Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpRaiz.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlRelatorio.ResumeLayout(false);
            this.pnlRelatorio.PerformLayout();
            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.flwBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRaiz;
        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.FlowLayoutPanel flwBotoes;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPrevia;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private RoundComboBox cbProduto;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.Panel pnlRelatorio;
        private System.Windows.Forms.Label lblAreaRelatorio;
    }
}