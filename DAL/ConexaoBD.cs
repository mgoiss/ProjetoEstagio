using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexaoBD
    {
        public static IDbConnection AbrirConexao()
        {
            return new SqlConnection("Data Source=NAVE;Initial Catalog=ProjetoEstagio;Integrated Security=True");
        }
    }

}
