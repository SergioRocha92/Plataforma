using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webtp.DAOs
{
    public class Usuario
    {
        public String usuario;
        public String contraseña;
        public String key;

        public Usuario (String usuario, String contraseña, String key)
        {
            this.contraseña = contraseña;
            this.usuario = usuario;
            this.key = key;
        }
    }

}
