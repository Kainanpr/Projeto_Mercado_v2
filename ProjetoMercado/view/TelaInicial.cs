using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMercado.view
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
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
    }
}
