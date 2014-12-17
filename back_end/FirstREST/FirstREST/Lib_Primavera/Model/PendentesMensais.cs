using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class PendentesMensais
    {
        public int Mes
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
        public int DebitoClientesAcumulado
        {
            get;
            set;
        }
        public int DebitoFornecedoresAcumulado
        {
            get;
            set;
        }
        public List<Model.Documento> pendentesClientes
        {
            get;
            set;
        }
        public List<Model.Documento> pendentesFornecedores
        {
            get;
            set;
        }

    }
}