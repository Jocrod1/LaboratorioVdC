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
            this.toolTip1.SetToolTip(this.dtDesde, "Fecha");
            this.toolTip1.SetToolTip(this.dtHasta, "Fecha");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.label1, "Cantidad de elementos a buscar");
        }

        private void RegistroAcceso_Load(object sender, EventArgs e)
        {
            cbBuscar.SelectedIndex = -1;
            cbTop.Text = "100";
            panel_cedula.Enabled = false;
            panel_turno.Enabled = false;
            panel_fechas.Enabled = false;

            //combobox
            cbTurno.DataSource = MTurno.MostrarCombobox();
            cbTurno.DisplayMember = "Nombre";
            cbTurno.ValueMember = "ID";
            cbTurno.SelectedIndex = -1;
            //

            //todo esto es pa ponerle colorcitos al datagridview

            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(209, 247, 195);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.FromArgb(127, 207, 74);
            dataListado.DefaultCellStyle.SelectionForeColor = Color.White;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(96, 191, 33);  //69, 204, 20
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataListado.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);


            Mostrar();
        }

        //metodos
        private void Mostrar()
        {
            dataListado.DataSource = MRegistroAcceso.Mostrar(Convert.ToInt32(cbTop.Text), (cbCedula.Text + txtCedula.Text));
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarTurno()
        {
            string IDTurno = MRegistroAcceso.CaptarTurno();

            dataListado.DataSource = MRegistroAcceso.MostrarTurnos(Convert.ToInt32(cbTop.Text), txtCedulaTurno.Text, Convert.ToInt32(IDTurno));
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarFechas()
        {
            dataListado.DataSource = MRegistroAcceso.MostrarFechas(Convert.ToInt32(cbTop.Text), txtCedulaTurno.Text, Convert.ToDateTime(dtDesde.Text), Convert.ToDateTime(dtHasta.Text));
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

            if (cbBuscar.SelectedIndex == 0)
            {
                panel_cedula.Visible = true;
                panel_cedula.Enabled = true;
                txtCedula.Focus();
            }
            else if(cbBuscar.SelectedIndex == 1)
            {
                panel_turno.Visible = true;
                panel_turno.Enabled = true;
                txtCedulaTurno.Enabled = false;
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
            MostrarTurno();
            txtCedulaTurno.Enabled = true;
            txtCedulaTurno.Focus();
        }

        private void txtCedulaTurno_TextChanged(object sender, EventArgs e)
        {
            MostrarTurno();
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            MostrarFechas();
            dtHasta.Focus();
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            MostrarFechas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            Mostrar();
            cbBuscar.SelectedIndex = -1;
        }

        private void cbTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 1)
            {
                MostrarTurno();
            }
            else if (cbBuscar.SelectedIndex == 2)
            {
                MostrarFechas();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
