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

        public static Usuario RealizarLogin(string email, string senha, List<Usuario> usuarios)
        {
            Usuario usuario = usuarios.Find(a => a.Email == email);

            try
            {
                if (usuario == null)
                {
                    // sera lançado um erro pq o email nao foi encotrado.
                    throw new Exception("E-mail inexistente!");
                }
                else
                {
                    if (usuario.Senha == senha)
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
                if (Senha == senhaAtual)
                {
                   if (novaSenha != senhaAtual)
                    {
                        if (novaSenha == confSenha)
                        {
                            Senha = novaSenha;
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
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario aluno1 = new Aluno(1, "João Pereira", Convert.ToDateTime("12/02/1995"), Convert.ToDateTime("20/05/2020"), "joao@gmail", "123", true);
            Usuario aluno2 = new Aluno(2, "Ana Júlia", Convert.ToDateTime("28/06/1993"), Convert.ToDateTime("20/02/2020"), "ana@gmail", "123", true);
            Usuario aluno3 = new Aluno(3, "Kayena Almeida", Convert.ToDateTime("20/08/1997"), Convert.ToDateTime("10/05/2020"), "kayena@gmail", "123", true);

            Usuario professor1 = new Professor(1, "Guilherme Almeida", Convert.ToDateTime("10/05/1981"), ("284.648.954-55"), "g.almeida@gmail", "123", 3, true);
            Usuario professor2 = new Professor(2, "Paulo Andrade", Convert.ToDateTime("20/11/1973"), ("357.188.984-16"), "pauloandrade@gmail", "123", 3, true);
            Usuario professor3 = new Professor(3, "João Carlos", Convert.ToDateTime("16/05/1977"), ("261.166.481-35"), "joaocarlos@gmail", "123", 3, true);




            usuarios.Add(aluno1);
            usuarios.Add(aluno2);
            usuarios.Add(aluno3);

            usuarios.Add(professor1);
            usuarios.Add(professor2);
            usuarios.Add(professor3);

            return usuarios;

        }
    }
    #endregion
}
