using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Connection
{
    public class Conexion
    {
        #region SINGLETON
        private static Conexion connection = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (connection == null)
            {
                connection = new Conexion();
            }
            return connection;
        }
        #endregion

        /**
         * Conexión estática a la base PASARELA donde se encuentra la información de los clientes con el subdominio
         * para así, realizar redirección a la base web final productiva
         */
        public FbConnection ConexionDB()
        {
            // Prueba Remoto AWS
            FbConnection cn = new FbConnection("User=SYSDBA;password=masterkey;DataSource=localhost;Database=localhost:C:\\PiscoCodes\\Bases\\PASARELAWEB.FDB;Charset=NONE;Dialect=3;Max Pool Size=1024;");

            return cn;
        }

        /**
         * Conexión a la Base Web del cliente, de acuerdo a la ruta recibida desde la invocación
         */
        public FbConnection ConexionDBWeb(string database)
        {
            // Prueba Remoto AWS
            FbConnection cn = new FbConnection("User=SYSDBA;password=masterkey;DataSource=localhost;Database=" + database + ";Charset=NONE;Dialect=3;Max Pool Size=1024;");

            return cn;
        }

        /**
         * Conexión a la BaseCRM donde encontraremos las rutas a las bases de previsión del cliente
         */
        public FbConnection ConexionDBCRM()
        {
            FbConnection cn = new FbConnection("User=SYSDBA;password=masterkey;DataSource=localhost;Database=BDPiscoTICS;Charset=NONE;Dialect=3;Max Pool Size=1024;");
            return cn;
        }
    }
}