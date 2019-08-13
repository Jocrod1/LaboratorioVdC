using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DPerfil:Conexion
    {

        private int _ID;
        private string _Nombre;
        private string _Equivalencia;
        private double _Precio1;
        private double _Precio2;
        private int _Titulo;
        private int _LabRef;
        private int _PrecioRef;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Equivalencia { get => _Equivalencia; set => _Equivalencia = value; }
        public double Precio1 { get => _Precio1; set => _Precio1 = value; }
        public double Precio2 { get => _Precio2; set => _Precio2 = value; }
        public int Titulo { get => _Titulo; set => _Titulo = value; }
        public int LabRef { get => _LabRef; set => _LabRef = value; }
        public int PrecioRef { get => _PrecioRef; set => _PrecioRef = value; }

        public DPerfil()
        {

        }

        public DPerfil(int iD, string nombre, string equivalencia, double precio1, double precio2, int titulo, int labRef, int precioRef)
        {
            ID = iD;
            Nombre = nombre;
            Equivalencia = equivalencia;
            Precio1 = precio1;
            Precio2 = precio2;
            Titulo = titulo;
            LabRef = labRef;
            PrecioRef = precioRef;
        }



        //parametros
        //insertar
        public string Insertar(DPerfil Perfil)
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
                SqlComando.CommandText = "insertar_perfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Perfil = new SqlParameter();
                Parametro_Id_Perfil.ParameterName = "@ID";
                Parametro_Id_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Perfil.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Perfil);

                //parametro nombre
                SqlParameter Parametro_Nombre= new SqlParameter();
                Parametro_Nombre.ParameterName = "@Nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Perfil.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@Equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 50;
                Parametro_Equivalencia.Value = Perfil.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro precio 1
                SqlParameter Parametro_Precio1 = new SqlParameter();
                Parametro_Precio1.ParameterName = "@precio1";
                Parametro_Precio1.SqlDbType = SqlDbType.Float;
                Parametro_Precio1.Value = Perfil.Precio1;
                SqlComando.Parameters.Add(Parametro_Precio1);

                //parametro precio 2
                SqlParameter Parametro_Precio2 = new SqlParameter();
                Parametro_Precio2.ParameterName = "@precio2";
                Parametro_Precio2.SqlDbType = SqlDbType.Float;
                Parametro_Precio2.Value = Perfil.Precio2;
                SqlComando.Parameters.Add(Parametro_Precio2);

                //parametro titulo
                SqlParameter Parametro_Titulo = new SqlParameter();
                Parametro_Titulo.ParameterName = "@titulo";
                Parametro_Titulo.SqlDbType = SqlDbType.Int;
                Parametro_Titulo.Value = Perfil.Titulo;
                SqlComando.Parameters.Add(Parametro_Titulo);

                //parametro labref
                SqlParameter Parametro_LabRef = new SqlParameter();
                Parametro_LabRef.ParameterName = "@labref";
                Parametro_LabRef.SqlDbType = SqlDbType.Int;
                Parametro_LabRef.Value = Perfil.LabRef;
                SqlComando.Parameters.Add(Parametro_LabRef);

                //parametro precioref
                SqlParameter Parametro_PrecioRef = new SqlParameter();
                Parametro_PrecioRef.ParameterName = "@precioRef";
                Parametro_PrecioRef.SqlDbType = SqlDbType.Int;
                Parametro_PrecioRef.Value = Perfil.PrecioRef;
                SqlComando.Parameters.Add(Parametro_PrecioRef);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Perfil";

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

        public string Editar(DPerfil Perfil)
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
                SqlComando.CommandText = "editar_perfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Perfil = new SqlParameter();
                Parametro_Id_Perfil.ParameterName = "@ID";
                Parametro_Id_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Perfil.Value = Perfil.ID;
                SqlComando.Parameters.Add(Parametro_Id_Perfil);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Perfil.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 50;
                Parametro_Equivalencia.Value = Perfil.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro precio 1
                SqlParameter Parametro_Precio1 = new SqlParameter();
                Parametro_Precio1.ParameterName = "@Precio1";
                Parametro_Precio1.SqlDbType = SqlDbType.Float;
                Parametro_Precio1.Value = Perfil.Precio1;
                SqlComando.Parameters.Add(Parametro_Precio1);

                //parametro precio 2
                SqlParameter Parametro_Precio2 = new SqlParameter();
                Parametro_Precio2.ParameterName = "@Precio2";
                Parametro_Precio2.SqlDbType = SqlDbType.Float;
                Parametro_Precio2.Value = Perfil.Precio2;
                SqlComando.Parameters.Add(Parametro_Precio2);

                //parametro titulo
                SqlParameter Parametro_Titulo = new SqlParameter();
                Parametro_Titulo.ParameterName = "@Titulo";
                Parametro_Titulo.SqlDbType = SqlDbType.Int;
                Parametro_Titulo.Value = Perfil.Titulo;
                SqlComando.Parameters.Add(Parametro_Titulo);

                //parametro labref
                SqlParameter Parametro_LabRef = new SqlParameter();
                Parametro_LabRef.ParameterName = "@IDLabRef";
                Parametro_LabRef.SqlDbType = SqlDbType.Int;
                Parametro_LabRef.Value = Perfil.LabRef;
                SqlComando.Parameters.Add(Parametro_LabRef);

                //parametro precioref
                SqlParameter Parametro_PrecioRef = new SqlParameter();
                Parametro_PrecioRef.ParameterName = "@PrecioRef";
                Parametro_PrecioRef.SqlDbType = SqlDbType.Int;
                Parametro_PrecioRef.Value = Perfil.PrecioRef;
                SqlComando.Parameters.Add(Parametro_PrecioRef);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro del Perfil";

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

        public string Eliminar(DPerfil Perfil)
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
                SqlComando.CommandText = "eliminar_perfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Perfil.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del perfil";

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

        public string Anular(DPerfil Perfil)
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
                SqlComando.CommandText = "anular_perfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Perfil.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro del perfil";

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

        public List<DPerfil> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Perfil");
            SqlConnection SqlConectar = new SqlConnection();
            List<DPerfil> ListaGenerica = new List<DPerfil>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_perfil";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DPerfil
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        Equivalencia= LeerFilas.GetString(2),
                        Precio1=LeerFilas.GetDouble(3),
                        Precio2= LeerFilas.GetDouble(4),
                        Titulo= LeerFilas.GetInt32(5),
                        LabRef= LeerFilas.GetInt32(6),
                        PrecioRef= LeerFilas.GetInt32(7)
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
