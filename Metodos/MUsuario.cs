using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;


namespace Metodos
{
    public class MUsuario : DUsuario
    {
        public static string Insertar(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, int Acceso)
        {
            DUsuario Objeto = new DUsuario();
            Objeto.Cedula = Cedula;
            Objeto.Nombre = Nombre;
            Objeto.Contraseña = Contraseña;
            Objeto.Direccion = Direccion;
            Objeto.Telefono = Telefono;
            Objeto.Correo = Correo;
            Objeto.Acceso = Acceso;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, int Acceso)
        {
            DUsuario Objeto = new DUsuario();
            Objeto.Cedula = Cedula;
            Objeto.Nombre = Nombre;
            Objeto.Contraseña = Contraseña;
            Objeto.Direccion = Direccion;
            Objeto.Telefono = Telefono;
            Objeto.Correo = Correo;
            Objeto.Acceso = Acceso;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(string Cedula)
        {
            DUsuario Objeto = new DUsuario();
            Objeto.Cedula = Cedula;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DUsuario> Mostrar(string TextoBuscar)
        {
            DUsuario Objeto = new DUsuario();
            return Objeto.Mostrar(TextoBuscar);
        }


    }
}
