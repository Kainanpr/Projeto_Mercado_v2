using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class Venda
    {
        /* Atributos */
        private int codigo;
        private DateTime dataHora;
        private decimal valorTotal;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public DateTime DataHora { get { return dataHora; } set { dataHora = value; } }
        public decimal ValotTotal { get { return valorTotal; } set { valorTotal = value; } }
    }
}
