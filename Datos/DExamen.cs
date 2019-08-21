using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Datos
{
    public class DExamen : Conexion
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
        private string _Unidades;

        public string Unidades
        {
            get { return _Unidades; }
            set { _Unidades = value; }
        }
        private double _Valor_Hombre;

        public double Valor_Hombre
        {
            get { return _Valor_Hombre; }
            set { _Valor_Hombre = value; }
        }
        private double _Valor_Mujer;

        public double Valor_Mujer
        {
            get { return _Valor_Mujer; }
            set { _Valor_Mujer = value; }
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
        private DateTime _Plazo_Entrega;

        public DateTime Plazo_Entrega
        {
            get { return _Plazo_Entrega; }
            set { _Plazo_Entrega = value; }
        }
        private string _Observacion;

        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        private int _ID_Grupo_Examen;

        public int ID_Grupo_Examen
        {
            get { return _ID_Grupo_Examen; }
            set { _ID_Grupo_Examen = value; }
        }
        private bool _Titulo;

        public bool Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        private int _ID_Lab_Referencia;

        public int ID_Lab_Referencia
        {
            get { return _ID_Lab_Referencia; }
            set { _ID_Lab_Referencia = value; }
        }
        private double _Precio_Referencia;

        public double Precio_Referencia
        {
            get { return _Precio_Referencia; }
            set { _Precio_Referencia = value; }
        }


        private string _GrupoExamen;

        public string GrupoExamen
        {
            get { return _GrupoExamen; }
            set { _GrupoExamen = value; }
        }

        private string _LabRef;

        public string LabRef
        {
            get { return _LabRef; }
            set { _LabRef = value; }
        }


        public DExamen()
        {

        }

        public DExamen(int iD, string nombre, string unidades, float valor_Hombre, float valor_Mujer, float precio1, float precio2, DateTime plazo_entrega, string observacion, int iD_Grupo_Examen, bool titulo, int lab_Referencia, double precio_Referencia, string grupo_examen, string labref)
        {
            ID = iD;
            Nombre = nombre;
            Unidades = unidades;
            Valor_Hombre = valor_Hombre;
            Valor_Mujer = valor_Mujer;
            Precio1 = precio1;
            Precio2 = precio2;
            Plazo_Entrega = plazo_entrega;
            Observacion = observacion;
            ID_Grupo_Examen = iD_Grupo_Examen;
            Titulo = titulo;
            ID_Lab_Referencia = lab_Referencia;
            Precio_Referencia = precio_Referencia;
            GrupoExamen = grupo_examen;
            LabRef = labref;
        }

        //Metodos

        //insertar
        public string Insertar(DExamen Examen)
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
                SqlComando.CommandText = "insertar_examen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@ID";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //parametro nombre
                SqlParameter Parametro_Nombre_Examen = new SqlParameter();
                Parametro_Nombre_Examen.ParameterName = "@nombre";
                Parametro_Nombre_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Examen.Size = 20;
                Parametro_Nombre_Examen.Value = Examen.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Examen);

                //parametro unidades
                SqlParameter Parametro_Unidad_Examen = new SqlParameter();
                Parametro_Unidad_Examen.ParameterName = "@Unidades";
                Parametro_Unidad_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Unidad_Examen.Size = 20;
                Parametro_Unidad_Examen.Value = Examen.Unidades;
                SqlComando.Parameters.Add(Parametro_Unidad_Examen);

                //parametro valor normal hombre
                SqlParameter Parametro_Valor_Hombre = new SqlParameter();
                Parametro_Valor_Hombre.ParameterName = "@ValNorHombres";
                Parametro_Valor_Hombre.SqlDbType = SqlDbType.Float;
                Parametro_Valor_Hombre.Value = Examen.Valor_Hombre;
                SqlComando.Parameters.Add(Parametro_Valor_Hombre);

                //parametro valor normal mujer
                SqlParameter Parametro_Valor_Mujer = new SqlParameter();
                Parametro_Valor_Mujer.ParameterName = "@ValNorMujeres";
                Parametro_Valor_Mujer.SqlDbType = SqlDbType.Float;
                Parametro_Valor_Mujer.Value = Examen.Valor_Mujer;
                SqlComando.Parameters.Add(Parametro_Valor_Mujer);

                //parametro precio 1
                SqlParameter Parametro_Precio_1 = new SqlParameter();
                Parametro_Precio_1.ParameterName = "@Precio1";
                Parametro_Precio_1.SqlDbType = SqlDbType.Float;
                Parametro_Precio_1.Value = Examen.Precio1;
                SqlComando.Parameters.Add(Parametro_Precio_1);

                //parametro precio 2
                SqlParameter Parametro_Precio_2 = new SqlParameter();
                Parametro_Precio_2.ParameterName = "@Precio2";
                Parametro_Precio_2.SqlDbType = SqlDbType.Float;
                Parametro_Precio_2.Value = Examen.Precio2;
                SqlComando.Parameters.Add(Parametro_Precio_2);

                //parametro plazo de entrega
                SqlParameter Parametro_Plazo_Entrega = new SqlParameter();
                Parametro_Plazo_Entrega.ParameterName = "@PlazoEntrega";
                Parametro_Plazo_Entrega.SqlDbType = SqlDbType.DateTime;
                Parametro_Plazo_Entrega.Value = Examen.Plazo_Entrega;
                SqlComando.Parameters.Add(Parametro_Plazo_Entrega);

                //parametro Observacion
                SqlParameter Parametro_Observacion = new SqlParameter();
                Parametro_Observacion.ParameterName = "@Observaciones";
                Parametro_Observacion.SqlDbType = SqlDbType.VarChar;
                Parametro_Observacion.Size = 150;
                Parametro_Observacion.Value = Examen.Observacion;
                SqlComando.Parameters.Add(Parametro_Observacion);

                //parametro ID grupo examen
                SqlParameter Parametro_ID_Grupo_Examen = new SqlParameter();
                Parametro_ID_Grupo_Examen.ParameterName = "@IDGrupoExamen";
                Parametro_ID_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_ID_Grupo_Examen.Value = Examen.ID_Grupo_Examen;
                SqlComando.Parameters.Add(Parametro_ID_Grupo_Examen);

                //parametro titulo
                SqlParameter Parametro_Titulo = new SqlParameter();
                Parametro_Titulo.ParameterName = "@Titulo";
                Parametro_Titulo.SqlDbType = SqlDbType.Int;
                Parametro_Titulo.Value = Examen.Titulo;
                SqlComando.Parameters.Add(Parametro_Titulo);

                //parametro lab referencia
                SqlParameter Parametro_Lab_Referencia = new SqlParameter();
                Parametro_Lab_Referencia.ParameterName = "@IDLabRef";
                Parametro_Lab_Referencia.SqlDbType = SqlDbType.Int;
                Parametro_Lab_Referencia.Value = Examen.ID_Lab_Referencia;
                SqlComando.Parameters.Add(Parametro_Lab_Referencia);

                //parametro precio referencia
                SqlParameter Parametro_Precio_Referencia = new SqlParameter();
                Parametro_Precio_Referencia.ParameterName = "@PrecioRef";
                Parametro_Precio_Referencia.SqlDbType = SqlDbType.Float;
                Parametro_Precio_Referencia.Value = Examen.Precio_Referencia;
                SqlComando.Parameters.Add(Parametro_Precio_Referencia);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Examen";

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
        public string Editar(DExamen Examen)
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
                SqlComando.CommandText = "editar_examen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@ID";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value= Examen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //parametro nombre
                SqlParameter Parametro_Nombre_Examen = new SqlParameter();
                Parametro_Nombre_Examen.ParameterName = "@nombre";
                Parametro_Nombre_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Examen.Size = 20;
                Parametro_Nombre_Examen.Value = Examen.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre_Examen);

                //parametro unidades
                SqlParameter Parametro_Unidad_Examen = new SqlParameter();
                Parametro_Unidad_Examen.ParameterName = "@Unidades";
                Parametro_Unidad_Examen.SqlDbType = SqlDbType.VarChar;
                Parametro_Unidad_Examen.Size = 20;
                Parametro_Unidad_Examen.Value = Examen.Unidades;
                SqlComando.Parameters.Add(Parametro_Unidad_Examen);

                //parametro valor normal hombre
                SqlParameter Parametro_Valor_Hombre = new SqlParameter();
                Parametro_Valor_Hombre.ParameterName = "@ValNorHombres";
                Parametro_Valor_Hombre.SqlDbType = SqlDbType.Float;
                Parametro_Valor_Hombre.Value = Examen.Valor_Hombre;
                SqlComando.Parameters.Add(Parametro_Valor_Hombre);

                //parametro valor normal mujer
                SqlParameter Parametro_Valor_Mujer = new SqlParameter();
                Parametro_Valor_Mujer.ParameterName = "@ValNorMujeres";
                Parametro_Valor_Mujer.SqlDbType = SqlDbType.Float;
                Parametro_Valor_Mujer.Value = Examen.Valor_Mujer;
                SqlComando.Parameters.Add(Parametro_Valor_Mujer);

                //parametro precio 1
                SqlParameter Parametro_Precio_1 = new SqlParameter();
                Parametro_Precio_1.ParameterName = "@Precio1";
                Parametro_Precio_1.SqlDbType = SqlDbType.Float;
                Parametro_Precio_1.Value = Examen.Precio1;
                SqlComando.Parameters.Add(Parametro_Precio_1);

                //parametro precio 2
                SqlParameter Parametro_Precio_2 = new SqlParameter();
                Parametro_Precio_2.ParameterName = "@Precio2";
                Parametro_Precio_2.SqlDbType = SqlDbType.Float;
                Parametro_Precio_2.Value = Examen.Precio2;
                SqlComando.Parameters.Add(Parametro_Precio_2);

                //parametro plazo de entrega
                SqlParameter Parametro_Plazo_Entrega = new SqlParameter();
                Parametro_Plazo_Entrega.ParameterName = "@PlazoEntrega";
                Parametro_Plazo_Entrega.SqlDbType = SqlDbType.DateTime;
                Parametro_Plazo_Entrega.Value = Examen.Plazo_Entrega;
                SqlComando.Parameters.Add(Parametro_Plazo_Entrega);

                //parametro Observacion
                SqlParameter Parametro_Observacion = new SqlParameter();
                Parametro_Observacion.ParameterName = "@Observaciones";
                Parametro_Observacion.SqlDbType = SqlDbType.VarChar;
                Parametro_Observacion.Size = 150;
                Parametro_Observacion.Value = Examen.Observacion;
                SqlComando.Parameters.Add(Parametro_Observacion);

                //parametro ID grupo examen
                SqlParameter Parametro_ID_Grupo_Examen = new SqlParameter();
                Parametro_ID_Grupo_Examen.ParameterName = "@IDGrupoExamen";
                Parametro_ID_Grupo_Examen.SqlDbType = SqlDbType.Int;
                Parametro_ID_Grupo_Examen.Value = Examen.ID_Grupo_Examen;
                SqlComando.Parameters.Add(Parametro_ID_Grupo_Examen);

                //parametro titulo
                SqlParameter Parametro_Titulo = new SqlParameter();
                Parametro_Titulo.ParameterName = "@Titulo";
                Parametro_Titulo.SqlDbType = SqlDbType.Int;
                Parametro_Titulo.Value = Examen.Titulo;
                SqlComando.Parameters.Add(Parametro_Titulo);

                //parametro lab referencia
                SqlParameter Parametro_Lab_Referencia = new SqlParameter();
                Parametro_Lab_Referencia.ParameterName = "@LabRef";
                Parametro_Lab_Referencia.SqlDbType = SqlDbType.Int;
                Parametro_Lab_Referencia.Value = Examen.ID_Lab_Referencia;
                SqlComando.Parameters.Add(Parametro_Lab_Referencia);

                //parametro precio referencia
                SqlParameter Parametro_Precio_Referencia = new SqlParameter();
                Parametro_Precio_Referencia.ParameterName = "@PrecioRef";
                Parametro_Precio_Referencia.SqlDbType = SqlDbType.Float;
                Parametro_Precio_Referencia.Value = Examen.Precio_Referencia;
                SqlComando.Parameters.Add(Parametro_Precio_Referencia);

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
        public string Eliminar(DExamen Examen)
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
                SqlComando.CommandText = "eliminar_examen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@ID";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Examen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del examen";

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


        public string Anular(DExamen Examen)
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
                SqlComando.CommandText = "anular_examen";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@ID";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Examen.ID;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el Registro del examen";

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
        public List<DExamen> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Examen");
            SqlConnection SqlConectar = new SqlConnection();
            List<DExamen> ListaGenerica = new List<DExamen>();
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_examen";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

               

                while (LeerFilas.Read())
                {
                int ID_ = LeerFilas.GetInt32(0);
                string Nombre_ = LeerFilas.GetString(1);
                string Unidades_ = LeerFilas.GetString(2);
                double ValorHombre_ = LeerFilas.GetDouble(3);
                double ValorMujer_ = LeerFilas.GetDouble(4);
                double Precio1_ = LeerFilas.GetDouble(5);
                double Precio2_ = LeerFilas.GetDouble(6);
                DateTime PlazoEntrega_ = LeerFilas.GetDateTime(7);
                string Observacion_ = LeerFilas.GetString(8);
                string Grupo_Examen_ = LeerFilas.GetString(9);
                bool Titulo_ = LeerFilas.GetBoolean(10);
                string Lab_Referencia_ = LeerFilas.GetString(11);
                double PrecioRef_ = LeerFilas.GetDouble(12);
                int IDGrupoExamen = LeerFilas.GetInt32(13);
                int IDLabRef = LeerFilas.GetInt32(14);

                ListaGenerica.Add(new DExamen
                {
                    ID = ID_,
                    Nombre = Nombre_,
                    Unidades = Unidades_,
                    Valor_Hombre = ValorHombre_,
                    Valor_Mujer = ValorMujer_,
                    Precio1 = Precio1_,
                    Precio2 = Precio2_,
                    Plazo_Entrega=PlazoEntrega_,
                    Observacion=Observacion_,
                    GrupoExamen = Grupo_Examen_,
                    Titulo=Titulo_,
                    LabRef = Lab_Referencia_,
                    Precio_Referencia=PrecioRef_,
                    ID_Grupo_Examen=IDGrupoExamen,
                    ID_Lab_Referencia=IDLabRef

                });

            }
                LeerFilas.Close();
                SqlConectar.Close();
           

            return ListaGenerica;

        }

        
    }
}
