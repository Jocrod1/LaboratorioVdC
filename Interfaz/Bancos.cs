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
    public partial class Bancos : Form
    {
        LimitantesDeIngreso lim = new LimitantesDeIngreso();
        public Bancos()
        {
            InitializeComponent();
        }
        private bool valid()
        {
            bool error = true;
            if (txtIDBan.Text == "")
            {
                error = false;
                error1.SetError(txtIDBan, "Agrega el número de cuenta");
            }
            if (txtNombreBan.Text == "")
            {
                error = false;
                error2.SetError(txtNombreBan, "Selecciona un banco disponible.");
            }
            return error;
        }
        private void SinErrores()
        {
            error1.SetError(txtIDBan, "");
            error2.SetError(txtNombreBan, "");
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void txtIDBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            lim.soloNumeros(e);
        }
        //Botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
        txtNombreBan.Enabled= true;
        txtIDBan.Enabled= true;
        btnGuardar.Enabled= true;
        btnEditar.Enabled= false;
        btnCancelar.Enabled= true;
        txtIDBan.Focus();
        }
        //Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
        SinErrores();
            if (valid()) {
                MessageBox.Show("¡Guardado con éxito!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtIDBan.Enabled = true;
            txtNombreBan.Enabled = true;
            btnNuevo.Enabled= false;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            txtIDBan.Focus();
        }
    }
}
