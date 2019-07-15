using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Examenes : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        public Examenes()
        {
            InitializeComponent();
        }

        private void Examenes_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Validación de campos
        private bool verificacion()
        {
            bool error = true;
            if (txtEquivalencia.Text == "")
            {
                error = false;
                error1.SetError(txtEquivalencia, "No dejes este campo vacío");
            }
            if (txtUnidades.Text == "")
            {
                error = false;
                error2.SetError(txtUnidades, "Llena este campo");
            }
             if (txtValNorHombres.Text == "")
            {
                error = false;
                error3.SetError(txtValNorHombres, "Valores normales de hombres");
            }
             if (txtValNorMujeres.Text == "")
            {
                error = false;
                error4.SetError(txtValNorMujeres, "Valores normales de mujeres");
            }
             if (txtPrecio1.Text == "")
            {
                error = false;
                error5.SetError(txtPrecio1, "Agrega un valor");
            }
             if (txtPrecio2.Text == "")
            {
                error = false;
                error6.SetError(txtPrecio2, "Segundo monto");
            }
             if (txtPlazoEntrega.Text == "")
            {
                error = false;
                error7.SetError(txtPlazoEntrega, "Plazo de entrega");
            }
             if (richObservaciones.Text == "")
            {
                error = false;
                error8.SetError(richObservaciones, "Escribe las observaciones pertinentes");
            }
             if (cbIDGrupoExamen.Text == "")
            {
                error = false;
                error9.SetError(cbIDGrupoExamen, "Selecciona un grupo");
            }
             if (txtTitulo.Text == "")
            {
                error = false;
                error10.SetError(txtTitulo, "Título");
            }
             if (txtLabRef.Text == "")
            {
                error = false;
                error11.SetError(txtLabRef, "Agrega el laboratorio de referencia");
            }
             if (txtPrecioRef.Text == "")
            {
                error = false;
                error12.SetError(txtPrecioRef, "Precio de referencia");
            }
            return error;
        }
        //Eliminación de los errores 
        private void EliminarErrores()
        {
            error1.SetError(txtEquivalencia, "");
            error2.SetError(txtUnidades, "");
            error3.SetError(txtValNorHombres, "");
            error4.SetError(txtValNorMujeres, "");
            error5.SetError(txtPrecio1, "");
            error6.SetError(txtPrecio2, "");
            error7.SetError(txtPlazoEntrega, "");
            error8.SetError(richObservaciones, "");
            error9.SetError(cbIDGrupoExamen, "");
            error10.SetError(txtTitulo, "");
            error11.SetError(txtLabRef, "");
            error12.SetError(txtPrecioRef, "");
        } 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EliminarErrores();
            if(verificacion()) 
            {
                MessageBox.Show("¡Guardado satisfactoriamente!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
            } 
        }

        private void txtValNorHombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }

        private void txtValNorMujeres_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }

        private void txtPrecio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }

        private void txtPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }
        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloLetras(e);
        }
        private void txtLabRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloLetras(e);
        }
        private void txtPrecioRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloLetras(e);
        }
    }
}
