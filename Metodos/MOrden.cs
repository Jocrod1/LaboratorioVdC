using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Metodos
{
    public class MOrden:DOrden
    {

        public static string Insertar(int IDBioanalista, string IDUsuario, int IDMedico, int IDTurno, DateTime Fecha, DataTable DtDetalles)
        {
            DOrden Objeto = new DOrden();
            Objeto.IDBioanalista = IDBioanalista;
            Objeto.IDUsuario = IDUsuario;
            Objeto.IDMedico = IDMedico;
            Objeto.IDTurno = IDTurno;
            Objeto.Fecha = Fecha;

            List<DDetalle_Orden> Detalles = new List<DDetalle_Orden>();
            foreach (DataRow row in DtDetalles.Rows)
            {
                DDetalle_Orden Detalle = new DDetalle_Orden();

                //voy a poner que se agregue el id mientras tanto
                Detalle.ID = Convert.ToInt32(row["ID"].ToString());
                Detalle.IDOrden = Convert.ToInt32(row["IDOrden"].ToString());
                Detalle.IDExamen = Convert.ToInt32(row["IDExamen"].ToString());
            }
            return Objeto.Insertar(Objeto, Detalles);
        }


        public static string Editar(int ID, int IDBioanalista, string IDUsuario, int IDMedico, int IDTurno, DateTime Fecha)
        {
            DOrden Objeto = new DOrden();
            Objeto.ID = ID;
            Objeto.IDBioanalista = IDBioanalista;
            Objeto.IDUsuario = IDUsuario;
            Objeto.IDMedico = IDMedico;
            Objeto.IDTurno = IDTurno;
            Objeto.Fecha = Fecha;
            return Objeto.Editar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DOrden> Mostrar(string TextoBuscar, int limite)
        {
            DOrden Objeto = new DOrden();
            return Objeto.Mostrar(limite, TextoBuscar);
        }

        public new static List<DOrden> MostrarFechas(int limite, string cedulausuario, string nombrebioanalista, DateTime fecha1, DateTime fecha2)
        {
            DOrden Objeto = new DOrden();
            return Objeto.MostrarFechas(limite, cedulausuario, nombrebioanalista, fecha1, fecha2);
        }

        public static string Anular(int ID)
        {
            DOrden Objeto = new DOrden();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }
    }
}
