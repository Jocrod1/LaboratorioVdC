using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Metodos
{
    public class MRegistroAcceso: DRegistroAcceso
    {

        public static string Insertar(int ID, string cedula, int turno, DateTime fecha)
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            Objeto.ID = ID;
            Objeto.CedulaUsuario = cedula;
            Objeto.IDTurno = turno;
            Objeto.Fecha = fecha;
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

        //turno
        public new static string CaptarTurno()
        {
            DRegistroAcceso Objeto = new DRegistroAcceso();
            return Objeto.CaptarTurno();
        }
    }
}
