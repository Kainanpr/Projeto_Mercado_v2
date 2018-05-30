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
    class ProdutoDAO
    {
        /* Salva um Produto no Banco de Dados */
        public void Create(Produto produto)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Produto (preco, cod_barras, descricao, " +
                "cod_categoria, qnt_min_estoque, cod_fornecedor) VALUE (@Preco, @Cod_barras, " +
                "@Descricao, @Cod_categoria, @Qnt_min_estoque, @Cod_fornecedor);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Preco", produto.Preco);
            command.Parameters.AddWithValue("@Cod_barras", produto.CodigoBarras);
            command.Parameters.AddWithValue("@Descricao", produto.Descricao);
            command.Parameters.AddWithValue("@Cod_Categoria", produto.Categoria.Codigo);
            command.Parameters.AddWithValue("@Qnt_min_estoque", produto.QntMinEstoque);
            command.Parameters.AddWithValue("@Cod_fornecedor", produto.Fornecedor.Codigo);

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        /* Lê um Produto no Banco de Dados. Retorna null se não achar */
        public Produto Read(int codigo)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            Database mercadoBD = Database.GetInstance(); 
            MySqlConnection connection = mercadoBD.GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Produto produto = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT p.*, c.descricao, f.nome FROM Produto p JOIN Categoria c " +
                "ON p.cod_categoria = c.codigo JOIN Fornecedor f ON p.cod_fornecedor = f.codigo WHERE p.codigo = @Codigo;";

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

                /* Verifica se troxe informações do banco e coloca no objeto produto */
                if (dataReader.Read())
                {
                    produto = new Produto();
                    produto.Categoria = new Categoria();
                    produto.Fornecedor = new Fornecedor();
                    produto.Codigo = dataReader.GetInt32(0);
                    produto.Preco = dataReader.GetDecimal(1);
                    produto.CodigoBarras = dataReader.GetString(2);
                    produto.Descricao = dataReader.GetString(3);
                    produto.Categoria.Codigo = dataReader.GetInt32(4);
                    produto.QntMinEstoque = dataReader.GetInt32(5);
                    produto.Fornecedor.Codigo = dataReader.GetInt32(6);
                    produto.Categoria.Descricao = dataReader.GetString(7);
                    produto.Fornecedor.Nome = dataReader.GetString(8);
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
            return produto;
        }

        /* Lê um Produto no Banco de Dados pelo seu código de barras. Retorna null se não achar */
        public Produto Read(long codigoBarras)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            Database mercadoBD = Database.GetInstance();
            MySqlConnection connection = mercadoBD.GetConnection();

            /* Objeto de Categoria para receber as informações do Banco de Dados */
            Produto produto = null;

            /* String que contém o SQL que será executado */
            string query = "SELECT p.*, c.descricao, f.nome FROM Produto p JOIN Categoria c " +
                "ON p.cod_categoria = c.codigo JOIN Fornecedor f ON p.cod_fornecedor = f.codigo WHERE p.cod_barras = @CodigoBarras;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@CodigoBarras", codigoBarras);

            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pela leitura do Banco de Dados */
                MySqlDataReader dataReader = command.ExecuteReader();

                /* Verifica se troxe informações do banco e coloca no objeto produto */
                if (dataReader.Read())
                {
                    produto = new Produto();
                    produto.Categoria = new Categoria();
                    produto.Fornecedor = new Fornecedor();
                    produto.Codigo = dataReader.GetInt32(0);
                    produto.Preco = dataReader.GetDecimal(1);
                    produto.CodigoBarras = dataReader.GetString(2);
                    produto.Descricao = dataReader.GetString(3);
                    produto.Categoria.Codigo = dataReader.GetInt32(4);
                    produto.QntMinEstoque = dataReader.GetInt32(5);
                    produto.Fornecedor.Codigo = dataReader.GetInt32(6);
                    produto.Categoria.Descricao = dataReader.GetString(7);
                    produto.Fornecedor.Nome = dataReader.GetString(8);
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
            return produto;
        }

        /* Atualiza um Produto no Banco de Dados */
        public void Update(Produto produto)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "UPDATE Produto SET preco = @Preco, cod_barras = @Cod_barras, " +
                "descricao = @Descricao, cod_categoria = @Cod_categoria, " +
                "qnt_min_estoque = @Qnt_min_estoque WHERE codigo = @codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

            /* Adiciona os parâmetros */
            command.Parameters.AddWithValue("@Preco", produto.Preco);
            command.Parameters.AddWithValue("@Cod_barras", produto.CodigoBarras);
            command.Parameters.AddWithValue("@Descricao", produto.Descricao);
            command.Parameters.AddWithValue("@Cod_categoria", produto.Categoria.Codigo);
            command.Parameters.AddWithValue("@Qnt_min_estoque", produto.QntMinEstoque);
            command.Parameters.AddWithValue("@Codigo", produto.Codigo);

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        /* Deleta uma categoria no Banco de Dados */
        public void Delete(Produto produto)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "DELETE FROM Produto WHERE codigo = @Codigo;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

            /* Adiciona o parâmetro */
            command.Parameters.AddWithValue("@Codigo", produto.Codigo);

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        /* Retorna uma lista com todos os Produtos */
        public List<Produto> ListAll()
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            Database mercadoBD = Database.GetInstance();
            MySqlConnection connection = mercadoBD.GetConnection();

            /* Lista de produtos */
            List<Produto> listaProdutos = new List<Produto>();

            /* Preenchido com as informações do Banco de Dados */
            Produto produto;

            /* String que contém o SQL que será executado */
            string query = "SELECT p.*, c.descricao, f.nome FROM Produto p JOIN Categoria c " +
                "ON p.cod_categoria = c.codigo JOIN Fornecedor f ON p.cod_fornecedor = f.codigo";

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
                    produto = new Produto();
                    produto.Categoria = new Categoria();
                    produto.Fornecedor = new Fornecedor();
                    produto.Codigo = dataReader.GetInt32(0);
                    produto.Preco = dataReader.GetDecimal(1);
                    produto.CodigoBarras = dataReader.GetString(2);
                    produto.Descricao = dataReader.GetString(3);
                    produto.Categoria.Codigo = dataReader.GetInt32(4);
                    produto.QntMinEstoque = dataReader.GetInt32(5);
                    produto.Fornecedor.Codigo = dataReader.GetInt32(6);
                    produto.Categoria.Descricao = dataReader.GetString(7);
                    produto.Fornecedor.Nome = dataReader.GetString(8);

                    listaProdutos.Add(produto); /* Adiciona na lista */
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
            return listaProdutos; /* Retorna a lista */
        }
    }
}
