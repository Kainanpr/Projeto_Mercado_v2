﻿namespace ProjetoMercado.view
{
    partial class TelaFornecedor
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
            this.radioButtonNome = new System.Windows.Forms.RadioButton();
            this.radioButtonCnpj = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPesquisarFornecedor = new System.Windows.Forms.TextBox();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.radioButtonCodigo = new System.Windows.Forms.RadioButton();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonCodigo);
            this.groupBox1.Controls.Add(this.radioButtonNome);
            this.groupBox1.Controls.Add(this.radioButtonCnpj);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione a forma da consulta";
            // 
            // radioButtonNome
            // 
            this.radioButtonNome.AutoSize = true;
            this.radioButtonNome.Location = new System.Drawing.Point(229, 23);
            this.radioButtonNome.Name = "radioButtonNome";
            this.radioButtonNome.Size = new System.Drawing.Size(67, 22);
            this.radioButtonNome.TabIndex = 1;
            this.radioButtonNome.TabStop = true;
            this.radioButtonNome.Text = "Nome";
            this.radioButtonNome.UseVisualStyleBackColor = true;
            // 
            // radioButtonCnpj
            // 
            this.radioButtonCnpj.AutoSize = true;
            this.radioButtonCnpj.Location = new System.Drawing.Point(135, 23);
            this.radioButtonCnpj.Name = "radioButtonCnpj";
            this.radioButtonCnpj.Size = new System.Drawing.Size(66, 22);
            this.radioButtonCnpj.TabIndex = 0;
            this.radioButtonCnpj.TabStop = true;
            this.radioButtonCnpj.Text = "CNPJ";
            this.radioButtonCnpj.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cadastro de fornecedor";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPesquisarFornecedor);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(401, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 45);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Localizar fornecedor:";
            // 
            // txtPesquisarFornecedor
            // 
            this.txtPesquisarFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarFornecedor.Location = new System.Drawing.Point(167, 11);
            this.txtPesquisarFornecedor.Name = "txtPesquisarFornecedor";
            this.txtPesquisarFornecedor.Size = new System.Drawing.Size(192, 24);
            this.txtPesquisarFornecedor.TabIndex = 0;
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.AllowUserToAddRows = false;
            this.dataGridViewClientes.AllowUserToDeleteRows = false;
            this.dataGridViewClientes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nome,
            this.cnpj});
            this.dataGridViewClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewClientes.Location = new System.Drawing.Point(26, 173);
            this.dataGridViewClientes.MultiSelect = false;
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(736, 195);
            this.dataGridViewClientes.TabIndex = 4;
            this.dataGridViewClientes.SelectionChanged += new System.EventHandler(this.dataGridViewClientes_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAdicionar);
            this.panel2.Controls.Add(this.btnListar);
            this.panel2.Controls.Add(this.btnExcluir);
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Controls.Add(this.btnAlterar);
            this.panel2.Location = new System.Drawing.Point(26, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 47);
            this.panel2.TabIndex = 2;
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(543, 7);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(91, 32);
            this.btnListar.TabIndex = 9;
            this.btnListar.Text = "Listar Todos";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(278, 7);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(77, 32);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(454, 7);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(78, 32);
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(645, 7);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(78, 32);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Location = new System.Drawing.Point(191, 7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 32);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(365, 7);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(78, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(102, 7);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(77, 32);
            this.btnAlterar.TabIndex = 0;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtEstado);
            this.panel3.Controls.Add(this.txtCidade);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtCep);
            this.panel3.Controls.Add(this.txtNumero);
            this.panel3.Controls.Add(this.txtEndereco);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.txtTelefone);
            this.panel3.Controls.Add(this.txtCnpj);
            this.panel3.Controls.Add(this.txtNome);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 242);
            this.panel3.TabIndex = 5;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(291, 206);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(61, 22);
            this.txtEstado.TabIndex = 38;
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(26, 206);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(221, 22);
            this.txtCidade.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(288, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Estado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Cidade";
            // 
            // txtCep
            // 
            this.txtCep.Enabled = false;
            this.txtCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(455, 159);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(155, 22);
            this.txtCep.TabIndex = 34;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(291, 159);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(101, 22);
            this.txtNumero.TabIndex = 33;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(26, 159);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(221, 22);
            this.txtEndereco.TabIndex = 32;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(455, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 22);
            this.txtEmail.TabIndex = 31;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefone.Location = new System.Drawing.Point(26, 110);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(366, 22);
            this.txtTelefone.TabIndex = 30;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Enabled = false;
            this.txtCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpj.Location = new System.Drawing.Point(455, 58);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(282, 22);
            this.txtCnpj.TabIndex = 29;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(26, 58);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(365, 22);
            this.txtNome.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(452, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "CEP(Apenas números)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Endereço";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(288, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Número";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Telefone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(452, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "CNPJ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dados abaixo para serem alterados";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(13, 7);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(77, 32);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // radioButtonCodigo
            // 
            this.radioButtonCodigo.AutoSize = true;
            this.radioButtonCodigo.Location = new System.Drawing.Point(39, 22);
            this.radioButtonCodigo.Name = "radioButtonCodigo";
            this.radioButtonCodigo.Size = new System.Drawing.Size(74, 22);
            this.radioButtonCodigo.TabIndex = 2;
            this.radioButtonCodigo.TabStop = true;
            this.radioButtonCodigo.Text = "Código";
            this.radioButtonCodigo.UseVisualStyleBackColor = true;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            // 
            // nome
            // 
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.Width = 330;
            // 
            // cnpj
            // 
            this.cnpj.HeaderText = "CNPJ";
            this.cnpj.Name = "cnpj";
            this.cnpj.Width = 250;
            // 
            // TelaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 628);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TelaFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fornecedores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNome;
        private System.Windows.Forms.RadioButton radioButtonCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPesquisarFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.RadioButton radioButtonCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpj;
    }
}