using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Classes
{
    public class Usuario
    {
        #region Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        #endregion

        #region Construtores

        public Usuario()
        {

        }

        public Usuario(int id, string nome, DateTime dtNascimento, string email, string senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            DtNascimento = dtNascimento;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }

        #endregion

        #region Métodos

        #region Antigo RealizarLogin Sem BANCO
        //public static Usuario RealizarLogin(string email, string senha, List<Usuario> usuarios)
        //{
        //    Usuario usuario = usuarios.Find(a => a.Email == email);

        //    try
        //    {
        //        if (usuario == null)
        //        {
        //            // sera lançado um erro pq o email nao foi encotrado.
        //            throw new Exception("E-mail inexistente!");
        //        }
        //        else
        //        {
        //            if (usuario.Senha == senha)
        //            {
        //                if (usuario.Ativo)
        //                {
        //                    //com acesso
        //                    return usuario;
        //                }
        //                else
        //                {
        //                    // usuario bloqueado
        //                    throw new Exception("Usuário bloqueado");

        //                }
        //            }
        //            else
        //            {
        //                // senha errada
        //                throw new Exception("Senha incorreta");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region Antiga Lista de usuários
            //public static List<Usuario> GetUsuarios()
        //{
        //    List<Usuario> usuarios = new List<Usuario>();
        //    Usuario aluno1 = new Aluno(1, "João Pereira", Convert.ToDateTime("12/02/1995"), Convert.ToDateTime("20/05/2020"), "joao@gmail", "123", true);
        //    Usuario aluno2 = new Aluno(2, "Ana Júlia", Convert.ToDateTime("28/06/1993"), Convert.ToDateTime("20/02/2020"), "ana@gmail", "123", true);
        //    Usuario aluno3 = new Aluno(3, "Kayena Almeida", Convert.ToDateTime("20/08/1997"), Convert.ToDateTime("10/05/2020"), "kayena@gmail", "123", true);

        //    Usuario professor1 = new Professor(1, "Guilherme Almeida", Convert.ToDateTime("10/05/1981"), ("284.648.954-55"), "g.almeida@gmail", "123", 3, true);
        //    Usuario professor2 = new Professor(2, "Paulo Andrade", Convert.ToDateTime("20/11/1973"), ("357.188.984-16"), "pauloandrade@gmail", "123", 3, true);
        //    Usuario professor3 = new Professor(3, "João Carlos", Convert.ToDateTime("16/05/1977"), ("261.166.481-35"), "joaocarlos@gmail", "123", 3, true);




        //    usuarios.Add(aluno1);
        //    usuarios.Add(aluno2);
        //    usuarios.Add(aluno3);

        //    usuarios.Add(professor1);
        //    usuarios.Add(professor2);
        //    usuarios.Add(professor3);

        //    return usuarios;

        //}
        #endregion

        public static Usuario RealizarLogin(string email, string senha, bool check)
        {
            Conexao cn;
            Usuario usuario;

            try
            {
                if (check)
                {
                    string query = ($"select * from Professor where Email = '{email}'");
                    cn = new Conexao(query);

                    cn.AbrirConexao();
                    cn.dr = cn.comando.ExecuteReader();
                    Professor professor = new Professor();

                    if (cn.dr.HasRows == true)
                    {
                        while (cn.dr.Read())
                        {

                            professor.Id = Convert.ToInt32(cn.dr[0]);
                            professor.Nome = cn.dr[1].ToString();
                            professor.DtNascimento = Convert.ToDateTime(cn.dr[2]);
                            professor.CPF = cn.dr[3].ToString();
                            professor.Email = cn.dr[4].ToString();
                            professor.Senha = cn.dr[5].ToString();
                            professor.NivelAcesso = Convert.ToInt32(cn.dr[6]);
                            professor.Ativo = Convert.ToBoolean(cn.dr[7]);

                        }

                    }
                    else
                    {

                        // Não teve retorno de linhas
                        throw new Exception("E-mail inexistente!");

                    }

                    usuario = professor;

                    if (usuario.Senha == Crypto.Sha256(senha))
                    {
                        if (usuario.Ativo)
                        {
                            //com acesso
                            return usuario;
                        }
                        else
                        {
                            // usuario bloqueado
                            throw new Exception("Usuário bloqueado");

                        }
                    }
                    else
                    {
                        // senha errada
                        throw new Exception("Senha incorreta");
                    }

                }
                else
                {
                    string query = ($"select * from Aluno where Email = '{email}'");
                    cn = new Conexao(query);

                    cn.AbrirConexao();
                    cn.dr = cn.comando.ExecuteReader();
                    Aluno aluno = new Aluno();

                    if (cn.dr.HasRows == true)
                    {
                        while (cn.dr.Read())
                        {

                            aluno.Id = Convert.ToInt32(cn.dr[0]);
                            aluno.Nome = cn.dr[1].ToString();
                            aluno.DtNascimento = Convert.ToDateTime(cn.dr[2]);
                            aluno.DtMatricula = Convert.ToDateTime(cn.dr[3]);
                            aluno.Email = cn.dr[4].ToString();
                            aluno.Senha = cn.dr[5].ToString();
                            aluno.Ativo = Convert.ToBoolean(cn.dr[6]);


                        }

                    }
                    else
                    {

                        // Não teve retorno de linhas
                        throw new Exception("E-mail inexistente!");

                    }

                    usuario = aluno;

                    if (usuario.Senha == Crypto.Sha256(senha))
                    {
                        if (usuario.Ativo)
                        {
                            //com acesso
                            return usuario;
                        }
                        else
                        {
                            // usuario bloqueado
                            throw new Exception("Usuário bloqueado");

                        }
                    }
                    else
                    {
                        // senha errada
                        throw new Exception("Senha incorreta");
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confSenha)
        {

            try
            {
                string query;

                if (this is Professor)
                {
                    query = string.Format($"UPDATE Professor SET Senha = '{Crypto.Sha256(novaSenha)}' WHERE Id = {Id}");
                }
                else
                {
                    query = string.Format($"UPDATE Aluno SET Senha = '{Crypto.Sha256(novaSenha)}' WHERE Id = {Id}");
                }

                Conexao cn = new Conexao(query);

                if (Senha == Crypto.Sha256(senhaAtual))
                {
                    if (novaSenha != senhaAtual)
                    {
                        if (novaSenha == confSenha)
                        {
                            cn.AbrirConexao();
                            cn.comando.ExecuteNonQuery();
                            Senha = Crypto.Sha256(novaSenha);
                        }
                        else
                        {
                            throw new Exception("Nova senha não confere!");
                        }
                    }
                    else
                    {
                        throw new Exception("Digite uma senha diferente");
                    }
                }
                else
                {
                    throw new Exception("Senha atual não confere!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
     
        public static List<Usuario> BuscarUsuarios()
        {
            string query = ("Select * from Aluno");
            Conexao cn = new Conexao(query);
            
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                cn.AbrirConexao();
                cn.dr = cn.comando.ExecuteReader(); 

                while (cn.dr.Read())
                {
                    usuarios.Add(new Aluno()
                    {
                        Id = Convert.ToInt32(cn.dr[0]),
                        Nome = Convert.ToString(cn.dr[1]),
                        DtNascimento = Convert.ToDateTime(cn.dr[2]),
                        DtMatricula = Convert.ToDateTime(cn.dr[3]),
                        Email = Convert.ToString(cn.dr[4]),
                        Senha = Convert.ToString(cn.dr[5]),
                        Ativo = Convert.ToBoolean(cn.dr[6])
                    });
                }
                return usuarios;     
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }

}
