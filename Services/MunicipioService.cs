using afiliacionwebapi.Models;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace afiliacionwebapi.Services
{
    public class MunicipioService
    {
        string rutaDBWeb = "";

        public Municipio get(string idMunicipio, string subdominio)
        {
            Municipio infoMunicipio = new Municipio();
            
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
                    cmdFB.CommandText = " SELECT M.IDMUNICIPIO, M.MUNICIPIO, D.CODDANE, D.DEPARTAMENTO FROM TBLDEPARTAMENTOS D " +
                        " INNER JOIN TBLMUNICIPIOS M ON D.CODDANE=M.CODDEPARTAMENTO WHERE M.IDMUNICIPIO = @IDMUNICIPIO ";
                    cmdFB.Parameters.AddWithValue("@IDMUNICIPIO", SqlDbType.Int).Value = idMunicipio;
                    cmdFB.CommandType = CommandType.Text;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoMunicipio.idMunicipio = dbDR.GetInt32(0).ToString();
                        infoMunicipio.municipio = dbDR.GetString(1);

                        Departamento departamento = new Departamento();
                        departamento.codDepartamento = dbDR.GetString(2);
                        departamento.departamento = dbDR.GetString(3);

                        infoMunicipio.departamento = departamento;
                    }
                }
                catch (Exception ex)
                {
                    infoMunicipio.codRespuesta = "404";
                    infoMunicipio.msjRespuesta = "Registro No Encontrado";

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
            return infoMunicipio;
        }

        public List<Municipio> getCitiesDepartment(string codDepartamento, string subdominio)
        {
            List<Municipio> lstMunicipios = new List<Municipio>();

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
                    cmdFB.CommandText = " SELECT M.IDMUNICIPIO, M.MUNICIPIO, D.CODDANE, D.DEPARTAMENTO FROM TBLDEPARTAMENTOS D INNER JOIN TBLMUNICIPIOS M ON D.CODDANE=M.CODDEPARTAMENTO WHERE M.CODDEPARTAMENTO = @CODDEPARTAMENTO ORDER BY M.MUNICIPIO ";
                    cmdFB.Parameters.AddWithValue("@CODDEPARTAMENTO", SqlDbType.VarChar).Value = codDepartamento;
                    cmdFB.CommandType = CommandType.Text;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Municipio municipio = new Municipio();
                        municipio.idMunicipio = dbDR.GetInt32(0).ToString();
                        municipio.municipio = dbDR.GetString(1);

                        Departamento depto = new Departamento();
                        depto.codDepartamento = dbDR.GetString(2);
                        depto.departamento = dbDR.GetString(3);

                        municipio.departamento = depto;

                        lstMunicipios.Add(municipio);
                    }
                }
                catch (Exception ex)
                {
                    lstMunicipios = null;
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
            return lstMunicipios;
        }

        public List<Municipio> list(string subdominio)
        {
            List<Municipio> lstMunicipios = new List<Municipio>();

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
                    cmdFB.CommandText = " SELECT M.IDMUNICIPIO, M.MUNICIPIO, D.CODDANE, D.DEPARTAMENTO " +
                        " FROM TBLDEPARTAMENTOS D INNER JOIN TBLMUNICIPIOS M ON D.CODDANE=M.CODDEPARTAMENTO " +
                        " ORDER BY M.MUNICIPIO ";
                    cmdFB.CommandType = CommandType.Text;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Municipio municipio = new Municipio();
                        municipio.idMunicipio = dbDR.GetInt32(0).ToString();
                        municipio.municipio = dbDR.GetString(1);

                        Departamento depto = new Departamento();
                        depto.codDepartamento = dbDR.GetString(2);
                        depto.departamento = dbDR.GetString(3);

                        municipio.departamento = depto;
                        //municipio.departamento.codDepartamento = dbDR.GetString(2);

                        lstMunicipios.Add(municipio);
                    }
                }
                catch (Exception ex)
                {
                    lstMunicipios = null;
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
            return lstMunicipios;
        }

    }
}