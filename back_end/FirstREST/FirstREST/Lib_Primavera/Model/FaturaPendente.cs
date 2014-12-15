using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class FaturaPendente
    {
        public int NumDoc
        {
            get;
            set;
        }

        public double TotalMerc
        {
            get;
            set;
        }
        public double TotalIVA
        {
            get;
            set;
        }
        public string Moeda
        {
            get;
            set;
        }
        public DateTime DataVencimento
        {
            get;
            set;
        }
        public string TipoDoc
        {
            get;
            set;
        }
    }
}