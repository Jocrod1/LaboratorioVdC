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
    public partial class RegistroAcceso : Form
    {
        public RegistroAcceso()
        {
            InitializeComponent();
        }

        private void RegistroAcceso_Load(object sender, EventArgs e)
        {
            cbTop.Text = "100";
            panel_cedula.Enabled = false;
            panel_turno.Enabled = false;
            panel_fechas.Enabled = false;
        }

        //metodos
        private void Mostrar()
        {
            dataListado.DataSource = MRegistroAcceso.Mostrar(Convert.ToInt32(cbTop.Text), txtCedula.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarTurno()
        {
            dataListado.DataSource = MRegistroAcceso.MostrarTurnos(Convert.ToInt32(cbTop.Text), txtCedulaTurno.Text, );
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LimpiarTodo()
        {
            txtCedula.Clear();
            txtCedulaTurno.Clear();
            cbTurno.SelectedIndex = -1;

            panel_cedula.Visible = false;
            panel_turno.Visible = false;
            panel_fechas.Visible = false;

            panel_cedula.Enabled = false;
            panel_turno.Enabled = false;
            panel_fechas.Enabled = false;
        }


        //mensajes
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTodo();
            Mostrar();

            if (cbBuscar.SelectedIndex==0)
            {
                panel_cedula.Visible = true;
                panel_cedula.Enabled = true;
                txtCedula.Focus();
            }
            else if(cbBuscar.SelectedIndex==1)
            {
                panel_turno.Visible = true;
                panel_turno.Enabled = true;
                cbTurno.Focus();
            }
            else if (cbBuscar.SelectedIndex == 2)
            {
                panel_fechas.Visible = true;
                panel_fechas.Enabled = true;
                dtDesde.Focus();
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCedulaTurno_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
