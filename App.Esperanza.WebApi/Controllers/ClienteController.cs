using App.Esperanza.Models;
using App.Esperanza.UnitOfWork;
using App.Esperanza.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace App.Esperanza.WebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : BaseController
    {
        public ClienteController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _unit.Clientes.Listar());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();
            var objCli = await _unit.Clientes.Obtener(id);
            if (objCli == null) return NotFound();  
            return Ok(objCli);
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] Cliente cliente) //Model Binder
        {
            if (cliente == null) return BadRequest("Debe enviar la información del nuevo cliente");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var idCli = await _unit.Clientes.Agregar(cliente);

            if (idCli <= 0) 
                return Ok(new RespuestaResultado {
                    Id = idCli, Mensaje = "No se logró crear al cliente", Estado = "Exito"
                });
            //return Ok(new { id = idCli });
            //return Ok(new RespuestaResultado { Id = idCli, Mensaje = "Se creó el cliente con éxito", Estado = "Exito" });
            return Ok(new { id = idCli });

        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Put([FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id <= 0) return BadRequest("Debe enviar la información del nuevo cliente");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _unit.Clientes.Modificar(cliente))
                return BadRequest("No se logró actualizar al cliente, vuelva a intentar");

            return Ok(new { status = true });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete( int id)
        {
            if (id <= 0) return BadRequest("Debe enviar el ID a eliminar");

            if (await _unit.Clientes.Eliminar(id) <= 0)
                return BadRequest("No se logró eliminar al cliente, vuelva a intentar");

            return Ok(new { status = true });
        }
    }
}