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
        /* Atributo responsável pelo CRUD produto */
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        /* Atributo responsável pelo CRUD produtoEstoque */
        private ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();
        /* Atributo responsável pelo CRUD venda */
        private VendaDAO vendaDAO = new VendaDAO();
        /* Atributo responsável pelo CRUD itemVenda */
        private ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
        /* Atributo do usuário que realiza a venda */
        private Usuario usuario;

        decimal subTotal = 0.0m;

        public TelaRealizarVenda(Usuario usuario)
        {
            InitializeComponent();
            txtSubTotal.Text = subTotal.ToString("c");
            this.usuario = usuario;
        }

        private void txtCodBarras_Leave(object sender, EventArgs e)
        {
            /* Verifica se existe um código de barras inserido */
            if (!txtCodBarras.Text.Equals(""))
            {
                Produto produto;

                /* Recupera o produto no Banco de Dados */
                produto = produtoDAO.Read(txtCodBarras.Text);

                if (produto != null)
                {
                    ExibeProduto(produto); /* Exibe o produto na tela */
                    txtQuantidade.ReadOnly = false; /* Habilita a edição */

                    /* Habilitação dos botões */
                    btnConfirmarProduto.Enabled = true;
                    btnCancelarProduto.Enabled = true;
                    btnExcluirProduto.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Código de Barras não cadastrado.", "Produto não cadastrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparTextBox();

                    txtQuantidade.ReadOnly = true; /* Habilita a edição */

                    /* Habilitação dos botões */
                    btnCancelarProduto.Enabled = false;
                    btnExcluirProduto.Enabled = false;
                    btnConfirmarProduto.Enabled = false;

                    dgvProdutos.ClearSelection();
                }
                    
            }
        }

        private void btnConfirmarProduto_Click(object sender, EventArgs e)
        {
            /* Encontra o produto no banco de dados */
            Produto produto = produtoDAO.Read(txtCodBarras.Text);

            /* Apos encontrar o produto, traz as informações do estoque desse produto*/
            ProdutoEstoque produtoEstoque = produtoEstoqueDAO.Read(produto.Codigo);

            /* Verifica se existe este produto no estoque */
            if(produtoEstoque.QuantidadeEstoque > 0)
            {
                /* Salva a quantidade, se não tiver nada no textbox assume 1 */
                int quantidade;
                if (!int.TryParse(txtQuantidade.Text, out quantidade))
                    quantidade = 1;

                if(quantidade <= produtoEstoque.QuantidadeEstoque)
                {
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
                else
                {
                    MessageBox.Show("Quantidade indisponível, este produto possui " + produtoEstoque.QuantidadeEstoque 
                                    + " unidades no estoque.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
  
            }
            else
            {
                MessageBox.Show("Produto indisponível.", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dgvProdutos.ClearSelection();
            
        }

        private void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            /* Desabilita os botões */
            btnConfirmarProduto.Enabled = false;
            btnCancelarProduto.Enabled = false;
            btnExcluirProduto.Enabled = false;

            dgvProdutos.ClearSelection();

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
            /* Verifica se o usúario tem certeza que deseja concluir a venda */
            var result = MessageBox.Show(this, "Você tem certeza que deseja concluir está venda?",
                "Deseja concluir está venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                List<ItemVenda> itens = new List<ItemVenda>();

                /* Realiza as operações com a venda */
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
                for (int i = 0; i < dgvProdutos.Rows.Count; i++)
                {
                    ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();
                    ItemVenda itemVenda = new ItemVenda();

                    /* Busca o produto pelo código presente no DGV e o coloca em item*/
                    itemVenda.Produto = produtoDAO.Read(int.Parse(dgvProdutos.Rows[i].Cells[0].Value.ToString()));

                    /* Informa a venda para o item */
                    itemVenda.Venda = venda;

                    /* Coloca a quantidade em item */
                    itemVenda.Quantidade = int.Parse(dgvProdutos.Rows[i].Cells[2].Value.ToString());

                    /* Pega o preco do produto e coloca o preco no item da venda 
                     * (Caso o valor do produto mude, temos esse registro do valor que o produto foi vendido)*/
                    itemVenda.PrecoUnitario = itemVenda.Produto.Preco;

                    /* Grava o ItemVenda no Banco de Dados */
                    itemVendaDAO.Create(itemVenda);

                    /* Adiciona os itens em uma lista para gerar a nota Fiscal */
                    itens.Add(itemVenda);

                    /* Recupera a informação do Produto Estoque */
                    ProdutoEstoque produtoEstoque = produtoEstoqueDAO.Read(itemVenda.Produto.Codigo);

                    /* Atualiza o estoque subtraindo os produtos vendidos */
                    produtoEstoque.QuantidadeEstoque -= itemVenda.Quantidade;

                    /* Armazena o BD o novo estoque */
                    produtoEstoqueDAO.Update(produtoEstoque);
                }

                /* Verifica se o usúario quer gerar a nota fiscal */
                var result2 = MessageBox.Show(this, "Você deseja gerar e salvar a nota fiscal?",
                    "Deseja gerar a nota fiscal?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(result2 == DialogResult.Yes)
                {
                    /* Responsável por gerar o relatório dos produtos do estoque */

                    /* Caixa de diálogo para salvar o arquivo */
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.DefaultExt = ".pdf";
                    saveFileDialog.ShowDialog();

                    if (!saveFileDialog.FileName.ToString().Equals(""))
                    {

                        Relatorios.GerarNotaFiscal(saveFileDialog.FileName.ToString(), itens);

                        MessageBox.Show("Nota fiscal foi gerada", "Nota Fiscal Gerada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                /* Desabilita o botão */
                btnConfirmarVenda.Enabled = false;
                btnExcluirProduto.Enabled = false;
                btnCancelarProduto.Enabled = false;

                txtQuantidade.ReadOnly = true; /* Desabilita a edição */

                LimparTextBox(); /* Limpa as textBox */

                dgvProdutos.Rows.Clear(); /* Limpa o DGV */

                subTotal = 0.0m;

                txtSubTotal.Text = subTotal.ToString("c");

                /* Mensagem indicando que a compra foi realizada com sucesso */
                MessageBox.Show("Venda foi realizada com sucesso.", "Venda realizada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                    
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnConfirmarProduto.Enabled = false;
            btnExcluirProduto.Enabled = true;
            btnCancelarProduto.Enabled = true;

            txtQuantidade.ReadOnly = true; /* Habilita a edição */

            ExibeProduto(); /* Exibe o produto nas caixas de texto */
        }


        /* Preenche a tela com as informações passadas com a categoria */
        private void SetDTO(Produto produto)
        {
            txtQuantidade.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
            txtPreco.Text = produto.Preco.ToString();
            txtCodBarras.Text = produto.CodigoBarras;
            txtDescricao.Text = produto.Descricao;
            txtCategoria.Text = produto.Categoria.Descricao;
        }

        private void ExibeProduto()
        {
            /* Pega o código da categoria selecionada */
            int codigo = int.Parse(dgvProdutos.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            Produto produto = produtoDAO.Read(codigo);

            SetDTO(produto);
        }

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            /* Verifica se o usúario tem certeza que deseja excluir um produto do carrinho */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este produto do carrinho?",
                "Deseja excluir produto?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                /* Coloca em uma string o sub total do datagrid do produto selecionado */
                String subTotalProduto = dgvProdutos.CurrentRow.Cells[3].Value.ToString();

                /* Como a string virá com caracteres, sera necessario a remoção para fazer a conta */
                subTotalProduto = subTotalProduto.Trim(new Char[] { 'R', '$', ' ' });

                /* Como o produto foi excluido, sera necessario subtrair o sub total da venda */
                subTotal -= decimal.Parse(subTotalProduto);

                /* Atualiza o sub total da venda na tela */
                txtSubTotal.Text = "R$ " + subTotal.ToString();

                /* Remove a linha correspondente ao produto excluido */
                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);

                /* Retira a seleção do datagrid */
                dgvProdutos.ClearSelection();

                LimparTextBox();

                btnExcluirProduto.Enabled = false;
                btnCancelarProduto.Enabled = false;

                MessageBox.Show("Produto foi excluído do carrinho.", "Produto Excluído",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* Caso o sub total seja 0 nao sera possivel confirmar a venda */
                if(subTotal <= 0.0m)
                    btnConfirmarVenda.Enabled = false;
            }

        }
        

    }
}

