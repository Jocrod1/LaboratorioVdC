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

        public static string Cargar(int ID, int IDBioanalista)
        {
            DOrden Objeto = new DOrden();
            Objeto.ID = ID;
            Objeto.IDBioanalista = IDBioanalista;
            return Objeto.Cargar(Objeto);
        }

        public static string InsertarCarga(int ID, string resultado)
        {
            DDetalle_Orden Objeto = new DDetalle_Orden();
            Objeto.ID = ID;
            Objeto.Resultado = resultado;
            return Objeto.InsertarCarga(Objeto);
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

        public static List<DDetalle_Orden> MostrarDetalle(int TextoBuscar)
        {
            DDetalle_Orden Objeto = new DDetalle_Orden();
            return Objeto.MostrarDetalle(TextoBuscar);
        }

        public static string Anular(int ID)
        {
            DOrden Objeto = new DOrden();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }
    }
}
