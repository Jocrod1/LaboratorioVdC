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
        public static string Insertar(string Nombre, DateTime FechaNacimiento, string Sexo ,string Cedula, string Telefono, DateTime FUR)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.Nombre = Nombre;
            Objeto.FechaNacimiento=FechaNacimiento;
            Objeto.Sexo = Sexo;
            Objeto.Cedula = Cedula;
            Objeto.Telefono = Telefono;
            Objeto.FUR=FUR;
            //Objeto.NumeroHabitacion=NumeroHabitacion;
            return Objeto.Insertar(Objeto);
        }


        public static string Editar(int ID, string Nombre, DateTime FechaNacimiento, string Sexo, string Cedula, string Telefono, DateTime FUR)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente = ID;
            Objeto.Nombre = Nombre;
            Objeto.FechaNacimiento = FechaNacimiento;
            Objeto.Sexo = Sexo;
            Objeto.Cedula = Cedula;
            Objeto.Telefono = Telefono;
            Objeto.FUR = FUR;
            return Objeto.Editar(Objeto);
        }

        public static string Eliminar(int ID)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente = ID;
            return Objeto.Eliminar(Objeto);
        }

        public static string Anular(int ID)
        {
            DPaciente Objeto = new DPaciente();
            Objeto.IdPaciente = ID;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DPaciente> Mostrar(string TextoBuscar)
        {
            DPaciente Objeto = new DPaciente();
            return Objeto.Mostrar(TextoBuscar);
        }

        public new static List<DPaciente> Buscar_Cedula(string TextoBuscar)
        {
            DPaciente Objeto = new DPaciente();
            return Objeto.Buscar_Cedula(TextoBuscar);
        }

        public new static List<DPaciente> CedulaUnica(string TextoBuscar)
        {
            DPaciente Objeto = new DPaciente();
            return Objeto.CedulaUnica(TextoBuscar);
        }
    }
}
