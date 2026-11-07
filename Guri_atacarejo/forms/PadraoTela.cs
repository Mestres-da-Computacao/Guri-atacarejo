using System;
using System.Drawing;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Pecas compartilhadas pelas telas de relatorio: barra lateral (com os botoes
    /// funcionando) e pequenos ajustes visuais que se repetem.
    /// </summary>
    internal static class PadraoTela
    {
        // ------------------------------------------------------------------
        // Barra lateral: Tela de Vendas / Registrar Produto / Registrar Funcionario / Logout
        // ------------------------------------------------------------------
        public static void AdicionarBarraLateral(Form form)
        {
            var menu = new MenuStrip();

            AdicionarItem(menu, "Tela de Vendas", form.Close);   // volta para o painel

            AdicionarItem(menu, "Registrar Produto", () =>
            {
                using (var f = new frmCadastroProduto())
                    f.ShowDialog(form);
            });

            AdicionarItem(menu, "Registrar Funcion\u00E1rio", () =>
            {
                using (var f = new frmCadastroFuncionario())
                    f.ShowDialog(form);
            });

            AdicionarItem(menu, "Logout", () => Deslogar(form));

            var barra = new BarraLateral(menu);
            form.Controls.Add(barra);
            barra.SendToBack();   // docka antes do conteudo (que e Fill)
        }

        private static void AdicionarItem(MenuStrip menu, string texto, Action acao)
        {
            var item = new ToolStripMenuItem(texto);
            item.Click += (s, e) => acao();
            menu.Items.Add(item);
        }

        // Mesmo logout do painel: limpa as sessoes e fecha as telas (volta ao login).
        private static void Deslogar(Form form)
        {
            Sessao.NivelFuncionario = 0;
            Sessao.IdFuncionario = 0;
            Sessao.Usuario = null;
            SessaoClientes.NomeCliente = null;
            SessaoClientes.Cpf = null;
            SessaoClientes.IdCliente = 0;

            Form painel = form.Owner;
            form.Close();
            if (painel != null && !painel.IsDisposed)
                painel.BeginInvoke(new Action(painel.Close));
        }

        // ------------------------------------------------------------------
        // Ajustes visuais
        // ------------------------------------------------------------------

        // Combo com owner-draw tem altura fixa (ItemHeight): sem isto o texto fica
        // cortado quando a fonte cresce ao maximizar a janela.
        public static void AjustarAlturaCombo(params ComboBox[] combos)
        {
            foreach (ComboBox c in combos)
            {
                ComboBox combo = c;
                Action ajustar = () =>
                {
                    if (combo.DrawMode != DrawMode.Normal)
                        combo.ItemHeight = combo.Font.Height + 10;
                };
                combo.FontChanged += (s, e) => ajustar();
                ajustar();
            }
        }

        // O designer deixou botoes com Padding e TextAlign no topo: o texto fica colado em cima.
        public static void CentralizarTexto(params Button[] botoes)
        {
            foreach (Button b in botoes)
            {
                b.Padding = Padding.Empty;
                b.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        // Mantem os controles no mesmo eixo horizontal (centro vertical) da referencia,
        // mesmo depois de redimensionar a janela.
        public static void AlinharNoEixo(Control referencia, params Control[] itens)
        {
            Action alinhar = () =>
            {
                int centro = referencia.Top + referencia.Height / 2;
                foreach (Control c in itens)
                    c.Top = centro - c.Height / 2;
            };

            referencia.SizeChanged += (s, e) => alinhar();
            referencia.LocationChanged += (s, e) => alinhar();
            foreach (Control c in itens)
                c.SizeChanged += (s, e) => alinhar();

            alinhar();
        }
    }
}
