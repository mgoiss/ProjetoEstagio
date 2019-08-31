using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MSubCategoria
    {
        public int subCodigoCategoria { get; set; }
        public String subNomeCategoria { get; set; }
        /*CodigoCategoria foi criado nesta classe SubCategoria por conta do relacionamento entre elas. Na tabela, Codigo Categoria é
         chave estrangeira em subcategoria.*/
        public int CodigoCategoria { get; set; }


        /*Esse é o construtor da classe. Ele deve ser criado sempre que um objeto é instanciado.
         Mesmo se eu não tivesse criado, o programa iria criar automaticamente. Eu criei apenas para iniciar as propriedades da classe.
         No caso elas irão iniciar recebendo um valor. */
        public MSubCategoria()
        {
            this.CodigoCategoria = 0;
            this.subCodigoCategoria = 0;
            this.subNomeCategoria = "";
        }
        /*Esse segundo construtor foi criado para passar uma informação para o objeto quando ele for criado. As informações 
         são as que estão dentro dos parâmetros.*/
        public MSubCategoria(int subCatCod, int subCatNome, String CatCod)
        {
            this.CodigoCategoria = subCatCod;
            this.subCodigoCategoria = subCatNome;
            this.subNomeCategoria = CatCod;
        }

        public MSubCategoria(string subNomeCategoria, int codigoCategoria)
        {
            this.subNomeCategoria = subNomeCategoria;
            CodigoCategoria = codigoCategoria;
        }
    }
}