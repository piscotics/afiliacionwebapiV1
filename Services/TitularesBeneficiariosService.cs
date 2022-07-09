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
    public class TitularesBeneficiariosService
    {

        string rutaDBWeb = "";
        
        public List<TitularesBeneficiarios> list(string subdominio, string identificaciontitular, string idcontrato)
        {
            List<TitularesBeneficiarios> lstTitularesBeneficiarios = new List<TitularesBeneficiarios>();

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
                    cmdFB.CommandText = " P_AW_LISTBTSERVICIOSADICIONALES ";
                     cmdFB.Parameters.AddWithValue("TITULAR", SqlDbType.VarChar).Value = identificaciontitular;
                    cmdFB.Parameters.AddWithValue("CONTRATO", SqlDbType.VarChar).Value = idcontrato;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        TitularesBeneficiarios titularesBeneficiarios = new TitularesBeneficiarios();
                        titularesBeneficiarios.identificacion = dbDR.GetString(0);
                        titularesBeneficiarios.nombre1 = dbDR.GetString(1);
                        titularesBeneficiarios.nombre2 = dbDR.GetString(2);
                        titularesBeneficiarios.apellido1 = dbDR.GetString(3);
                        titularesBeneficiarios.apellido2 = dbDR.GetString(4);
                        lstTitularesBeneficiarios.Add(titularesBeneficiarios);
                    }
                }
                catch (Exception ex)
                {
                    lstTitularesBeneficiarios = null;
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
            return lstTitularesBeneficiarios;
        }

    }
}