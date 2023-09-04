using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    internal class Conexao
    {
        #region Variáveis

        //String de Conexão                                 Informações CHUMBADAS - HardCode
        private static string _strConexao = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=EscolaN22; Integrated Security=True";


        //Variáveis de uso (podem ou não serem usadas ao decorrer do projeto)
        public SqlConnection conexao = new SqlConnection(_strConexao);
        public SqlCommand comando; // Armazenar a query
        public SqlDataAdapter da; // Adaptador para alguns componentes 
        public SqlDataReader dr; // Recebe os select's
        public DataSet ds; // trabalha com múltiplas tabelas

        #endregion

        #region Construtores

        public Conexao(string query)
        {
            comando = new SqlCommand(query, conexao); // Comando montado
            da = new SqlDataAdapter(query, conexao); // Caso necessário, está pronto
            ds = new DataSet(); // Se necessário
        }

        #endregion

        #region Métodos

        // Um método para abri conexão com o banco

        public void AbrirConexao()
        {
            if(conexao.State == ConnectionState.Open)
            {
                conexao.Close();    
            }

            conexao.Open();
        }

        // Um método para fechar conexão com o banco

        public void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
