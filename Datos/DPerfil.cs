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
private double _Precio1;

public double Precio1
{
    get { return _Precio1; }
    set { _Precio1 = value; }
}
private double _Precio2;

public double Precio2
{
    get { return _Precio2; }
    set { _Precio2 = value; }
}
private bool _Titulo;

public bool Titulo
{
    get { return _Titulo; }
    set { _Titulo = value; }
}
private int _LabRef;

public int LabRef
{
    get { return _LabRef; }
    set { _LabRef = value; }
}
private int _PrecioRef;

public int PrecioRef
{
    get { return _PrecioRef; }
    set { _PrecioRef = value; }
}

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        private string _Nombre_LabRef;

        public string Nombre_LabRef
        {
            get { return _Nombre_LabRef; }
            set { _Nombre_LabRef = value; }
        }


        public DPerfil()
        {

        }

        public DPerfil(int iD, string nombre, double precio1, double precio2, bool titulo, int labRef, int precioRef, string estado, string nombre_labref)
        {
            ID = iD;
            Nombre = nombre;
            Precio1 = precio1;
            Precio2 = precio2;
            Titulo = titulo;
            LabRef = labRef;
            PrecioRef = precioRef;
            Estado = estado;
            Nombre_LabRef = nombre_labref;
        }



        //parametros
        //insertar
        public string Insertar(DPerfil Perfil, List<DDetalle_Perfil> Detalle)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //transaccion
                SqlTransaction SqlTransaccion = SqlConectar.BeginTransaction();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction=SqlTransaccion;
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
                Parametro_Titulo.SqlDbType = SqlDbType.Bit;
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

                if (respuesta.Equals("OK"))
                {
                    this.ID = Convert.ToInt32(SqlComando.Parameters["@ID"].Value);

                    foreach (DDetalle_Perfil det in Detalle)
                    {
                        det.IDPerfil = this.ID;

                        //llamar al insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (respuesta.Equals("OK"))
                {
                    SqlTransaccion.Commit();
                }
                else
                {
                    //si recibe una respuesta contraria se niega la transaccion
                    SqlTransaccion.Rollback();
                }

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

        public string Editar(DPerfil Perfil, List<DDetalle_Perfil> Detalle)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //transaccion
                SqlTransaction SqlTransaccion = SqlConectar.BeginTransaction();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
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
                SqlComando.Parameters.Add(Parametro_Nombre);;

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
                Parametro_Titulo.SqlDbType = SqlDbType.Bit;
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

                if (respuesta.Equals("OK"))
                {
                    this.ID = Convert.ToInt32(SqlComando.Parameters["@ID"].Value);

                    foreach (DDetalle_Perfil det in Detalle)
                    {
                        det.IDPerfil = this.ID;

                        //llamar al insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (respuesta.Equals("OK"))
                {
                    SqlTransaccion.Commit();
                }
                else
                {
                    //si recibe una respuesta contraria se niega la transaccion
                    SqlTransaccion.Rollback();
                }

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

        //Eliminar
        public string EliminarDetalle(DPerfil Detalle_Perfil)
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
                SqlComando.CommandText = "eliminar_detalleperfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@IDperfil";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Detalle_Perfil.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "OK";

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
                        Precio1=LeerFilas.GetDouble(2),
                        Precio2= LeerFilas.GetDouble(3),
                        Titulo= LeerFilas.GetBoolean(4),
                        Nombre_LabRef=LeerFilas.GetString(5),
                        PrecioRef= LeerFilas.GetInt32(6),
                        LabRef = LeerFilas.GetInt32(7),
                        Estado =LeerFilas.GetString(8)
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
