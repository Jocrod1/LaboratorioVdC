using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MBioanalista: DBioanalista
    {
        public static string Insertar(string cedula, string nombre, string colegio_bioanalista, string colegio_codigo)
        {
            DBioanalista Objeto = new DBioanalista();
            Objeto.Cedula = cedula;
            Objeto.Nombre = nombre;
            Objeto.Colegio_Bioanalista = colegio_bioanalista;
            Objeto.Colegio_Codigo = colegio_codigo;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string cedula, string nombre, string colegio_bioanalista, string colegio_codigo)
        {
            DBioanalista Objeto = new DBioanalista();
            Objeto.ID = ID;
            Objeto.Cedula = cedula;
            Objeto.Nombre = nombre;
            Objeto.Colegio_Bioanalista = colegio_bioanalista;
            Objeto.Colegio_Codigo = colegio_codigo;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DBioanalista Objeto = new DBioanalista();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DBioanalista Objeto = new DBioanalista();
            Objeto.ID = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DBioanalista> Mostrar(string TextoBuscar)
        {
            DBioanalista Objeto = new DBioanalista();
            return Objeto.Mostrar(TextoBuscar);
        }

        public new static List<DBioanalista> MostrarCedula(string TextoBuscar)
        {
            DBioanalista Objeto = new DBioanalista();
            return Objeto.MostrarCedula(TextoBuscar);
        }

        public new static List<DBioanalista> CedulaUnica(string TextoBuscar)
        {
            DBioanalista Objeto = new DBioanalista();
            return Objeto.CedulaUnica(TextoBuscar);
        }

        public new static List<DBioanalista> MostrarCombobox()
        {
            DBioanalista Objeto = new DBioanalista();
            return Objeto.MostrarCombobox();
        }
    }
}
