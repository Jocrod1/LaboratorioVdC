using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MGrupoExamen : DGrupoExamen
    {
        public static string Insertar(string nombre)
        {
            DGrupoExamen Objeto = new DGrupoExamen();
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre)
        {
            DGrupoExamen Objeto = new DGrupoExamen();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DGrupoExamen Objeto = new DGrupoExamen();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DGrupoExamen> Mostrar(string TextoBuscar)
        {
            DGrupoExamen Objeto = new DGrupoExamen();
            return Objeto.Mostrar(TextoBuscar);
        }


    }
}
