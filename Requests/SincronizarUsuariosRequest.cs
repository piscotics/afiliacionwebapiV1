using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SincronizarUsuariosRequest : SincronizarUsuarios
    {
       
        public SincronizarUsuarios get(string subdominio)
        {
            SincronizarUsuariosService sincronizarUsuariosService = new SincronizarUsuariosService();
            SincronizarUsuarios sincronizarUsuario = new SincronizarUsuarios();
            sincronizarUsuario = sincronizarUsuariosService.get(subdominio);
            return sincronizarUsuario;
        }
    }
}