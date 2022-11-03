using App.Esperanza.Models;
using App.Esperanza.UI.MVC.ViewModels;
using App.Esperanza.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Esperanza.UI.MVC.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public /*async Task<*/ActionResult/*>*/ Login(string returnUrl)
        {
            return View(new UsuarioLoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioViewModel)
        {
            var usuarioValido = await _unit.Usuarios.ValidarUsuario(usuarioViewModel.NombreUsuario, usuarioViewModel.Contraseña);

            if (usuarioValido == null)
            {
                ModelState.AddModelError("Error", "Email o Password Inválido");
                return View(usuarioViewModel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.GivenName, usuarioValido.NombreUsuario),
                new Claim(ClaimTypes.Role, usuarioValido.IdRol.ToString()),
                new Claim(ClaimTypes.Name, $"{usuarioValido.Nombres} {usuarioValido.Apellidos}"),
                new Claim(ClaimTypes.NameIdentifier, usuarioValido.Id.ToString())
            }, "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignIn(identity);

            return RedirectToLocal(usuarioViewModel.ReturnUrl);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Account");
            //return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Signup(UsuarioRegisterViewModel usuarioRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    DNI = usuarioRegisterViewModel.DNI,
                    Nombres = usuarioRegisterViewModel.Nombres,
                    Apellidos = usuarioRegisterViewModel.Apellidos,
                    NombreUsuario = usuarioRegisterViewModel.NombreUsuario,
                    Contraseña = usuarioRegisterViewModel.Contraseña,
                    Estado = true,
                    IdRol = 3
                };

                var resp = await _unit.Usuarios.CrearUsuario(usuario);
                if (resp != null)
                    return RedirectToAction("Login", "Account");
                else
                    return View(usuarioRegisterViewModel);
            }
            return View(usuarioRegisterViewModel);
        }
        

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}