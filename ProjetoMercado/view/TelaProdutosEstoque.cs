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

        private void dgvProdutosEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibeInformacoes();
            btnInformacoesFornecedor.Enabled = true;
        }

        private void ExibeInformacoes()
        {
            Produto produto = new Produto();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            int codigo = int.Parse(dgvProdutosEstoque.CurrentRow.Cells[0].Value.ToString());
            int quantidadeEstoque = int.Parse(dgvProdutosEstoque.CurrentRow.Cells[2].Value.ToString());
            int quantidadeMinima = int.Parse(dgvProdutosEstoque.CurrentRow.Cells[3].Value.ToString());

            produto = produtoDAO.Read(codigo);

            txtCodigo.Text = produto.Codigo.ToString();
            txtPreco.Text = produto.Preco.ToString();
            txtCodBarras.Text = produto.CodigoBarras;
            txtDescricao.Text = produto.Descricao;
            txtCategoria.Text = produto.Categoria.Descricao;
            txtFornecedor.Text = produto.Fornecedor.Nome;

            if (quantidadeEstoque >= quantidadeMinima)
                txtSituacao.Text = "Quantidade em Estoque Normal";
            else
                txtSituacao.Text = "Quantidade em Estoque Abaixo do Normal";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInformacoesFornecedor_Click(object sender, EventArgs e)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            FornecedorDAO fornecedorDAO = new FornecedorDAO();
            int codigo = int.Parse(dgvProdutosEstoque.CurrentRow.Cells[0].Value.ToString());
            Fornecedor fornecedor = fornecedorDAO.Read(produtoDAO.Read(codigo).Fornecedor.Codigo);
            TelaExibeFornecedor telaExibeFornecedor = new TelaExibeFornecedor(fornecedor);
            //this.Hide();
            telaExibeFornecedor.ShowDialog();
            //this.Show();
        }
    }
}