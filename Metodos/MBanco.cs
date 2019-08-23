using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MBanco: DBanco
    {

        public static string Insertar(string nombre)
        {
            DBanco Objeto = new DBanco();
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre)
        {
            DBanco Objeto = new DBanco();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DBanco Objeto = new DBanco();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DBanco Objeto = new DBanco();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DBanco> Mostrar(string TextoBuscar)
        {
            DBanco Objeto = new DBanco();
            return Objeto.Mostrar(TextoBuscar);
        }

        public new static List<DBanco> MostrarCombobox()
        {
            DBanco Objeto = new DBanco();
            return Objeto.MostrarCombobox();
        }
    }
}
