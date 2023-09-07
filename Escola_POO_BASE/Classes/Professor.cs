using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    public class Professor : Usuario
    {
        #region Propriedades


        public string CPF { get; set; }
        public int NivelAcesso { get; set; }

        #endregion

        #region Construtores

        public Professor()
        {

        }

        public Professor(int id, string nome, DateTime dtNascimento, string cpf, string email, string senha, int nivelAcesso, bool ativo) : base(id, nome, dtNascimento, email, senha, ativo)
        {

            CPF = cpf;
            NivelAcesso = nivelAcesso;

        }
        #endregion

        #region Métodos

        public void Cadastrar(List<Professor> professores)
        {
            string query = ($"insert into Professor VALUES ('{Nome}', '{DtNascimento}', '{CPF}', '{Email}', '{Senha}', '{NivelAcesso}', 1)");
            query += "; SELECT SCOPE_IDENTITY()";
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirConexao();
                this.Id = Convert.ToInt32(cn.comando.ExecuteScalar());

                professores.Add(this);
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
        public void Alterar(List<Professor> professores)
        {

            string query = ($"update Professor set Nome = '{Nome}', Email = '{Email}', DtNascimento = '{DtNascimento}', Cpf = '{CPF}', NivelAcesso = '{NivelAcesso}'  where Id = {Id} ");
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

        public void Deletar(List<Professor> professores)
        {
            string query = ($"update Professor set Ativo = '{0}' where Id = {Id} ");
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
        public void Reativar(List<Professor> professores)
        {
            string query = ($"update Professor set Ativo = '{1}' where Id = {Id} ");
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
        public static List<Professor> Buscar(List<Professor> professores , int indexCbbBuscar, string texto)
        {
            switch (indexCbbBuscar)
            {
                case 0:
                    return professores.Where(a => a.Nome.ToUpper().Normalize(NormalizationForm.FormD).Contains(texto.ToUpper().Normalize(NormalizationForm.FormD))).ToList();

                case 1:
                    return professores.Where(a => a.Email.ToUpper().Normalize(NormalizationForm.FormD).Contains(texto.ToUpper().Normalize(NormalizationForm.FormD))).ToList();

                case 2:
                    return professores.Where(a => a.Id == Convert.ToInt32(texto)).ToList();

                default:
                    return professores;

            }
        }
        #endregion


    }
}
