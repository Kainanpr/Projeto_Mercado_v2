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
    class CategoriaDAO
    {
        /* Salva uma categoria no Banco de Dados */
        public bool Create(Categoria categoria)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Categoria (descricao) VALUES (@Descricao);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Executa o comando SQL */
                command.ExecuteNonQuery();

                state = true; /* Comando foi executado */
            }
            catch (MySqlException exception)
            {
                /* Exceção por violar o UNIQUE(descrição) */
                if (exception.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                    MessageBox.Show("Essa categoria já está cadastrada.", "Categoria já cadastrada",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /* Lê uma categoria no Banco de Dados. Retorna null se não achar */
        public Categoria Read(int codigo)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Categoria categoria = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Categoria WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Codigo", codigo);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto categoria */
                if(dataReader.Read())
                {
                    categoria = new Categoria();
                    categoria.Codigo = dataReader.GetInt32(0);
                    categoria.Descricao = dataReader.GetString(1);
                }
                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (Exception exception)
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
            return categoria;
        }

        /* Lê uma categoria no Banco de Dados. Retorna null se não achar */
        public Categoria Read(string descricao)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Categoria categoria = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Categoria WHERE descricao = @Descricao;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Descricao", descricao);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto categoria */
                if (dataReader.Read())
                {
                    categoria = new Categoria();
                    categoria.Codigo = dataReader.GetInt32(0);
                    categoria.Descricao = dataReader.GetString(1);
                }
                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (Exception exception)
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
            return categoria;
        }

        /* Atualiza uma categoria no Banco de Dados */
        public bool Update(Categoria categoria)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "UPDATE Categoria SET descricao = @Descricao WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
            command.Parameters.AddWithValue("@Codigo", categoria.Codigo);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Executa o comando SQL */
                command.ExecuteNonQuery();

                state = true; /* Comando foi executado */
            }
            catch (MySqlException exception)
            {
                /* Exceção por violar o UNIQUE(descrição) */
                if (exception.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                    MessageBox.Show("Essa categoria já está cadastrada.", "Categoria já cadastrada",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /* Deleta uma categoria no Banco de Dados */
        public bool Delete(Categoria categoria)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "DELETE FROM Categoria WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Codigo", categoria.Codigo);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Executa o comando SQL */
                command.ExecuteNonQuery();

                state = true; /* Comando foi executado */
            }
            catch (MySqlException exception)
            {
                /* Categoria está atrelada a produtos */
                if (exception.Number == (int)MySqlErrorCode.RowIsReferenced2)
                {
                    MessageBox.Show("Esta categoria não pode ser excluída, pois está atrelada " +
                        "a produtos cadastrados", "Categoria não pode ser excluída",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Erro ao excluir",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /* Retorna uma lista com todas as categorias */
        public List<Categoria> ListAll()
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Lista de categoria */
            List<Categoria> listaCategorias = new List<Categoria>();

            /* Preenchido com as informações do Banco de Dados */
            Categoria categoria;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Categoria;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Lê todos os dados na tabela do Banco de Dados */
                while(dataReader.Read())
                {
                    categoria = new Categoria();
                    categoria.Codigo = dataReader.GetInt32(0);
                    categoria.Descricao = dataReader.GetString(1);

                    listaCategorias.Add(categoria); /* Adiciona na lista */
                }
                dataReader.Close();
            }
            catch (Exception exception)
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
            return listaCategorias; /* Retorna a lista */
        }
    }
}