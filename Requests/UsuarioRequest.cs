using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using afiliacionwebapi.Services;

namespace afiliacionwebapi.Models
{
    public class UsuarioRequest : Usuario
    {
        private string cadenaConexion = String.Empty;

        public UsuarioRequest() { }

        public Usuario login(string username, string password, string subdominio)
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario usuario = new Usuario();
            usuario = usuarioService.login(username, password, subdominio);
            return usuario;
        }

        public Usuario create(Usuario usuario)
        {
            UsuarioService userService = new UsuarioService();
            return userService.create(usuario);
        }

        public Usuario update(Usuario usuario)
        {
            UsuarioService userService = new UsuarioService();
            return userService.update(usuario);
        }

        public List<Usuario> list(string subdominio)
        {
            UsuarioService userService = new UsuarioService();
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = userService.list(subdominio);
            return usuarios;
        }

        public Usuario get(string username, string subdominio)
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario usuarios = new Usuario();
            usuarios = usuarioService.get(username, subdominio);
            return usuarios;
        }
    }
}