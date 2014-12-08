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
    public class ArmazensController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Armazem> Get()
        {
            return Lib_Primavera.Comercial.ListaArmazens();
        }


        // GET api/artigo/5    
        public Armazem Get(string id)
        {
            Lib_Primavera.Model.Armazem armazem = Lib_Primavera.Comercial.GetArmazem(id);
            if (armazem == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return armazem;
            }
        }

    }
}

