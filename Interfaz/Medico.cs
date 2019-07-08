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
    public partial class Medico : Form
    {
        public Medico()
        {
            InitializeComponent();
        }

        private bool validarr()
        {
            bool error = true;
            if (txtCiMedico.Text == "")
            {
                error = false;
                err1.SetError(txtCiMedico, "Cédula del médico");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                err2.SetError(txtNombre, "No olvides el nombre del médico");
            }
            if (txtContrasena.Text == "")
            {
                error = false;
                err3.SetError(txtContrasena, "Crea una contraseña que no puedas olvidar");
            }
            if (richDireccion.Text == "")
            {
                error = false;
                err4.SetError(richDireccion, "Escribe una dirección");
            }
            if (txtTelefono.Text == "")
            {
                error = false;
                err5.SetError(txtTelefono, "Inserta un número telefónico");
            }
            if (txtCorreo.Text == "")
            {
                error = false;
                err6.SetError(txtCorreo, "Agrega un correo electrónico");
            }
            if (cbAcceso.Text == "")
            {
                error = false;
                err7.SetError(cbAcceso, "Selecciona su nivel de acceso.");
            }
            return error;
        }
        //Eliminación de los errores 
        private void ChaoErr()
        {
            err1.SetError(txtCiMedico, "");
            err2.SetError(txtNombre, "");
            err3.SetError(txtContrasena, "");
            err4.SetError(richDireccion, "");
            err5.SetError(txtTelefono, "");
            err6.SetError(txtCorreo, "");
            err7.SetError(cbAcceso, "");
        } 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ChaoErr();
            if (validarr())
            {
                MessageBox.Show("¡Guardado en la base de datos!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 
        }

    }
}
