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
    class FornecedorDAO
    {

        /* Salva uma fornecedor no Banco de Dados */
        public bool Create(Fornecedor fornecedor)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Fornecedor (cnpj, nome, email, telefone, rua, numero, cep, cidade, estado) " +
                           "VALUES (@Cnpj, @Nome, @Email, @Telefone, @Rua, @Numero, @Cep, @Cidade, @Estado);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
            command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
            command.Parameters.AddWithValue("@Email", fornecedor.Email);
            command.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
            command.Parameters.AddWithValue("@Rua", fornecedor.Rua);
            command.Parameters.AddWithValue("@Numero", fornecedor.Numero);
            command.Parameters.AddWithValue("@Cep", fornecedor.Cep);
            command.Parameters.AddWithValue("@Cidade", fornecedor.Cidade);
            command.Parameters.AddWithValue("@Estado", fornecedor.Estado);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Executa o comando SQL */
                command.ExecuteNonQuery();

                state = true; /* Comando foi executado */
            }
            catch(MySqlException exception)
            {
                /* Exceção por violar algum UNIQUE */
                if(exception.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    /* UNIQUE(cnpj) */
                    if (exception.Message.ToString().Contains("un_fornecedor_cnpj"))
                        MessageBox.Show("Este CNPJ já está cadastrado.", "CNPJ já Cadastrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    /* UNIQUE(nome) */
                    if (exception.Message.ToString().Contains("un_fornecedor_nome"))
                        MessageBox.Show("Este Nome de Fornecedor já está cadastrado.",
                            "Nome já Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    /* UNIQUE(email) */
                    if (exception.Message.ToString().Contains("un_fornecedor_email"))
                        MessageBox.Show("Este email já está cadastrado.", "Email já Cadastrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return state;
        }

        /* Lê um fornecedor no Banco de Dados. Retorna null se não achar */
        public Fornecedor Read(int codigo)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Fornecedor fornecedor = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Fornecedor WHERE codigo = @Codigo;";

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
                if (dataReader.Read())
                {
                    fornecedor = new Fornecedor();
                    fornecedor.Codigo = dataReader.GetInt32(0);
                    fornecedor.Cnpj = dataReader.GetString(1);
                    fornecedor.Nome = dataReader.GetString(2);
                    fornecedor.Email = dataReader.GetString(3);
                    fornecedor.Telefone = dataReader.GetString(4);
                    fornecedor.Rua = dataReader.GetString(5);
                    fornecedor.Numero = dataReader.GetInt32(6);
                    fornecedor.Cep = dataReader.GetString(7);
                    fornecedor.Cidade = dataReader.GetString(8);
                    fornecedor.Estado = dataReader.GetString(9);
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
            return fornecedor;
        }


        /* Atualiza um fornecedor no Banco de Dados */
        public bool Update(Fornecedor fornecedor)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "UPDATE Fornecedor SET cnpj = @Cnpj, " +
                           "nome = @Nome, email = @Email, telefone = @Telefone, " +
                           "rua = @Rua, numero = @Numero, cep = @Cep, " +
                           "cidade = @Cidade, estado = @Estado " +
                           "WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros */
            command.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
            command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
            command.Parameters.AddWithValue("@Email", fornecedor.Email);
            command.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
            command.Parameters.AddWithValue("@Rua", fornecedor.Rua);
            command.Parameters.AddWithValue("@Numero", fornecedor.Numero);
            command.Parameters.AddWithValue("@Cep", fornecedor.Cep);
            command.Parameters.AddWithValue("@Cidade", fornecedor.Cidade);
            command.Parameters.AddWithValue("@Estado", fornecedor.Estado);
            command.Parameters.AddWithValue("@Codigo", fornecedor.Codigo);

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
                /* Exceção por violar algum UNIQUE */
                if (exception.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    /* UNIQUE(cnpj) */
                    if (exception.Message.ToString().Contains("un_fornecedor_cnpj"))
                        MessageBox.Show("Este CNPJ já está cadastrado.", "CNPJ já Cadastrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    /* UNIQUE(nome) */
                    if (exception.Message.ToString().Contains("un_fornecedor_nome"))
                        MessageBox.Show("Este Nome de Fornecedor já está cadastrado.",
                            "Nome já Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    /* UNIQUE(email) */
                    if (exception.Message.ToString().Contains("un_fornecedor_email"))
                        MessageBox.Show("Este email já está cadastrado.", "Email já Cadastrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return state;
        }

        public Fornecedor Read(string nome)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Fornecedor fornecedor = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Fornecedor WHERE lower(nome) LIKE @Nome;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adição de parametros ja com valor */
            command.Parameters.AddWithValue("@Nome", nome + "%");

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
                    fornecedor = new Fornecedor();
                    fornecedor.Codigo = dataReader.GetInt32(0);
                    fornecedor.Cnpj = dataReader.GetString(1);
                    fornecedor.Nome = dataReader.GetString(2);
                    fornecedor.Email = dataReader.GetString(3);
                    fornecedor.Telefone = dataReader.GetString(4);
                    fornecedor.Rua = dataReader.GetString(5);
                    fornecedor.Numero = dataReader.GetInt32(6);
                    fornecedor.Cep = dataReader.GetString(7);
                    fornecedor.Cidade = dataReader.GetString(8);
                    fornecedor.Estado = dataReader.GetString(9);
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
            return fornecedor;
        }

        public List<Fornecedor> ListAll()
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */

            Database mercadoBD = Database.GetInstance();
            MySqlConnection connection = mercadoBD.GetConnection();

            /* Lista de produtos */
            List<Fornecedor> listaFornecedor = new List<Fornecedor>();

            /* Preenchido com as informações do Banco de Dados */
            Fornecedor fornecedor;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Fornecedor";

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
                while (dataReader.Read())
                {
                    fornecedor = new Fornecedor();
                    fornecedor.Codigo = dataReader.GetInt32(0);
                    fornecedor.Cnpj = dataReader.GetString(1);
                    fornecedor.Nome = dataReader.GetString(2);
                    fornecedor.Email = dataReader.GetString(3);
                    fornecedor.Telefone = dataReader.GetString(4);
                    fornecedor.Rua = dataReader.GetString(5);
                    fornecedor.Numero = dataReader.GetInt32(6);
                    fornecedor.Cep = dataReader.GetString(7);
                    fornecedor.Cidade = dataReader.GetString(8);
                    fornecedor.Estado = dataReader.GetString(9);

                    listaFornecedor.Add(fornecedor); /* Adiciona na lista */
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
            return listaFornecedor; /* Retorna a lista */
        }

        

        public bool Delete(Fornecedor fornecedor)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "DELETE FROM Fornecedor WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Codigo", fornecedor.Codigo);

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
                /* Fornecedor está atrelado a produtos */
                if (exception.Number == (int)MySqlErrorCode.RowIsReferenced2)
                {
                    MessageBox.Show("Este fornecedor não pode ser excluído, pois está atrelado " +
                        "a produtos cadastrados", "Fornecedor não pode ser excluído",
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
    }
}
