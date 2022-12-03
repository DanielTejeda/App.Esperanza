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
    public class AgenciaController : BaseController
    {
        public AgenciaController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Agencia
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            /*INICIO Signal-R Datos adicionales a usar*/
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            var lstClaims = authManager.User.Claims.ToList();
            ViewBag.userId = lstClaims[3].Value;    //ViewData["userId"] = lstClaims[3].Value;
            ViewBag.userName = lstClaims[2].Value;  //ViewData["userName"] = lstClaims[2].Value;
            /*FIN Signal-R Datos adicionales a usar*/

            return View(await _unit.Agencias.Listar());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Agencia agencia) //Model Binder
        {
            if (ModelState.IsValid)
            {

                //Datos adicionales a usar del objeto Usuario logueado
                //descomentar cuando se configure la seguridad del sistema
                
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                var lstClaims = authManager.User.Claims.ToList();
                var userId = lstClaims[3].Value;
                //var usuario = _unit.Usuarios.Obtener(int.Parse(userId));

                //agencia.IdUsuarioCreador = int.Parse(userId);
                var retorno = await _unit.Agencias.Agregar(agencia);

                if (retorno > 0)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = retorno
                    };
                else
                    return PartialView("_Create", agencia);
            }

            return PartialView("_Create");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", await _unit.Agencias.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _unit.Agencias.Modificar(agencia);

                if (retorno)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = agencia.Id
                    };
                else
                    return PartialView("_Edit", agencia);
            }

            return PartialView("_Edit", agencia);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return PartialView("_Details",await _unit.Agencias.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView("_Delete", await _unit.Agencias.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Agencia agencia)
        {
            var retorno = await _unit.Agencias.Eliminar(agencia.Id); //Eliminación lógica -> soft delete

            if (retorno > 0)
                return new JsonResult
                {
                    ContentType = "application/json",
                    Data = agencia.Id
                };
            else
                return PartialView("_Delete", agencia);
        }

        // aqui va la ruta especifica para los filtros -- NO OLVIDAR COLOCAR -> [RoutePrefix("Agencia")]
    }
}