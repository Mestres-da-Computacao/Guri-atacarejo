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
    public partial class frmRelatorioVendas : Form
    {
        public frmRelatorioVendas()
        {
            InitializeComponent();
            AplicarTema();
        }

        private void AplicarTema()
        {
            // fundo da tela e dos contêineres
            BackColor = Color.FromArgb(72, 151, 44);
            
            tlpRaiz.BackColor = Color.FromArgb(72, 151, 44);

            // cabeçalho
            // cabeçalho como cartão escuro arredondado
            TemaModerno.Cartao(pnlCabecalho, 12, false);   // false = sem contorno
            pnlCabecalho.BackColor = TemaModerno.Floresta;
            flwBotoes.BackColor = TemaModerno.Floresta;

            Rotulo(lblTitulo, 22f, FontStyle.Bold, TemaModerno.Menta2, TemaModerno.Floresta);
            Rotulo(lblSubtitulo, 10.5f, FontStyle.Regular, TemaModerno.Oliva1, TemaModerno.Floresta);

            // botões: principal verde; secundários brancos (fundo da tela) ou "campo" (dentro do cartão)
            TemaModerno.Botao(btnImprimir, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnPrevia, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnFechar, Color.White, TemaModerno.Texto, TemaModerno.Cabecalho);
            TemaModerno.Botao(btnAplicar, TemaModerno.Accent, Color.White, TemaModerno.Verde2);
            TemaModerno.Botao(btnLimpar, TemaModerno.Campo, TemaModerno.Texto, TemaModerno.Cabecalho);

            // cartão de filtros
            TemaModerno.Cartao(pnlFiltros);
            Rotulo(lblFiltros, 9.5f, FontStyle.Bold, TemaModerno.Verde4, TemaModerno.Card);
            foreach (Label l in new[] { lblPeriodo, lblData, lblLote, lblProduto })
                Rotulo(l, 9f, FontStyle.Regular, TemaModerno.TextoSuave, TemaModerno.Card);

            TemaModerno.Combo(cbPeriodo);
            foreach (TextBoxBase t in new TextBoxBase[] { mskData})
            {
                t.BorderStyle = BorderStyle.FixedSingle;
                t.BackColor = TemaModerno.Campo;
                t.ForeColor = TemaModerno.Texto;
                t.Font = TemaModerno.Fonte(10f);
            }

            // cartão do relatório
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
