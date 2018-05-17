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
    public partial class TelaProduto : Form
    {
        /* Atributo responsável pelo CRUD produto */
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        /* Atributo responsável pelo CRUD categoria */
        private CategoriaDAO categoriaDAO = new CategoriaDAO();
        /* Atributo responsável pelo CRUD fornecedor */
        private FornecedorDAO fornecedorDAO = new FornecedorDAO();

        public TelaProduto()
        {
            InitializeComponent();
        }

        private void TelaProduto_Load(object sender, EventArgs e)
        {
            AtualizaDGV(); /* Atualiza o Data Grid View */
            AtualizaCbCategoria(); /* Atualiza o Combo Box Categoria */
            AtualizaCbFornecedor(); /* Atualiza o Combo Box Fornecedor */
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;

            exibeProduto(); /* Exibe o produto nas caixas de texto */

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
          

            limparTextBox(); /* Limpa as caixas de texto */

            habilitarEdicao(true); /* Habilita a edição */
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            habilitarEdicao(true); /* Habilita a edição */
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto;

            /* Verifica se os campos obrigatórios estão preenchidos */
            if (!txtPreco.Text.Equals("") && !txtCodBarras.Text.Equals("") &&
                !txtDescricao.Text.Equals("") && !cbCategoria.Text.Equals("") &&
                !txtQntMinEstoque.Text.Equals("") && !cbFornecedor.Text.Equals(""))
            {
                /* Chama o método para retornar um objeto produto com as informações da tela */
                produto = GetDTO();

                /* Se categoria for null, ela não está cadastrada no Banco de Dados */
                if (produto.Categoria != null)
                {
                    if (txtCodigo.Text.Equals(""))
                    {
                        /* Quando uma categoria está sendo adicionada ela não possui código, 
                         * logo, o txtCodigo estará sempre vazio. É chamado então, o método 
                         * para criar a categoria no Banco de Dados */
                        produtoDAO.Create(produto);
                    }
                    else
                    {
                        /* Já quando ela está sendo atualizada o txtCodigo estará preenchido,
                         * então o método para atualizar a categoria no Banco de Dados é chamado */
                        produtoDAO.Update(produto);
                    }
                    /* Atualiza o Data Grid View */
                    AtualizaDGV();

                    /* Habilitação e desabilitação dos botões */
                    btnAdicionar.Enabled = true;
                    btnAtualizar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCancelar.Enabled = false;

                    limparTextBox(); /* Limpa as caixas de texto */

                    habilitarEdicao(false); /* Desabilita a edição */
                }
                else
                {
                    /* Mensagem informando que a categoria não está no Banco de Dados */
                    MessageBox.Show("Por favor, escolha uma categoria que esteja cadastrada",
                        "Categoria não cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            else
            {
                /* Exibe uma mensagem informando falta de informações */
                MessageBox.Show("Por favor, preencha todas a informações", "Faltando informações",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /* Verifica se o usúario tem certeza que deseja excluir um produto */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este produto?", "Atenção", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                /* Busca no Banco de Dados e exclui */
                Produto produto = GetDTO();
                produtoDAO.Delete(produto);

                AtualizaDGV(); /* Atualiza o Data Grid View */

                habilitarEdicao(false); /* Desabilita a edição */

                /* Habilitação e desabilitação dos botões */
                btnAdicionar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = false;

                limparTextBox(); /* Limpa as caixas de texto */
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;

            limparTextBox(); /* Limpa as caixas de texto */

            habilitarEdicao(false); /* Desabilita a edição */
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); /* Fecha a janela */
        }



        /* ABAIXO APENAS METODOS AUXILIARES */

        /* Retorna um objeto categoria com as informações recolhidas da tela */
        private Produto GetDTO()
        {
            Produto produto = new Produto();
            Categoria categoria = new Categoria();
            Fornecedor fornecedor = new Fornecedor();

            /* Lê a categoria do Banco de Dados para recuperar o codigo 
             * e para saber se ela está cadastrada */
            categoria = categoriaDAO.Read(cbCategoria.Text);

            /* Lê a fornecedor do Banco de Dados para recuperar o codigo 
             * e para saber se ela está cadastrada */
            fornecedor = fornecedorDAO.Read(cbFornecedor.Text);

            /* Quando um Produto é adicionada, não é inserido o código */
            if (!txtCodigo.Text.Equals(""))
                produto.Codigo = int.Parse(txtCodigo.Text);
            produto.Preco = decimal.Parse(txtPreco.Text);
            produto.CodigoBarras = long.Parse(txtCodBarras.Text);
            produto.Descricao = txtDescricao.Text;
            produto.Categoria = categoria;
            produto.Fornecedor = fornecedor;
            produto.QntMinEstoque = int.Parse(txtQntMinEstoque.Text);
            return produto;
        }

        /* Preenche a tela com as informações passadas com a categoria */
        private void SetDTO(Produto produto)
        {
            txtCodigo.Text = produto.Codigo.ToString();
            txtPreco.Text = produto.Preco.ToString();
            txtCodBarras.Text = produto.CodigoBarras.ToString();
            txtDescricao.Text = produto.Descricao;
            cbCategoria.Text = produto.Categoria.Descricao;
            cbFornecedor.Text = produto.Fornecedor.Nome;
            txtQntMinEstoque.Text = produto.QntMinEstoque.ToString();

        }

        /* Atualiza as informações da dataGridView */
        private void AtualizaDGV()
        {
            /* Recebe todos os produtos do Bando de Dados */
            List<Produto> listaProdutos = produtoDAO.ListAll();

            /* Limpa o Data Grid View */
            dgvProdutos.Rows.Clear();

            /* Percorre a lista adicionando categoria por categoria no Data Grid View */
            foreach (Produto produto in listaProdutos)
                dgvProdutos.Rows.Add(produto.Codigo, produto.Descricao, produto.Preco.ToString("c"));

            /* Limpa a seleção de linhas no Data Grid View */
            dgvProdutos.ClearSelection();
        }

        private void AtualizaCbCategoria()
        {          
            /* Recebe todas as Categorias do Bando de Dados */
            List<Categoria> listaCategorias = categoriaDAO.ListAll();

            /* Limpa o Combo Box */
            cbCategoria.Items.Clear();

            /* Percorre a lista adicionando categoria por categoria no Combo Box */
            foreach (Categoria categoria in listaCategorias)
                cbCategoria.Items.Add(categoria.Descricao);
        }


        private void AtualizaCbFornecedor()
        {
            /* Recebe todas as Categorias do Bando de Dados */

            List<Fornecedor> listaFornecedores = fornecedorDAO.ListAll();

            /* Limpa o Combo Box */
            cbFornecedor.Items.Clear();

            /* Percorre a lista adicionando categoria por categoria no Combo Box */
            foreach (Fornecedor fornecedor in listaFornecedores)
                cbFornecedor.Items.Add(fornecedor.Nome);
        }

        /* Verifica qual produto foi selecionada e o exibe */
        private void exibeProduto()
        {
            /* Pega o código da categoria selecionada */
            int codigo = int.Parse(dgvProdutos.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            Produto produto = produtoDAO.Read(codigo);
            SetDTO(produto);
        }

        /* Habilita ou desabilita a edição das textBoxs */
        private void habilitarEdicao(bool state)
        {
            txtPreco.ReadOnly = !state;
            txtCodBarras.ReadOnly = !state;
            txtDescricao.ReadOnly = !state;
            cbCategoria.Enabled = state;
            cbFornecedor.Enabled = state;
            txtQntMinEstoque.ReadOnly = !state;
        }

        /* Limpa as caixas de texto */
        private void limparTextBox()
        {
            txtCodigo.Text = "";
            txtPreco.Text = "";
            txtCodBarras.Text = "";
            txtDescricao.Text = "";
            cbCategoria.Text = "";
            cbFornecedor.Text = "";
            txtQntMinEstoque.Text = "";
        }
    }
}