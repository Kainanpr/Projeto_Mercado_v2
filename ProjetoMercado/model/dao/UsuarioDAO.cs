using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjetoMercado.model.domain;
using ProjetoMercado.model.connection;

namespace ProjetoMercado.model.dao
{
    class UsuarioDAO
    {
        /* Verifica se existe pelo menos um usuário cadastrado no Banco de Dados */
        public bool ExisteUsuario()
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Variável para armazenar o resultado da consulta */
            int count = 0;

            /* String que contém o SQL que será executado */
            string query = "SELECT COUNT(*) FROM Usuario;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e armazena */
                if (dataReader.Read())
                {
                    count = dataReader.GetInt32(0);
                }

                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (MySqlException exception)
            {
                /* Se ocorrer alguma exceção mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }

            if (count > 0)
                return true;
            else
                return false;
        }

        /* Lê um Usuário no Banco de Dados pelo Login. Retorna null se não achar */
        public Usuario Read(string login)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de Usuário para receber as informações do Banco de Dados */
            Usuario usuario = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Usuario WHERE login = @Login;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Login", login);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto usuario */
                if (dataReader.Read())
                {
                    usuario = new Usuario();
                    usuario.Codigo = dataReader.GetInt32(0);
                    usuario.Nome = dataReader.GetString(1);
                    usuario.Login = dataReader.GetString(2);
                    usuario.Senha = dataReader.GetString(3);
                }
                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (MySqlException exception)
            {
                /* Se ocorrer alguma exceção mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return usuario;
        }

        /* Cria um Usuário no Banco de Dados */
        public bool Create(Usuario usuario)
        {
            bool state = false; /* Indica se  foi inserido com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Usuario (nome, login, senha) VALUES (@Nome, @Login, @Senha);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Login", usuario.Login);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Executa o comando SQL */
                command.ExecuteNonQuery();

                state = true;
            }
            catch(MySqlException exception)
            {
                
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return state;
        }
    }
}