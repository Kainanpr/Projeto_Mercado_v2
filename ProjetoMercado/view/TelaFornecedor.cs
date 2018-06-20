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

            AtualizaCBEstado(); /* Preeche o combo box estado com os estados */
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
                !cbEstado.Text.Equals(""))
            {
                /* Verifica se o CNPJ está preenchido completamente */
                if(txtCNPJ.MaskCompleted)
                {
                    /* Valida o CNPJ */

                    if (ValidaCNPJ())
                    {
                        /* Verifica se o telefone está preenchido completamente */
                        if (txtTelefone.MaskCompleted)
                        {
                            /* Verifica se o CEP está completamente preenchido */
                            if (txtCEP.MaskCompleted)
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
                            MessageBox.Show("O telefone não está completamente preenchido.", "Telefone Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O CNPJ inserido não é válido.", "CNPJ Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O CNPJ inserido não está completamente preenchido.", "CNPJ Incompleto",
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
                MessageBox.Show("Há informações faltando. Por favor, preencha todas a informações", 
                    "Falta de informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /* Verifica se o usúario tem certeza que deseja excluir o fornecedor */
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este fornecedor?",
                "Deseja excluir fornecedor?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                /* Busca no Banco de Dados e exclui */
                Fornecedor fornecedor = GetDTO();

                /* Chama o método para excluir o fornecedor do bd */
                if(fornecedorDAO.Delete(fornecedor))
                {
                    /* Mensagem indicando que o fornecedor foi excluído */
                    MessageBox.Show("Fornecedor foi excluído.", "Fornecedor Excluído",
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
            fornecedor.Estado = cbEstado.Text;
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
            cbEstado.Text = fornecedor.Estado;
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
            cbEstado.Enabled = state;
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
            cbEstado.Text = "";
        }

        private void AtualizaCBEstado()
        {
            /* Vetor contendo os estados do Brasil */
            string[] estados = new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF",
                "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ",
                "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO", "" };

            /* Adiciona no combo box */
            cbEstado.Items.AddRange(estados);
        }

        private bool ValidaCNPJ()
        {
            /* Variáveis para armazenar os dígitos verificadores */
            int digito1;
            int digito2;

            /* String que contém o CNPJ formatado */
            string cnpjF = txtCNPJ.Text;

            /* Vetor de int para armazenar os dígitos do CNPJ */
            int[] CNPJ = new int[14];
            CNPJ[0] = int.Parse(cnpjF[0].ToString());
            CNPJ[1] = int.Parse(cnpjF[1].ToString());
            CNPJ[2] = int.Parse(cnpjF[3].ToString());
            CNPJ[3] = int.Parse(cnpjF[4].ToString());
            CNPJ[4] = int.Parse(cnpjF[5].ToString());
            CNPJ[5] = int.Parse(cnpjF[7].ToString());
            CNPJ[6] = int.Parse(cnpjF[8].ToString());
            CNPJ[7] = int.Parse(cnpjF[9].ToString());
            CNPJ[8] = int.Parse(cnpjF[11].ToString());
            CNPJ[9] = int.Parse(cnpjF[12].ToString());
            CNPJ[10] = int.Parse(cnpjF[13].ToString());
            CNPJ[11] = int.Parse(cnpjF[14].ToString());
            CNPJ[12] = int.Parse(cnpjF[16].ToString());
            CNPJ[13] = int.Parse(cnpjF[17].ToString());

            /* Calcular o 1º dígito verificador */
            digito1 = (5 * CNPJ[0]) + (4 * CNPJ[1]) + (3 * CNPJ[2]) + (2 * CNPJ[3]);
            digito1 += (9 * CNPJ[4]) + (8 * CNPJ[5]) + (7 * CNPJ[6]) + (6 * CNPJ[7]);
            digito1 += (5 * CNPJ[8]) + (4 * CNPJ[9]) + (3 * CNPJ[10]) + (2 * CNPJ[11]);
            digito1 = 11 - (digito1 % 11);
            if (digito1 >= 10)
                digito1 = 0;

            /* Calcular o 2º dígito verificador */
            digito2 = (6 * CNPJ[0]) + (5 * CNPJ[1]) + (4 * CNPJ[2]) + (3 * CNPJ[3]);
            digito2 += (2 * CNPJ[4]) + (9 * CNPJ[5]) + (8 * CNPJ[6]) + (7 * CNPJ[7]);
            digito2 += (6 * CNPJ[8]) + (5 * CNPJ[9]) + (4 * CNPJ[10]) + (3 * CNPJ[11]);
            digito2 += 2 * CNPJ[12];
            digito2 = 11 - (digito2 % 11);
            if (digito2 >= 10)
                digito2 = 0;

            if (CNPJ[12] == digito1 && CNPJ[13] == digito2)
                return true;
            else
                return false;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação */
            if (!(char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                e.KeyChar.Equals('\b')))
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
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar.Equals('\b')))
                e.Handled = true;                
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de dígitos e caracteres de pontuação */
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                e.KeyChar.Equals('\b')))
                e.Handled = true;
        }

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Não permite a inserção de caracteres especiais */
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar.Equals('.') ||
                char.IsWhiteSpace(e.KeyChar) || e.KeyChar.Equals('\b')))
                e.Handled = true;

        }
    }
}