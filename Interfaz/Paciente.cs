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
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Validacioneees
        private bool valid()
        {
            bool error = true;
            if (txtCiPaciente.Text == "")
            {
                error = false;
                error1.SetError(txtCiPaciente, "Ingresa la cédula del paciente");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                error2.SetError(txtNombre, "Nombre del paciente.");
            }
            if (txtSexo.Text == "")
            {
                error = false;
                error3.SetError(txtSexo, "Asigna un género");
            }
            if (txtEdad.Text == "")
            {
                error = false;
                error4.SetError(txtEdad, "Ingresa la edad del paciente.");
            }
            if (txtTelefono.Text == "")
            {
                error = false;
                error5.SetError(txtTelefono, "Agrega un número teléfonico");
            }
            if (dateTimePickerFUR.Text == "")
            {
                error = false;
                error6.SetError(dateTimePickerFUR, "Fecha de hoy");
            }
            if (txtNroHab.Text == "")
            {
                error = false;
                error7.SetError(txtNroHab, "El número de habitación");
            }
            if (txtIdMedico.Text == "")
            {
                error = false;
                error8.SetError(txtIdMedico, "Agrega el ID del médico");
            }
            return error;
        }
        //Eliminación de los errores 
        private void SinErrores()
        {
            error1.SetError(txtCiPaciente, "");
            error2.SetError(txtNombre, "");
            error3.SetError(txtSexo, "");
            error4.SetError(txtEdad,"");
            error5.SetError(txtTelefono,"");
            error6.SetError(dateTimePickerFUR,"");
            error7.SetError(txtNroHab,"");
            error8.SetError(txtIdMedico,"");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (valid())
            {
                MessageBox.Show("¡Paciente guardado satisfactoriamente!", "Almacenado...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        
    }
}
