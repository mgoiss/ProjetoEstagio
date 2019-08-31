using System;
using Modelo;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DALSubCategoria
    {
        #region
        /*Percebam que CodigoCategoria foi chamado aqui dentro, pois esta classe se relaciona com a classe categoria.*/
        //Implementação do try para tratamento de erros, caso venha acontecer. 

        public static void Incluir(MSubCategoria modelo)
        {
            try
            {
                using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
                {
                    conn.Open(); //Abrindo a conexão
                    using (var comm = conn.CreateCommand()) //Criando o comando SQL
                    {
                        comm.CommandText = "Insert into subcategoria(categoria_cod, subCategoria_nome) values (@codigo, @nome); select @@IDENTITY;";
                        //Passando valores por parametro
                        comm.Parameters.Add(new SqlParameter("@codigo", modelo.subNomeCategoria));
                        comm.Parameters.Add(new SqlParameter("@nome", modelo.CodigoCategoria));
                        //Executando o comando
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static void Alterar(MSubCategoria modelo)
        {
            try
            {
                using (var conn = ConexaoBD.AbrirConexao())//Passando a string de conexão
                {
                    conn.Open(); //Abrindo a conexão
                    using (var comm = conn.CreateCommand()) //Criando o comando SQL
                    {
                        comm.CommandText = "Update subcategoria set subCategoria_nome = @nome, categoria_cod = @codigo where subCategoria_cod = @codigo; ";
                        //Passando valores por parametro
                        comm.Parameters.Add(new SqlParameter("@nome", modelo.subNomeCategoria));
                        comm.Parameters.Add(new SqlParameter("@subcodigo", modelo.subCodigoCategoria));
                        comm.Parameters.Add(new SqlParameter("@codigo", modelo.CodigoCategoria));
                        //Executando o comando
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static void Excluir(int codigo)
        {
            try
            {
                using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
                {
                    conn.Open(); //Abrindo a conexão
                    using (var comm = conn.CreateCommand()) //Criando o comando SQL
                    {
                        comm.CommandText = "Delete subcategoria where subCategoria_cod = @codigo";
                        //Passando o valores por parametro
                        comm.Parameters.Add(new SqlParameter("@codigo", codigo));
                        //Executando o comando
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
        /* Método para carregar os dados da tabela no DataGridView*/
        public static DataTable CarregarGrid()
        {
            using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
            {
                conn.Open(); //Abrindo a conexão
                using (var comm = conn.CreateCommand()) //Criando o comando SQL
                {
                    comm.CommandText = "Select sub.*, cate.categoria_nome from subcategoria as sub " +
                        "inner join categoria as cate on sub.categoria_cod = cate.categoria_cod " +
                        "order by subcategoria_cod desc";
                    var reader = comm.ExecuteReader(); //Passando o comando 
                    var table = new DataTable(); //Passando a tabela
                    table.Load(reader); //Carregando a tabela 
                    return table; //Retornando a consulta ao Banco de Dados
                }
            }
        }
        /* Método para buscar dados na base de dados e trazer para dentro do DataGridView*/
        public static DataTable LocalizarDados(String valor)
        {
            using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
            {
                conn.Open(); //Abrindo a conexão
                using (var comm = conn.CreateCommand()) //Criando o comando SQL
                {
                    comm.CommandText = "Select * from subcategoria WHERE subcategoria_nome LIKE @nome";
                    //Passando valores por parametro
                    comm.Parameters.Add(new SqlParameter("@nome", valor + "%"));
                    var reader = comm.ExecuteReader(); //Passando o comando 
                    var table = new DataTable(); //Passando a tabela
                    table.Load(reader); //Carregando a tabela 
                    return table; //Retornando a consulta ao Banco de Dados
                }
            }
        }
        #endregion Autor da região: Wallace        
    }
}