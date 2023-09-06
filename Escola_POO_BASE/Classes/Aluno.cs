using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        public void Cadastrar(List<Aluno> alunos)
        {
            string query = ($"insert into Aluno VALUES ('{Nome}', '{DtNascimento}', '{DtMatricula}', '{Email}', '{Senha}', 1)");
            query += "; SELECT SCOPE_IDENTITY()";
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirConexao();
                this.Id = Convert.ToInt32(cn.comando.ExecuteScalar());

                alunos.Add(this);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.FecharConexao();
            }
        }
        public void Alterar(List<Aluno> alunos)
        {

            string query = ($"update Aluno set Nome = '{Nome}', Email = '{Email}', DtNascimento = '{DtNascimento}', DtMatricula = '{DtMatricula}' where Id = {Id} ");
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirConexao();
                cn.comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Deletar(List<Aluno> alunos)
        {
            string query = ($"update Aluno set Ativo = '{0}' where Id = {Id} ");
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirConexao();
                cn.comando.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

                throw;
            }
        } 

        public static List<Aluno> Buscar(List<Aluno> alunos, int indexCbbBuscar, string texto)
        {
            switch (indexCbbBuscar)
            {
                case 0:
                    return alunos.Where(a => a.Nome.ToUpper().Normalize(NormalizationForm.FormD).Contains(texto.ToUpper().Normalize(NormalizationForm.FormD))).ToList();

                case 1:
                    return alunos.Where(a => a.Email.ToUpper().Normalize(NormalizationForm.FormD).Contains(texto.ToUpper().Normalize(NormalizationForm.FormD))).ToList();

                case 2:
                    return alunos.Where(a => a.Id == Convert.ToInt32(texto)).ToList();

                default:
                    return alunos;
                   
            }
        }
        #endregion

    }

}



