using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DALSubCategoria
    {
        #region
        private DALConexao conexao;

        //Construtor da classe
        public DALSubCategoria(DALConexao conexaoCategoria)
        {
            this.conexao = conexaoCategoria;
        }

        /*Percebam que CodigoCategoria foi chamado aqui dentro, pois esta classe se relaciona com a classe categoria.*/
        //Implementação do try para tratamento de erros, caso venha acontecer. 
        /*Caso dê erro e caia no catch, o finally será executado, encerrando a conexão com o banco.*/
        public void Incluir(MSubCategoria modelo)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Insert into subcategoria(categoria_cod, subCategoria_nome) values (@codigo, @nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@codigo", modelo.CodigoCategoria);
                cmd.Parameters.AddWithValue("@nome", modelo.subNomeCategoria);
                conexao.Conectar();
                modelo.subCodigoCategoria = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
           
            finally
            {
                conexao.Desconectar();
            }

        }

        public void Alterar(MSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Update subcategoria set subCategoria_nome = @nome, categoria_cod = @codigo where subCategoria_cod = @codigo;";
                cmd.Parameters.AddWithValue("@nome", modelo.subNomeCategoria);
                cmd.Parameters.AddWithValue("@subcodigo", modelo.subCodigoCategoria);
                cmd.Parameters.AddWithValue("@codigo", modelo.CodigoCategoria);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch(Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Delete subcategoria where subCategoria_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        /* Método para buscar dados na base de dados e trazer para dentro do DataGridView*/
        public DataTable LocalizarDados(String valor)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter dados = new SqlDataAdapter("Select * from subcategoria", conexao.ConexaoString);
            dados.Fill(tabela);
            return tabela;
        }
        #endregion Autor da região: Wallace

        /*Esse é método para carregar dados dentro da tela. Ao clicar duas vezes em algum dado na grid, ele executa esse comando 
         ara buscar no banco e trazer para o grid*/
        #region
        public MSubCategoria CarregarDados(int codigo)
        {
            MSubCategoria carregaDados = new MSubCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "Select * from subcategoria";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            /*O comando ExecuteRader está buscando todas as informações na base de dados e salvando no objeto
             * informacoes.
             * Logo abaixo foi criado uma condicao para verificar se existe algum registro dentro do objeto.
             * se existir, o programa vai fazer a leitura da linha e trazer todas as informações salvas.
             * DataReader é um objeto que serve para ler e acessar os registro na base de dados.  
             */
            SqlDataReader informacoes = cmd.ExecuteReader();
            if (informacoes.HasRows)
            {
                informacoes.Read();
                carregaDados.CodigoCategoria = Convert.ToInt32(informacoes["categoria_cod"]);
                carregaDados.subCodigoCategoria = Convert.ToInt32(informacoes["subCategoria_cod"]);
                carregaDados.subNomeCategoria = Convert.ToString(informacoes["subCategoria_nome"]);

            }
            conexao.Desconectar();
            return carregaDados;
        }
        #endregion
    } 
}
