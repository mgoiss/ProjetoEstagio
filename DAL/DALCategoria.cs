using Modelo;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /*Esssa é a camada de dados Data Access Layer(DAL). 
    * A camada DAL é a representação da base de dados. Todas as tabelas e o CRUD serão tratadas aqui dentro.
    * Nessa classe é onde está o CRUD da tabeça CATEGORIA.*/
    public class DALCategoria
    {
        /*Nos métodos dentro do #region não vou entrar em detalhes...é o CRUD que está logo abaixo e eles seguem esse mesmo padrão.*/
        #region

        /* Método para buscar dados na base de dados e trazer para dentro do DataGridView*/
        public static DataTable LocalizarDados(String valor)
        {
            using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
            {
                conn.Open(); //Abrindo a conexão
                using (var comm = conn.CreateCommand()) //Criando o comando SQL
                {
                    comm.CommandText = "Select* from categoria WHERE categoria_nome LIKE @nome";
                    //Passando valores por parametro
                    comm.Parameters.Add(new SqlParameter("@nome", valor + "%"));
                    var reader = comm.ExecuteReader(); //Passando o comando 
                    var table = new DataTable(); //Passando a tabela
                    table.Load(reader); //Carregando a tabela 
                    return table; //Retornando a consulta ao Banco de Dados
                }
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
                    comm.CommandText = "Select* from categoria order by categoria_cod desc";
                    var reader = comm.ExecuteReader(); //Passando o comando 
                    var table = new DataTable(); //Passando a tabela
                    table.Load(reader); //Carregando a tabela 
                    return table; //Retornando a consulta ao Banco de Dados
                }
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
                        comm.CommandText = "DELETE FROM categoria WHERE categoria_cod = @id";
                        //Passando o valores por parametro
                        comm.Parameters.Add(new SqlParameter("@id", codigo));
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

        public static void Incluir(MCategoria modelo)
        {
            try
            {
                using (var conn = ConexaoBD.AbrirConexao()) //Passando a string de conexão
                {
                    conn.Open(); //Abrindo a conexão
                    using (var comm = conn.CreateCommand()) //Criando o comando SQL
                    {
                        comm.CommandText = "INSERT INTO categoria (categoria_nome) VALUES (@nome)";
                        //Passando valores por parametro
                        comm.Parameters.Add(new SqlParameter("@nome", modelo.NomeCategoria));
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

        public static void Alterar(MCategoria modelo)
        {
            try
            {
                using (var conn = ConexaoBD.AbrirConexao())//Passando a string de conexão
                {
                    conn.Open(); //Abrindo a conexão
                    using (var comm = conn.CreateCommand()) //Criando o comando SQL
                    {
                        comm.CommandText = "Update categoria set categoria_nome = @nome where categoria_cod = @codigo;";
                        //Passando valores por parametro
                        comm.Parameters.Add(new SqlParameter("@nome", modelo.NomeCategoria));
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
        #endregion Autor da região: Wallace Myregion Wallace
    }
}