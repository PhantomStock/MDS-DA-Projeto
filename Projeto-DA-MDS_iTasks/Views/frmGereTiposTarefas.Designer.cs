namespace iTasks
{
    partial class frmGereTiposTarefas
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
            this.lstLista = new System.Windows.Forms.ListBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btnCriarTipoTarefa = new System.Windows.Forms.Button();
            this.btnEliminarTipoTarefa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.lstLista);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Tipos de Tarefas";
            // 
            // lstLista
            // 
            this.lstLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lstLista.FormattingEnabled = true;
            this.lstLista.Location = new System.Drawing.Point(3, 14);
            this.lstLista.Name = "lstLista";
            this.lstLista.Size = new System.Drawing.Size(269, 369);
            this.lstLista.TabIndex = 0;
            this.lstLista.SelectedIndexChanged += new System.EventHandler(this.lstLista_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDesc.Location = new System.Drawing.Point(359, 54);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(286, 20);
            this.txtDesc.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Descrição:";
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtId.Location = new System.Drawing.Point(359, 28);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(62, 20);
            this.txtId.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Id:";
            // 
            // btGravar
            // 
            this.btGravar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btGravar.Location = new System.Drawing.Point(533, 108);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(111, 23);
            this.btGravar.TabIndex = 31;
            this.btGravar.Text = "Gravar Dados";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btnCriarTipoTarefa
            // 
            this.btnCriarTipoTarefa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCriarTipoTarefa.Location = new System.Drawing.Point(417, 108);
            this.btnCriarTipoTarefa.Name = "btnCriarTipoTarefa";
            this.btnCriarTipoTarefa.Size = new System.Drawing.Size(111, 23);
            this.btnCriarTipoTarefa.TabIndex = 32;
            this.btnCriarTipoTarefa.Text = "Limpar";
            this.btnCriarTipoTarefa.UseVisualStyleBackColor = true;
            this.btnCriarTipoTarefa.Click += new System.EventHandler(this.btnCriarTipoTarefa_Click);
            // 
            // btnEliminarTipoTarefa
            // 
            this.btnEliminarTipoTarefa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminarTipoTarefa.Location = new System.Drawing.Point(300, 108);
            this.btnEliminarTipoTarefa.Name = "btnEliminarTipoTarefa";
            this.btnEliminarTipoTarefa.Size = new System.Drawing.Size(111, 23);
            this.btnEliminarTipoTarefa.TabIndex = 33;
            this.btnEliminarTipoTarefa.Text = "Eliminar";
            this.btnEliminarTipoTarefa.UseVisualStyleBackColor = true;
            this.btnEliminarTipoTarefa.Click += new System.EventHandler(this.btnEliminarTipoTarefa_Click);
            // 
            // frmGereTiposTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 404);
            this.Controls.Add(this.btnEliminarTipoTarefa);
            this.Controls.Add(this.btnCriarTipoTarefa);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGereTiposTarefas";
            this.Text = "frmGereTiposTarefas";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstLista;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btnCriarTipoTarefa;
        private System.Windows.Forms.Button btnEliminarTipoTarefa;
    }
}