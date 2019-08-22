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
    public partial class CargarDatos : Form
    {
        LimitantesDeIngreso lim = new LimitantesDeIngreso();
        private int ID;

        public CargarDatos()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnAnular, "Anular");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
            this.toolTip1.SetToolTip(this.txtResultado, "Buscar ID del examen");
        }

        private void CargarDatos_Load(object sender, EventArgs e)
        {

        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validar()
        {
            bool error = true;
            if (txtResultado.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtResultado, "Ingrese resultado del examen");
            }
            return error;
        }
        //Cuando se llenen, se retira el error
        private void SinErrores()
        {
            errorProvider1.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (!validar())
            {
                MensajeError("Falta llenar un campo");
            }
            else
            {
                Guardar();
            }
        }
        private void Limpiar()
        {
            ID = 0;
            this.txtResultado.Text = string.Empty;
        }
        private void Habilitar()
        {
            this.txtResultado.Enabled = true;
            PanelIngreso.Size = new Size(317, PanelIngreso.Size.Height);
        }
        private void Guardar()
        {



        }
    }
}
