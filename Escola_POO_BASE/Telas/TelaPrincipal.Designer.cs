namespace Escola_POO_BASE.Telas
{
    partial class TelaPrincipal
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
            this.SspRodape = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TslNomeUserLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TslEmailUserLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.nadave = new System.Windows.Forms.ToolStripStatusLabel();
            this.TslPerfil = new System.Windows.Forms.ToolStripStatusLabel();
            this.TslDataHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TslAlterarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.TsiCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.TslCadastroAluno = new System.Windows.Forms.ToolStripMenuItem();
            this.TslCadastroProfessor = new System.Windows.Forms.ToolStripMenuItem();
            this.TmrRelogio = new System.Windows.Forms.Timer(this.components);
            this.SspRodape.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SspRodape
            // 
            this.SspRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TslNomeUserLogado,
            this.toolStripStatusLabel2,
            this.TslEmailUserLogado,
            this.nadave,
            this.TslPerfil,
            this.TslDataHora});
            this.SspRodape.Location = new System.Drawing.Point(0, 443);
            this.SspRodape.Name = "SspRodape";
            this.SspRodape.Size = new System.Drawing.Size(1098, 22);
            this.SspRodape.TabIndex = 1;
            this.SspRodape.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel1.Text = "Usuário Logado: ";
            // 
            // TslNomeUserLogado
            // 
            this.TslNomeUserLogado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TslNomeUserLogado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TslNomeUserLogado.Name = "TslNomeUserLogado";
            this.TslNomeUserLogado.Size = new System.Drawing.Size(36, 17);
            this.TslNomeUserLogado.Text = "Filipe";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel2.Text = "Email: ";
            // 
            // TslEmailUserLogado
            // 
            this.TslEmailUserLogado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TslEmailUserLogado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TslEmailUserLogado.Name = "TslEmailUserLogado";
            this.TslEmailUserLogado.Size = new System.Drawing.Size(103, 17);
            this.TslEmailUserLogado.Text = "filipe@gmail.com";
            // 
            // nadave
            // 
            this.nadave.Name = "nadave";
            this.nadave.Size = new System.Drawing.Size(40, 17);
            this.nadave.Text = "Perfil: ";
            // 
            // TslPerfil
            // 
            this.TslPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TslPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TslPerfil.Name = "TslPerfil";
            this.TslPerfil.Size = new System.Drawing.Size(60, 17);
            this.TslPerfil.Text = "Professor";
            // 
            // TslDataHora
            // 
            this.TslDataHora.Name = "TslDataHora";
            this.TslDataHora.Size = new System.Drawing.Size(706, 17);
            this.TslDataHora.Spring = true;
            this.TslDataHora.Text = "02/07/2023";
            this.TslDataHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.TsiCadastro});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1098, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TslAlterarSenha});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Arquivo";
            // 
            // TslAlterarSenha
            // 
            this.TslAlterarSenha.Name = "TslAlterarSenha";
            this.TslAlterarSenha.Size = new System.Drawing.Size(144, 22);
            this.TslAlterarSenha.Text = "Alterar Senha";
            this.TslAlterarSenha.Click += new System.EventHandler(this.TslAlterarSenha_Click);
            // 
            // TsiCadastro
            // 
            this.TsiCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TslCadastroAluno,
            this.TslCadastroProfessor});
            this.TsiCadastro.Name = "TsiCadastro";
            this.TsiCadastro.Size = new System.Drawing.Size(66, 20);
            this.TsiCadastro.Text = "Cadastro";
            // 
            // TslCadastroAluno
            // 
            this.TslCadastroAluno.Name = "TslCadastroAluno";
            this.TslCadastroAluno.Size = new System.Drawing.Size(123, 22);
            this.TslCadastroAluno.Text = "Aluno";
            this.TslCadastroAluno.Click += new System.EventHandler(this.TslCadastroAluno_Click);
            // 
            // TslCadastroProfessor
            // 
            this.TslCadastroProfessor.Name = "TslCadastroProfessor";
            this.TslCadastroProfessor.Size = new System.Drawing.Size(123, 22);
            this.TslCadastroProfessor.Text = "Professor";
            this.TslCadastroProfessor.Click += new System.EventHandler(this.TslCadastroProfessor_Click);
            // 
            // TmrRelogio
            // 
            this.TmrRelogio.Tick += new System.EventHandler(this.TmrRelogio_Tick);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 465);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SspRodape);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipal";
            this.Text = "TelaPrincipal";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.SspRodape.ResumeLayout(false);
            this.SspRodape.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip SspRodape;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TslNomeUserLogado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel TslEmailUserLogado;
        private System.Windows.Forms.ToolStripStatusLabel TslDataHora;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TslAlterarSenha;
        private System.Windows.Forms.ToolStripStatusLabel nadave;
        private System.Windows.Forms.ToolStripStatusLabel TslPerfil;
        private System.Windows.Forms.ToolStripMenuItem TsiCadastro;
        private System.Windows.Forms.ToolStripMenuItem TslCadastroAluno;
        private System.Windows.Forms.ToolStripMenuItem TslCadastroProfessor;
        private System.Windows.Forms.Timer TmrRelogio;
    }
}