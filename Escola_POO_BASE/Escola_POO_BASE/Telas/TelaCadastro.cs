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
    public partial class TelaCadastro : Form
    {
        private List<Usuario> _usuarios;    
        
        public TelaCadastro(List<Usuario> usuarios)
        {
            InitializeComponent();
            _usuarios = usuarios;   
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno(0, TxtNome.Text, DTPNascimento.Value, DTPMatricula.Value, TxtEmail.Text, "123", true);
                aluno.Cadastrar(_usuarios);

                MessageBox.Show($"Aluno {aluno.Nome} cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch ( Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
