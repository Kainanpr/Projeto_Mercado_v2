using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoMercado.model.connection
{
    class Database
    {
        /* Atributos */
        private static MySqlConnection connection; /* Conexão com o Banco de Dados */
        private static Database instance; /* Instância do objeto Database */
        private string connectionString = /* String de configuração da Conexão */
            "Server=localhost; Uid=root; Pwd=";

        /* Construtor privado */
        private Database()
        {
            connection = new MySqlConnection(connectionString); /* Configura a conexão */
            CreateDB(); /* Chama o método para criar o Bando de Dados */
        }

        /* Retorna a Instância */
        public static Database GetInstance()
        {
            /* Se não possui instância, chama o construtor. Por fim, retorna a instância */
            if (instance == null)
                instance = new Database();
            return instance;
        }

        /* Retorna a conexão com o Banco de Dados */
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        /* Executa um comando SQL que não retorna dados, e indica se foi possível executar */
        public bool ExecuteSQL(MySqlCommand command)
        {
            bool state = false;
            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Informa a conexão para o comando */
                command.Connection = connection;
                command.ExecuteNonQuery();

                /* Indica que executou */
                state = true;
            }
            catch (Exception exception)
            {
                /* Se ocorrer algum erro mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
            return state;
        }

        /* Cria o Banco de Dados */
        private void CreateDB()
        {
            try
            {
                /* Abre a conexão */
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                /* Responsável pelos comandos MySql */
                MySqlCommand command;

                /* String que contém o comando SQL que será executado */
                string query;

                /* SQL para criar o Banco de Dados mercado */
                query = "CREATE DATABASE IF NOT EXISTS mercado";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* Muda o banco de dados em uso */
                connection.ChangeDatabase("mercado");

                /* SQL para criar a tabela categoria */
                query = "CREATE TABLE IF NOT EXISTS Categoria (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "descricao VARCHAR(64) NOT NULL," +
                    "CONSTRAINT pk_categoria PRIMARY KEY(codigo)," +
                    "CONSTRAINT un_categoria UNIQUE(descricao));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Produto */
                query = "CREATE TABLE IF NOT EXISTS Produto (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "preco DECIMAL(10,2) NOT NULL," +
                    "cod_barras BIGINT NOT NULL," +
                    "descricao VARCHAR(64) NOT NULL," +
                    "cod_categoria INTEGER NOT NULL," +
                    "qnt_min_estoque INTEGER NOT NULL," +
                    "CONSTRAINT pk_produto PRIMARY KEY(codigo)," +
                    "CONSTRAINT un_produto UNIQUE(descricao)," +
                    "CONSTRAINT fk_prod_categoria FOREIGN KEY(cod_categoria) " +
                    "REFERENCES Categoria(codigo));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Venda */
                query = "CREATE TABLE IF NOT EXISTS Venda (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "data_hora DATETIME NOT NULL, " +
                    "valor_total DECIMAL(10,2)," +
                    "CONSTRAINT pk_venda PRIMARY KEY(codigo));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Item_Venda */
                query = "CREATE TABLE IF NOT EXISTS Item_Venda (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "cod_venda INTEGER NOT NULL," +
                    "cod_produto INTEGER NOT NULL," +
                    "quantidade INTEGER NOT NULL," +
                    "CONSTRAINT pk_item PRIMARY KEY(codigo)," +
                    "CONSTRAINT fk_item_venda FOREIGN KEY(cod_venda) " +
                    "REFERENCES Venda (codigo)," +
                    "CONSTRAINT fk_item_produto FOREIGN KEY(cod_produto) " +
                    "REFERENCES Produto(codigo));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                /* Se ocorrer alguma exceção mostra uma caixa de texto com o erro */
                MessageBox.Show(exception.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /* Fecha a conexão */
                connection.Close();
            }
        }
    }
}
