using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MLabRef:DLabRef
    {

        public static string Insertar(int ID, string nombre)
        {
            DLabRef Objeto = new DLabRef();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre)
        {
            DLabRef Objeto = new DLabRef();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DLabRef Objeto = new DLabRef();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DLabRef> Mostrar(string TextoBuscar)
        {
            DLabRef Objeto = new DLabRef();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
