using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class ArtigoArmazem
    {
        public string Artigo
        {
            get;
            set;
        }

        public string Armazem
        {
            get;
            set;
        }
        public double StkActual
        {
            get;
            set;
        }
        public double QtReservada
        {
            get;
            set;
        }
         public double UltimaContagem
        {
            get;
            set;
        }
         public string DataUltimaContagem
        {
            get;
            set;
        } 
    }
}