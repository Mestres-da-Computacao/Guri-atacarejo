namespace Guri_atacarejo.forms
{
        partial class frmPainel
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.dataGridView1 = new System.Windows.Forms.DataGridView();
                        this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                        this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.registrarFuncionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.registrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.loginClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.logoutClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.registrarProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.label2 = new System.Windows.Forms.Label();
                        this.btnCancelar = new System.Windows.Forms.Button();
                        this.btnAlterar = new System.Windows.Forms.Button();
                        this.btnAdicionar = new System.Windows.Forms.Button();
                        this.btnFinalizar = new System.Windows.Forms.Button();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.panel3 = new System.Windows.Forms.Panel();
                        this.lblTotal = new System.Windows.Forms.Label();
                        this.label8 = new System.Windows.Forms.Label();
                        this.dataGridView2 = new System.Windows.Forms.DataGridView();
                        this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.preco_uni = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.unidade_medi = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.Validade = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        this.panel5 = new System.Windows.Forms.Panel();
                        this.label3 = new System.Windows.Forms.Label();
                        this.panel6 = new System.Windows.Forms.Panel();
                        this.label4 = new System.Windows.Forms.Label();
                        this.label5 = new System.Windows.Forms.Label();
                        this.label6 = new System.Windows.Forms.Label();
                        this.panel4 = new System.Windows.Forms.Panel();
                        this.label7 = new System.Windows.Forms.Label();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                        this.menuStrip1.SuspendLayout();
                        this.groupBox1.SuspendLayout();
                        this.TrocoContainer.SuspendLayout();
                        this.panel6.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
                        this.panel5.SuspendLayout();
                        this.panel3.SuspendLayout();
                        this.groupBox2.SuspendLayout();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                        this.panel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // menuStrip1
                        // 
                        this.menuStrip1.BackColor = System.Drawing.Color.White;
                        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionáriosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.registrarProdutosToolStripMenuItem});
                        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                        this.menuStrip1.Name = "menuStrip1";
                        this.menuStrip1.Size = new System.Drawing.Size(945, 24);
                        this.menuStrip1.TabIndex = 3;
                        this.menuStrip1.Text = "menuStrip1";
                        // 
                        // funcionáriosToolStripMenuItem
                        // 
                        this.funcionáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarFuncionárioToolStripMenuItem,
            this.logoutToolStripMenuItem});
                        this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
                        this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
                        this.funcionáriosToolStripMenuItem.Text = "Funcionários";
                        // 
                        // registrarFuncionárioToolStripMenuItem
                        // 
                        this.registrarFuncionárioToolStripMenuItem.Name = "registrarFuncionárioToolStripMenuItem";
                        this.registrarFuncionárioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                        this.registrarFuncionárioToolStripMenuItem.Text = "Registrar Funcionário";
                        this.registrarFuncionárioToolStripMenuItem.Click += new System.EventHandler(this.registrarFuncionárioToolStripMenuItem_Click);
                        // 
                        // logoutToolStripMenuItem
                        // 
                        this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
                        this.logoutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                        this.logoutToolStripMenuItem.Text = "Logout";
                        this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
                        // 
                        // clientesToolStripMenuItem
                        // 
                        this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClientesToolStripMenuItem,
            this.loginClienteToolStripMenuItem,
            this.logoutClienteToolStripMenuItem});
                        this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
                        this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
                        this.clientesToolStripMenuItem.Text = "Clientes";
                        // 
                        // registrarClientesToolStripMenuItem
                        // 
                        this.registrarClientesToolStripMenuItem.Name = "registrarClientesToolStripMenuItem";
                        this.registrarClientesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.registrarClientesToolStripMenuItem.Text = "Registrar Cliente";
                        this.registrarClientesToolStripMenuItem.Click += new System.EventHandler(this.registrarClientesToolStripMenuItem_Click);
                        // 
                        // loginClienteToolStripMenuItem
                        // 
                        this.loginClienteToolStripMenuItem.Name = "loginClienteToolStripMenuItem";
                        this.loginClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.loginClienteToolStripMenuItem.Text = "Login Cliente";
                        this.loginClienteToolStripMenuItem.Click += new System.EventHandler(this.loginClienteToolStripMenuItem_Click);
                        // 
                        // logoutClienteToolStripMenuItem
                        // 
                        this.logoutClienteToolStripMenuItem.Name = "logoutClienteToolStripMenuItem";
                        this.logoutClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.logoutClienteToolStripMenuItem.Text = "Logout Cliente";
                        this.logoutClienteToolStripMenuItem.Click += new System.EventHandler(this.logoutClienteToolStripMenuItem_Click);
                        // 
                        // registrarProdutosToolStripMenuItem
                        // 
                        this.registrarProdutosToolStripMenuItem.Name = "registrarProdutosToolStripMenuItem";
                        this.registrarProdutosToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
                        this.registrarProdutosToolStripMenuItem.Text = "Registrar Produtos";
                        this.registrarProdutosToolStripMenuItem.Click += new System.EventHandler(this.registrarProdutosToolStripMenuItem_Click);
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.panel1);
                        this.groupBox1.Controls.Add(this.cbPag);
                        this.groupBox1.Controls.Add(this.labelTroco);
                        this.groupBox1.Controls.Add(this.TrocoContainer);
                        this.groupBox1.Controls.Add(this.label5);
                        this.groupBox1.Controls.Add(this.panel6);
                        this.groupBox1.Controls.Add(this.panel5);
                        this.groupBox1.Controls.Add(this.panel3);
                        this.groupBox1.Controls.Add(this.groupBox2);
                        this.groupBox1.Controls.Add(this.panel2);
                        this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.groupBox1.ForeColor = System.Drawing.Color.White;
                        this.groupBox1.Location = new System.Drawing.Point(12, 37);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(920, 447);
                        this.groupBox1.TabIndex = 4;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "CAIXA LIVRE";
                        // 
                        // labelTroco
                        // 
                        this.labelTroco.AutoSize = true;
                        this.labelTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.labelTroco.ForeColor = System.Drawing.Color.White;
                        this.labelTroco.Location = new System.Drawing.Point(803, 348);
                        this.labelTroco.Name = "labelTroco";
                        this.labelTroco.Size = new System.Drawing.Size(111, 25);
                        this.labelTroco.TabIndex = 19;
                        this.labelTroco.Text = "R$ 420,69";
                        this.labelTroco.Visible = false;
                        // 
                        // TrocoContainer
                        // 
                        this.TrocoContainer.BackColor = System.Drawing.Color.White;
                        this.TrocoContainer.Controls.Add(this.label7);
                        this.TrocoContainer.Location = new System.Drawing.Point(788, 319);
                        this.TrocoContainer.Name = "TrocoContainer";
                        this.TrocoContainer.Size = new System.Drawing.Size(116, 26);
                        this.TrocoContainer.TabIndex = 20;
                        this.TrocoContainer.Visible = false;
                        // 
                        // label7
                        // 
                        this.label7.AutoSize = true;
                        this.label7.BackColor = System.Drawing.Color.White;
                        this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label7.Location = new System.Drawing.Point(3, 0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(65, 24);
                        this.label7.TabIndex = 0;
                        this.label7.Text = "Troco:";
                        // 
                        // label5
                        // 
                        this.label5.AutoSize = true;
                        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label5.ForeColor = System.Drawing.Color.White;
                        this.label5.Location = new System.Drawing.Point(463, 348);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(51, 25);
                        this.label5.TabIndex = 13;
                        this.label5.Text = "Não";
                        // 
                        // panel6
                        // 
                        this.panel6.BackColor = System.Drawing.Color.White;
                        this.panel6.Controls.Add(this.label4);
                        this.panel6.Controls.Add(this.dataGridView2);
                        this.panel6.Location = new System.Drawing.Point(460, 58);
                        this.panel6.Name = "panel6";
                        this.panel6.Size = new System.Drawing.Size(444, 255);
                        this.panel6.TabIndex = 18;
                        // 
                        // label4
                        // 
                        this.label4.AutoSize = true;
                        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label4.Location = new System.Drawing.Point(3, 6);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(314, 25);
                        this.label4.TabIndex = 4;
                        this.label4.Text = "INFORMAÇÕES DO PRODUTO";
                        // 
                        // dataGridView2
                        // 
                        this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
                        this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
                        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                        this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.preco_uni,
            this.unidade_medi,
            this.Validade});
                        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
                        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                        this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
                        this.dataGridView2.Location = new System.Drawing.Point(0, 36);
                        this.dataGridView2.Name = "dataGridView2";
                        this.dataGridView2.Size = new System.Drawing.Size(441, 219);
                        this.dataGridView2.TabIndex = 4;
                        // 
                        // panel5
                        // 
                        this.panel5.BackColor = System.Drawing.Color.White;
                        this.panel5.Controls.Add(this.label3);
                        this.panel5.Location = new System.Drawing.Point(460, 319);
                        this.panel5.Name = "panel5";
                        this.panel5.Size = new System.Drawing.Size(113, 26);
                        this.panel5.TabIndex = 17;
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.BackColor = System.Drawing.Color.White;
                        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label3.Location = new System.Drawing.Point(3, 0);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(105, 24);
                        this.label3.TabIndex = 0;
                        this.label3.Text = "Registrado:";
                        // 
                        // panel3
                        // 
                        this.panel3.BackColor = System.Drawing.Color.White;
                        this.panel3.Controls.Add(this.label9);
                        this.panel3.Controls.Add(this.label8);
                        this.panel3.Location = new System.Drawing.Point(411, 395);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(371, 37);
                        this.panel3.TabIndex = 16;
                        // 
                        // label9
                        // 
                        this.label9.AutoSize = true;
                        this.label9.BackColor = System.Drawing.Color.White;
                        this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label9.Location = new System.Drawing.Point(251, 3);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(120, 29);
                        this.label9.TabIndex = 12;
                        this.label9.Text = "R$ 420,69";
                        // 
                        // label8
                        // 
                        this.label8.AutoSize = true;
                        this.label8.BackColor = System.Drawing.Color.White;
                        this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label8.Location = new System.Drawing.Point(3, 3);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(117, 29);
                        this.label8.TabIndex = 1;
                        this.label8.Text = "SubTotal:";
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.button4);
                        this.groupBox2.Controls.Add(this.button3);
                        this.groupBox2.Controls.Add(this.button2);
                        this.groupBox2.Controls.Add(this.button1);
                        this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.groupBox2.ForeColor = System.Drawing.Color.White;
                        this.groupBox2.Location = new System.Drawing.Point(8, 339);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(383, 101);
                        this.groupBox2.TabIndex = 15;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "Ações";
                        // 
                        // button4
                        // 
                        this.button4.BackColor = System.Drawing.Color.White;
                        this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.button4.Location = new System.Drawing.Point(287, 36);
                        this.button4.Name = "button4";
                        this.button4.Size = new System.Drawing.Size(87, 42);
                        this.button4.TabIndex = 3;
                        this.button4.Text = "Finalizar Compra";
                        this.button4.UseVisualStyleBackColor = false;
                        // 
                        // button3
                        // 
                        this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.button3.ForeColor = System.Drawing.Color.White;
                        this.button3.Location = new System.Drawing.Point(194, 36);
                        this.button3.Name = "button3";
                        this.button3.Size = new System.Drawing.Size(87, 42);
                        this.button3.TabIndex = 2;
                        this.button3.Text = "Adicionar Produto";
                        this.button3.UseVisualStyleBackColor = true;
                        // 
                        // button2
                        // 
                        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.button2.ForeColor = System.Drawing.Color.White;
                        this.button2.Location = new System.Drawing.Point(101, 36);
                        this.button2.Name = "button2";
                        this.button2.Size = new System.Drawing.Size(87, 42);
                        this.button2.TabIndex = 1;
                        this.button2.Text = "Alterar Produto";
                        this.button2.UseVisualStyleBackColor = true;
                        // 
                        // button1
                        // 
                        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.button1.ForeColor = System.Drawing.Color.White;
                        this.button1.Location = new System.Drawing.Point(8, 36);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(87, 42);
                        this.button1.TabIndex = 0;
                        this.button1.Text = "Cancelar Venda";
                        this.button1.UseVisualStyleBackColor = true;
                        // 
                        // panel2
                        // 
                        this.panel2.BackColor = System.Drawing.Color.White;
                        this.panel2.Controls.Add(this.label2);
                        this.panel2.Controls.Add(this.dataGridView1);
                        this.panel2.Location = new System.Drawing.Point(8, 58);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(431, 275);
                        this.panel2.TabIndex = 14;
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label2.Location = new System.Drawing.Point(3, 4);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(229, 25);
                        this.label2.TabIndex = 3;
                        this.label2.Text = "LISTA DE PRODUTOS";
                        // 
                        // dataGridView1
                        // 
                        this.dataGridView1.AllowUserToAddRows = false;
                        this.dataGridView1.AllowUserToDeleteRows = false;
                        this.dataGridView1.AllowUserToResizeColumns = false;
                        this.dataGridView1.AllowUserToResizeRows = false;
                        this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
                        this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
                        dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
                        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
                        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Produto,
            this.qtd,
            this.custo,
            this.total});
                        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
                        dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                        this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
                        this.dataGridView1.Location = new System.Drawing.Point(0, 32);
                        this.dataGridView1.Name = "dataGridView1";
                        this.dataGridView1.ReadOnly = true;
                        this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView1.Size = new System.Drawing.Size(433, 254);
                        this.dataGridView1.TabIndex = 2;
                        this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
                        // 
                        // Id
                        // 
                        this.Id.HeaderText = "Id";
                        this.Id.Name = "Id";
                        this.Id.ReadOnly = true;
                        this.Id.Width = 50;
                        // 
                        // Produto
                        // 
                        this.Produto.HeaderText = "Produto";
                        this.Produto.Name = "Produto";
                        this.Produto.ReadOnly = true;
                        this.Produto.Width = 80;
                        // 
                        // qtd
                        // 
                        this.qtd.HeaderText = "Quantidade";
                        this.qtd.Name = "qtd";
                        this.qtd.ReadOnly = true;
                        this.qtd.Width = 80;
                        // 
                        // custo
                        // 
                        this.custo.HeaderText = "preço unitario";
                        this.custo.Name = "custo";
                        this.custo.ReadOnly = true;
                        this.custo.Width = 80;
                        // 
                        // total
                        // 
                        this.total.HeaderText = "total";
                        this.total.Name = "total";
                        this.total.ReadOnly = true;
                        this.total.Width = 80;
                        // 
                        // cbPag
                        // 
                        this.cbPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.cbPag.FormattingEnabled = true;
                        this.cbPag.Items.AddRange(new object[] {
            "Dinheiro",
            "Débito",
            "Crédito",
            "Pix"});
                        this.cbPag.Location = new System.Drawing.Point(579, 351);
                        this.cbPag.Name = "cbPag";
                        this.cbPag.Size = new System.Drawing.Size(142, 28);
                        this.cbPag.TabIndex = 21;
                        this.cbPag.SelectedIndexChanged += new System.EventHandler(this.cbPag_SelectedIndexChanged);
                        // 
                        // panel1
                        // 
                        this.funcionáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarFuncionárioToolStripMenuItem,
            this.logoutToolStripMenuItem});
                        this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
                        this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
                        this.funcionáriosToolStripMenuItem.Text = "Funcionários";
                        // 
                        // label10
                        // 
                        this.registrarFuncionárioToolStripMenuItem.Name = "registrarFuncionárioToolStripMenuItem";
                        this.registrarFuncionárioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                        this.registrarFuncionárioToolStripMenuItem.Text = "Registrar Funcionário";
                        // 
                        // logoutToolStripMenuItem
                        // 
                        this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
                        this.logoutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                        this.logoutToolStripMenuItem.Text = "Logout";
                        // 
                        // clientesToolStripMenuItem
                        // 
                        this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClientesToolStripMenuItem,
            this.loginClienteToolStripMenuItem,
            this.logoutClienteToolStripMenuItem});
                        this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
                        this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
                        this.clientesToolStripMenuItem.Text = "Clientes";
                        // 
                        // registrarClientesToolStripMenuItem
                        // 
                        this.registrarClientesToolStripMenuItem.Name = "registrarClientesToolStripMenuItem";
                        this.registrarClientesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.registrarClientesToolStripMenuItem.Text = "Registrar Cliente";
                        // 
                        // loginClienteToolStripMenuItem
                        // 
                        this.loginClienteToolStripMenuItem.Name = "loginClienteToolStripMenuItem";
                        this.loginClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.loginClienteToolStripMenuItem.Text = "Login Cliente";
                        // 
                        // logoutClienteToolStripMenuItem
                        // 
                        this.logoutClienteToolStripMenuItem.Name = "logoutClienteToolStripMenuItem";
                        this.logoutClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
                        this.logoutClienteToolStripMenuItem.Text = "Logout Cliente";
                        // 
                        // registrarProdutosToolStripMenuItem
                        // 
                        this.registrarProdutosToolStripMenuItem.Name = "registrarProdutosToolStripMenuItem";
                        this.registrarProdutosToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
                        this.registrarProdutosToolStripMenuItem.Text = "Registrar Produtos";
                        // 
                        // panel2
                        // 
                        this.panel2.BackColor = System.Drawing.Color.White;
                        this.panel2.Controls.Add(this.label2);
                        this.panel2.Controls.Add(this.dataGridView1);
                        this.panel2.Location = new System.Drawing.Point(12, 89);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(433, 275);
                        this.panel2.TabIndex = 4;
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label2.Location = new System.Drawing.Point(3, 4);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(229, 25);
                        this.label2.TabIndex = 3;
                        this.label2.Text = "LISTA DE PRODUTOS";
                        // 
                        // btnCancelar
                        // 
                        this.btnCancelar.ForeColor = System.Drawing.Color.Black;
                        this.btnCancelar.Location = new System.Drawing.Point(8, 16);
                        this.btnCancelar.Name = "btnCancelar";
                        this.btnCancelar.Size = new System.Drawing.Size(87, 42);
                        this.btnCancelar.TabIndex = 0;
                        this.btnCancelar.Text = "Cancelar Venda";
                        this.btnCancelar.UseVisualStyleBackColor = true;
                        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
                        // 
                        // btnAlterar
                        // 
                        this.btnAlterar.ForeColor = System.Drawing.Color.Black;
                        this.btnAlterar.Location = new System.Drawing.Point(110, 16);
                        this.btnAlterar.Name = "btnAlterar";
                        this.btnAlterar.Size = new System.Drawing.Size(87, 42);
                        this.btnAlterar.TabIndex = 1;
                        this.btnAlterar.Text = "Alterar Produto";
                        this.btnAlterar.UseVisualStyleBackColor = true;
                        this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
                        // 
                        // btnAdicionar
                        // 
                        this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
                        this.btnAdicionar.Location = new System.Drawing.Point(221, 16);
                        this.btnAdicionar.Name = "btnAdicionar";
                        this.btnAdicionar.Size = new System.Drawing.Size(87, 42);
                        this.btnAdicionar.TabIndex = 2;
                        this.btnAdicionar.Text = "Adicionar Produto";
                        this.btnAdicionar.UseVisualStyleBackColor = true;
                        this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
                        // 
                        // btnFinalizar
                        // 
                        this.btnFinalizar.ForeColor = System.Drawing.Color.Black;
                        this.btnFinalizar.Location = new System.Drawing.Point(328, 16);
                        this.btnFinalizar.Name = "btnFinalizar";
                        this.btnFinalizar.Size = new System.Drawing.Size(87, 42);
                        this.btnFinalizar.TabIndex = 3;
                        this.btnFinalizar.Text = "Finalizar Compra";
                        this.btnFinalizar.UseVisualStyleBackColor = true;
                        this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.btnFinalizar);
                        this.groupBox2.Controls.Add(this.btnAdicionar);
                        this.groupBox2.Controls.Add(this.btnAlterar);
                        this.groupBox2.Controls.Add(this.btnCancelar);
                        this.groupBox2.ForeColor = System.Drawing.Color.White;
                        this.groupBox2.Location = new System.Drawing.Point(12, 370);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(433, 68);
                        this.groupBox2.TabIndex = 6;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "Ações";
                        // 
                        // panel3
                        // 
                        this.panel3.BackColor = System.Drawing.Color.White;
                        this.panel3.Controls.Add(this.lblTotal);
                        this.panel3.Controls.Add(this.label8);
                        this.panel3.Location = new System.Drawing.Point(464, 370);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(313, 42);
                        this.panel3.TabIndex = 7;
                        // 
                        // lblTotal
                        // 
                        this.lblTotal.AutoSize = true;
                        this.lblTotal.BackColor = System.Drawing.Color.White;
                        this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.lblTotal.Location = new System.Drawing.Point(178, 0);
                        this.lblTotal.Name = "lblTotal";
                        this.lblTotal.Size = new System.Drawing.Size(109, 31);
                        this.lblTotal.TabIndex = 12;
                        this.lblTotal.Text = "R$ 0,00";
                        // 
                        // label8
                        // 
                        this.label8.AutoSize = true;
                        this.label8.BackColor = System.Drawing.Color.White;
                        this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label8.Location = new System.Drawing.Point(2, 0);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(117, 29);
                        this.label8.TabIndex = 1;
                        this.label8.Text = "SubTotal:";
                        // 
                        // dataGridView2
                        // 
                        this.dataGridView2.AllowUserToAddRows = false;
                        this.dataGridView2.AllowUserToDeleteRows = false;
                        this.dataGridView2.AllowUserToResizeColumns = false;
                        this.dataGridView2.AllowUserToResizeRows = false;
                        this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
                        this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.preco_uni,
            this.unidade_medi,
            this.Validade});
                        this.dataGridView2.Location = new System.Drawing.Point(0, 34);
                        this.dataGridView2.Name = "dataGridView2";
                        this.dataGridView2.Size = new System.Drawing.Size(313, 223);
                        this.dataGridView2.TabIndex = 4;
                        // 
                        // item
                        // 
                        this.item.HeaderText = "Produto";
                        this.item.Name = "item";
                        this.item.Width = 110;
                        // 
                        // preco_uni
                        // 
                        this.preco_uni.HeaderText = "preco_uni";
                        this.preco_uni.Name = "preco_uni";
                        this.preco_uni.Width = 80;
                        // 
                        // unidade_medi
                        // 
                        this.unidade_medi.HeaderText = "unidade_medi";
                        this.unidade_medi.Name = "unidade_medi";
                        this.unidade_medi.Width = 110;
                        // 
                        // Validade
                        // 
                        this.Validade.HeaderText = "Validade";
                        this.Validade.Name = "Validade";
                        this.Validade.Width = 50;
                        // 
                        // panel5
                        // 
                        this.panel5.BackColor = System.Drawing.Color.White;
                        this.panel5.Controls.Add(this.label3);
                        this.panel5.Location = new System.Drawing.Point(464, 300);
                        this.panel5.Name = "panel5";
                        this.panel5.Size = new System.Drawing.Size(155, 26);
                        this.panel5.TabIndex = 8;
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.BackColor = System.Drawing.Color.White;
                        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label3.Location = new System.Drawing.Point(3, 0);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(105, 24);
                        this.label3.TabIndex = 0;
                        this.label3.Text = "Registrado:";
                        this.label3.Click += new System.EventHandler(this.label3_Click);
                        // 
                        // panel6
                        // 
                        this.panel6.BackColor = System.Drawing.Color.White;
                        this.panel6.Controls.Add(this.label4);
                        this.panel6.Controls.Add(this.dataGridView2);
                        this.panel6.Location = new System.Drawing.Point(464, 38);
                        this.panel6.Name = "panel6";
                        this.panel6.Size = new System.Drawing.Size(313, 256);
                        this.panel6.TabIndex = 9;
                        // 
                        // label4
                        // 
                        this.label4.AutoSize = true;
                        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label4.Location = new System.Drawing.Point(3, 6);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(314, 25);
                        this.label4.TabIndex = 4;
                        this.label4.Text = "INFORMAÇÕES DO PRODUTO";
                        // 
                        // label5
                        // 
                        this.label5.AutoSize = true;
                        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label5.ForeColor = System.Drawing.Color.White;
                        this.label5.Location = new System.Drawing.Point(467, 329);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(51, 25);
                        this.label5.TabIndex = 4;
                        this.label5.Text = "Não";
                        // 
                        // label6
                        // 
                        this.label6.AutoSize = true;
                        this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label6.ForeColor = System.Drawing.Color.White;
                        this.label6.Location = new System.Drawing.Point(666, 329);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(87, 25);
                        this.label6.TabIndex = 10;
                        this.label6.Text = "R$ 0,00";
                        // 
                        // panel4
                        // 
                        this.panel4.BackColor = System.Drawing.Color.White;
                        this.panel4.Controls.Add(this.label7);
                        this.panel4.Location = new System.Drawing.Point(622, 300);
                        this.panel4.Name = "panel4";
                        this.panel4.Size = new System.Drawing.Size(155, 26);
                        this.panel4.TabIndex = 11;
                        // 
                        // label7
                        // 
                        this.label7.AutoSize = true;
                        this.label7.BackColor = System.Drawing.Color.White;
                        this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.label7.Location = new System.Drawing.Point(3, 0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(65, 24);
                        this.label7.TabIndex = 0;
                        this.label7.Text = "Troco:";
                        // 
                        // frmPainel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(119)))), ((int)(((byte)(27)))));
                        this.ClientSize = new System.Drawing.Size(945, 496);
                        this.Controls.Add(this.groupBox1);
                        this.Controls.Add(this.menuStrip1);
                        this.MainMenuStrip = this.menuStrip1;
                        this.Name = "frmPainel";
                        this.Text = "frmPainel";
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                        this.menuStrip1.ResumeLayout(false);
                        this.menuStrip1.PerformLayout();
                        this.groupBox1.ResumeLayout(false);
                        this.groupBox1.PerformLayout();
                        this.TrocoContainer.ResumeLayout(false);
                        this.TrocoContainer.PerformLayout();
                        this.panel6.ResumeLayout(false);
                        this.panel6.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
                        this.panel5.ResumeLayout(false);
                        this.panel5.PerformLayout();
                        this.panel3.ResumeLayout(false);
                        this.panel3.PerformLayout();
                        this.groupBox2.ResumeLayout(false);
                        this.panel2.ResumeLayout(false);
                        this.panel2.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.DataGridView dataGridView1;
                private System.Windows.Forms.MenuStrip menuStrip1;
                private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem registrarFuncionárioToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem registrarClientesToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem loginClienteToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem logoutClienteToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem registrarProdutosToolStripMenuItem;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Button btnCancelar;
                private System.Windows.Forms.Button btnAlterar;
                private System.Windows.Forms.Button btnAdicionar;
                private System.Windows.Forms.Button btnFinalizar;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.DataGridView dataGridView2;
                private System.Windows.Forms.Panel panel5;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.Label label9;
                private System.Windows.Forms.Label label8;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.Button button4;
                private System.Windows.Forms.Button button3;
                private System.Windows.Forms.Button button2;
                private System.Windows.Forms.Button button1;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.DataGridView dataGridView1;
                private System.Windows.Forms.ComboBox cbPag;
                private System.Windows.Forms.DataGridViewTextBoxColumn nmr;
                private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
                private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
                private System.Windows.Forms.DataGridViewTextBoxColumn custo;
                private System.Windows.Forms.DataGridViewTextBoxColumn total;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Label label10;
                private System.Windows.Forms.DataGridViewTextBoxColumn item;
                private System.Windows.Forms.DataGridViewTextBoxColumn preco_uni;
                private System.Windows.Forms.DataGridViewTextBoxColumn unidade_medi;
                private System.Windows.Forms.DataGridViewTextBoxColumn Validade;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label5;
                private System.Windows.Forms.Label label6;
                private System.Windows.Forms.Panel panel4;
                private System.Windows.Forms.Label label7;
                private System.Windows.Forms.Label label8;
                private System.Windows.Forms.Label lblTotal;
                private System.Windows.Forms.DataGridViewTextBoxColumn Id;
                private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
                private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
                private System.Windows.Forms.DataGridViewTextBoxColumn custo;
                private System.Windows.Forms.DataGridViewTextBoxColumn total;
        }
}