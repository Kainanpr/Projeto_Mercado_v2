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
    class ItemVendaDAO
    {
        /* Salva um ItemVenda no Banco de Dados */
        public void Create(ItemVenda itemVenda)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Item_Venda (cod_venda, cod_produto, quantidade, preco_unitario) " +
                "VALUES (@Cod_venda, @Cod_produto, @Quantidade, @Preco_unitario);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Cod_venda", itemVenda.Venda.Codigo);
            command.Parameters.AddWithValue("@Cod_produto", itemVenda.Produto.Codigo);
            command.Parameters.AddWithValue("@Quantidade", itemVenda.Quantidade);
            command.Parameters.AddWithValue("@Preco_unitario", itemVenda.PrecoUnitario);

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        /* Recupera uma lista contendo todos os itens de uma venda no Banco de Dados */
        public List<ItemVenda> ListAll(int codVenda)
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Lista de itens */
            List<ItemVenda> listaItens = new List<ItemVenda>();

            /* Preenchido com as informações do Banco de Dados */
            ItemVenda itemVenda;

            /* String que contém o SQL que será executado */
            string query = "SELECT iv.*, v.*, p.*, c.descricao FROM Item_Venda iv " +
                "JOIN Venda v ON iv.cod_venda = v.codigo " +
                "JOIN Produto p ON iv.cod_produto = p.codigo " +
                "JOIN Categoria c ON p.cod_categoria = c.codigo " +
                "WHERE iv.cod_venda = @Cod_venda;";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query, connection);

            /* Adiciona os parâmetros */
            command.Parameters.AddWithValue("@Cod_venda", codVenda);

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
                    itemVenda = new ItemVenda();
                    itemVenda.Produto = new Produto();
                    itemVenda.Produto.Categoria = new Categoria();
                    itemVenda.Venda = new Venda();
                    itemVenda.Codigo = dataReader.GetInt32(0);
                    itemVenda.Venda.Codigo = dataReader.GetInt32(1);
                    itemVenda.Produto.Codigo = dataReader.GetInt32(2);
                    itemVenda.Quantidade = dataReader.GetInt32(3);
                    itemVenda.PrecoUnitario = dataReader.GetDecimal(4);
                    itemVenda.Venda.DataHora = dataReader.GetDateTime(6);
                    itemVenda.Venda.ValotTotal = dataReader.GetDecimal(7);
                    itemVenda.Produto.Preco = dataReader.GetDecimal(9);
                    itemVenda.Produto.CodigoBarras = dataReader.GetString(10);
                    itemVenda.Produto.Descricao = dataReader.GetString(11);
                    itemVenda.Produto.Categoria.Codigo = dataReader.GetInt32(12);
                    itemVenda.Produto.QntMinEstoque = dataReader.GetInt32(13);
                    itemVenda.Produto.Categoria.Descricao = dataReader.GetString(14);

                    listaItens.Add(itemVenda); /* Adiciona na lista */
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
            return listaItens; /* Retorna a lista */
        }
    }
}
