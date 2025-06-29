﻿namespace iTasks
{
    partial class frmKanban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKanban));
            this.lstTodo = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDoing = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstDone = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarTodasAsTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarTarefaPorFazerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarTarefaEmExecuçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarTarefaConcluidaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarTodasAsTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarTarefasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarTarefasEmExecuçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarTarefasConcluidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirUtilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirTiposDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefasTerminadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefasEmCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetDoing = new System.Windows.Forms.Button();
            this.btSetDone = new System.Windows.Forms.Button();
            this.btSetTodo = new System.Windows.Forms.Button();
            this.btNova = new System.Windows.Forms.Button();
            this.labelNomeUtilizador = new System.Windows.Forms.Label();
            this.btnPrevisao = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEliminarTarefa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTodo
            // 
            this.lstTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTodo.FormattingEnabled = true;
            this.lstTodo.Location = new System.Drawing.Point(3, 18);
            this.lstTodo.Name = "lstTodo";
            this.lstTodo.Size = new System.Drawing.Size(317, 407);
            this.lstTodo.TabIndex = 0;
            this.lstTodo.SelectedIndexChanged += new System.EventHandler(this.lstTodo_SelectedIndexChanged);
            this.lstTodo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTodo_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.lstTodo);
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 434);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ToDo";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.lstDoing);
            this.groupBox2.Location = new System.Drawing.Point(342, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 434);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doing";
            // 
            // lstDoing
            // 
            this.lstDoing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDoing.FormattingEnabled = true;
            this.lstDoing.Location = new System.Drawing.Point(3, 18);
            this.lstDoing.Name = "lstDoing";
            this.lstDoing.Size = new System.Drawing.Size(317, 407);
            this.lstDoing.TabIndex = 0;
            this.lstDoing.SelectedIndexChanged += new System.EventHandler(this.lstDoing_SelectedIndexChanged);
            this.lstDoing.DoubleClick += new System.EventHandler(this.lstDoing_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox3.Controls.Add(this.lstDone);
            this.groupBox3.Location = new System.Drawing.Point(670, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 434);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Done";
            // 
            // lstDone
            // 
            this.lstDone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDone.FormattingEnabled = true;
            this.lstDone.Location = new System.Drawing.Point(3, 18);
            this.lstDone.Name = "lstDone";
            this.lstDone.Size = new System.Drawing.Size(317, 407);
            this.lstDone.TabIndex = 0;
            this.lstDone.SelectedIndexChanged += new System.EventHandler(this.lstDone_SelectedIndexChanged);
            this.lstDone.DoubleClick += new System.EventHandler(this.lstDone_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.utilizadoresToolStripMenuItem,
            this.listagensToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(296, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.exportarParaCSVToolStripMenuItem,
            this.importarTarefasToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // exportarParaCSVToolStripMenuItem
            // 
            this.exportarParaCSVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarTodasAsTarefasToolStripMenuItem,
            this.exportarTarefaPorFazerToolStripMenuItem,
            this.exportarTarefaEmExecuçãoToolStripMenuItem,
            this.exportarTarefaConcluidaToolStripMenuItem1});
            this.exportarParaCSVToolStripMenuItem.Name = "exportarParaCSVToolStripMenuItem";
            this.exportarParaCSVToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.exportarParaCSVToolStripMenuItem.Text = "Exportar Tarefas";
            // 
            // exportarTodasAsTarefasToolStripMenuItem
            // 
            this.exportarTodasAsTarefasToolStripMenuItem.Name = "exportarTodasAsTarefasToolStripMenuItem";
            this.exportarTodasAsTarefasToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.exportarTodasAsTarefasToolStripMenuItem.Text = "Exportar Todas as Tarefas";
            this.exportarTodasAsTarefasToolStripMenuItem.Click += new System.EventHandler(this.exportarTodasAsTarefasToolStripMenuItem_Click);
            // 
            // exportarTarefaPorFazerToolStripMenuItem
            // 
            this.exportarTarefaPorFazerToolStripMenuItem.Name = "exportarTarefaPorFazerToolStripMenuItem";
            this.exportarTarefaPorFazerToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.exportarTarefaPorFazerToolStripMenuItem.Text = "Exportar Tarefa Por Fazer";
            this.exportarTarefaPorFazerToolStripMenuItem.Click += new System.EventHandler(this.exportarTarefaPorFazerToolStripMenuItem_Click);
            // 
            // exportarTarefaEmExecuçãoToolStripMenuItem
            // 
            this.exportarTarefaEmExecuçãoToolStripMenuItem.Name = "exportarTarefaEmExecuçãoToolStripMenuItem";
            this.exportarTarefaEmExecuçãoToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.exportarTarefaEmExecuçãoToolStripMenuItem.Text = "Exportar Tarefa em execução";
            this.exportarTarefaEmExecuçãoToolStripMenuItem.Click += new System.EventHandler(this.exportarTarefaEmExecuçãoToolStripMenuItem_Click);
            // 
            // exportarTarefaConcluidaToolStripMenuItem1
            // 
            this.exportarTarefaConcluidaToolStripMenuItem1.Name = "exportarTarefaConcluidaToolStripMenuItem1";
            this.exportarTarefaConcluidaToolStripMenuItem1.Size = new System.Drawing.Size(250, 24);
            this.exportarTarefaConcluidaToolStripMenuItem1.Text = "Exportar Tarefa Concluida";
            this.exportarTarefaConcluidaToolStripMenuItem1.Click += new System.EventHandler(this.exportarTarefaConcluidaToolStripMenuItem1_Click);
            // 
            // importarTarefasToolStripMenuItem
            // 
            this.importarTarefasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarTodasAsTarefasToolStripMenuItem,
            this.importarTarefasToolStripMenuItem1,
            this.importarTarefasEmExecuçãoToolStripMenuItem,
            this.importarTarefasConcluidasToolStripMenuItem});
            this.importarTarefasToolStripMenuItem.Name = "importarTarefasToolStripMenuItem";
            this.importarTarefasToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.importarTarefasToolStripMenuItem.Text = "Importar Tarefas";
            // 
            // importarTodasAsTarefasToolStripMenuItem
            // 
            this.importarTodasAsTarefasToolStripMenuItem.Name = "importarTodasAsTarefasToolStripMenuItem";
            this.importarTodasAsTarefasToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.importarTodasAsTarefasToolStripMenuItem.Text = "Importar Todas as Tarefas";
            this.importarTodasAsTarefasToolStripMenuItem.Click += new System.EventHandler(this.importarTodasAsTarefasToolStripMenuItem_Click);
            // 
            // importarTarefasToolStripMenuItem1
            // 
            this.importarTarefasToolStripMenuItem1.Name = "importarTarefasToolStripMenuItem1";
            this.importarTarefasToolStripMenuItem1.Size = new System.Drawing.Size(259, 24);
            this.importarTarefasToolStripMenuItem1.Text = "Importar Tarefas Por Concluir";
            this.importarTarefasToolStripMenuItem1.Click += new System.EventHandler(this.importarTarefasToolStripMenuItem1_Click);
            // 
            // importarTarefasEmExecuçãoToolStripMenuItem
            // 
            this.importarTarefasEmExecuçãoToolStripMenuItem.Name = "importarTarefasEmExecuçãoToolStripMenuItem";
            this.importarTarefasEmExecuçãoToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.importarTarefasEmExecuçãoToolStripMenuItem.Text = "Importar Tarefas em execução";
            this.importarTarefasEmExecuçãoToolStripMenuItem.Click += new System.EventHandler(this.importarTarefasEmExecuçãoToolStripMenuItem_Click);
            // 
            // importarTarefasConcluidasToolStripMenuItem
            // 
            this.importarTarefasConcluidasToolStripMenuItem.Name = "importarTarefasConcluidasToolStripMenuItem";
            this.importarTarefasConcluidasToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.importarTarefasConcluidasToolStripMenuItem.Text = "Importar Tarefas Concluidas";
            this.importarTarefasConcluidasToolStripMenuItem.Click += new System.EventHandler(this.importarTarefasConcluidasToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerirUtilizadoresToolStripMenuItem,
            this.gerirTiposDeTarefasToolStripMenuItem});
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(144, 23);
            this.utilizadoresToolStripMenuItem.Text = "Gestão da Aplicação";
            // 
            // gerirUtilizadoresToolStripMenuItem
            // 
            this.gerirUtilizadoresToolStripMenuItem.Name = "gerirUtilizadoresToolStripMenuItem";
            this.gerirUtilizadoresToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.gerirUtilizadoresToolStripMenuItem.Text = "Gerir Utilizadores";
            this.gerirUtilizadoresToolStripMenuItem.Click += new System.EventHandler(this.gerirUtilizadoresToolStripMenuItem_Click);
            // 
            // gerirTiposDeTarefasToolStripMenuItem
            // 
            this.gerirTiposDeTarefasToolStripMenuItem.Name = "gerirTiposDeTarefasToolStripMenuItem";
            this.gerirTiposDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.gerirTiposDeTarefasToolStripMenuItem.Text = "Gerir Tipos de Tarefas";
            this.gerirTiposDeTarefasToolStripMenuItem.Click += new System.EventHandler(this.gerirTiposDeTarefasToolStripMenuItem_Click);
            // 
            // listagensToolStripMenuItem
            // 
            this.listagensToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarefasTerminadasToolStripMenuItem,
            this.tarefasEmCursoToolStripMenuItem});
            this.listagensToolStripMenuItem.Name = "listagensToolStripMenuItem";
            this.listagensToolStripMenuItem.Size = new System.Drawing.Size(78, 23);
            this.listagensToolStripMenuItem.Text = "Listagens";
            // 
            // tarefasTerminadasToolStripMenuItem
            // 
            this.tarefasTerminadasToolStripMenuItem.Name = "tarefasTerminadasToolStripMenuItem";
            this.tarefasTerminadasToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.tarefasTerminadasToolStripMenuItem.Text = "Tarefas Concluídas";
            this.tarefasTerminadasToolStripMenuItem.Click += new System.EventHandler(this.tarefasTerminadasToolStripMenuItem_Click);
            // 
            // tarefasEmCursoToolStripMenuItem
            // 
            this.tarefasEmCursoToolStripMenuItem.Name = "tarefasEmCursoToolStripMenuItem";
            this.tarefasEmCursoToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.tarefasEmCursoToolStripMenuItem.Text = "Tarefas em Curso";
            this.tarefasEmCursoToolStripMenuItem.Click += new System.EventHandler(this.tarefasEmCursoToolStripMenuItem_Click);
            // 
            // btSetDoing
            // 
            this.btSetDoing.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSetDoing.Location = new System.Drawing.Point(176, 494);
            this.btSetDoing.Name = "btSetDoing";
            this.btSetDoing.Size = new System.Drawing.Size(156, 22);
            this.btSetDoing.TabIndex = 5;
            this.btSetDoing.Text = "Executar Tarefa >>";
            this.btSetDoing.UseVisualStyleBackColor = true;
            this.btSetDoing.Click += new System.EventHandler(this.btSetDoing_Click);
            // 
            // btSetDone
            // 
            this.btSetDone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSetDone.Location = new System.Drawing.Point(506, 494);
            this.btSetDone.Name = "btSetDone";
            this.btSetDone.Size = new System.Drawing.Size(154, 22);
            this.btSetDone.TabIndex = 6;
            this.btSetDone.Text = "Terminar Tarefa >>";
            this.btSetDone.UseVisualStyleBackColor = true;
            this.btSetDone.Click += new System.EventHandler(this.btSetDone_Click);
            // 
            // btSetTodo
            // 
            this.btSetTodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSetTodo.Location = new System.Drawing.Point(345, 494);
            this.btSetTodo.Name = "btSetTodo";
            this.btSetTodo.Size = new System.Drawing.Size(154, 22);
            this.btSetTodo.TabIndex = 7;
            this.btSetTodo.Text = "<< Reiniciar Tarefa";
            this.btSetTodo.UseVisualStyleBackColor = true;
            this.btSetTodo.Click += new System.EventHandler(this.btSetTodo_Click);
            // 
            // btNova
            // 
            this.btNova.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btNova.Location = new System.Drawing.Point(16, 494);
            this.btNova.Name = "btNova";
            this.btNova.Size = new System.Drawing.Size(111, 22);
            this.btNova.TabIndex = 8;
            this.btNova.Text = "Nova Tarefa";
            this.btNova.UseVisualStyleBackColor = true;
            this.btNova.Click += new System.EventHandler(this.btNova_Click);
            // 
            // labelNomeUtilizador
            // 
            this.labelNomeUtilizador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelNomeUtilizador.AutoSize = true;
            this.labelNomeUtilizador.Location = new System.Drawing.Point(830, 34);
            this.labelNomeUtilizador.Name = "labelNomeUtilizador";
            this.labelNomeUtilizador.Size = new System.Drawing.Size(149, 13);
            this.labelNomeUtilizador.TabIndex = 9;
            this.labelNomeUtilizador.Text = "Bem vindo: <Nome Utilizador>";
            // 
            // btnPrevisao
            // 
            this.btnPrevisao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrevisao.Location = new System.Drawing.Point(13, 29);
            this.btnPrevisao.Name = "btnPrevisao";
            this.btnPrevisao.Size = new System.Drawing.Size(178, 22);
            this.btnPrevisao.TabIndex = 10;
            this.btnPrevisao.Text = "Ver Previsão de Conclusão";
            this.btnPrevisao.UseVisualStyleBackColor = true;
            this.btnPrevisao.Click += new System.EventHandler(this.btnPrevisao_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(955, 488);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 31);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEliminarTarefa
            // 
            this.btnEliminarTarefa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEliminarTarefa.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarTarefa.Image")));
            this.btnEliminarTarefa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarTarefa.Location = new System.Drawing.Point(786, 494);
            this.btnEliminarTarefa.Name = "btnEliminarTarefa";
            this.btnEliminarTarefa.Size = new System.Drawing.Size(154, 22);
            this.btnEliminarTarefa.TabIndex = 12;
            this.btnEliminarTarefa.Text = "Eliminar tarefa";
            this.btnEliminarTarefa.UseVisualStyleBackColor = true;
            this.btnEliminarTarefa.Click += new System.EventHandler(this.EliminarTarefa_Click);
            // 
            // frmKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1006, 529);
            this.Controls.Add(this.btnEliminarTarefa);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPrevisao);
            this.Controls.Add(this.labelNomeUtilizador);
            this.Controls.Add(this.btNova);
            this.Controls.Add(this.btSetTodo);
            this.Controls.Add(this.btSetDone);
            this.Controls.Add(this.btSetDoing);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKanban";
            this.Text = "frmKanban";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKanban_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstDoing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstDone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirUtilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirTiposDeTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarParaCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarefasTerminadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarefasEmCursoToolStripMenuItem;
        private System.Windows.Forms.Button btSetDoing;
        private System.Windows.Forms.Button btSetDone;
        private System.Windows.Forms.Button btSetTodo;
        private System.Windows.Forms.Button btNova;
        private System.Windows.Forms.Label labelNomeUtilizador;
        private System.Windows.Forms.Button btnPrevisao;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblRefreshbtnSim;
        private System.Windows.Forms.ToolStripMenuItem importarTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarTodasAsTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarTarefaPorFazerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarTarefaEmExecuçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarTarefaConcluidaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importarTodasAsTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarTarefasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importarTarefasEmExecuçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarTarefasConcluidasToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEliminarTarefa;
    }
}