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
    public class NovedadService
    {

        string rutaDBWeb = "";

        public Novedad get(string subdominio, string idNovedad)
        {
            Novedad infoNovedad = new Novedad();

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
                    cmdFB.CommandText = " P_AW_GETNOVEDAD ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idNovedad;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoNovedad.idNovedad = dbDR.GetInt32(0);
                        infoNovedad.codigo = dbDR.GetString(1);
                        infoNovedad.novedad = dbDR.GetString(2);
                       
                    }
                }
                catch (Exception ex)
                {
                    infoNovedad = null;
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
            return infoNovedad;
        }

        public List<Novedad> list(string subdominio)
        {
            List<Novedad> lstNovedad = new List<Novedad>();

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
                    cmdFB.CommandText = " P_AW_LISTNOVEDAD ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Novedad caja = new Novedad();
                        caja.idNovedad = dbDR.GetInt32(0);
                        caja.codigo = dbDR.GetString(1);
                        caja.novedad = dbDR.GetString(2);
                        lstNovedad.Add(caja);
                    }
                }
                catch (Exception ex)
                {
                    lstNovedad = null;
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
            return lstNovedad;
        }

    }
}