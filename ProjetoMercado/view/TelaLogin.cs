﻿using System;
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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            new TelaCadastroUsuario().ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            /* Objeto UsuarioDAO para acessar o Banco de Dados */
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            /* Objeto Usuario para receber os Dados */
            Usuario usuario = usuarioDAO.Read(txtLogin.Text);

            /* Verifica se o Login está cadastrado no Banco de Dados */
            if(usuario != null)
            {
                if(usuario.Senha == txtSenha.Text)
                {
                    /* Esconde o form de login */
                    this.Hide();

                    /* Cria o form TelaInicial */
                    new TelaInicial(usuario).ShowDialog();

                    /* Após fechar a tela inicial, fecha a janela de login encerrando o programa */
                    this.Close();
                }
                else
                {
                    /* Mostra uma mensagem informando que a senha está incorreta */
                    MessageBox.Show("A Senha informada está incorreta", "Senha Incorreta",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /* Limpa o text box senha */
                    txtSenha.Text = "";
                }
            }
            else
            {
                /* Mostra uma mensagem informando que o login não está cadastrado */
                MessageBox.Show("Login informado não cadastrado", "Login Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* Limpa o text box login e senha */
                txtLogin.Text = "";
                txtSenha.Text = "";
            }
        }

    }
}
