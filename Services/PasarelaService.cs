using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Services
{
    public class PasarelaWebService
    {
        public static String validarSubdominio(string subdominio)
        {
            FbConnection cnConnFB = null;
            FbCommand cmdFB = null;
            FbDataReader drFB = null;
            
            string rutaBaseWeb = "";
            try
            {
                cnConnFB = Connection.Conexion.getInstance().ConexionDB();
                cnConnFB.Open();
                cmdFB = cnConnFB.CreateCommand();
                cmdFB.CommandText = " SELECT RUTADBWEB FROM TBLBASECLIENTES WHERE SUBDOMINIO = @SubDominio AND ESTADO = 0 ";
                cmdFB.Parameters.AddWithValue("@SubDominio", SqlDbType.VarChar).Value = subdominio.ToLower();
                cmdFB.CommandType = CommandType.Text;
                drFB = cmdFB.ExecuteReader();

                foreach (DbDataRecord dbDR in drFB)
                {
                    rutaBaseWeb = dbDR.GetString(0).ToLower();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                rutaBaseWeb = "";
            } finally
            {
                if (drFB != null)
                {
                    drFB.Close();
                }
                if (cnConnFB != null && cnConnFB.State == System.Data.ConnectionState.Open)
                {
                    cnConnFB.Close();
                }
            }

            return rutaBaseWeb;
        }
    }
}