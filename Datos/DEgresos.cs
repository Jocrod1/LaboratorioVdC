using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DEgresos:Conexion
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
        private string _Equivalencia;

        public string Equivalencia
        {
            get { return _Equivalencia; }
            set { _Equivalencia = value; }
        }
        private double _Precio;

        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        private double _Precio_Empresa;

        public double Precio_Empresa
        {
            get { return _Precio_Empresa; }
            set { _Precio_Empresa = value; }
        }
        private int _Tipo;

        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        private double _Cuenta_Contable;

        public double Cuenta_Contable
        {
            get { return _Cuenta_Contable; }
            set { _Cuenta_Contable = value; }
        }


        public DEgresos()
        {

        }

        public DEgresos(int iD, string nombre, string equivalencia, double precio, double precio_Empresa, int tipo, double cuneta_Contable)
        {
            ID = iD;
            Nombre = nombre;
            Equivalencia = equivalencia;
            Precio = precio;
            Precio_Empresa = precio_Empresa;
            Tipo = tipo;
            Cuenta_Contable = cuneta_Contable;
        }

        //Metodos

        //insertar
        public string Insertar(DEgresos Egresos)
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
                SqlComando.CommandText = "insertar_egreso";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Egreso = new SqlParameter();
                Parametro_Id_Egreso.ParameterName = "@ID";
                Parametro_Id_Egreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Egreso.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Egreso);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Egresos.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 10;
                Parametro_Equivalencia.Value = Egresos.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro precio
                SqlParameter Parametro_Precio = new SqlParameter();
                Parametro_Precio.ParameterName = "@precio";
                Parametro_Precio.SqlDbType = SqlDbType.Float;
                Parametro_Precio.Value = Egresos.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Precio);

                //parametro precio empresa
                SqlParameter Parametro_Precio_Empresa = new SqlParameter();
                Parametro_Precio_Empresa.ParameterName = "@precio_empresa";
                Parametro_Precio_Empresa.SqlDbType = SqlDbType.Float;
                Parametro_Precio_Empresa.Value = Egresos.Precio_Empresa;
                SqlComando.Parameters.Add(Parametro_Precio_Empresa);

                //parametro tipo
                SqlParameter Parametro_Tipo = new SqlParameter();
                Parametro_Tipo.ParameterName = "@tipo";
                Parametro_Tipo.SqlDbType = SqlDbType.Int;
                Parametro_Tipo.Value = Egresos.Tipo;
                SqlComando.Parameters.Add(Parametro_Tipo);

                //parametro cuenta contable
                SqlParameter Parametro_Cuenta_Contable = new SqlParameter();
                Parametro_Cuenta_Contable.ParameterName = "@cuenta_contable";
                Parametro_Cuenta_Contable.SqlDbType = SqlDbType.Float;
                Parametro_Cuenta_Contable.Value = Egresos.Cuenta_Contable;
                SqlComando.Parameters.Add(Parametro_Cuenta_Contable);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Banco";

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
        public string Editar(DEgresos Egresos)
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
                SqlComando.CommandText = "editar_egresos";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Egreso = new SqlParameter();
                Parametro_Id_Egreso.ParameterName = "@ID";
                Parametro_Id_Egreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Egreso.Value = Egresos.ID;
                SqlComando.Parameters.Add(Parametro_Id_Egreso);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@nombre";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = Egresos.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro equivalencia
                SqlParameter Parametro_Equivalencia = new SqlParameter();
                Parametro_Equivalencia.ParameterName = "@equivalencia";
                Parametro_Equivalencia.SqlDbType = SqlDbType.VarChar;
                Parametro_Equivalencia.Size = 10;
                Parametro_Equivalencia.Value = Egresos.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Equivalencia);

                //parametro precio
                SqlParameter Parametro_Precio = new SqlParameter();
                Parametro_Precio.ParameterName = "@precio";
                Parametro_Precio.SqlDbType = SqlDbType.Float;
                Parametro_Precio.Value = Egresos.Equivalencia;
                SqlComando.Parameters.Add(Parametro_Precio);

                //parametro precio empresa
                SqlParameter Parametro_Precio_Empresa = new SqlParameter();
                Parametro_Precio_Empresa.ParameterName = "@precio_empresa";
                Parametro_Precio_Empresa.SqlDbType = SqlDbType.Float;
                Parametro_Precio_Empresa.Value = Egresos.Precio_Empresa;
                SqlComando.Parameters.Add(Parametro_Precio_Empresa);

                //parametro tipo
                SqlParameter Parametro_Tipo = new SqlParameter();
                Parametro_Tipo.ParameterName = "@tipo";
                Parametro_Tipo.SqlDbType = SqlDbType.Int;
                Parametro_Tipo.Value = Egresos.Tipo;
                SqlComando.Parameters.Add(Parametro_Tipo);

                //parametro cuenta contable
                SqlParameter Parametro_Cuenta_Contable = new SqlParameter();
                Parametro_Cuenta_Contable.ParameterName = "@cuenta_contable";
                Parametro_Cuenta_Contable.SqlDbType = SqlDbType.Float;
                Parametro_Cuenta_Contable.Value = Egresos.Cuenta_Contable;
                SqlComando.Parameters.Add(Parametro_Cuenta_Contable);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro del Egreso";

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
        public string Eliminar(DEgresos Egresos)
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
                SqlComando.CommandText = "eliminar_egresos";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id = new SqlParameter();
                Parametro_Id.ParameterName = "@ID";
                Parametro_Id.SqlDbType = SqlDbType.Int;
                Parametro_Id.Value = Egresos.ID;
                SqlComando.Parameters.Add(Parametro_Id);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro del egreso";

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
        public List<DEgresos> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Egresos");
            SqlConnection SqlConectar = new SqlConnection();
            List<DEgresos> ListaGenerica = new List<DEgresos>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_egresos";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DEgresos
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        Equivalencia = LeerFilas.GetString(2),
                        Precio = LeerFilas.GetFloat(3),
                        Precio_Empresa = LeerFilas.GetFloat(4),
                        Tipo = LeerFilas.GetInt32(5),
                        Cuenta_Contable = LeerFilas.GetFloat(6),
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

