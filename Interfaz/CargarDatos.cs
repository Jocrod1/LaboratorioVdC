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
    public partial class CargarDatos : Form
    {
        LimitantesDeIngreso lim = new LimitantesDeIngreso();
        private int ID;

        private bool IsNuevo = false;
        
        private bool IsEditar = false;

        public CargarDatos()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnBuscar, "Eliminar");
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
            this.txtNombre.Enabled = true;
            PanelIngreso.Size = new Size(317, PanelIngreso.Size.Height);
        }


        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar();
             
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Deshabilitar();
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Deshabilitar()
        {
            this.txtResultado.Enabled = false;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
 
        }


        private void Mostrar()
        {
            dataListado.DataSource = MOrden.MostrarDetalle(Convert.ToInt32(txtBuscar.Text));
            dataListado.ClearSelection();
   //         this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
           Anulados();
        }

        private void Anulados()
        {
            string estadotabla;

            for (int fila = 0; fila <= dataListado.Rows.Count - 1; fila++)
            {
                estadotabla = Convert.ToString(this.dataListado.Rows[fila].Cells["Estado"].Value);

                if (estadotabla == "ANULADO")
                {
                    dataListado.Rows[fila].Cells["nombre"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["nombre"].Style.SelectionBackColor = Color.Brown;
                }
            }
        }

        private void Guardar()
        {
            MOrden.InsertarCarga(txtResultado.Text);
        }
        private void Buscar()
        {
            this.Mostrar();
        }

        private void DobleClick()
        {
            Limpiar();
            Habilitar();

            //dgvSeleccionados.DataSource = MPerfil.MostrarDetalle(IDDetalle);

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreExamen"].Value);

            //Editar();
            txtNombre.Enabled = false;
            txtResultado.Focus();
        }


        //eventos

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            lim.soloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            lim.soloLetras(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DobleClick();
        }
    }
}
