namespace Guri_atacarejo.forms
{
    partial class FrmLogon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogon));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Passwordtxtbox = new System.Windows.Forms.TextBox();
            this.Usertxtbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(643, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Passwordtxtbox
            // 
            this.Passwordtxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordtxtbox.Location = new System.Drawing.Point(155, 304);
            this.Passwordtxtbox.Multiline = true;
            this.Passwordtxtbox.Name = "Passwordtxtbox";
            this.Passwordtxtbox.Size = new System.Drawing.Size(360, 34);
            this.Passwordtxtbox.TabIndex = 1;
            this.Passwordtxtbox.Text = "Digite sua senha";
            this.Passwordtxtbox.Click += new System.EventHandler(this.Passwordtxtbox_Click);
            this.Passwordtxtbox.Leave += new System.EventHandler(this.Passwordtxtbox_Leave);
            // 
            // Usertxtbox
            // 
            this.Usertxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usertxtbox.Location = new System.Drawing.Point(155, 264);
            this.Usertxtbox.Multiline = true;
            this.Usertxtbox.Name = "Usertxtbox";
            this.Usertxtbox.Size = new System.Drawing.Size(360, 34);
            this.Usertxtbox.TabIndex = 2;
            this.Usertxtbox.Text = "Digite o usuário";
            this.Usertxtbox.Click += new System.EventHandler(this.Usertxtbox_Click);
            this.Usertxtbox.Leave += new System.EventHandler(this.Usertxtbox_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(270, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Entrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnEntrar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(256, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Esqueci minha senha";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BtnRecupSenha_Click);
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(667, 456);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Usertxtbox);
            this.Controls.Add(this.Passwordtxtbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmLogon";
            this.Text = "frmLogon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Passwordtxtbox;
        private System.Windows.Forms.TextBox Usertxtbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}