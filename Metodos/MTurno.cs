using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MTurno:DTurno
    {
        public static string Insertar(string nombre, TimeSpan comienzo, TimeSpan final)
        {
            DTurno Objeto = new DTurno();
            Objeto.Nombre = nombre;
            Objeto.Comienzo = comienzo;
            Objeto.Final = final;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre, TimeSpan comienzo, TimeSpan final)
        {
            DTurno Objeto = new DTurno();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.Comienzo = comienzo;
            Objeto.Final = final;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DTurno Objeto = new DTurno();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DTurno> Mostrar(string TextoBuscar)
        {
            DTurno Objeto = new DTurno();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
