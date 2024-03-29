﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DRegistroAcceso : Conexion
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        private string _CedulaUsuario;

public string CedulaUsuario
{
  get { return _CedulaUsuario; }
  set { _CedulaUsuario = value; }
}

        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private int _IDTurno;

public int IDTurno
{
  get { return _IDTurno; }
  set { _IDTurno = value; }
}
private DateTime _Fecha;

public DateTime Fecha
{
    get { return _Fecha; }
    set { _Fecha = value; }
}

        private string _Turno;

        public string Turno
        {
            get { return _Turno; }
            set { _Turno = value; }
        }

        public DRegistroAcceso()
        {

        }

        public DRegistroAcceso(int iD, string cedulaUsuario, int iDTurno, DateTime fecha, string turno, string usuario)
        {
            ID = iD;
            CedulaUsuario = cedulaUsuario;
            IDTurno = iDTurno;
            Fecha = fecha;
            Turno = turno;
            Usuario = usuario;
        }

        //Metodos 

        //insertar 
        public string Insertar(DRegistroAcceso RegistroAcceso)
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
                SqlComando.CommandText = "insertar_registroacceso";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros 

                //parametro id 
                SqlParameter Parametro_Id_Acceso = new SqlParameter();
                Parametro_Id_Acceso.ParameterName = "@ID";
                Parametro_Id_Acceso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Acceso.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Acceso);

                //parametro cedula 
                SqlParameter Parametro_Cedula_Acceso = new SqlParameter();
                Parametro_Cedula_Acceso.ParameterName = "@CedulaUsuario";
                Parametro_Cedula_Acceso.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Acceso.Size = 50;
                Parametro_Cedula_Acceso.Value = RegistroAcceso.CedulaUsuario;
                SqlComando.Parameters.Add(Parametro_Cedula_Acceso);

                //parametro turno 
                SqlParameter Parametro_Turno = new SqlParameter();
                Parametro_Turno.ParameterName = "@IDTurno";
                Parametro_Turno.SqlDbType = SqlDbType.Int;
                Parametro_Turno.Value = RegistroAcceso.IDTurno;
                SqlComando.Parameters.Add(Parametro_Turno);

                //parametro fecha 
                SqlParameter Parametro_Fecha_Acceso = new SqlParameter();
                Parametro_Fecha_Acceso.ParameterName = "@Fecha";
                Parametro_Fecha_Acceso.SqlDbType = SqlDbType.DateTime;
                Parametro_Fecha_Acceso.Value = RegistroAcceso.Fecha;
                SqlComando.Parameters.Add(Parametro_Fecha_Acceso);

                //ejecuta y lo envia en comentario 
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Acceso";

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


        public List<DRegistroAcceso> Mostrar(int limite, string cedula)
        {
            SqlConnection SqlConectar = new SqlConnection();
            List<DRegistroAcceso> ListaGenerica = new List<DRegistroAcceso>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_registroacceso";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion 
                SqlComando.Parameters.AddWithValue("@limite", limite);
                SqlComando.Parameters.AddWithValue("@CedulaUsuario", cedula);



                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DRegistroAcceso
                    {
                        ID = LeerFilas.GetInt32(0),
                        CedulaUsuario = LeerFilas.GetString(1),
                        Usuario=LeerFilas.GetString(2),
                        Turno = LeerFilas.GetString(3),
                        Fecha = LeerFilas.GetDateTime(4)
                    });
                }
                LeerFilas.Close();
                SqlConectar.Close();
            }
            catch (Exception e)
            {
                ListaGenerica = null;
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return ListaGenerica;

        }

        public List<DRegistroAcceso> MostrarFechas(int limite, string cedula, DateTime fecha1, DateTime fecha2)
        {
            DataTable DtResultado = new DataTable("RegistroAcceso");
            SqlConnection SqlConectar = new SqlConnection();
            List<DRegistroAcceso> ListaGenerica = new List<DRegistroAcceso>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_registroacceso_entrefechas";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion 
                SqlComando.Parameters.AddWithValue("@limite", limite);
                SqlComando.Parameters.AddWithValue("@CedulaUsuario", cedula);
                SqlComando.Parameters.AddWithValue("@Fecha1", fecha1);
                SqlComando.Parameters.AddWithValue("@Fecha2", fecha2);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DRegistroAcceso
                    {
                        ID = LeerFilas.GetInt32(0),
                        CedulaUsuario = LeerFilas.GetString(1),
                        Usuario = LeerFilas.GetString(2),
                        Turno = LeerFilas.GetString(3),
                        Fecha = LeerFilas.GetDateTime(4)
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

        public List<DRegistroAcceso> MostrarTurnos(int limite, string cedula, int turno)
        {
            DataTable DtResultado = new DataTable("RegistroAcceso");
            SqlConnection SqlConectar = new SqlConnection();
            List<DRegistroAcceso> ListaGenerica = new List<DRegistroAcceso>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_registroacceso_turnos";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion 
                SqlComando.Parameters.AddWithValue("@limite", limite);
                SqlComando.Parameters.AddWithValue("@CedulaUsuario", cedula);
                SqlComando.Parameters.AddWithValue("@IDTurno", turno);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DRegistroAcceso
                    {
                        ID = LeerFilas.GetInt32(0),
                        CedulaUsuario = LeerFilas.GetString(1),
                        Usuario = LeerFilas.GetString(2),
                        Turno = LeerFilas.GetString(3),
                        Fecha = LeerFilas.GetDateTime(4)
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

        //combobox
        public string CaptarTurno()
        {
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "seleccionar_turno";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlConectar.Open();
                LeerFilas = SqlComando.ExecuteReader();

                string resultado = null;

                while (LeerFilas.Read())
                {
                    resultado = LeerFilas[0].ToString();
                };
                SqlConectar.Close();
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
