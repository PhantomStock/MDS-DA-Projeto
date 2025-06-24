namespace iTasks
{
    partial class frmGereUtilizadores
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdGestor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstListaGestores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btVoltar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstListaProgramadores = new System.Windows.Forms.ListBox();
            this.txtIdProg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btGravarGestor = new System.Windows.Forms.Button();
            this.txtUsernameProg = new System.Windows.Forms.TextBox();
            this.txtPasswordProg = new System.Windows.Forms.TextBox();
            this.cbNivelProg = new System.Windows.Forms.ComboBox();
            this.cbGestorProg = new System.Windows.Forms.ComboBox();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.btnCreateProg = new System.Windows.Forms.Button();
            this.btnDeleteProg = new System.Windows.Forms.Button();
            this.btnDeleteGestor = new System.Windows.Forms.Button();
            this.btnCreateGestor = new System.Windows.Forms.Button();
            this.txtNomeGestor = new System.Windows.Forms.TextBox();
            this.chkGereUtilizadores = new System.Windows.Forms.CheckBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.txtPasswordGestor = new System.Windows.Forms.TextBox();
            this.txtUsernameGestor = new System.Windows.Forms.TextBox();
            this.txtNomeProg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Nome:";
            // 
            // txtIdGestor
            // 
            this.txtIdGestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtIdGestor.Location = new System.Drawing.Point(294, 35);
            this.txtIdGestor.Name = "txtIdGestor";
            this.txtIdGestor.ReadOnly = true;
            this.txtIdGestor.Size = new System.Drawing.Size(62, 20);
            this.txtIdGestor.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Id:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.lstListaGestores);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 455);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista";
            // 
            // lstListaGestores
            // 
            this.lstListaGestores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaGestores.FormattingEnabled = true;
            this.lstListaGestores.Location = new System.Drawing.Point(3, 16);
            this.lstListaGestores.Name = "lstListaGestores";
            this.lstListaGestores.Size = new System.Drawing.Size(268, 436);
            this.lstListaGestores.TabIndex = 0;
            this.lstListaGestores.SelectedIndexChanged += new System.EventHandler(this.lstListaGestores_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.btnCreateGestor);
            this.groupBox2.Controls.Add(this.btnDeleteGestor);
            this.groupBox2.Controls.Add(this.chkGereUtilizadores);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btGravarGestor);
            this.groupBox2.Controls.Add(this.txtPasswordGestor);
            this.groupBox2.Controls.Add(this.cbDepartamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsernameGestor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtIdGestor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNomeGestor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 480);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestores";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Departamento:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Username:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox3.Controls.Add(this.btnCreateProg);
            this.groupBox3.Controls.Add(this.btnDeleteProg);
            this.groupBox3.Controls.Add(this.btVoltar);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbGestorProg);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btGravarProg);
            this.groupBox3.Controls.Add(this.txtPasswordProg);
            this.groupBox3.Controls.Add(this.cbNivelProg);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtUsernameProg);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txtIdProg);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNomeProg);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(529, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 480);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programadores";
            // 
            // btVoltar
            // 
            this.btVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btVoltar.Location = new System.Drawing.Point(408, 451);
            this.btVoltar.Name = "btVoltar";
            this.btVoltar.Size = new System.Drawing.Size(97, 23);
            this.btVoltar.TabIndex = 16;
            this.btVoltar.Text = "Voltar";
            this.btVoltar.UseVisualStyleBackColor = true;
            this.btVoltar.Click += new System.EventHandler(this.btVoltar_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(291, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Gestor:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Nível de Experiência:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Password:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Username:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox4.Controls.Add(this.lstListaProgramadores);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 455);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista";
            // 
            // lstListaProgramadores
            // 
            this.lstListaProgramadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaProgramadores.FormattingEnabled = true;
            this.lstListaProgramadores.Location = new System.Drawing.Point(3, 16);
            this.lstListaProgramadores.Name = "lstListaProgramadores";
            this.lstListaProgramadores.Size = new System.Drawing.Size(268, 436);
            this.lstListaProgramadores.TabIndex = 0;
            this.lstListaProgramadores.SelectedIndexChanged += new System.EventHandler(this.lstListaProgramadores_SelectedIndexChanged);
            // 
            // txtIdProg
            // 
            this.txtIdProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtIdProg.Location = new System.Drawing.Point(294, 35);
            this.txtIdProg.Name = "txtIdProg";
            this.txtIdProg.ReadOnly = true;
            this.txtIdProg.Size = new System.Drawing.Size(62, 20);
            this.txtIdProg.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Id:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Nome:";
            // 
            // btGravarGestor
            // 
            this.btGravarGestor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btGravarGestor.Location = new System.Drawing.Point(294, 283);
            this.btGravarGestor.Name = "btGravarGestor";
            this.btGravarGestor.Size = new System.Drawing.Size(201, 23);
            this.btGravarGestor.TabIndex = 5;
            this.btGravarGestor.Text = "Gravar Dados";
            this.btGravarGestor.UseVisualStyleBackColor = true;
            this.btGravarGestor.Click += new System.EventHandler(this.btGravarGestor_Click);
            // 
            // txtUsernameProg
            // 
            this.txtUsernameProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtUsernameProg.Location = new System.Drawing.Point(294, 119);
            this.txtUsernameProg.Name = "txtUsernameProg";
            this.txtUsernameProg.Size = new System.Drawing.Size(201, 20);
            this.txtUsernameProg.TabIndex = 9;
            // 
            // txtPasswordProg
            // 
            this.txtPasswordProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtPasswordProg.Location = new System.Drawing.Point(294, 159);
            this.txtPasswordProg.Name = "txtPasswordProg";
            this.txtPasswordProg.Size = new System.Drawing.Size(201, 20);
            this.txtPasswordProg.TabIndex = 10;
            // 
            // cbNivelProg
            // 
            this.cbNivelProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbNivelProg.FormattingEnabled = true;
            this.cbNivelProg.Location = new System.Drawing.Point(294, 203);
            this.cbNivelProg.Name = "cbNivelProg";
            this.cbNivelProg.Size = new System.Drawing.Size(201, 21);
            this.cbNivelProg.TabIndex = 11;
            // 
            // cbGestorProg
            // 
            this.cbGestorProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbGestorProg.FormattingEnabled = true;
            this.cbGestorProg.Location = new System.Drawing.Point(294, 246);
            this.cbGestorProg.Name = "cbGestorProg";
            this.cbGestorProg.Size = new System.Drawing.Size(201, 21);
            this.cbGestorProg.TabIndex = 12;
            // 
            // btGravarProg
            // 
            this.btGravarProg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btGravarProg.Location = new System.Drawing.Point(294, 283);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(201, 23);
            this.btGravarProg.TabIndex = 13;
            this.btGravarProg.Text = "Gravar Dados";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btGravarProg_Click);
            // 
            // btnCreateProg
            // 
            this.btnCreateProg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateProg.Location = new System.Drawing.Point(294, 312);
            this.btnCreateProg.Name = "btnCreateProg";
            this.btnCreateProg.Size = new System.Drawing.Size(201, 23);
            this.btnCreateProg.TabIndex = 14;
            this.btnCreateProg.Text = "Limpar Input Programador";
            this.btnCreateProg.UseVisualStyleBackColor = true;
            this.btnCreateProg.Click += new System.EventHandler(this.btnCreateProg_Click);
            // 
            // btnDeleteProg
            // 
            this.btnDeleteProg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteProg.Location = new System.Drawing.Point(294, 341);
            this.btnDeleteProg.Name = "btnDeleteProg";
            this.btnDeleteProg.Size = new System.Drawing.Size(201, 23);
            this.btnDeleteProg.TabIndex = 15;
            this.btnDeleteProg.Text = "Eliminar";
            this.btnDeleteProg.UseVisualStyleBackColor = true;
            this.btnDeleteProg.Click += new System.EventHandler(this.btnDeleteProg_Click);
            // 
            // btnDeleteGestor
            // 
            this.btnDeleteGestor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteGestor.Location = new System.Drawing.Point(294, 341);
            this.btnDeleteGestor.Name = "btnDeleteGestor";
            this.btnDeleteGestor.Size = new System.Drawing.Size(201, 23);
            this.btnDeleteGestor.TabIndex = 7;
            this.btnDeleteGestor.Text = "Eliminar";
            this.btnDeleteGestor.UseVisualStyleBackColor = true;
            this.btnDeleteGestor.Click += new System.EventHandler(this.btnDeleteGestor_Click);
            // 
            // btnCreateGestor
            // 
            this.btnCreateGestor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateGestor.Location = new System.Drawing.Point(294, 312);
            this.btnCreateGestor.Name = "btnCreateGestor";
            this.btnCreateGestor.Size = new System.Drawing.Size(201, 23);
            this.btnCreateGestor.TabIndex = 6;
            this.btnCreateGestor.Text = "Limpar Input Gestor";
            this.btnCreateGestor.UseVisualStyleBackColor = true;
            this.btnCreateGestor.Click += new System.EventHandler(this.btnCreateGestor_Click);
            // 
            // txtNomeGestor
            // 
            this.txtNomeGestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtNomeGestor.Location = new System.Drawing.Point(294, 80);
            this.txtNomeGestor.Name = "txtNomeGestor";
            this.txtNomeGestor.Size = new System.Drawing.Size(201, 20);
            this.txtNomeGestor.TabIndex = 0;
            // 
            // chkGereUtilizadores
            // 
            this.chkGereUtilizadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chkGereUtilizadores.AutoSize = true;
            this.chkGereUtilizadores.Location = new System.Drawing.Point(294, 240);
            this.chkGereUtilizadores.Name = "chkGereUtilizadores";
            this.chkGereUtilizadores.Size = new System.Drawing.Size(106, 17);
            this.chkGereUtilizadores.TabIndex = 4;
            this.chkGereUtilizadores.Text = "Gere Utilizadores";
            this.chkGereUtilizadores.UseVisualStyleBackColor = true;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(294, 203);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(201, 21);
            this.cbDepartamento.TabIndex = 3;
            // 
            // txtPasswordGestor
            // 
            this.txtPasswordGestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtPasswordGestor.Location = new System.Drawing.Point(294, 159);
            this.txtPasswordGestor.Name = "txtPasswordGestor";
            this.txtPasswordGestor.Size = new System.Drawing.Size(201, 20);
            this.txtPasswordGestor.TabIndex = 2;
            // 
            // txtUsernameGestor
            // 
            this.txtUsernameGestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtUsernameGestor.Location = new System.Drawing.Point(294, 119);
            this.txtUsernameGestor.Name = "txtUsernameGestor";
            this.txtUsernameGestor.Size = new System.Drawing.Size(201, 20);
            this.txtUsernameGestor.TabIndex = 1;
            // 
            // txtNomeProg
            // 
            this.txtNomeProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtNomeProg.Location = new System.Drawing.Point(294, 80);
            this.txtNomeProg.Name = "txtNomeProg";
            this.txtNomeProg.Size = new System.Drawing.Size(201, 20);
            this.txtNomeProg.TabIndex = 8;
            // 
            // frmGereUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 504);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmGereUtilizadores";
            this.Text = "frmListaUtilizadores";
            this.Load += new System.EventHandler(this.frmGereUtilizadores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdGestor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstListaGestores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstListaProgramadores;
        private System.Windows.Forms.TextBox txtIdProg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btVoltar;
        private System.Windows.Forms.Button btnCreateGestor;
        private System.Windows.Forms.Button btnDeleteGestor;
        private System.Windows.Forms.CheckBox chkGereUtilizadores;
        private System.Windows.Forms.Button btGravarGestor;
        private System.Windows.Forms.TextBox txtPasswordGestor;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.TextBox txtUsernameGestor;
        private System.Windows.Forms.TextBox txtNomeGestor;
        private System.Windows.Forms.Button btnCreateProg;
        private System.Windows.Forms.Button btnDeleteProg;
        private System.Windows.Forms.ComboBox cbGestorProg;
        private System.Windows.Forms.Button btGravarProg;
        private System.Windows.Forms.TextBox txtPasswordProg;
        private System.Windows.Forms.ComboBox cbNivelProg;
        private System.Windows.Forms.TextBox txtUsernameProg;
        private System.Windows.Forms.TextBox txtNomeProg;
    }
}