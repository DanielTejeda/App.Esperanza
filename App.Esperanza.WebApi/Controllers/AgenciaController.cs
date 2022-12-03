using App.Esperanza.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace App.Esperanza.WebApi.Controllers
{
    //[RoutePrefix("api/agencia")]
    public class AgenciaController : BaseController
    {
        public AgenciaController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        
        public async Task<IHttpActionResult> Get()
        {
            ////[Route("list")] agregar debajo de HttpGet
            return Ok(await _unit.Agencias.Listar());
            //return new InternalServerErrorResult(Request);
        }
    }
}