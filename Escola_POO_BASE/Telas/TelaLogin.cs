using Escola_POO_BASE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Telas
{
    public partial class TelaLogin : Form
    {       
        
        public TelaLogin()
        {
            InitializeComponent();
          
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                Usuario userLogado = Usuario.RealizarLogin(TxtEmail.Text, TxtSenha.Text, RBtnProfessor.Checked);
                
                if(userLogado.Senha == Crypto.Sha256("123"))
                {
                    TelaAlterarSenha telaAlterarSenha = new TelaAlterarSenha(userLogado);                    
                    telaAlterarSenha.ShowDialog();                   
                    TxtSenha.Clear();
                    TxtSenha.Focus();
                }
                else
                {
                    TelaPrincipal tlPrincipal = new TelaPrincipal(userLogado);
                    this.Hide();
                    tlPrincipal.ShowDialog();
                    this.Show();
                    TxtSenha.Clear();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin.PerformClick();
            }

        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin.PerformClick();
            }
        }

        private void RBtnProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin.PerformClick();
            }
        }

        private void RBtnAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin.PerformClick();
            }
        }


    }
}
