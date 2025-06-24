namespace iTasks.Views
{
    partial class frmPrevisaoDeConclusao
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
            this.txbMinutos = new System.Windows.Forms.TextBox();
            this.btnRefreshTempoPrevisto = new System.Windows.Forms.Button();
            this.lbTarefasToDo = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbHoras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPrevisaoDeConclusao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbMinutos
            // 
            this.txbMinutos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbMinutos.Location = new System.Drawing.Point(183, 76);
            this.txbMinutos.Name = "txbMinutos";
            this.txbMinutos.ReadOnly = true;
            this.txbMinutos.Size = new System.Drawing.Size(55, 20);
            this.txbMinutos.TabIndex = 6;
            // 
            // btnRefreshTempoPrevisto
            // 
            this.btnRefreshTempoPrevisto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshTempoPrevisto.Location = new System.Drawing.Point(70, 125);
            this.btnRefreshTempoPrevisto.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshTempoPrevisto.Name = "btnRefreshTempoPrevisto";
            this.btnRefreshTempoPrevisto.Size = new System.Drawing.Size(56, 19);
            this.btnRefreshTempoPrevisto.TabIndex = 1;
            this.btnRefreshTempoPrevisto.Text = "Refresh";
            this.btnRefreshTempoPrevisto.UseVisualStyleBackColor = true;
            this.btnRefreshTempoPrevisto.Click += new System.EventHandler(this.btnRefreshTempoPrevisto_Click);
            // 
            // lbTarefasToDo
            // 
            this.lbTarefasToDo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTarefasToDo.AutoSize = true;
            this.lbTarefasToDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTarefasToDo.Location = new System.Drawing.Point(67, 57);
            this.lbTarefasToDo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTarefasToDo.Name = "lbTarefasToDo";
            this.lbTarefasToDo.Size = new System.Drawing.Size(236, 16);
            this.lbTarefasToDo.TabIndex = 2;
            this.lbTarefasToDo.Text = "Tempo previsto para as tarefas ToDo:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVoltar.Location = new System.Drawing.Point(247, 125);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(56, 19);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "h";
            // 
            // txbHoras
            // 
            this.txbHoras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbHoras.Location = new System.Drawing.Point(111, 76);
            this.txbHoras.Name = "txbHoras";
            this.txbHoras.ReadOnly = true;
            this.txbHoras.Size = new System.Drawing.Size(55, 20);
            this.txbHoras.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "m";
            // 
            // lbPrevisaoDeConclusao
            // 
            this.lbPrevisaoDeConclusao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPrevisaoDeConclusao.AutoSize = true;
            this.lbPrevisaoDeConclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrevisaoDeConclusao.Location = new System.Drawing.Point(11, 9);
            this.lbPrevisaoDeConclusao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrevisaoDeConclusao.Name = "lbPrevisaoDeConclusao";
            this.lbPrevisaoDeConclusao.Size = new System.Drawing.Size(350, 37);
            this.lbPrevisaoDeConclusao.TabIndex = 0;
            this.lbPrevisaoDeConclusao.Text = "Previsao De Conclusão";
            // 
            // frmPrevisaoDeConclusao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 155);
            this.Controls.Add(this.txbMinutos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbHoras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lbTarefasToDo);
            this.Controls.Add(this.btnRefreshTempoPrevisto);
            this.Controls.Add(this.lbPrevisaoDeConclusao);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPrevisaoDeConclusao";
            this.Text = "frmPrevisaoDeConclusao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbMinutos;
        private System.Windows.Forms.Button btnRefreshTempoPrevisto;
        private System.Windows.Forms.Label lbTarefasToDo;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbHoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPrevisaoDeConclusao;
    }
}