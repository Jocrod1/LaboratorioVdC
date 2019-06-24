using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MPaciente:DPaciente
    {
        public static string Insertar(int ID, string Nombre, int Edad, string Cedula, string Telefono, DateTime FUR,string NumeroHabitacion, int IdMedico)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente=ID;
            Objeto.Nombre = Nombre;
            Objeto.Edad=Edad;
            Objeto.Cedula = Cedula;
            Objeto.Telefono = Telefono;
            Objeto.FUR=FUR;
            Objeto.NumeroHabitacion=NumeroHabitacion;
            Objeto.IdMedico = IdMedico;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string Nombre, int Edad, string Cedula, string Telefono, DateTime FUR, string NumeroHabitacion, int IdMedico)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente = ID;
            Objeto.Nombre = Nombre;
            Objeto.Edad = Edad;
            Objeto.Cedula = Cedula;
            Objeto.Telefono = Telefono;
            Objeto.FUR = FUR;
            Objeto.NumeroHabitacion = NumeroHabitacion;
            Objeto.IdMedico = IdMedico;
            return Objeto.Insertar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente = ID;
            return Objeto.Eliminar(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DPaciente> Mostrar(string TextoBuscar)
        {
            DPaciente Objeto = new DPaciente();
            return Objeto.Mostrar(TextoBuscar);
        }

    }
}
