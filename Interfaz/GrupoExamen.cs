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
    public partial class GrupoExamen : Form
    {
        LimitantesDeIngreso lim = new LimitantesDeIngreso();
        public GrupoExamen()
        {
            InitializeComponent();
        }

        //ícono ilustrativo pq no sé dónde encontrar los que estaban usando, esos con el fondo azul beios, sorry

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            verificarerrores();
            if (validar()) {
                MessageBox.Show("Guardado con éxito", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //Validaciones hi
        private bool validar ()
        {
            bool error = true;
            if (txtIDGrupoExam.Text == "" && txtNombreGrupExam.Text == "")
            {
                error= false;
                errorProvider1.SetError(txtIDGrupoExam, "¡Llena este campo");
                errorProvider2.SetError(txtNombreGrupExam,"Completa este campo");
            }
            return error;
        }
        //Eliminación de los errores 
        private void verificarerrores()
        {
            errorProvider1.SetError(txtIDGrupoExam, "");
            errorProvider2.SetError(txtNombreGrupExam, "");
        } 
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIDGrupoExam.Enabled = true;
            txtNombreGrupExam.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            txtIDGrupoExam.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtIDGrupoExam.Enabled = true;
            txtNombreGrupExam.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            txtNombreGrupExam.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIDGrupoExam.Clear();
            txtNombreGrupExam.Clear();
        }

    }
}
