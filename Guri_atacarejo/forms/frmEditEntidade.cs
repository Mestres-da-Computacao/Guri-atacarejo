using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmEditEntidade : Form
    {
        enum Tipo { Texto, Email, Telefone, Documento, Inteiro, Decimal, Data, Lista, Chave }

        // Uma coluna da tabela. Extra:
        //   Lista     -> opções separadas por vírgula ("M,F,O")
        //   Chave     -> "Tabela,ColunaId" da tabela de referência
        //   Documento -> quantidade de dígitos (CPF 11, CNPJ 14)
        class Campo
        {
            public string Coluna, Rotulo, Extra;
            public Tipo Tipo;
            public int Tamanho;
            public bool Obrigatorio, SomenteLeitura;
            public Control Controle;

            public Campo(string coluna, string rotulo, Tipo tipo, int tamanho, bool obrigatorio, string extra = null)
            {
                Coluna = coluna; Rotulo = rotulo; Tipo = tipo;
                Tamanho = tamanho; Obrigatorio = obrigatorio; Extra = extra;
            }
        }

        // Item dos combos de chave estrangeira (mostra o Nome, guarda o Id)
        class Opcao
        {
            public int Id;
            public string Nome;
            public Opcao(int id, string nome) { Id = id; Nome = nome; }
            public override string ToString() { return Nome; }
        }

        readonly string _conexao = Guri_atacarejo.Properties.Settings.Default.ConnectionString;
        readonly CultureInfo _pt = new CultureInfo("pt-BR");
        readonly DataRow _linha;
        readonly List<Campo> _campos = new List<Campo>();
        string _nome, _tabela, _colunaId;

        // entidade = texto do combo (Funcionários, Produtos...), linha = registro selecionado no grid
        public frmEditEntidade(string entidade, DataRow linha)
        {
            InitializeComponent();
            _linha = linha;
            DefinirCampos(entidade);
            MontarTela();
        }

        // ---------- campos de cada tabela (conforme o script do banco) ----------
        private void DefinirCampos(string entidade)
        {
            switch (entidade)
            {
                case "Funcionários":
                    _nome = "Funcionário"; _tabela = "GA_Funcionarios"; _colunaId = "IdFuncionario";
                    _campos.Add(new Campo("FKCargo", "Cargo", Tipo.Chave, 0, true, "GA_Cargos,IdCargo"));
                    _campos.Add(new Campo("FKDepartamento", "Departamento", Tipo.Chave, 0, true, "GA_Departamentos,IdDepartamento"));
                    _campos.Add(new Campo("Nome", "Nome", Tipo.Texto, 100, true));
                    _campos.Add(new Campo("CPF", "CPF", Tipo.Documento, 14, true, "11"));
                    _campos.Add(new Campo("DataNascimento", "Data de nascimento", Tipo.Data, 0, true));
                    _campos.Add(new Campo("Genero", "Gênero", Tipo.Lista, 0, false, "M,F,O"));
                    _campos.Add(new Campo("Telefone", "Telefone", Tipo.Telefone, 15, false));
                    _campos.Add(new Campo("Email", "E-mail", Tipo.Email, 100, false));
                    _campos.Add(new Campo("DataEmissao", "Data de emissão", Tipo.Data, 0, true));
                    _campos.Add(new Campo("Salario", "Salário", Tipo.Decimal, 0, true));
                    _campos.Add(new Campo("StatusFuncionamento", "Status", Tipo.Lista, 0, true, "Ativo,Inativo,Afastado"));
                    break;

                case "Produtos":
                    _nome = "Produto"; _tabela = "GA_Produtos"; _colunaId = "IdProduto";
                    _campos.Add(new Campo("FKCategoria", "Categoria", Tipo.Chave, 0, true, "GA_Categoria,IdCategoria"));
                    _campos.Add(new Campo("Nome", "Nome", Tipo.Texto, 100, true));
                    _campos.Add(new Campo("UnidadeMedida", "Unidade de medida", Tipo.Texto, 20, true));
                    _campos.Add(new Campo("Preco", "Preço", Tipo.Decimal, 0, true));
                    break;

                case "Fornecedores":
                    _nome = "Fornecedor"; _tabela = "GA_Fornecedor"; _colunaId = "IdFornecedor";
                    _campos.Add(new Campo("Nome", "Nome", Tipo.Texto, 100, true));
                    _campos.Add(new Campo("CNPJ", "CNPJ", Tipo.Documento, 18, true, "14"));
                    _campos.Add(new Campo("Email", "E-mail", Tipo.Email, 100, false));
                    _campos.Add(new Campo("Telefone", "Telefone", Tipo.Telefone, 15, false));
                    _campos.Add(new Campo("Endereco", "Endereço", Tipo.Texto, 200, true));
                    break;

                case "Clientes":
                    _nome = "Cliente"; _tabela = "GA_Clientes"; _colunaId = "IdCliente";
                    _campos.Add(new Campo("Nome", "Nome", Tipo.Texto, 100, true));
                    _campos.Add(new Campo("CPF", "CPF", Tipo.Documento, 14, true, "11"));
                    _campos.Add(new Campo("Genero", "Gênero", Tipo.Lista, 0, false, "M,F,O"));
                    _campos.Add(new Campo("Email", "E-mail", Tipo.Email, 100, false));
                    _campos.Add(new Campo("Celular", "Celular", Tipo.Telefone, 15, false));
                    _campos.Add(new Campo("NivelFidelidade", "Nível de fidelidade", Tipo.Inteiro, 0, false));
                    // calculado pela trigger trg_AtualizarTotalComprasCliente: só mostra
                    Campo total = new Campo("TotalComprasAcumuladas", "Total de compras", Tipo.Decimal, 0, false);
                    total.SomenteLeitura = true;
                    _campos.Add(total);
                    break;

                default:
                    throw new ArgumentException("Entidade desconhecida: " + entidade);
            }
        }

        // ---------- tela (mesmo visual do frmPainel, via TemaModerno) ----------
        private void MontarTela()
        {
            const int m = 24;
            const int largura = 560;

            Text = "Editar " + _nome;
            BackColor = TemaModerno.Fundo;

            Panel host = new Panel();
            host.Dock = DockStyle.Fill;
            host.AutoScroll = true;
            host.BackColor = TemaModerno.Fundo;

            host.Controls.Add(NovoRotulo("Editar " + _nome.ToLower(), 22f, FontStyle.Bold,
                TemaModerno.Texto, TemaModerno.Fundo, new Point(m, 14)));
            host.Controls.Add(NovoRotulo("Altere os dados e clique em Editar  \u2022  Guri Atacarejo", 10.5f,
                FontStyle.Regular, TemaModerno.Verde2, TemaModerno.Fundo, new Point(m, 58)));

            // cartão com um rótulo + um campo por coluna
            TableLayoutPanel tabela = new TableLayoutPanel();
            tabela.AutoSize = true;
            tabela.ColumnCount = 2;
            tabela.Location = new Point(20, 16);
            tabela.BackColor = TemaModerno.Card;

            int linha = 0;
            foreach (Campo c in _campos)
            {
                string texto = c.Rotulo + (c.Obrigatorio ? " *" : "");
                Label lbl = NovoRotulo(texto, 9.5f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card, Point.Empty);
                lbl.Anchor = AnchorStyles.Left;
                lbl.Margin = new Padding(0, 8, 16, 8);

                c.Controle = CriarControle(c);
                c.Controle.Margin = new Padding(0, 4, 0, 4);

                tabela.Controls.Add(lbl, 0, linha);
                tabela.Controls.Add(c.Controle, 1, linha);
                linha++;
            }

            Panel cartao = new Panel();
            cartao.Controls.Add(tabela);
            cartao.Bounds = new Rectangle(m, 96, largura - 2 * m, tabela.PreferredSize.Height + 32);
            TemaModerno.Cartao(cartao);
            host.Controls.Add(cartao);

            // botões
            int y = cartao.Bottom + 16;
            Button btnEditar = NovoBotao("Editar", TemaModerno.Accent, Color.White, TemaModerno.Verde2, m, y, 130);
            Button btnCancelar = NovoBotao("Cancelar", TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho, m + 142, y, 130);
            Button btnExcluir = NovoBotao("Excluir " + _nome, Color.FromArgb(250, 228, 230), TemaModerno.Perigo,
                Color.FromArgb(244, 206, 210), m + 284, y, 190);

            btnEditar.Click += btnEditar_Click;
            btnExcluir.Click += btnExcluir_Click;
            btnCancelar.DialogResult = DialogResult.Cancel; // fecha a tela sozinho
            CancelButton = btnCancelar;

            host.Controls.Add(btnEditar);
            host.Controls.Add(btnCancelar);
            host.Controls.Add(btnExcluir);

            Controls.Add(host);
            ClientSize = new Size(largura, Math.Min(y + 44 + m, Screen.PrimaryScreen.WorkingArea.Height - 60));
        }

        private static Label NovoRotulo(string texto, float tamanho, FontStyle estilo, Color cor, Color fundo, Point local)
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

        private static Button NovoBotao(string texto, Color fundo, Color letra, Color hover, int x, int y, int largura)
        {
            Button b = new Button();
            b.Text = texto;
            b.Bounds = new Rectangle(x, y, largura, 44);
            TemaModerno.Botao(b, fundo, letra, hover);
            return b;
        }

        private Control CriarControle(Campo c)
        {
            object valor = _linha[c.Coluna];
            bool nulo = valor == DBNull.Value;

            // DATE -> seletor de data
            if (c.Tipo == Tipo.Data)
            {
                DateTimePicker data = new DateTimePicker();
                data.Format = DateTimePickerFormat.Short;
                data.Font = TemaModerno.Fonte(10f);
                data.Width = 280;
                if (!nulo) data.Value = Convert.ToDateTime(valor);
                return data;
            }

            // CHECK (M/F/O...) e FOREIGN KEY -> combo, só aceita o que o banco aceita
            if (c.Tipo == Tipo.Lista || c.Tipo == Tipo.Chave)
            {
                ComboBox combo = new ComboBox();
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.Width = 280;
                TemaModerno.Combo(combo);

                if (c.Tipo == Tipo.Lista)
                {
                    if (!c.Obrigatorio) combo.Items.Add(""); // vazio = NULL
                    combo.Items.AddRange(c.Extra.Split(','));
                    if (!nulo) combo.SelectedItem = valor.ToString().Trim();
                }
                else
                {
                    CarregarOpcoes(combo, c.Extra.Split(','), nulo ? -1 : Convert.ToInt32(valor));
                }
                return combo;
            }

            // demais -> caixa de texto que só aceita os caracteres do tipo
            TextBox texto = new TextBox();
            texto.Width = 280;
            texto.Font = TemaModerno.Fonte(10f);
            texto.BorderStyle = BorderStyle.FixedSingle;
            texto.BackColor = c.SomenteLeitura ? TemaModerno.Cabecalho : TemaModerno.Campo;
            texto.ForeColor = TemaModerno.Texto;
            texto.ReadOnly = c.SomenteLeitura;
            texto.Tag = c;
            texto.KeyPress += Digitacao;

            if (c.Tipo == Tipo.Inteiro) texto.MaxLength = 9;
            else if (c.Tipo == Tipo.Decimal) texto.MaxLength = 19; // DECIMAL(18,2)
            else texto.MaxLength = c.Tamanho;

            if (!nulo)
            {
                texto.Text = c.Tipo == Tipo.Decimal
                    ? Convert.ToDecimal(valor).ToString("F2", _pt)
                    : valor.ToString().Trim();
            }
            return texto;
        }

        // refTabela = { "Tabela", "ColunaId" }
        private void CarregarOpcoes(ComboBox combo, string[] refTabela, int idAtual)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(_conexao))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT " + refTabela[1] + ", Nome FROM " + refTabela[0] + " ORDER BY Nome", conexao))
                {
                    conexao.Open();
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Opcao opcao = new Opcao(leitor.GetInt32(0), leitor.GetString(1));
                            combo.Items.Add(opcao);
                            if (opcao.Id == idAtual) combo.SelectedItem = opcao;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível carregar a lista: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Só deixa digitar o que o tipo da coluna aceita
        private void Digitacao(object sender, KeyPressEventArgs e)
        {
            TextBox texto = (TextBox)sender;
            Tipo tipo = ((Campo)texto.Tag).Tipo;
            char tecla = e.KeyChar;

            if (char.IsControl(tecla)) return;

            string permitidos;
            if (tipo == Tipo.Documento) permitidos = ".-/";
            else if (tipo == Tipo.Telefone) permitidos = "()- +";
            else if (tipo == Tipo.Inteiro) permitidos = "";
            else if (tipo == Tipo.Decimal)
            {
                if (tecla == '.') tecla = e.KeyChar = ','; // ponto vira vírgula
                permitidos = ",";
            }
            else return; // Texto e E-mail: qualquer caractere

            bool digito = tecla >= '0' && tecla <= '9';
            if (!digito && permitidos.IndexOf(tecla) < 0)
            {
                e.Handled = true;
                return;
            }

            // decimal: uma vírgula só e no máximo 2 casas
            if (tipo == Tipo.Decimal && texto.SelectionLength == 0)
            {
                int virgula = texto.Text.IndexOf(',');
                if (tecla == ',' && virgula >= 0) e.Handled = true;
                if (digito && virgula >= 0 && texto.SelectionStart > virgula && texto.Text.Length - virgula > 2)
                    e.Handled = true;
            }
        }

        // ---------- validação ----------
        // Retorna null se estiver tudo certo, ou a mensagem do primeiro erro
        private string Validar()
        {
            foreach (Campo c in _campos)
            {
                if (c.SomenteLeitura) continue;

                string texto = c.Controle.Text.Trim();
                if (texto == "")
                {
                    if (!c.Obrigatorio) continue;
                    c.Controle.Focus();
                    return "O campo \"" + c.Rotulo + "\" é obrigatório.";
                }

                int digitos = Regex.Replace(texto, @"\D", "").Length;
                string erro = null;

                switch (c.Tipo)
                {
                    case Tipo.Email:
                        if (!Regex.IsMatch(texto, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) erro = "E-mail inválido.";
                        break;
                    case Tipo.Documento:
                        if (digitos != int.Parse(c.Extra)) erro = c.Rotulo + " deve ter " + c.Extra + " dígitos.";
                        break;
                    case Tipo.Telefone:
                        if (digitos < 8) erro = c.Rotulo + " inválido (mínimo de 8 dígitos).";
                        break;
                    case Tipo.Inteiro:
                        if (!Regex.IsMatch(texto, @"^\d{1,9}$")) erro = c.Rotulo + " deve ser um número inteiro.";
                        break;
                    case Tipo.Decimal:
                        if (!Regex.IsMatch(texto, @"^\d{1,16}(,\d{1,2})?$")) erro = c.Rotulo + " inválido. Use o formato 0,00.";
                        break;
                }

                if (erro != null)
                {
                    c.Controle.Focus();
                    return erro;
                }
            }
            return null;
        }

        // Valor que vai para o banco (DBNull quando vazio)
        private object ObterValor(Campo c)
        {
            if (c.Tipo == Tipo.Data) return ((DateTimePicker)c.Controle).Value.Date;

            if (c.Tipo == Tipo.Chave)
            {
                Opcao opcao = ((ComboBox)c.Controle).SelectedItem as Opcao;
                return opcao == null ? (object)DBNull.Value : opcao.Id;
            }

            string texto = c.Controle.Text.Trim();
            if (texto == "") return DBNull.Value;
            if (c.Tipo == Tipo.Inteiro) return int.Parse(texto);
            if (c.Tipo == Tipo.Decimal) return decimal.Parse(texto, _pt);
            return texto;
        }

        // ---------- botões ----------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string erro = Validar();
            if (erro != null)
            {
                MessageBox.Show(erro, "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UPDATE tabela SET Coluna1 = @Coluna1, ... WHERE IdX = @Id
            List<string> atribuicoes = new List<string>();
            foreach (Campo c in _campos)
                if (!c.SomenteLeitura) atribuicoes.Add(c.Coluna + " = @" + c.Coluna);

            string comando = "UPDATE " + _tabela + " SET " + string.Join(", ", atribuicoes.ToArray()) +
                             " WHERE " + _colunaId + " = @Id";

            try
            {
                using (SqlConnection conexao = new SqlConnection(_conexao))
                using (SqlCommand cmd = new SqlCommand(comando, conexao))
                {
                    foreach (Campo c in _campos)
                        if (!c.SomenteLeitura) cmd.Parameters.AddWithValue("@" + c.Coluna, ObterValor(c));
                    cmd.Parameters.AddWithValue("@Id", _linha[_colunaId]);

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(_nome + " atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                // 2627 / 2601 = valor repetido em coluna UNIQUE (CPF / CNPJ)
                string mensagem = (ex.Number == 2627 || ex.Number == 2601)
                    ? "Já existe outro registro com esse CPF/CNPJ."
                    : "Não foi possível atualizar: " + ex.Message;
                MessageBox.Show(mensagem, "Erro ao atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este " + _nome.ToLower() + "?\nEssa ação não pode ser desfeita.",
                "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conexao = new SqlConnection(_conexao))
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM " + _tabela + " WHERE " + _colunaId + " = @Id", conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", _linha[_colunaId]);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(_nome + " excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                // 547 = violação de FOREIGN KEY (tem vendas, compras ou lotes ligados a ele)
                string mensagem = ex.Number == 547
                    ? "Não é possível excluir: este " + _nome.ToLower() + " possui registros vinculados (vendas, compras ou lotes)."
                    : "Não foi possível excluir: " + ex.Message;
                MessageBox.Show(mensagem, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}