using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Artigo
    {
        public string cod
        {
            get;
            set;
        }

        public string Descricao
        {
            get;
            set;
        }
        public string CodBarras
        {
            get;
            set;
        }
        public string UnidadeVenda
        {
            get;
            set;
        }
         public string IVA
        {
            get;
            set;
        }
        public float Desconto
        {
            get;
            set;
        }
        public string Fornecedor
        {
            get;
            set;
        }
        public double STKActual
        {
            get;
            set;
        }
        public string Familia
        {
            get;
            set;
        }
        public string TipoArtigo
        {
            get;
            set;
        }

    }
}