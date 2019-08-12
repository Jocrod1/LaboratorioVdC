using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Windows.Forms;

namespace Metodos
{
    public class MExamen: DExamen
    {
        public static string Insertar(string nombre, string unidades, double valor_Hombre, double valor_Mujer, double precio1, double precio2, DateTime plazo_entrega, string observacion, int iD_Grupo_Examen, int titulo, int lab_Referencia, int precio_Referencia)
        {
            DExamen Objeto = new DExamen();
            Objeto.Nombre = nombre;
            Objeto.Unidades = unidades;
            Objeto.Valor_Hombre = valor_Hombre;
            Objeto.Valor_Mujer = valor_Mujer;
            Objeto.Precio1 = precio1;
            Objeto.Precio2 = precio2;
            Objeto.Plazo_Entrega = plazo_entrega;
            Objeto.Observacion = observacion;
            Objeto.ID_Grupo_Examen = iD_Grupo_Examen;
            Objeto.Titulo = titulo;
            Objeto.ID_Lab_Referencia = lab_Referencia;
            Objeto.Precio_Referencia = precio_Referencia;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre, string unidades, double valor_Hombre, double valor_Mujer, double precio1, double precio2, DateTime plazo_entrega, string observacion, int iD_Grupo_Examen, int titulo, int lab_Referencia, int precio_Referencia)
        {
            DExamen Objeto = new DExamen();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.Unidades = unidades;
            Objeto.Valor_Hombre = valor_Hombre;
            Objeto.Valor_Mujer = valor_Mujer;
            Objeto.Precio1 = precio1;
            Objeto.Precio2 = precio2;
            Objeto.Plazo_Entrega = plazo_entrega;
            Objeto.Observacion = observacion;
            Objeto.ID_Grupo_Examen = iD_Grupo_Examen;
            Objeto.Titulo = titulo;
            Objeto.ID_Lab_Referencia = lab_Referencia;
            Objeto.Precio_Referencia = precio_Referencia;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DExamen Objeto = new DExamen();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DExamen Objeto = new DExamen();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DExamen> Mostrar(string TextoBuscar)
        {
            DExamen Objeto = new DExamen();
            return Objeto.Mostrar(TextoBuscar);
        }


        //grupo examen
        public new static string CaptarGrupoExamen(string nombre)
        {
            DExamen Objeto = new DExamen();
            return Objeto.CaptarGrupoExamen(nombre);
        }

        //lab ref
        public new static string CaptarLabRef(string nombre)
        {
            DExamen Objeto = new DExamen();
            return Objeto.CaptarLabRef(nombre);
        }
    }
}
