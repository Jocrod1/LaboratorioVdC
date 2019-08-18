using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DPaciente:Conexion
    {
        private int _IdPaciente;

        public int IdPaciente
        {
            get { return _IdPaciente; }
            set { _IdPaciente = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private DateTime _FechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        private string _Sexo;

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }
        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }
        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private DateTime _FUR;

        public DateTime FUR
        {
            get { return _FUR; }
            set { _FUR = value; }
        }
        private string _NumeroHabitacion;

        public string NumeroHabitacion
        {
            get { return _NumeroHabitacion; }
            set { _NumeroHabitacion = value; }
        }





        //constructor vacio
        public DPaciente()
        {

        }

        public DPaciente(int IdPaciente, string Nombre, DateTime FechaNacimiento, string Sexo,string Cedula,string Telefono, DateTime FUR,string NumeroHabitacion)
        {
            this.IdPaciente = IdPaciente;
            this.Nombre = Nombre;
            this.FechaNacimiento = FechaNacimiento;
            this.Sexo = Sexo;
            this.Cedula= Cedula;
            this.Telefono = Telefono;
            this.FUR = FUR;
            this.NumeroHabitacion = NumeroHabitacion;
        }


        //Metodos

        //insertar
        public string Insertar(DPaciente Paciente)
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
                SqlComando.CommandText = "insertar_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@IDPaciente";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Paciente = new SqlParameter();
                Parametro_Nombre_Paciente.ParameterName = "@nombre";
                Parametro_Nombre_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Paciente.Size = 30;
                Parametro_Nombre_Paciente.Value = Paciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Paciente);

                //parametro edad
                SqlParameter Parametro_FechaNac_Paciente = new SqlParameter();
                Parametro_FechaNac_Paciente.ParameterName = "@FechaNac";
                Parametro_FechaNac_Paciente.SqlDbType = SqlDbType.Date;
                Parametro_FechaNac_Paciente.Value = Paciente.FechaNacimiento;
                SqlComando.Parameters.Add(Parametro_FechaNac_Paciente);

                //parametro sexo
                SqlParameter Parametro_Sexo_Paciente = new SqlParameter();
                Parametro_Sexo_Paciente.ParameterName = "@sexo";
                Parametro_Sexo_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Paciente.Size = 10;
                Parametro_Sexo_Paciente.Value = Paciente.Sexo;
                SqlComando.Parameters.Add(Parametro_Sexo_Paciente);

                //parametro cedula
                SqlParameter Parametro_Cedula_Paciente = new SqlParameter();
                Parametro_Cedula_Paciente.ParameterName = "@cedula";
                Parametro_Cedula_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Paciente.Size = 10;
                Parametro_Cedula_Paciente.Value = Paciente.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Paciente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Paciente = new SqlParameter();
                Parametro_Telefono_Paciente.ParameterName = "@telefono";
                Parametro_Telefono_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Paciente.Size = 10;
                Parametro_Telefono_Paciente.Value = Paciente.Telefono;
                SqlComando.Parameters.Add(Parametro_Telefono_Paciente);

                //parametro FUR
                SqlParameter Parametro_FUR_Paciente = new SqlParameter();
                Parametro_FUR_Paciente.ParameterName = "@FUR";
                Parametro_FUR_Paciente.SqlDbType = SqlDbType.Date;
                Parametro_FUR_Paciente.Value = Paciente.FUR;
                SqlComando.Parameters.Add(Parametro_FUR_Paciente);

                ////parametro numero habitacion
                //SqlParameter Parametro_NHabitacion_Paciente = new SqlParameter();
                //Parametro_NHabitacion_Paciente.ParameterName = "@NumeroHabitacion";
                //Parametro_NHabitacion_Paciente.SqlDbType = SqlDbType.VarChar;
                //Parametro_NHabitacion_Paciente.Size = 10;
                //Parametro_NHabitacion_Paciente.Value = Paciente.NumeroHabitacion;
                //SqlComando.Parameters.Add(Parametro_NHabitacion_Paciente);



                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Paciente";

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
        public string Editar(DPaciente Paciente)
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
                SqlComando.CommandText = "editar_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@IDPaciente";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Value= Paciente.IdPaciente;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Paciente = new SqlParameter();
                Parametro_Nombre_Paciente.ParameterName = "@nombre";
                Parametro_Nombre_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Paciente.Size = 30;
                Parametro_Nombre_Paciente.Value = Paciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Paciente);

                //parametro edad
                SqlParameter Parametro_FechaNac_Paciente = new SqlParameter();
                Parametro_FechaNac_Paciente.ParameterName = "@FechaNac";
                Parametro_FechaNac_Paciente.SqlDbType = SqlDbType.Date;
                Parametro_FechaNac_Paciente.Value = Paciente.FechaNacimiento;
                SqlComando.Parameters.Add(Parametro_FechaNac_Paciente);

                //parametro sexo
                SqlParameter Parametro_Sexo_Paciente = new SqlParameter();
                Parametro_Sexo_Paciente.ParameterName = "@sexo";
                Parametro_Sexo_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Paciente.Size = 10;
                Parametro_Sexo_Paciente.Value = Paciente.Sexo;
                SqlComando.Parameters.Add(Parametro_Sexo_Paciente);

                //parametro cedula
                SqlParameter Parametro_Cedula_Paciente = new SqlParameter();
                Parametro_Cedula_Paciente.ParameterName = "@cedula";
                Parametro_Cedula_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Paciente.Size = 10;
                Parametro_Cedula_Paciente.Value = Paciente.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Paciente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Paciente = new SqlParameter();
                Parametro_Telefono_Paciente.ParameterName = "@telefono";
                Parametro_Telefono_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Paciente.Size = 10;
                Parametro_Telefono_Paciente.Value = Paciente.Telefono;
                SqlComando.Parameters.Add(Parametro_Telefono_Paciente);

                //parametro FUR
                SqlParameter Parametro_FUR_Paciente = new SqlParameter();
                Parametro_FUR_Paciente.ParameterName = "@FUR";
                Parametro_FUR_Paciente.SqlDbType = SqlDbType.Date;
                Parametro_FUR_Paciente.Value = Paciente.FUR;
                SqlComando.Parameters.Add(Parametro_FUR_Paciente);

                //parametro numero habitacion
                SqlParameter Parametro_NHabitacion_Paciente = new SqlParameter();
                Parametro_NHabitacion_Paciente.ParameterName = "@nrohab";
                Parametro_NHabitacion_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_NHabitacion_Paciente.Size = 10;
                Parametro_NHabitacion_Paciente.Value = Paciente.NumeroHabitacion;
                SqlComando.Parameters.Add(Parametro_NHabitacion_Paciente);


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
        public string Eliminar(DPaciente Paciente)
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
                SqlComando.CommandText = "eliminar_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@IDPaciente";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Value = Paciente.IdPaciente;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del paciente";

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

        public string Anular(DPaciente Paciente)
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
                SqlComando.CommandText = "anular_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@IDPaciente";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Value = Paciente.IdPaciente;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro del paciente";

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
        public List<DPaciente> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Paciente");
            SqlConnection SqlConectar = new SqlConnection();
            List<DPaciente> ListaGenerica = new List<DPaciente>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DPaciente
                    {
                        IdPaciente = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        FechaNacimiento = LeerFilas.GetDateTime(2),
                        Sexo = LeerFilas.GetString(3),
                        Cedula = LeerFilas.GetString(4),
                        Telefono = LeerFilas.GetString(5),
                        FUR = LeerFilas.GetDateTime(6),
                        NumeroHabitacion = LeerFilas.GetString(7)
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

        
        //Buscar
        public List<DPaciente> Buscar_Cedula(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Paciente");
            SqlConnection SqlConectar = new SqlConnection();
            List<DPaciente> ListaGenerica = new List<DPaciente>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "buscar_Paciente_Cedula";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@textobuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DPaciente
                    {
                        IdPaciente=LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        FechaNacimiento = LeerFilas.GetDateTime(2),
                        Sexo = LeerFilas.GetString(3),
                        Cedula = LeerFilas.GetString(4),
                        Telefono = LeerFilas.GetString(5),
                        FUR=LeerFilas.GetDateTime(6),
                        NumeroHabitacion=LeerFilas.GetString(7)
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

        public List<DPaciente> CedulaUnica(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Paciente");
            SqlConnection SqlConectar = new SqlConnection();
            List<DPaciente> ListaGenerica = new List<DPaciente>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "cedulaunica_paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@textobuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DPaciente
                    {
                        IdPaciente = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        FechaNacimiento = LeerFilas.GetDateTime(2),
                        Sexo = LeerFilas.GetString(3),
                        Cedula = LeerFilas.GetString(4),
                        Telefono = LeerFilas.GetString(5),
                        FUR = LeerFilas.GetDateTime(6),
                        NumeroHabitacion = LeerFilas.GetString(7)
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
