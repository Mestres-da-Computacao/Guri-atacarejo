using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Guri_atacarejo.forms
{
    // Carrega um relatório .rdlc que está DENTRO do programa (EmbeddedResource) e mostra no ReportViewer.
    // No projeto os relatórios são recursos incorporados, e não arquivos soltos em bin\Debug\Reports.
    internal static class RelatorioRdlc
    {
        // visualizador : o ReportViewer da tela
        // arquivoRdlc  : nome do arquivo, ex.: "rptEstoque.rdlc"
        // nomeDataSet  : nome do DataSet dentro do .rdlc, ex.: "Estoque", "Compras", "Vendas"
        // dados        : os dados do relatório
        // previa       : true = abre no modo "como vai sair na página"
        public static void Mostrar(ReportViewer visualizador, string arquivoRdlc,
                                   string nomeDataSet, DataTable dados, bool previa = false)
        {
            Assembly programa = typeof(RelatorioRdlc).Assembly;

            // Procura pelo final do nome, assim não importa o namespace/pasta exatos.
            string recurso = programa.GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith("." + arquivoRdlc, StringComparison.OrdinalIgnoreCase));

            if (recurso == null)
                throw new FileNotFoundException(
                    "O relatório '" + arquivoRdlc + "' não está dentro do programa. " +
                    "Confira se ele está no projeto com Ação de Compilação = Recurso Incorporado.");

            using (Stream conteudo = programa.GetManifestResourceStream(recurso))
                visualizador.LocalReport.LoadReportDefinition(conteudo);

            visualizador.LocalReport.DataSources.Clear();
            visualizador.LocalReport.DataSources.Add(new ReportDataSource(nomeDataSet, dados));
            visualizador.SetDisplayMode(previa ? DisplayMode.PrintLayout : DisplayMode.Normal);
            visualizador.RefreshReport();
        }
    }
}
