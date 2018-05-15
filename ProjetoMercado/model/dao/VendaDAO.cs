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
    class VendaDAO
    {
        /* Salva uma Venda no Banco de Dados */
        public void Create(Venda venda)
        {
            /* Instância de Database para acessar o Banco de Dados */
            Database mercadoDB = Database.GetInstance();

            /* String que contém o SQL que será executado */
            string query = "INSERT INTO Venda (data_hora, valor_total) " +
                "VALUES (@Data_hora, @Valor_total);";

            /* Responsável pelo comando SQL */
            MySqlCommand command = new MySqlCommand(query);

            /* Adiciona os parâmetros no comando SQL */
            command.Parameters.AddWithValue("@Data_hora", venda.DataHora);
            command.Parameters.AddWithValue("@Valor_total", venda.ValotTotal);

            /* Chama o método de Database para executar um comando que não retorna dados */
            mercadoDB.ExecuteSQL(command);
        }

        /* Recupera uma lista contendo todas as vendas no Banco de Dados */
        public List<Venda> ListAll()
        {
            /* Recebe a conexão utilizada para acessar o Banco de Dados */
            MySqlConnection connection = Database.GetInstance().GetConnection();

            /* Lista de vendas */
            List<Venda> listaVendas = new List<Venda>();

            /* Preenchido com as informações do Banco de Dados */
            Venda venda;

            /* String que contém o SQL que será executado */
            string query = "SELECT * FROM Venda;";

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
                    venda = new Venda();
                    venda.Codigo = dataReader.GetInt32(0);
                    venda.DataHora = dataReader.GetDateTime(1);
                    venda.ValotTotal = dataReader.GetDecimal(2);

                    listaVendas.Add(venda); /* Adiciona na lista */
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
            return listaVendas; /* Retorna a lista */
        }

        /* Retorna o código que será utilizado para a próxima venda */
        public int NextCodVenda()
        {
            int nextCod = 1;

            MySqlConnection connection = Database.GetInstance().GetConnection();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = "SELECT MAX(codigo) FROM Venda;";

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader dataReader = command.ExecuteReader();
            
            /* Verifica se o dataReader retornou uma consulta sem valor */
            if (dataReader.Read())
                if (!dataReader.IsDBNull(0))
                    nextCod = dataReader.GetInt32(0) + 1;

            dataReader.Close();
            connection.Close();
            return nextCod;
        }
    }
}
