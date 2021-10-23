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
    public class TitularService
    {
        string rutaDBWeb = "";

        public Titular get(string subdominio, string identificacion)
        {
            Titular infoTitular = new Titular();

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
                    cmdFB.CommandText = " P_AW_GETTITULAR ";
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.Int).Value = identificacion;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoTitular.codRespuesta = dbDR.GetString(19);
                        infoTitular.msjRespuesta = dbDR.GetString(20);

                        if (dbDR["IDPERSONA"] != DBNull.Value)
                        {
                            infoTitular.identificacion = dbDR.GetString(0);
                            infoTitular.nombre1 = dbDR.GetString(1);
                            infoTitular.nombre2 = dbDR.GetString(2);
                            infoTitular.apellido1 = dbDR.GetString(3);
                            infoTitular.apellido2 = dbDR.GetString(4);

                            Departamento departamento = new Departamento();
                            if (dbDR["IDDEPARTAMENTO"] == DBNull.Value)
                            {
                                departamento = null;
                            }
                            else
                            {
                                departamento.codDepartamento = dbDR.GetString(5);
                                departamento.departamento = dbDR.GetString(6);
                            }

                            Municipio municipio = new Municipio();
                            if (dbDR["IDMUNICIPIO"] == DBNull.Value)
                            {
                                municipio = null;
                            }
                            else
                            {
                                municipio.idMunicipio = dbDR.GetInt32(7).ToString();
                                municipio.municipio = dbDR.GetString(8);
                            }

                            infoTitular.departamento = departamento;
                            infoTitular.municipio = municipio;
                            infoTitular.direccion = dbDR.GetString(9);
                            infoTitular.barrio = dbDR.GetString(10);
                            infoTitular.telefono = dbDR.GetString(11);
                            infoTitular.celular1 = dbDR.GetString(12);
                            infoTitular.celular2 = dbDR.GetString(13);
                            infoTitular.email = dbDR.GetString(14);

                            if (dbDR["FECHANACIMIENTO"] == DBNull.Value)
                            {
                                infoTitular.fechaNacimiento = null;
                            } else
                            {
                                infoTitular.fechaNacimiento = dbDR.GetDateTime(15);
                            }
                            infoTitular.edadAfiliacion = dbDR.GetInt32(16);
                            infoTitular.genero = dbDR.GetString(17);

                            if (dbDR["FECHACOBERTURA"] == DBNull.Value)
                            {
                                infoTitular.fechaCobertura = null;
                            }
                            else
                            {
                                infoTitular.fechaCobertura = dbDR.GetDateTime(18);
                            }
                        }

                    }

                } catch(Exception ex)
                {
                    infoTitular = null;
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

            return infoTitular;
        }

        public Titular update(Titular titular)
        {
            Titular resultado = new Titular();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(titular.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATETITULAR ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = titular.id;
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = titular.identificacion;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.apellido2);
                    cmdFB.Parameters.AddWithValue("IDDEPARTAMENTO", SqlDbType.VarChar).Value = titular.departamento.codDepartamento;
                    cmdFB.Parameters.AddWithValue("IDMUNICIPIO", SqlDbType.VarChar).Value = titular.municipio.idMunicipio;
                    cmdFB.Parameters.AddWithValue("DIRECCION", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.direccion);
                    cmdFB.Parameters.AddWithValue("BARRIO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.barrio);
                    cmdFB.Parameters.AddWithValue("TELEFONO", SqlDbType.VarChar).Value = titular.telefono;
                    cmdFB.Parameters.AddWithValue("CELULAR1", SqlDbType.VarChar).Value = titular.celular1;
                    cmdFB.Parameters.AddWithValue("CELULAR2", SqlDbType.VarChar).Value = titular.celular2;
                    cmdFB.Parameters.AddWithValue("EMAIL", SqlDbType.VarChar).Value = titular.email.ToLower();
                    cmdFB.Parameters.AddWithValue("FECHANACIMIENTO", SqlDbType.VarChar).Value = titular.fechaNacimiento;
                    cmdFB.Parameters.AddWithValue("GENERO", SqlDbType.VarChar).Value = titular.genero;
                    cmdFB.Parameters.AddWithValue("FECHACOBERTURA", SqlDbType.VarChar).Value = titular.fechaCobertura;
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

        public Titular create(Titular titular)
        {
            Titular resultado = new Titular();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(titular.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARTITULAR ";
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = titular.identificacion;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.apellido2);
                    cmdFB.Parameters.AddWithValue("IDDEPARTAMENTO", SqlDbType.VarChar).Value = titular.departamento.codDepartamento;
                    cmdFB.Parameters.AddWithValue("IDMUNICIPIO", SqlDbType.Int).Value = titular.municipio.idMunicipio;
                    cmdFB.Parameters.AddWithValue("DIRECCION", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.direccion);
                    cmdFB.Parameters.AddWithValue("BARRIO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(titular.barrio);
                    cmdFB.Parameters.AddWithValue("TELEFONO", SqlDbType.VarChar).Value = titular.telefono;
                    cmdFB.Parameters.AddWithValue("CELULAR1", SqlDbType.VarChar).Value = titular.celular1;
                    cmdFB.Parameters.AddWithValue("CELULAR2", SqlDbType.VarChar).Value = titular.celular2;
                    cmdFB.Parameters.AddWithValue("EMAIL", SqlDbType.VarChar).Value = titular.email.ToLower();
                    cmdFB.Parameters.AddWithValue("FECHANACIMIENTO", SqlDbType.Date).Value = titular.fechaNacimiento;
                    cmdFB.Parameters.AddWithValue("GENERO", SqlDbType.VarChar).Value = titular.genero;
                    cmdFB.Parameters.AddWithValue("FECHACOBERTURA", SqlDbType.Date).Value = titular.fechaCobertura;
                    cmdFB.Parameters.AddWithValue("FECHAAFILIACION", SqlDbType.Date).Value = titular.fechaAfiliacion;
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