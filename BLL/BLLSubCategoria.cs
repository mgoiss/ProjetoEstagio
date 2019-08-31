using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Modelo;

namespace BLL
{
    public class BLLSubCategoria
    {
        /* Aqui foi criada uma pequena restrição para o usuário*/
        public void Incluir(MSubCategoria modelo)
        {
            if (modelo.subNomeCategoria.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório!");
            }
            if (modelo.CodigoCategoria <= 0)
            {
                throw new Exception("O código da categoria é obrigatório!");
            }
            //Para ficar tudo maiúsculo
            modelo.subNomeCategoria = modelo.subNomeCategoria.ToUpper();
            DALSubCategoria.Incluir(modelo);
        }
        /* Aqui foi criada uma pequena restrição para o usuário*/
        public void Alterar(MSubCategoria modelo)
        {
            if (modelo.subCodigoCategoria <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório!");
            }
            if (modelo.CodigoCategoria <= 0)
            {
                throw new Exception("O código da categoria é obrigatório!");
            }
            if (modelo.subNomeCategoria.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório!");
            }
            //Para ficar tudo maiúsculo
            modelo.subNomeCategoria = modelo.subNomeCategoria.ToUpper();
            DALSubCategoria.Alterar(modelo);
        }
        /*Nos métodos abaixo ainda faltam acrescentar as restrições de usuário. Dentro dos métodos só foram apenas abertas as conexões
         com o banco de dados.*/
        public void Excluir(int codigo)
        {
            DALSubCategoria.Excluir(codigo);
        }
        public DataTable LocalizarDados(String valor)
        {
            return DALSubCategoria.LocalizarDados(valor);
        }
    }
}
