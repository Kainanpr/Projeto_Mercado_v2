using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjetoMercado.model.connection;
using ProjetoMercado.model.domain;


namespace ProjetoMercado.model.dao
{
    class ProdutoEstoqueDAO
    {
        /* Cria um ProdutoEstoque no BD */
        public bool Create(ProdutoEstoque produtoEstoque)
        {
            bool state = false; /* Indica a execução do comando */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Produto_Estoque (cod_produto, quantidade) " +
                "VALUES (@Cod_produto, @Quantidade);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Cod_produto", produtoEstoque.Produto.Codigo);
            command.Parameters.AddWithValue("@Quantidade", produtoEstoque.QuantidadeEstoque);

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
                MessageBox.Show(exception.Message.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /* Atualiza um ProdutoEstoque no BD */
        public bool Update(ProdutoEstoque produtoEstoque)
        {
            bool state = false; /* Indica se o comando foi executado com sucesso */

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* String que contém o SQL que será executado */
            string query = "UPDATE Produto_Estoque SET quantidade = @Quantidade " +
                "WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Quantidade", produtoEstoque.QuantidadeEstoque);
            command.Parameters.AddWithValue("@Codigo", produtoEstoque.Codigo);

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
                MessageBox.Show(exception.Message.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /* Lê um Produto_Estoque no BD */
        public ProdutoEstoque Read(int codigoProduto)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de ProdutoEstoque para receber as informações do Banco de Dados */
            ProdutoEstoque produtoEstoque = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT pe.*, p.*, c.*, f.* FROM Produto_Estoque pe " +
                "JOIN Produto p ON pe.cod_produto = p.codigo " +
                "JOIN Categoria c ON p.cod_categoria = c.codigo " +
                "JOIN Fornecedor f ON p.cod_fornecedor = f.codigo " +
                "WHERE pe.cod_produto = @Cod_produto;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Cod_produto", codigoProduto);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto ProdutoEstoque */
                if (dataReader.Read())
                {
                    produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.Produto = new Produto();
                    produtoEstoque.Produto.Categoria = new Categoria();
                    produtoEstoque.Produto.Fornecedor = new Fornecedor();

                    produtoEstoque.Codigo = dataReader.GetInt32(0);
                    produtoEstoque.QuantidadeEstoque = dataReader.GetInt32(2);

                    produtoEstoque.Produto.Codigo = dataReader.GetInt32(3);
                    produtoEstoque.Produto.Preco = dataReader.GetDecimal(4);
                    produtoEstoque.Produto.CodigoBarras = dataReader.GetString(5);
                    produtoEstoque.Produto.Descricao = dataReader.GetString(6);
                    produtoEstoque.Produto.QntMinEstoque = dataReader.GetInt32(8);

                    produtoEstoque.Produto.Categoria.Codigo = dataReader.GetInt32(10);
                    produtoEstoque.Produto.Categoria.Descricao = dataReader.GetString(11);                    
                }
                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (MySqlException exception)
            {
                /* Se ocorrer alguma exceção mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.Message.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return produtoEstoque;
        }

        /* Lista todos Produto_Estoque no BD */
        public List<ProdutoEstoque> ListAll()
        {
            List<ProdutoEstoque> lista = new List<ProdutoEstoque>();

            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Objeto de ProdutoEstoque para receber as informações do Banco de Dados */
            ProdutoEstoque produtoEstoque = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT pe.*, p.*, c.*, f.* FROM Produto_Estoque pe " +
                "JOIN Produto p ON pe.cod_produto = p.codigo " +
                "JOIN Categoria c ON p.cod_categoria = c.codigo " +
                "JOIN Fornecedor f ON p.cod_fornecedor = f.codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto ProdutoEstoque */
                while (dataReader.Read())
                {
                    produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.Produto = new Produto();
                    produtoEstoque.Produto.Categoria = new Categoria();
                    produtoEstoque.Produto.Fornecedor = new Fornecedor();

                    produtoEstoque.Codigo = dataReader.GetInt32(0);
                    produtoEstoque.QuantidadeEstoque = dataReader.GetInt32(2);

                    produtoEstoque.Produto.Codigo = dataReader.GetInt32(3);
                    produtoEstoque.Produto.Descricao = dataReader.GetString(6);
                    produtoEstoque.Produto.QntMinEstoque = dataReader.GetInt32(8);

                    lista.Add(produtoEstoque);
                }
                /* Fecha o dataReader */
                dataReader.Close();
            }
            catch (MySqlException exception)
            {
                /* Se ocorrer alguma exceção mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.Message.ToString(), "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return lista;
        }

    }
}
