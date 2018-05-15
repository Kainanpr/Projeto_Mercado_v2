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
    public partial class TelaCategoria : Form
    {
        public TelaCategoria()
        {
            InitializeComponent();
        }

        private void TelaCategoria_Load(object sender, EventArgs e)
        {
            AtualizaDGV(); /* Atualiza o Data Grid View */
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
                        
            exibeCategoria(); /* Exibe a categoria nas caixas de texto */
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

            txtDescricao.ReadOnly = false; /* Habilita a edição */
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            txtDescricao.ReadOnly = false; /* Habilita a edição */           
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Categoria categoria;
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            /* Verifica se os campos obrigatórios estão preenchidos */
            if (!txtDescricao.Text.Equals(""))
            {
                /* Chama o método para retornar um objeto categoria com as informações da tela */
                categoria = GetDTO();

                if (txtCodigo.Text.Equals(""))
                {
                    /* Quando uma categoria está sendo adicionada ela não possui código, 
                     * logo, o txtCodigo estará sempre vazio. É chamado então o método 
                     * para criar a categoria no Banco de Dados */
                    categoriaDAO.Create(categoria);
                }
                else
                {
                    /* Já quando ela está sendo atualizada o txtCodigo estará preenchido,
                     * então o método para atualizar a categoria no Banco de Dados é chamado */
                    categoriaDAO.Update(categoria);
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

                txtDescricao.ReadOnly = true; /* Desabilita a edição */
            }
            else
            {
                /* Exibe uma mensagem informando falta de informações */
                MessageBox.Show("Por favor, preencha a descrição.", "Faltando informações",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /* Busca no Banco de Dados e exclui */
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            Categoria categoria = GetDTO();
            categoriaDAO.Delete(categoria);

            AtualizaDGV(); /* Atualiza o Data Grid View */

            txtDescricao.ReadOnly = true; /* Desabilita a edição */

            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;

            limparTextBox(); /* Limpa as caixas de texto */
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

            txtDescricao.ReadOnly = true; /* Desabilita a edição */
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); /* Fecha a janela */
        }

        /* Retorna um objeto categoria com as informações recolhidas da tela */
        private Categoria GetDTO()
        {
            Categoria categoria = new Categoria();

            /* Quando uma categoria é adicionada, não é inserido o código */
            if (!txtCodigo.Text.Equals(""))
                categoria.Codigo = int.Parse(txtCodigo.Text);
            categoria.Descricao = txtDescricao.Text;
            return categoria;
        }
        
        /* Preenche a tela com as informações passadas com a categoria */
        private void SetDTO(Categoria categoria)
        {
            txtCodigo.Text = categoria.Codigo.ToString();
            txtDescricao.Text = categoria.Descricao;
        }

        /* Atualiza as informações da dataGridView */
        private void AtualizaDGV()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            /* Recebe todas as categorias do Bando de Dados */
            List<Categoria> listaCategorias = categoriaDAO.ListAll();

            /* Limpa o Data Grid View */
            dgvCategorias.Rows.Clear();

            /* Percorre a lista adicionando categoria por categoria no Data Grid View */
            foreach (Categoria categoria in listaCategorias)
                dgvCategorias.Rows.Add(categoria.Codigo, categoria.Descricao);

            /* Limpa a seleção de linhas no Data Grid View */
            dgvCategorias.ClearSelection();
        }

        /* Verifica qual categora foi selecionada e a exibe */
        private void exibeCategoria()
        {
            /* Pega o código da categoria selecionada */
            int codigo = int.Parse(dgvCategorias.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            Categoria categoria = categoriaDAO.Read(codigo);
            SetDTO(categoria);
        }

        /* Limpa as caixas de texto */
        private void limparTextBox()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }
    }
}
