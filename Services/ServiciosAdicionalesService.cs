using afiliacionwebapi.Models;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Services
{
    public class ServiciosAdicionalesService
    {

        string rutaDBWeb = "";
        
        public ServiciosAdicionales get(string subdominio, string idServiciosAdicionales)
        {
            ServiciosAdicionales infoServiciosAdicionales = new ServiciosAdicionales();

            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(subdominio);
            if (rutaDBWeb != "")
            {
                FbConnection cnConnFB = null;
                FbCommand cmdFB = null;
                FbDataReader drFB = null;

                try
                {

                    cnConnFB = Connection.Conexion.getInstance().ConexionDBWeb(rutaDBWeb);
                    cnConnFB.Open();
                    cmdFB = cnConnFB.CreateCommand();
                    cmdFB.CommandText = " P_AW_GETSERVICIOSADICIONALES ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idServiciosAdicionales;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoServiciosAdicionales.idsa = dbDR.GetInt32(0);
                        infoServiciosAdicionales.descripcion = dbDR.GetString(1);
                        infoServiciosAdicionales.estado = dbDR.GetString(2);
                        infoServiciosAdicionales.valor = dbDR.GetFloat(3);
                        infoServiciosAdicionales.tipocobro = dbDR.GetInt16(4);
                        infoServiciosAdicionales.planproteccion = dbDR.GetString(5);
                        infoServiciosAdicionales.parentesco = dbDR.GetString(6);
                        infoServiciosAdicionales.usuario = dbDR.GetString(7);
                        infoServiciosAdicionales.valorpoliza = dbDR.GetFloat(8);
                        infoServiciosAdicionales.seguro = dbDR.GetInt16(9);
                        infoServiciosAdicionales.tipo = dbDR.GetString(10);
                       
                    }
                }
                catch (Exception ex)
                {
                    infoServiciosAdicionales = null;
                    Console.WriteLine(ex.Message);
                }
                finally
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
            }
            return infoServiciosAdicionales;
        }

        public List<ServiciosAdicionales> list(string subdominio)
        {
            List<ServiciosAdicionales> lstServiciosAdicionales = new List<ServiciosAdicionales>();

            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(subdominio);
            if (rutaDBWeb != "")
            {
                FbConnection cnConnFB = null;
                FbCommand cmdFB = null;
                FbDataReader drFB = null;

                try
                {
                    cnConnFB = Connection.Conexion.getInstance().ConexionDBWeb(rutaDBWeb);
                    cnConnFB.Open();
                    cmdFB = cnConnFB.CreateCommand();
                    cmdFB.CommandText = " P_AW_LISTSERVICIOSADICIONALES ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        ServiciosAdicionales serviciosAdicionales = new ServiciosAdicionales();
                        serviciosAdicionales.idsa = dbDR.GetInt32(0);
                        serviciosAdicionales.descripcion = dbDR.GetString(1);
                        serviciosAdicionales.estado = dbDR.GetString(2);
                        serviciosAdicionales.valor = dbDR.GetFloat(3);
                        serviciosAdicionales.tipocobro = dbDR.GetInt16(4);
                        serviciosAdicionales.planproteccion = dbDR.GetString(5);
                        serviciosAdicionales.parentesco = dbDR.GetString(6);
                        serviciosAdicionales.usuario = dbDR.GetString(7);
                        serviciosAdicionales.valorpoliza = dbDR.GetFloat(8);
                        serviciosAdicionales.seguro = dbDR.GetInt16(9);
                        serviciosAdicionales.tipo = dbDR.GetString(10);
                        lstServiciosAdicionales.Add(serviciosAdicionales);
                    }
                }
                catch (Exception ex)
                {
                    lstServiciosAdicionales = null;
                    Console.WriteLine(ex.Message);
                }
                finally
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
            }
            return lstServiciosAdicionales;
        }

    }
}