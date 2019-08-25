using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MSubCategoria
    {

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
        private int subCategoria_codigo;
        public int subCodigoCategoria
        {
            get { return this.subCategoria_codigo; }
            set { this.subCategoria_codigo = value; }
        }
        private String subCategoria_nome;
        public String subNomeCategoria
        {
            get { return this.subCategoria_nome; }
            set { this.subCategoria_nome = value; }
        }
        
        /*CodigoCategoria foi criado nesta classe SubCategoria por conta do relacionamento entre elas. Na tabela, Codigo Categoria é
         chave estrangeira em subcategoria.*/
        private int categoria_codigo;
        public int CodigoCategoria
        {
            get { return this.categoria_codigo; }
            set { this.categoria_codigo = value; }
        }
    }
}
