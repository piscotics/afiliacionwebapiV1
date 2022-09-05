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
    public class ContratosAdicionalesService
    {

        string rutaDBWeb = "";

        public ContratosAdicionales create(ContratosAdicionales ContratosAdicionales)
        {
            ContratosAdicionales resultado = new ContratosAdicionales();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(ContratosAdicionales.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARCONTRATOSADICIONALES ";
                    //cmdFB.Parameters.AddWithValue("IDCA", SqlDbType.Int).Value = ContratosAdicionales.idca;
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = ContratosAdicionales.idcontrato;
                    cmdFB.Parameters.AddWithValue("IDSADICIONAL", SqlDbType.Int).Value = ContratosAdicionales.idsadicional;
                    cmdFB.Parameters.AddWithValue("VALOR", SqlDbType.Int).Value = ContratosAdicionales.valor ;
                    cmdFB.Parameters.AddWithValue("USUARIO", SqlDbType.VarChar).Value = ContratosAdicionales.usuario ;
                    cmdFB.Parameters.AddWithValue("FECHA", SqlDbType.DateTime).Value = ContratosAdicionales.fecha ;
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = ContratosAdicionales.idpersona ;
                    cmdFB.Parameters.AddWithValue("VALORANTERIOR", SqlDbType.Int).Value = ContratosAdicionales.valoranterior ;
                    cmdFB.Parameters.AddWithValue("FECHARETIRO", SqlDbType.DateTime).Value = ContratosAdicionales.fecharetiro ;
                    cmdFB.Parameters.AddWithValue("IDASESOR", SqlDbType.VarChar).Value = ContratosAdicionales.idasesor ;
                    
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

        public ContratosAdicionales update(ContratosAdicionales ContratosAdicionales)
        {
            ContratosAdicionales resultado = new ContratosAdicionales();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(ContratosAdicionales.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATECONTRATOSADICIONALES ";

                    cmdFB.Parameters.AddWithValue("IDCA", SqlDbType.Int).Value = ContratosAdicionales.idca;
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = ContratosAdicionales.idcontrato;
                    cmdFB.Parameters.AddWithValue("IDSADICIONAL", SqlDbType.Int).Value = ContratosAdicionales.idsadicional;
                    cmdFB.Parameters.AddWithValue("VALOR", SqlDbType.Int).Value = ContratosAdicionales.valor ;
                    cmdFB.Parameters.AddWithValue("USUARIO", SqlDbType.VarChar).Value = ContratosAdicionales.usuario ;
                    cmdFB.Parameters.AddWithValue("FECHA", SqlDbType.DateTime).Value = ContratosAdicionales.fecha ;
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = ContratosAdicionales.idpersona ;
                    cmdFB.Parameters.AddWithValue("VALORANTERIOR", SqlDbType.Int).Value = ContratosAdicionales.valoranterior ;
                    cmdFB.Parameters.AddWithValue("FECHARETIRO", SqlDbType.DateTime).Value = ContratosAdicionales.fecharetiro ;
                    cmdFB.Parameters.AddWithValue("IDASESOR", SqlDbType.VarChar).Value = ContratosAdicionales.idasesor ;
                    
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

        
        public ContratosAdicionales get(string subdominio, string idContratosAdicionales)
        {
            ContratosAdicionales infoContratosAdicionales = new ContratosAdicionales();

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
                    cmdFB.CommandText = " P_AW_GETCONTRATOSADICIONALES ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idContratosAdicionales;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoContratosAdicionales.idca = dbDR.GetInt32(0);
                        infoContratosAdicionales.idcontrato = dbDR.GetString(1);
                        infoContratosAdicionales.idsadicional = dbDR.GetInt32(2);
                        infoContratosAdicionales.servicioadicional = dbDR.GetString(3);
                        infoContratosAdicionales.valor = dbDR.GetInt32(4);
                        infoContratosAdicionales.usuario = dbDR.GetString(5);
                        infoContratosAdicionales.fecha = dbDR.GetDateTime(6);
                        infoContratosAdicionales.idpersona = dbDR.GetString(7);
                        infoContratosAdicionales.valoranterior = dbDR.GetFloat(8);
                        if (dbDR["FECHARETIRO"] == DBNull.Value)
                        {
                            infoContratosAdicionales.fecharetiro    = null;
                        }else{
                            infoContratosAdicionales.fecharetiro    = dbDR.GetDateTime(8);
                        }
                        infoContratosAdicionales.idasesor = dbDR.GetString(10);
                        infoContratosAdicionales.asesor = dbDR.GetString(11);
                        infoContratosAdicionales.tipocobro = dbDR.GetInt16(12);
                       
                    }
                }
                catch (Exception ex)
                {
                    infoContratosAdicionales = null;
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
            return infoContratosAdicionales;
        }

        public List<ContratosAdicionales> list(string subdominio, string idcontrato)
        {
            List<ContratosAdicionales> lstContratosAdicionales = new List<ContratosAdicionales>();

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
                    cmdFB.CommandText = " P_AW_LISTCONTRATOADICIONALES ";
                   //  cmdFB.Parameters.AddWithValue("TITULAR", SqlDbType.VarChar).Value = identificaciontitular;
                    cmdFB.Parameters.AddWithValue("CONTRATO", SqlDbType.VarChar).Value = idcontrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        ContratosAdicionales contratosAdicionales = new ContratosAdicionales();
                        contratosAdicionales.idca = dbDR.GetInt32(0);
                        contratosAdicionales.idcontrato = dbDR.GetString(1);
                        contratosAdicionales.idsadicional = dbDR.GetInt32(2);
                        contratosAdicionales.servicioadicional = dbDR.GetString(3);
                        contratosAdicionales.valor = dbDR.GetInt32(4);
                        contratosAdicionales.usuario = dbDR.GetString(5);
                        contratosAdicionales.fecha = dbDR.GetDateTime(6);
                        contratosAdicionales.idpersona = dbDR.GetString(7);
                        contratosAdicionales.valoranterior = dbDR.GetFloat(8);
                        if (dbDR["FECHARETIRO"] == DBNull.Value)
                        {
                            contratosAdicionales.fecharetiro    = null;
                        }else{
                            contratosAdicionales.fecharetiro    = dbDR.GetDateTime(9);
                        }
                        contratosAdicionales.idasesor = dbDR.GetString(10);
                        contratosAdicionales.asesor = dbDR.GetString(11);
                        contratosAdicionales.tipocobro = dbDR.GetInt16(12);
                        lstContratosAdicionales.Add(contratosAdicionales);
                    }
                }
                catch (Exception ex)
                {
                    lstContratosAdicionales = null;
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
            return lstContratosAdicionales;
        }

    }
}