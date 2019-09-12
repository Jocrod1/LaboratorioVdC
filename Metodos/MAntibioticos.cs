using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MAntibioticos:DAntibioticos
    {

        public static string Insertar(string nombre)
        {
            DAntibioticos Objeto = new DAntibioticos();
            Objeto.Nombre = nombre;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre)
        {
            DAntibioticos Objeto = new DAntibioticos();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DAntibioticos Objeto = new DAntibioticos();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DAntibioticos Objeto = new DAntibioticos();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DAntibioticos> Mostrar(string TextoBuscar)
        {
            DAntibioticos Objeto = new DAntibioticos();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
