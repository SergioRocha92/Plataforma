using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webtp.DAOs
{
    public class UsuarioDAO
    {

        public static UsuarioDAO instancia = null;


            

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null)
            {
                UsuarioDAO.instancia = new UsuarioDAO();
            }

            return instancia;

        }

        public void agregarPersona(Usuario usuario)
        {

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("INSERT INTO users (nombre,contraseña,clave) VALUES (@nombre,@contraseña,@clave)");
            queryBuilder.addParam("@nombre", usuario.usuario);
            queryBuilder.addParam("@contraseña", usuario.contraseña);
            queryBuilder.addParam("@clave", usuario.key);


            Console.WriteLine(usuario.key);
            //this.personas.Add(persona)
            DBConnection.getInstance().abm(queryBuilder);
            queryBuilder.setQuery("update llaves set disponible=@disponible where nombre=@nombre"); 
            queryBuilder.addParam("@disponible", "no"); 
            queryBuilder.addParam("@nombre", usuario.key); 
            DBConnection.getInstance().abm(queryBuilder);
        }



        public Usuario buscarUsuario(String nombre, String contraseña)
        {
            var queryBuilder = DBConnection.getInstance().getQueryBuilder();
            queryBuilder.setQuery("SELECT * FROM users WHERE nombre=@nombre and contraseña=@contraseña");
            queryBuilder.addParam("@nombre", nombre);
            queryBuilder.addParam("@contraseña", contraseña);
            var dataReader = DBConnection.getInstance().Select(queryBuilder);

            Usuario usuario = null;
            while (dataReader.Read())
            {
                usuario = new Usuario(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2));
            }

            return usuario;
        }
        public Boolean keyvalidator(String key)
        {

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("SELECT * FROM llaves WHERE nombre=@nombre and disponible=@disponible");
            queryBuilder.addParam("@nombre", key);
            queryBuilder.addParam("@disponible", "si");
            var dataReader = DBConnection.getInstance().Select(queryBuilder);


          while(dataReader.Read())
              {
                if (dataReader.GetString(0).Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}