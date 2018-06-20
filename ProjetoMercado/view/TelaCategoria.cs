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
        /* Atributo responsável pelo CRUD categoria */
        private CategoriaDAO categoriaDAO = new CategoriaDAO();

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
                        
            ExibeCategoria(); /* Exibe a categoria nas caixas de texto */
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
                    if (categoriaDAO.Create(categoria))
                    {
                        /* Mensagem indicando que a categoria foi cadastrada */
                        MessageBox.Show("Categoria foi cadastrada.", "Categoria Cadastrada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    /* Já quando ela está sendo atualizada o txtCodigo estará preenchido,
                     * então o método para atualizar a categoria no Banco de Dados é chamado */
                    if(categoriaDAO.Update(categoria))
                    {
                        /* Mensagem indicando que a categoria foi atualizada */
                        MessageBox.Show("Categoria foi atualizada.", "Categoria Atualizada",
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

                txtDescricao.ReadOnly = true; /* Desabilita a edição */
            }
            else
            {
                /* Exibe uma mensagem informando falta de informações */
                MessageBox.Show("Há informações faltando. Por favor, preencha a descrição.",
                    "Falta de informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /* Verifica se o usúario tem certeza que deseja excluir a categoria */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir esta categoria?",
                "Deseja excluir categoria?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                /* Busca no Banco de Dados e exclui */
                Categoria categoria = GetDTO();

                /* Chama o método para deletar a categoria do bd */
                if (categoriaDAO.Delete(categoria))
                {
                    /* Mensagem indicando que a categoria foi excluída */
                    MessageBox.Show("Categoria foi excluída.", "Categoria Excluída",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AtualizaDGV(); /* Atualiza o Data Grid View */

                txtDescricao.ReadOnly = true; /* Desabilita a edição */

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

            txtDescricao.ReadOnly = true; /* Desabilita a edição */

            /* Limpa a seleção de linhas no Data Grid View */
            dgvCategorias.ClearSelection();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); /* Fecha a janela */
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação no 
             * text box descrição */
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                e.KeyChar.Equals('\b')))
                e.Handled = true;
        }
        
        /* ABAIXO APENAS METODOS AUXILIARES */

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
        private void ExibeCategoria()
        {
            /* Pega o código da categoria selecionada */
            int codigo = int.Parse(dgvCategorias.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            Categoria categoria = categoriaDAO.Read(codigo);
            SetDTO(categoria);
        }

        /* Limpa as caixas de texto */
        private void LimparTextBox()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }
    }
}
