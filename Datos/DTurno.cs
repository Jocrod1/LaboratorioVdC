using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DTurno:Conexion
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
        private DateTime _Comienzo;

        public DateTime Comienzo
        {
            get { return _Comienzo; }
            set { _Comienzo = value; }
        }
        private DateTime _Final;

        public DateTime Final
        {
            get { return _Final; }
            set { _Final = value; }
        }



        public DTurno()
        {

        }

        public DTurno(int iD, string nombre, DateTime comienzo, DateTime final)
        {
            ID = iD;
            Nombre = nombre;
            Comienzo = comienzo;
            Final = final;
        }

        //Metodos

        //insertar
        public string Insertar(DTurno Turno)
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
                SqlComando.CommandText = "insertar_turno";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Turno.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 10;
                Parametro_Nombre.Value = Turno.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro comienzo
                SqlParameter Parametro_Comienzo = new SqlParameter();
                Parametro_Comienzo.ParameterName = "@comienzo";
                Parametro_Comienzo.SqlDbType = SqlDbType.DateTime;
                Parametro_Comienzo.Value = Turno.Comienzo;
                SqlComando.Parameters.Add(Parametro_Comienzo);

                //parametro nombre
                SqlParameter Parametro_Final = new SqlParameter();
                Parametro_Final.ParameterName = "@final";
                Parametro_Final.SqlDbType = SqlDbType.DateTime;
                Parametro_Final.Value = Turno.Final;
                SqlComando.Parameters.Add(Parametro_Final);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del turno";

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
        public string Editar(DTurno Turno)
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
                SqlComando.CommandText = "editar_turno";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Turno.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 10;
                Parametro_Nombre.Value = Turno.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro comienzo
                SqlParameter Parametro_Comienzo = new SqlParameter();
                Parametro_Comienzo.ParameterName = "@comienzo";
                Parametro_Comienzo.SqlDbType = SqlDbType.DateTime;
                Parametro_Comienzo.Value = Turno.Comienzo;
                SqlComando.Parameters.Add(Parametro_Comienzo);

                //parametro nombre
                SqlParameter Parametro_Final = new SqlParameter();
                Parametro_Final.ParameterName = "@final";
                Parametro_Final.SqlDbType = SqlDbType.DateTime;
                Parametro_Final.Value = Turno.Final;
                SqlComando.Parameters.Add(Parametro_Final);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro del Turno";

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
        public string Eliminar(DTurno Turno)
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
                SqlComando.CommandText = "eliminar_turno";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Turno.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del Turno";

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

        //mostrar y buscar
        public List<DTurno> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Turno");
            SqlConnection SqlConectar = new SqlConnection();
            List<DTurno> ListaGenerica = new List<DTurno>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_turno";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DTurno
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        Comienzo= LeerFilas.GetDateTime(2),
                        Final=LeerFilas.GetDateTime(3),
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
