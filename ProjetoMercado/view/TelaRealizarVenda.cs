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
    public partial class TelaRealizarVenda : Form
    {
        decimal subTotal = 0.0m;

        public TelaRealizarVenda()
        {
            InitializeComponent();
            txtSubTotal.Text = subTotal.ToString("c");
        }

        private void txtCodBarras_Leave(object sender, EventArgs e)
        {
            /* Verifica se existe um código de barras inserido */
            if (!txtCodBarras.Text.Equals(""))
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();
                Produto produto;

                /* Recupera o produto no Banco de Dados */
                produto = produtoDAO.Read(long.Parse(txtCodBarras.Text));

                if (produto != null)
                {
                    ExibeProduto(produto); /* Exibe o produto na tela */
                    txtQuantidade.ReadOnly = false; /* Habilita a edição */

                    /* Habilitação dos botões */
                    btnConfirmarProduto.Enabled = true;
                    btnCancelarProduto.Enabled = true;
                }
                else
                    MessageBox.Show("Código de Barras não cadastrado.", "Produto não cadastrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirmarProduto_Click(object sender, EventArgs e)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            Produto produto = produtoDAO.Read(long.Parse(txtCodBarras.Text));

            /* Salva a quantidade, se não tiver nada no textbox assume 1 */
            int quantidade;
            if (!int.TryParse(txtQuantidade.Text, out quantidade))
                quantidade = 1;

            /* Adiciona o produto no Data Grid View */
            dgvProdutos.Rows.Add(produto.Codigo, produto.Descricao, quantidade,
                (produto.Preco * quantidade).ToString("c"));

            /* Atualiza p subTotal da Venda */
            subTotal += (produto.Preco * quantidade);
            txtSubTotal.Text = subTotal.ToString("c");

            /* Desabilita os botões */
            btnConfirmarProduto.Enabled = false;
            btnCancelarProduto.Enabled = false;
            btnConfirmarVenda.Enabled = true;

            txtQuantidade.ReadOnly = true; /* Desabilita a edição */

            LimparTextBox(); /* Limpa as textBox */
        }

        private void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            /* Desabilita os botões */
            btnConfirmarProduto.Enabled = false;
            btnCancelarProduto.Enabled = false;

            txtQuantidade.ReadOnly = true; /* Desabilita a edição */

            LimparTextBox(); /* Limpa as textBox */
        }


        /* Exibe as informações do produto na tela */
        private void ExibeProduto(Produto produto)
        {
            txtPreco.Text = produto.Preco.ToString("c");
            txtDescricao.Text = produto.Descricao;
            txtCategoria.Text = produto.Categoria.Descricao;
        }

        /* Limpa todos os textBox */
        private void LimparTextBox()
        {
            txtCodBarras.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            txtDescricao.Text = "";
            txtCategoria.Text = "";
        }

        private void btnConfirmarVenda_Click(object sender, EventArgs e)
        {
            /* Realiza as operações com a venda */
            VendaDAO vendaDAO = new VendaDAO();
            Venda venda = new Venda();

            /* Coloca o codigo em venda, sendo o último inserido no banco mais um */
            venda.Codigo = vendaDAO.NextCodVenda();

            /* Coloca a hora da venda */
            venda.DataHora = DateTime.Now;

            /* Coloca o valor total da venda */
            venda.ValotTotal = subTotal;

            /* Grava a venda no Banco de Dados */
            vendaDAO.Create(venda);

            /* Depois, realiza as operações com os itens */

            /* Percorre todos os produtos que estão no Data Grid View */
            for(int i = 0; i < dgvProdutos.Rows.Count; i++)
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
                ItemVenda itemVenda = new ItemVenda();

                /* Busca o produto pelo código presente no DGV e o coloca em item*/
                itemVenda.Produto = produtoDAO.Read(int.Parse(dgvProdutos.Rows[i].Cells[0].Value.ToString()));

                /* Informa a venda para o item */
                itemVenda.Venda = venda;

                /* Coloca a quantidade em item */
                itemVenda.Quantidade = int.Parse(dgvProdutos.Rows[i].Cells[2].Value.ToString());

                /* Grava o ItemVenda no Banco de Dados */
                itemVendaDAO.Create(itemVenda);
            }
            /* Desabilita o botão */
            btnConfirmarVenda.Enabled = false;

            txtQuantidade.ReadOnly = true; /* Desabilita a edição */

            LimparTextBox(); /* Limpa as textBox */

            dgvProdutos.Rows.Clear(); /* Limpa o DGV */

            subTotal = 0.0m;

            txtSubTotal.Text = subTotal.ToString("c");
        }
    }
}

