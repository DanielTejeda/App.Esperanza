using App.Esperanza.Models;
using App.Esperanza.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Esperanza.UI.MVC.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClienteController : BaseController
    {
        public ClienteController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Cliente
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            //return View(await _unit.Clientes.Listar());

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44319/api/cliente");
            var result = response.Content.ReadAsStringAsync().Result;
            var contentResult = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(result);

            return View(contentResult);
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

                //------------------------------ LLAMADA DIRECTA AL _unit (REPOSITORY) ------------------------------------
                //var retorno = await _unit.Clientes.Agregar(cliente);

                /*
                 *  CONSUMO DE SERVICIO WEP API (.NET FRAMEWORK)
                 */

                var httpClient = new HttpClient();
                var content = JsonConvert.SerializeObject(cliente);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync("https://localhost:44319/api/cliente", byteContent);
                var result = response.Content.ReadAsStringAsync().Result;
                var contentResult = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);

                if (contentResult["id"] > 0)
                    return new JsonResult
                    {
                        ContentType = "application/json",
                        Data = contentResult["id"] //retorno
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
                //var retorno = await _unit.Clientes.Modificar(cliente);
                /*
                 *  CONSUMO DE SERVICIO WEP API (.NET FRAMEWORK)
                 */
                var httpClient = new HttpClient();
                var content = JsonConvert.SerializeObject(cliente);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync("https://localhost:44319/api/cliente", byteContent);
                var result = response.Content.ReadAsStringAsync().Result;
                var contentResult = JsonConvert.DeserializeObject<Dictionary<string, bool>>(result);


                //if (retorno)
                if (contentResult["status"])
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
            //var retorno = await _unit.Clientes.Eliminar(cliente.Id); //Eliminación lógica -> soft delete

            var httpClient = new HttpClient();
        
            var response = await httpClient.DeleteAsync("https://localhost:44319/api/cliente/" + cliente.Id);
            var result = response.Content.ReadAsStringAsync().Result;
            var contentResult = JsonConvert.DeserializeObject<Dictionary<string, bool>>(result);

            //if (retorno > 0) if (contentResult["id"] > 0)
            if (contentResult["status"])
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