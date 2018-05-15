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
using ProjetoMercado.model.dao;

namespace ProjetoMercado.view
{
    public partial class TelaListarVendas : Form
    {
        /* Atributo responsável pelo CRUD venda */
        private VendaDAO vendaDAO = new VendaDAO();
        /* Atributo responsável pelo CRUD itemVenda */
        private ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

        public TelaListarVendas()
        {
            InitializeComponent();
        }

        private void TelaListarVendas_Load(object sender, EventArgs e)
        {
            AtualizaDGVVendas();
        }

        private void AtualizaDGVVendas()
        {
            /* Recebe todos os dados do Banco de Dados */
            List<Venda> listaVendas = vendaDAO.ListAll();

            /* Percorre toda a lista de vendas e adiciona no Data Grid View */
            foreach (Venda venda in listaVendas)
                dgvVendas.Rows.Add(venda.Codigo, venda.DataHora.ToString("dd/MM/yyyy"),
                    venda.DataHora.ToString("HH:mm:ss"), venda.ValotTotal.ToString("c"));

            /* Limpa a seleção de linha */
            dgvVendas.ClearSelection();
        }

        private void dgvVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvProdutos.Rows.Clear();           

            int codVenda = int.Parse(dgvVendas.CurrentRow.Cells[0].Value.ToString());

            /* Recebe a lista de items da Venda */
            List<ItemVenda> listaItens = itemVendaDAO.ListAll(codVenda);

            /* Percorre toda a lista de itens adicionando no Data Grid View */
            foreach (ItemVenda itemVenda in listaItens)
                dgvProdutos.Rows.Add(itemVenda.Produto.Codigo, itemVenda.Produto.Descricao,
                    itemVenda.Quantidade, itemVenda.PrecoUnitario.ToString("c"), (itemVenda.Quantidade * itemVenda.PrecoUnitario).ToString("c"));

            /* Limpa a seleção de linha */
            dgvProdutos.ClearSelection();
        }
    }
}
