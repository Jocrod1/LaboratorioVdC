﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Metodos
{
    public class MUsuario : DUsuario
    {
        public static string Insertar(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, string Acceso)
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


        public static string Editar(string Cedula, string Nombre, string Contraseña, string Direccion, string Telefono, string Correo, string Acceso)
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

        public static string Anular(string Cedula)
        {
            DUsuario Objeto = new DUsuario();
            Objeto.Cedula = Cedula;
            return Objeto.Anular(Objeto);
        }

        //probar esta nueva version, NUEVA VERSION
        public new static List<DUsuario> Mostrar(string TextoBuscar)
        {
            DUsuario Objeto = new DUsuario();
            return Objeto.Mostrar(TextoBuscar);
        }

        public new static List<DUsuario> Buscar_Nombre(string TextoBuscar)
        {
            DUsuario Objeto = new DUsuario();
            return Objeto.Buscar_Nombre(TextoBuscar);
        }

        public new static List<DUsuario> CedulaUnica(string TextoBuscar)
        {
            DUsuario Objeto = new DUsuario();
            return Objeto.CedulaUnica(TextoBuscar);
        }

        public static DataTable Login(string usuario, string contraseña)
        {
            DUsuario Obj = new DUsuario();
            Obj.Cedula = usuario;
            Obj.Contraseña = contraseña;
            return Obj.Login(Obj);
        }
    }
}
