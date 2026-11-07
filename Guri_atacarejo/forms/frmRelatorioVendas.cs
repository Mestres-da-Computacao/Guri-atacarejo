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

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioVendas : Icone
    {
        public frmRelatorioVendas()
        {
            InitializeComponent();
            AplicarTema();

            btnFechar.Click += (s, e) => Close();

            ConfigurarFiltros();
            Load += frmRelatorioVendas_Load;

            PadraoTela.AdicionarBarraLateral(this);   // barra lateral fixa
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
    }
}