using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoMercado.model.domain;

namespace ProjetoMercado.view
{
    public partial class TelaExibeFornecedor : Form
    {
        public TelaExibeFornecedor()
        {
            InitializeComponent();
        }

        public TelaExibeFornecedor(Fornecedor fornecedor)
        {
            InitializeComponent();
            txtCodigo.Text = fornecedor.Codigo.ToString();
            txtCNPJ.Text = fornecedor.Cnpj;
            txtNome.Text = fornecedor.Nome;
            txtEmail.Text = fornecedor.Email;
            txtTelefone.Text = fornecedor.Telefone;
            txtRua.Text = fornecedor.Rua;
            txtN.Text = fornecedor.Numero.ToString();
            txtCEP.Text = fornecedor.Cep;
            txtCidade.Text = fornecedor.Cidade;
            txtEstado.Text = fornecedor.Estado;
        }
    }
}
