﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DGermenes:Conexion
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public DGermenes()
        {

        }

        public DGermenes(int iD, string nombre, string estado)
        {
            ID = iD;
            Nombre = nombre;
            Estado = estado;
        }



        //Metodos

        //insertar
        public string Insertar(DGermenes Germenes)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "insertar_germenes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Coloracion = new SqlParameter();
                Parametro_Id_Coloracion.ParameterName = "@ID";
                Parametro_Id_Coloracion.SqlDbType = SqlDbType.Int;
                Parametro_Id_Coloracion.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Coloracion);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Germenes.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro de los germenes";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;
        }

        //editar
        public string Editar(DGermenes Germenes)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "editar_germenes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Coloracion = new SqlParameter();
                Parametro_Id_Coloracion.ParameterName = "@ID";
                Parametro_Id_Coloracion.SqlDbType = SqlDbType.Int;
                Parametro_Id_Coloracion.Value = Germenes.ID;
                SqlComando.Parameters.Add(Parametro_Id_Coloracion);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Germenes.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro de los germenes";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;
        }


        //Eliminar
        public string Eliminar(DGermenes Germenes)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "eliminar_germenes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Germenes.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro de los germenes";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;

        }

        //Anular
        public string Anular(DGermenes Germenes)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "anular_germenes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Germenes.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro de los germenes";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;

        }

        public List<DGermenes> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Germenes");
            SqlConnection SqlConectar = new SqlConnection();
            List<DGermenes> ListaGenerica = new List<DGermenes>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_germenes";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DGermenes
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        Estado = LeerFilas.GetString(2)
                    });
                }
                LeerFilas.Close();
                SqlConectar.Close();
            }
            catch (Exception)
            {
                ListaGenerica = null;
            }

            return ListaGenerica;

        }

    }
}
