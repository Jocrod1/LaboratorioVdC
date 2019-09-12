using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MGermenes:DGermenes
    {

        public static string Insertar(string nombre)
        {
            DGermenes Objeto = new DGermenes();
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre)
        {
            DGermenes Objeto = new DGermenes();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DGermenes Objeto = new DGermenes();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DGermenes Objeto = new DGermenes();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DGermenes> Mostrar(string TextoBuscar)
        {
            DGermenes Objeto = new DGermenes();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
