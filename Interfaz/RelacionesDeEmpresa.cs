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
                label1.Enabled = true;
                txtMonto.Enabled = true;
            }
            if (cbFormaDePago.Text == "Pagar por parte") 
            {
                txtMonto.Enabled = true;
                label1.Enabled = true;
            }

        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarMonto();
        }
    }
}
