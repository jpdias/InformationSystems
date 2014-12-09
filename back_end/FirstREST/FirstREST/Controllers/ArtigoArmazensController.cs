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
    public class ArtigoArmazensController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.ArtigoArmazem> Get()
        {
            return Lib_Primavera.Comercial.ListaArtigoArmazens();
        }


        // GET api/artigo/5    
        public IEnumerable<Lib_Primavera.Model.ArtigoArmazem> Get(string id)
        {
            IEnumerable<Lib_Primavera.Model.ArtigoArmazem> artigoArmazem = Lib_Primavera.Comercial.GetArtigoArmazem(id);
            if (artigoArmazem == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return artigoArmazem;
            }
        }

    }
}

