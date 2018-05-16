using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class Fornecedor
    {
        /* Atributos */
        private int codigo;
        private string cnpj;
        private string nome;
        private string email;
        private string telefone;
        private string rua;
        private int numero;
        private string cep;
        private string cidade;
        private string estado;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Cnpj { get { return cnpj; } set { cnpj = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Telefone { get { return telefone; } set { telefone = value; } }
        public string Rua { get { return rua; } set { rua = value; } }
        public int Numero { get { return numero; } set { numero = value; } }
        public string Cep { get { return cep; } set { cep = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public string Estado { get { return estado; } set { estado = value; } }
    }
}
