using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoMercado.model.dao;
using ProjetoMercado.model.domain;

namespace ProjetoMercado.view
{
    public partial class TelaCadastroUsuario : Form
    {
        public TelaCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            /* Objeto DAO para acessar o Banco de Dados */
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            /* Verifica se os campos estão preenchidos */
            if (!txtNome.Text.Equals("") && !txtLogin.Text.Equals("") &&
                !txtSenha.Text.Equals(""))
            {
                /* Chama o método para inserir no Banco de Dados */
                if(usuarioDAO.Create(GetDTO()))
                {
                    /* Mensagem indicando que o usuário foi cadastrado */
                    MessageBox.Show("O usuário foi cadastrado.", "Usuário Cadastrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                /* Mensagem pedindo a inserção dos dados */
                MessageBox.Show("Há informações faltando. Por favor, preencha todos os campos.",
                    "Falta de informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Usuario GetDTO()
        {
            Usuario usuario = new Usuario();
            
            /* Preenche o objeto com os dados da tela */
            usuario.Nome = txtNome.Text;
            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;

            return usuario;
        }
    }
}