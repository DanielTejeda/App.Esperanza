using App.Esperanza.Models;
using App.Esperanza.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace App.Esperanza.UI.MVC.Controllers
{
    [RoutePrefix("Venta")]
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
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Venta venta) //Model Binder
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
            
                var retorno = await _unit.Ventas.Agregar(venta);

                if (retorno > 0)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = retorno
                    };
                else
                    return PartialView("_Create", venta);
            }

            return PartialView("_Create");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", await _unit.Ventas.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _unit.Ventas.Modificar(venta);

                if (retorno)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = venta.Id
                    };
                else
                    return PartialView("_Edit", venta);
            }

            return PartialView("_Edit", venta);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return PartialView("_Details", await _unit.Ventas.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView("_Delete", await _unit.Ventas.Obtener(id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Venta venta)
        {
            var retorno = await _unit.Ventas.Eliminar(venta); //Eliminación física -> hard delete

            if (retorno) //(retorno > 0)
                return new JsonResult
                {
                    ContentType = "application/json",
                    Data = venta.Id
                };
            else
                return PartialView("_Delete", venta);
        }
        [HttpGet]
        public async Task<ActionResult> ListPendientes()
        {
            return View(await _unit.Ventas.ListaPendientes());
        }

        // aqui va la ruta especifica para los filtros -- NO OLVIDAR COLOCAR -> [RoutePrefix("Venta")]
        [Route("ListByFilters/{ventaId}/{ventaIdCliente}/{ventaIdAsesor}")]
        public async Task<PartialViewResult> ListByFilters(string ventaId, string ventaIdCliente, string ventaIdAsesor)
        {
            List<Venta> lstVentas = new List<Venta>();

            if (!ventaId.Equals("-"))
            {
                var venta = await _unit.Ventas.Obtener(int.Parse(ventaId));
                lstVentas.Add(venta);
            }
            else if (!ventaIdCliente.Equals("0"))
            {
                var resultado = await _unit.Ventas.ListarPorCliente(int.Parse(ventaIdCliente));
                lstVentas = resultado.ToList();
            }
            else if (!ventaIdAsesor.Equals("0"))
            {
                var resultado = await _unit.Ventas.ListarPorUsuario(int.Parse(ventaIdAsesor));
                lstVentas = resultado.ToList();
            }
            else
            {
                var resultado = await _unit.Ventas.ListarPorUsuario(0);
                lstVentas = resultado.ToList();
            }

            return PartialView("_List", lstVentas);
        }
        [Route("ListByFiltersPend/{ventaPendId}/{ventaPendIdCliente}/{ventaPendIdAsesor}")]
        public async Task<PartialViewResult> ListByFiltersPend(string ventaPendId, string ventaPendIdCliente, string ventaPendIdAsesor)
        {
            List<Venta> lstVentas = new List<Venta>();

            if (!ventaPendId.Equals("-"))
            {
                var venta = await _unit.Ventas.Obtener(int.Parse(ventaPendId));
                lstVentas.Add(venta);
            }
            else if (!ventaPendIdCliente.Equals("0"))
            {
                var resultado = await _unit.Ventas.ListarPorCliente(int.Parse(ventaPendIdCliente));
                lstVentas = resultado.ToList();
            }
            else if (!ventaPendIdAsesor.Equals("0"))
            {
                var resultado = await _unit.Ventas.ListarPorUsuario(int.Parse(ventaPendIdAsesor));
                lstVentas = resultado.ToList();
            }
            else
            {
                var resultado = await _unit.Ventas.ListarPorUsuario(0);
                lstVentas = resultado.ToList();
            }

            return PartialView("_List_pendientes", lstVentas);
        }
    }
}