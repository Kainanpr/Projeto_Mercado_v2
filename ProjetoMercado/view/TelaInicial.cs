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
            this.Hide();
            telaCategoria.ShowDialog();
            this.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Produtos */
            TelaProduto telaProduto = new TelaProduto();
            this.Hide();
            telaProduto.ShowDialog();
            this.Show();
        }

        private void btnRealizarVenda_Click(object sender, EventArgs e)
        {
            /* Abre a Tela para Realizar Vendas */
            TelaRealizarVenda telaRealizarVenda = new TelaRealizarVenda();
            this.Hide();
            telaRealizarVenda.ShowDialog();
            this.Show();
        }

        private void btnListarVendas_Click(object sender, EventArgs e)
        {
            /* Abre a Tela para Listar Vendas */
            TelaListarVendas telaListarVendas = new TelaListarVendas();
            this.Hide();
            telaListarVendas.ShowDialog();
            this.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Fornecedores */
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            this.Hide();
            telaFornecedor.ShowDialog();
            this.Show();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            /* Preenche a label com o login do usuário */
            lblLogin.Text = usuario.Nome;

            /* Preeche o label com a data atual */
            lblData.Text = DateTime.Now.ToLongDateString();

            /* Preeche o label com a hora atual */
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        /* Executado a cada 1000ms */
        private void timer_Tick(object sender, EventArgs e)
        {
            /* Preeche o label com a data atual */
            lblData.Text = DateTime.Now.ToLongDateString();

            /* Preeche o label com a hora atual */
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
