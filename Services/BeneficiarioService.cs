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
    public class BeneficiarioService
    {
        string rutaDBWeb = "";

        public Beneficiario get(string subdominio, string identificacion)
        {
            Beneficiario infoBeneficiario = new Beneficiario();

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
                    cmdFB.CommandText = " P_AW_GETBENEFICIARIO";
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.Int).Value = identificacion;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoBeneficiario.codRespuesta = dbDR.GetString(20);
                        infoBeneficiario.msjRespuesta = dbDR.GetString(21);

                        if (dbDR["IDPERSONA"] != DBNull.Value)
                        {
                            infoBeneficiario.identificacion = dbDR.GetString(0);
                            Titular titular = new Titular();
                            if (dbDR["IDENTIFICACIONTITULAR"] == DBNull.Value)
                            {
                                titular = null;
                            }
                            else
                            {
                                titular.identificacion = dbDR.GetString(1);
                            }
                            infoBeneficiario.identificaciontitular = titular;
                            infoBeneficiario.nombre1 = dbDR.GetString(2);
                            infoBeneficiario.nombre2 = dbDR.GetString(3);
                            infoBeneficiario.apellido1 = dbDR.GetString(4);
                            infoBeneficiario.apellido2 = dbDR.GetString(5);
                            infoBeneficiario.telefono = dbDR.GetString(6);
                            infoBeneficiario.celular = dbDR.GetString(7);
                            if (dbDR["FECHANACIMIENTO"] == DBNull.Value)
                            {
                                infoBeneficiario.fechaNacimiento = null;
                            } else
                            {
                                infoBeneficiario.fechaNacimiento = dbDR.GetDateTime(8);
                            }
                            infoBeneficiario.genero = dbDR.GetString(9);
                            if (dbDR["FECHACOBERTURA"] == DBNull.Value)
                            {
                                infoBeneficiario.fechaCobertura = null;
                            }
                            else
                            {
                                infoBeneficiario.fechaCobertura = dbDR.GetDateTime(10);
                            }
                            infoBeneficiario.observaciones = dbDR.GetString(12);
                            infoBeneficiario.edadAfiliacion = dbDR.GetInt32(13);
                            Parentesco parentesco = new Parentesco();
                            if (dbDR["IDPARENTESCO"] == DBNull.Value)
                            {
                                parentesco = null;
                            }
                            else
                            {
                                parentesco.idParentesco = dbDR.GetString(14);
                            }
                            infoBeneficiario.idParentesco = parentesco;
                            infoBeneficiario.adicional = dbDR.GetInt32(15);
                            infoBeneficiario.fallecido = dbDR.GetInt32(16);
                            infoBeneficiario.retirado = dbDR.GetInt32(17);
                            if (dbDR["FECHAFALLECIDO"] == DBNull.Value)
                            {
                                infoBeneficiario.fechafallecido = null;
                            }
                            else
                            {
                               infoBeneficiario.fechafallecido = dbDR.GetDateTime(18);
                            }
                            if (dbDR["FECHARETIRADO"] == DBNull.Value)
                            {
                                infoBeneficiario.fecharetirado = null;
                            }
                            else
                            {
                                infoBeneficiario.fecharetirado = dbDR.GetDateTime(19);
                            }
                            
                            
                            
                        }

                    }

                } catch(Exception ex)
                {
                    infoBeneficiario = null;
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

            return infoBeneficiario;
        }

        public Beneficiario update(Beneficiario Beneficiario)
        {
            Beneficiario resultado = new Beneficiario();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Beneficiario.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEBENEFICIARIO";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = Beneficiario.id;
                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = Beneficiario.identificacion;
                    cmdFB.Parameters.AddWithValue("IDENTIFICACIONTITULR", SqlDbType.VarChar).Value = Beneficiario.identificaciontitular.identificacion;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.apellido2);
                    cmdFB.Parameters.AddWithValue("TELEFONO", SqlDbType.VarChar).Value = Beneficiario.telefono;
                    cmdFB.Parameters.AddWithValue("CELULAR1", SqlDbType.VarChar).Value = Beneficiario.celular;
                    cmdFB.Parameters.AddWithValue("FECHANACIMIENTO", SqlDbType.VarChar).Value = Beneficiario.fechaNacimiento;
                    cmdFB.Parameters.AddWithValue("GENERO", SqlDbType.VarChar).Value = Beneficiario.genero;
                    cmdFB.Parameters.AddWithValue("FECHACOBERTURA", SqlDbType.VarChar).Value = Beneficiario.fechaCobertura;
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = Beneficiario.observaciones;
                    cmdFB.Parameters.AddWithValue("IDPARENTESCO", SqlDbType.VarChar).Value = Beneficiario.idParentesco.idParentesco;
                    cmdFB.Parameters.AddWithValue("ADICIONAL", SqlDbType.VarChar).Value = Beneficiario.adicional;
                    cmdFB.Parameters.AddWithValue("FALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fallecido;
                    cmdFB.Parameters.AddWithValue("RETIRADO", SqlDbType.VarChar).Value = Beneficiario.retirado;
                    cmdFB.Parameters.AddWithValue("FECHAFALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fechafallecido;
                    cmdFB.Parameters.AddWithValue("FECHARETIRADO", SqlDbType.VarChar).Value = Beneficiario.fecharetirado;
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

        public Beneficiario create(Beneficiario Beneficiario)
        {
            Beneficiario resultado = new Beneficiario();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(Beneficiario.subdominio);
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
                    cmdFB.CommandText = "P_AW_CREARBENEFICIARIO";
                     cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = Beneficiario.identificacion;
                    cmdFB.Parameters.AddWithValue("IDENTIFICACIONTITULR", SqlDbType.VarChar).Value = Beneficiario.identificaciontitular.identificacion;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(Beneficiario.apellido2);
                    cmdFB.Parameters.AddWithValue("TELEFONO", SqlDbType.VarChar).Value = Beneficiario.telefono;
                    cmdFB.Parameters.AddWithValue("CELULAR1", SqlDbType.VarChar).Value = Beneficiario.celular;
                    cmdFB.Parameters.AddWithValue("FECHANACIMIENTO", SqlDbType.VarChar).Value = Beneficiario.fechaNacimiento;
                    cmdFB.Parameters.AddWithValue("GENERO", SqlDbType.VarChar).Value = Beneficiario.genero;
                    cmdFB.Parameters.AddWithValue("FECHACOBERTURA", SqlDbType.VarChar).Value = Beneficiario.fechaCobertura;
                    cmdFB.Parameters.AddWithValue("FECHAAFILIACION", SqlDbType.Date).Value = Beneficiario.fechaAfiliacion;
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = Beneficiario.observaciones;
                    cmdFB.Parameters.AddWithValue("IDPARENTESCO", SqlDbType.VarChar).Value = Beneficiario.idParentesco.idParentesco;
                    cmdFB.Parameters.AddWithValue("ADICIONAL", SqlDbType.VarChar).Value = Beneficiario.adicional;
                    cmdFB.Parameters.AddWithValue("FALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fallecido;
                    cmdFB.Parameters.AddWithValue("RETIRADO", SqlDbType.VarChar).Value = Beneficiario.retirado;
                    cmdFB.Parameters.AddWithValue("FECHAFALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fechafallecido;
                    cmdFB.Parameters.AddWithValue("FECHARETIRADO", SqlDbType.VarChar).Value = Beneficiario.fecharetirado;

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