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
    public class RolController : BaseController
    {
        public RolController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Rol
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _unit.Roles.Listar());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Rol rol) //Model Binder
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
            var retorno = await _unit.Roles.Agregar(rol);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Roles.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Rol rol)
        {
            var retorno = await _unit.Roles.Modificar(rol);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Roles.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _unit.Roles.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Rol rol)
        {
            var retorno = await _unit.Roles.Eliminar(rol.Id); //Eliminación lógica -> soft delete

            return RedirectToAction("Index");
        }
    }
}