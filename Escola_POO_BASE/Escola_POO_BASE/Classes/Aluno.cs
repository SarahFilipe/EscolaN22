using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Classes
{
    public class Aluno : Usuario
    {
        #region Proriedades

        public DateTime DtMatricula { get; set; }

        #endregion

        #region Construtores
        public Aluno()
        {

        }
        public Aluno(int id, string nome, DateTime dtNascimento, DateTime dtMtricula, string email, string senha, bool ativo) : base(id, nome, dtNascimento, email, senha, ativo)
        {

            DtMatricula = dtMtricula;

        }
        #endregion

        #region Métodos

        public void Cadastrar(List<Usuario> usuarios)
        {
            try
            {
                usuarios.Add(this);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }

}



