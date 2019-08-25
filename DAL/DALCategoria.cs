using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
 /*Esssa é a camada de dados Data Access Layer(DAL). 
 * A camada DAL é a representação da base de dados. Todas as tabelas e o CRUD serão tratadas aqui dentro.
 * Nessa classe é onde está o CRUD da tabeça CATEGORIA.*/
    public class DALCategoria
    {
        /*Nos métodos dentro do #region não vou entrar em detalhes...é o CRUD que está logo abaixo e eles seguem esse mesmo padrão. 
         Claro, existem outras formas de fazer o CRUD usando o SqlCommand, mas em geral é dessa forma que está ai. Tem métodos que 
         utilizam o OledbCommand. Porém, acho mais fácil pelo SqlCommand. Para as próximas tabelas é só apenas replicar o que está 
         abaixo. Claro, terá que ser acrescentado novos campos de acordo com o número de atributos que a classe possuir.
         Mas isso é bobagem e não dificulta em nada.*/
        #region
        private DALConexao conexao;

        //Implementação do try para tratamento de erros, caso venha acontecer.
        /*Caso dê erro e caia no catch, o finally será executado, encerrando a conexão com o banco.*/
        //Construtor da classe
        public DALCategoria(DALConexao conexaoCategoria)
        {
            this.conexao = conexaoCategoria;
        }
        
        public void Incluir(MCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Insert into categoria(categoria_nome) values (@nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", modelo.NomeCategoria);
                conexao.Conectar();
                modelo.CodigoCategoria = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Alterar(MCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Update categoria set categoria_nome = @nome where categoria_cod = @codigo;";
                cmd.Parameters.AddWithValue("@nome", modelo.NomeCategoria);
                cmd.Parameters.AddWithValue("@codigo", modelo.CodigoCategoria);
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

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Delete categoria where categoria_cod = @codigo;";
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
            SqlDataAdapter dados = new SqlDataAdapter("Select * from categoria", conexao.ConexaoString);
            dados.Fill(tabela);
            return tabela;
        }
        #endregion Autor da região: Wallace Myregion Wallace

        /*Esse é método para carregar dados dentro da tela. Ao clicar duas vezes em algum dado na grid, ele executa esse comando 
         ara buscar no banco e trazer para o grid*/
        #region
        public MCategoria CarregarDados(int codigo)
        {
            MCategoria carregaDados = new MCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "Select * from categoria";
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
                carregaDados.NomeCategoria = Convert.ToString(informacoes["categoria_nome"]);

            }
            conexao.Desconectar();
            return carregaDados;
        }
        #endregion
    }
}

