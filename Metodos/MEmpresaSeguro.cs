using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MEmpresaSeguro:DEmpresaSeguro
    {
        public static string Insertar(int ID, string nombre, double porcentaje, int tipoPrecio, string emision, string direccion, string RIF, string NIT, string contacto)
        {
            DEmpresaSeguro Objeto = new DEmpresaSeguro();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.Porcentaje = porcentaje;
            Objeto.TipoPrecio = tipoPrecio;
            Objeto.Emision = emision;
            Objeto.Direccion = direccion;
            Objeto.RIF = RIF;
            Objeto.NIT = NIT;
            Objeto.Contacto = contacto;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre, double porcentaje, int tipoPrecio, string emision, string direccion, string RIF, string NIT, string contacto)
        {
            DEmpresaSeguro Objeto = new DEmpresaSeguro();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.Porcentaje = porcentaje;
            Objeto.TipoPrecio = tipoPrecio;
            Objeto.Emision = emision;
            Objeto.Direccion = direccion;
            Objeto.RIF = RIF;
            Objeto.NIT = NIT;
            Objeto.Contacto = contacto;

            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DEmpresaSeguro Objeto = new DEmpresaSeguro();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DEmpresaSeguro> Mostrar(string TextoBuscar)
        {
            DEmpresaSeguro Objeto = new DEmpresaSeguro();
            return Objeto.Mostrar(TextoBuscar);
        }


        
        public new static List<DEmpresaSeguro> MostrarNombre(string TextoBuscar)
        {
            DEmpresaSeguro Objeto = new DEmpresaSeguro();
            return Objeto.MostrarNombre(TextoBuscar); //añadir esta wea en DEmpresaSeguro
        }
        

    }
}
