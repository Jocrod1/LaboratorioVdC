using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DMedico: Conexion
    {
        private int _IDMedico;

        public int IdMedico
        {
            get { return _IDMedico; }
            set { _IDMedico = value; }
        }

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

        private string _ClinicaOHospital;

        public string ClinicaOHospital
        {
            get { return _ClinicaOHospital; }
            set { _ClinicaOHospital = value; }
        }

        public DMedico()
        {

        }

        public DMedico(int IDMedico,string Cedula, string Nombre, string ClinicaOHospital)
        {
            this.IdMedico = IDMedico;
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.ClinicaOHospital = ClinicaOHospital;
        }

        public string Insertar(DMedico Medico)
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
                SqlComando.CommandText = "insertar_medico";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Medico = new SqlParameter();
                Parametro_Id_Medico.ParameterName = "@IDMedico";
                Parametro_Id_Medico.SqlDbType = SqlDbType.Int;
                Parametro_Id_Medico.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Medico);

                //parametro cedula
                SqlParameter Parametro_Cedula_Medico = new SqlParameter();
                Parametro_Cedula_Medico.ParameterName = "@cedula";
                Parametro_Cedula_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Medico.Size = 10;
                Parametro_Cedula_Medico.Value = Medico.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Medico);

                //parametro nombre
                SqlParameter Parametro_Nombre_Medico = new SqlParameter();
                Parametro_Nombre_Medico.ParameterName = "@nombre";
                Parametro_Nombre_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Medico.Size = 50;
                Parametro_Nombre_Medico.Value = Medico.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Medico);

                //parametro clinica o hospital
                SqlParameter Parametro_Clinica_Medico = new SqlParameter();
                Parametro_Clinica_Medico.ParameterName = "@ClinicaOHospital";
                Parametro_Clinica_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Clinica_Medico.Size = 70;
                Parametro_Clinica_Medico.Value = Medico.ClinicaOHospital;
                SqlComando.Parameters.Add(Parametro_Clinica_Medico);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Medico";

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

        public string Editar(DMedico Medico)
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
                SqlComando.CommandText = "editar_medico";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Medico = new SqlParameter();
                Parametro_Id_Medico.ParameterName = "@ID";
                Parametro_Id_Medico.SqlDbType = SqlDbType.Int;
                Parametro_Id_Medico.Value= Medico.IdMedico;
                SqlComando.Parameters.Add(Parametro_Id_Medico);

                //parametro cedula
                SqlParameter Parametro_Cedula_Medico = new SqlParameter();
                Parametro_Cedula_Medico.ParameterName = "@Cedula";
                Parametro_Cedula_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Cedula_Medico.Size = 10;
                Parametro_Cedula_Medico.Value = Medico.Cedula;
                SqlComando.Parameters.Add(Parametro_Cedula_Medico);

                //parametro nombre
                SqlParameter Parametro_Nombre_Medico = new SqlParameter();
                Parametro_Nombre_Medico.ParameterName = "@nombre";
                Parametro_Nombre_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Medico.Size = 50;
                Parametro_Nombre_Medico.Value = Medico.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Medico);

                //parametro clinica o hospital
                SqlParameter Parametro_Clinica_Medico = new SqlParameter();
                Parametro_Clinica_Medico.ParameterName = "@ClinicaOHospital";
                Parametro_Clinica_Medico.SqlDbType = SqlDbType.VarChar;
                Parametro_Clinica_Medico.Size = 70;
                Parametro_Clinica_Medico.Value = Medico.ClinicaOHospital;
                SqlComando.Parameters.Add(Parametro_Clinica_Medico);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro del medico";

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
        public string Eliminar(DMedico Medico)
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
                SqlComando.CommandText = "eliminar_medico";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Medico = new SqlParameter();
                Parametro_Id_Medico.ParameterName = "@ID";
                Parametro_Id_Medico.SqlDbType = SqlDbType.Int;
                Parametro_Id_Medico.Value = Medico.IdMedico;
                SqlComando.Parameters.Add(Parametro_Id_Medico);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del medico";

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
        public List<DMedico> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Medicos");
            SqlConnection SqlConectar = new SqlConnection();
            List<DMedico> ListaGenerica = new List<DMedico>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_medico";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DMedico
                    {
                        IdMedico = LeerFilas.GetInt32(0),
                        _Cedula= LeerFilas.GetString(1),
                        Nombre = LeerFilas.GetString(2),
                        ClinicaOHospital= LeerFilas.GetString(3),
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


        public List<DMedico> CedulaUnica(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Medicos");
            SqlConnection SqlConectar = new SqlConnection();
            List<DMedico> ListaGenerica = new List<DMedico>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "cedulaunica_medico";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DMedico
                    {
                        IdMedico = LeerFilas.GetInt32(0),
                        _Cedula = LeerFilas.GetString(1),
                        Nombre = LeerFilas.GetString(2),
                        ClinicaOHospital = LeerFilas.GetString(3),
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
