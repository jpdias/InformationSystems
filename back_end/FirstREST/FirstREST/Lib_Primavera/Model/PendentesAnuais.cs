using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class PendentesAnuais
    {
        public int Ano
        {
            get;
            set;
        }
        public int DebitoClientes
        {
            get;
            set;
        }
        public int DebitoFornecedores
        {
            get;
            set;
        }
        public List<Model.PendentesTrimestrais> trimestres
        {
            get;
            set;
        }

    }
}