using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmexibcaoentidades : Icone
    {
        // ---- Barra de título colorida (Windows 11) ----
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
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

        string tipo = "";
        private readonly string _connectionString =
            Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        private DataTable _dadosEntidade;

        public frmexibcaoentidades()
        {
            InitializeComponent();

            AplicarTema(); // visual igual ao do frmPainel (TemaModerno)
            ResponsividadeForm.Aplicar(this);

            cbcar.SelectedIndexChanged += cbcar_SelectedIndexChanged;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            cbent.SelectedIndex = 0;

            this.Text = "Exibição de entidades";
        }

        private void cbent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbcar.Items.Clear();

            switch (cbent.SelectedIndex)
            {
                case 0:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdFuncionario", "FKCargo", "FKDepartamento",
                        "Nome", "CPF", "DataNascimento", "Genero", "Telefone",
                        "Email", "DataEmissao", "Salario", "StatusFuncionamento"
                    });
                    break;

                case 1:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdProduto", "FKCategoria",
                        "Nome", "UnidadeMedida", "Preco"
                    });
                    break;

                case 2:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdFornecedor", "Nome", "CNPJ",
                        "Email", "Telefone", "Endereco"
                    });
                    break;

                case 3:
                    cbcar.Items.AddRange(new object[]
                    {
                        "Tudo", "IdCliente", "Nome", "CPF", "Genero",
                        "Email", "Celular", "NivelFidelidade",
                        "TotalComprasAcumuladas"
                    });
                    break;

                default:
                    _dadosEntidade = null;
                    dataGridView1.DataSource = null;
                    return;
            }

            tipo = cbent.SelectedItem.ToString();

            cbcar.SelectedIndex = 0;
            CarregarEntidade();
        }

        private void cbcar_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarColunasVisiveis();
        }

        private void CarregarEntidade()
        {
            string consulta;

            switch (cbent.SelectedIndex)
            {
                case 0:
                    consulta = "SELECT IdFuncionario, FKCargo, FKDepartamento, Nome, CPF, " +
                               "DataNascimento, Genero, Telefone, Email, DataEmissao, " +
                               "Salario, StatusFuncionamento FROM GA_Funcionarios " +
                               "ORDER BY Nome";
                    break;

                case 1:
                    consulta = "SELECT IdProduto, FKCategoria, Nome, " +
                               "UnidadeMedida, Preco FROM GA_Produtos ORDER BY Nome";
                    break;

                case 2:
                    consulta = "SELECT IdFornecedor, Nome, CNPJ, Email, Telefone, " +
                               "Endereco FROM GA_Fornecedor ORDER BY Nome";
                    break;

                case 3:
                    consulta = "SELECT IdCliente, Nome, CPF, Genero, Email, Celular, " +
                               "NivelFidelidade, TotalComprasAcumuladas " +
                               "FROM GA_Clientes ORDER BY Nome";
                    break;

                default:
                    _dadosEntidade = null;
                    dataGridView1.DataSource = null;
                    return;
            }

            var dados = new DataTable();

            try
            {
                using (var conexao = new SqlConnection(_connectionString))
                using (var adaptador = new SqlDataAdapter(consulta, conexao))
                {
                    adaptador.Fill(dados);
                }
            }
            catch (SqlException ex)
            {
                _dadosEntidade = null;
                dataGridView1.DataSource = null;

                MessageBox.Show(
                    "Não foi possível carregar os dados: " + ex.Message,
                    "Erro ao carregar dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _dadosEntidade = dados;
            dataGridView1.DataSource = _dadosEntidade;

            AtualizarColunasVisiveis();
        }

        private void AtualizarColunasVisiveis()
        {
            if (_dadosEntidade == null || dataGridView1.Columns.Count == 0)
            {
                return;
            }

            string atributoSelecionado = cbcar.SelectedItem as string;
            bool mostrarTudo = cbcar.SelectedIndex <= 0;

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                coluna.Visible = mostrarTudo ||
                                 coluna.DataPropertyName == atributoSelecionado ||
                                 coluna.Name == atributoSelecionado;
            }

            AjustarColunas();
        }

        // Colunas do tamanho do conteúdo (sem "..."); se sobrar espaço, esticam para
        // preencher a tabela; se não couberem, aparece a barra de rolagem horizontal.
        private void AjustarColunas()
        {
            DataGridView g = dataGridView1;
            if (g.Columns.Count == 0) return;

            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int total = 0;
            foreach (DataGridViewColumn c in g.Columns)
                if (c.Visible) total += c.Width;

            if (total < g.ClientSize.Width)
            {
                foreach (DataGridViewColumn c in g.Columns)
                    c.FillWeight = Math.Max(1, c.Width);
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = e.RowIndex >= 0 && e.ColumnIndex >= 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataRowView linha = dataGridView1.CurrentRow == null
                ? null
                : dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (linha == null) return;

            using (frmEditEntidade editar = new frmEditEntidade(tipo, linha.Row))
            {
                // OK = editou ou excluiu, então recarrega o grid
                if (editar.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarEntidade();
                    btnEditar.Enabled = false;
                }
            }
        }

        // ------------------------------------------------------------------
        // Visual igual ao do frmPainel: fundo claro, cartões arredondados,
        // botões e tabela do TemaModerno. Os controles do designer são só reorganizados.
        // ------------------------------------------------------------------
        private void AplicarTema()
        {
            SuspendLayout();

            ClientSize = new Size(900, 560);
            BackColor = TemaModerno.Fundo;
            Text = "Entidades";
            menuStrip1.Visible = false;   // não tem itens

            const int m = 24;
            int largura = ClientSize.Width - 2 * m;
            int acoesH = 108;
            int acoesY = ClientSize.Height - m - acoesH;

            Panel host = new Panel();
            host.Dock = DockStyle.Fill;
            host.BackColor = TemaModerno.Fundo;

            host.Controls.Add(NovoRotulo("Entidades", 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Consulta e edi\u00E7\u00E3o  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // ---- logo da firma (canto superior direito) ----
            PrepararLogo();
            pictureBox1.Visible = true;
            pictureBox1.BackColor = TemaModerno.Fundo;   // fundo igual ao da tela (sem o laranja)
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            // tamanho da área do logo: se o seu logo for mais largo que alto, aumente a largura (80)
            pictureBox1.Bounds = new Rectangle(ClientSize.Width - m - 80, 10, 80, 78);
            host.Controls.Add(pictureBox1);

            // ---- cartão: PESQUISA (o GroupBox vira um Panel) ----
            Panel pesquisa = TemaModerno.GroupBoxParaPainel(Pesquisa, TemaModerno.Card);
            pesquisa.Bounds = new Rectangle(m, 96, largura, acoesY - 16 - 96);
            TemaModerno.Cartao(pesquisa);

            pesquisa.Controls.Add(NovoRotulo("Pesquisa", 12f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Card, new Point(20, 14)));

            // rótulos com tamanho fixo (alinhados ao título do cartão e aos combos)
            Estilizar(label1, new Point(20, 52));
            label1.AutoSize = false;
            label1.Bounds = new Rectangle(20, 52, 85, 30);
            label1.TextAlign = ContentAlignment.MiddleLeft;
            TemaModerno.Combo(cbent);
            AjustarAlturaCombo(cbent);
            cbent.Location = new Point(110, 52);
            cbent.Width = 200;

            Estilizar(label2, new Point(340, 52));
            label2.AutoSize = false;
            label2.Bounds = new Rectangle(340, 52, 65, 30);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            TemaModerno.Combo(cbcar);
            AjustarAlturaCombo(cbcar);
            cbcar.Location = new Point(410, 52);
            cbcar.Width = 220;

            pesquisa.Controls.Add(dataGridView1);
            dataGridView1.Location = new Point(1, 100);
            dataGridView1.Size = new Size(pesquisa.Width - 2, pesquisa.Height - 101);
            TemaModerno.Grid(dataGridView1);
            dataGridView1.SizeChanged += (s, e) => AjustarColunas();   // ao maximizar a janela
            host.Controls.Add(pesquisa);

            // ---- cartão: AÇÕES ----
            Panel acoes = new Panel();
            acoes.Bounds = new Rectangle(m, acoesY, largura, acoesH);
            TemaModerno.Cartao(acoes);
            acoes.Controls.Add(NovoRotulo("A\u00C7\u00D5ES", 9.5f, FontStyle.Bold,
                TemaModerno.Verde4, TemaModerno.Card, new Point(20, 16)));

            EstilizarBotao(btnEditar, true);
            btnEditar.Bounds = new Rectangle(20, 46, 170, 46);
            EstilizarBotao(btnVoltar, false);
            btnVoltar.Bounds = new Rectangle(210, 46, 170, 46);
            acoes.Controls.Add(btnEditar);
            acoes.Controls.Add(btnVoltar);
            host.Controls.Add(acoes);

            Controls.Add(host);
            host.BringToFront();
            ResumeLayout(true);
        }

        private static Label NovoRotulo(string texto, float tamanho, FontStyle estilo,
            Color cor, Color fundo, Point local)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.Text = texto;
            l.Font = TemaModerno.Fonte(tamanho, estilo);
            l.ForeColor = cor;
            l.BackColor = fundo;
            l.Location = local;
            return l;
        }

        // rótulo do designer ("Pesquisar:", "O Que:") com o estilo dos cartões
        private static void Estilizar(Label l, Point local)
        {
            l.Font = TemaModerno.Fonte(10f);
            l.ForeColor = TemaModerno.TextoSuave;
            l.BackColor = TemaModerno.Card;
            l.Location = local;
        }

        // ------------------------------------------------------------------
        // Botões no mesmo padrão do resto do projeto (Compra, Registrar Lote...):
        // verde #48972C com texto branco; o secundário é branco com texto e borda verdes.
        // Cantos arredondados.
        // ------------------------------------------------------------------
        private static readonly Color VerdeBotao = Color.FromArgb(72, 151, 44);

        private static void EstilizarBotao(Button b, bool principal)
        {
            const int raio = 10;
            Color corBorda = VerdeBotao;

            b.UseVisualStyleBackColor = false;
            b.FlatStyle = FlatStyle.Flat;
            b.Cursor = Cursors.Hand;
            b.Font = TemaModerno.Fonte(10.5f, FontStyle.Bold);
            b.FlatAppearance.BorderSize = 0;   // a borda é desenhada no Paint, arredondada

            if (principal)
            {
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 124, 35);
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 104, 28);
            }
            else
            {
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 243, 229);
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 232, 209);
            }

            // cores normais e cores de "desabilitado" (o Editar começa desabilitado)
            Action pintar = () =>
            {
                if (!b.Enabled)
                {
                    b.BackColor = Color.FromArgb(226, 232, 224);
                    b.ForeColor = Color.FromArgb(140, 150, 138);
                    corBorda = Color.FromArgb(206, 214, 204);
                }
                else
                {
                    b.BackColor = principal ? VerdeBotao : Color.White;
                    b.ForeColor = principal ? Color.White : VerdeBotao;
                    corBorda = VerdeBotao;
                }
                b.Invalidate();
            };

            b.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath caminho = CaminhoArredondado(
                    new RectangleF(0.5f, 0.5f, b.Width - 2f, b.Height - 2f), raio))
                using (Pen caneta = new Pen(corBorda, 1.5f))
                {
                    e.Graphics.DrawPath(caneta, caminho);
                }
            };

            b.EnabledChanged += (s, e) => pintar();
            pintar();
            TemaModerno.Arredondar(b, raio);
        }

        private static GraphicsPath CaminhoArredondado(RectangleF r, float raio)
        {
            float d = raio * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
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

        // O logo (imagem do pictureBox1) vem num fundo laranja enorme, com o desenho
        // pequeno no meio. Recorta só a área do desenho para ele aparecer em tamanho útil.
        private void PrepararLogo()
        {
            Image original = pictureBox1.Image;
            if (original == null || original.Width != 1280 || original.Height != 1024)
                return;

            Rectangle area = new Rectangle(332, 187, 629, 614);
            Bitmap recorte = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(recorte))
            {
                g.DrawImage(original, new Rectangle(0, 0, area.Width, area.Height),
                    area, GraphicsUnit.Pixel);
            }
            pictureBox1.Image = recorte;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}