
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmexibcaoentidades));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Pesquisa = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbcar = new System.Windows.Forms.ComboBox();
            this.cbent = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Pesquisa
            // 
            this.Pesquisa.Controls.Add(this.label2);
            this.Pesquisa.Controls.Add(this.label1);
            this.Pesquisa.Controls.Add(this.cbcar);
            this.Pesquisa.Controls.Add(this.cbent);
            this.Pesquisa.Controls.Add(this.dataGridView1);
            this.Pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Pesquisa.ForeColor = System.Drawing.Color.White;
            this.Pesquisa.Location = new System.Drawing.Point(16, 47);
            this.Pesquisa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pesquisa.Name = "Pesquisa";
            this.Pesquisa.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pesquisa.Size = new System.Drawing.Size(715, 425);
            this.Pesquisa.TabIndex = 1;
            this.Pesquisa.TabStop = false;
            this.Pesquisa.Text = "Pesquisa";
            this.Pesquisa.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(380, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "O Que:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar:";
            // 
            // cbcar
            // 
            this.cbcar.BackColor = System.Drawing.Color.White;
            this.cbcar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcar.FormattingEnabled = true;
            this.cbcar.Items.AddRange(new object[] {
            "Nenhuma Entidade Selecionada"});
            this.cbcar.Location = new System.Drawing.Point(467, 48);
            this.cbcar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbcar.Name = "cbcar";
            this.cbcar.Size = new System.Drawing.Size(219, 33);
            this.cbcar.TabIndex = 2;
            // 
            // cbent
            // 
            this.cbent.BackColor = System.Drawing.Color.White;
            this.cbent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbent.ForeColor = System.Drawing.Color.Black;
            this.cbent.FormattingEnabled = true;
            this.cbent.Items.AddRange(new object[] {
            "Funcionários",
            "Produtos",
            "Fornecedores",
            "Clientes"});
            this.cbent.Location = new System.Drawing.Point(152, 48);
            this.cbent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbent.Name = "cbent";
            this.cbent.Size = new System.Drawing.Size(219, 33);
            this.cbent.TabIndex = 1;
            this.cbent.SelectedIndexChanged += new System.EventHandler(this.cbent_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(25, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(661, 305);
            this.dataGridView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(739, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 407);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmexibcaoentidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1089, 489);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Pesquisa);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmexibcaoentidades";
            this.Text = "frmexibcaoentidades";
            this.Pesquisa.ResumeLayout(false);
            this.Pesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox Pesquisa;
        private System.Windows.Forms.ComboBox cbcar;
        private System.Windows.Forms.ComboBox cbent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}