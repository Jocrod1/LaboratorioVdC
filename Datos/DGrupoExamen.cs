using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DGrupoExamen: Conexion
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



        public DGrupoExamen()
        {

        }

        public DGrupoExamen(int iD, string nombre)
        {
            ID = iD;
            Nombre = nombre;
        }

        //Metodos

        //insertar
        public string Insertar(DGrupoExamen GrupoExamen)
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
                SqlComando.CommandText = "insertar_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Grupo_Examen = new SqlParameter();
                Parametro_Id_Grupo_Examen.ParameterName = "@ID";
                Parametro_Id_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Grupo_Examen.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Grupo_Examen);

                //parametro nombre
                SqlParameter Parametro_Nombre_Grupo_Examen = new SqlParameter();
                Parametro_Nombre_Grupo_Examen.ParameterName = "@nombre";
                Parametro_Nombre_Grupo_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Grupo_Examen.Size = 50;
                Parametro_Nombre_Grupo_Examen.Value = GrupoExamen.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Grupo_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Grupo de Examenes";

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
        public string Editar(DGrupoExamen GrupoExamen)
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
                SqlComando.CommandText = "editar_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Grupo_Examen = new SqlParameter();
                Parametro_Id_Grupo_Examen.ParameterName = "@ID";
                Parametro_Id_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Grupo_Examen.Value = GrupoExamen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Grupo_Examen);

                //parametro nombre
                SqlParameter Parametro_Nombre_Grupo_Examen = new SqlParameter();
                Parametro_Nombre_Grupo_Examen.ParameterName = "@nombre";
                Parametro_Nombre_Grupo_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Grupo_Examen.Size = 50;
                Parametro_Nombre_Grupo_Examen.Value = GrupoExamen.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Grupo_Examen);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro del Examen";

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
        public string Eliminar(DGrupoExamen GrupoExamen)
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
                SqlComando.CommandText = "eliminar_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Grupo_Examen = new SqlParameter();
                Parametro_Id_Grupo_Examen.ParameterName = "@ID";
                Parametro_Id_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Grupo_Examen.Value = GrupoExamen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Grupo_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del grupo de examenes";

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


        public string Anular(DGrupoExamen GrupoExamen)
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
                SqlComando.CommandText = "anular_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Grupo_Examen = new SqlParameter();
                Parametro_Id_Grupo_Examen.ParameterName = "@ID";
                Parametro_Id_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Grupo_Examen.Value = GrupoExamen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Grupo_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro del grupo de examenes";

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
        public List<DGrupoExamen> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("GrupoExamen");
            SqlConnection SqlConectar = new SqlConnection();
            List<DGrupoExamen> ListaGenerica = new List<DGrupoExamen>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DGrupoExamen
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
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


        public List<DGrupoExamen> MostrarCombobox()
        {
            DataTable DtResultado = new DataTable("GrupoExamen");
            SqlConnection SqlConectar = new SqlConnection();
            List<DGrupoExamen> ListaGenerica = new List<DGrupoExamen>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "seleccionar_grupoexamen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DGrupoExamen
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
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
