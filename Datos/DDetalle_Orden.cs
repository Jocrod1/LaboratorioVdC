using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDetalle_Orden:Conexion
    {

        private int _ID;

public int ID
{
  get { return _ID; }
  set { _ID = value; }
}
        private int _IDOrden;

public int IDOrden
{
  get { return _IDOrden; }
  set { _IDOrden = value; }
}
private int _IDExamen;

public int IDExamen
{
    get { return _IDExamen; }
    set { _IDExamen = value; }
}

        private string _Resultado;

        public string Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        public DDetalle_Orden()
        {

        }

        public DDetalle_Orden(int iD, int iDOrden, int iDExamen, string resultado)
        {
            ID = iD;
            IDOrden = iDOrden;
            IDExamen = iDExamen;
            Resultado = resultado;
        }


        //insertar
        public string Insertar(DDetalle_Orden Detalle_Orden, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "insertar_detalleorden";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle orden
                SqlParameter Parametro_Id_Detalle_Orden = new SqlParameter();
                Parametro_Id_Detalle_Orden.ParameterName = "@ID";
                Parametro_Id_Detalle_Orden.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Orden.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Orden);

                //parametro id orden
                SqlParameter Parametro_Id_Orden = new SqlParameter();
                Parametro_Id_Orden.ParameterName = "@IDOrden";
                Parametro_Id_Orden.SqlDbType = SqlDbType.Int;
                Parametro_Id_Orden.Value = Detalle_Orden.IDOrden;
                SqlComando.Parameters.Add(Parametro_Id_Orden);

                //parametro id examen
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@IDExamen";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Detalle_Orden.IDExamen;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el detalle de orden";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }

        public string InsertarCarga(DDetalle_Orden Detalle_Orden, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "cargar_detalleorden";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle orden
                SqlParameter Parametro_Id_Detalle_Orden = new SqlParameter();
                Parametro_Id_Detalle_Orden.ParameterName = "@ID";
                Parametro_Id_Detalle_Orden.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Orden.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Orden);

                //parametro id orden
                SqlParameter Parametro_Id_Orden = new SqlParameter();
                Parametro_Id_Orden.ParameterName = "@Resultado";
                Parametro_Id_Orden.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Orden.Size = 50;
                Parametro_Id_Orden.Value = Detalle_Orden.Resultado;
                SqlComando.Parameters.Add(Parametro_Id_Orden);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el la carga de la orden";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }
    }
}
