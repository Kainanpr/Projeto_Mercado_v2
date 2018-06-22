using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using ProjetoMercado.model.dao;
using ProjetoMercado.model.domain;

namespace ProjetoMercado.model.connection
{
    class Database
    {
        /* Atributos */
        private static MySqlConnection connection; /* Conexão com o Banco de Dados */
        private static Database instance; /* Instância do objeto Database */
        private string connectionString = /* String de configuração da Conexão */
            "Server=localhost; database=mercado; Uid=root; Pwd=";

        /* Construtor privado */
        private Database()
        {
            try
            {
                connection = new MySqlConnection(connectionString); /* Configura a conexão */
                connection.Open(); /* Abre a conexão para teste */
            }
            catch (MySqlException exception)
            {
                if (exception.Number == (int)MySqlErrorCode.None)
                {
                    CreateDB(); /* Chama o método para criar o Bando de Dados */
                }
                else
                {
                    /* Se ocorrer algum erro mostra uma caixa de texto com o erro */
                    MessageBox.Show(exception.Message.ToString(), "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                connection.Close(); /* Fecha a conexão */
            }
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
                MessageBox.Show(exception.ToString(), "Erro", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
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
                /* Troca a string de conexão */
                connection.ConnectionString = "Server=localhost; Uid=root; Pwd=";

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

                /* SQL para criar a tabela Usuário */
                query = "CREATE TABLE IF NOT EXISTS Usuario (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "nome VARCHAR(64) NOT NULL," +
                    "login VARCHAR(64) NOT NULL," +
                    "senha VARCHAR(64) NOT NULL," +
                    "CONSTRAINT pk_usuario PRIMARY KEY(codigo)," +
                    "CONSTRAINT un_usuario_nome UNIQUE(nome)," +
                    "CONSTRAINT un_usuario_login UNIQUE(login));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela categoria */
                query = "CREATE TABLE IF NOT EXISTS Categoria (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "descricao VARCHAR(64) NOT NULL," +
                    "CONSTRAINT pk_categoria PRIMARY KEY(codigo)," +
                    "CONSTRAINT un_categoria_descricao UNIQUE(descricao));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Fornecedor */
                query = "CREATE TABLE IF NOT EXISTS Fornecedor (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "cnpj VARCHAR(64) NOT NULL," +
                    "nome VARCHAR(64) NOT NULL," +
                    "email VARCHAR(64) NOT NULL," +
                    "telefone VARCHAR(64) NOT NULL," +
                    "rua VARCHAR(64) NOT NULL," +
                    "numero INTEGER NOT NULL," +
                    "cep VARCHAR(64) NOT NULL," +
                    "cidade VARCHAR(64) NOT NULL," +
                    "estado VARCHAR(64) NOT NULL," +
                    "CONSTRAINT pk_fornecedor PRIMARY KEY(codigo), " +
                    "CONSTRAINT un_fornecedor_cnpj UNIQUE(cnpj)," +
                    "CONSTRAINT un_fornecedor_nome UNIQUE(nome)," +
                    "CONSTRAINT un_fornecedor_email UNIQUE(email));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Produto */
                query = "CREATE TABLE IF NOT EXISTS Produto (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "preco DECIMAL(10,2) NOT NULL," +
                    "cod_barras VARCHAR(64) NOT NULL," +
                    "descricao VARCHAR(64) NOT NULL," +
                    "cod_categoria INTEGER NOT NULL," +
                    "qnt_min_estoque INTEGER NOT NULL," +
                    "cod_fornecedor INTEGER NOT NULL, " +
                    "CONSTRAINT pk_produto PRIMARY KEY(codigo)," +
                    "CONSTRAINT un_produto_cod_barras UNIQUE(cod_barras)," +
                    "CONSTRAINT un_produto_descricao UNIQUE(descricao)," +
                    "CONSTRAINT fk_prod_categoria FOREIGN KEY(cod_categoria) " +
                    "REFERENCES Categoria(codigo), " +
                    "CONSTRAINT fk_prod_fornecedor FOREIGN KEY(cod_fornecedor) " +
                    "REFERENCES Fornecedor(codigo));";

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
                    "preco_unitario DECIMAL(10,2) NOT NULL," +
                    "CONSTRAINT pk_item PRIMARY KEY(codigo)," +
                    "CONSTRAINT fk_item_venda FOREIGN KEY(cod_venda) " +
                    "REFERENCES Venda (codigo)," +
                    "CONSTRAINT fk_item_produto FOREIGN KEY(cod_produto) " +
                    "REFERENCES Produto(codigo));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* SQL para criar a tabela Produto_Estoque */
                query = "CREATE TABLE IF NOT EXISTS Produto_Estoque (" +
                    "codigo INTEGER AUTO_INCREMENT," +
                    "cod_produto INTEGER NOT NULL," +
                    "quantidade INTEGER NOT NULL," +
                    "CONSTRAINT pk_produto_estoque PRIMARY KEY(codigo)," +
                    "CONSTRAINT fk_produto_estoque FOREIGN KEY(cod_produto) " +
                    "REFERENCES Produto(codigo));";

                /* Executa o comando MySql */
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                /* Chama o metodo para cadastrar alguns registros para teste e demonstração */
                PreencherBDTeste();
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
        }

        /* Metodo para cadastrar registros no banco de dados para teste e demonstração */
        private void PreencherBDTeste()
        {

            //Cadastro de categorias               
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            Categoria bebida = new Categoria();
            bebida.Codigo = 1;
            bebida.Descricao = "Bebida"; 
            categoriaDAO.Create(bebida);

            Categoria limpeza = new Categoria();
            limpeza.Codigo = 2;
            limpeza.Descricao = "Limpeza";
            categoriaDAO.Create(limpeza);

            Categoria comida = new Categoria();
            comida.Codigo = 3;
            comida.Descricao = "Comida";
            categoriaDAO.Create(comida);

            Categoria brinquedo = new Categoria();
            brinquedo.Codigo = 4;
            brinquedo.Descricao = "Brinquedo";
            categoriaDAO.Create(brinquedo);

            //Cadastro de fornecedores       
            FornecedorDAO fornecedorDAO = new FornecedorDAO();

            Fornecedor fornecedor1 = new Fornecedor();
            fornecedor1.Codigo = 1;
            fornecedor1.Cnpj = "76.245.133/0001-90";
            fornecedor1.Nome = "Tem de tudo";
            fornecedor1.Email = "temdetudo@gmail.com";
            fornecedor1.Telefone = "(16)3312-1244";
            fornecedor1.Rua = "Rua Gertrudes";
            fornecedor1.Numero = 123;
            fornecedor1.Cep = "1233450-600";
            fornecedor1.Cidade = "São Carlos";
            fornecedor1.Estado = "SP";
            fornecedorDAO.Create(fornecedor1);

            Fornecedor fornecedor2 = new Fornecedor();
            fornecedor2.Codigo = 2;
            fornecedor2.Cnpj = "67.472.648/0001-31";
            fornecedor2.Nome = "Casa de carnes";
            fornecedor2.Email = "casadecarnes@gmail.com";
            fornecedor2.Telefone = "(16)3345-6677";
            fornecedor2.Rua = "Rua Almeida";
            fornecedor2.Numero = 333;
            fornecedor2.Cep = "12570-552";
            fornecedor2.Cidade = "São Carlos";
            fornecedor2.Estado = "SP";
            fornecedorDAO.Create(fornecedor2);

            Fornecedor fornecedor3 = new Fornecedor();
            fornecedor3.Codigo = 3;
            fornecedor3.Cnpj = "66.773.984/0001-51";
            fornecedor3.Nome = "Sorvetes Mil Grau";
            fornecedor3.Email = "milgrau@hotmail.com";
            fornecedor3.Telefone = "(16)99143-1212";
            fornecedor3.Rua = "Rua Mello Alves";
            fornecedor3.Numero = 1343;
            fornecedor3.Cep = "15870-698";
            fornecedor3.Cidade = "Araraquara";
            fornecedor3.Estado = "SP";
            fornecedorDAO.Create(fornecedor3);

            Fornecedor fornecedor4 = new Fornecedor();
            fornecedor4.Codigo = 4;
            fornecedor4.Cnpj = "36.583.761/0001-60";
            fornecedor4.Nome = "24 Horas";
            fornecedor4.Email = "horas24@hotmail.com";
            fornecedor4.Telefone = "(16)99344-2332";
            fornecedor4.Rua = "Rua Bento Carlos";
            fornecedor4.Numero = 1111;
            fornecedor4.Cep = "14784-114";
            fornecedor4.Cidade = "Ibaté";
            fornecedor4.Estado = "SP";
            fornecedorDAO.Create(fornecedor4);

            Fornecedor fornecedor5 = new Fornecedor();
            fornecedor5.Codigo = 5;
            fornecedor5.Cnpj = "58.683.153/0001-60";
            fornecedor5.Nome = "Bebidas LTDA";
            fornecedor5.Email = "bebidasLTDA@hotmail.com";
            fornecedor5.Telefone = "(16)3375-9099";
            fornecedor5.Rua = "Rua Alexandrina";
            fornecedor5.Numero = 234;
            fornecedor5.Cep = "14781-101";
            fornecedor5.Cidade = "São Carlos";
            fornecedor5.Estado = "SP";
            fornecedorDAO.Create(fornecedor5);

            Fornecedor fornecedor6 = new Fornecedor();
            fornecedor6.Codigo = 6;
            fornecedor6.Cnpj = "99.278.153/0001-62";
            fornecedor6.Nome = "Brinquedos LTDA";
            fornecedor6.Email = "brinquedosLTDA@hotmail.com";
            fornecedor6.Telefone = "(16)99455-2332";
            fornecedor6.Rua = "Rua 7 de Agosto";
            fornecedor6.Numero = 234;
            fornecedor6.Cep = "11568-998";
            fornecedor6.Cidade = "São Carlos";
            fornecedor6.Estado = "SP";
            fornecedorDAO.Create(fornecedor6);

            //Cadastro de produtos  
            ProdutoDAO produtoDAO = new ProdutoDAO();

            Produto produto1 = new Produto();
            produto1.Preco = 1.99m;
            produto1.CodigoBarras = "1111";
            produto1.Descricao = "Sabonete";
            produto1.Categoria = limpeza;
            produto1.QntMinEstoque = 50;
            produto1.Fornecedor = fornecedor1;
            produtoDAO.Create(produto1);

            Produto produto2 = new Produto();
            produto2.Preco = 2.99m;
            produto2.CodigoBarras = "1112";
            produto2.Descricao = "Papel Toalha";
            produto2.Categoria = limpeza;
            produto2.QntMinEstoque = 25;
            produto2.Fornecedor = fornecedor1;
            produtoDAO.Create(produto2);

            Produto produto3 = new Produto();
            produto3.Preco = 41.44m;
            produto3.CodigoBarras = "1113";
            produto3.Descricao = "Limpa Tecido Automotivo";
            produto3.Categoria = limpeza;
            produto3.QntMinEstoque = 20;
            produto3.Fornecedor = fornecedor1;
            produtoDAO.Create(produto3);

            Produto produto4 = new Produto();
            produto4.Preco = 8.50m;
            produto4.CodigoBarras = "2221";
            produto4.Descricao = "Coca Cola 2L";
            produto4.Categoria = bebida;
            produto4.QntMinEstoque = 60;
            produto4.Fornecedor = fornecedor5;
            produtoDAO.Create(produto4);

            Produto produto5 = new Produto();
            produto5.Preco = 12.10m;
            produto5.CodigoBarras = "2222";
            produto5.Descricao = "Cerveja Brahma 300ml";
            produto5.Categoria = bebida;
            produto5.QntMinEstoque = 55;
            produto5.Fornecedor = fornecedor5;
            produtoDAO.Create(produto5);

            Produto produto6 = new Produto();
            produto6.Preco = 6.50m;
            produto6.CodigoBarras = "2223";
            produto6.Descricao = "Fanta Laranja 2L";
            produto6.Categoria = bebida;
            produto6.QntMinEstoque = 75;
            produto6.Fornecedor = fornecedor4;
            produtoDAO.Create(produto6);

            Produto produto7 = new Produto();
            produto7.Preco = 1.99m;
            produto7.CodigoBarras = "3331";
            produto7.Descricao = "Miojo NISSIN";
            produto7.Categoria = comida;
            produto7.QntMinEstoque = 55;
            produto7.Fornecedor = fornecedor1;
            produtoDAO.Create(produto7);

            Produto produto8 = new Produto();
            produto8.Preco = 19.25m;
            produto8.CodigoBarras = "3332";
            produto8.Descricao = "Sorvete KIBON 2L";
            produto8.Categoria = comida;
            produto8.QntMinEstoque = 78;
            produto8.Fornecedor = fornecedor3;
            produtoDAO.Create(produto8);

            Produto produto9 = new Produto();
            produto9.Preco = 10.25m;
            produto9.CodigoBarras = "3333";
            produto9.Descricao = "Arroz Integral Vapza";
            produto9.Categoria = comida;
            produto9.QntMinEstoque = 110;
            produto9.Fornecedor = fornecedor1;
            produtoDAO.Create(produto9);

            Produto produto10 = new Produto();
            produto10.Preco = 49.99m;
            produto10.CodigoBarras = "4441";
            produto10.Descricao = "Bola Futebol Nike";
            produto10.Categoria = brinquedo;
            produto10.QntMinEstoque = 40;
            produto10.Fornecedor = fornecedor6;
            produtoDAO.Create(produto10);

            Produto produto11 = new Produto();
            produto11.Preco = 89.90m;
            produto11.CodigoBarras = "4442";
            produto11.Descricao = "Boneca Barbie";
            produto11.Categoria = brinquedo;
            produto11.QntMinEstoque = 35;
            produto11.Fornecedor = fornecedor6;
            produtoDAO.Create(produto11);

        }
    }
}
