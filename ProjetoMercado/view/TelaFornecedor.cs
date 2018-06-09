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
    public partial class TelaFornecedor : Form
    {
        /* Atributo responsável pelo CRUD Fornecedor */
        private FornecedorDAO fornecedorDAO = new FornecedorDAO();

        public TelaFornecedor()
        {
            InitializeComponent();
        }

        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            AtualizaDGV(); /* Atualiza o Data Grid View */
        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* Habilitação e desabilitação dos botões */
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;

            ExibeFornecedor(); /* Exibe o Fornecedor nas caixas de texto */
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
            Fornecedor fornecedor;
            bool dadosCompletos = false; /* Indica o preenchimento correto dos dados */

            /* Verifica se os campos obrigatórios estão preenchidos */
            if(!txtNome.Text.Equals("") && !txtRua.Text.Equals("") &&
                !txtN.Text.Equals("") && !txtCidade.Text.Equals("") &&
                !txtEstado.Text.Equals(""))
            {
                /* Verifica se o CNPJ está preenchido completamente */
                if(txtCNPJ.MaskCompleted)
                {
                    /* Verifica se o telefone está preenchido completamente */
                    if(txtTelefone.MaskCompleted)
                    {
                        /* Verifica se o CEP está completamente preenchido */
                        if(txtCEP.MaskCompleted)
                        {
                            dadosCompletos = true;
                        }
                        else
                        {
                            MessageBox.Show("O CEP não está completamente preenchido.", "CEP Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O telefone inserido não é válido.", "Telefone Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O CNPJ inserido não está completo.", "CNPJ Incompleto",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                /* Chama o método para retornar um objeto Fornecedor com as informações da tela */
                fornecedor = GetDTO();


                /* Se os dados estiverem completos, pode prosseguir */
                if (dadosCompletos)
                {
                    if (txtCodigo.Text.Equals(""))
                    {
                        /* Quando um fornecedor está sendo adicionado ela não possui código, 
                         * logo, o txtCodigo estará sempre vazio. É chamado então, o método 
                         * para criar o fornecedor no Banco de Dados */
                        if (fornecedorDAO.Create(fornecedor))
                            MessageBox.Show("O Fornecedor foi cadastrado.", "Fornecedor Cadastrado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        /* Já quando ele está sendo atualizado, o txtCodigo estará preenchido,
                         * então o método para atualizar o fornecedor no Banco de Dados é chamado */
                        if(fornecedorDAO.Update(fornecedor))
                            MessageBox.Show("O Fornecedor foi atualizado.", "Fornecedor Atualizado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            /* Verifica se o usúario tem certeza que deseja excluir o fornecedor */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este produto?",
                "Atenção", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                /* Busca no Banco de Dados e exclui */
                Fornecedor fornecedor = GetDTO();
                fornecedorDAO.Delete(fornecedor);

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

        /* ABAIXO APENAS METODOS AUXILIARES */

        /* Retorna um objeto categoria com as informações recolhidas da tela */
        private Fornecedor GetDTO()
        {
            Fornecedor fornecedor = new Fornecedor();

            /* Quando um Fornecedor é adicionado, não é inserido o código */
            if (!txtCodigo.Text.Equals(""))
                fornecedor.Codigo = int.Parse(txtCodigo.Text);
            fornecedor.Cnpj = txtCNPJ.Text;
            fornecedor.Nome = txtNome.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Telefone = txtTelefone.Text;
            fornecedor.Rua = txtRua.Text;
            fornecedor.Numero = int.Parse(txtN.Text);
            fornecedor.Cep = txtCEP.Text;
            fornecedor.Cidade = txtCidade.Text;
            fornecedor.Estado = txtEstado.Text;
            return fornecedor;
        }

        /* Preenche a tela com as informações passadas com a categoria */
        private void SetDTO(Fornecedor fornecedor)
        {
            txtCodigo.Text = fornecedor.Codigo.ToString();
            txtCNPJ.Text = fornecedor.Cnpj;
            txtNome.Text = fornecedor.Nome;
            txtEmail.Text = fornecedor.Email;
            txtTelefone.Text = fornecedor.Telefone;
            txtRua.Text = fornecedor.Rua;
            txtN.Text = fornecedor.Numero.ToString();
            txtCEP.Text = fornecedor.Cep;
            txtCidade.Text = fornecedor.Cidade;
            txtEstado.Text = fornecedor.Estado;
        }

        /* Atualiza as informações do dataGridView */
        private void AtualizaDGV()
        {
            /* Recebe todos os fornecedores do Bando de Dados */
            List<Fornecedor> listaFornecedores = fornecedorDAO.ListAll();

            /* Limpa o Data Grid View */
            dgvFornecedores.Rows.Clear();

            /* Percorre a lista adicionando os fornecedores no Data Grid View */
            foreach (Fornecedor fornecedor in listaFornecedores)
                dgvFornecedores.Rows.Add(fornecedor.Codigo.ToString(), fornecedor.Nome, fornecedor.Telefone);

            /* Limpa a seleção de linhas no Data Grid View */
            dgvFornecedores.ClearSelection();
        }

        /* Verifica qual produto foi selecionada e o exibe */
        private void ExibeFornecedor()
        {
            /* Pega o código do fornecedor selecionado */
            int codigo = int.Parse(dgvFornecedores.CurrentRow.Cells[0].Value.ToString());

            /* Busca no Banco de Dados e preenche a tela */
            Fornecedor fornecedor = fornecedorDAO.Read(codigo);
            SetDTO(fornecedor);
        }

        /* Habilita ou desabilita a edição das textBoxs */
        private void HabilitarEdicao(bool state)
        {
            txtCNPJ.ReadOnly = !state;
            txtNome.ReadOnly = !state;
            txtEmail.ReadOnly = !state;
            txtTelefone.ReadOnly = !state;
            txtCEP.ReadOnly = !state;
            txtRua.ReadOnly = !state;
            txtN.ReadOnly = !state;
            txtCidade.ReadOnly = !state;
            txtEstado.ReadOnly = !state;
        }

        /* Limpa as caixas de texto */
        private void LimparTextBox()
        {
            txtCodigo.Text = "";
            txtCNPJ.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCEP.Text = "";
            txtRua.Text = "";
            txtN.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação */
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            /* Se o 9º dígito foi inserido muda para o formato de Nº de celular */
            if (txtTelefone.MaskFull)
                txtTelefone.Mask = "(00)00000-0009";
            else
                txtTelefone.Mask = "(00)0000-00009";
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Permite apenas a inserção de dígitos */
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;                
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação */
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }


    }
}