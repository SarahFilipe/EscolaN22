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
    public partial class TelaCadastroProfessor : Form

    {
        private Professor _userLogado;
        private List<Professor> _professores;
        private Professor _professorSelecionado;

        public TelaCadastroProfessor(Usuario userLogado)
        {
            InitializeComponent();           

            try
            {
                _professores = Usuario.BuscarUsuarios().ConvertAll(u => (Professor)u);
                _userLogado = (Professor)userLogado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
