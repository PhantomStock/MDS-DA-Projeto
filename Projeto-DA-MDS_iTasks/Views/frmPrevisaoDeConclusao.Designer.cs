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
            this.lbPrevisaoDeConclusao = new System.Windows.Forms.Label();
            this.lbTempoPrevisto = new System.Windows.Forms.Label();
            this.btnRefreshTempoPrevisto = new System.Windows.Forms.Button();
            this.lbTarefasToDo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPrevisaoDeConclusao
            // 
            this.lbPrevisaoDeConclusao.AutoSize = true;
            this.lbPrevisaoDeConclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrevisaoDeConclusao.Location = new System.Drawing.Point(190, 9);
            this.lbPrevisaoDeConclusao.Name = "lbPrevisaoDeConclusao";
            this.lbPrevisaoDeConclusao.Size = new System.Drawing.Size(439, 46);
            this.lbPrevisaoDeConclusao.TabIndex = 0;
            this.lbPrevisaoDeConclusao.Text = "Previsao De Conclusão";
            // 
            // lbTempoPrevisto
            // 
            this.lbTempoPrevisto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTempoPrevisto.AutoSize = true;
            this.lbTempoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempoPrevisto.Location = new System.Drawing.Point(9, 87);
            this.lbTempoPrevisto.Name = "lbTempoPrevisto";
            this.lbTempoPrevisto.Size = new System.Drawing.Size(205, 32);
            this.lbTempoPrevisto.TabIndex = 0;
            this.lbTempoPrevisto.Text = "TempoPrevisto";
            // 
            // btnRefreshTempoPrevisto
            // 
            this.btnRefreshTempoPrevisto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshTempoPrevisto.Location = new System.Drawing.Point(15, 415);
            this.btnRefreshTempoPrevisto.Name = "btnRefreshTempoPrevisto";
            this.btnRefreshTempoPrevisto.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshTempoPrevisto.TabIndex = 1;
            this.btnRefreshTempoPrevisto.Text = "Refresh";
            this.btnRefreshTempoPrevisto.UseVisualStyleBackColor = true;
            this.btnRefreshTempoPrevisto.Click += new System.EventHandler(this.btnRefreshTempoPrevisto_Click);
            // 
            // lbTarefasToDo
            // 
            this.lbTarefasToDo.AutoSize = true;
            this.lbTarefasToDo.Location = new System.Drawing.Point(12, 64);
            this.lbTarefasToDo.Name = "lbTarefasToDo";
            this.lbTarefasToDo.Size = new System.Drawing.Size(95, 16);
            this.lbTarefasToDo.TabIndex = 2;
            this.lbTarefasToDo.Text = "Tarefas ToDo:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmPrevisaoDeConclusao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbTarefasToDo);
            this.Controls.Add(this.btnRefreshTempoPrevisto);
            this.Controls.Add(this.lbTempoPrevisto);
            this.Controls.Add(this.lbPrevisaoDeConclusao);
            this.Name = "frmPrevisaoDeConclusao";
            this.Text = "frmPrevisaoDeConclusao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPrevisaoDeConclusao;
        private System.Windows.Forms.Label lbTempoPrevisto;
        private System.Windows.Forms.Button btnRefreshTempoPrevisto;
        private System.Windows.Forms.Label lbTarefasToDo;
        private System.Windows.Forms.Button button1;
    }
}