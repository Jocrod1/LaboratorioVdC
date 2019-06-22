using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;


namespace Metodos
{
    public class MTrabajador : DTrabajador
    {
        public static string Insertar(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, int Acceso)
        {
            DTrabajador Objeto = new DTrabajador();
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
            DTrabajador Objeto = new DTrabajador();
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
            DTrabajador Objeto = new DTrabajador();
            Objeto.Cedula = Cedula;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DTrabajador> Mostrar(string TextoBuscar)
        {
            DTrabajador Objeto = new DTrabajador();
            return Objeto.Mostrar(TextoBuscar);
        }


    }
}
