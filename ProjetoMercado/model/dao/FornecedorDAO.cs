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
        public void Create(Fornecedor fornecedor)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Fornecedor (cnpj, nome, email, telefone, rua, numero, cep, cidade, estado) " +
                           "VALUES (@Cnpj, @Nome, @Email, @Telefone, @Rua, @Numero, @Cep, @Cidade, @Estado);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

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

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
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
        public void Update(Fornecedor fornecedor)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "UPDATE Fornecedor SET cnpj = @Cnpj, " +
                           "nome = @Nome, email = @Email, telefone = @Telefone, " +
                           "rua = @Rua, numero = @Numero, cep = @Cep, " +
                           "cidade = @Cidade, estado = @Estado " +
                           "WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

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

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        public List<Fornecedor> FindByName(string nome)
        {
            return null;
        }

        public Fornecedor FindByCnpj(string cnpj)
        {
            return null;
        }

        public List<Fornecedor> ListAll()
        {
            return null;
        }

        

        public void Delete(Fornecedor fornecedor)
        {
             
        }
        
    }
}
