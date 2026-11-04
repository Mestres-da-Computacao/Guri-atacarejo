namespace Guri_atacarejo.forms
{
    partial class frmPainel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forneceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroFornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraLotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maisOpçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioFinanceiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarProdutosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarFuncionariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcProdFornToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRS = new System.Windows.Forms.Label();
            this.txtReciboDinheiro = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelClienteRegistrado = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco_uni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade_medi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Validade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPag = new System.Windows.Forms.ComboBox();
            this.TrocoContainer = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTroco = new System.Windows.Forms.Label();
            this.pnlPagamento = new System.Windows.Forms.Panel();
            this.pnlAcoes = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.TrocoContainer.SuspendLayout();
            this.pnlAcoes.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionáriosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.forneceToolStripMenuItem,
            this.maisOpçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
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
            // forneceToolStripMenuItem
            // 
            this.forneceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroFornecedoresToolStripMenuItem,
            this.compraLotesToolStripMenuItem});
            this.forneceToolStripMenuItem.Name = "forneceToolStripMenuItem";
            this.forneceToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.forneceToolStripMenuItem.Text = "Fornecedores";
            // 
            // registroFornecedoresToolStripMenuItem
            // 
            this.registroFornecedoresToolStripMenuItem.Name = "registroFornecedoresToolStripMenuItem";
            this.registroFornecedoresToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.registroFornecedoresToolStripMenuItem.Text = "Registro Fornecedores";
            this.registroFornecedoresToolStripMenuItem.Click += new System.EventHandler(this.registrarFornecedorToolStripMenuItem_Click);
            // 
            // compraLotesToolStripMenuItem
            // 
            this.compraLotesToolStripMenuItem.Name = "compraLotesToolStripMenuItem";
            this.compraLotesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.compraLotesToolStripMenuItem.Text = "Compra Lotes";
            this.compraLotesToolStripMenuItem.Click += new System.EventHandler(this.compraDeLotesToolStripMenuItem_Click);
            // 
            // maisOpçõesToolStripMenuItem
            // 
            this.maisOpçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatóriosToolStripMenuItem,
            this.lotesToolStripMenuItem,
            this.registrarProdutosToolStripMenuItem1,
            this.registrarFuncionariosToolStripMenuItem,
            this.funcProdFornToolStripMenuItem});
            this.maisOpçõesToolStripMenuItem.Name = "maisOpçõesToolStripMenuItem";
            this.maisOpçõesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.maisOpçõesToolStripMenuItem.Text = "Mais opções";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioFinanceiroToolStripMenuItem,
            this.relatórioDeEstoqueToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // relatórioFinanceiroToolStripMenuItem
            // 
            this.relatórioFinanceiroToolStripMenuItem.Name = "relatórioFinanceiroToolStripMenuItem";
            this.relatórioFinanceiroToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.relatórioFinanceiroToolStripMenuItem.Text = "Relatório movimentação financeira";
            this.relatórioFinanceiroToolStripMenuItem.Click += new System.EventHandler(this.relatórioFinanceiroToolStripMenuItem_Click);
            // 
            // relatórioDeEstoqueToolStripMenuItem
            // 
            this.relatórioDeEstoqueToolStripMenuItem.Name = "relatórioDeEstoqueToolStripMenuItem";
            this.relatórioDeEstoqueToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.relatórioDeEstoqueToolStripMenuItem.Text = "Relatório fluxo estoque";
            this.relatórioDeEstoqueToolStripMenuItem.Click += new System.EventHandler(this.relatórioDeEstoqueToolStripMenuItem_Click);
            // 
            // lotesToolStripMenuItem
            // 
            this.lotesToolStripMenuItem.Name = "lotesToolStripMenuItem";
            this.lotesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.lotesToolStripMenuItem.Text = "Lotes";
            this.lotesToolStripMenuItem.Click += new System.EventHandler(this.lotesToolStripMenuItem_Click);
            // 
            // registrarProdutosToolStripMenuItem1
            // 
            this.registrarProdutosToolStripMenuItem1.Name = "registrarProdutosToolStripMenuItem1";
            this.registrarProdutosToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.registrarProdutosToolStripMenuItem1.Text = "Registrar produtos";
            this.registrarProdutosToolStripMenuItem1.Click += new System.EventHandler(this.registrarProdutosToolStripMenuItem1_Click);
            // 
            // registrarFuncionariosToolStripMenuItem
            // 
            this.registrarFuncionariosToolStripMenuItem.Name = "registrarFuncionariosToolStripMenuItem";
            this.registrarFuncionariosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.registrarFuncionariosToolStripMenuItem.Text = "Registrar Funcionários";
            this.registrarFuncionariosToolStripMenuItem.Click += new System.EventHandler(this.registrarFuncionariosToolStripMenuItem_Click);
            // 
            // funcProdFornToolStripMenuItem
            // 
            this.funcProdFornToolStripMenuItem.Name = "funcProdFornToolStripMenuItem";
            this.funcProdFornToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.funcProdFornToolStripMenuItem.Text = "Consulta geral";
            this.funcProdFornToolStripMenuItem.Click += new System.EventHandler(this.funcProdFornToolStripMenuItem_Click);
            // 
            // lblRS
            // 
            this.lblRS.AutoSize = true;
            this.lblRS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.lblRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRS.ForeColor = System.Drawing.Color.White;
            this.lblRS.Location = new System.Drawing.Point(842, 512);
            this.lblRS.Name = "lblRS";
            this.lblRS.Size = new System.Drawing.Size(43, 24);
            this.lblRS.TabIndex = 21;
            this.lblRS.Text = "RS:";
            this.lblRS.Visible = false;
            // 
            // txtReciboDinheiro
            // 
            this.txtReciboDinheiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.txtReciboDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReciboDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciboDinheiro.ForeColor = System.Drawing.Color.White;
            this.txtReciboDinheiro.Location = new System.Drawing.Point(882, 514);
            this.txtReciboDinheiro.Name = "txtReciboDinheiro";
            this.txtReciboDinheiro.Size = new System.Drawing.Size(170, 22);
            this.txtReciboDinheiro.TabIndex = 20;
            this.txtReciboDinheiro.Text = "00,00";
            this.txtReciboDinheiro.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(24, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 481);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.label2.Location = new System.Drawing.Point(16, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 0;
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Produto,
            this.qtd,
            this.custo,
            this.total});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(105)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(94)))), ((int)(((byte)(58)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(760, 437);
            this.dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 45;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Produto.HeaderText = "Produto";
            this.Produto.MinimumWidth = 6;
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // qtd
            // 
            this.qtd.HeaderText = "Quantidade";
            this.qtd.MinimumWidth = 6;
            this.qtd.Name = "qtd";
            this.qtd.ReadOnly = true;
            this.qtd.Width = 95;
            // 
            // custo
            // 
            this.custo.HeaderText = "Preço unitário";
            this.custo.MinimumWidth = 6;
            this.custo.Name = "custo";
            this.custo.ReadOnly = true;
            this.custo.Width = 95;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 75;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.labelClienteRegistrado);
            this.panel5.Location = new System.Drawing.Point(1072, 458);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 30);
            this.panel5.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente:";
            // 
            // labelClienteRegistrado
            // 
            this.labelClienteRegistrado.AutoSize = true;
            this.labelClienteRegistrado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.labelClienteRegistrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteRegistrado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.labelClienteRegistrado.Location = new System.Drawing.Point(60, 0);
            this.labelClienteRegistrado.Name = "labelClienteRegistrado";
            this.labelClienteRegistrado.Size = new System.Drawing.Size(113, 20);
            this.labelClienteRegistrado.TabIndex = 4;
            this.labelClienteRegistrado.Text = "Não registrado";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.dataGridView2);
            this.panel6.Location = new System.Drawing.Point(808, 96);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(518, 280);
            this.panel6.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.label4.Location = new System.Drawing.Point(16, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "INFORMAÇÕES DO PRODUTO";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.preco_uni,
            this.unidade_medi,
            this.Validade});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(105)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView2.Location = new System.Drawing.Point(0, 44);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(518, 236);
            this.dataGridView2.TabIndex = 1;
            // 
            // item
            // 
            this.item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item.HeaderText = "Produto";
            this.item.MinimumWidth = 6;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // preco_uni
            // 
            this.preco_uni.HeaderText = "Preço unitário";
            this.preco_uni.MinimumWidth = 6;
            this.preco_uni.Name = "preco_uni";
            this.preco_uni.ReadOnly = true;
            this.preco_uni.Width = 105;
            // 
            // unidade_medi
            // 
            this.unidade_medi.HeaderText = "Unidade";
            this.unidade_medi.MinimumWidth = 6;
            this.unidade_medi.Name = "unidade_medi";
            this.unidade_medi.ReadOnly = true;
            this.unidade_medi.Width = 85;
            // 
            // Validade
            // 
            this.Validade.HeaderText = "Validade";
            this.Validade.MinimumWidth = 6;
            this.Validade.Name = "Validade";
            this.Validade.ReadOnly = true;
            this.Validade.Width = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(832, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Forma de pagamento:";
            // 
            // cbPag
            // 
            this.cbPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPag.FormattingEnabled = true;
            this.cbPag.Items.AddRange(new object[] {
            "Dinheiro",
            "Débito",
            "Crédito",
            "Pix"});
            this.cbPag.Location = new System.Drawing.Point(832, 458);
            this.cbPag.Name = "cbPag";
            this.cbPag.Size = new System.Drawing.Size(230, 32);
            this.cbPag.TabIndex = 16;
            // 
            // TrocoContainer
            // 
            this.TrocoContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.TrocoContainer.Controls.Add(this.label7);
            this.TrocoContainer.Controls.Add(this.labelTroco);
            this.TrocoContainer.Location = new System.Drawing.Point(1072, 506);
            this.TrocoContainer.Name = "TrocoContainer";
            this.TrocoContainer.Size = new System.Drawing.Size(230, 36);
            this.TrocoContainer.TabIndex = 17;
            this.TrocoContainer.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.label7.Location = new System.Drawing.Point(7, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Troco:";
            // 
            // labelTroco
            // 
            this.labelTroco.AutoSize = true;
            this.labelTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTroco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.labelTroco.Location = new System.Drawing.Point(61, 5);
            this.labelTroco.Name = "labelTroco";
            this.labelTroco.Size = new System.Drawing.Size(65, 17);
            this.labelTroco.TabIndex = 1;
            this.labelTroco.Text = "R$ 0,00";
            // 
            // pnlPagamento
            // 
            this.pnlPagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.pnlPagamento.Location = new System.Drawing.Point(808, 392);
            this.pnlPagamento.Name = "pnlPagamento";
            this.pnlPagamento.Size = new System.Drawing.Size(518, 185);
            this.pnlPagamento.TabIndex = 22;
            // 
            // pnlAcoes
            // 
            this.pnlAcoes.Controls.Add(this.btnCancelar);
            this.pnlAcoes.Controls.Add(this.btnAlterar);
            this.pnlAcoes.Controls.Add(this.btnAdicionar);
            this.pnlAcoes.Controls.Add(this.btnFinalizar);
            this.pnlAcoes.Location = new System.Drawing.Point(24, 593);
            this.pnlAcoes.Name = "pnlAcoes";
            this.pnlAcoes.Size = new System.Drawing.Size(760, 112);
            this.pnlAcoes.TabIndex = 18;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.btnCancelar.Location = new System.Drawing.Point(16, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 56);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar venda";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.btnAlterar.Location = new System.Drawing.Point(201, 40);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(173, 56);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar produto";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click_1);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.btnAdicionar.Location = new System.Drawing.Point(386, 40);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(173, 56);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar produto";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.btnFinalizar.Location = new System.Drawing.Point(571, 40);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(173, 56);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "Finalizar compra";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Location = new System.Drawing.Point(808, 593);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 112);
            this.panel3.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.label8.Location = new System.Drawing.Point(18, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Subtotal:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(58)))), ((int)(((byte)(32)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(157)))), ((int)(((byte)(24)))));
            this.lblTotal.Location = new System.Drawing.Point(0, 46);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(101, 29);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "R$ 0,00";
            // 
            // frmPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(151)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.lblRS);
            this.Controls.Add(this.txtReciboDinheiro);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbPag);
            this.Controls.Add(this.TrocoContainer);
            this.Controls.Add(this.pnlAcoes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlPagamento);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(974, 582);
            this.Name = "frmPainel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Painel de vendas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.TrocoContainer.ResumeLayout(false);
            this.TrocoContainer.PerformLayout();
            this.pnlAcoes.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maisOpçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioFinanceiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarProdutosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarFuncionariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forneceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroFornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraLotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcProdFornToolStripMenuItem;
        private System.Windows.Forms.Label lblRS;
        private System.Windows.Forms.TextBox txtReciboDinheiro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelClienteRegistrado;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco_uni;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade_medi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Validade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPag;
        private System.Windows.Forms.Panel TrocoContainer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTroco;
        private System.Windows.Forms.Panel pnlPagamento;
        private System.Windows.Forms.Panel pnlAcoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
    }
}
