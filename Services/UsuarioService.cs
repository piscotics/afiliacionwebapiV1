using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using afiliacionwebapi.Models;
using afiliacionwebapi.utils;

namespace afiliacionwebapi.Services
{
    public class UsuarioService
    {
        string rutaDBWeb = "";
        public Usuario login(string username, string password, string subdominio)
        {
            Usuario usuario = new Usuario();

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
                    cmdFB.CommandText = " P_AW_LOGIN ";
                    cmdFB.Parameters.AddWithValue("USERNAME", SqlDbType.VarChar).Value = username.ToUpper();
                    cmdFB.Parameters.AddWithValue("PWD", SqlDbType.VarChar).Value = password;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        usuario.username = username;
                        usuario.nombre = dbDR.GetString(0);
                        usuario.apellido = dbDR.GetString(1);
                        usuario.estado = dbDR.GetInt16(2).ToString();
                        usuario.renovarPass = dbDR.GetInt16(3).ToString();
                        usuario.codRespuesta = dbDR.GetString(4);
                        usuario.msjRespuesta = dbDR.GetString(5);
                    }

                }
                catch (Exception ex)
                {
                    usuario = null;
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
            return usuario;
        }

        public Usuario create(Usuario usuario)
        {
            Usuario resultado = new Usuario();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(usuario.subdominio);
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
                    cmdFB.CommandText = " P_AW_CREARUSUARIO ";
                    cmdFB.Parameters.AddWithValue("USERNAME", SqlDbType.VarChar).Value = usuario.username.ToUpper();
                    cmdFB.Parameters.AddWithValue("PWD", SqlDbType.VarChar).Value = usuario.password;
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = usuario.idPersona;
                    cmdFB.Parameters.AddWithValue("NOMBRES", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.nombre);
                    cmdFB.Parameters.AddWithValue("APELLIDOS", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.apellido);
                    cmdFB.Parameters.AddWithValue("CARGO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.cargo);
                    cmdFB.Parameters.AddWithValue("USUARIOMODIF", SqlDbType.VarChar).Value = usuario.usuarioModif;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        resultado.codRespuesta = dbDR.GetString(0);
                        resultado.msjRespuesta = dbDR.GetString(1);
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resultado = null;
                } finally
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

        public Usuario get(string username, string subdominio)
        {
            Usuario infoUser = new Usuario();

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
                    cmdFB.CommandText = " P_AW_GETUSUARIO ";
                    cmdFB.Parameters.AddWithValue("USUARIO", SqlDbType.VarChar).Value = username;
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        infoUser.username = dbDR.GetString(0);
                        infoUser.idPersona = dbDR.GetString(1);
                        infoUser.nombre = dbDR.GetString(2);
                        infoUser.apellido = dbDR.GetString(3);
                        infoUser.cargo = dbDR.GetString(4);
                        infoUser.estado = dbDR.GetInt16(5).ToString();
                    }
                }
                catch (Exception ex)
                {
                    infoUser = null;
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
            return infoUser;
        }

        public Usuario update(Usuario usuario)
        {
            Usuario resultado = new Usuario();
            // Siempre entramos a verificar que el subdominio enviado exista
            rutaDBWeb = PasarelaWebService.validarSubdominio(usuario.subdominio);
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
                    cmdFB.CommandText = " P_AW_UPDATEUSUARIO ";
                    cmdFB.Parameters.AddWithValue("USERNAME", SqlDbType.VarChar).Value = usuario.username.ToUpper();
                    cmdFB.Parameters.AddWithValue("PWD", SqlDbType.VarChar).Value = usuario.password;
                    cmdFB.Parameters.AddWithValue("IDPERSONA", SqlDbType.VarChar).Value = usuario.idPersona;
                    cmdFB.Parameters.AddWithValue("NOMBRES", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.nombre);
                    cmdFB.Parameters.AddWithValue("APELLIDOS", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.apellido);
                    cmdFB.Parameters.AddWithValue("CARGO", SqlDbType.VarChar).Value = Capitalize.CapitalizeWords(usuario.cargo);
                    cmdFB.Parameters.AddWithValue("USUARIOMODIF", SqlDbType.VarChar).Value = usuario.usuarioModif.ToUpper();
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

        public List<Usuario> list(string subdominio)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();

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
                    cmdFB.CommandText = " P_AW_LISTUSUARIOS ";
                    cmdFB.CommandType = CommandType.StoredProcedure;
                    drFB = cmdFB.ExecuteReader();

                    foreach (DbDataRecord dbDR in drFB)
                    {
                        Usuario usuarios = new Usuario();
                        usuarios.username = dbDR.GetString(0);
                        usuarios.idPersona = dbDR.GetString(1);
                        usuarios.nombre = dbDR.GetString(2);
                        usuarios.apellido = dbDR.GetString(3);
                        usuarios.cargo = dbDR.GetString(4);
                        usuarios.estado = dbDR.GetInt16(5).ToString();

                        lstUsuarios.Add(usuarios);
                    }
                }
                catch (Exception ex)
                {
                    lstUsuarios = null;
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
            return lstUsuarios;
        }
    }
}