namespace ProjetoMercado.view
{
    partial class TelaInicial
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnFornecedores = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListarVendas = new System.Windows.Forms.Button();
            this.btnRealizarVenda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReceberProdutos = new System.Windows.Forms.Button();
            this.btnProdutosEstoque = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProdutos);
            this.groupBox1.Controls.Add(this.btnFornecedores);
            this.groupBox1.Controls.Add(this.btnCategorias);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastros";
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProdutos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Location = new System.Drawing.Point(267, 34);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(119, 71);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnFornecedores
            // 
            this.btnFornecedores.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFornecedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFornecedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFornecedores.Location = new System.Drawing.Point(142, 34);
            this.btnFornecedores.Name = "btnFornecedores";
            this.btnFornecedores.Size = new System.Drawing.Size(119, 71);
            this.btnFornecedores.TabIndex = 1;
            this.btnFornecedores.Text = "Fornecedores";
            this.btnFornecedores.UseVisualStyleBackColor = false;
            this.btnFornecedores.Click += new System.EventHandler(this.btnFornecedores_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Location = new System.Drawing.Point(17, 34);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(119, 71);
            this.btnCategorias.TabIndex = 0;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnListarVendas);
            this.groupBox2.Controls.Add(this.btnRealizarVenda);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(421, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 119);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendas";
            // 
            // btnListarVendas
            // 
            this.btnListarVendas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListarVendas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnListarVendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnListarVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarVendas.Location = new System.Drawing.Point(142, 34);
            this.btnListarVendas.Name = "btnListarVendas";
            this.btnListarVendas.Size = new System.Drawing.Size(119, 71);
            this.btnListarVendas.TabIndex = 4;
            this.btnListarVendas.Text = "Listar Vendas";
            this.btnListarVendas.UseVisualStyleBackColor = false;
            this.btnListarVendas.Click += new System.EventHandler(this.btnListarVendas_Click);
            // 
            // btnRealizarVenda
            // 
            this.btnRealizarVenda.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRealizarVenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRealizarVenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRealizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarVenda.Location = new System.Drawing.Point(17, 34);
            this.btnRealizarVenda.Name = "btnRealizarVenda";
            this.btnRealizarVenda.Size = new System.Drawing.Size(119, 71);
            this.btnRealizarVenda.TabIndex = 3;
            this.btnRealizarVenda.Text = "Realizar Venda";
            this.btnRealizarVenda.UseVisualStyleBackColor = false;
            this.btnRealizarVenda.Click += new System.EventHandler(this.btnRealizarVenda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bem vindo, ";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(96, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(0, 20);
            this.lblLogin.TabIndex = 5;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(256, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 20);
            this.lblData.TabIndex = 6;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(603, 9);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 20);
            this.lblHora.TabIndex = 7;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReceberProdutos);
            this.groupBox3.Controls.Add(this.btnProdutosEstoque);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 119);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estoque";
            // 
            // btnReceberProdutos
            // 
            this.btnReceberProdutos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReceberProdutos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReceberProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReceberProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceberProdutos.Location = new System.Drawing.Point(142, 34);
            this.btnReceberProdutos.Name = "btnReceberProdutos";
            this.btnReceberProdutos.Size = new System.Drawing.Size(119, 71);
            this.btnReceberProdutos.TabIndex = 4;
            this.btnReceberProdutos.Text = "Receber Produtos";
            this.btnReceberProdutos.UseVisualStyleBackColor = false;
            this.btnReceberProdutos.Click += new System.EventHandler(this.btnReceberProdutos_Click);
            // 
            // btnProdutosEstoque
            // 
            this.btnProdutosEstoque.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProdutosEstoque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnProdutosEstoque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProdutosEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutosEstoque.Location = new System.Drawing.Point(17, 34);
            this.btnProdutosEstoque.Name = "btnProdutosEstoque";
            this.btnProdutosEstoque.Size = new System.Drawing.Size(119, 71);
            this.btnProdutosEstoque.TabIndex = 3;
            this.btnProdutosEstoque.Text = "Produtos em Estoque";
            this.btnProdutosEstoque.UseVisualStyleBackColor = false;
            this.btnProdutosEstoque.Click += new System.EventHandler(this.btnProdutosEstoque_Click);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(711, 299);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercado";
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnFornecedores;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnListarVendas;
        private System.Windows.Forms.Button btnRealizarVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReceberProdutos;
        private System.Windows.Forms.Button btnProdutosEstoque;
    }
}