﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class PendentesTrimestrais
    {
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
        public List<Model.PendentesMensais> pendentesMensais
        {
            get;
            set;
        }

    }
}