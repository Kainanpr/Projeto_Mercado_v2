namespace ProjetoMercado.view
{
    partial class TelaProdutosEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProdutosEstoque = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProdutosEstoque);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 425);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Produtos";
            // 
            // dgvProdutosEstoque
            // 
            this.dgvProdutosEstoque.AllowUserToAddRows = false;
            this.dgvProdutosEstoque.AllowUserToDeleteRows = false;
            this.dgvProdutosEstoque.AllowUserToResizeColumns = false;
            this.dgvProdutosEstoque.AllowUserToResizeRows = false;
            this.dgvProdutosEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Produto,
            this.Quantidade,
            this.QuantidadeMinima});
            this.dgvProdutosEstoque.Location = new System.Drawing.Point(7, 22);
            this.dgvProdutosEstoque.MultiSelect = false;
            this.dgvProdutosEstoque.Name = "dgvProdutosEstoque";
            this.dgvProdutosEstoque.ReadOnly = true;
            this.dgvProdutosEstoque.RowHeadersVisible = false;
            this.dgvProdutosEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutosEstoque.Size = new System.Drawing.Size(444, 397);
            this.dgvProdutosEstoque.TabIndex = 8;
            this.dgvProdutosEstoque.TabStop = false;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Width = 200;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // QuantidadeMinima
            // 
            this.QuantidadeMinima.HeaderText = "Quantidade Min.";
            this.QuantidadeMinima.Name = "QuantidadeMinima";
            this.QuantidadeMinima.ReadOnly = true;
            this.QuantidadeMinima.Width = 140;
            // 
            // TelaProdutosEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "TelaProdutosEstoque";
            this.Text = "Estoque de Produtos";
            this.Load += new System.EventHandler(this.TelaProdutosEstoque_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProdutosEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeMinima;
    }
}