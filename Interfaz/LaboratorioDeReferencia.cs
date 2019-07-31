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
    public partial class LaboratorioDeReferencia : Form
    {
        LimitantesDeIngreso lim = new LimitantesDeIngreso();
        public LaboratorioDeReferencia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
<<<<<<< HEAD
        //Ignoren esto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }
        //Ignora lo de arriba
=======

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Limpiar();
            if (valid()) {
                MessageBox.Show("¡Guardado con éxito!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
            }
        }

>>>>>>> master
        //Validaciones de campos
        private bool valid()
        {
            bool error = true;
            if (txtIDLabRef.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtIDLabRef, "Olvidaste llenar este campo");
            }
            if (txtNombreLabRef.Text == "")
            {
                error = false;
                errorProvider2.SetError(txtNombreLabRef, "Agrega el nombre");
            }
            return error;
        }
        //Limpiar errores
        private void Limpiar()
        {
            errorProvider1.SetError(txtIDLabRef, "");
            errorProvider2.SetError(txtNombreLabRef, "");
        } 

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombreLabRef.Enabled = true;
            txtIDLabRef.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            txtIDLabRef.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIDLabRef.Enabled = true;
            txtNombreLabRef.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            txtIDLabRef.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIDLabRef.Clear();
            txtNombreLabRef.Clear();
            btnEditar.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = true;
        }
        private void txtNombreLabRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            lim.soloLetras(e);
<<<<<<< HEAD
        }
        //Este es el botón guardar
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            if (valid())
            {
                MessageBox.Show("¡Guardado con éxito!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

       
=======
        } 
>>>>>>> master
    }
}
