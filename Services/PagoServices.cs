using afiliacionwebapi.Models;
using afiliacionwebapi.utils;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Services
{
    public class PagoService
    {
        string rutaDBWeb = "";

        public List<Pago> list(string subdominio, string identificaciontitular, string idcontrato)
        {
            List<Pago> lstPagos = new List<Pago>();

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
                    cmdFB.CommandText = " P_AW_LISTPAGOS ";
                    cmdFB.Parameters.AddWithValue("IDTITULAR", SqlDbType.VarChar).Value = identificaciontitular;
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = idcontrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                      

                        Pago Pagos = new Pago();
                            Pagos.nrorecibo = dbDR.GetString(0);
                            Pagos.fecha  = dbDR.GetDateTime(1);
                            Pagos.valor  = dbDR.GetFloat(2);
                            Pagos.descuento  = dbDR.GetFloat(3);
                            if (dbDR.GetInt32(4) == 0){
                                Pagos.anulado  = false;
                            }else{
                                Pagos.anulado  = true;
                            }
                            Pagos.idcobrador  = dbDR.GetString(5);
                           // Pagos.cobrador  = dbDR.GetString(6);
                            Pagos.observaciones  = dbDR.GetString(6);
                            Pagos.cuotadesde  = dbDR.GetDateTime(7);
                            Pagos.cuotahasta  = dbDR.GetDateTime(8);
                            Pagos.nrofactura   = dbDR.GetString(9);
                            Pagos.idcaja   = dbDR.GetInt32(10);
                           // Pagos.caja   = dbDR.GetString(12);
                            Pagos.idtipopago   = dbDR.GetInt32(11);
                           // Pagos.tipopago   = dbDR.GetString(14);
                            Pagos.identificaciontitular   = dbDR.GetString(12);
                            Pagos.contrato   = dbDR.GetString(13);
                            Pagos.usuario    = dbDR.GetString(14);
                            Pagos.nota1    = dbDR.GetString(15);
                            Pagos.nota2    = dbDR.GetString(16);
                            if (dbDR["PAGOHASTA"] == DBNull.Value)
                            {
                                 Pagos.pagohasta    = null;
                            }else{
                                Pagos.pagohasta    = dbDR.GetDateTime(17);
                            }
                            Pagos.estadopago    = dbDR.GetString(18);
                   
                        lstPagos.Add(Pagos);
                    }
                }
                catch (Exception ex)
                {
                    lstPagos = null;
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
            return lstPagos;
        }


        public Pago get(string subdominio, string recibo)
        {
            Pago Pagos = new Pago();

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
                    cmdFB.CommandText = " P_AW_GETPAGOS";
                    cmdFB.Parameters.AddWithValue("RECIBO", SqlDbType.VarChar).Value = recibo;
                   
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                       // Pagos.codRespuesta = dbDR.GetString(19);
                       //Pagos.msjRespuesta = dbDR.GetString(20);

                        if (dbDR["NRORECIBO"] != DBNull.Value)
                        {
                           
                           // Pagos.idpago = dbDR.GetString(0);
                           Pagos.nrorecibo = dbDR.GetString(0);
                            Pagos.fecha  = dbDR.GetDateTime(1);
                            Pagos.valor  = dbDR.GetFloat(2);
                            Pagos.descuento  = dbDR.GetFloat(3);
                             if (dbDR.GetInt32(4) == 0){
                                Pagos.anulado  = false;
                            }else{
                                Pagos.anulado  = true;
                            }
                            Pagos.idcobrador  = dbDR.GetString(5);
                           // Pagos.cobrador  = dbDR.GetString(6);
                            Pagos.observaciones  = dbDR.GetString(6);
                            Pagos.cuotadesde  = dbDR.GetDateTime(7);
                            Pagos.cuotahasta  = dbDR.GetDateTime(8);
                            Pagos.nrofactura   = dbDR.GetString(9);
                            Pagos.idcaja   = dbDR.GetInt32(10);
                           // Pagos.caja   = dbDR.GetString(12);
                            Pagos.idtipopago   = dbDR.GetInt32(11);
                           // Pagos.tipopago   = dbDR.GetString(14);
                            Pagos.identificaciontitular   = dbDR.GetString(12);
                            Pagos.contrato   = dbDR.GetString(13);
                            Pagos.usuario    = dbDR.GetString(14);
                            Pagos.nota1    = dbDR.GetString(15);
                            Pagos.nota2    = dbDR.GetString(16);
                            if (dbDR["PAGOHASTA"] == DBNull.Value)
                            {
                                 Pagos.pagohasta    = null;
                            }else{
                                Pagos.pagohasta    = dbDR.GetDateTime(17);
                            }
                           Pagos.estadopago    = dbDR.GetString(18);
                            
                        }

                    }

                } catch(Exception ex)
                {
                    Pagos = null;
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

            return Pagos;
        }

        public Pago update(Pago Pago)
        {
            Pago resultado = new Pago();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Pago.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEPAGO";
                     //cmdFB.Parameters.AddWithValue("idpago", SqlDbType.VarChar).Value = Pago.idpago;
                    cmdFB.Parameters.AddWithValue("nrorecibo", SqlDbType.VarChar).Value = Pago.nrorecibo;
                     cmdFB.Parameters.AddWithValue("fecha", SqlDbType.DateTime).Value = Pago.fecha;
                     cmdFB.Parameters.AddWithValue("valor", SqlDbType.Float).Value = Pago.valor;
                     cmdFB.Parameters.AddWithValue("descuento", SqlDbType.Float).Value = Pago.descuento;
                     cmdFB.Parameters.AddWithValue("anulado", SqlDbType.Int).Value = Pago.anulado;
                     cmdFB.Parameters.AddWithValue("idcobrador", SqlDbType.VarChar).Value = Pago.idcobrador;
                     cmdFB.Parameters.AddWithValue("observaciones", SqlDbType.VarChar).Value = Pago.observaciones;
                     cmdFB.Parameters.AddWithValue("cuotadesde", SqlDbType.DateTime).Value = Pago.cuotadesde;
                     cmdFB.Parameters.AddWithValue("cuotahasta", SqlDbType.DateTime).Value = Pago.cuotahasta;
                     cmdFB.Parameters.AddWithValue("nrofactura", SqlDbType.VarChar).Value = Pago.nrofactura;
                     cmdFB.Parameters.AddWithValue("idcaja", SqlDbType.Int).Value = Pago.idcaja;
                     cmdFB.Parameters.AddWithValue("idtipopago", SqlDbType.Int).Value = Pago.idtipopago;
                     cmdFB.Parameters.AddWithValue("identificaciontitular", SqlDbType.VarChar).Value = Pago.identificaciontitular;
                     cmdFB.Parameters.AddWithValue("contrato", SqlDbType.VarChar).Value = Pago.contrato;
                     cmdFB.Parameters.AddWithValue("usuario", SqlDbType.VarChar).Value = Pago.usuario;
                     cmdFB.Parameters.AddWithValue("nota1", SqlDbType.VarChar).Value = Pago.nota1;
                     cmdFB.Parameters.AddWithValue("nota2", SqlDbType.VarChar).Value = Pago.nota2;
                    // cmdFB.Parameters.AddWithValue("pagohasta", SqlDbType.DateTime).Value = Pago.pagohasta;
                    
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        resultado.codRespuesta = dbDR.GetString(0);
                        resultado.msjRespuesta = dbDR.GetString(1);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resultado = null;
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
            return resultado;
        }

        public Pago create(Pago Pago)
        {
            Pago resultado = new Pago();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Pago.subdominio);
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
                    cmdFB.CommandText = "P_AW_CREARPAGO";
                     cmdFB.Parameters.AddWithValue("nrorecibo", SqlDbType.VarChar).Value = Pago.nrorecibo;
                     cmdFB.Parameters.AddWithValue("fecha", SqlDbType.DateTime).Value = Pago.fecha;
                     cmdFB.Parameters.AddWithValue("valor", SqlDbType.Float).Value = Pago.valor;
                     cmdFB.Parameters.AddWithValue("descuento", SqlDbType.Float).Value = Pago.descuento;
                     cmdFB.Parameters.AddWithValue("anulado", SqlDbType.Int).Value = Pago.anulado;
                     cmdFB.Parameters.AddWithValue("idcobrador", SqlDbType.VarChar).Value = Pago.idcobrador;
                     cmdFB.Parameters.AddWithValue("observaciones", SqlDbType.VarChar).Value = Pago.observaciones;
                     cmdFB.Parameters.AddWithValue("cuotadesde", SqlDbType.DateTime).Value = Pago.cuotadesde;
                     cmdFB.Parameters.AddWithValue("cuotahasta", SqlDbType.DateTime).Value = Pago.cuotahasta;
                     cmdFB.Parameters.AddWithValue("nrofactura", SqlDbType.VarChar).Value = Pago.nrofactura;
                     cmdFB.Parameters.AddWithValue("idcaja", SqlDbType.Int).Value = Pago.idcaja;
                     cmdFB.Parameters.AddWithValue("idtipopago", SqlDbType.Int).Value = Pago.idtipopago;
                     cmdFB.Parameters.AddWithValue("identificaciontitular", SqlDbType.VarChar).Value = Pago.identificaciontitular;
                     cmdFB.Parameters.AddWithValue("contrato", SqlDbType.VarChar).Value = Pago.contrato;
                     cmdFB.Parameters.AddWithValue("usuario", SqlDbType.VarChar).Value = Pago.usuario;
                     cmdFB.Parameters.AddWithValue("nota1", SqlDbType.VarChar).Value = Pago.nota1;
                     cmdFB.Parameters.AddWithValue("nota2", SqlDbType.VarChar).Value = Pago.nota2;
                     //cmdFB.Parameters.AddWithValue("pagohasta", SqlDbType.DateTime).Value = Pago.pagohasta;
                

                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        resultado.codRespuesta = dbDR.GetString(0);
                        resultado.msjRespuesta = dbDR.GetString(1);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resultado = null;
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
            return resultado;
        }

        

    }
}