using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioEstoqueQtd : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
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

        private ReportViewer visualizador;            // visualizador do relatório (criado no código)
        private bool imprimirAoTerminar = false; // true = abre a janela de impressão quando o relatório ficar pronto

        public frmRelatorioEstoqueQtd()
        {
            InitializeComponent();
            AplicarTema();

            ConfigurarRelatorio();
            Load += frmRelatorioEstoqueQtd_Load;

            PadraoTela.AdicionarBarraLateral(this);   // barra lateral fixa

            this.Text = "Relatório de Estoque por Quantidade";
        }

        private void AplicarTema()
        {
            // fundo claro, igual ao do painel
            BackColor = TemaModerno.Fundo;
            tlpRaiz.BackColor = TemaModerno.Fundo;

            // ---- cabecalho: sem cartao, so titulo + subtitulo + botoes ----
            pnlCabecalho.Padding = Padding.Empty;
            pnlCabecalho.BackColor = TemaModerno.Fundo;

            flwBotoes.BackColor = TemaModerno.Fundo;
            flwBotoes.Dock = DockStyle.Right;
            foreach (Button b in new[] { btnImprimir, btnPrevia, btnFechar })
                b.Margin = new Padding(8, 22, 0, 0);

            Rotulo(lblTitulo, 22f, FontStyle.Bold, TemaModerno.Texto, TemaModerno.Fundo);
            Rotulo(lblSubtitulo, 10.5f, FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo);
            lblTitulo.Location = new Point(0, 6);
            lblSubtitulo.Location = new Point(2, 52);

            // ---- botoes do cabecalho ----
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnPrevia, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFechar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);

            // ---- cartao de filtro ----
            TemaModerno.Cartao(pnlFiltros);
            Rotulo(lblFiltros, 9.5f, FontStyle.Bold, TemaModerno.Verde4, TemaModerno.Card);
            Rotulo(lblProduto, 9f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);

            TemaModerno.Botao(btnAplicar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnLimpar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);
            PadraoTela.CentralizarTexto(btnImprimir, btnPrevia, btnFechar, btnAplicar, btnLimpar);

            // ---- cartao do relatorio ----
            TemaModerno.Cartao(pnlRelatorio);
            Rotulo(lblAreaRelatorio, 11f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);
        }

        private static void Rotulo(Label l, float tam, FontStyle est, Color cor, Color fundo)
        {
            l.Font = TemaModerno.Fonte(tam, est);
            l.ForeColor = cor;
            l.BackColor = fundo;
        }

        private void tlpRaiz_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRelatorio_Paint(object sender, PaintEventArgs e)
        {

        }

        // ------------------------------------------------------
        // RELATÓRIO (RDLC)
        // ------------------------------------------------------

        private void ConfigurarRelatorio()
        {
            // No designer a linha do relatório estava com altura fixa de 100 px, então o relatório
            // ficava espremido. Aqui ela passa a ocupar todo o espaço que sobra na tela.
            tlpRaiz.RowStyles[2].SizeType = SizeType.Percent;
            tlpRaiz.RowStyles[2].Height = 100F;

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

        // O cbProduto do designer é um RoundComboBox. Esta função acha o ComboBox de verdade:
        // o próprio controle (se ele for um ComboBox) ou o que estiver dentro dele.
        private static ComboBox ObterCombo(Control controle)
        {
            ComboBox combo = controle as ComboBox;
            if (combo != null) return combo;

            foreach (Control filho in controle.Controls)
            {
                combo = ObterCombo(filho);
                if (combo != null) return combo;
            }
            return null;
        }

        private void frmRelatorioEstoqueQtd_Load(object sender, EventArgs e)
        {
            ComboBox combo = ObterCombo(cbProduto);

            if (combo != null)
            {
                try
                {
                    var tabela = new DataTable();
                    using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    using (var da = new SqlDataAdapter("SELECT IdProduto AS Id, Nome AS Descricao FROM GA_Produtos ORDER BY Nome", conn))
                    {
                        da.Fill(tabela);
                    }

                    // a primeira opção ("Todos") não filtra nada
                    DataRow todos = tabela.NewRow();
                    todos["Id"] = 0;
                    todos["Descricao"] = "Todos";
                    tabela.Rows.InsertAt(todos, 0);

                    combo.DisplayMember = "Descricao";
                    combo.ValueMember = "Id";
                    combo.DataSource = tabela;
                    combo.SelectedIndex = 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
                }
            }

            // o relatório já aparece ao abrir a tela (todos os produtos)
            GerarRelatorio(false, false, false);
        }

        // Estoque somado por produto. idProduto = 0 traz todos.
        private DataTable BuscarEstoque(int idProduto)
        {
            // O estoque é guardado por lote, então somamos os lotes de cada produto.
            string sql = @"select p.IdProduto, p.Nome, p.Preco,
                                  isnull(sum(e.QuantidadeAtual), 0) as QtdEstoque
                           from GA_Produtos p
                           left join GA_Lote l on l.FKProduto = p.IdProduto
                           left join GA_Estoque e on e.FKLote = l.IdLote
                           where (@produto = 0 or p.IdProduto = @produto)
                           group by p.IdProduto, p.Nome, p.Preco
                           order by p.Nome";

            var tabela = new DataTable();
            using (var conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.Add("@produto", SqlDbType.Int).Value = idProduto;
                da.Fill(tabela);
            }
            return tabela;
        }

        // previa = true mostra como ficará na página; imprimir = true abre a janela de impressão;
        // avisos = false deixa as mensagens de lado (usado quando a tela abre sozinha)
        private void GerarRelatorio(bool previa, bool imprimir, bool avisos)
        {
            try
            {
                ComboBox combo = ObterCombo(cbProduto);
                int idProduto = combo == null ? 0 : Convert.ToInt32(combo.SelectedValue);

                DataTable dt = BuscarEstoque(idProduto);
                if (dt.Rows.Count == 0 && avisos)
                    MessageBox.Show("Nenhum produto encontrado.");

                lblAreaRelatorio.Visible = false;   // o texto "O relatório aparece aqui" some

                imprimirAoTerminar = imprimir;
                RelatorioRdlc.Mostrar(visualizador, "rptEstoque.rdlc", "Estoque", dt, previa);
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
            ComboBox combo = ObterCombo(cbProduto);
            if (combo != null && combo.Items.Count > 0) combo.SelectedIndex = 0;

            GerarRelatorio(false, false, true);   // volta a mostrar o relatório completo
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
