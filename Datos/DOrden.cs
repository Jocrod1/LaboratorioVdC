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

public int ID
{
  get { return _ID; }
  set { _ID = value; }
}
        private int _IDBioanalista;

public int IDBioanalista
{
  get { return _IDBioanalista; }
  set { _IDBioanalista = value; }
}
        private string _IDUsuario;

public string IDUsuario
{
  get { return _IDUsuario; }
  set { _IDUsuario = value; }
}
        private int _IDMedico;

public int IDMedico
{
  get { return _IDMedico; }
  set { _IDMedico = value; }
}
        private int _IDTurno;

public int IDTurno
{
  get { return _IDTurno; }
  set { _IDTurno = value; }
}
        private DateTime _Fecha;

public DateTime Fecha
{
  get { return _Fecha; }
  set { _Fecha = value; }
}

        private string NombreBioanalista;

public string NombreBioanalista1
{
  get { return NombreBioanalista; }
  set { NombreBioanalista = value; }
}
        private string NombreUsuario;

public string NombreUsuario1
{
  get { return NombreUsuario; }
  set { NombreUsuario = value; }
}
        private string NombreMedico;

public string NombreMedico1
{
  get { return NombreMedico; }
  set { NombreMedico = value; }
}
private string NombreTurno;

public string NombreTurno1
{
    get { return NombreTurno; }
    set { NombreTurno = value; }
}




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
        public string Insertar(DOrden Orden, List<DDetalle_Orden> Detalle, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion, ref int IDENTITY)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
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

                if(respuesta.Equals("OK"))
                {
                    this.ID = Convert.ToInt32(SqlComando.Parameters["@ID"].Value);
                    IDENTITY = ID;

                    foreach(DDetalle_Orden det in Detalle)
                    {
                        det.IDOrden = this.ID;

                        //llamar al insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if(!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
                System.Windows.Forms.MessageBox.Show(excepcion.Message);
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


        public string Anular(DOrden Orden)
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
                SqlComando.CommandText = "anular_orden";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Medico = new SqlParameter();
                Parametro_Id_Medico.ParameterName = "@ID";
                Parametro_Id_Medico.SqlDbType = SqlDbType.Int;
                Parametro_Id_Medico.Value = Orden.ID;
                SqlComando.Parameters.Add(Parametro_Id_Medico);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro de la orden";

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

    }
}
