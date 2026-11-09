using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmImprimirCompra : Icone
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(Color fundo, Color texto)
        {
            // O DWM espera o formato COLORREF: 0x00BBGGRR
            int corFundo = fundo.R | (fundo.G << 8) | (fundo.B << 16);
            int corTexto = texto.R | (texto.G << 8) | (texto.B << 16);

            DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref corFundo, sizeof(int));
            DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref corTexto, sizeof(int));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Cor da barra superior do form
            DefinirCorBarra(Color.FromArgb(19, 83, 46), Color.White);
        }

        // filtro de datas aplicado na tela (o relatório usa o mesmo)
        DateTime? filtroInicio = null;
        DateTime? filtroFim = null;

        private BarraLateral barraLateral;

        public frmImprimirCompra()
        {
            InitializeComponent();

            AplicarTema();          // visual igual ao do frmPainel (TemaModerno)
            AplicarTemaRelatorio("Relat\u00F3rio de compras");
            ResponsividadeForm.Aplicar(this);

            cbtempo.Leave += cbtempo_Leave;
            maskData.TextChanged += maskData_TextChanged;

            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;

            cbtempo.SelectedIndex = 0;

            CriarBarraLateral();    // a barrinha de cima virou a barra lateral

            this.Text = "Relatório de compras";
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void cbtempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbtempo.SelectedIndex)
            {
                case 0:
                    maskData.Mask = "00/00/0000";
                    break;
                case 1:
                    maskData.Mask = "00/0000";
                    break;
                case 2:
                    maskData.Mask = "0000";
                    break;
            }
        }

        private void CarregarProdutos(DateTime? inicio = null, DateTime? fim = null)
        {
            filtroInicio = inicio;
            filtroFim = fim;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;

            try
            {
                DataSet.GA_CompraRelatorioDataTable compras;
                using (var adapter = new DataSetTableAdapters.GA_CompraRelatorioTableAdapter())
                    compras = adapter.GetCompras(inicio, fim);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DataCompra",
                    HeaderText = "Data",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StatusCompra",
                    HeaderText = "Tipo",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ValorTotal",
                    HeaderText = "Valor",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                // título da coluna "Valor" alinhado com os valores (direita)
                dataGridView1.Columns[2].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dataGridView1.DataSource = compras;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        private void AplicarFiltro(bool mostrarAvisos)
        {
            if (!maskData.MaskCompleted)
            {
                if (mostrarAvisos)
                    MessageBox.Show("Preencha a data completa.");
                else
                    CarregarProdutos(); // sem data preenchida, mostra tudo
                return;
            }

            string texto = maskData.Text;
            DateTime inicio, fim;
            bool ok;

            switch (cbtempo.SelectedIndex)
            {
                case 0: // dia
                    ok = DateTime.TryParseExact(texto, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddDays(1);
                    break;

                case 1: // mês
                    ok = DateTime.TryParseExact(texto, "MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddMonths(1);
                    break;

                default: // ano
                    ok = DateTime.TryParseExact(texto, "yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio);
                    fim = inicio.AddYears(1);
                    break;
            }

            // data inválida (ex.: 67/67/6767): avisa e limpa
            if (!ok)
            {
                MessageBox.Show("Data inválida.", "Data inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskData.Clear();
                maskData.Focus();
                return;
            }

            // data futura: avisa e limpa
            DateTime hoje = DateTime.Today;
            bool futura;

            switch (cbtempo.SelectedIndex)
            {
                case 0: // dia
                    futura = inicio.Date > hoje;
                    break;
                case 1: // mês
                    futura = inicio > new DateTime(hoje.Year, hoje.Month, 1);
                    break;
                default: // ano
                    futura = inicio.Year > hoje.Year;
                    break;
            }

            if (futura)
            {
                MessageBox.Show("Não é possível consultar datas futuras.", "Data inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskData.Clear();
                maskData.Focus();
                return;
            }

            CarregarProdutos(inicio, fim);
        }

        private void cbtempo_Leave(object sender, EventArgs e)
        {
            AplicarFiltro(false);
        }

        private void maskData_TextChanged(object sender, EventArgs e)
        {
            if (maskData.MaskCompleted)
                AplicarFiltro(false);
        }

        private void MostrarDetalhes(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count) return;

            var drv = dataGridView1.Rows[rowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            int idCompra = Convert.ToInt32(drv["IdCompra"]);
            var sb = new StringBuilder();

            sb.AppendLine("COMPRA Nº " + idCompra);
            sb.AppendLine("Data: " + Convert.ToDateTime(drv["DataCompra"]).ToString("dd/MM/yyyy"));
            sb.AppendLine("Status: " + drv["StatusCompra"]);
            sb.AppendLine("Pagamento: " + (drv["FormaPagamento"] == DBNull.Value ? "-" : drv["FormaPagamento"]));
            sb.AppendLine("Fornecedor: " + drv["NomeFornecedor"]);
            sb.AppendLine("Funcionário: " + drv["NomeFuncionario"]);
            sb.AppendLine("Valor total: " + Convert.ToDecimal(drv["ValorTotal"]).ToString("C2"));
            sb.AppendLine();
            sb.AppendLine("ITENS:");

            try
            {
                DataSet.GA_ItensCompraRelatorioDataTable itens;
                using (var adapter = new DataSetTableAdapters.GA_ItensCompraRelatorioTableAdapter())
                    itens = adapter.GetItensPorCompra(idCompra);

                if (itens.Rows.Count == 0)
                    sb.AppendLine("(nenhum item)");
                else
                {
                    foreach (DataRow item in itens.Rows)
                    {
                        sb.AppendLine(string.Format("- {0} (Lote {1}): {2} x {3:C2} = {4:C2}",
                            item["Produto"], item["FKLote"], item["Quantidade"],
                            item["PrecoUnitario"], item["Subtotal"]));
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("Erro ao carregar itens: " + ex.Message);
            }

            textBox2.Text = sb.ToString();
        }

        // Ao passar o mouse por cima da linha
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetalhes(e.RowIndex);
        }

        // reseta o filtro
        private void btnResetarFiltro_Click(object sender, EventArgs e)
        {
            maskData.Clear();
            cbtempo.SelectedIndex = 0;
            CarregarProdutos();
            textBox2.Clear();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //deslogar o funcionario com a classe sessão que esta na main
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        #region Visual moderno (cartão, barra lateral)

        // ------------------------------------------------------------------
        // Reorganiza os controles do designer num cartão, dentro de um painel
        // "host" que preenche a área ao lado da barra lateral.
        // ------------------------------------------------------------------
        private void AplicarTema()
        {
            SuspendLayout();

            ClientSize = new Size(1180, 640);
            BackColor = TemaModerno.Fundo;
            Text = "Relat\u00F3rio de compras";

            const int m = 24;
            int W = ClientSize.Width - BarraLateral.LarguraAberta;
            int H = ClientSize.Height;

            int topo = 96;
            int cartaoW = W - 2 * m;
            int cartaoH = H - topo - m;

            // o GroupBox laranja do designer (pai da tabela) vai ser escondido no fim
            Control caixaAntiga = dataGridView1.Parent;

            var host = new Panel
            {
                Name = "pnlConteudo",
                Dock = DockStyle.Fill,
                BackColor = TemaModerno.Fundo
            };

            // ---- título da tela ----
            host.Controls.Add(NovoRotulo("Movimento financeiro", 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Relat\u00F3rio de compras  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // ---- cartão: REGISTRO DO MOVIMENTO FINANCEIRO ----
            var cartao = new Panel { Bounds = new Rectangle(m, topo, cartaoW, cartaoH) };
            TemaModerno.Cartao(cartao);

            cartao.Controls.Add(NovoRotulo("Registro do movimento financeiro", 12f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Card, new Point(20, 14)));

            // filtros (tudo alinhado pelo centro vertical do botão)
            TemaModerno.Combo(cbtempo);
            AjustarAlturaCombo(cbtempo);   // sem isso o texto do combo fica cortado
            cbtempo.Location = new Point(20, 56);
            cbtempo.Width = 170;
            cartao.Controls.Add(cbtempo);

            maskData.Font = TemaModerno.Fonte(11f);
            maskData.BackColor = TemaModerno.Campo;
            maskData.ForeColor = TemaModerno.Texto;
            maskData.Location = new Point(206, 56);
            maskData.Width = 150;
            cartao.Controls.Add(maskData);

            TemaModerno.Botao(btnResetarFiltro, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            btnResetarFiltro.Padding = Padding.Empty;
            btnResetarFiltro.TextAlign = ContentAlignment.MiddleCenter;
            btnResetarFiltro.Bounds = new Rectangle(372, 52, 140, 40);
            cartao.Controls.Add(btnResetarFiltro);

            // mantém combo, data e botão no mesmo eixo, mesmo depois do redimensionamento
            Action alinhar = AlinharFiltros;
            btnResetarFiltro.SizeChanged += (s, e) => alinhar();
            btnResetarFiltro.LocationChanged += (s, e) => alinhar();
            cbtempo.SizeChanged += (s, e) => alinhar();
            maskData.SizeChanged += (s, e) => alinhar();
            alinhar();

            // tabela (esquerda) + detalhes (direita)
            int areaY = 108;
            int areaH = cartaoH - areaY - 20;
            int gridW = (cartaoW - 40 - 16) * 45 / 100;
            int detX = 20 + gridW + 16;
            int detW = cartaoW - 20 - detX;

            cartao.Controls.Add(dataGridView1);
            dataGridView1.Bounds = new Rectangle(20, areaY, gridW, areaH);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            TemaModerno.Grid(dataGridView1);

            cartao.Controls.Add(textBox2);
            textBox2.Font = TemaModerno.Fonte(10f);
            textBox2.BackColor = TemaModerno.Campo;
            textBox2.ForeColor = TemaModerno.Texto;
            textBox2.Bounds = new Rectangle(detX, areaY, detW, areaH);

            // botão "Imprimir relatório" no canto direito do cabeçalho
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            btnImprimir.Text = "Imprimir relat\u00F3rio";
            btnImprimir.Size = new Size(180, 44);
            PadraoTela.CentralizarTexto(btnImprimir);
            host.Controls.Add(btnImprimir);
            Action posicionarImprimir = () =>
                btnImprimir.Location = new Point(host.ClientSize.Width - btnImprimir.Width - m, 22);
            host.Resize += (s, e) => posicionarImprimir();
            posicionarImprimir();

            host.Controls.Add(cartao);

            // a navegação agora é a barra lateral: esconde a barra de cima e a caixa antiga
            toolStrip1.Visible = false;
            if (caixaAntiga != null && caixaAntiga != this && caixaAntiga != cartao)
                caixaAntiga.Visible = false;

            // ---- host por último: Fill precisa ser o último a ser "docado" ----
            Controls.Add(host);
            host.BringToFront();

            ResumeLayout(true);
        }

        // ------------------------------------------------------------------
        // Barra lateral montada a partir dos itens da barra de cima (toolStrip1).
        // Cada clique é repassado com PerformClick, então os eventos já existentes
        // (toolStripButton1_Click etc.) continuam funcionando.
        // ------------------------------------------------------------------
        private void CriarBarraLateral()
        {
            var menu = new MenuStrip();

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripSeparator)
                    continue;

                // o botão de sair só tem imagem, então ganha um nome
                string texto =
                    item.DisplayStyle == ToolStripItemDisplayStyle.Image ||
                    string.IsNullOrWhiteSpace(item.Text)
                        ? "Logout"
                        : item.Text.Trim();

                ToolStripItem origem = item;
                Action acao = AcaoDoItem(texto, origem);
                var novo = new ToolStripMenuItem(texto);
                novo.Click += (s, e) => acao();
                menu.Items.Add(novo);
            }

            barraLateral = new BarraLateral(menu);
            Controls.Add(barraLateral);
            barraLateral.SendToBack();   // docka antes do conteúdo (que é Fill)
        }

        // Define o que cada item da barra lateral faz, pelo texto do item.
        // Itens desconhecidos continuam chamando o clique original do botão.
        private Action AcaoDoItem(string texto, ToolStripItem origem)
        {
            string t = texto.ToLowerInvariant();

            if (t.Contains("venda"))
                return Close;                         // volta para o painel de vendas

            if (t.Contains("produto"))
                return () =>
                {
                    using (var f = new frmCadastroProduto())
                        f.ShowDialog(this);
                };

            if (t.Contains("funcion"))
                return () =>
                {
                    using (var f = new frmCadastroFuncionario())
                        f.ShowDialog(this);
                };

            if (t.Contains("logout"))
                return Deslogar;

            return () => origem.PerformClick();
        }

        // Mesmo logout do painel: limpa as sessões e fecha as telas (volta ao login).
        private void Deslogar()
        {
            Sessao.NivelFuncionario = 0;
            Sessao.IdFuncionario = 0;
            Sessao.Usuario = null;
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Cpf = null;
            SessaoClientes.IdCliente = 0;

            // este form foi aberto com ShowDialog(painel): fecha o painel também
            Form painel = Owner;
            Close();
            if (painel != null && !painel.IsDisposed)
                painel.BeginInvoke(new Action(painel.Close));
        }

        // centraliza combo e campo de data na altura do botão "Resetar filtro"
        private void AlinharFiltros()
        {
            int centro = btnResetarFiltro.Top + btnResetarFiltro.Height / 2;
            cbtempo.Top = centro - cbtempo.Height / 2;
            maskData.Top = centro - maskData.Height / 2;
        }

        // Combo com owner-draw tem altura fixa (ItemHeight): sem isto o texto fica
        // cortado quando a fonte cresce ao maximizar a janela.
        private static void AjustarAlturaCombo(ComboBox c)
        {
            Action ajustar = () =>
            {
                if (c.DrawMode != DrawMode.Normal)
                    c.ItemHeight = c.Font.Height + 10;
            };
            c.FontChanged += (s, e) => ajustar();
            ajustar();
        }

        private static Label NovoRotulo(string texto, float tamanho, FontStyle estilo,
            Color cor, Color fundo, Point local)
        {
            return new Label
            {
                AutoSize = true,
                Text = texto,
                Font = TemaModerno.Fonte(tamanho, estilo),
                ForeColor = cor,
                BackColor = fundo,
                Location = local
            };
        }

        #endregion

        // ------------------------------------------------------
        // TELA DO RELATÓRIO (RDLC): mesmo visual das outras telas
        // ------------------------------------------------------

        private Button btnImprimirRel;   // botão "Imprimir" dentro da tela do relatório

        private void AplicarTemaRelatorio(string titulo)
        {
            pnlRelatorio.BackColor = TemaModerno.Fundo;
            pnlRelatorio.Padding = new Padding(24, 16, 24, 24);

            // barra do topo: título + botões
            var barra = new Panel { Dock = DockStyle.Top, Height = 84, BackColor = TemaModerno.Fundo };
            barra.Controls.Add(NovoRotulo(titulo, 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(0, 6)));
            barra.Controls.Add(NovoRotulo("Pr\u00E9-visualiza\u00E7\u00E3o  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(2, 52)));

            var botoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 300,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = TemaModerno.Fundo
            };
            barra.Controls.Add(botoes);

            btnImprimirRel = new Button { Text = "Imprimir", Size = new Size(140, 44), Margin = new Padding(8, 18, 0, 0) };
            TemaModerno.Botao(btnImprimirRel, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            btnImprimirRel.Click += (s, e) => reportViewer1.PrintDialog();

            // o "Voltar" do designer era uma barra branca no topo: vira um botão igual aos outros
            btnVoltar.Dock = DockStyle.None;
            btnVoltar.Text = "Voltar";
            btnVoltar.Size = new Size(120, 44);
            btnVoltar.Margin = new Padding(8, 18, 0, 0);
            TemaModerno.Botao(btnVoltar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);

            botoes.Controls.Add(btnImprimirRel);
            botoes.Controls.Add(btnVoltar);
            PadraoTela.CentralizarTexto(btnImprimirRel, btnVoltar);

            // o relatório fica dentro de um cartão
            var cartao = new Panel { Dock = DockStyle.Fill, Padding = new Padding(2) };
            TemaModerno.Cartao(cartao);
            reportViewer1.Dock = DockStyle.Fill;
            cartao.Controls.Add(reportViewer1);

            pnlRelatorio.Controls.Add(cartao);   // Fill primeiro...
            pnlRelatorio.Controls.Add(barra);    // ...Top depois (docka antes)
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlRelatorio.Visible = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet.GA_CompraRelatorioDataTable compras;
                using (var adapter = new DataSetTableAdapters.GA_CompraRelatorioTableAdapter())
                    compras = adapter.GetCompras(filtroInicio, filtroFim);

                pnlRelatorio.Visible = true;
                pnlRelatorio.BringToFront();
                RelatorioRdlc.Mostrar(reportViewer1, "rptCompras.rdlc", "Compras", (DataTable)compras, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar o relatório: " + ex.Message);
            }
        }
    }
}