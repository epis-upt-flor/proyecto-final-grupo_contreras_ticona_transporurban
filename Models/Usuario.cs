﻿using Project.Funciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public int idTipoUsuario { get; set; }
        public string tipoUsuarioNombre { get; set; }
        public string nombreCompleto { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int estado { get; set; }
        public string estadoNombre { get; set; }

        string _conexion = string.Empty;

        public Usuario()
        {
            _conexion = ConfigurationManager.ConnectionStrings["ModeloDatos"].ConnectionString;
        }
        public Usuario ValidarLogin(Usuario obj)
        {
            Usuario objUsu = new Usuario();
            string consulta = @"SELECT
                                u.id,
                                u.idTipoUsuario,
                                CASE
                                    WHEN u.idTipoUsuario = 1 THEN 'Anar'
                                    WHEN u.idTipoUsuario = 2 THEN 'Unidad'
	                                WHEN u.idTipoUsuario = 3 THEN 'Administrador'
                                    ELSE '--'
                                END AS tipoUsuarioNombre,
                                u.nombreCompleto,
                                u.usuario,                                
                                u.estado AS idEstado,
                                CASE
                                WHEN u.estado = 1 THEN 'Activo'
                                WHEN u.estado = 0 THEN 'Inactivo'
                                ELSE '--'
                                END AS estado
                                FROM usuario AS u WHERE u.usuario = @p0 AND u.password = @p1";
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarStr(obj.usuario));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.password));
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                objUsu.id = Utilitarios.ValidarInteger(dr["id"]);
                                objUsu.nombreCompleto = Utilitarios.ValidarStr(dr["nombreCompleto"]);
                                objUsu.idTipoUsuario = Utilitarios.ValidarInteger(dr["idTipoUsuario"]);
                                objUsu.tipoUsuarioNombre = Utilitarios.ValidarStr(dr["tipoUsuarioNombre"]);
                                objUsu.estado = Utilitarios.ValidarInteger(dr["idEstado"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return objUsu;
        }
        public bool UsuarioRegistrar(Usuario obj)
        {
            bool respuesta = false;

            string consulta = @"INSERT INTO usuario (
                                    idTipoUsuario,
                                    nombreCompleto,
                                    usuario,                                    
                                    password,
                                    estado                                    
                                )
                                VALUES (
                                    @p0,
                                    @p1,
                                    @p2,
                                    @p3,
                                    @p4                                    
                                )";
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(obj.idTipoUsuario));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.nombreCompleto));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(obj.usuario));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarStr(obj.password));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarInteger(1));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return respuesta;
        }
        public bool UsuarioEditar(Usuario obj)
        {
            bool respuesta = false;

            string consulta = @"UPDATE usuario
                                SET
                                idTipoUsuario = @p0,
                                nombreCompleto = @p1,
                                usuario = @p2,                       
                                password = @p3                                
                                WHERE id = @p5";
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(obj.idTipoUsuario));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.nombreCompleto));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(obj.usuario));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarStr(obj.password));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarInteger(obj.id));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return respuesta;
        }
        public bool UsuarioCambiarEstado(Usuario obj)
        {
            bool respuesta = false;

            string consulta = @"UPDATE usuario
                                SET
                                estado = @p0                              
                                WHERE id = @p1";
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(obj.estado));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.id));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return respuesta;
        }
        public List<Usuario> UsuarioListar()
        {
            List<Usuario> list = new List<Usuario>();

            string consulta = @"select
                                u.id,
                                CASE
                                    WHEN u.idTipoUsuario = 1 THEN 'Anar'
                                    WHEN u.idTipoUsuario = 2 THEN 'Unidad'
	                                WHEN u.idTipoUsuario = 3 THEN 'Administrador'
                                    ELSE '--'
                                END AS tipoUsuarioNombre,
                                u.nombreCompleto,
                                u.usuario,                                
                                CASE
                                WHEN u.estado = 1 THEN 'Activo'
                                WHEN u.estado= 0 THEN 'Inactivo'
                                ELSE '--'
                                END AS estado,
                                u.estado AS idestado
                                from usuario as u";

#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Usuario objUsuario = new Usuario
                                {
                                    id = Utilitarios.ValidarInteger(dr["id"]),
                                    tipoUsuarioNombre = Utilitarios.ValidarStr(dr["tipoUsuarioNombre"]),
                                    nombreCompleto = Utilitarios.ValidarStr(dr["nombreCompleto"]),
                                    usuario = Utilitarios.ValidarStr(dr["usuario"]),
                                    estadoNombre = Utilitarios.ValidarStr(dr["estado"]),
                                    estado = Utilitarios.ValidarInteger(dr["idestado"])
                                };
                                list.Add(objUsuario);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa

            return list;
        }
        public Usuario UsuarioDetalle(int id)
        {
            Usuario obj = new Usuario();
            string consulta = @"select 
                                *
                                from usuario as u
                                where u.id = @p0";
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(id));

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                obj.id = Utilitarios.ValidarInteger(dr["id"]);
                                obj.idTipoUsuario = Utilitarios.ValidarInteger(dr["idTipoUsuario"]);
                                obj.nombreCompleto = Utilitarios.ValidarStr(dr["nombreCompleto"]);
                                obj.usuario = Utilitarios.ValidarStr(dr["usuario"]);
                                obj.password = Utilitarios.ValidarStr(dr["password"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return obj;
        }

    }
}