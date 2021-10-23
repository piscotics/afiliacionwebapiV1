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
    public class FormaPagoService
    {

        string rutaDBWeb = "";

        public FormaPago get(string subdominio, string idFormaPago)
        {
            FormaPago infoFormaPago = new FormaPago();

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
                    cmdFB.CommandText = " P_AW_GETFORMAPAGO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idFormaPago;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoFormaPago.idFormaPago = dbDR.GetInt32(0).ToString();
                        infoFormaPago.formaPago = dbDR.GetString(1);
                        infoFormaPago.dias = dbDR.GetInt32(2);
                    }
                }
                catch (Exception ex)
                {
                    infoFormaPago = null;
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
            return infoFormaPago;
        }

        public List<FormaPago> list(string subdominio)
        {
            List<FormaPago> lstFormasPagos = new List<FormaPago>();

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
                    cmdFB.CommandText = " P_AW_LISTFORMAPAGO ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        FormaPago formaPago = new FormaPago();
                        formaPago.idFormaPago = dbDR.GetInt32(0).ToString();
                        formaPago.formaPago = dbDR.GetString(1);
                        formaPago.dias = dbDR.GetInt32(2);

                        lstFormasPagos.Add(formaPago);
                    }
                }
                catch (Exception ex)
                {
                    lstFormasPagos = null;
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
            return lstFormasPagos;
        }

    }
}