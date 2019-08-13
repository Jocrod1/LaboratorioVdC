using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MTipoPaciente:DTipoPaciente
    {
        public static string Insertar(int ID, string nombre, int tipo_precio, double porcentaje, string tipo_pago)
        {
            DTipoPaciente Objeto = new DTipoPaciente();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.TipoPrecio = tipo_precio;
            Objeto.Porcentaje = porcentaje;
            Objeto.TipoPago = tipo_pago;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre, int tipo_precio, double porcentaje, string tipo_pago)
        {
            DTipoPaciente Objeto = new DTipoPaciente();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.TipoPrecio = tipo_precio;
            Objeto.Porcentaje = porcentaje;
            Objeto.TipoPago = tipo_pago;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DTipoPaciente Objeto = new DTipoPaciente();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DTipoPaciente Objeto = new DTipoPaciente();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DTipoPaciente> Mostrar(string TextoBuscar)
        {
            DTipoPaciente Objeto = new DTipoPaciente();
            return Objeto.Mostrar(TextoBuscar);
        }


    }
}
