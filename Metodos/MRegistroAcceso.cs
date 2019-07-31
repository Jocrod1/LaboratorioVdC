using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MRegistroAcceso:DRegistroAcceso
    {

        public static string Insertar(int ID, string Cedula, int Turno, DateTime Fecha)
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            Objeto.ID = ID;
            Objeto.CedulaUsuario = Cedula;
            Objeto.IDTurno = Turno;
            Objeto.Fecha = Fecha;
            return Objeto.Insertar(Objeto);
        }

        public new static List<DRegistroAcceso> Mostrar(int limite, string cedula)
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            return Objeto.Mostrar(limite, cedula);
        }

        public new static List<DRegistroAcceso> MostrarFechas(int limite, string cedula, DateTime fecha1, DateTime fecha2)
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            return Objeto.MostrarFechas(limite, cedula, fecha1, fecha2);
        }

        public new static List<DRegistroAcceso> MostrarTurnos(int limite, string cedula, int turno)
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            return Objeto.MostrarTurnos(limite, cedula, turno);
        }
    }
}
