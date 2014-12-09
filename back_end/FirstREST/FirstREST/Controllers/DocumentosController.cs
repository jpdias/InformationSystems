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
    public class DocumentosController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Documento> Get()
        {
            return Lib_Primavera.Comercial.ListaDocumentos();
        }


        // GET api/artigo/5    
        public IEnumerable<Lib_Primavera.Model.Documento> Get(string id)
        {
            IEnumerable<Lib_Primavera.Model.Documento> documento = Lib_Primavera.Comercial.GetDocumento(id);
            if (documento == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return documento;
            }
        }

    }
}

