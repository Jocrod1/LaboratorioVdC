using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DOrden:Conexion
    {
        private int _ID;
        private int _IDBioanalista;
        private string _IDUsuario;
        private int _IDMedico;
        private int _IDTurno;
        private DateTime _Fecha;

        private string NombreBioanalista;
        private string NombreUsuario;
        private string NombreMedico;
        private string NombreTurno;

        public int ID { get => _ID; set => _ID = value; }
        public int IDBioanalista { get => _IDBioanalista; set => _IDBioanalista = value; }
        public string IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public int IDMedico { get => _IDMedico; set => _IDMedico = value; }
        public int IDTurno { get => _IDTurno; set => _IDTurno = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string NombreBioanalista1 { get => NombreBioanalista; set => NombreBioanalista = value; }
        public string NombreUsuario1 { get => NombreUsuario; set => NombreUsuario = value; }
        public string NombreMedico1 { get => NombreMedico; set => NombreMedico = value; }
        public string NombreTurno1 { get => NombreTurno; set => NombreTurno = value; }

        public DOrden()
        {

        }

        public DOrden(int iD, int iDBioanalista, string iDUsuario, int iDMedico, int iDTurno, DateTime fecha, string nombreBioanalista1, string nombreUsuario1, string nombreMedico1, string nombreTurno1)
        {
            ID = iD;
            IDBioanalista = iDBioanalista;
            IDUsuario = iDUsuario;
            IDMedico = iDMedico;
            IDTurno = iDTurno;
            Fecha = fecha;
            NombreBioanalista1 = nombreBioanalista1;
            NombreUsuario1 = nombreUsuario1;
            NombreMedico1 = nombreMedico1;
            NombreTurno1 = nombreTurno1;
        }




        //metodos

        //insertar
        public string Insertar(DOrden Orden)
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
                SqlComando.CommandText = "insertar_orden";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro id bioanalista
                SqlParameter Parametro_ID_Bioanalista = new SqlParameter();
                Parametro_ID_Bioanalista.ParameterName = "@IDBioanalista";
                Parametro_ID_Bioanalista.SqlDbType = SqlDbType.Int;
                Parametro_ID_Bioanalista.Value = Orden.IDBioanalista;
                SqlComando.Parameters.Add(Parametro_ID_Bioanalista);

                //parametro id usuario
                SqlParameter Parametro_ID_Usuario = new SqlParameter();
                Parametro_ID_Usuario.ParameterName = "@IDUsuario";
                Parametro_ID_Usuario.SqlDbType = SqlDbType.VarChar;
                Parametro_ID_Usuario.Size = 50;
                Parametro_ID_Usuario.Value = Orden.IDUsuario;
                SqlComando.Parameters.Add(Parametro_ID_Usuario);

                //parametro id medico
                SqlParameter Parametro_ID_Medico = new SqlParameter();
                Parametro_ID_Medico.ParameterName = "@IDMedico";
                Parametro_ID_Medico.SqlDbType = SqlDbType.Int;
                Parametro_ID_Medico.Value = Orden.IDMedico;
                SqlComando.Parameters.Add(Parametro_ID_Medico);

                //parametro id turno
                SqlParameter Parametro_ID_Turno = new SqlParameter();
                Parametro_ID_Turno.ParameterName = "@IDTurno";
                Parametro_ID_Turno.SqlDbType = SqlDbType.Int;
                Parametro_ID_Turno.Value = Orden.IDTurno;
                SqlComando.Parameters.Add(Parametro_ID_Turno);

                //parametro fecha
                SqlParameter Parametro_Fecha = new SqlParameter();
                Parametro_Fecha.ParameterName = "@Fecha";
                Parametro_Fecha.SqlDbType = SqlDbType.Date;
                Parametro_Fecha.Value = Orden.Fecha;
                SqlComando.Parameters.Add(Parametro_Fecha);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro de la orden";

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
        public string Editar(DOrden Orden)
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
                SqlComando.CommandText = "editar_orden";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Orden.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //parametro id bioanalista
                SqlParameter Parametro_ID_Bioanalista = new SqlParameter();
                Parametro_ID_Bioanalista.ParameterName = "@IDBioanalista";
                Parametro_ID_Bioanalista.SqlDbType = SqlDbType.Int;
                Parametro_ID_Bioanalista.Value = Orden.IDBioanalista;
                SqlComando.Parameters.Add(Parametro_ID_Bioanalista);

                //parametro id usuario
                SqlParameter Parametro_ID_Usuario = new SqlParameter();
                Parametro_ID_Usuario.ParameterName = "@IDUsuario";
                Parametro_ID_Usuario.SqlDbType = SqlDbType.VarChar;
                Parametro_ID_Usuario.Size = 50;
                Parametro_ID_Usuario.Value = Orden.IDUsuario;
                SqlComando.Parameters.Add(Parametro_ID_Usuario);

                //parametro id medico
                SqlParameter Parametro_ID_Medico = new SqlParameter();
                Parametro_ID_Medico.ParameterName = "@IDMedico";
                Parametro_ID_Medico.SqlDbType = SqlDbType.Int;
                Parametro_ID_Medico.Value = Orden.IDMedico;
                SqlComando.Parameters.Add(Parametro_ID_Medico);

                //parametro id turno
                SqlParameter Parametro_ID_Turno = new SqlParameter();
                Parametro_ID_Turno.ParameterName = "@IDTurno";
                Parametro_ID_Turno.SqlDbType = SqlDbType.Int;
                Parametro_ID_Turno.Value = Orden.IDTurno;
                SqlComando.Parameters.Add(Parametro_ID_Turno);

                //parametro fecha
                SqlParameter Parametro_Fecha = new SqlParameter();
                Parametro_Fecha.ParameterName = "@Fecha";
                Parametro_Fecha.SqlDbType = SqlDbType.Date;
                Parametro_Fecha.Value = Orden.Fecha;
                SqlComando.Parameters.Add(Parametro_Fecha);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro de la orden";

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
        public List<DOrden> Mostrar(int limite, string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Orden");
            SqlConnection SqlConectar = new SqlConnection();
            List<DOrden> ListaGenerica = new List<DOrden>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_orden";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);
                SqlComando.Parameters.AddWithValue("@limite", limite);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

      

                while (LeerFilas.Read())
                {
                ListaGenerica.Add(new DOrden
                    {
                    ID= LeerFilas.GetInt32(0),
                    NombreBioanalista = LeerFilas.GetString(1),
                    NombreUsuario = LeerFilas.GetString(2),
                    NombreMedico = LeerFilas.GetString(3),
                    NombreTurno = LeerFilas.GetString(4),
                    Fecha=LeerFilas.GetDateTime(5)
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


        public List<DOrden> MostrarFechas(int limite, string CedulaUsuario, string NombreBioanalista, DateTime fecha1, DateTime fecha2)
        {
            DataTable DtResultado = new DataTable("Orden");
            SqlConnection SqlConectar = new SqlConnection();
            List<DOrden> ListaGenerica = new List<DOrden>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_orden";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@cedulaUsuario", CedulaUsuario);
                SqlComando.Parameters.AddWithValue("@limite", limite);
                SqlComando.Parameters.AddWithValue("@nombrebioanalista", NombreBioanalista);
                SqlComando.Parameters.AddWithValue("@fecha1", fecha1);
                SqlComando.Parameters.AddWithValue("@fecha2", fecha2);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();



                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DOrden
                    {
                        ID = LeerFilas.GetInt32(0),
                        NombreBioanalista1 = LeerFilas.GetString(1),
                        NombreUsuario1 = LeerFilas.GetString(2),
                        NombreMedico1 = LeerFilas.GetString(3),
                        NombreTurno1 = LeerFilas.GetString(4),
                        Fecha = LeerFilas.GetDateTime(5)
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
