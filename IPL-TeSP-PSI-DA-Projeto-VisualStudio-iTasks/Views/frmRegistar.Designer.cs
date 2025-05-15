namespace iTasks
{
    partial class frmRegistar
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
            this.btRegistar = new System.Windows.Forms.Button();
            this.btVoltar = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConfirmarPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gpUtilizador = new System.Windows.Forms.GroupBox();
            this.rbGestor = new System.Windows.Forms.RadioButton();
            this.rbProgramador = new System.Windows.Forms.RadioButton();
            this.rbUtilizadorComum = new System.Windows.Forms.RadioButton();
            this.gbProgramador = new System.Windows.Forms.GroupBox();
            this.cbGestor = new System.Windows.Forms.ComboBox();
            this.cbExperiencia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbGestor = new System.Windows.Forms.GroupBox();
            this.cbxGereUtilizadores = new System.Windows.Forms.CheckBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpUtilizador.SuspendLayout();
            this.gbProgramador.SuspendLayout();
            this.gbGestor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRegistar
            // 
            this.btRegistar.Location = new System.Drawing.Point(236, 326);
            this.btRegistar.Name = "btRegistar";
            this.btRegistar.Size = new System.Drawing.Size(121, 28);
            this.btRegistar.TabIndex = 11;
            this.btRegistar.Text = "Registar";
            this.btRegistar.UseVisualStyleBackColor = true;
            this.btRegistar.Click += new System.EventHandler(this.btRegistar_Click);
            // 
            // btVoltar
            // 
            this.btVoltar.Location = new System.Drawing.Point(403, 326);
            this.btVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btVoltar.Name = "btVoltar";
            this.btVoltar.Size = new System.Drawing.Size(100, 28);
            this.btVoltar.TabIndex = 10;
            this.btVoltar.Text = "Voltar";
            this.btVoltar.UseVisualStyleBackColor = true;
            this.btVoltar.Click += new System.EventHandler(this.btVoltar_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(167, 124);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(183, 22);
            this.tbPassword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(167, 81);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(183, 22);
            this.tbUsername.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username:";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(168, 39);
            this.tbNome.Margin = new System.Windows.Forms.Padding(4);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(183, 22);
            this.tbNome.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nome:";
            // 
            // tbConfirmarPass
            // 
            this.tbConfirmarPass.Location = new System.Drawing.Point(167, 164);
            this.tbConfirmarPass.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfirmarPass.Name = "tbConfirmarPass";
            this.tbConfirmarPass.Size = new System.Drawing.Size(183, 22);
            this.tbConfirmarPass.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Confirme a Password:";
            // 
            // gpUtilizador
            // 
            this.gpUtilizador.Controls.Add(this.label3);
            this.gpUtilizador.Controls.Add(this.tbConfirmarPass);
            this.gpUtilizador.Controls.Add(this.label1);
            this.gpUtilizador.Controls.Add(this.label4);
            this.gpUtilizador.Controls.Add(this.tbUsername);
            this.gpUtilizador.Controls.Add(this.tbNome);
            this.gpUtilizador.Controls.Add(this.label2);
            this.gpUtilizador.Controls.Add(this.tbPassword);
            this.gpUtilizador.Location = new System.Drawing.Point(24, 47);
            this.gpUtilizador.Name = "gpUtilizador";
            this.gpUtilizador.Size = new System.Drawing.Size(357, 240);
            this.gpUtilizador.TabIndex = 16;
            this.gpUtilizador.TabStop = false;
            this.gpUtilizador.Text = "Dados Utilizador";
            // 
            // rbGestor
            // 
            this.rbGestor.AutoSize = true;
            this.rbGestor.Location = new System.Drawing.Point(465, 12);
            this.rbGestor.Name = "rbGestor";
            this.rbGestor.Size = new System.Drawing.Size(68, 20);
            this.rbGestor.TabIndex = 17;
            this.rbGestor.TabStop = true;
            this.rbGestor.Text = "Gestor";
            this.rbGestor.UseVisualStyleBackColor = true;
            this.rbGestor.CheckedChanged += new System.EventHandler(this.rbGestor_CheckedChanged);
            // 
            // rbProgramador
            // 
            this.rbProgramador.AutoSize = true;
            this.rbProgramador.Location = new System.Drawing.Point(348, 12);
            this.rbProgramador.Name = "rbProgramador";
            this.rbProgramador.Size = new System.Drawing.Size(108, 20);
            this.rbProgramador.TabIndex = 18;
            this.rbProgramador.Text = "Programador";
            this.rbProgramador.UseVisualStyleBackColor = true;
            this.rbProgramador.CheckedChanged += new System.EventHandler(this.rbProgramador_CheckedChanged);
            // 
            // rbUtilizadorComum
            // 
            this.rbUtilizadorComum.AutoSize = true;
            this.rbUtilizadorComum.Checked = true;
            this.rbUtilizadorComum.Location = new System.Drawing.Point(250, 12);
            this.rbUtilizadorComum.Name = "rbUtilizadorComum";
            this.rbUtilizadorComum.Size = new System.Drawing.Size(84, 20);
            this.rbUtilizadorComum.TabIndex = 19;
            this.rbUtilizadorComum.TabStop = true;
            this.rbUtilizadorComum.Text = "Utilizador";
            this.rbUtilizadorComum.UseVisualStyleBackColor = true;
            this.rbUtilizadorComum.CheckedChanged += new System.EventHandler(this.rbUtilizadorComum_CheckedChanged);
            // 
            // gbProgramador
            // 
            this.gbProgramador.Controls.Add(this.cbGestor);
            this.gbProgramador.Controls.Add(this.cbExperiencia);
            this.gbProgramador.Controls.Add(this.label5);
            this.gbProgramador.Controls.Add(this.label6);
            this.gbProgramador.Enabled = false;
            this.gbProgramador.Location = new System.Drawing.Point(403, 47);
            this.gbProgramador.Name = "gbProgramador";
            this.gbProgramador.Size = new System.Drawing.Size(357, 105);
            this.gbProgramador.TabIndex = 17;
            this.gbProgramador.TabStop = false;
            this.gbProgramador.Text = "Dados Programador";
            // 
            // cbGestor
            // 
            this.cbGestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGestor.FormattingEnabled = true;
            this.cbGestor.Location = new System.Drawing.Point(162, 67);
            this.cbGestor.Name = "cbGestor";
            this.cbGestor.Size = new System.Drawing.Size(183, 24);
            this.cbGestor.TabIndex = 14;
            // 
            // cbExperiencia
            // 
            this.cbExperiencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExperiencia.FormattingEnabled = true;
            this.cbExperiencia.Location = new System.Drawing.Point(162, 28);
            this.cbExperiencia.Name = "cbExperiencia";
            this.cbExperiencia.Size = new System.Drawing.Size(183, 24);
            this.cbExperiencia.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nivel de Experiencia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Gestor:";
            // 
            // gbGestor
            // 
            this.gbGestor.Controls.Add(this.cbxGereUtilizadores);
            this.gbGestor.Controls.Add(this.cbDepartamento);
            this.gbGestor.Controls.Add(this.label7);
            this.gbGestor.Enabled = false;
            this.gbGestor.Location = new System.Drawing.Point(403, 182);
            this.gbGestor.Name = "gbGestor";
            this.gbGestor.Size = new System.Drawing.Size(357, 105);
            this.gbGestor.TabIndex = 18;
            this.gbGestor.TabStop = false;
            this.gbGestor.Text = "Dados Gestor";
            // 
            // cbxGereUtilizadores
            // 
            this.cbxGereUtilizadores.AutoSize = true;
            this.cbxGereUtilizadores.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxGereUtilizadores.Location = new System.Drawing.Point(43, 65);
            this.cbxGereUtilizadores.Name = "cbxGereUtilizadores";
            this.cbxGereUtilizadores.Size = new System.Drawing.Size(136, 20);
            this.cbxGereUtilizadores.TabIndex = 16;
            this.cbxGereUtilizadores.Text = "Gere Utilizadores:";
            this.cbxGereUtilizadores.UseVisualStyleBackColor = true;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(162, 21);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(183, 24);
            this.cbDepartamento.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Departamento:";
            // 
            // frmRegistar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 386);
            this.Controls.Add(this.gbGestor);
            this.Controls.Add(this.gbProgramador);
            this.Controls.Add(this.rbGestor);
            this.Controls.Add(this.rbUtilizadorComum);
            this.Controls.Add(this.rbProgramador);
            this.Controls.Add(this.gpUtilizador);
            this.Controls.Add(this.btVoltar);
            this.Controls.Add(this.btRegistar);
            this.Name = "frmRegistar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistar";
            this.gpUtilizador.ResumeLayout(false);
            this.gpUtilizador.PerformLayout();
            this.gbProgramador.ResumeLayout(false);
            this.gbProgramador.PerformLayout();
            this.gbGestor.ResumeLayout(false);
            this.gbGestor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRegistar;
        private System.Windows.Forms.Button btVoltar;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConfirmarPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpUtilizador;
        private System.Windows.Forms.RadioButton rbGestor;
        private System.Windows.Forms.RadioButton rbProgramador;
        private System.Windows.Forms.RadioButton rbUtilizadorComum;
        private System.Windows.Forms.GroupBox gbProgramador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbGestor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbGestor;
        private System.Windows.Forms.ComboBox cbExperiencia;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.CheckBox cbxGereUtilizadores;
    }
}