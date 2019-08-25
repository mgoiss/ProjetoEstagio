using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCategoria
    {
        private DALConexao conexaoBD;
        public BLLCategoria(DALConexao conexaoCategoria)
        {
            this.conexaoBD = conexaoCategoria;
        }

        /* Aqui foi criada uma pequena restrição para o usuário*/
        public void Incluir(MCategoria modelo)
        {
            if (modelo.NomeCategoria.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório!");
            }
            //Para ficar tudo maiúsculo
            modelo.NomeCategoria = modelo.NomeCategoria.ToUpper();
            DALCategoria objeto = new DALCategoria(conexaoBD);
            objeto.Incluir(modelo);
        }
        /* Aqui foi criada uma pequena restrição para o usuário*/
        public void Alterar(MCategoria modelo)
        {
            if (modelo.CodigoCategoria <= 0)
            {
                throw new Exception("O código da categoria é obrigatório!");
            }

            if (modelo.NomeCategoria.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório!");
            }
            //Para ficar tudo maiúsculo
            modelo.NomeCategoria = modelo.NomeCategoria.ToUpper();
            DALCategoria objeto = new DALCategoria(conexaoBD);
            objeto.Alterar(modelo);
        }
        /*Nos métodos abaixo ainda faltam acrescentar as restrições de usuário. Dentro dos métodos só foram apenas abertas as conexões
         com o banco de dados.*/
        public void Excluir(int codigo)
        {
            DALCategoria objeto = new DALCategoria(conexaoBD);
            objeto.Excluir(codigo);
        }
        public DataTable LocalizarDados(String valor)
        {
            DALCategoria objeto = new DALCategoria(conexaoBD);
            return objeto.LocalizarDados(valor);
        }
        public MCategoria CarregarDados(int codigo)
        {
            DALCategoria objeto = new DALCategoria(conexaoBD);
            return objeto.CarregarDados(codigo);
        }
    }
}
