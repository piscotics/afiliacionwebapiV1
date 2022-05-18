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

        public List<Beneficiario> list(string subdominio, string identificaciontitular, string idcontrato)
        {
            List<Beneficiario> lstBeneficiarios = new List<Beneficiario>();

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
                    cmdFB.CommandText = " P_AW_LISTBENEFICIARIOS ";
                    cmdFB.Parameters.AddWithValue("IDENTIFICACIONTITULAR", SqlDbType.VarChar).Value = identificaciontitular;
                    cmdFB.Parameters.AddWithValue("CONTRATO", SqlDbType.VarChar).Value = idcontrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                      

                        Beneficiario beneficiarios = new Beneficiario();
                        beneficiarios.identificacion = dbDR.GetString(0);
                        beneficiarios.identificaciontitular = dbDR.GetString(1);
                        beneficiarios.nombre1 = dbDR.GetString(2);
                        beneficiarios.nombre2 = dbDR.GetString(3);
                        beneficiarios.apellido1 = dbDR.GetString(4);
                        beneficiarios.apellido2 = dbDR.GetString(5);
                        beneficiarios.telefono = dbDR.GetString(6);
                        beneficiarios.celular = dbDR.GetString(7);
                        if (dbDR["FECHANACIMIENTO"] != DBNull.Value)
                        {
                            beneficiarios.fechaNacimiento = dbDR.GetDateTime(8);
                        }else{
                            beneficiarios.fechaNacimiento  =  Convert.ToDateTime("1999-01-01");
                        }
                        beneficiarios.genero = dbDR.GetString(9);
                        beneficiarios.fechaCobertura = dbDR.GetDateTime(10);
                        beneficiarios.fechaAfiliacion = dbDR.GetDateTime(11);
                        beneficiarios.observaciones = dbDR.GetString(12);
                        if (dbDR["EDADAFILIACION"] != DBNull.Value)
                        {
                            beneficiarios.edadAfiliacion =  dbDR.GetInt64(13);
                        }else{
                            beneficiarios.edadAfiliacion  =  0;
                        }
                        beneficiarios.idParentesco = dbDR.GetInt32(14).ToString();
                        beneficiarios.parentesco = dbDR.GetString(15);
                        beneficiarios.adicional = dbDR.GetInt32(16);
                        beneficiarios.fallecido = dbDR.GetInt32(17);
                        beneficiarios.retirado = dbDR.GetInt32(18);
                        if (dbDR["FECHAFALLECIDO"] != DBNull.Value)
                        {
                            beneficiarios.fechafallecido = dbDR.GetDateTime(19);
                        }else{
                            beneficiarios.fechafallecido  =  Convert.ToDateTime("1999-01-01");
                        }
                        if (dbDR["FECHARETIRADO"] != DBNull.Value)
                        {
                            beneficiarios.fecharetirado = dbDR.GetDateTime(20);
                        }else{
                            beneficiarios.fecharetirado  = null;
                        }
                        beneficiarios.contrato = dbDR.GetString(21);
                        beneficiarios.valoradicional = dbDR.GetFloat(22);
                        beneficiarios.estadobeneficiario = dbDR.GetString(23);
                   
                        lstBeneficiarios.Add(beneficiarios);
                    }
                }
                catch (Exception ex)
                {
                    lstBeneficiarios = null;
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
            return lstBeneficiarios;
        }


        public Beneficiario get(string subdominio, string identificacion)
        {
            Beneficiario beneficiarios = new Beneficiario();

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
                        beneficiarios.codRespuesta = dbDR.GetString(24);
                        beneficiarios.msjRespuesta = dbDR.GetString(25);

                        if (dbDR["IDENTIFICACION"] != DBNull.Value)
                        {
                           
                            beneficiarios.identificacion = dbDR.GetString(0);
                            beneficiarios.identificaciontitular = dbDR.GetString(1);
                            beneficiarios.nombre1 = dbDR.GetString(2);
                            beneficiarios.nombre2 = dbDR.GetString(3);
                            beneficiarios.apellido1 = dbDR.GetString(4);
                            beneficiarios.apellido2 = dbDR.GetString(5);
                            beneficiarios.telefono = dbDR.GetString(6);
                            beneficiarios.celular = dbDR.GetString(7);
                            if (dbDR["FECHANACIMIENTO"] != DBNull.Value)
                            {
                                beneficiarios.fechaNacimiento = dbDR.GetDateTime(8);
                            }else{
                                beneficiarios.fechaNacimiento  =  Convert.ToDateTime("1999-01-01");
                            }
                            beneficiarios.genero = dbDR.GetString(9);
                            beneficiarios.fechaCobertura = dbDR.GetDateTime(10);
                            beneficiarios.fechaAfiliacion = dbDR.GetDateTime(11);
                            beneficiarios.observaciones = dbDR.GetString(12);
                            if (dbDR["EDADAFILIACION"] != DBNull.Value)
                            {
                               beneficiarios.edadAfiliacion =  dbDR.GetInt64(13);
                            }else{
                                 beneficiarios.edadAfiliacion  =  0;
                            }
                            beneficiarios.idParentesco = dbDR.GetInt32(14).ToString();
                            beneficiarios.parentesco = dbDR.GetString(15);
                            beneficiarios.adicional = dbDR.GetInt32(16);
                            beneficiarios.fallecido = dbDR.GetInt32(17);
                            beneficiarios.retirado = dbDR.GetInt32(18);
                            if (dbDR["FECHAFALLECIDO"] != DBNull.Value)
                            {
                                 beneficiarios.fechafallecido = dbDR.GetDateTime(19);
                            }else{
                                beneficiarios.fechafallecido  =  Convert.ToDateTime("1999-01-01");
                            }
                            if (dbDR["FECHARETIRADO"] != DBNull.Value)
                            {
                                 beneficiarios.fecharetirado = dbDR.GetDateTime(20);
                            }else{
                                beneficiarios.fecharetirado  = null;
                            }
                           
                            beneficiarios.contrato = dbDR.GetString(21);
                            beneficiarios.valoradicional = dbDR.GetFloat(22);
                            beneficiarios.estadobeneficiario = dbDR.GetString(23);
                            
                        }

                    }

                } catch(Exception ex)
                {
                    beneficiarios = null;
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

            return beneficiarios;
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
                     cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = Beneficiario.identificacion;
                    cmdFB.Parameters.AddWithValue("IDENTIFICACIONTITULR", SqlDbType.VarChar).Value = Beneficiario.identificaciontitular;
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
                    cmdFB.Parameters.AddWithValue("IDPARENTESCO", SqlDbType.VarChar).Value = Beneficiario.idParentesco;
                    cmdFB.Parameters.AddWithValue("ADICIONAL", SqlDbType.VarChar).Value = Beneficiario.adicional;
                    cmdFB.Parameters.AddWithValue("FALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fallecido;
                    cmdFB.Parameters.AddWithValue("RETIRADO", SqlDbType.Int).Value = Beneficiario.retirado;
                    cmdFB.Parameters.AddWithValue("FECHAFALLECIDO", SqlDbType.DateTime).Value = Beneficiario.fechafallecido;
                    cmdFB.Parameters.AddWithValue("FECHARETIRADO", SqlDbType.DateTime).Value = Beneficiario.fecharetirado;
                    cmdFB.Parameters.AddWithValue("CONTRATO", SqlDbType.VarChar).Value = Beneficiario.contrato;
                    cmdFB.Parameters.AddWithValue("VALORADICIONAL", SqlDbType.Float).Value = Beneficiario.valoradicional;

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
                    cmdFB.Parameters.AddWithValue("IDENTIFICACIONTITULR", SqlDbType.VarChar).Value = Beneficiario.identificaciontitular;
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
                    cmdFB.Parameters.AddWithValue("IDPARENTESCO", SqlDbType.VarChar).Value = Beneficiario.idParentesco;
                    cmdFB.Parameters.AddWithValue("ADICIONAL", SqlDbType.VarChar).Value = Beneficiario.adicional;
                    cmdFB.Parameters.AddWithValue("FALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fallecido;
                    cmdFB.Parameters.AddWithValue("RETIRADO", SqlDbType.VarChar).Value = Beneficiario.retirado;
                    cmdFB.Parameters.AddWithValue("FECHAFALLECIDO", SqlDbType.VarChar).Value = Beneficiario.fechafallecido;
                    cmdFB.Parameters.AddWithValue("FECHARETIRADO", SqlDbType.VarChar).Value =Beneficiario.fecharetirado;// Beneficiario.fecharetirado;
                    cmdFB.Parameters.AddWithValue("CONTRATO", SqlDbType.VarChar).Value = Beneficiario.contrato;
                    cmdFB.Parameters.AddWithValue("VALORADICIONAL", SqlDbType.Float).Value = Beneficiario.valoradicional;

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