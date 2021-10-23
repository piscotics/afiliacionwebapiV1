using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using afiliacionwebapi.Models;
using afiliacionwebapi.utils;

namespace afiliacionwebapi.Services
{
    public class EmpresaService
    {
        string rutaDBWeb = "";
        public Empresa update(Empresa empresa)
        {
            Empresa resultado = new Empresa();

            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(empresa.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEEMPRESA ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = empresa.id;
                    cmdFB.Parameters.AddWithValue("NITEMPRESA", SqlDbType.VarChar).Value = empresa.nitEmpresa;
                    cmdFB.Parameters.AddWithValue("EMPRESA", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empresa.empresa);
                    cmdFB.Parameters.AddWithValue("TELEFONO1", SqlDbType.VarChar).Value = empresa.telefono1;
                    cmdFB.Parameters.AddWithValue("TELEFONO2", SqlDbType.VarChar).Value = empresa.telefono2;
                    cmdFB.Parameters.AddWithValue("DIRECCION", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empresa.direccion);
                    cmdFB.Parameters.AddWithValue("ESTADO", SqlDbType.Int).Value = empresa.estado;
                    cmdFB.Parameters.AddWithValue("MULTIAFILIACION", SqlDbType.Int).Value = empresa.multiAfiliacion;
                    cmdFB.Parameters.AddWithValue("BANNERSUPERIOR", SqlDbType.VarChar).Value = empresa.bannerSuperior.ToLower();
                    cmdFB.Parameters.AddWithValue("BANNERINFERIOR", SqlDbType.VarChar).Value = empresa.bannerInferior.ToLower();
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
                    resultado = null;
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
            return resultado;
        }

        public Empresa get(string subdominio)
        {
            Empresa infoEmpresa = new Empresa();

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
                    cmdFB.CommandText = " P_AW_GETEMPRESA ";
                    //cmdFB.Parameters.AddWithValue("NIT", SqlDbType.Int).Value = empresa.nitEmpresa;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoEmpresa.nitEmpresa = dbDR.GetString(0);
                        infoEmpresa.empresa = dbDR.GetString(1);
                        infoEmpresa.telefono1 = dbDR.GetString(2);
                        infoEmpresa.telefono2 = dbDR.GetString(3);
                        infoEmpresa.direccion = dbDR.GetString(4);
                        infoEmpresa.estado = dbDR.GetInt16(5);
                        infoEmpresa.multiAfiliacion = dbDR.GetInt16(6);
                        infoEmpresa.bannerSuperior = dbDR.GetString(7);
                        infoEmpresa.bannerInferior = dbDR.GetString(8);
                        infoEmpresa.erp = dbDR.GetInt16(9);
                    }
                }
                catch (Exception ex)
                {
                    infoEmpresa = null;
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
            return infoEmpresa;
        }
    }
}