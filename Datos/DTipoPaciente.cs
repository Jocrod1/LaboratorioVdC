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
        private string _Nombre;
        private string _Equivalencia;
        private int _TipoPrecio;
        private float _Porcentaje;
        private string _TipoPago;
        private int _NoCopia;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Equivalencia { get => _Equivalencia; set => _Equivalencia = value; }
        public int TipoPrecio { get => _TipoPrecio; set => _TipoPrecio = value; }
        public float Porcentaje { get => _Porcentaje; set => _Porcentaje = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public int NoCopia { get => _NoCopia; set => _NoCopia = value; }

        public DTipoPaciente()
        {

        }

        public DTipoPaciente(int iD, string nombre, string equivalencia, int tipoPrecio, float porcentaje, string tipoPago, int noCopia)
        {
            ID = iD;
            Nombre = nombre;
            Equivalencia = equivalencia;
            TipoPrecio = tipoPrecio;
            Porcentaje = porcentaje;
            TipoPago = tipoPago;
            NoCopia = noCopia;
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
                SqlComando.CommandText = "insertar_tipo_paciente";
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

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 10;
                Parametro_Equivalencia.Value = TipoPaciente.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@tipo_precio";
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
                Parametro_Tipo_Pago.ParameterName = "@tipo_pago";
                Parametro_Tipo_Pago.SqlDbType = SqlDbType.VarChar;
                Parametro_Tipo_Pago.Size = 10;
                Parametro_Tipo_Pago.Value = TipoPaciente.TipoPago;
                SqlComando.Parameters.Add(Parametro_Tipo_Pago);

                //parametro N copias
                SqlParameter Parametro_Copias = new SqlParameter();
                Parametro_Copias.ParameterName = "@no_copias";
                Parametro_Copias.SqlDbType = SqlDbType.Int;
                Parametro_Copias.Value = TipoPaciente.NoCopia;
                SqlComando.Parameters.Add(Parametro_Copias);

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
                SqlComando.CommandText = "editar_tipo_paciente";
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

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 10;
                Parametro_Equivalencia.Value = TipoPaciente.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@tipo_precio";
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
                Parametro_Tipo_Pago.ParameterName = "@tipo_pago";
                Parametro_Tipo_Pago.SqlDbType = SqlDbType.VarChar;
                Parametro_Tipo_Pago.Size = 10;
                Parametro_Tipo_Pago.Value = TipoPaciente.TipoPago;
                SqlComando.Parameters.Add(Parametro_Tipo_Pago);

                //parametro N copias
                SqlParameter Parametro_Copias = new SqlParameter();
                Parametro_Copias.ParameterName = "@no_copias";
                Parametro_Copias.SqlDbType = SqlDbType.Int;
                Parametro_Copias.Value = TipoPaciente.NoCopia;
                SqlComando.Parameters.Add(Parametro_Copias);

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
                SqlComando.CommandText = "eliminar_tipo_paciente";
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
                SqlComando.CommandText = "mostrar_tipo_paciente";
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
                        Equivalencia = LeerFilas.GetString(2),
                        TipoPrecio = LeerFilas.GetInt32(3),
                        Porcentaje = LeerFilas.GetFloat(4),
                        TipoPago = LeerFilas.GetString(5),
                        NoCopia = LeerFilas.GetInt32(6),
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

