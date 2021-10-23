using afiliacionwebapi.Models;
using afiliacionwebapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Models
{
    public class EmpleadoRequest
    {
        public List<Empleado> list(string subdominio, string tipoEmpleado)
        {
            EmpleadoService empleadoService = new EmpleadoService();
            List<Empleado> empleados = new List<Empleado>();
            empleados = empleadoService.list(subdominio, tipoEmpleado);
            return empleados;
        }

        public Empleado get(string subdominio, string identificacion)
        {
            EmpleadoService empleadoService = new EmpleadoService();
            Empleado empleado = new Empleado();
            empleado = empleadoService.get(subdominio, identificacion);
            return empleado;
        }

        public Empleado update(Empleado empleado)
        {
            EmpleadoService empleadoService = new EmpleadoService();
            return empleadoService.update(empleado);
        }

        public Empleado create(Empleado empleado)
        {
            EmpleadoService empleadoService = new EmpleadoService();
            return empleadoService.create(empleado);
        }

    }
}