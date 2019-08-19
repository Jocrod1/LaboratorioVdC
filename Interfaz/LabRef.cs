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
    public partial class LabRef : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        public LabRef()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnAnular, "Anular acción");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
            this.toolTip1.SetToolTip(this.btnNuevo, "Nuevo paciente");
            this.toolTip1.SetToolTip(this.txtNombre, "Nombre del laboratorio de referencia");
        }

        private void LabRef_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
            this.Botones();

            this.OcultarColumnas();

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


        }

        //botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtNombre.Focus();
            ID = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (!validar())
            {
                MensajeError("Falta ingresar algunos datos, serán remarcados");
            }
            else
            {
                Guardar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Deshabilitar();
            ID = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Habilitar();
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            Editar();
            txtNombre.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

        }

        //metodos

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false; //ID
        }

        private void EliminarItems()
        {

            try
            {
                int NumeroSeleccionado = 0;
                DialogResult Opcion;
                foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                {
                    NumeroSeleccionado++;
                }
                if (NumeroSeleccionado > 1)
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de Laboratorios de Referencias?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del Laboratorio de Referencia?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MLabRef.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los Laboratorios de Referencias");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del Laboratorio de Referencia");
                        }
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void AnularItems()
        {

            try
            {
                int NumeroSeleccionado = 0;
                DialogResult Opcion;
                foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                {
                    NumeroSeleccionado++;
                }
                if (NumeroSeleccionado > 1)
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros de Laboratorios de Referencias?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro del Laboratorio de Referencia?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MLabRef.Anular(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los Laboratorios de Referencias");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del Laboratorio de Referencia");
                        }
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Guardar()
        {
            try
            {
                string Rpta = "";

                if (this.IsNuevo)
                {
                    Rpta = MLabRef.Insertar(this.txtNombre.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MLabRef.Editar(ID, this.txtNombre.Text);
                }
                //Si la respuesta fue OK, fue porque se modificó
                //o insertó el Trabajador
                //de forma correcta
                if (Rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOK("Se insertó de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeOK("Se actualizó de forma correcta el registro");
                    }

                }
                else
                {
                    //Mostramos el mensaje de error
                    this.MensajeError(Rpta);
                }
                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();
                this.Deshabilitar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Editar()
        {
            //Si no ha seleccionado un producto no puede modificar
            if (!ID.Equals(0))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private bool validar()
        {
            bool error = true;
            if (txtNombre.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtNombre, "Agrega el CI del trabajador");
            }
            return error;
        }
        //Cuando se llenen, se retira el error
        private void SinErrores()
        {
            errorProvider1.Clear();
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

        private void Habilitar()
        {
            this.txtNombre.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(323, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar();
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Deshabilitar();
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            ID = 0;
        }

        private void Mostrar()
        {
            dataListado.DataSource = MLabRef.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar()
        {
            Mostrar();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtBuscar, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtBuscar, "En este campo solo se pueden ingresar letras");
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
