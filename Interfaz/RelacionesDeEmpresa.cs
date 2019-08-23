using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metodos;

namespace Interfaz
{
    public partial class RelacionesDeEmpresa : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        public RelacionesDeEmpresa()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnAnular, "Anular acción");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");        
        
        }


        private void OcultarMonto() {

            if (cbFormaDePago.Text == "Pagar completo") 
            {
                label1.Visible = true;
                txtMonto.Visible = true;
            }
            if (cbFormaDePago.Text == "Pagar por parte") 
            {
                txtMonto.Visible = true;
                label1.Visible = true;
            }

        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarMonto();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtMonto, "");
            if (valid.soloNumerosyPuntos(e))
            {
                errorProvider1.SetError(txtMonto, "Sólo se permiten números");
            }
            
        }
        private void Habilitar()
        {
            this.txtMonto.Enabled = true;
            PanelIngreso.Size = new Size(317, PanelIngreso.Size.Height);
        }
        private void SinErrores()
        {
            errorProvider1.Clear();
        }
        private void Deshabilitar()
        {
            this.txtMonto.Enabled = false;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
           
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SinErrores();
            this.Deshabilitar();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtBuscar, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtBuscar, "En este campo solo se pueden ingresar letras");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Botón guardar



        }
    }
}
