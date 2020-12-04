using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webtp.DAOs;

namespace Webtp.Controllers
{

    public class apiController : Controller
    {
        public Boolean usu(String nombre, String contraseña)
        {
            if (UsuarioDAO.getInstancia().buscarUsuario(nombre, contraseña) != null)

            {
                return true;
            }
            return false;
        }
        public String hola()
        {

            return "holas";
        }


    }
}