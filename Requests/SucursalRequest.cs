using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class SucursalRequest : Sucursal
    {
        public Sucursal create(Sucursal sucursal)
        {
            SucursalService sucursalService = new SucursalService();
            return sucursalService.create(sucursal);
        }

        public Sucursal update(Sucursal sucursal)
        {
            SucursalService sucursalService = new SucursalService();
            return sucursalService.update(sucursal);
        }

        public List<Sucursal> list(string subdominio)
        {
            SucursalService sucursalService = new SucursalService();
            List<Sucursal> sucursales = new List<Sucursal>();
            sucursales = sucursalService.list(subdominio);
            return sucursales;
        }

        public Sucursal get(string idSucursal, string subdominio)
        {
            SucursalService sucursalService = new SucursalService();
            Sucursal sucursales = new Sucursal();
            sucursales = sucursalService.get(idSucursal, subdominio);
            return sucursales;
        }
    }
}