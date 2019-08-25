using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
 /* Esssa é a camada de dados Data Access Layer(DAL). 
 * A camada DAL é a representação da base de dados.
 * Nessa classe é onde estão os métodos de conexão ao BD.*/

    public class DALConexao
    {
        private String Conexao_string;
        private SqlConnection conexao;

        //construtor para instanciar a string de conexao
        public DALConexao(String DadosConexao)
        {
            this.conexao = new SqlConnection();
            this.Conexao_string = DadosConexao;
            this.conexao.ConnectionString = DadosConexao;
        }

        public String ConexaoString
        {
            get { return this.Conexao_string; }
            set { this.Conexao_string = value; }
        }
        public SqlConnection ObjetoConexao
        {
            get { return this.conexao; }
            set { this.conexao = value; }
        }

        public void Conectar()
        {
            this.conexao.Open();
        }
        public void Desconectar()
        {
            this.conexao.Close();
        }
    }
}

