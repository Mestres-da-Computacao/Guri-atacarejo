
namespace Guri_atacarejo.forms
{
    partial class frmexibcaoentidades
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.telaDeVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbcar = new System.Windows.Forms.ComboBox();
            this.cbent = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telaDeVendasToolStripMenuItem,
            this.registroProdutoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // telaDeVendasToolStripMenuItem
            // 
            this.telaDeVendasToolStripMenuItem.Name = "telaDeVendasToolStripMenuItem";
            this.telaDeVendasToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.telaDeVendasToolStripMenuItem.Text = "Tela de Vendas";
            // 
            // registroProdutoToolStripMenuItem
            // 
            this.registroProdutoToolStripMenuItem.Name = "registroProdutoToolStripMenuItem";
            this.registroProdutoToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.registroProdutoToolStripMenuItem.Text = "Registro Produto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbcar);
            this.groupBox1.Controls.Add(this.cbent);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 401);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cbcar
            // 
            this.cbcar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcar.FormattingEnabled = true;
            this.cbcar.Items.AddRange(new object[] {
            "Nenhuma Entidade Selecionada"});
            this.cbcar.Location = new System.Drawing.Point(279, 98);
            this.cbcar.Name = "cbcar";
            this.cbcar.Size = new System.Drawing.Size(121, 21);
            this.cbcar.TabIndex = 2;
            // 
            // cbent
            // 
            this.cbent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbent.FormattingEnabled = true;
            this.cbent.Items.AddRange(new object[] {
            "Funcionários",
            "Produtos",
            "Fornecedores"});
            this.cbent.Location = new System.Drawing.Point(76, 98);
            this.cbent.Name = "cbent";
            this.cbent.Size = new System.Drawing.Size(121, 21);
            this.cbent.TabIndex = 1;
            this.cbent.SelectedIndexChanged += new System.EventHandler(this.cbent_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // frmexibcaoentidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmexibcaoentidades";
            this.Text = "frmexibcaoentidades";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem telaDeVendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroProdutoToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbcar;
        private System.Windows.Forms.ComboBox cbent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}