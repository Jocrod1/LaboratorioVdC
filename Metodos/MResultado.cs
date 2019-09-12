using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MResultado:DResultado
    {

        public static string Insertar(string nota)
        {
            DResultado Objeto = new DResultado();
            Objeto.Nota = nota;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nota)
        {
            DResultado Objeto = new DResultado();
            Objeto.ID = ID;
            Objeto.Nota = nota;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DResultado Objeto = new DResultado();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DResultado Objeto = new DResultado();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DResultado> Mostrar(string TextoBuscar)
        {
            DResultado Objeto = new DResultado();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
