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
        private List<Usuario> _usuarios;

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public TelaPrincipal(Usuario usuario, List<Usuario>usuarios)
        {
            InitializeComponent();
            _userLogado = usuario;
            _usuarios =  usuarios;
            
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            if (_userLogado is Aluno)
            {
                Aluno aluno = (Aluno)_userLogado;

                LblBemVindo.Text = $"Bem Vindo {_userLogado.Nome}";
                TslNomeUserLogado.Text = _userLogado.Nome;
                TslEmailUserLogado.Text = _userLogado.Email;
                TslPerfil.Text = "Aluno";
            }
            else
            {
                Professor professor = (Professor)_userLogado;

                LblBemVindo.Text = $"Bem Vindo {_userLogado.Nome}";
                TslNomeUserLogado.Text = _userLogado.Nome;
                TslEmailUserLogado.Text = _userLogado.Email;
                TslPerfil.Text = "Professor";
            }
                    
        }

        private void TslAlterarSenha_Click(object sender, EventArgs e)
        {
            TelaAlterarSenha telaAlterarSenha = new TelaAlterarSenha(_userLogado);
            telaAlterarSenha.ShowDialog();
        }

        private void TslCadastroAluno_Click(object sender, EventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro(_usuarios);
            telaCadastro.ShowDialog();  
        }
    }
}

