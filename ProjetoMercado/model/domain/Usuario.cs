﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class Usuario
    {
        /* Atributos */
        private int codigo;
        private string login;
        private string senha;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Senha { get { return senha; } set { senha = value; } }
    }
}