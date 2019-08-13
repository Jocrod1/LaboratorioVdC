using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MPerfil:DPerfil
    {

        public static string Insertar(string nombre, string equivalencia, double precio1, double precio2, int titulo, int labRef, int precioRef)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.Nombre = nombre;
            Objeto.Equivalencia = equivalencia;
            Objeto.Precio1 = precio1;
            Objeto.Precio2 = precio2;
            Objeto.Titulo = titulo;
            Objeto.LabRef = labRef;
            Objeto.PrecioRef = precioRef;
            return Objeto.Insertar(Objeto);
        }

        public static string Editar(int id, string nombre, string equivalencia, double precio1, double precio2, int titulo, int labRef, int precioRef)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.ID = id;
            Objeto.Nombre = nombre;
            Objeto.Equivalencia = equivalencia;
            Objeto.Precio1 = precio1;
            Objeto.Precio2 = precio2;
            Objeto.Titulo = titulo;
            Objeto.LabRef = labRef;
            Objeto.PrecioRef = precioRef;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int id)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.ID = id;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int id)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.ID = id;
            return Objeto.Anular(Objeto);
        }

        public new static List<DPerfil> Mostrar(string TextoBuscar)
        {
            DPerfil Objeto = new DPerfil();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
