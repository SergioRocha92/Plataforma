using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Webtp.DAOs;
using Webtp.Models;

namespace Webtp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult login()
        {
            return View("login");
        }

        public IActionResult logear(string usuario, string password)
        {

            var usuarioEncontrado = UsuarioDAO.getInstancia().buscarUsuario(usuario, password);

            if (usuarioEncontrado != null)
            {

                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuarioEncontrado));
                ViewBag.sesion = usuarioEncontrado;
                return View("Index");

            }
            else
            {

                ViewBag.msg = "El usuario no existe";
                return View("login");

            }

        }
        public IActionResult registrarse(string usuario, string password, string key)
        {

            var usuarioEncontrado = UsuarioDAO.getInstancia().buscarUsuario(usuario, password);

            if (usuarioEncontrado == null&&UsuarioDAO.getInstancia().keyvalidator(key))
            {
                usuarioEncontrado = new Usuario(usuario, password, key);
                UsuarioDAO.getInstancia().agregarPersona(usuarioEncontrado);

                return View("Index");

            }
            else
            {

                ViewBag.msg = "ingrese una key valida";
                return View("registro");

            }

        }


    }
}
