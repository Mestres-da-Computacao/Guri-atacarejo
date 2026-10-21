
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmexibcaoentidades));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.telaDeVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pesquisa = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbcar = new System.Windows.Forms.ComboBox();
            this.cbent = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.Pesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // Pesquisa
            // 
            this.Pesquisa.Controls.Add(this.pictureBox1);
            this.Pesquisa.Controls.Add(this.label2);
            this.Pesquisa.Controls.Add(this.label1);
            this.Pesquisa.Controls.Add(this.cbcar);
            this.Pesquisa.Controls.Add(this.cbent);
            this.Pesquisa.Controls.Add(this.dataGridView1);
            this.Pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pesquisa.ForeColor = System.Drawing.Color.White;
            this.Pesquisa.Location = new System.Drawing.Point(12, 37);
            this.Pesquisa.Name = "Pesquisa";
            this.Pesquisa.Size = new System.Drawing.Size(776, 345);
            this.Pesquisa.TabIndex = 1;
            this.Pesquisa.TabStop = false;
            this.Pesquisa.Text = "Pesquisa";
            this.Pesquisa.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar:";
            // 
            // cbcar
            // 
            this.cbcar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcar.FormattingEnabled = true;
            this.cbcar.Items.AddRange(new object[] {
            "Nenhuma Entidade Selecionada"});
            this.cbcar.Location = new System.Drawing.Point(350, 39);
            this.cbcar.Name = "cbcar";
            this.cbcar.Size = new System.Drawing.Size(165, 28);
            this.cbcar.TabIndex = 2;
            // 
            // cbent
            // 
            this.cbent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbent.FormattingEnabled = true;
            this.cbent.Items.AddRange(new object[] {
            "Funcionários",
            "Produtos",
            "Fornecedores"});
            this.cbent.Location = new System.Drawing.Point(105, 39);
            this.cbent.Name = "cbent";
            this.cbent.Size = new System.Drawing.Size(165, 28);
            this.cbent.TabIndex = 1;
            this.cbent.SelectedIndexChanged += new System.EventHandler(this.cbent_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(496, 248);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(285, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "O Que:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(521, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 306);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmexibcaoentidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(800, 394);
            this.Controls.Add(this.Pesquisa);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmexibcaoentidades";
            this.Text = "frmexibcaoentidades";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Pesquisa.ResumeLayout(false);
            this.Pesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem telaDeVendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroProdutoToolStripMenuItem;
        private System.Windows.Forms.GroupBox Pesquisa;
        private System.Windows.Forms.ComboBox cbcar;
        private System.Windows.Forms.ComboBox cbent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}