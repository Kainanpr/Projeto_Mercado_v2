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
    public partial class TelaRelatorioVendas : Form
    {
        private bool state = false; /* Indica qual botão foi clicado */
        private DateTime dataInicio;
        private DateTime dataFim;

        public TelaRelatorioVendas()
        {
            InitializeComponent();
        }

        public bool State { get { return state; } set { state = value; } }
        public DateTime DataInicio { get { return dataInicio; } }
        public DateTime DataFim { get { return dataFim; } }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            state = true;
            dataInicio = dtpInicio.Value;
            dataFim = dtpFim.Value;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
