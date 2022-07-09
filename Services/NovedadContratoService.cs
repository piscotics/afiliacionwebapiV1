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
    public class NovedadContratoService
    {

        string rutaDBWeb = "";

        public NovedadContrato create(NovedadContrato NovedadContrato)
        {
            NovedadContrato resultado = new NovedadContrato();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(NovedadContrato.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARNOVEDADCONTRATO ";
                    //cmdFB.Parameters.AddWithValue("IDNOVEDADCONTRATO", SqlDbType.Int).Value = NovedadContrato.idNovedadContrato;
                    cmdFB.Parameters.AddWithValue("IDNOVEDAD", SqlDbType.Int).Value = NovedadContrato.idNovedad;
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = NovedadContrato.idContrato;
                    cmdFB.Parameters.AddWithValue("FECHANOVEDAD", SqlDbType.DateTime).Value = NovedadContrato.fechanovedad ;
                    cmdFB.Parameters.AddWithValue("POSTFECHADODIA", SqlDbType.Int).Value = NovedadContrato.postfechadodia ;
                    cmdFB.Parameters.AddWithValue("APLICADA", SqlDbType.Int).Value = NovedadContrato.aplicada ;
                    cmdFB.Parameters.AddWithValue("FECHAN", SqlDbType.DateTime).Value = NovedadContrato.fechan ;
                    cmdFB.Parameters.AddWithValue("USUARIO", SqlDbType.VarChar).Value = NovedadContrato.usuario ;
                    cmdFB.Parameters.AddWithValue("IDCOBRADOR", SqlDbType.VarChar).Value = NovedadContrato.idcobrador ;
                    cmdFB.Parameters.AddWithValue("MODULO", SqlDbType.VarChar).Value = NovedadContrato.modulo ;
                    cmdFB.Parameters.AddWithValue("TRANSAC", SqlDbType.Int).Value = NovedadContrato.transac ;
                    cmdFB.Parameters.AddWithValue("FECHAPROGRAMADA", SqlDbType.DateTime).Value = NovedadContrato.fechaprogramada ;
                    cmdFB.Parameters.AddWithValue("POSICIONX", SqlDbType.VarChar).Value = NovedadContrato.posicionx;
                    cmdFB.Parameters.AddWithValue("POSICIONY", SqlDbType.VarChar).Value = NovedadContrato.posiciony ;
                    cmdFB.Parameters.AddWithValue("TITULAR", SqlDbType.VarChar).Value = NovedadContrato.titular ;
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = NovedadContrato.observaciones ;
                    cmdFB.Parameters.AddWithValue("IDALTERNA", SqlDbType.Int).Value = NovedadContrato.idalterna ;
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

        public NovedadContrato update(NovedadContrato NovedadContrato)
        {
            NovedadContrato resultado = new NovedadContrato();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(NovedadContrato.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATENOVEDADCONTRATO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = NovedadContrato.idNovedadContrato;
                    cmdFB.Parameters.AddWithValue("IDNOVEDAD", SqlDbType.Int).Value = NovedadContrato.idNovedad;
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = NovedadContrato.idContrato;
                    cmdFB.Parameters.AddWithValue("FECHANOVEDAD", SqlDbType.DateTime).Value = NovedadContrato.fechanovedad ;
                    cmdFB.Parameters.AddWithValue("POSTFECHADODIA", SqlDbType.Int).Value = NovedadContrato.postfechadodia ;
                    cmdFB.Parameters.AddWithValue("APLICADA", SqlDbType.Int).Value = NovedadContrato.aplicada ;
                    cmdFB.Parameters.AddWithValue("FECHAN", SqlDbType.DateTime).Value = NovedadContrato.fechan ;
                    cmdFB.Parameters.AddWithValue("USUARIO", SqlDbType.VarChar).Value = NovedadContrato.usuario ;
                    cmdFB.Parameters.AddWithValue("IDCOBRADOR", SqlDbType.VarChar).Value = NovedadContrato.idcobrador ;
                    cmdFB.Parameters.AddWithValue("MODULO", SqlDbType.VarChar).Value = NovedadContrato.modulo ;
                    cmdFB.Parameters.AddWithValue("TRANSAC", SqlDbType.Int).Value = NovedadContrato.transac ;
                    cmdFB.Parameters.AddWithValue("FECHAPROGRAMADA", SqlDbType.DateTime).Value = NovedadContrato.fechaprogramada ;
                    cmdFB.Parameters.AddWithValue("POSICIONX", SqlDbType.VarChar).Value = NovedadContrato.posicionx;
                    cmdFB.Parameters.AddWithValue("POSICIONY", SqlDbType.VarChar).Value = NovedadContrato.posiciony ;
                    cmdFB.Parameters.AddWithValue("TITULAR", SqlDbType.VarChar).Value = NovedadContrato.titular ;
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = NovedadContrato.observaciones ;
                    cmdFB.Parameters.AddWithValue("IDALTERNA", SqlDbType.Int).Value = NovedadContrato.idalterna ;

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

        public NovedadContrato get(string subdominio, string idNovedadContrato)
        {
            NovedadContrato infoNovedadContrato = new NovedadContrato();

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
                    cmdFB.CommandText = " P_AW_GETNOVEDADCONTRATO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idNovedadContrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoNovedadContrato.idNovedadContrato= dbDR.GetInt32(0);
                        infoNovedadContrato.idNovedad = dbDR.GetInt32(1);
                        infoNovedadContrato.idContrato = dbDR.GetString(2);
                        infoNovedadContrato.fechanovedad = dbDR.GetDateTime(3);
                        infoNovedadContrato.postfechadodia = dbDR.GetInt16(4);
                        infoNovedadContrato.aplicada = dbDR.GetInt16(5);
                        infoNovedadContrato.fechan = dbDR.GetDateTime(6);
                        infoNovedadContrato.usuario = dbDR.GetString(7);
                        infoNovedadContrato.idcobrador = dbDR.GetString(8);
                        infoNovedadContrato.modulo = dbDR.GetString(9);
                        infoNovedadContrato.transac = dbDR.GetInt32(10);
                        infoNovedadContrato.fechaprogramada = dbDR.GetDateTime(11);
                        infoNovedadContrato.posicionx= dbDR.GetString(12);
                        infoNovedadContrato.posiciony = dbDR.GetString(13);
                        infoNovedadContrato.titular = dbDR.GetString(14);
                        infoNovedadContrato.observaciones = dbDR.GetString(15);
                        infoNovedadContrato.idalterna = dbDR.GetInt16(16);
                       
                    }
                }
                catch (Exception ex)
                {
                    infoNovedadContrato = null;
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
            return infoNovedadContrato;
        }

        public List<NovedadContrato> list(string subdominio, string idcontrato)
        {
            List<NovedadContrato> lstNovedadContrato = new List<NovedadContrato>();

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
                    cmdFB.CommandText = " P_AW_LISTNOVEDADCONTRATO ";
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = idcontrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        NovedadContrato infoNovedadContrato = new NovedadContrato();
                        infoNovedadContrato.idNovedadContrato= dbDR.GetInt32(0);
                        infoNovedadContrato.idNovedad = dbDR.GetInt32(1);
                        infoNovedadContrato.idContrato = dbDR.GetString(2);
                       
                        infoNovedadContrato.fechanovedad = dbDR.GetDateTime(3);
                        infoNovedadContrato.postfechadodia = dbDR.GetInt16(4);
                        
                        infoNovedadContrato.aplicada = dbDR.GetInt16(5);

                        infoNovedadContrato.fechan = dbDR.GetDateTime(6);
                        infoNovedadContrato.usuario = dbDR.GetString(7);
                        infoNovedadContrato.idcobrador = dbDR.GetString(8);
                        infoNovedadContrato.modulo = dbDR.GetString(9);
                        infoNovedadContrato.transac = dbDR.GetInt32(10);
                        infoNovedadContrato.fechaprogramada = dbDR.GetDateTime(11);
                        infoNovedadContrato.posicionx= dbDR.GetString(12);
                        infoNovedadContrato.posiciony = dbDR.GetString(13);
                        infoNovedadContrato.titular = dbDR.GetString(14);
                        infoNovedadContrato.observaciones = dbDR.GetString(15);
                        
                        infoNovedadContrato.idalterna = dbDR.GetInt16(16);

                        lstNovedadContrato.Add(infoNovedadContrato);
                    }
                }
                catch (Exception ex)
                {
                    lstNovedadContrato = null;
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
            return lstNovedadContrato;
        }

    }
}