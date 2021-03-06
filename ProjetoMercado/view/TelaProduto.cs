﻿using System;
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

            ExibeProduto(); /* Exibe o produto nas caixas de texto */
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
          

            LimparTextBox(); /* Limpa as caixas de texto */

            HabilitarEdicao(true); /* Habilita a edição */
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            HabilitarEdicao(true); /* Habilita a edição */
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
                        if(produtoDAO.Create(produto))
                        {
                            ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                            ProdutoEstoqueDAO produtoEstoqueDAO = new ProdutoEstoqueDAO();

                            /* Adiciona o produto em um objeto ProdutoEstoque */
                            produtoEstoque.Produto = produtoDAO.Read(txtCodBarras.Text);
                            produtoEstoque.QuantidadeEstoque = 0;

                            /* Salva o produto no estoque também */
                            produtoEstoqueDAO.Create(produtoEstoque);

                            /* Mensagem indicando que o produto foi cadastrado */
                            MessageBox.Show("Produto foi cadastrado.", "Produto Cadastrado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        /* Já quando ela está sendo atualizada o txtCodigo estará preenchido,
                         * então o método para atualizar a categoria no Banco de Dados é chamado */
                        if(produtoDAO.Update(produto))
                        {
                            /* Mensagem indicando que o produto foi atualizado */
                            MessageBox.Show("Produto foi atualizado.", "Produto Atualizado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* Atualiza o Data Grid View */
                    AtualizaDGV();

                    /* Habilitação e desabilitação dos botões */
                    btnAdicionar.Enabled = true;
                    btnAtualizar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCancelar.Enabled = false;

                    LimparTextBox(); /* Limpa as caixas de texto */

                    HabilitarEdicao(false); /* Desabilita a edição */
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
                MessageBox.Show("Há informações faltando. Por favor, preencha todas a informações", 
                    "Falta de informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /* Verifica se o usúario tem certeza que deseja excluir um produto */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este produto?",
                "Deseja excluir produto?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                /* Busca no Banco de Dados e exclui */
                Produto produto = GetDTO();

                if(produtoDAO.Delete(produto))
                {
                    /* Mensagem indicando que o produto foi excluído */
                    MessageBox.Show("Produto foi excluído.", "Produto Excluído",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AtualizaDGV(); /* Atualiza o Data Grid View */

                HabilitarEdicao(false); /* Desabilita a edição */

                /* Habilitação e desabilitação dos botões */
                btnAdicionar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = false;

                LimparTextBox(); /* Limpa as caixas de texto */
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

            LimparTextBox(); /* Limpa as caixas de texto */

            HabilitarEdicao(false); /* Desabilita a edição */
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); /* Fecha a janela */
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Só permite a inserção de dígitos e de uma vírgula no text box Preço */
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar.Equals(',') && !txtPreco.Text.Contains(',')) ||
                char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Permite apenas a inserção de dígitos no text box Código de Barras */
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação */
            if (!(char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                e.KeyChar.Equals('\b')))
                e.Handled = true;
        }

        private void txtQntMinEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Permite apenas a inserção de dígitos no text box Quantidade Mínima */
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
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
            produto.CodigoBarras = txtCodBarras.Text;
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
            txtCodBarras.Text = produto.CodigoBarras;
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

            cbCategoria.Items.Add("");
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

            cbFornecedor.Items.Add("");
        }

        /* Verifica qual produto foi selecionada e o exibe */
        private void ExibeProduto()
        {
            /* Pega o código da categoria selecionada */
            int codigo = int.Parse(dgvProdutos.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            Produto produto = produtoDAO.Read(codigo);
            SetDTO(produto);
        }

        /* Habilita ou desabilita a edição das textBoxs */
        private void HabilitarEdicao(bool state)
        {
            txtPreco.ReadOnly = !state;
            txtCodBarras.ReadOnly = !state;
            txtDescricao.ReadOnly = !state;
            cbCategoria.Enabled = state;
            cbFornecedor.Enabled = state;
            txtQntMinEstoque.ReadOnly = !state;
        }

        /* Limpa as caixas de texto */
        private void LimparTextBox()
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