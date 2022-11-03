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
    public class VentaController : BaseController
    {
        public VentaController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Venta
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _unit.Ventas.Listar());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Venta venta) //Model Binder
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
            var retorno = await _unit.Ventas.Agregar(venta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Ventas.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Venta venta)
        {
            var retorno = await _unit.Ventas.Modificar(venta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Ventas.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _unit.Ventas.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Venta venta)
        {
            var retorno = await _unit.Ventas.Eliminar(venta); //Eliminación física -> hard delete

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> ListPendientes()
        {
            return View(await _unit.Ventas.ListaPendientes());
        }
    }
}