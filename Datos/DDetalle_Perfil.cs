using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDetalle_Perfil:Conexion
    {

        private int _ID;
        private int _IDPerfil;
        private int _IDExamen;



        public int ID { get => _ID; set => _ID = value; }
        public int IDPerfil { get => _IDPerfil; set => _IDPerfil = value; }
        public int IDExamen { get => _IDExamen; set => _IDExamen = value; }

        public DDetalle_Perfil()
        {

        }

        public DDetalle_Perfil(int iD, int iDPerfil, int iDExamen)
        {
            ID = iD;
            IDPerfil = iDPerfil;
            IDExamen = iDExamen;
        }


        //metodos

        //insertar
        public string Insertar(DDetalle_Perfil Detalle_Perfil, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "insertar_detalleperfil";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle orden
                SqlParameter Parametro_Id_Detalle_Perfil = new SqlParameter();
                Parametro_Id_Detalle_Perfil.ParameterName = "@ID";
                Parametro_Id_Detalle_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Perfil.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Perfil);

                //parametro id perfil
                SqlParameter Parametro_Id_Perfil = new SqlParameter();
                Parametro_Id_Perfil.ParameterName = "@IDPerfil";
                Parametro_Id_Perfil.SqlDbType = SqlDbType.Int;
                Parametro_Id_Perfil.Value = Detalle_Perfil.IDPerfil;
                SqlComando.Parameters.Add(Parametro_Id_Perfil);

                //parametro id examen
                SqlParameter Parametro_Id_Examen = new SqlParameter();
                Parametro_Id_Examen.ParameterName = "@IDExamen";
                Parametro_Id_Examen.SqlDbType = SqlDbType.Int;
                Parametro_Id_Examen.Value = Detalle_Perfil.IDExamen;
                SqlComando.Parameters.Add(Parametro_Id_Examen);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el detalle de perfil";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }

    }
}
