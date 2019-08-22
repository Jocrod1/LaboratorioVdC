using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DUsuario:Conexion
    {
        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Contraseña;

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private string _Correo;

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        private string _Acceso;

        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public DUsuario()
        {

        }

        public DUsuario(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, string Acceso, string TextoBuscar, string estado)
        {
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.Contraseña = Contraseña;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Correo = Correo;
            this.Acceso = Acceso;
            this.Estado = estado;
        }

        //Metodos

        //insertar
        public string Insertar(DUsuario Usuario)
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
                SqlComando.CommandText = "insertar_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro cedula
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@cedula";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 10;
                Parametro_Id_Trabajador.Value= Usuario.Cedula;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro nombre
                SqlParameter Parametro_Nombre_Trabajador = new SqlParameter();
                Parametro_Nombre_Trabajador.ParameterName = "@nombre";
                Parametro_Nombre_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Trabajador.Size = 50;
                Parametro_Nombre_Trabajador.Value = Usuario.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Trabajador);

                //parametro contraseña
                SqlParameter Parametro_Contraseña_Trabajador = new SqlParameter();
                Parametro_Contraseña_Trabajador.ParameterName = "@password";
                Parametro_Contraseña_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Contraseña_Trabajador.Size = 30;
                Parametro_Contraseña_Trabajador.Value = Usuario.Contraseña;
                SqlComando.Parameters.Add(Parametro_Contraseña_Trabajador);

                //parametro direccion
                SqlParameter Parametro_Direccion_Trabajador = new SqlParameter();
                Parametro_Direccion_Trabajador.ParameterName = "@direccion";
                Parametro_Direccion_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Trabajador.Size = 50;
                Parametro_Direccion_Trabajador.Value = Usuario.Direccion;
                SqlComando.Parameters.Add(Parametro_Direccion_Trabajador);

                //parametro telefono
                SqlParameter Parametro_Telefono_Trabajador = new SqlParameter();
                Parametro_Telefono_Trabajador.ParameterName = "@telefono";
                Parametro_Telefono_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Trabajador.Size = 13;
                Parametro_Telefono_Trabajador.Value = Usuario.Telefono;
                SqlComando.Parameters.Add(Parametro_Telefono_Trabajador);

                //parametro correo
                SqlParameter Parametro_Correo_Trabajador = new SqlParameter();
                Parametro_Correo_Trabajador.ParameterName = "@correo";
                Parametro_Correo_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Correo_Trabajador.Size = 60;
                Parametro_Correo_Trabajador.Value = Usuario.Correo;
                SqlComando.Parameters.Add(Parametro_Correo_Trabajador);

                //parametro acceso
                SqlParameter Parametro_Acceso_Trabajador = new SqlParameter();
                Parametro_Acceso_Trabajador.ParameterName = "@acceso";
                Parametro_Acceso_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Acceso_Trabajador.Value = Usuario.Acceso;
                SqlComando.Parameters.Add(Parametro_Acceso_Trabajador);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Trabajador";

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
        public string Editar(DUsuario Usuario)
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
                SqlComando.CommandText = "editar_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros


                //parametro cedula
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@cedula";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 10;
                Parametro_Id_Trabajador.Value = Usuario.Cedula;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro nombre
                SqlParameter Parametro_Nombre_Trabajador = new SqlParameter();
                Parametro_Nombre_Trabajador.ParameterName = "@nombre";
                Parametro_Nombre_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Trabajador.Size = 50;
                Parametro_Nombre_Trabajador.Value = Usuario.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Trabajador);

                //parametro contraseña
                SqlParameter Parametro_Contraseña_Trabajador = new SqlParameter();
                Parametro_Contraseña_Trabajador.ParameterName = "@password";
                Parametro_Contraseña_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Contraseña_Trabajador.Size = 30;
                Parametro_Contraseña_Trabajador.Value = Usuario.Contraseña;
                SqlComando.Parameters.Add(Parametro_Contraseña_Trabajador);

                //parametro direccion
                SqlParameter Parametro_Direccion_Trabajador = new SqlParameter();
                Parametro_Direccion_Trabajador.ParameterName = "@direccion";
                Parametro_Direccion_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Trabajador.Size = 50;
                Parametro_Direccion_Trabajador.Value = Usuario.Direccion;
                SqlComando.Parameters.Add(Parametro_Direccion_Trabajador);

                //parametro telefono
                SqlParameter Parametro_Telefono_Trabajador = new SqlParameter();
                Parametro_Telefono_Trabajador.ParameterName = "@telefono";
                Parametro_Telefono_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Trabajador.Size = 13;
                Parametro_Telefono_Trabajador.Value = Usuario.Telefono;
                SqlComando.Parameters.Add(Parametro_Telefono_Trabajador);

                //parametro correo
                SqlParameter Parametro_Correo_Trabajador = new SqlParameter();
                Parametro_Correo_Trabajador.ParameterName = "@correo";
                Parametro_Correo_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Correo_Trabajador.Size = 60;
                Parametro_Correo_Trabajador.Value = Usuario.Correo;
                SqlComando.Parameters.Add(Parametro_Correo_Trabajador);

                //parametro acceso
                SqlParameter Parametro_Acceso_Trabajador = new SqlParameter();
                Parametro_Acceso_Trabajador.ParameterName = "@acceso";
                Parametro_Acceso_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Correo_Trabajador.Size = 15;
                Parametro_Acceso_Trabajador.Value = Usuario.Acceso;
                SqlComando.Parameters.Add(Parametro_Acceso_Trabajador);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro del paciente";

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
        public string Eliminar(DUsuario Trabajador)
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
                SqlComando.CommandText = "eliminar_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@cedula";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 10;
                Parametro_Id_Trabajador.Value = Trabajador.Cedula;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el usuario";

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

        public string Anular(DUsuario Trabajador)
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
                SqlComando.CommandText = "anular_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@cedula";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 10;
                Parametro_Id_Trabajador.Value = Trabajador.Cedula;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el usuario";

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

        //Mostrar
        public List<DUsuario> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlConectar = new SqlConnection();
            List<DUsuario> ListaGenerica = new List<DUsuario>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DUsuario
                    {
                        Cedula = LeerFilas.GetString(0),
                        Nombre = LeerFilas.GetString(1),
                        Contraseña=LeerFilas.GetString(2),
                        Direccion = LeerFilas.GetString(3),
                        Telefono = LeerFilas.GetString(4),
                        Correo=LeerFilas.GetString(5),
                        Acceso=LeerFilas.GetString(6),
                        Estado=LeerFilas.GetString(7)
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

        public List<DUsuario> Buscar_Nombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlConectar = new SqlConnection();
            List<DUsuario> ListaGenerica = new List<DUsuario>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "buscar_usuario_nombre";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DUsuario
                    {
                        Cedula = LeerFilas.GetString(0),
                        Nombre = LeerFilas.GetString(1),
                        Contraseña = LeerFilas.GetString(2),
                        Direccion = LeerFilas.GetString(3),
                        Telefono = LeerFilas.GetString(4),
                        Correo = LeerFilas.GetString(5),
                        Acceso = LeerFilas.GetString(6),
                        Estado=LeerFilas.GetString(7)
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

        public List<DUsuario> CedulaUnica(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlConectar = new SqlConnection();
            List<DUsuario> ListaGenerica = new List<DUsuario>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "cedulaunica_usuario";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DUsuario
                    {
                        Cedula = LeerFilas.GetString(0),
                        Nombre = LeerFilas.GetString(1),
                        Contraseña = LeerFilas.GetString(2),
                        Direccion = LeerFilas.GetString(3),
                        Telefono = LeerFilas.GetString(4),
                        Correo = LeerFilas.GetString(5),
                        Acceso = LeerFilas.GetString(6),
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


        public DataTable Login(DUsuario Usuario)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "acceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametro usuario
                SqlParameter Parametro_Usuario = new SqlParameter();
                Parametro_Usuario.ParameterName = "@cedula";
                Parametro_Usuario.SqlDbType = SqlDbType.VarChar;
                Parametro_Usuario.Size = 10;
                Parametro_Usuario.Value = Usuario.Cedula;
                SqlCmd.Parameters.Add(Parametro_Usuario);

                //parametro clave
                SqlParameter Parametro_Contraseña = new SqlParameter();
                Parametro_Contraseña.ParameterName = "@contraseña";
                Parametro_Contraseña.SqlDbType = SqlDbType.VarChar;
                Parametro_Contraseña.Size = 30;
                Parametro_Contraseña.Value = Usuario.Contraseña;
                SqlCmd.Parameters.Add(Parametro_Contraseña);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
