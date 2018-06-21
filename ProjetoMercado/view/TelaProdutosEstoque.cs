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
    public partial class TelaProdutosEstoque : Form
    {
        public TelaProdutosEstoque()
        {
            InitializeComponent();
        }

        private void TelaProdutosEstoque_Load(object sender, EventArgs e)
        {
            AtualizaDGV();
        }

        private void AtualizaDGV()
        {
            ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();

            List<ProdutoEstoque> listaProdutos = produtoEstoqueDAO.ListAll();

            foreach (ProdutoEstoque produtoEstoque in listaProdutos)
            {
                dgvProdutosEstoque.Rows.Add(produtoEstoque.Produto.Codigo,
                    produtoEstoque.Produto.Descricao, produtoEstoque.QuantidadeEstoque,
                    produtoEstoque.Produto.QntMinEstoque);
            }

            dgvProdutosEstoque.ClearSelection();
        }
    }
}