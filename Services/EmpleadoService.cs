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
    public class EmpleadoService
    {
        string rutaDBWeb = "";

        public List<Empleado> list(string subdominio, string tipoEmpleado)
        {
            List<Empleado> lstEmpleados = new List<Empleado>();

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
                    cmdFB.CommandText = " P_AW_LISTEMPLEADOS ";
                    cmdFB.Parameters.AddWithValue("TIPO", SqlDbType.VarChar).Value = tipoEmpleado.ToUpper();
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Empleado empleado = new Empleado();
                        empleado.idPersona = dbDR.GetString(0);
                        empleado.nombre1 = dbDR.GetString(1);
                        empleado.nombre2 = dbDR.GetString(2);
                        empleado.apellido1 = dbDR.GetString(3);
                        empleado.apellido2 = dbDR.GetString(4);
                        empleado.telefono1 = dbDR.GetString(5);
                        empleado.telefono2 = dbDR.GetString(6);
                        empleado.estado = dbDR.GetInt16(7);
                        empleado.tipoEmpleado = dbDR.GetString(8);

                        lstEmpleados.Add(empleado);
                    }
                }
                catch (Exception ex)
                {
                    lstEmpleados = null;
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
            return lstEmpleados;
        }

        public Empleado get(string subdominio, string identificacion)
        {
            Empleado infoEmpleado = new Empleado();

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
                    cmdFB.CommandText = " P_AW_GETEMPLEADO ";
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = identificacion;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoEmpleado.idPersona = dbDR.GetString(0);
                        infoEmpleado.nombre1 = dbDR.GetString(1);
                        infoEmpleado.nombre2 = dbDR.GetString(2);
                        infoEmpleado.apellido1 = dbDR.GetString(3);
                        infoEmpleado.apellido2 = dbDR.GetString(4);
                        infoEmpleado.telefono1 = dbDR.GetString(5);
                        infoEmpleado.telefono2 = dbDR.GetString(6);
                        infoEmpleado.estado = dbDR.GetInt16(7);
                        infoEmpleado.tipoEmpleado = dbDR.GetString(8);
                    }

                }
                catch (Exception ex)
                {
                    infoEmpleado = null;
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

            return infoEmpleado;
        }

        public Empleado update(Empleado empleado)
        {
            Empleado resultado = new Empleado();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(empleado.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEEMPLEADO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = empleado.id;
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = empleado.idPersona;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.apellido2);
                    cmdFB.Parameters.AddWithValue("TELEFONO1", SqlDbType.VarChar).Value = empleado.telefono1;
                    cmdFB.Parameters.AddWithValue("TELEFONO2", SqlDbType.VarChar).Value = empleado.telefono2;
                    cmdFB.Parameters.AddWithValue("ESTADO", SqlDbType.Int).Value = empleado.estado;
                    cmdFB.Parameters.AddWithValue("TIPOEMPLEADO", SqlDbType.VarChar).Value = empleado.tipoEmpleado;
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

        public Empleado create(Empleado empleado)
        {
            Empleado resultado = new Empleado();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(empleado.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREAREMPLEADO ";
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = empleado.idPersona;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(empleado.apellido2);
                    cmdFB.Parameters.AddWithValue("TELEFONO1", SqlDbType.VarChar).Value = empleado.telefono1;
                    cmdFB.Parameters.AddWithValue("TELEFONO2", SqlDbType.VarChar).Value = empleado.telefono2;
                    cmdFB.Parameters.AddWithValue("TIPOEMPLEADO", SqlDbType.VarChar).Value = empleado.tipoEmpleado;
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