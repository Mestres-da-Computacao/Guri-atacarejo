using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorioEstoqueQtd : Form
    {
        // cor de fundo da tela: 72, 151, 44
        private static readonly Color Fundo = Color.FromArgb(72, 151, 44);

        public frmRelatorioEstoqueQtd()
        {
            InitializeComponent();
            AplicarTema();

            btnFechar.Click += (s, e) => Close();   // só para facilitar o teste
        }

        private void AplicarTema()
        {
            // fundo da tela
            BackColor = Fundo;
            tlpRaiz.BackColor = Fundo;

            // cabeçalho: cartão escuro arredondado, sem contorno
            TemaModerno.Cartao(pnlCabecalho, 12, false);
            pnlCabecalho.BackColor = TemaModerno.Floresta;
            flwBotoes.BackColor = TemaModerno.Floresta;
            Rotulo(lblTitulo, 22f, FontStyle.Bold, TemaModerno.Menta2, TemaModerno.Floresta);
            Rotulo(lblSubtitulo, 10.5f, FontStyle.Regular, TemaModerno.Oliva1, TemaModerno.Floresta);

            // botões do cabeçalho
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnPrevia, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFechar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);

            // cartão de filtro
            TemaModerno.Cartao(pnlFiltros);
            Rotulo(lblFiltros, 9.5f, FontStyle.Bold, TemaModerno.Verde4, TemaModerno.Card);
            Rotulo(lblProduto, 9f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);

            TemaModerno.Botao(btnAplicar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnLimpar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);

            // cartão do relatório
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
    }
}