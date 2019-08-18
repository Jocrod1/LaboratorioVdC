using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Metodos
{
    public class MPerfil:DPerfil
    {

        public static string Insertar(string nombre, double precio1, double precio2, bool titulo, int labRef, int precioRef, DataTable DtDetalles)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.Nombre = nombre;
            Objeto.Precio1 = precio1;
            Objeto.Precio2 = precio2;
            Objeto.Titulo = titulo;
            Objeto.LabRef = labRef;
            Objeto.PrecioRef = precioRef;

            List<DDetalle_Perfil> Detalles = new List<DDetalle_Perfil>();
            foreach (DataRow row in DtDetalles.Rows)
            {
                DDetalle_Perfil Detalle = new DDetalle_Perfil();

                //voy a poner que se agregue el id mientras tanto
                Detalle.IDExamen = Convert.ToInt32(row["IDExamen"].ToString());

                Detalles.Add(Detalle);
            }

            return Objeto.Insertar(Objeto, Detalles);
        }

        public static string Editar(int id, string nombre, double precio1, double precio2, bool titulo, int labRef, int precioRef)
        {
            DPerfil Objeto = new DPerfil();
            Objeto.ID = id;
            Objeto.Nombre = nombre;
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

        public static List<DDetalle_Perfil> MostrarDetalle(int TextoBuscar)
        {
            DDetalle_Perfil Objeto = new DDetalle_Perfil();
            return Objeto.MostrarDetalle(TextoBuscar);
        }
    }
}
