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
    public class ServicioController : BaseController
    {
        public ServicioController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Servicio
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _unit.Servicios.Listar());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Servicio servicio) //Model Binder
        {

            //Datos adicionales a usar del ojeto Usuario logueado
            //descomentar cuando se configure la seguridad del sistema
            /*
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            var lstClaims = authManager.User.Claims.ToList();
            var userId = lstClaims[3].Value;
            var usuario = _unit.Usuarios.Obtener(int.Parse(userId));

            categoria.IdUsuarioCreador = int.Parse(userId);
            */
            var retorno = await _unit.Servicios.Agregar(servicio);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Servicios.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Servicio servicio)
        {
            var retorno = await _unit.Servicios.Modificar(servicio);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Servicios.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _unit.Servicios.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Servicio servicio)
        {
            var retorno = await _unit.Servicios.Eliminar(servicio.Id); //Eliminación lógica -> soft delete

            return RedirectToAction("Index");
        }
    }
}