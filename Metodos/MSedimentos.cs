using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MSedimentos:DSedimentos
    {

        public static string Insertar(string nota)
        {
            DSedimentos Objeto = new DSedimentos();
            Objeto.Nota = nota;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nota)
        {
            DSedimentos Objeto = new DSedimentos();
            Objeto.ID = ID;
            Objeto.Nota = nota;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DSedimentos Objeto = new DSedimentos();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DSedimentos Objeto = new DSedimentos();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DSedimentos> Mostrar(string TextoBuscar)
        {
            DSedimentos Objeto = new DSedimentos();
            return Objeto.Mostrar(TextoBuscar);
        }
    }
}
