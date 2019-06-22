using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    class DPaciente:Conexion
    {
        private int _IdPaciente;
        private string _Nombre;
        private int _Edad;
        private string _Sexo;
        private string _Cedula;
        private string _Telefono;
        private DateTime _FUR;
        private string _NumeroHabitacion;
        private int _IdMedico;
        private string _TextoBuscar;

        public int IdPaciente { get => _IdPaciente; set => _IdPaciente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public DateTime FUR { get => _FUR; set => _FUR = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string NumeroHabitacion { get => _NumeroHabitacion; set => _NumeroHabitacion = value; }
        public int IdMedico { get => _IdMedico; set => _IdMedico = value; }


        //constructor vacio
        public DPaciente()
        {

        }

        public DPaciente(int IdCliente, string Nombre, int Edad, string Sexo,string Cedula,string Telefono, DateTime FUR,string NumeroHabitacion,int IdMedico, string TextoBuscar)
        {
            this.IdPaciente = IdPaciente;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Sexo = Sexo;
            this.Cedula= Cedula;
            this.Telefono = Telefono;
            this.FUR = FUR;
            this.NumeroHabitacion = NumeroHabitacion;
            this.IdMedico = IdMedico;
            this.TextoBuscar = TextoBuscar;
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
                SqlComando.CommandText = "Insertar_Paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@ID";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Paciente = new SqlParameter();
                Parametro_Nombre_Paciente.ParameterName = "@Nombre";
                Parametro_Nombre_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Paciente.Size = 30;
                Parametro_Nombre_Paciente.Value = Paciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Paciente);

                //parametro edad
                SqlParameter Parametro_Edad_Paciente = new SqlParameter();
                Parametro_Edad_Paciente.ParameterName = "@Edad";
                Parametro_Edad_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Edad_Paciente.Value = Paciente.Edad;
                SqlComando.Parameters.Add(Parametro_Edad_Paciente);

                //parametro sexo
                SqlParameter Parametro_Sexo_Paciente = new SqlParameter();
                Parametro_Sexo_Paciente.ParameterName = "@Sexo";
                Parametro_Sexo_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Paciente.Size = 10;
                Parametro_Sexo_Paciente.Value = Paciente.Sexo;
                SqlComando.Parameters.Add(Parametro_Sexo_Paciente);

                //parametro cedula
                SqlParameter Parametro_Cedula_Paciente = new SqlParameter();
                Parametro_Cedula_Paciente.ParameterName = "@Cedula";
                Parametro_Cedula_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Paciente.Size = 10;
                Parametro_Cedula_Paciente.Value = Paciente.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Paciente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Paciente = new SqlParameter();
                Parametro_Telefono_Paciente.ParameterName = "@Telefono";
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
                Parametro_NHabitacion_Paciente.ParameterName = "@NroHabitacion";
                Parametro_NHabitacion_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_NHabitacion_Paciente.Size = 10;
                Parametro_NHabitacion_Paciente.Value = Paciente.NumeroHabitacion;
                SqlComando.Parameters.Add(Parametro_NHabitacion_Paciente);

                //parametro id medico
                SqlParameter Parametro_IdMedico_Paciente = new SqlParameter();
                Parametro_IdMedico_Paciente.ParameterName = "@IdMedico";
                Parametro_IdMedico_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_IdMedico_Paciente.Value = Paciente.IdMedico;
                SqlComando.Parameters.Add(Parametro_IdMedico_Paciente);



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
                SqlComando.CommandText = "Editar_Paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@ID";
                Parametro_Id_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Id_Paciente.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Paciente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Paciente = new SqlParameter();
                Parametro_Nombre_Paciente.ParameterName = "@Nombre";
                Parametro_Nombre_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Paciente.Size = 30;
                Parametro_Nombre_Paciente.Value = Paciente.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Paciente);

                //parametro edad
                SqlParameter Parametro_Edad_Paciente = new SqlParameter();
                Parametro_Edad_Paciente.ParameterName = "@Edad";
                Parametro_Edad_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_Edad_Paciente.Value = Paciente.Edad;
                SqlComando.Parameters.Add(Parametro_Edad_Paciente);

                //parametro sexo
                SqlParameter Parametro_Sexo_Paciente = new SqlParameter();
                Parametro_Sexo_Paciente.ParameterName = "@Sexo";
                Parametro_Sexo_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Paciente.Size = 10;
                Parametro_Sexo_Paciente.Value = Paciente.Sexo;
                SqlComando.Parameters.Add(Parametro_Sexo_Paciente);

                //parametro cedula
                SqlParameter Parametro_Cedula_Paciente = new SqlParameter();
                Parametro_Cedula_Paciente.ParameterName = "@Cedula";
                Parametro_Cedula_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Paciente.Size = 10;
                Parametro_Cedula_Paciente.Value = Paciente.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Paciente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Paciente = new SqlParameter();
                Parametro_Telefono_Paciente.ParameterName = "@Telefono";
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
                Parametro_NHabitacion_Paciente.ParameterName = "@NroHabitacion";
                Parametro_NHabitacion_Paciente.SqlDbType = SqlDbType.VarChar;
                Parametro_NHabitacion_Paciente.Size = 10;
                Parametro_NHabitacion_Paciente.Value = Paciente.NumeroHabitacion;
                SqlComando.Parameters.Add(Parametro_NHabitacion_Paciente);

                //parametro id medico
                SqlParameter Parametro_IdMedico_Paciente = new SqlParameter();
                Parametro_IdMedico_Paciente.ParameterName = "@IdMedico";
                Parametro_IdMedico_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_IdMedico_Paciente.Value = Paciente.IdMedico;
                SqlComando.Parameters.Add(Parametro_IdMedico_Paciente);



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
                SqlComando.CommandText = "Eliminar_Paciente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Paciente = new SqlParameter();
                Parametro_Id_Paciente.ParameterName = "@ID";
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

        //mostrar
        public List<DPaciente> Mostrar()
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
                SqlComando.CommandText = "Mostrar_Paciente";
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
                        Edad = LeerFilas.GetInt32(2),
                        Sexo = LeerFilas.GetString(3),
                        Cedula = LeerFilas.GetString(4),
                        Telefono = LeerFilas.GetString(5),
                        FUR = LeerFilas.GetDateTime(6),
                        NumeroHabitacion = LeerFilas.GetString(7),
                        IdMedico = LeerFilas.GetInt32(8),
                    });
                }
                LeerFilas.Close();
                SqlConectar.Close();
            }
            catch (Exception ex)
            {
                ListaGenerica = null;
            }

            return ListaGenerica;

        }

        /*
        //Buscar
        public List<DPaciente> Buscar_Cedula()
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
                SqlComando.CommandText = "Buscar_Paciente_Cedula";
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
                        Edad = LeerFilas.GetInt32(2),
                        Sexo = LeerFilas.GetString(3),
                        Cedula = LeerFilas.GetString(4),
                        Telefono = LeerFilas.GetString(5),
                        FUR=LeerFilas.GetDateTime(6),
                        NumeroHabitacion=LeerFilas.GetString(7),
                        IdMedico=LeerFilas.GetInt32(8),
                    });
                }
                LeerFilas.Close();
                SqlConectar.Close();
            }
            catch (Exception ex)
            {
                ListaGenerica = null;
            }

            return ListaGenerica;

        }
        */
    }
}
