using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MMedico:DMedico
    {
        public static string Insertar(int IDMedico,string Cedula, string Nombre,string ClinicaOHospital)
        {
            DMedico Objeto = new DMedico();
            Objeto.IdMedico = IDMedico;
            Objeto.Cedula = Cedula;
            Objeto.Nombre = Nombre;
            Objeto.ClinicaOHospital = ClinicaOHospital;
            return Objeto.Insertar(Objeto);
        }

        public static string Editar(int IDMedico, string Cedula, string Nombre, string ClinicaOHospital)
        {
            DMedico Objeto = new DMedico();
            Objeto.IdMedico = IDMedico;
            Objeto.Cedula = Cedula;
            Objeto.Nombre = Nombre;
            Objeto.ClinicaOHospital = ClinicaOHospital;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int IDMedico)
        {
            DMedico Objeto = new DMedico();
            Objeto.IdMedico = IDMedico;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DMedico> Mostrar(string TextoBuscar)
        {
            DMedico Objeto = new DMedico();
            return Objeto.Mostrar(TextoBuscar);
        }

    }
}
