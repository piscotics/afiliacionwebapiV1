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
    public class TipoPagoService
    {

        string rutaDBWeb = "";

        public TipoPago get(string subdominio, string idTipoPago)
        {
            TipoPago infoTipoPago = new TipoPago();

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
                    cmdFB.CommandText = " P_AW_GETTIPOPAGO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idTipoPago;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoTipoPago.idTipoPago = dbDR.GetInt32(0).ToString();
                        infoTipoPago.tipoPago = dbDR.GetString(1);
                       
                    }
                }
                catch (Exception ex)
                {
                    infoTipoPago = null;
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
            return infoTipoPago;
        }

        public List<TipoPago> list(string subdominio)
        {
            List<TipoPago> lstTiposPagos = new List<TipoPago>();

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
                    cmdFB.CommandText = " P_AW_LISTTIPOPAGO ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        TipoPago tipoPago = new TipoPago();
                        tipoPago.idTipoPago = dbDR.GetInt32(0).ToString();
                        tipoPago.tipoPago = dbDR.GetString(1);
                        

                        lstTiposPagos.Add(tipoPago);
                    }
                }
                catch (Exception ex)
                {
                    lstTiposPagos = null;
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
            return lstTiposPagos;
        }

    }
}