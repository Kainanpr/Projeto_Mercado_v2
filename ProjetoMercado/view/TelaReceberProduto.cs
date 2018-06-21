using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoMercado.model.domain;
using ProjetoMercado.model.dao;

namespace ProjetoMercado.view
{
    public partial class TelaReceberProduto : Form
    {
        public TelaReceberProduto()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            Produto produto = produtoDAO.Read(txtCodigoBarras.Text);

            ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();
            ProdutoEstoque produtoEstoque = produtoEstoqueDAO.Read(produto.Codigo);

            produtoEstoque.QuantidadeEstoque += int.Parse(txtQuantidade.Text);
            produtoEstoqueDAO.Update(produtoEstoque);
        }
    }
}
