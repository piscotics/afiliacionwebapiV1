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
    public class ParentescoService
    {
        string rutaDBWeb = "";
        public Parentesco create(Parentesco Parentesco)
        {
            Parentesco resultado = new Parentesco();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Parentesco.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARPARENTESCO ";
                    cmdFB.Parameters.AddWithValue("PARENTESCO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Parentesco.parentesco);
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

        public Parentesco get(string idParentesco, string subdominio)
        {
            Parentesco infoParentesco = new Parentesco();

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
                    cmdFB.CommandText = " P_AW_GETPARENTESCO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = idParentesco;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoParentesco.idParentesco = dbDR.GetInt32(0).ToString();
                        infoParentesco.parentesco = dbDR.GetString(1);
                    }
                }
                catch (Exception ex)
                {
                    infoParentesco = null;
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
            return infoParentesco;
        }

        public Parentesco update(Parentesco Parentesco)
        {
            Parentesco resultado = new Parentesco();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Parentesco.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEPARENTESCO ";
                    cmdFB.Parameters.AddWithValue("IDPARENTESCO", SqlDbType.Int).Value = Parentesco.idParentesco;
                    cmdFB.Parameters.AddWithValue("PARENTESCO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Parentesco.parentesco);
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
        public List<Parentesco> list(string subdominio)
        {
            List<Parentesco> lstParentescos = new List<Parentesco>();

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
                    cmdFB.CommandText = " P_AW_LISTPARENTESCOS ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Parentesco parentesco = new Parentesco();
                        parentesco.idParentesco = dbDR.GetInt32(0).ToString();
                        parentesco.parentesco = dbDR.GetString(1);

                        lstParentescos.Add(parentesco);
                    }
                }
                catch (Exception ex)
                {
                    lstParentescos = null;
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
            return lstParentescos;
        }

    }
}