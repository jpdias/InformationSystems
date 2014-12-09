using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Documento
    {
        public int NumDoc
        {
            get;
            set;
        }

        public string Entidade
        {
            get;
            set;
        }
        public string TipoDoc
        {
            get;
            set;
        }
        public string CondPag
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
        public string ModoPag
        {
            get;
            set;
        }
        public DateTime DataVencimento
        {
            get;
            set;
        }
        public string LocalCarga
        {
            get;
            set;
        }
        public string HoraCarga
        {
            get;
            set;
        }
        public string LocalDescarga
        {
            get;
            set;
        }
        public string HoraDescarga
        {
            get;
            set;
        }

    }
}