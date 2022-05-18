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
    public class EmpresasService
    {
        string rutaDBWeb = "";
        

        public Empresas get(string subdominio)
        {
            Empresas infoEmpresas = new Empresas();

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
                    cmdFB.CommandText = " P_AW_GETEMPRESAS ";
                    //cmdFB.Parameters.AddWithValue("NIT", SqlDbType.Int).Value = empresa.nitEmpresas;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoEmpresas.idEmpresas = dbDR.GetInt32(0);
                        infoEmpresas.nitEmpresa = dbDR.GetString(1);
                        infoEmpresas.empresa = dbDR.GetString(2);
                        infoEmpresas.telefono1 = dbDR.GetString(3);
                        infoEmpresas.telefono2 = dbDR.GetString(4);
                        infoEmpresas.direccion = dbDR.GetString(5);
                        infoEmpresas.estado = dbDR.GetInt16(6);
                      
                    }
                }
                catch (Exception ex)
                {
                    infoEmpresas = null;
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
            return infoEmpresas;
        }

        public List<Empresas> list(string subdominio)
        {
            List<Empresas> lstEmpresas = new List<Empresas>();

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
                    cmdFB.CommandText = " P_AW_LISTEMPRESAS ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Empresas empresas = new Empresas();
                        empresas.idEmpresas = dbDR.GetInt32(0);
                        empresas.nitEmpresa = dbDR.GetString(1);
                        empresas.empresa = dbDR.GetString(2);
                        empresas.telefono1 = dbDR.GetString(3);
                        empresas.telefono2 = dbDR.GetString(4);
                        empresas.direccion = dbDR.GetString(5);
                        empresas.estado = dbDR.GetInt16(6);
                        lstEmpresas.Add(empresas);
                    }
                }
                catch (Exception ex)
                {
                    lstEmpresas = null;
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
            return lstEmpresas;
        }
    }

    
}