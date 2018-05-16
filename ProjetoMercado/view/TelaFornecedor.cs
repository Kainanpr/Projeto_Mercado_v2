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

    /* View responsavel pelo formulario de clientes na parte de exclusao, pesquisa e alterações
     * Os eventos de botões representam a camada de controller(C) do MVC */
    public partial class TelaFornecedor : Form
    {

        //Atributo responsavel por ter as regras de negocio relacionadas ao DAO
        private FornecedorDAO fornecedorDAO = new FornecedorDAO();

        //Atributo para poder ser manipulado pelos metodos
        private Fornecedor fornecedor = new Fornecedor();

        public TelaFornecedor()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Verifica se o cliente digitou algo no campo localizar cliente
            if (txtPesquisarFornecedor.Text != "")
            {

                //Verifica se o radio name esta selecionado
                if (radioButtonNome.Checked)
                {

                    //Irá tentar encontrar um cliente
                    try
                    {
                        /*Encontra o cliente de acordo com seu nome
                         *(Metodo pode lançar uma exceção caso nao encontre o cliente)*/
                        List<Fornecedor> fornecedores = fornecedorDAO.FindByName(txtPesquisarFornecedor.Text.ToLower());

                        //Chama o metodo auxiliar que nos criamos para atualizar a tabela de acordo com os dados
                        AtualizarGrid(fornecedores);
                    }
                    //Caso não encontre nenhum cliente irá recuperar a exceção que nos lançamos
                    catch (Exception ex)
                    {
                        //Recupera a exceção com o erro que nos instanciamos
                        MessageBox.Show("Erro: " + ex.Message);

                        //Limpa todas as rows
                        dataGridViewClientes.Rows.Clear();
                    }

                }//Fim if

                //Verifica se o raio cpf esta selecionado
                else if (radioButtonCnpj.Checked)
                {

                    //Irá tentar encontrar um cliente
                    try
                    {
                        /*Encontra o cliente de acordo com seu cpf
                         *(Metodo pode lançar uma exceção caso nao encontre o cliente)*/
                        Fornecedor fornecedor = fornecedorDAO.FindByCnpj(txtPesquisarFornecedor.Text.ToLower());

                        //Limpa todas as rows
                        dataGridViewClientes.Rows.Clear();

                        //Atualiza a gride
                        dataGridViewClientes.Rows.Add(fornecedor.Codigo, fornecedor.Nome, fornecedor.Cnpj);

                    }
                    //Caso não encontre nenhum cliente irá recuperar a exceção que nos lançamos
                    catch (Exception ex)
                    {
                        //Recupera a exceção com o erro que nos instanciamos
                        MessageBox.Show("Erro: " + ex.Message);

                        //Limpa todas as rows
                        dataGridViewClientes.Rows.Clear();
                    }
                }
                //Verifica se o raio codigo esta selecionado
                else if (radioButtonCodigo.Checked)
                {

                    //Irá tentar encontrar um cliente
                    try
                    {
                        /*Encontra o cliente de acordo com seu cpf
                         *(Metodo pode lançar uma exceção caso nao encontre o cliente)*/
                        Fornecedor fornecedor = fornecedorDAO.Read(int.Parse(txtPesquisarFornecedor.Text));

                        //Limpa todas as rows
                        dataGridViewClientes.Rows.Clear();

                        //Atualiza a gride
                        dataGridViewClientes.Rows.Add(fornecedor.Codigo, fornecedor.Nome, fornecedor.Cnpj);

                    }
                    //Caso não encontre nenhum cliente irá recuperar a exceção que nos lançamos
                    catch (Exception ex)
                    {
                        //Recupera a exceção com o erro que nos instanciamos
                        MessageBox.Show("Erro: " + ex.Message);

                        //Limpa todas as rows
                        dataGridViewClientes.Rows.Clear();
                    }
                }


            }//Fim if
            else
            {
                MessageBox.Show("Campo está em branco");
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            //Irá tentar encontrar um cliente
            try
            {
                /*Encontra o cliente de acordo com seu id
                 *(Metodo pode lançar uma exceção caso nao encontre o cliente)*/
                List<Fornecedor> fornecedores = fornecedorDAO.ListAll();

                //Chama o metodo auxiliar que nos criamos para atualizar a tabela de acordo com os dados
                AtualizarGrid(fornecedores);
            }
            //Caso não encontre nenhum cliente irá recuperar a exceção que nos lançamos
            catch (Exception ex)
            {
                //Recupera a exceção com o erro que nos instanciamos
                MessageBox.Show("Erro: " + ex.Message);

            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            try
            {
                //Pega o id do cliente da linha do datagrid que estiver selecionado
                int id = int.Parse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString());

                //Pesquisa o cliente selecionado
                fornecedor = fornecedorDAO.Read(id);

                //Envia o cliente para setar a view
                SetDTO(fornecedor);

                //Comandos abaixos apenas para resetar o layout
                AbilitarCamposGeral();

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                btnExcluir.Enabled = true;

                btnListar.Enabled = false;
                btnAlterar.Enabled = false;
                btnPesquisar.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Selecione uma linha válida da tabela");
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCamposGeral();
            DesabilitarCamposGeral();

            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            btnListar.Enabled = true;
            btnPesquisar.Enabled = true;
            btnAdicionar.Enabled = true;
            txtPesquisarFornecedor.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           
            try
            {
                //Recupera os dados digitados na view
                fornecedor = GetDTOCadastro(fornecedor);

                if (fornecedor.Codigo == 0)
                {
                    fornecedorDAO.Create(fornecedor);
                }
                else
                {
                    //Envia o cliente para a camada de service que sera responsavel pela atualização do cliente
                    fornecedorDAO.Update(fornecedor);
                }
  
            }
            //Captura uma exceção caso o usuario digite algo que esteja incorreto
            catch (FormatException)
            {
                MessageBox.Show("Erro: Dados incorretos");
                LimparCamposGeral();
            }

            //Comandos abaixos apenas para resetar o layout
            DesabilitarCamposGeral();

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;

            btnListar.Enabled = true;
            btnPesquisar.Enabled = true;
            btnAdicionar.Enabled = true;
            txtPesquisarFornecedor.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir este cliente?", "Sim", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                fornecedorDAO.Delete(fornecedor);

                //Comandos abaixos apenas para resetar o layout
                DesabilitarCamposGeral();

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                btnExcluir.Enabled = false;

                btnListar.Enabled = true;
                btnAlterar.Enabled = true;
                btnPesquisar.Enabled = true;

                LimparCamposGeral();

                //Limpa todas as rows
                dataGridViewClientes.Rows.Clear();
            }

        }


        //Evento é disparado sempre que eu escolher uma linha da gride
        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                //Pega o id do cliente da linha do datagrid que estiver selecionado
                int id = int.Parse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString());

                //Pesquisa o cliente selecionado
                fornecedor = fornecedorDAO.Read(id);

                //Envia o cliente para setar a view
                SetDTO(fornecedor);
            }
            catch (Exception ex)
            {
                //Caso não encontre nenhum cliente limpe os campos
                LimparCamposGeral();
            }

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtPesquisarFornecedor.Enabled = false;
            btnPesquisar.Enabled = false;
            btnListar.Enabled = false;
            btnAdicionar.Enabled = false;

            btnCancelar.Enabled = true;
            btnSalvar.Enabled = true;

            AbilitarCamposGeral();
        }

        //Metodos auxiliares
        private void AbilitarCamposGeral()
        {
            txtCnpj.Enabled = true;
            txtTelefone.Enabled = true;
            txtCidade.Enabled = true;
            txtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtEmail.Enabled = true;
            txtNumero.Enabled = true;
            txtEstado.Enabled = true;
            txtNome.Enabled = true;
        }

        private void DesabilitarCamposGeral()
        {
            txtCnpj.Enabled = false;
            txtTelefone.Enabled = false;
            txtCidade.Enabled = false;
            txtCep.Enabled = false;
            txtEndereco.Enabled = false;
            txtEmail.Enabled = false;
            txtNumero.Enabled = false;
            txtEstado.Enabled = false;
            txtNome.Enabled = false;
        }

        private void LimparCamposGeral()
        {
            txtCnpj.Clear();
            txtTelefone.Clear();
            txtCidade.Clear();
            txtCep.Clear();
            txtEndereco.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtEstado.Clear();
            txtNome.Clear();
        }

        private void AtualizarGrid(List<Fornecedor> clientes)
        {
            //Limpa todas as rows
            dataGridViewClientes.Rows.Clear();

            //Percorre a lista de clientes
            foreach (Fornecedor cli in clientes)
            {
                //Adiciona os dados do cliente na row
                dataGridViewClientes.Rows.Add(cli.Codigo, cli.Nome, cli.Cnpj);
            }
        }

        /* Metodos auxiliares (DTO). 
         * Coleta os dados da visão e passa os dados para o modelo */
        private Fornecedor GetDTOCadastro(Fornecedor fornecedor)
        {
            fornecedor.Nome = txtNome.Text == "" ? null : txtNome.Text;
            fornecedor.Cnpj = txtCnpj.Text == "" ? null : txtCnpj.Text;
            fornecedor.Email = txtEmail.Text == "" ? null : txtEmail.Text;
            fornecedor.Telefone = txtTelefone.Text == "" ? null : txtTelefone.Text;

            fornecedor.Rua = txtEndereco.Text == "" ? null : txtEndereco.Text;
            fornecedor.Numero = int.Parse(txtNumero.Text);
            fornecedor.Cep = txtCep.Text == "" ? null : txtCep.Text;
            fornecedor.Cidade = txtCidade.Text == "" ? null : txtCidade.Text;
            fornecedor.Estado = txtEstado.Text == "" ? null : txtEstado.Text;

            return fornecedor;
        }

        /* Metodos auxiliares (DTO). 
         * Coloca as informações do modelo na visão */
        private void SetDTO(Fornecedor cliente)
        {

            txtNome.Text = cliente.Nome;
            txtCnpj.Text = cliente.Cnpj;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtEndereco.Text = cliente.Rua;
            txtNumero.Text = cliente.Numero == 0 ? "" : cliente.Numero.ToString();
            txtCep.Text = cliente.Cep;
            txtCidade.Text = cliente.Cidade;
            txtEstado.Text = cliente.Estado;
            
            
        }


    }//Fim da classe
}//Fim da namespace
