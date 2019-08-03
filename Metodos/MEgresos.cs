using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MEgresos:DEgresos
    {

        public static string Insertar(string nombre, string equivalencia, float precio, float precio_empresa, int tipo, float cuenta_contable)
        {
            DEgresos Objeto = new DEgresos();
            Objeto.Nombre = nombre;
            Objeto.Equivalencia = equivalencia;
            Objeto.Precio = precio;
            Objeto.Precio_Empresa = precio_empresa;
            Objeto.Tipo = tipo;
            Objeto.Cuenta_Contable = cuenta_contable;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string nombre, string equivalencia, float precio, float precio_empresa, int tipo, float cuenta_contable)
        {
            DEgresos Objeto = new DEgresos();
            Objeto.ID = ID;
            Objeto.Nombre = nombre;
            Objeto.Equivalencia = equivalencia;
            Objeto.Precio = precio;
            Objeto.Precio_Empresa = precio_empresa;
            Objeto.Tipo = tipo;
            Objeto.Cuenta_Contable = cuenta_contable;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DEgresos Objeto = new DEgresos();
            Objeto.ID = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DEgresos> Mostrar(string TextoBuscar)
        {
            DEgresos Objeto = new DEgresos();
            return Objeto.Mostrar(TextoBuscar);
        }

    }
}
