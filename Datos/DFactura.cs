using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DFactura:Conexion
    {

        private int _ID;
        private int _IDPaciente;
        private int _IDTipoPaciente;
        private int _IDEmpresaSeguro;
        private int _IDOrden;
        private int _TipoPago;
        private int _IDBanco;
        private string _NumeroCHoT;
        private string _Exonerado;
        private string _Motivo;
        private double _Descuento;
        private double _Subtotal;
        private double _RecargoEmergencia;
        private double _Abonar;
        private double _Total;

        public int ID { get => _ID; set => _ID = value; }
        public int IDPaciente { get => _IDPaciente; set => _IDPaciente = value; }
        public int IDTipoPaciente { get => _IDTipoPaciente; set => _IDTipoPaciente = value; }
        public int IDEmpresaSeguro { get => _IDEmpresaSeguro; set => _IDEmpresaSeguro = value; }
        public int IDOrden { get => _IDOrden; set => _IDOrden = value; }
        public int TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public int IDBanco { get => _IDBanco; set => _IDBanco = value; }
        public string NumeroCHoT { get => _NumeroCHoT; set => _NumeroCHoT = value; }
        public string Exonerado { get => _Exonerado; set => _Exonerado = value; }
        public string Motivo { get => _Motivo; set => _Motivo = value; }
        public double Descuento { get => _Descuento; set => _Descuento = value; }
        public double Subtotal { get => _Subtotal; set => _Subtotal = value; }
        public double RecargoEmergencia { get => _RecargoEmergencia; set => _RecargoEmergencia = value; }
        public double Abonar { get => _Abonar; set => _Abonar = value; }
        public double Total { get => _Total; set => _Total = value; }

        public DFactura()
        {

        }

        public DFactura(int iD, int iDPaciente, int iDTipoPaciente, int iDEmpresaSeguro, int iDOrden, int tipoPago, int iDBanco, string numeroCHoT, string exonerado, string motivo, double descuento, double subtotal, double recargoEmergencia, double abonar, double total)
        {
            ID = iD;
            IDPaciente = iDPaciente;
            IDTipoPaciente = iDTipoPaciente;
            IDEmpresaSeguro = iDEmpresaSeguro;
            IDOrden = iDOrden;
            TipoPago = tipoPago;
            IDBanco = iDBanco;
            NumeroCHoT = numeroCHoT;
            Exonerado = exonerado;
            Motivo = motivo;
            Descuento = descuento;
            Subtotal = subtotal;
            RecargoEmergencia = recargoEmergencia;
            Abonar = abonar;
            Total = total;
        }


        //metodos
        //insertar
        public string Insertar(DFactura Factura, List<DDetalle_Factura> Detalle)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //transaccion
                SqlTransaction SqlTransaccion = SqlConectar.BeginTransaction();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "insertar_factura";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Factura = new SqlParameter();
                Parametro_Id_Factura.ParameterName = "@ID";
                Parametro_Id_Factura.SqlDbType = SqlDbType.Int;
                Parametro_Id_Factura.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Factura);

                //parametro paciente
                SqlParameter Parametro_ID_Paciente = new SqlParameter();
                Parametro_ID_Paciente.ParameterName = "@IDPaciente";
                Parametro_ID_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_ID_Paciente.Value = Factura.IDPaciente;
                SqlComando.Parameters.Add(Parametro_ID_Paciente);

                //parametro id tipo paciente
                SqlParameter Parametro_ID_Tipo_Paciente = new SqlParameter();
                Parametro_ID_Tipo_Paciente.ParameterName = "@IDTipoPaciente";
                Parametro_ID_Tipo_Paciente.SqlDbType = SqlDbType.Int;
                Parametro_ID_Tipo_Paciente.Value = Factura.IDTipoPaciente;
                SqlComando.Parameters.Add(Parametro_ID_Tipo_Paciente);

                //parametro id empresa seguro
                SqlParameter Parametro_ID_EmpresaSeguro = new SqlParameter();
                Parametro_ID_EmpresaSeguro.ParameterName = "@IDEmpresasySeg";
                Parametro_ID_EmpresaSeguro.SqlDbType = SqlDbType.Int;
                Parametro_ID_EmpresaSeguro.Value = Factura.IDEmpresaSeguro;
                SqlComando.Parameters.Add(Parametro_ID_EmpresaSeguro);

                //parametro id orden
                SqlParameter Parametro_ID_Orden = new SqlParameter();
                Parametro_ID_Orden.ParameterName = "@IDOrden";
                Parametro_ID_Orden.SqlDbType = SqlDbType.Int;
                Parametro_ID_Orden.Value = Factura.IDOrden;
                SqlComando.Parameters.Add(Parametro_ID_Orden);

                //parametro tipo pago
                SqlParameter Parametro_Tipo_Pago = new SqlParameter();
                Parametro_Tipo_Pago.ParameterName = "@TipoDePago";
                Parametro_Tipo_Pago.SqlDbType = SqlDbType.Int;
                Parametro_Tipo_Pago.Value = Factura.TipoPago;
                SqlComando.Parameters.Add(Parametro_Tipo_Pago);

                //parametro id banco
                SqlParameter Parametro_ID_Banco = new SqlParameter();
                Parametro_ID_Banco.ParameterName = "@IDBanco";
                Parametro_ID_Banco.SqlDbType = SqlDbType.Int;
                Parametro_ID_Banco.Value = Factura.IDBanco;
                SqlComando.Parameters.Add(Parametro_ID_Banco);

                //parametro Numero cheque o tarjeta
                SqlParameter Parametro_Cheque_Tarjeta = new SqlParameter();
                Parametro_Cheque_Tarjeta.ParameterName = "@NumoCHoT";
                Parametro_Cheque_Tarjeta.SqlDbType = SqlDbType.VarChar;
                Parametro_Cheque_Tarjeta.Size = 50;
                Parametro_Cheque_Tarjeta.Value = Factura.NumeroCHoT;
                SqlComando.Parameters.Add(Parametro_Cheque_Tarjeta);

                //parametro Exonerado
                SqlParameter Parametro_Exonerado = new SqlParameter();
                Parametro_Exonerado.ParameterName = "@Exonerado";
                Parametro_Exonerado.SqlDbType = SqlDbType.VarChar;
                Parametro_Exonerado.Size = 10;
                Parametro_Exonerado.Value = Factura.Exonerado;
                SqlComando.Parameters.Add(Parametro_Exonerado);

                //parametro Motivo
                SqlParameter Parametro_Motivo = new SqlParameter();
                Parametro_Motivo.ParameterName = "@Motivo";
                Parametro_Motivo.SqlDbType = SqlDbType.VarChar;
                Parametro_Motivo.Size = 300;
                Parametro_Motivo.Value = Factura.Motivo;
                SqlComando.Parameters.Add(Parametro_Motivo);

                //parametro descuento
                SqlParameter Parametro_Descuento = new SqlParameter();
                Parametro_Descuento.ParameterName = "@Descuento";
                Parametro_Descuento.SqlDbType = SqlDbType.Float;
                Parametro_Descuento.Value = Factura.Descuento;
                SqlComando.Parameters.Add(Parametro_Descuento);

                //parametro subtotal
                SqlParameter Parametro_Subtotal = new SqlParameter();
                Parametro_Subtotal.ParameterName = "@Subtotal";
                Parametro_Subtotal.SqlDbType = SqlDbType.Float;
                Parametro_Subtotal.Value = Factura.Subtotal;
                SqlComando.Parameters.Add(Parametro_Subtotal);

                //parametro recargo emergencia
                SqlParameter Parametro_RecargoEmergencia = new SqlParameter();
                Parametro_RecargoEmergencia.ParameterName = "@RecargoEmergencia";
                Parametro_RecargoEmergencia.SqlDbType = SqlDbType.Float;
                Parametro_RecargoEmergencia.Value = Factura.RecargoEmergencia;
                SqlComando.Parameters.Add(Parametro_RecargoEmergencia);

                //parametro abonar
                SqlParameter Parametro_Abonar = new SqlParameter();
                Parametro_Abonar.ParameterName = "@Abonar";
                Parametro_Abonar.SqlDbType = SqlDbType.Float;
                Parametro_Abonar.Value = Factura.Abonar;
                SqlComando.Parameters.Add(Parametro_Abonar);

                //parametro subtotal
                SqlParameter Parametro_Total = new SqlParameter();
                Parametro_Total.ParameterName = "@Total";
                Parametro_Total.SqlDbType = SqlDbType.Float;
                Parametro_Total.Value = Factura.Total;
                SqlComando.Parameters.Add(Parametro_Total);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro de la factura";

                if(respuesta.Equals("OK"))
                {
                    this.ID = Convert.ToInt32(SqlComando.Parameters["ID"].Value);

                    foreach(DDetalle_Factura det in Detalle)
                    {
                        det.ID = this.ID;

                        //llamar a insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if(!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if(respuesta.Equals("OK"))
                {
                    SqlTransaccion.Commit();
                }
                else
                {
                    //si recibe una respuesta contraria se niega la transaccion
                    SqlTransaccion.Rollback();
                }

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
        public string Anular(DFactura Factura)
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
                SqlComando.CommandText = "anular_factura";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Factura = new SqlParameter();
                Parametro_Id_Factura.ParameterName = "@ID";
                Parametro_Id_Factura.SqlDbType = SqlDbType.Int;
                Parametro_Id_Factura.Value = Factura.ID;
                SqlComando.Parameters.Add(Parametro_Id_Factura);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo la factura";

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
