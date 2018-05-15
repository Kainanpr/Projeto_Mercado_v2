using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class ItemVenda
    {
        /* Atributos */
        private int codigo;
        private Venda venda;
        private Produto produto;
        private int quantidade;
        private decimal precoUnitario;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public Venda Venda { get { return venda; } set { venda = value; } }
        public Produto Produto { get { return produto; } set { produto = value; } }
        public int Quantidade { get { return quantidade; } set { quantidade = value; } }
        public decimal PrecoUnitario { get { return precoUnitario; } set { precoUnitario = value; } }
    }
}
