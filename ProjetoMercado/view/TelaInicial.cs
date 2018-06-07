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
    public partial class TelaInicial : Form
    {
        /* Atributo */
        private Usuario usuario;

        public TelaInicial(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }



        private void btnCategorias_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Categorias */
            TelaCategoria telaCategoria = new TelaCategoria();
            telaCategoria.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Produtos */
            TelaProduto telaProduto = new TelaProduto();
            telaProduto.ShowDialog();
        }

        private void btnRealizarVenda_Click(object sender, EventArgs e)
        {
            /* Abre a Tela para Realizar Vendas */
            TelaRealizarVenda telaRealizarVenda = new TelaRealizarVenda();
            telaRealizarVenda.ShowDialog();
        }

        private void btnListarVendas_Click(object sender, EventArgs e)
        {
            /* Abre a Tela para Listar Vendas */
            TelaListarVendas telaListarVendas = new TelaListarVendas();
            telaListarVendas.ShowDialog();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Fornecedores */
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.ShowDialog();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            /* Preenche a label com o login do usuário */
            lblLogin.Text = usuario.Login;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /* Preeche o label com a data atual */
            lblData.Text = DateTime.Now.ToLongDateString();

            /* Preeche o label com a hora atual */
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
