using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDetalle_Factura:Conexion
    {

        private int _ID;

public int ID
{
  get { return _ID; }
  set { _ID = value; }
}
        private int _IDFactura;

public int IDFactura
{
  get { return _IDFactura; }
  set { _IDFactura = value; }
}
        private string _ExamenPerfil;

public string ExamenPerfil
{
  get { return _ExamenPerfil; }
  set { _ExamenPerfil = value; }
}
        private int _IDExamen;

public int IDExamen
{
  get { return _IDExamen; }
  set { _IDExamen = value; }
}
        private int _IDPerfil;

public int IDPerfil
{
  get { return _IDPerfil; }
  set { _IDPerfil = value; }
}
private int _IDDetalleOrden;

public int IDDetalleOrden
{
    get { return _IDDetalleOrden; }
    set { _IDDetalleOrden = value; }
}


        public DDetalle_Factura()
        {

        }

        public DDetalle_Factura(int iD, int iDFactura, string examenPerfil, int iDExamen, int iDPerfil, int iDDetalleOrden)
        {
            ID = iD;
            IDFactura = iDFactura;
            ExamenPerfil = examenPerfil;
            IDExamen = iDExamen;
            IDPerfil = iDPerfil;
            IDDetalleOrden = iDDetalleOrden;
        }


        //insertar
        public string Insertar(DDetalle_Factura Detalle_Factura, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "insertar_detallefactura";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle factura
                SqlParameter Parametro_Id_Detalle_Factura = new SqlParameter();
                Parametro_Id_Detalle_Factura.ParameterName = "@ID";
                Parametro_Id_Detalle_Factura.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Factura.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Factura);

                //parametro id factura
                SqlParameter Parametro_Id_Factura = new SqlParameter();
                Parametro_Id_Factura.ParameterName = "@IDFactura";
                Parametro_Id_Factura.SqlDbType = SqlDbType.Int;
                Parametro_Id_Factura.Value = Detalle_Factura.IDFactura;
                SqlComando.Parameters.Add(Parametro_Id_Factura);

                //parametro examen o perfil
                SqlParameter Parametro_ExamenPerfil = new SqlParameter();
                Parametro_ExamenPerfil.ParameterName = "@EXoPERF";
                Parametro_ExamenPerfil.SqlDbType = SqlDbType.VarChar;
                Parametro_ExamenPerfil.Size = 10;
                Parametro_ExamenPerfil.Value = Detalle_Factura.ExamenPerfil;
                SqlComando.Parameters.Add(Parametro_ExamenPerfil);

                //parametro id examen
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@IDExamen";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Detalle_Factura.IDExamen;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //parametro id perfil
                SqlParameter Parametro_Id_Perfil = new SqlParameter();
                Parametro_Id_Perfil.ParameterName = "@IDPerfil";
                Parametro_Id_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Perfil.Value = Detalle_Factura.IDPerfil;
                SqlComando.Parameters.Add(Parametro_Id_Perfil);

                //parametro id detalle orden
                SqlParameter Parametro_Id_Detalle_Orden = new SqlParameter();
                Parametro_Id_Detalle_Orden.ParameterName = "@IDDetalleOrden";
                Parametro_Id_Detalle_Orden.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Orden.Value = Detalle_Factura.IDDetalleOrden;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Orden);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el detalle de factura";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }
    }
}
