using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using System.IO;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioVendas : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private void DefinirCorBarra(System.Drawing.Color fundo, System.Drawing.Color texto)
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

            // Barra do form com a mesma cor do fundo; texto branco (ou preto se o fundo for claro)
            System.Drawing.Color fundo = BackColor;
            bool escuro = fundo.GetBrightness() < 0.6f;
            DefinirCorBarra(fundo, escuro ? System.Drawing.Color.White : System.Drawing.Color.Black);
        }

        private ReportViewer visualizador;            // visualizador do relatório (criado no código)
        private bool imprimirAoTerminar = false; // true = abre a janela de impressão quando o relatório ficar pronto

        public frmRelatorioVendas()
        {
            InitializeComponent();
            AplicarTema();

            ConfigurarFiltros();
            ConfigurarRelatorio();
            Load += frmRelatorioVendas_Load;

            PadraoTela.AdicionarBarraLateral(this);   // barra lateral fixa

            this.Text = "Relatório de Vendas";
        }

        // ------------------------------------------------------
        // FILTROS
        // ------------------------------------------------------

        private void ConfigurarFiltros()
        {
            // o designer tinha deixado "Dia / Mês / Ano" copiado em todos os combos
            lblData.Text = "Data :";
            comboBox1.Items.Clear();   // Lote
            comboBox2.Items.Clear();   // Produto

            // "Filtrar por" define o formato da data digitada
            cbPeriodo.SelectedIndexChanged += cbPeriodo_SelectedIndexChanged;
            cbPeriodo.SelectedIndex = 0;   // Dia
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbPeriodo.SelectedIndex)
            {
                case 0: mskData.Mask = "00/00/0000"; break;   // Dia
                case 1: mskData.Mask = "00/0000"; break;      // Mês
                case 2: mskData.Mask = "0000"; break;         // Ano
            }
            mskData.Clear();
        }

        private void frmRelatorioVendas_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombo(comboBox1,
                    "SELECT l.IdLote AS Id, 'Lote ' + CAST(l.IdLote AS varchar(10)) + ' - ' + p.Nome AS Descricao " +
                    "FROM GA_Lote l INNER JOIN GA_Produtos p ON p.IdProduto = l.FKProduto " +
                    "ORDER BY l.IdLote");

                CarregarCombo(comboBox2,
                    "SELECT IdProduto AS Id, Nome AS Descricao FROM GA_Produtos ORDER BY Nome");

                // o relatório já aparece ao abrir a tela (todas as vendas)
                GerarRelatorio(false, false, false);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar filtros: " + ex.Message);
            }
        }

        // Carrega o combo com os dados do banco; a primeira opção ("Todos") não filtra nada.
        private void CarregarCombo(ComboBox combo, string sql)
        {
            var tabela = new DataTable();

            using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(tabela);
            }

            DataRow todos = tabela.NewRow();
            todos["Id"] = 0;
            todos["Descricao"] = "Todos";
            tabela.Rows.InsertAt(todos, 0);

            combo.DisplayMember = "Descricao";
            combo.ValueMember = "Id";
            combo.DataSource = tabela;
            combo.SelectedIndex = 0;
        }

        private void AplicarTema()
        {
            // fundo claro, igual ao do painel
            BackColor = TemaModerno.Fundo;
            tlpRaiz.BackColor = TemaModerno.Fundo;

            // ---- cabecalho: sem cartao, so titulo + subtitulo + botoes ----
            panel1.Visible = false;   // painel vazio que sobrou no designer
            pnlCabecalho.Padding = Padding.Empty;
            pnlCabecalho.BackColor = TemaModerno.Fundo;

            flwBotoes.BackColor = TemaModerno.Fundo;
            flwBotoes.Dock = DockStyle.Right;
            foreach (Button b in new[] { btnFechar, btnPrevia, btnImprimir })
                b.Margin = new Padding(8, 22, 0, 0);

            Rotulo(lblTitulo, 22f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Fundo);
            Rotulo(lblSubtitulo, 10.5f, FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo);
            lblTitulo.Location = new Point(0, 6);
            lblSubtitulo.Location = new Point(2, 52);

            // ---- botoes ----
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnPrevia, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFechar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnAplicar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnLimpar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            PadraoTela.CentralizarTexto(btnImprimir, btnPrevia, btnFechar, btnAplicar, btnLimpar);

            // ---- cartao de filtros ----
            TemaModerno.Cartao(pnlFiltros);
            Rotulo(lblFiltros, 9.5f, FontStyle.Bold, TemaModerno.Verde4, TemaModerno.Card);
            foreach (Label l in new[] { lblPeriodo, lblData, lblLote, lblProduto })
                Rotulo(l, 9f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);

            TemaModerno.Combo(cbPeriodo);
            TemaModerno.Combo(comboBox1);
            TemaModerno.Combo(comboBox2);
            PadraoTela.AjustarAlturaCombo(cbPeriodo, comboBox1, comboBox2);

            foreach (TextBoxBase t in new TextBoxBase[] { mskData })
            {
                t.BorderStyle = BorderStyle.FixedSingle;
                t.BackColor = TemaModerno.Campo;
                t.ForeColor = TemaModerno.Texto;
                t.Font = TemaModerno.Fonte(10f);
            }

            // tudo na mesma linha, tomando o botao "Aplicar" como referencia
            PadraoTela.AlinharNoEixo(btnAplicar,
                cbPeriodo, comboBox1, comboBox2, mskData,
                lblPeriodo, lblData, lblLote, lblProduto);

            // ---- cartao do relatorio ----
            TemaModerno.Cartao(pnlRelatorio);
        }

        private static void Rotulo(Label l, float tam, FontStyle est, Color cor, Color fundo)
        {
            l.Font = TemaModerno.Fonte(tam, est);
            l.ForeColor = cor;
            l.BackColor = fundo;
        }

        // ------------------------------------------------------
        // RELATÓRIO (RDLC)
        // ------------------------------------------------------

        private void ConfigurarRelatorio()
        {
            visualizador = new ReportViewer();
            visualizador.Dock = DockStyle.Fill;
            visualizador.RenderingComplete += visualizador_RenderingComplete;
            pnlRelatorio.Controls.Add(visualizador);
            visualizador.BringToFront();

            // Tira e põe o evento de novo: assim o botão nunca fica ligado duas vezes,
            // mesmo que o designer já tenha ligado.
            Ligar(btnAplicar, btnAplicar_Click);
            Ligar(btnPrevia, btnPrevia_Click);
            Ligar(btnImprimir, btnImprimir_Click);
            Ligar(btnLimpar, btnLimpar_Click);
            Ligar(btnFechar, btnFechar_Click);
        }

        private static void Ligar(Button botao, EventHandler acao)
        {
            botao.Click -= acao;
            botao.Click += acao;
        }

        // Lê a data digitada. Sem data = todas as vendas (devolve true com inicio/fim nulos).
        private bool LerPeriodo(out DateTime? inicio, out DateTime? fim)
        {
            inicio = null;
            fim = null;

            if (mskData.MaskedTextProvider.AssignedEditPositionCount == 0)
                return true;

            if (!mskData.MaskCompleted)
            {
                MessageBox.Show("Preencha a data completa.");
                mskData.Focus();
                return false;
            }

            string[] formatos = { "dd/MM/yyyy", "MM/yyyy", "yyyy" };   // Dia, Mês, Ano
            DateTime ini;

            if (!DateTime.TryParseExact(mskData.Text, formatos[cbPeriodo.SelectedIndex],
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out ini))
            {
                MessageBox.Show("Data inválida.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskData.Clear();
                mskData.Focus();
                return false;
            }

            inicio = ini;
            switch (cbPeriodo.SelectedIndex)
            {
                case 0: fim = ini.AddDays(1); break;
                case 1: fim = ini.AddMonths(1); break;
                default: fim = ini.AddYears(1); break;
            }
            return true;
        }

        // Uma linha por item vendido. Valor 0 em lote/produto = "Todos" (não filtra).
        private DataTable BuscarVendas(DateTime? inicio, DateTime? fim, int idLote, int idProduto)
        {
            string sql = @"
                select v.IdVenda, v.DataVenda,
                       case when iv.Cancelado = 1 then 'Cancelado' else v.StatusVenda end as Status,
                       p.Nome as Produto, l.IdLote, iv.Quantidade, iv.PrecoUnitario,
                       iv.Quantidade * iv.PrecoUnitario as Subtotal
                from GA_ItensVenda iv
                inner join GA_Venda v on v.IdVenda = iv.FKVenda
                inner join GA_Lote l on l.IdLote = iv.FKLote
                inner join GA_Produtos p on p.IdProduto = l.FKProduto
                where (@ini is null or v.DataVenda >= @ini)
                  and (@fim is null or v.DataVenda < @fim)
                  and (@lote = 0 or l.IdLote = @lote)
                  and (@produto = 0 or p.IdProduto = @produto)
                order by v.DataVenda, v.IdVenda";

            var tabela = new DataTable();
            using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                SqlParameterCollection p = da.SelectCommand.Parameters;
                p.Add("@ini", SqlDbType.DateTime).Value = (object)inicio ?? DBNull.Value;
                p.Add("@fim", SqlDbType.DateTime).Value = (object)fim ?? DBNull.Value;
                p.Add("@lote", SqlDbType.Int).Value = idLote;
                p.Add("@produto", SqlDbType.Int).Value = idProduto;
                da.Fill(tabela);
            }
            return tabela;
        }

        // previa = true mostra como ficará na página; imprimir = true abre a janela de impressão;
        // avisos = false deixa as mensagens de lado (usado quando a tela abre sozinha)
        private void GerarRelatorio(bool previa, bool imprimir, bool avisos)
        {
            DateTime? inicio, fim;
            if (!LerPeriodo(out inicio, out fim)) return;

            try
            {
                int idLote = Convert.ToInt32(comboBox1.SelectedValue);
                int idProduto = Convert.ToInt32(comboBox2.SelectedValue);

                DataTable dt = BuscarVendas(inicio, fim, idLote, idProduto);
                if (dt.Rows.Count == 0 && avisos)
                    MessageBox.Show("Nenhuma venda encontrada com esses filtros.");

                imprimirAoTerminar = imprimir;
                RelatorioRdlc.Mostrar(visualizador, "rptVendas.rdlc", "Vendas", dt, previa);
            }
            catch (Exception ex)
            {
                if (avisos) MessageBox.Show("Erro ao gerar o relatório: " + ex.Message);
            }
        }

        // Quando o relatório termina de montar, abre a impressão (se foi o botão Imprimir)
        private void visualizador_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (!imprimirAoTerminar) return;

            imprimirAoTerminar = false;
            visualizador.PrintDialog();
        }

        // ------------------------------------------------------
        // BOTÕES
        // ------------------------------------------------------

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            GerarRelatorio(false, false, true);
        }

        private void btnPrevia_Click(object sender, EventArgs e)
        {
            GerarRelatorio(true, false, true);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GerarRelatorio(false, true, true);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cbPeriodo.SelectedIndex = 0;
            mskData.Clear();

            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;

            GerarRelatorio(false, false, true);   // volta a mostrar o relatório completo
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
