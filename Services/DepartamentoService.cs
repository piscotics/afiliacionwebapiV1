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
    public class DepartamentoService
    {
        string rutaDBWeb = "";

        public Departamento get(string codDepartamento, string subdominio)
        {
            Departamento infoDepartamento = new Departamento();

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
                    cmdFB.CommandText = " SELECT CODDANE, DEPARTAMENTO FROM TBLDEPARTAMENTOS WHERE CODDANE = @CODDEPARTAMENTO ";
                    cmdFB.Parameters.AddWithValue("@CODDEPARTAMENTO", SqlDbType.VarChar).Value = codDepartamento;
                    cmdFB.CommandType = CommandType.Text;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoDepartamento.codDepartamento = dbDR.GetString(0);
                        infoDepartamento.departamento = dbDR.GetString(1);
                    }
                }
                catch (Exception ex)
                {
                    infoDepartamento = null;
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
            return infoDepartamento;
        }

        public List<Departamento> list(string subdominio)
        {
            List<Departamento> lstDepartamentos = new List<Departamento>();

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
                    cmdFB.CommandText = " SELECT CODDANE, DEPARTAMENTO FROM TBLDEPARTAMENTOS ORDER BY DEPARTAMENTO ";
                    cmdFB.CommandType = CommandType.Text;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Departamento departamento = new Departamento();
                        departamento.codDepartamento = dbDR.GetString(0);
                        departamento.departamento = dbDR.GetString(1);

                        lstDepartamentos.Add(departamento);
                    }
                }
                catch (Exception ex)
                {
                    lstDepartamentos = null;
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
            return lstDepartamentos;
        }
    }
}