using Escola_POO_BASE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Telas
{
    public partial class TelaPrincipal : Form
    {

        private Usuario _userLogado;        

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public TelaPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _userLogado = usuario;          
            
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            if (_userLogado is Aluno)
            {            
                TslPerfil.Text = "Aluno";
                groupBox1.Text = "Aluno";
                TsiCadastro.Visible = false;
            }
            else
            {
                Professor professor = (Professor)_userLogado;

                TslPerfil.Text = "Professor";
                groupBox1.Text = "Professor";
            }
            
            LblBemVindo.Text = $"Bem Vindo {_userLogado.Nome}";
            TslNomeUserLogado.Text = _userLogado.Nome;
            TslEmailUserLogado.Text = _userLogado.Email;
            TslDataHora.Text = DateTime.Now.ToString();

        }

        private void TslAlterarSenha_Click(object sender, EventArgs e)
        {
            TelaAlterarSenha telaAlterarSenha = new TelaAlterarSenha(_userLogado);
            telaAlterarSenha.ShowDialog();
        }

        private void TslCadastroAluno_Click(object sender, EventArgs e)
        {
            Professor professor = (Professor)_userLogado;

                TelaCadastroAluno telaCadastro = new TelaCadastroAluno(_userLogado);
                telaCadastro.ShowDialog();
           
        }

        private void TslCadastroProfessor_Click(object sender, EventArgs e)
        {
            Professor professor = (Professor)_userLogado;

            TelaCadastroProfessor telaCadastro = new TelaCadastroProfessor(_userLogado);
            telaCadastro.ShowDialog();
        }
    }
}

