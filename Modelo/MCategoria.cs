 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MCategoria
    {
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
