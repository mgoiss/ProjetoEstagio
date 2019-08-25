 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MCategoria
    {

        /*Esse é o construtor da classe. Ele deve ser criado sempre que um objeto é instanciado.
         Mesmo se eu não tivesse criado, o programa iria criar automaticamente. Eu criei apenas para iniciar as propriedades.*/
        public MCategoria()
        {
            this.CodigoCategoria = 0;
            this.NomeCategoria = "";
        }
        /*Esse segundo construtor foi criado para passar uma informação para o objeto quando ele for criado. As informações 
         são as que estão dentro dos parâmetros.*/
        public MCategoria(int CatCod, String CatNome)
        {
            this.CodigoCategoria = CatCod;
            this.NomeCategoria = CatNome;
        }

        private int categoria_codigo;
        public int CodigoCategoria
        {
            get { return this.categoria_codigo; }
            set { this.categoria_codigo = value; }
        }
        private String categoria_nome;
        public String NomeCategoria
        {
            get { return this.categoria_nome; }
            set { this.categoria_nome = value; }
        }
    }
}
