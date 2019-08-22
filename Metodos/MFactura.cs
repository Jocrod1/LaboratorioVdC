using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Metodos
{
    public class MFactura:DFactura
    {

        public static string Facturar  (int IDBioanalista, string IDUsuario, int IDMedico, int IDTurno, DateTime Fecha, DataTable DtDetalleOrden, int idpaciente, int idtipopaciente, int idempresaseguro, int idorden, string tipopago, int idbanco, string numerochot,
                                        bool exonerado, string motivo, double descuento, double subtotal, double recargoemergencia, double abonar, double total,
                                        DataTable DtDetalleFactura)
        {
            //Objeto del Orden
            DOrden ObjetoOrden = new DOrden();
            ObjetoOrden.IDBioanalista = IDBioanalista;
            ObjetoOrden.IDUsuario = IDUsuario;
            ObjetoOrden.IDMedico = IDMedico;
            ObjetoOrden.IDTurno = IDTurno;
            ObjetoOrden.Fecha = Fecha;

            List<DDetalle_Orden> DetalleOrden = new List<DDetalle_Orden>();
            foreach (DataRow row in DtDetalleOrden.Rows)
            {
                DDetalle_Orden Detalle = new DDetalle_Orden();

                //voy a poner que se agregue el id mientras tanto
                //Detalle.ID = Convert.ToInt32(row["ID"].ToString());
                //Detalle.IDOrden = Convert.ToInt32(row["IDOrden"].ToString());
                Detalle.IDExamen = Convert.ToInt32(row["IDExamen"].ToString());

                DetalleOrden.Add(Detalle);
            }

            //Objeto de la Factura
            DFactura ObjetoFactura = new DFactura();
            ObjetoFactura.IDPaciente = idpaciente;
            ObjetoFactura.IDTipoPaciente = idtipopaciente;
            ObjetoFactura.IDEmpresaSeguro = idempresaseguro;
            ObjetoFactura.TipoPago = tipopago;
            ObjetoFactura.IDBanco = idbanco;
            ObjetoFactura.NumeroCHoT = numerochot;
            ObjetoFactura.Exonerado = exonerado;
            ObjetoFactura.Motivo = motivo;
            ObjetoFactura.Descuento = descuento;
            ObjetoFactura.Subtotal = subtotal;
            ObjetoFactura.RecargoEmergencia = recargoemergencia;
            ObjetoFactura.Abonar = abonar;
            ObjetoFactura.Total = total;

            List<DDetalle_Factura> DetalleFactura = new List<DDetalle_Factura>();
            foreach (DataRow row in DtDetalleFactura.Rows)
            {
                DDetalle_Factura Detalle = new DDetalle_Factura();

                //voy a poner que se agregue el id mientras tanto
                //Detalle.ID = Convert.ToInt32(row["ID"].ToString());
                //Detalle.IDFactura = Convert.ToInt32(row["IDFactura"].ToString());
                Detalle.ExamenPerfil = Convert.ToString(row["EXoPERF"].ToString());
                Detalle.IDExamen = Convert.ToInt32(row["IDExamen"].ToString());
                Detalle.IDPerfil = Convert.ToInt32(row["IDPerfil"].ToString());
                //Detalle.IDDetalleOrden = Convert.ToInt32(row["IDDetalleOrden"].ToString());

                DetalleFactura.Add(Detalle);
            }

            return ObjetoFactura.Facturar(ObjetoFactura,DetalleFactura, ObjetoOrden, DetalleOrden);
        }

        //public static string Insertar(int idpaciente, int idtipopaciente, int idempresaseguro, string tipopago, int idbanco, string numerochot, bool exonerado, string motivo, double descuento, double subtotal, double recargoemergencia, double abonar, double total, DataTable DtDetalles)
        //{
        //    DFactura Objeto = new DFactura();
        //    Objeto.IDPaciente = idpaciente;
        //    Objeto.IDTipoPaciente = idtipopaciente;
        //    Objeto.IDEmpresaSeguro = idempresaseguro;
        //    Objeto.TipoPago = tipopago;
        //    Objeto.IDBanco = idbanco;
        //    Objeto.NumeroCHoT = numerochot;
        //    Objeto.Exonerado = exonerado;
        //    Objeto.Motivo = motivo;
        //    Objeto.Descuento = descuento;
        //    Objeto.Subtotal = subtotal;
        //    Objeto.RecargoEmergencia = recargoemergencia;
        //    Objeto.Abonar = abonar;
        //    Objeto.Total = total;

        //    List<DDetalle_Factura> Detalles = new List<DDetalle_Factura>();
        //    foreach(DataRow row in DtDetalles.Rows)
        //    {
        //        DDetalle_Factura Detalle = new DDetalle_Factura();

        //        //voy a poner que se agregue el id mientras tanto
        //        //Detalle.ID = Convert.ToInt32(row["ID"].ToString());
        //        //Detalle.IDFactura = Convert.ToInt32(row["IDFactura"].ToString());
        //        Detalle.ExamenPerfil = Convert.ToString(row["EXoPERF"].ToString());
        //        Detalle.IDExamen = Convert.ToInt32(row["IDExamen"].ToString());
        //        Detalle.IDPerfil = Convert.ToInt32(row["IDPerfil"].ToString());
        //        //Detalle.IDDetalleOrden = Convert.ToInt32(row["IDDetalleOrden"].ToString());
        //    }

        //    return Objeto.Insertar(Objeto, Detalles);
        //}


        public static string Anular(int ID)
        {
            DFactura Objeto = new DFactura();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

    }
}
