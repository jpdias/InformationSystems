using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using System.Web.Http.Cors;

namespace FirstREST.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        //
        // GET: /Clientes/

        public IEnumerable<Lib_Primavera.Model.Cliente> Get()
        {
            return Lib_Primavera.Comercial.ListaClientes();
        }


        // GET api/cliente/5    
        public Cliente Get(string id)
        {
            Lib_Primavera.Model.Cliente cliente = Lib_Primavera.Comercial.GetCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return cliente;
            }
        }
    }
}
