﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMercado.model.domain
{
    class Categoria
    {
        /* Atributos */
        private int codigo;
        private string descricao;

        /* Propriedades */
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
    }
}