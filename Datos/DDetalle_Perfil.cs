using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDetalle_Perfil:Conexion
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _IDPerfil;

        public int IDPerfil
        {
            get { return _IDPerfil; }
            set { _IDPerfil = value; }
        }
        private int _IDExamen;

        public int IDExamen
        {
            get { return _IDExamen; }
            set { _IDExamen = value; }
        }

        private string _NombrePerfil;

public string NombrePerfil
{
  get { return _NombrePerfil; }
  set { _NombrePerfil = value; }
}
private string _NombreExamen;

public string NombreExamen
{
    get { return _NombreExamen; }
    set { _NombreExamen = value; }
}






        public DDetalle_Perfil()
        {

        }

        public DDetalle_Perfil(int iD, int iDPerfil, int iDExamen, string nombreperfil, string nombreexamen)
        {
            ID = iD;
            IDPerfil = iDPerfil;
            IDExamen = iDExamen;
            NombrePerfil = nombreperfil;
            NombreExamen = nombreexamen;
        }


        //metodos

        //insertar
        public string Insertar(DDetalle_Perfil Detalle_Perfil, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "insertar_detalleperfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle orden
                SqlParameter Parametro_Id_Detalle_Perfil = new SqlParameter();
                Parametro_Id_Detalle_Perfil.ParameterName = "@ID";
                Parametro_Id_Detalle_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Perfil.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Perfil);

                //parametro id perfil
                SqlParameter Parametro_Id_Perfil = new SqlParameter();
                Parametro_Id_Perfil.ParameterName = "@IDPerfil";
                Parametro_Id_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Perfil.Value = Detalle_Perfil.IDPerfil;
                SqlComando.Parameters.Add(Parametro_Id_Perfil);

                //parametro id examen
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@IDExamen";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Detalle_Perfil.IDExamen;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el detalle de perfil";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }

        //Eliminar
        public string Eliminar(DDetalle_Perfil Detalle_Perfil)
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
                Parametro_Id.Value = Detalle_Perfil.IDPerfil;
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

        //mostrar detalle fecha
        public List<DDetalle_Perfil> MostrarDetalle(int TextoBuscar)
        {
            DataTable DtResultado = new DataTable("DetallePerfil");
            SqlConnection SqlConectar = new SqlConnection();
            List<DDetalle_Perfil> ListaGenerica = new List<DDetalle_Perfil>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_detalleperfil";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@IDperfil", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {

                    ListaGenerica.Add(new DDetalle_Perfil
                    {
                        ID = LeerFilas.GetInt32(0),
                        IDExamen=LeerFilas.GetInt32(1),
                        NombreExamen = LeerFilas.GetString(2)
                    });
                }
                LeerFilas.Close();
                SqlConectar.Close();
            }
            catch (Exception e)
            {
                ListaGenerica = null;
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return ListaGenerica;

        }

    }
}
