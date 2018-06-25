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
            
            InitializeComponent();
            this.usuario = usuario;
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
            TelaRealizarVenda telaRealizarVenda = new TelaRealizarVenda(usuario);
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

        private void btnProdutosEstoque_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Produtos em Estoque */
            TelaProdutosEstoque telaProdutosEstoque = new TelaProdutosEstoque();
            this.Hide();
            telaProdutosEstoque.ShowDialog();
            this.Show();
        }

        private void btnReceberProdutos_Click(object sender, EventArgs e)
        {
            /* Abre a Tela de Receber Produtos */
            TelaReceberProduto telaReceberProduto = new TelaReceberProduto();
            this.Hide();
            telaReceberProduto.ShowDialog();
            this.Show();
        }

        private void btnRlEstoque_Click(object sender, EventArgs e)
        {
            /* Responsável por gerar o relatório dos produtos do estoque */

            /* Caixa de diálogo para salvar o arquivo */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.ShowDialog();

            if (!saveFileDialog.FileName.ToString().Equals(""))
            {
                Relatorios.GerarEstoque(saveFileDialog.FileName.ToString());

                MessageBox.Show("Relatório de Estoque Gerado", "Relatório Gerado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRlVendas_Click(object sender, EventArgs e)
        {
            TelaRelatorioVendas telaRelatorioVendas = new TelaRelatorioVendas();
            telaRelatorioVendas.ShowDialog();
            if(telaRelatorioVendas.State)
            {
                /* Caixa de diálogo para salvar o arquivo */
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = ".pdf";
                saveFileDialog.ShowDialog();

                if (!saveFileDialog.FileName.ToString().Equals(""))
                {
                    Relatorios.GerarVendas(saveFileDialog.FileName.ToString(), telaRelatorioVendas.DataInicio,
                    telaRelatorioVendas.DataFim);

                    MessageBox.Show("Relatório de Vendas Gerado", "Relatório Gerado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnMaisVendidos_Click(object sender, EventArgs e)
        {
            /* Caixa de diálogo para salvar o arquivo */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.ShowDialog();

            if (!saveFileDialog.FileName.ToString().Equals(""))
            {
                Relatorios.GerarMaisVendidos(saveFileDialog.FileName.ToString());

                MessageBox.Show("Relatório de Produtos Mais Vendidos Gerado", "Relatório Gerado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
