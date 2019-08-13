using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DTipoPaciente:Conexion
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
        private int _TipoPrecio;

        public int TipoPrecio
        {
            get { return _TipoPrecio; }
            set { _TipoPrecio = value; }
        }
        private double _Porcentaje;

        public double Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }

       
        private string _TipoPago;

        public string TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }


        public DTipoPaciente()
        {

        }

        public DTipoPaciente(int iD, string nombre, int tipoPrecio, float porcentaje, string tipoPago)
        {
            ID = iD;
            Nombre = nombre;
            TipoPrecio = tipoPrecio;
            Porcentaje = porcentaje;
            TipoPago = tipoPago;
        }

        //Metodos

        //insertar
        public string Insertar(DTipoPaciente TipoPaciente)
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
                SqlComando.CommandText = "insertar_tipopacientes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 30;
                Parametro_Nombre.Value = TipoPaciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@tipoprecio";
                Parametro_Tipo_Precio.SqlDbType = SqlDbType.Int;
                Parametro_Tipo_Precio.Value = TipoPaciente.TipoPrecio;
                SqlComando.Parameters.Add(Parametro_Tipo_Precio);

                //parametro porcentaje
                SqlParameter Parametro_Porcentaje = new SqlParameter();
                Parametro_Porcentaje.ParameterName = "@porcentaje";
                Parametro_Porcentaje.SqlDbType = SqlDbType.Float;
                Parametro_Porcentaje.Value = TipoPaciente.Porcentaje;
                SqlComando.Parameters.Add(Parametro_Porcentaje);

                //parametro tipo pago
                SqlParameter Parametro_Tipo_Pago = new SqlParameter();
                Parametro_Tipo_Pago.ParameterName = "@tipodepago";
                Parametro_Tipo_Pago.SqlDbType = SqlDbType.VarChar;
                Parametro_Tipo_Pago.Size = 10;
                Parametro_Tipo_Pago.Value = TipoPaciente.TipoPago;
                SqlComando.Parameters.Add(Parametro_Tipo_Pago);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Tipo del Paciente";

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
        public string Editar(DTipoPaciente TipoPaciente)
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
                SqlComando.CommandText = "editar_tipopacientes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = TipoPaciente.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 30;
                Parametro_Nombre.Value = TipoPaciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@tipoprecio";
                Parametro_Tipo_Precio.SqlDbType = SqlDbType.Int;
                Parametro_Tipo_Precio.Value = TipoPaciente.TipoPrecio;
                SqlComando.Parameters.Add(Parametro_Tipo_Precio);

                //parametro porcentaje
                SqlParameter Parametro_Porcentaje = new SqlParameter();
                Parametro_Porcentaje.ParameterName = "@porcentaje";
                Parametro_Porcentaje.SqlDbType = SqlDbType.Float;
                Parametro_Porcentaje.Value = TipoPaciente.Porcentaje;
                SqlComando.Parameters.Add(Parametro_Porcentaje);

                //parametro tipo pago
                SqlParameter Parametro_Tipo_Pago = new SqlParameter();
                Parametro_Tipo_Pago.ParameterName = "@tipodepago";
                Parametro_Tipo_Pago.SqlDbType = SqlDbType.VarChar;
                Parametro_Tipo_Pago.Size = 10;
                Parametro_Tipo_Pago.Value = TipoPaciente.TipoPago;
                SqlComando.Parameters.Add(Parametro_Tipo_Pago);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro del Tipo del Paciente";

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
        public string Eliminar(DTipoPaciente TipoPaciente)
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
                SqlComando.CommandText = "eliminar_tipopacientes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = TipoPaciente.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del tipo del paciente";

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

        public string Anular(DTipoPaciente TipoPaciente)
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
                SqlComando.CommandText = "anular_tipopacientes";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = TipoPaciente.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro del tipo del paciente";

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
        public List<DTipoPaciente> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("TipoPacientes");
            SqlConnection SqlConectar = new SqlConnection();
            List<DTipoPaciente> ListaGenerica = new List<DTipoPaciente>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_tipopacientes";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DTipoPaciente
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        TipoPrecio = LeerFilas.GetInt32(2),
                        Porcentaje = LeerFilas.GetDouble(3), 
                        TipoPago = LeerFilas.GetString(4)
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

