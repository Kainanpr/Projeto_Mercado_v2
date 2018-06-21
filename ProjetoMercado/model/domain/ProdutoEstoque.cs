using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class ProdutoEstoque
    {
        /* Atributos */
        private int codigo;
        private Produto produto;
        private int quantidadeEstoque;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public Produto Produto { get { return produto; } set { produto = value; } }
        public int QuantidadeEstoque { get { return quantidadeEstoque; } set { quantidadeEstoque = value; } }

        /* Retorna se o estoque está acima do limite mínimo do produto */
        public bool EstoqueNormal()
        {
            if (QuantidadeEstoque >= produto.QntMinEstoque)
                return true;
            else
                return false;
        }
    }
}