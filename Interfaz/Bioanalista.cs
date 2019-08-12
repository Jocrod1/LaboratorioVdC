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
    public partial class Bioanalista : Form
    {

        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        public Bioanalista()
        {
            InitializeComponent();
        }

        private void Bioanalista_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
            this.Botones();
            cbBuscar.SelectedIndex = 0;


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
            this.cbCedula.Focus();
            ID = 0;
            this.txtCedula.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
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
            Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Habilitar();
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);

            //esto es la cedula
            string Cedula = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.cbCedula.Text = Cedula.Substring(0, 2);
            this.txtCedula.Text = Cedula.Remove(0, 2);
            //

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtColegio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Colegio_Bioanalista"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Colegio_Codigo"].Value);
            Editar();
            txtCedula.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        //metodos

        void EliminarItems()
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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de Bioanalistas?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del Bioanalista?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MBioanalista.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de Bioanalistas");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del Bioanalista");
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


        void AnularItems()
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros de Bioanalistas?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro del Bioanalista?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MBioanalista.Anular(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de Bioanalistas");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del Bioanalista");
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

                    Rpta = MBioanalista.Insertar((this.cbCedula.Text+this.txtCedula.Text),this.txtNombre.Text, this.txtColegio.Text,this.txtCodigo.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MBioanalista.Editar(ID,(this.cbCedula.Text + this.txtCedula.Text), this.txtNombre.Text, this.txtColegio.Text, this.txtCodigo.Text);
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
                this.txtCedula.Enabled = false;
                this.cbCedula.Enabled = false;
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
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
            this.txtCedula.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtColegio.Enabled = true;
            this.txtCodigo.Enabled = true;
            this.cbCedula.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(317, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtColegio.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.cbCedula.Enabled = false;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
            btnNuevo.Visible = true;
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
            ID = 0;
            this.txtCedula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtColegio.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.cbCedula.SelectedIndex = -1;
        }

        private void Mostrar()
        {
            dataListado.DataSource = MBioanalista.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar_Cedula()
        {
            dataListado.DataSource = MBioanalista.MostrarCedula(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar()
        {
            if (cbBuscar.SelectedIndex == 1)
            {
                this.Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 0)
            {
                this.Buscar_Cedula();
            }
        }

        private void CedulaUnica()
        {
            try
            {
                if (!IsNuevo)
                    return;
                dataListado.DataSource = MBioanalista.CedulaUnica((this.cbCedula.Text + this.txtCedula.Text));

                if (dataListado.Rows.Count != 0)
                {
                    MessageBox.Show("Ya el Bioanalista C.I: " + (this.cbCedula.Text + this.txtCedula.Text) + "está ingresado", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCedula.Text = string.Empty;
                    this.txtCedula.Focus();
                }

                Mostrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la Conexion de la BD", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            CedulaUnica();
        }

        private void cbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCedula.SelectedIndex != -1)
            {
                txtCedula.Enabled = true;
                txtCedula.Focus();
            }
        }


    }
}
