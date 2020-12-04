using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabajo1.DAOs
{
    class UsuariosDAO
    {

        static RestClient cliente = new RestClient("https://localhost:44381/");

        public static Boolean buscarUsuario(String usuario, String password)
        {
            var request = new RestRequest("api/usu?nombre=" + usuario + "&contraseña=" + password);
            /*request.RequestFormat = DataFormat.Json;*/
            var response = cliente.Get(request).Content;
            return response.Equals("true");


        }

        public static void val1()
        {
            var request = new RestRequest("api/hola");
            /*request.RequestFormat = DataFormat.Json;*/
            var response = cliente.Get(request).Content;
            Console.WriteLine(response);

        }

    }
}
