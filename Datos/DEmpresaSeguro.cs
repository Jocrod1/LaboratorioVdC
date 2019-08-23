using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DEmpresaSeguro : Conexion
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
        private double _Porcentaje;

        public double Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }
        private int _TipoPrecio;

        public int TipoPrecio
        {
            get { return _TipoPrecio; }
            set { _TipoPrecio = value; }
        }
        private string _Emision;

        public string Emision
        {
            get { return _Emision; }
            set { _Emision = value; }
        }
        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private string _RIF;

        public string RIF
        {
            get { return _RIF; }
            set { _RIF = value; }
        }
        private string _NIT;

        public string NIT
        {
            get { return _NIT; }
            set { _NIT = value; }
        }
        private string _Contacto;

        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }



        public DEmpresaSeguro()
        {

        }

        public DEmpresaSeguro(int iD, string nombre, double porcentaje, int tipoPrecio, string emision, string direccion, string rIF, string nIT, string contacto, string estado)
        {
            ID = iD;
            Nombre = nombre;
            Porcentaje = porcentaje;
            TipoPrecio = tipoPrecio;
            Emision = emision;
            Direccion = direccion;
            RIF = rIF;
            NIT = nIT;
            Contacto = contacto;
            Estado = estado;
        }

        //Metodos

        //insertar
        public string Insertar(DEmpresaSeguro EmpresaSeguro)
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
                SqlComando.CommandText = "insertar_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Empresa = new SqlParameter();
                Parametro_Id_Empresa.ParameterName = "@ID";
                Parametro_Id_Empresa.SqlDbType = SqlDbType.Int;
                Parametro_Id_Empresa.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Empresa);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@NombreEmpresa";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = EmpresaSeguro.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro porcentaje
                SqlParameter Parametro_Porcentaje = new SqlParameter();
                Parametro_Porcentaje.ParameterName = "@Porcentaje";
                Parametro_Porcentaje.SqlDbType = SqlDbType.Float;
                Parametro_Porcentaje.Value = EmpresaSeguro.Porcentaje;
                SqlComando.Parameters.Add(Parametro_Porcentaje);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@TipoPrecio";
                Parametro_Tipo_Precio.SqlDbType = SqlDbType.Int;
                Parametro_Tipo_Precio.Value = EmpresaSeguro.TipoPrecio;
                SqlComando.Parameters.Add(Parametro_Tipo_Precio);

                //parametro emision
                SqlParameter Parametro_Emision = new SqlParameter();
                Parametro_Emision.ParameterName = "@EmisionRel";
                Parametro_Emision.SqlDbType = SqlDbType.VarChar;
                Parametro_Emision.Size = 10;
                Parametro_Emision.Value = EmpresaSeguro.Emision;
                SqlComando.Parameters.Add(Parametro_Emision);

                //parametro direccion
                SqlParameter Parametro_Direccion = new SqlParameter();
                Parametro_Direccion.ParameterName = "@Direccion";
                Parametro_Direccion.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion.Size = 300;
                Parametro_Direccion.Value = EmpresaSeguro.Direccion;
                SqlComando.Parameters.Add(Parametro_Direccion);

                //parametro rif
                SqlParameter Parametro_RIF = new SqlParameter();
                Parametro_RIF.ParameterName = "@Rif";
                Parametro_RIF.SqlDbType = SqlDbType.VarChar;
                Parametro_RIF.Size = 20;
                Parametro_RIF.Value = EmpresaSeguro.RIF;
                SqlComando.Parameters.Add(Parametro_RIF);

                //parametro nit
                SqlParameter Parametro_NIT = new SqlParameter();
                Parametro_NIT.ParameterName = "@NIT";
                Parametro_NIT.SqlDbType = SqlDbType.VarChar;
                Parametro_NIT.Size = 10;
                Parametro_NIT.Value = EmpresaSeguro.NIT;
                SqlComando.Parameters.Add(Parametro_NIT);

                //parametro contacto
                SqlParameter Parametro_Contacto = new SqlParameter();
                Parametro_Contacto.ParameterName = "@Contacto";
                Parametro_Contacto.SqlDbType = SqlDbType.VarChar;
                Parametro_Contacto.Size = 50;
                Parametro_Contacto.Value = EmpresaSeguro.Contacto;
                SqlComando.Parameters.Add(Parametro_Contacto);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro de la empresa/seguro";

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
        public string Editar(DEmpresaSeguro EmpresaSeguro)
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
                SqlComando.CommandText = "editar_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Empresa = new SqlParameter();
                Parametro_Id_Empresa.ParameterName = "@ID";
                Parametro_Id_Empresa.SqlDbType = SqlDbType.Int;
                Parametro_Id_Empresa.Value= EmpresaSeguro.ID;
                SqlComando.Parameters.Add(Parametro_Id_Empresa);

                //parametro nombre
                SqlParameter Parametro_Nombre = new SqlParameter();
                Parametro_Nombre.ParameterName = "@NombreEmpresa";
                Parametro_Nombre.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre.Size = 50;
                Parametro_Nombre.Value = EmpresaSeguro.Nombre;
                SqlComando.Parameters.Add(Parametro_Nombre);

                //parametro porcentaje
                SqlParameter Parametro_Porcentaje = new SqlParameter();
                Parametro_Porcentaje.ParameterName = "@Porcentaje";
                Parametro_Porcentaje.SqlDbType = SqlDbType.Float;
                Parametro_Porcentaje.Value = EmpresaSeguro.Porcentaje;
                SqlComando.Parameters.Add(Parametro_Porcentaje);

                //parametro tipo precio
                SqlParameter Parametro_Tipo_Precio = new SqlParameter();
                Parametro_Tipo_Precio.ParameterName = "@TipoPrecio";
                Parametro_Tipo_Precio.SqlDbType = SqlDbType.Int;
                Parametro_Tipo_Precio.Value = EmpresaSeguro.TipoPrecio;
                SqlComando.Parameters.Add(Parametro_Tipo_Precio);

                //parametro emision
                SqlParameter Parametro_Emision = new SqlParameter();
                Parametro_Emision.ParameterName = "@EmisionRel";
                Parametro_Emision.SqlDbType = SqlDbType.VarChar;
                Parametro_Emision.Size = 10;
                Parametro_Emision.Value = EmpresaSeguro.Emision;
                SqlComando.Parameters.Add(Parametro_Emision);

                //parametro direccion
                SqlParameter Parametro_Direccion = new SqlParameter();
                Parametro_Direccion.ParameterName = "@Direccion";
                Parametro_Direccion.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion.Size = 300;
                Parametro_Direccion.Value = EmpresaSeguro.Direccion;
                SqlComando.Parameters.Add(Parametro_Direccion);

                //parametro rif
                SqlParameter Parametro_RIF = new SqlParameter();
                Parametro_RIF.ParameterName = "@Rif";
                Parametro_RIF.SqlDbType = SqlDbType.VarChar;
                Parametro_RIF.Size = 20;
                Parametro_RIF.Value = EmpresaSeguro.RIF;
                SqlComando.Parameters.Add(Parametro_RIF);

                //parametro nit
                SqlParameter Parametro_NIT = new SqlParameter();
                Parametro_NIT.ParameterName = "@NIT";
                Parametro_NIT.SqlDbType = SqlDbType.VarChar;
                Parametro_NIT.Size = 10;
                Parametro_NIT.Value = EmpresaSeguro.NIT;
                SqlComando.Parameters.Add(Parametro_NIT);

                //parametro contacto
                SqlParameter Parametro_Contacto = new SqlParameter();
                Parametro_Contacto.ParameterName = "@Contacto";
                Parametro_Contacto.SqlDbType = SqlDbType.VarChar;
                Parametro_Contacto.Size = 50;
                Parametro_Contacto.Value = EmpresaSeguro.Contacto;
                SqlComando.Parameters.Add(Parametro_Contacto);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el Registro de la empresa/seguro";

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
        public string Eliminar(DEmpresaSeguro EmpresaSeguro)
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
                SqlComando.CommandText = "eliminar_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_ID = new SqlParameter();
                Parametro_ID.ParameterName = "@ID";
                Parametro_ID.SqlDbType = SqlDbType.Int;
                Parametro_ID.Value = EmpresaSeguro.ID;
                SqlComando.Parameters.Add(Parametro_ID);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro de la empresa/seguro";

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


        public string Anular(DEmpresaSeguro EmpresaSeguro)
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
                SqlComando.CommandText = "anular_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_ID = new SqlParameter();
                Parametro_ID.ParameterName = "@ID";
                Parametro_ID.SqlDbType = SqlDbType.Int;
                Parametro_ID.Value = EmpresaSeguro.ID;
                SqlComando.Parameters.Add(Parametro_ID);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el Registro de la empresa/seguro";

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
        public List<DEmpresaSeguro> Mostrar(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("EmpresasYSeg");
            SqlConnection SqlConectar = new SqlConnection();
            List<DEmpresaSeguro> ListaGenerica = new List<DEmpresaSeguro>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_empresasyseg_Rif";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DEmpresaSeguro
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre= LeerFilas.GetString(1),
                        Porcentaje=LeerFilas.GetDouble(2),
                        TipoPrecio=LeerFilas.GetInt32(3),
                        Emision=LeerFilas.GetString(4),
                        Direccion=LeerFilas.GetString(5),
                        RIF=LeerFilas.GetString(6),
                        NIT=LeerFilas.GetString(7),
                        Contacto=LeerFilas.GetString(8),
                        Estado=LeerFilas.GetString(9)
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

        public List<DEmpresaSeguro> MostrarNombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("EmpresasYSeg");
            SqlConnection SqlConectar = new SqlConnection();
            List<DEmpresaSeguro> ListaGenerica = new List<DEmpresaSeguro>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "mostrar_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;
                //esto es cuando tiene alguna condicion
                SqlComando.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DEmpresaSeguro
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1),
                        Porcentaje = LeerFilas.GetDouble(2),
                        TipoPrecio = LeerFilas.GetInt32(3),
                        Emision = LeerFilas.GetString(4),
                        Direccion = LeerFilas.GetString(5),
                        RIF = LeerFilas.GetString(6),
                        NIT = LeerFilas.GetString(7),
                        Contacto = LeerFilas.GetString(8),
                        Estado=LeerFilas.GetString(9)
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



        public List<DEmpresaSeguro> MostrarCombobox()
        {
            DataTable DtResultado = new DataTable("EmpresasYSeg");
            SqlConnection SqlConectar = new SqlConnection();
            List<DEmpresaSeguro> ListaGenerica = new List<DEmpresaSeguro>();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlDataReader LeerFilas;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "seleccionar_empresasyseg";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlConectar.Open();

                LeerFilas = SqlComando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    ListaGenerica.Add(new DEmpresaSeguro
                    {
                        ID = LeerFilas.GetInt32(0),
                        Nombre = LeerFilas.GetString(1)
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
