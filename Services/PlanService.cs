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
    public class PlanService : Plan
    {
        string rutaDBWeb = "";

        public Plan create(Plan plan)
        {
            Plan resultado = new Plan();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(plan.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARPLAN ";
                    cmdFB.Parameters.AddWithValue("NOMBREPLAN", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(plan.nombrePlan);
                    cmdFB.Parameters.AddWithValue("VALORBASE", SqlDbType.Float).Value = plan.valorBase;
                    cmdFB.Parameters.AddWithValue("VALORADICIONAL", SqlDbType.Float).Value = plan.valorAdicional;
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

        public Plan get(string id, string subdominio)
        {
            Plan infoPlan = new Plan();

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
                    cmdFB.CommandText = " P_AW_GETPLAN ";
                    cmdFB.Parameters.AddWithValue("IDPLAN", SqlDbType.Int).Value = id;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoPlan.id = dbDR.GetInt32(0).ToString();
                        infoPlan.nombrePlan = dbDR.GetString(1);
                        infoPlan.valorBase = dbDR.GetFloat(2);
                        infoPlan.valorAdicional = dbDR.GetFloat(3);
                        infoPlan.estado = dbDR.GetInt16(4);
                    }
                }
                catch (Exception ex)
                {
                    infoPlan = null;
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
            return infoPlan;
        }

        public Plan update(Plan plan)
        {
            Plan resultado = new Plan();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(plan.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEPLAN ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.Int).Value = plan.id;
                    cmdFB.Parameters.AddWithValue("NOMBREPLAN", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(plan.nombrePlan);
                    cmdFB.Parameters.AddWithValue("ESTADO", SqlDbType.VarChar).Value = plan.estado;
                    cmdFB.Parameters.AddWithValue("VALORBASE", SqlDbType.VarChar).Value = plan.valorBase;
                    cmdFB.Parameters.AddWithValue("VALORADICIONAL", SqlDbType.VarChar).Value = plan.valorAdicional;
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

        public List<Plan> list(string subdominio)
        {
            List<Plan> lstPlanes = new List<Plan>();

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
                    cmdFB.CommandText = " P_AW_LISTPLANES ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Plan plan = new Plan();
                        plan.id = dbDR.GetInt32(0).ToString();
                        plan.nombrePlan = dbDR.GetString(1);
                        plan.valorBase = dbDR.GetFloat(2);
                        plan.valorAdicional = dbDR.GetFloat(3);

                        lstPlanes.Add(plan);
                    }
                }
                catch (Exception ex)
                {
                    lstPlanes = null;
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
            return lstPlanes;
        }
    }
}