using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MColoracion:DColoracion
    {

        public static string Insertar(string nota)
        {
            DColoracion Objeto = new DColoracion();
            Objeto.Nota = nota;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nota)
        {
            DColoracion Objeto = new DColoracion();
            Objeto.ID = ID;
            Objeto.Nota = nota;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DColoracion Objeto = new DColoracion();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DColoracion Objeto = new DColoracion();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DColoracion> Mostrar(string TextoBuscar)
        {
            DColoracion Objeto = new DColoracion();
            return Objeto.Mostrar(TextoBuscar);
        }

    }
}
