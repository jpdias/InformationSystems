using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

using System.Web.Http.Cors;

namespace FirstREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaturaPendenteController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.FaturaPendente> Get()
        {
            return Lib_Primavera.Comercial.ListaFaturasPendentes();
        }


        // GET api/artigo/5    
        public FaturaPendente Get(string id)
        {
            Lib_Primavera.Model.FaturaPendente fatura = Lib_Primavera.Comercial.GetFatura(id);
            if (fatura == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return fatura;
            }
        }
    }
}
