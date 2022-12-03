using App.Esperanza.Models;
using App.Esperanza.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Esperanza.UI.MVC.Controllers
{
    public class ClienteController : BaseController
    {
        public ClienteController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Cliente
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _unit.Clientes.Listar());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente) //Model Binder
        {
            if (ModelState.IsValid)
            {
                //Datos adicionales a usar del ojeto Usuario logueado
                //descomentar cuando se configure la seguridad del sistema

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                var lstClaims = authManager.User.Claims.ToList();
                var userId = lstClaims[3].Value;
                //var usuario = _unit.Usuarios.Obtener(int.Parse(userId));

                //categoria.IdUsuarioCreador = int.Parse(userId);
            
                var retorno = await _unit.Clientes.Agregar(cliente);

                if (retorno > 0)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = retorno
                    };
                else
                    return PartialView("_Create", cliente);
            }

            return PartialView("_Create");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", await _unit.Clientes.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _unit.Clientes.Modificar(cliente);

                if (retorno)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = cliente.Id
                    };
                else
                    return PartialView("_Edit", cliente);
            }

            return PartialView("_Edit", cliente);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return PartialView("_Details", await _unit.Clientes.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView("_Delete", await _unit.Clientes.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Cliente cliente)
        {
            var retorno = await _unit.Clientes.Eliminar(cliente.Id); //Eliminación lógica -> soft delete

            if (retorno > 0)
                return new JsonResult
                {
                    ContentType = "application/json",
                    Data = cliente.Id
                };
            else
                return PartialView("_Delete", cliente);
        }

        // aqui va la ruta especifica para los filtros -- NO OLVIDAR COLOCAR -> [RoutePrefix("Cliente")]
    }
}