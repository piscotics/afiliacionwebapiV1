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
    public class MultifiltrosService
    {
        string rutaDBWeb = "";

        

        public List<Contrato> list(string subdominio, DateTime bfechaafiliaciondesde,DateTime bfechaafiliacionhasta, string bsucursal, string bcobrador, string bvendedor, string bzona, string bplan, string bempresa, string btipoafiliacion, string bestado)
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
                    cmdFB.CommandText = " P_AW_GETMULTIFILTRO ";
                    cmdFB.Parameters.AddWithValue("BFECHAAFILIACIONDESDE", SqlDbType.DateTime).Value = bfechaafiliaciondesde;
                    cmdFB.Parameters.AddWithValue("BFECHAAFILIACIONHASTA", SqlDbType.DateTime).Value = bfechaafiliacionhasta;
                    cmdFB.Parameters.AddWithValue("BSUCURSAL", SqlDbType.VarChar).Value = bsucursal;
                    cmdFB.Parameters.AddWithValue("BCOBRADOR", SqlDbType.VarChar).Value = bcobrador;
                    cmdFB.Parameters.AddWithValue("BVENDEDOR", SqlDbType.VarChar).Value = bvendedor;
                    cmdFB.Parameters.AddWithValue("BZONA", SqlDbType.VarChar).Value = bzona;
                    cmdFB.Parameters.AddWithValue("BPLAN", SqlDbType.VarChar).Value = bplan;
                    cmdFB.Parameters.AddWithValue("BEMPRESA", SqlDbType.VarChar).Value = bempresa;
                    cmdFB.Parameters.AddWithValue("BTIPOAFILIACION", SqlDbType.VarChar).Value = btipoafiliacion;
                    cmdFB.Parameters.AddWithValue("BESTADO", SqlDbType.VarChar).Value = bestado;
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

        
    }
}