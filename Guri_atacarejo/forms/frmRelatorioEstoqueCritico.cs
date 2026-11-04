using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    /// <summary>
    /// Lotes que precisam de atenção: estoque abaixo/no mínimo, validade chegando ou vencida.
    /// Abrir com: new frmRelatorioEstoqueCritico().ShowDialog(this)
    /// </summary>
    internal sealed class frmRelatorioEstoqueCritico : frmRelatorioModelo
    {
        private const int DiasAlerta = 30;   // "vencendo em breve" = próximos 30 dias

        private readonly ComboBox cbSituacao = new ComboBox();
        private readonly ComboBox cbOrdem = new ComboBox();

        public frmRelatorioEstoqueCritico()
            : base("Relatório de estoque crítico", "Lotes abaixo do mínimo ou com validade próxima  \u2022  Guri Atacarejo")
        {
            DefinirColunas(
                new ColunaRelatorio("Produto", "Produto", 2.4f),
                new ColunaRelatorio("Lote", "IdLote", 0.6f, HorizontalAlignment.Right),
                new ColunaRelatorio("Fornecedor", "Fornecedor", 2f),
                new ColunaRelatorio("Validade", "DataValidade", 1f, HorizontalAlignment.Left, "dd/MM/yyyy"),
                new ColunaRelatorio("Dias p/ vencer", "DiasParaVencer", 1f, HorizontalAlignment.Right),
                new ColunaRelatorio("Atual", "QuantidadeAtual", 0.7f, HorizontalAlignment.Right),
                new ColunaRelatorio("Mínimo", "QuantidadeMinima", 0.7f, HorizontalAlignment.Right),
                new ColunaRelatorio("Situação", "Situacao", 1.4f));

            cbSituacao.Items.AddRange(new object[]
            {
                "Todos os críticos",
                "Abaixo ou no mínimo",
                "Vencendo em " + DiasAlerta + " dias",
                "Vencidos",
                "Todos os lotes"
            });
            cbOrdem.Items.AddRange(new object[] { "Mais urgentes primeiro", "Produto (A-Z)", "Validade mais próxima" });

            AdicionarFiltro("Situação", cbSituacao, 220);
            AdicionarFiltro("Ordenar por", cbOrdem, 220);

            LimparFiltros();
        }

        protected override void LimparFiltros()
        {
            cbSituacao.SelectedIndex = 0;
            cbOrdem.SelectedIndex = 0;
        }

        protected override IEnumerable<string> DescreverFiltros()
        {
            yield return "Situação: " + cbSituacao.Text;
            yield return "Ordem: " + cbOrdem.Text;
        }

        protected override void Consultar()
        {
            // Os trechos de "where" e "order by" abaixo são fixos (vêm do índice do combo),
            // nunca de texto digitado, então não há risco de SQL injection.
            string filtro;
            switch (cbSituacao.SelectedIndex)
            {
                case 0: filtro = "where Prioridade <= 5"; break;                                   // tudo menos "Normal"
                case 1: filtro = "where QuantidadeAtual <= QuantidadeMinima"; break;               // inclui esgotados
                case 2: filtro = "where QuantidadeAtual > 0 and DiasParaVencer between 0 and " + DiasAlerta; break;
                case 3: filtro = "where QuantidadeAtual > 0 and DiasParaVencer < 0"; break;
                default: filtro = ""; break;
            }

            string ordem;
            switch (cbOrdem.SelectedIndex)
            {
                case 1: ordem = "order by Produto, DataValidade"; break;
                case 2: ordem = "order by DataValidade, Produto"; break;
                default: ordem = "order by Prioridade, DataValidade, Produto"; break;
            }

            // A consulta de dentro calcula a situação de cada lote; a de fora filtra e ordena.
            // Lote esgotado (quantidade 0) não é tratado como vencido: não há o que perder.
            string hojeMais = "dateadd(day, " + DiasAlerta + ", cast(getdate() as date))";
            string sql = @"
                select * from (
                    select p.Nome as Produto, l.IdLote, f.Nome as Fornecedor, l.DataValidade,
                           datediff(day, cast(getdate() as date), l.DataValidade) as DiasParaVencer,
                           e.QuantidadeAtual, e.QuantidadeMinima,
                           case
                               when e.QuantidadeAtual > 0 and l.DataValidade < cast(getdate() as date) then 'Vencido'
                               when e.QuantidadeAtual = 0 then 'Esgotado'
                               when e.QuantidadeAtual < e.QuantidadeMinima then 'Abaixo do mínimo'
                               when e.QuantidadeAtual = e.QuantidadeMinima then 'No mínimo'
                               when l.DataValidade <= " + hojeMais + @" then 'Vence em breve'
                               else 'Normal'
                           end as Situacao,
                           case
                               when e.QuantidadeAtual > 0 and l.DataValidade < cast(getdate() as date) then 1
                               when e.QuantidadeAtual = 0 then 2
                               when e.QuantidadeAtual < e.QuantidadeMinima then 3
                               when e.QuantidadeAtual = e.QuantidadeMinima then 4
                               when l.DataValidade <= " + hojeMais + @" then 5
                               else 6
                           end as Prioridade
                    from GA_Estoque e
                    inner join GA_Lote l on l.IdLote = e.FKLote
                    inner join GA_Produtos p on p.IdProduto = l.FKProduto
                    inner join GA_Fornecedor f on f.IdFornecedor = l.FKFornecedores
                ) x
                " + filtro + @"
                " + ordem;

            DataTable tabela = Buscar(sql, null);
            if (tabela == null) return;

            // Cada cartão conta pelo próprio critério (um lote pode entrar em mais de um).
            int vencidos = 0, baixo = 0, vencendo = 0;
            var produtos = new HashSet<string>();
            foreach (DataRow r in tabela.Rows)
            {
                produtos.Add(Convert.ToString(r["Produto"]));
                int atual = Convert.ToInt32(r["QuantidadeAtual"]);
                int minimo = Convert.ToInt32(r["QuantidadeMinima"]);
                int dias = Convert.ToInt32(r["DiasParaVencer"]);

                if (atual <= minimo) baixo++;
                if (atual > 0 && dias < 0) vencidos++;
                if (atual > 0 && dias >= 0 && dias <= DiasAlerta) vencendo++;
            }

            MostrarDados(tabela,
                new ItemResumo("Lotes listados", tabela.Rows.Count.ToString()),
                new ItemResumo("Produtos afetados", produtos.Count.ToString()),
                new ItemResumo("Estoque baixo / esgotado", baixo.ToString()),
                new ItemResumo("Vencendo em " + DiasAlerta + " dias", vencendo.ToString()),
                new ItemResumo("Vencidos", vencidos.ToString()));
        }
    }
}
