using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

using System.Web.Http.Cors;namespace FirstREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnaliseDebitoController : ApiController
    {
        public Lib_Primavera.Model.AnaliseDebito Get()
        {
            return Lib_Primavera.Comercial.ListaAnaliseDebito();
        }


        // GET api/artigo/5    
        public AnaliseDebito Get(string id)
        {
            Lib_Primavera.Model.AnaliseDebito analiseDebito = Lib_Primavera.Comercial.GetAnaliseDebito(id);
            if (analiseDebito == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return analiseDebito;
            }
        }

    }
}

