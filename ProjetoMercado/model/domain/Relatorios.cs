using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMercado.model.dao;
using ProjetoMercado.model.domain;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ProjetoMercado.model.domain
{
    static class Relatorios
    {
        static public void GerarEstoque(string nomeArquivo)
        {
            ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();
            List<ProdutoEstoque> produtos = produtoEstoqueDAO.ListAll();

            /* Cria um documento */
            Document relatorio = new Document(PageSize.A4);
            relatorio.AddCreationDate();

            /* Cria o arquivo PDF */
            PdfWriter pdfWriter = PdfWriter.GetInstance(relatorio,
                new FileStream(nomeArquivo, FileMode.Create));

            /* Abre o documento criado */
            relatorio.Open();

            /* Título do Relatório */
            Paragraph titulo = new Paragraph();
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório de Estoque\n");
            titulo.Add("Emitido em: " + DateTime.Now.ToShortDateString() + "     " +
                DateTime.Now.ToShortTimeString() + "\n\n\n");

            relatorio.Add(titulo);

            /* Tabela com os produtos */
            PdfPTable tabela = new PdfPTable(new float[] { 100, 60, 40, 50 });
            tabela.AddCell(new Phrase("Produto", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Quantidade Min.", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Quantidade", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Situação", new Font(Font.NORMAL, 8, Font.BOLD)));

            foreach (ProdutoEstoque produtoEstoque in produtos)
            {
                tabela.AddCell(new Phrase(produtoEstoque.Produto.Descricao, new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(produtoEstoque.Produto.QntMinEstoque.ToString(),
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(produtoEstoque.QuantidadeEstoque.ToString(),
                    new Font(Font.NORMAL, 8)));
                if (produtoEstoque.QuantidadeEstoque < produtoEstoque.Produto.QntMinEstoque)
                    tabela.AddCell(new Phrase("Estoque Baixo", new Font(Font.NORMAL, 8)));
                else
                    tabela.AddCell(new Phrase("Estoque Normal", new Font(Font.NORMAL, 8)));
            }

            relatorio.Add(tabela);

            relatorio.Close();
        }

        static public void GerarVendas(string nomeArquivo, DateTime dataInicio, DateTime dataFim)
        {
            VendaDAO vendaDAO = new VendaDAO();
            List<Venda> vendas = vendaDAO.ListAll();

            /* Cria um documento */
            Document relatorio = new Document(PageSize.A4);
            relatorio.AddCreationDate();

            /* Cria o arquivo PDF */
            PdfWriter pdfWriter = PdfWriter.GetInstance(relatorio,
                new FileStream(nomeArquivo, FileMode.Create));

            /* Abre o documento criado */
            relatorio.Open();

            /* Título do Relatório */
            Paragraph titulo = new Paragraph();
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório de Vendas do dia: " + dataInicio.ToShortDateString() +
                " ao dia " + dataFim.ToShortDateString() + "\n");
            titulo.Add("Emitido em: " + DateTime.Now.ToShortDateString() + "     " +
                DateTime.Now.ToShortTimeString() + "\n\n\n");

            relatorio.Add(titulo);

            /* Tabela com as vendas */
            PdfPTable tabela = new PdfPTable(new float[] { 100, 100, 100 });
            tabela.AddCell(new Phrase("Data", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Hora", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Valor Total", new Font(Font.NORMAL, 8, Font.BOLD)));

            decimal total = 0.0m;
            foreach (Venda venda in vendas)
            {
                if (venda.DataHora.Date >= dataInicio.Date && venda.DataHora.Date <= dataFim.Date)
                {
                    tabela.AddCell(new Phrase(venda.DataHora.ToShortDateString(),
                        new Font(Font.NORMAL, 8)));
                    tabela.AddCell(new Phrase(venda.DataHora.ToShortTimeString(),
                        new Font(Font.NORMAL, 8)));
                    tabela.AddCell(new Phrase(venda.ValotTotal.ToString("c"),
                        new Font(Font.NORMAL, 8)));
                    total += venda.ValotTotal;
                }
            }

            relatorio.Add(tabela);

            Paragraph totalVendas = new Paragraph();
            totalVendas.Alignment = Element.ALIGN_LEFT;
            totalVendas.Add("\n\nAs vendas nesse período contabilizam " + total.ToString("c"));

            relatorio.Add(totalVendas);

            relatorio.Close();
        }

        static public void GerarNotaFiscal(string nomeArquivo, List<ItemVenda> itens)
        {
            /* Cria um documento */
            Document relatorio = new Document(PageSize.A4);
            relatorio.AddCreationDate();

            /* Cria o arquivo PDF */
            PdfWriter pdfWriter = PdfWriter.GetInstance(relatorio,
                new FileStream(nomeArquivo, FileMode.Create));

            /* Abre o documento criado */
            relatorio.Open();

            /* Título do Relatório */
            Paragraph titulo = new Paragraph();
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add(new Phrase("Cupom Fiscal\n", new Font(Font.NORMAL, 10)));
            titulo.Add(new Phrase("Emitido em: " + DateTime.Now.ToLongDateString() + " " +
                DateTime.Now.ToLongTimeString() + "\n\n\n", new Font(Font.NORMAL, 10)));

            relatorio.Add(titulo);

            /* Tabela com os itens comprados */
            PdfPTable tabela = new PdfPTable(new float[] { 20, 45, 100, 50, 60, 60});
            tabela.DefaultCell.Border = PdfPCell.NO_BORDER;
            tabela.AddCell(new Phrase("Nº", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Código", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Produto", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Qtd.", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Valor Un.", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Valor Total", new Font(Font.NORMAL, 8, Font.BOLD)));

            int n = 0;
            decimal total = 0.0m;
            foreach (ItemVenda itemVenda in itens)
            {
                tabela.AddCell(new Phrase((++n).ToString(),
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(itemVenda.Produto.CodigoBarras,
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(itemVenda.Produto.Descricao,
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(itemVenda.Quantidade.ToString(),
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(itemVenda.PrecoUnitario.ToString("c"),
                    new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase((itemVenda.PrecoUnitario * itemVenda.Quantidade).ToString("c"),
                    new Font(Font.NORMAL, 8)));
                total += itemVenda.PrecoUnitario * itemVenda.Quantidade;
            }
            PdfPCell rodape = new PdfPCell(new Phrase("Total", new Font(Font.NORMAL, 8, Font.BOLD)));
            rodape.Colspan = 5;
            rodape.Border = PdfPCell.NO_BORDER;
            tabela.AddCell(rodape);
            tabela.AddCell(new Phrase(total.ToString("c"), new Font(Font.NORMAL, 8, Font.BOLD)));

            relatorio.Add(tabela);

            relatorio.Close();
        }

        static public void GerarMaisVendidos(string nomeArquivo)
        {
            ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

            List<ItemVenda> itensVendidos = itemVendaDAO.ListAll();

            /* Cria um documento */
            Document relatorio = new Document(PageSize.A4);
            relatorio.AddCreationDate();

            /* Cria o arquivo PDF */
            PdfWriter pdfWriter = PdfWriter.GetInstance(relatorio,
                new FileStream(nomeArquivo, FileMode.Create));

            /* Abre o documento criado */
            relatorio.Open();

            /* Título do Relatório */
            Paragraph titulo = new Paragraph();
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Produtos mais vendidos\n");
            titulo.Add("Emitido em: " + DateTime.Now.ToShortDateString() + "     " +
                DateTime.Now.ToShortTimeString() + "\n\n\n");

            relatorio.Add(titulo);

            /* Tabela com os produtos */
            PdfPTable tabela = new PdfPTable(new float[] { 100, 100 });
            tabela.AddCell(new Phrase("Produto", new Font(Font.NORMAL, 8, Font.BOLD)));
            tabela.AddCell(new Phrase("Nº de Vendas", new Font(Font.NORMAL, 8, Font.BOLD)));

            foreach (ItemVenda itemVenda in itensVendidos)
            {
                tabela.AddCell(new Phrase(itemVenda.Produto.Descricao,
                        new Font(Font.NORMAL, 8)));
                tabela.AddCell(new Phrase(itemVenda.Quantidade.ToString(),
                    new Font(Font.NORMAL, 8)));
            }

            relatorio.Add(tabela);

            relatorio.Close();
        }
    }
}