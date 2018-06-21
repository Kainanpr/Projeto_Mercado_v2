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

            if (!txtQuantidade.Text.Equals(""))
            {
                /* Atualiza o estoque */
                produtoEstoque.QuantidadeEstoque += int.Parse(txtQuantidade.Text);
                produtoEstoqueDAO.Update(produtoEstoque);

                /* Exibe a mensage na tela */
                MessageBox.Show("Quantidade em estoque do produto atualizada", "Estoque atualizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirmar.Enabled = false;

                /* Limpa as caixas de texto */
                txtCodigoBarras.Text = "";
                txtDescricao.Text = "";
                txtQuantidade.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor, insira a quantidade recebida do produto",
                    "Falntando Informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCodigoBarras_Leave(object sender, EventArgs e)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            /* Verifica se existe um código de barras inserido */
            if (!txtCodigoBarras.Text.Equals(""))
            {
                Produto produto;

                /* Recupera o produto no Banco de Dados */
                produto = produtoDAO.Read(txtCodigoBarras.Text);

                if (produto != null)
                {
                    txtDescricao.Text = produto.Descricao;
                    txtQuantidade.ReadOnly = false;
                    btnConfirmar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Código de Barras não cadastrado.", "Produto não cadastrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoBarras.Text = "";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
