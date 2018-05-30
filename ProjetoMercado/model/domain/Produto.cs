using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class Produto
    {
        /* Atributos */
        private int codigo;
        private decimal preco;
        private string codigoBarras;
        private string descricao;
        private Categoria categoria;
        private int qntMinEstoque;
        private Fornecedor fornecedor;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public decimal Preco { get { return preco; } set { preco = value; } }
        public string CodigoBarras { get { return codigoBarras; } set { codigoBarras = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public Categoria Categoria { get { return categoria; } set { categoria = value; } }
        public int QntMinEstoque { get { return qntMinEstoque; } set { qntMinEstoque = value; } }
        public Fornecedor Fornecedor { get { return fornecedor; } set { fornecedor = value; } }
    }
}
