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
    public class ContratoService
    {
        string rutaDBWeb = "";

        public Contrato get(string subdominio, string idContrato, string tipoBusqueda)
        {
            Contrato infoContrato = new Contrato();

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
                    cmdFB.CommandText = " P_AW_GETCONTRATO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = idContrato;
                    cmdFB.Parameters.AddWithValue("TIPOBUSQUEDA", SqlDbType.VarChar).Value = tipoBusqueda;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {

                        infoContrato.codRespuesta = dbDR.GetString(0);
                        infoContrato.msjRespuesta = dbDR.GetString(1);

                        if (dbDR["IDCONTRATO"]!= DBNull.Value)
                        {
                            infoContrato.idContrato = dbDR.GetString(2);

                            Titular titular = new Titular();
                            titular.identificacion = dbDR.GetString(3);
                            titular.nombre1 = dbDR.GetString(4);
                            titular.nombre2 = dbDR.GetString(5);
                            titular.apellido1 = dbDR.GetString(6);
                            titular.apellido2 = dbDR.GetString(7);

                            Departamento departamento = new Departamento();
                            departamento.codDepartamento = dbDR.GetString(8);
                            departamento.departamento = dbDR.GetString(9);
                            titular.departamento = departamento;

                            Municipio municipio = new Municipio();
                            municipio.idMunicipio = dbDR.GetInt32(10).ToString();
                            municipio.municipio = dbDR.GetString(11);
                            titular.municipio = municipio;

                            titular.direccion = dbDR.GetString(12);
                            titular.barrio = dbDR.GetString(13);
                            titular.telefono = dbDR.GetString(14);
                            titular.celular1 = dbDR.GetString(15);
                            titular.celular2 = dbDR.GetString(16);
                            titular.email = dbDR.GetString(17);
                            titular.fechaNacimiento = dbDR.GetDateTime(18);
                            titular.edadAfiliacion = dbDR.GetInt32(19);
                            titular.genero = dbDR.GetString(20);
                            titular.fechaCobertura = dbDR.GetDateTime(21);
                            infoContrato.titular = titular;

                            infoContrato.tipoAfiliacion = dbDR.GetString(22);
                            infoContrato.fechaAfiliacion = dbDR.GetDateTime(23);
                            infoContrato.estatus = dbDR.GetString(24);
                            infoContrato.vigenciaDesde = dbDR.GetDateTime(25);
                            infoContrato.vigenciaHasta = dbDR.GetDateTime(26);
                            infoContrato.valorCuota = dbDR.GetFloat(27);
                            infoContrato.diaCobro = dbDR.GetInt32(28);

                            FormaPago formaPago = new FormaPago();
                            formaPago.idFormaPago = dbDR.GetInt32(29).ToString();
                            formaPago.formaPago = dbDR.GetString(30);
                            infoContrato.formaPago = formaPago;

                            Plan plan = new Plan();
                            plan.id = dbDR.GetInt32(31).ToString();
                            plan.nombrePlan = dbDR.GetString(32);
                            plan.valorBase = dbDR.GetFloat(33);
                            plan.valorAdicional = dbDR.GetFloat(34);
                            infoContrato.plan = plan;

                            Zona zona = new Zona();
                            zona.id = dbDR.GetInt32(35).ToString();
                            zona.nombreZona = dbDR.GetString(36);
                            infoContrato.zona = zona;

                            Sucursal sucursal = new Sucursal();
                            sucursal.id = dbDR.GetInt32(37).ToString();
                            sucursal.nombreSucursal = dbDR.GetString(38);
                            infoContrato.sucursal = sucursal;

                            Empleado cobrador = new Empleado();
                            cobrador.idPersona = dbDR.GetString(39);
                            cobrador.nombre1 = dbDR.GetString(40);
                            cobrador.nombre2 = dbDR.GetString(41);
                            cobrador.apellido1 = dbDR.GetString(42);
                            cobrador.apellido2 = dbDR.GetString(43);
                            infoContrato.cobrador = cobrador;

                            Empleado vendedor = new Empleado();
                            vendedor.idPersona = dbDR.GetString(44);
                            vendedor.nombre1 = dbDR.GetString(45);
                            vendedor.nombre2 = dbDR.GetString(46);
                            vendedor.apellido1 = dbDR.GetString(47);
                            vendedor.apellido2 = dbDR.GetString(48);
                            infoContrato.vendedor = vendedor;

                            infoContrato.direccionCobro = dbDR.GetString(49);
                            infoContrato.observaciones = dbDR.GetString(50);

                            Empresas empresas = new Empresas();
                            if (dbDR["NITEMPRESA"] == DBNull.Value)
                            {
                                empresas.nitEmpresa = null;
                                empresas.empresa = null;
                            }else{
                                empresas.nitEmpresa = dbDR.GetString(51);
                                empresas.empresa = dbDR.GetString(52);
                            }
                            infoContrato.empresas = empresas;

                            if (dbDR["FECHAULTIMOPAGO"] == DBNull.Value)
                            {
                                infoContrato.fechaUltimoPago = null;
                            }else{
                                infoContrato.fechaUltimoPago = dbDR.GetDateTime(53);
                            }

                            if (dbDR["PAGOHASTA"] == DBNull.Value)
                            {
                                infoContrato.pagoHasta = null;
                            }else{
                                infoContrato.pagoHasta = dbDR.GetDateTime(54);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    infoContrato = null;
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
            return infoContrato;
        }

        public List<Contrato> list(string subdominio, string criterio, string tipoBusqueda)
        {
           
            List<Contrato> lstContrato = new List<Contrato>();
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
                    cmdFB.CommandText = " P_AW_GETCONTRATO ";
                    cmdFB.Parameters.AddWithValue("ID", SqlDbType.VarChar).Value = criterio;
                    cmdFB.Parameters.AddWithValue("TIPOBUSQUEDA", SqlDbType.VarChar).Value = tipoBusqueda;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {

                      

                        if (dbDR["IDCONTRATO"]!= DBNull.Value)
                        {
                            
                            Contrato infoContrato = new Contrato();

                            infoContrato.idContrato = dbDR.GetString(2);

                            Titular titular = new Titular();
                            titular.identificacion = dbDR.GetString(3);
                            titular.nombre1 = dbDR.GetString(4);
                            titular.nombre2 = dbDR.GetString(5);
                            titular.apellido1 = dbDR.GetString(6);
                            titular.apellido2 = dbDR.GetString(7);
                            
                            
                            infoContrato.identificacion =titular.identificacion;
                            infoContrato.nombre1 = titular.nombre1;
                            infoContrato.nombre2 = titular.nombre2;
                            infoContrato.apellido1 = titular.apellido1;
                            infoContrato.apellido2 = titular.apellido2;


                            Departamento departamento = new Departamento();
                            departamento.codDepartamento = dbDR.GetString(8);
                            departamento.departamento = dbDR.GetString(9);
                            titular.departamento = departamento;

                            Municipio municipio = new Municipio();
                            municipio.idMunicipio = dbDR.GetInt32(10).ToString();
                            municipio.municipio = dbDR.GetString(11);
                            titular.municipio = municipio;

                            titular.direccion = dbDR.GetString(12);
                            titular.barrio = dbDR.GetString(13);
                            titular.telefono = dbDR.GetString(14);
                            titular.celular1 = dbDR.GetString(15);
                            titular.celular2 = dbDR.GetString(16);
                            titular.email = dbDR.GetString(17);
                            titular.fechaNacimiento = dbDR.GetDateTime(18);
                            titular.edadAfiliacion = dbDR.GetInt32(19);
                            titular.genero = dbDR.GetString(20);
                            titular.fechaCobertura = dbDR.GetDateTime(21);
                            infoContrato.titular = titular;

                            infoContrato.tipoAfiliacion = dbDR.GetString(22);
                            infoContrato.fechaAfiliacion = dbDR.GetDateTime(23);
                            infoContrato.estatus = dbDR.GetString(24);
                            infoContrato.vigenciaDesde = dbDR.GetDateTime(25);
                            infoContrato.vigenciaHasta = dbDR.GetDateTime(26);
                            infoContrato.valorCuota = dbDR.GetFloat(27);
                            infoContrato.diaCobro = dbDR.GetInt32(28);

                            FormaPago formaPago = new FormaPago();
                            formaPago.idFormaPago = dbDR.GetInt32(29).ToString();
                            formaPago.formaPago = dbDR.GetString(30);
                            infoContrato.formaPago = formaPago;

                            Plan plan = new Plan();
                            plan.id = dbDR.GetInt32(31).ToString();
                            plan.nombrePlan = dbDR.GetString(32);
                            plan.valorBase = dbDR.GetFloat(33);
                            plan.valorAdicional = dbDR.GetFloat(34);
                            infoContrato.plan = plan;

                            Zona zona = new Zona();
                            zona.id = dbDR.GetInt32(35).ToString();
                            zona.nombreZona = dbDR.GetString(36);
                            infoContrato.zona = zona;

                            Sucursal sucursal = new Sucursal();
                            sucursal.id = dbDR.GetInt32(37).ToString();
                            sucursal.nombreSucursal = dbDR.GetString(38);
                            infoContrato.sucursal = sucursal;

                            Empleado cobrador = new Empleado();
                            cobrador.idPersona = dbDR.GetString(39);
                            cobrador.nombre1 = dbDR.GetString(40);
                            cobrador.nombre2 = dbDR.GetString(41);
                            cobrador.apellido1 = dbDR.GetString(42);
                            cobrador.apellido2 = dbDR.GetString(43);
                            infoContrato.cobrador = cobrador;

                            Empleado vendedor = new Empleado();
                            vendedor.idPersona = dbDR.GetString(44);
                            vendedor.nombre1 = dbDR.GetString(45);
                            vendedor.nombre2 = dbDR.GetString(46);
                            vendedor.apellido1 = dbDR.GetString(47);
                            vendedor.apellido2 = dbDR.GetString(48);
                            infoContrato.vendedor = vendedor;

                            infoContrato.direccionCobro = dbDR.GetString(49);
                            infoContrato.observaciones = dbDR.GetString(50);

                            Empresas empresas = new Empresas();
                            if (dbDR["NITEMPRESA"] == DBNull.Value)
                            {
                                empresas.nitEmpresa = null;
                                empresas.empresa = null;
                            }else{
                                empresas.nitEmpresa = dbDR.GetString(51);
                                empresas.empresa = dbDR.GetString(52);
                            }
                            infoContrato.empresas = empresas;

                            if (dbDR["FECHAULTIMOPAGO"] == DBNull.Value)
                            {
                                infoContrato.fechaUltimoPago = null;
                            }else{
                                infoContrato.fechaUltimoPago = dbDR.GetDateTime(53);
                            }

                            if (dbDR["PAGOHASTA"] == DBNull.Value)
                            {
                                infoContrato.pagoHasta = null;
                            }else{
                                infoContrato.pagoHasta = dbDR.GetDateTime(54);
                            }

                            lstContrato.Add(infoContrato);

                        }
                    }
                }
                catch (Exception ex)
                {
                    lstContrato = null;
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
            return lstContrato;
        }

        public Contrato create(Contrato contrato)
        {
            Contrato resultado = new Contrato();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(contrato.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARCONTRATO ";

                    cmdFB.Parameters.AddWithValue("IDENTIFICACION", SqlDbType.VarChar).Value = contrato.titular.identificacion;
                    cmdFB.Parameters.AddWithValue("NOMBRE1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.nombre1);
                    cmdFB.Parameters.AddWithValue("NOMBRE2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.nombre2);
                    cmdFB.Parameters.AddWithValue("APELLIDO1", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.apellido1);
                    cmdFB.Parameters.AddWithValue("APELLIDO2", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.apellido2);
                    cmdFB.Parameters.AddWithValue("IDDEPARTAMENTO", SqlDbType.VarChar).Value = contrato.titular.departamento.codDepartamento;
                    cmdFB.Parameters.AddWithValue("IDMUNICIPIO", SqlDbType.Int).Value = contrato.titular.municipio.idMunicipio;
                    cmdFB.Parameters.AddWithValue("DIRECCION", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.direccion);
                    cmdFB.Parameters.AddWithValue("BARRIO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.titular.barrio);
                    cmdFB.Parameters.AddWithValue("TELEFONO", SqlDbType.VarChar).Value = contrato.titular.telefono;
                    cmdFB.Parameters.AddWithValue("CELULAR1", SqlDbType.VarChar).Value = contrato.titular.celular1;
                    cmdFB.Parameters.AddWithValue("CELULAR2", SqlDbType.VarChar).Value = contrato.titular.celular2;
                    cmdFB.Parameters.AddWithValue("EMAIL", SqlDbType.VarChar).Value = contrato.titular.email.ToLower();
                    cmdFB.Parameters.AddWithValue("FECHANACIMIENTO", SqlDbType.Date).Value = contrato.titular.fechaNacimiento;
                    cmdFB.Parameters.AddWithValue("GENERO", SqlDbType.VarChar).Value = contrato.titular.genero;
                    cmdFB.Parameters.AddWithValue("FECHACOBERTURA", SqlDbType.Date).Value = contrato.titular.fechaCobertura;

                    cmdFB.Parameters.AddWithValue("FECHAFILIACION", SqlDbType.Date).Value = contrato.fechaAfiliacion;
                    cmdFB.Parameters.AddWithValue("TIPOAFILIACION", SqlDbType.VarChar).Value = contrato.tipoAfiliacion.ToUpper();
                    cmdFB.Parameters.AddWithValue("VIGENCIADESDE", SqlDbType.Date).Value = contrato.vigenciaDesde;
                    cmdFB.Parameters.AddWithValue("VIGENCIAHASTA", SqlDbType.Date).Value = contrato.vigenciaHasta;
                    cmdFB.Parameters.AddWithValue("VALORCUOTA", SqlDbType.Float).Value = contrato.valorCuota;
                    cmdFB.Parameters.AddWithValue("DIACOBRO", SqlDbType.Int).Value = contrato.diaCobro;
                    cmdFB.Parameters.AddWithValue("IDFORMAPAGO", SqlDbType.Int).Value = contrato.formaPago.idFormaPago;
                    cmdFB.Parameters.AddWithValue("IDPLAN", SqlDbType.Int).Value = contrato.plan.id;
                    cmdFB.Parameters.AddWithValue("IDZONA", SqlDbType.Int).Value = contrato.zona.id;
                    cmdFB.Parameters.AddWithValue("IDSUCURSAL", SqlDbType.Int).Value = contrato.sucursal.id;
                    cmdFB.Parameters.AddWithValue("IDCOBRADOR", SqlDbType.VarChar).Value = contrato.cobrador.idPersona;
                    cmdFB.Parameters.AddWithValue("IDVENDEDOR", SqlDbType.VarChar).Value = contrato.vendedor.idPersona;
                    cmdFB.Parameters.AddWithValue("DIRECCIONCOBRO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.direccionCobro);
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.observaciones);
                    cmdFB.Parameters.AddWithValue("NITEMPRESA", SqlDbType.VarChar).Value = contrato.empresas.nitEmpresa;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        resultado.codRespuesta = dbDR.GetString(1);
                        resultado.msjRespuesta = dbDR.GetString(2);

                        if (dbDR["IDCONTRATO"] != DBNull.Value)
                        {
                            resultado.idContrato = dbDR.GetString(0);
                        }
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

        public Contrato update(Contrato contrato)
        {
            Contrato resultado = new Contrato();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(contrato.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATECONTRATO ";
                    cmdFB.Parameters.AddWithValue("IDCONTRATO", SqlDbType.VarChar).Value = contrato.idContrato;
                    cmdFB.Parameters.AddWithValue("IDTITULAR", SqlDbType.VarChar).Value = contrato.titular.identificacion;
                    cmdFB.Parameters.AddWithValue("TIPOAFILIACION", SqlDbType.VarChar).Value = contrato.tipoAfiliacion.ToUpper();
                    cmdFB.Parameters.AddWithValue("FECHAFILIACION", SqlDbType.Date).Value = contrato.fechaAfiliacion;
                    cmdFB.Parameters.AddWithValue("ESTATUS", SqlDbType.VarChar).Value = contrato.estatus.ToUpper();
                    cmdFB.Parameters.AddWithValue("VIGENCIADESDE", SqlDbType.Date).Value = contrato.vigenciaDesde;
                    cmdFB.Parameters.AddWithValue("VIGENCIAHASTA", SqlDbType.Date).Value = contrato.vigenciaHasta;
                    cmdFB.Parameters.AddWithValue("VALORCUOTA", SqlDbType.Float).Value = contrato.valorCuota;
                    cmdFB.Parameters.AddWithValue("DIACOBRO", SqlDbType.Int).Value = contrato.diaCobro;
                    cmdFB.Parameters.AddWithValue("IDFORMAPAGO", SqlDbType.Int).Value = contrato.formaPago.idFormaPago;
                    cmdFB.Parameters.AddWithValue("IDPLAN", SqlDbType.Int).Value = contrato.plan.id;
                    cmdFB.Parameters.AddWithValue("IDZONA", SqlDbType.Int).Value = contrato.zona.id;
                    cmdFB.Parameters.AddWithValue("IDSUCURSAL", SqlDbType.Int).Value = contrato.sucursal.id;
                    cmdFB.Parameters.AddWithValue("IDCOBRADOR", SqlDbType.VarChar).Value = contrato.cobrador.idPersona;
                    cmdFB.Parameters.AddWithValue("IDVENDEDOR", SqlDbType.VarChar).Value = contrato.vendedor.idPersona;
                    cmdFB.Parameters.AddWithValue("DIRECCIONCOBRO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.direccionCobro);
                    cmdFB.Parameters.AddWithValue("OBSERVACIONES", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(contrato.observaciones);
                    cmdFB.Parameters.AddWithValue("NITEMPRESA", SqlDbType.VarChar).Value = contrato.empresas.nitEmpresa;
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