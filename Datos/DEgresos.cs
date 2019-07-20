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
        private string _Nombre;
        private string _Equivalencia;
        private double _Precio;
        private double _Precio_Empresa;
        private int _Tipo;
        private double _Cuneta_Contable;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Equivalencia { get => _Equivalencia; set => _Equivalencia = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public double Precio_Empresa { get => _Precio_Empresa; set => _Precio_Empresa = value; }
        public int Tipo { get => _Tipo; set => _Tipo = value; }
        public double Cuneta_Contable { get => _Cuneta_Contable; set => _Cuneta_Contable = value; }

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
            Cuneta_Contable = cuneta_Contable;
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
                Parametro_Cuenta_Contable.Value = Egresos.Precio_Empresa;
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
    }
}
