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
        private List<Aluno> _alunos;

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public TelaPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _userLogado = usuario;
            _alunos = Usuario.BuscarUsuariosA().ConvertAll(u => (Aluno)u);                        
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            if (_userLogado is Aluno)
            {            
                TslPerfil.Text = "Aluno";                
                TslCadastro.Visible = false;
            }
            else
            {
                Professor professor = (Professor)_userLogado;                
                TslPerfil.Text = "Professor";               
            }
            
            TslNomeUserLogado.Text = _userLogado.Nome;
            TslEmailUserLogado.Text = _userLogado.Email;
            TslDataHora.Text = DateTime.Now.ToString();
            TmrRelogio.Interval = 1000;
            TmrRelogio.Enabled = true;

            LblAlunosAtivos.Text = _alunos.Where(aluno => aluno.Ativo == true).Count().ToString();
            LblTotalAlunos.Text = _alunos.Count.ToString();
            LblAlunosRemovidos.Text = _alunos.Where(aluno => aluno.Ativo == false).Count().ToString();

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
                telaCadastro.MdiParent = this;
                telaCadastro.Show();

        }

        private void TslCadastroProfessor_Click(object sender, EventArgs e)
        {
            Professor professor = (Professor)_userLogado;

            TelaCadastroProfessor telaCadastro = new TelaCadastroProfessor(_userLogado);

            telaCadastro.MdiParent = this;
            telaCadastro.Show();  
            
            
        }

        private void TmrRelogio_Tick(object sender, EventArgs e)
        {
            TslDataHora.Text = DateTime.Now.ToString() ;

            try
            {
                _alunos = Usuario.BuscarUsuariosA().ConvertAll(u => (Aluno)u);

                LblAlunosAtivos.Text = _alunos.Where(aluno => aluno.Ativo == true).Count().ToString();
                LblTotalAlunos.Text = _alunos.Count.ToString();
                LblAlunosRemovidos.Text = _alunos.Where(aluno => aluno.Ativo == false).Count().ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

    }
}

