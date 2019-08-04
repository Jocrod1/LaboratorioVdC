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
    public partial class Paciente : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        public Paciente()
        {
            InitializeComponent();
        }

        private void Paciente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
            this.Botones();


            dataListado.BorderStyle = BorderStyle.None;
            dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 246, 238);
            dataListado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataListado.DefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 196, 99);
            dataListado.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataListado.BackgroundColor = Color.White;

            dataListado.EnableHeadersVisualStyles = false;
            dataListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(237, 144, 5);
            dataListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }

        //botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtCiPaciente.Focus();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            ID = 0;
        }

        //estos 2 se dejan al final
        private void btnAnular_Click(object sender, EventArgs e)
        {

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
        //

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdPaciente"].Value);
            this.txtCiPaciente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sexo"].Value);
            this.txtEdad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Edad"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.dateTimePickerFUR.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FUR"].Value);
            this.txtNroHab.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NumeroHabitacion"].Value);


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de pacientes?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del paciente?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MPaciente.Eliminar(Convert.ToInt32(item.Cells["IdPaciente"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de pacientes");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del paciente");
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

                    Rpta = MPaciente.Insertar(this.txtNombre.Text, Convert.ToInt32(txtEdad.Text), this.txtSexo.Text, this.txtCiPaciente.Text, txtTelefono.Text, Convert.ToDateTime(dateTimePickerFUR.Text), txtNroHab.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MPaciente.Editar(ID, this.txtNombre.Text, Convert.ToInt32(txtEdad.Text), this.txtSexo.Text, this.txtCiPaciente.Text, txtTelefono.Text, Convert.ToDateTime(dateTimePickerFUR.Text), txtNroHab.Text);
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
            if (txtCiPaciente.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtCiPaciente, "Agrega el CI del paciente");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtNombre, "Ingresa el nombre del paciente");
            }
            if (txtSexo.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtSexo, "Ingresa el sexo del paciente");
            }
            if (txtTelefono.Text == "")
            {
                errorProvider1.SetError(txtTelefono, "ingresa un ");
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
            this.txtCiPaciente.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtSexo.Enabled = true;
            this.txtEdad.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.dateTimePickerFUR.Enabled = true;
            this.txtNroHab.Enabled = true;
        }

        private void Deshabilitar()
        {
            this.txtCiPaciente.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtSexo.Enabled = false;
            this.txtEdad.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.dateTimePickerFUR.Enabled = false;
            this.txtNroHab.Enabled = false;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar();
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Deshabilitar();
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Limpiar()
        {
            this.txtCiPaciente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtSexo.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.dateTimePickerFUR.Text = string.Empty;
            this.txtNroHab.Text = string.Empty;
        }

        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MPaciente.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar_Cedula()
        {
            dataListado.DataSource = MPaciente.Buscar_Cedula(txtBuscar.Text);
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


        //validaciones
        private void txtCiPaciente_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtCiPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtCiPaciente, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtCiPaciente, "En este campo solo se pueden ingresar numeros");
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtEdad, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtEdad, "En este campo solo se pueden ingresar numeros");
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtTelefono, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtTelefono, "En este campo solo se pueden ingresar numeros");
            }
        }
        private void txtIdMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }
        private void txtNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBuscar.Text == "Cedula")
            {
                errorProvider1.SetError(txtBuscar, "");
                if (valid.soloNumeros(e))
                {
                    errorProvider1.SetError(txtBuscar, "En este campo solo se pueden ingresar numeros");
                }
            }
            if (cbBuscar.Text == "Nombre")
            {
                errorProvider1.SetError(txtBuscar, "");
                if (valid.soloLetras(e))
                {
                    errorProvider1.SetError(txtBuscar, "En este campo solo se pueden ingresar letras");
                }
            }
        }

        private void txtCiPaciente_Leave(object sender, EventArgs e)
        {
            if (!IsNuevo)
                return;
            dataListado.DataSource= MPaciente.CedulaUnica(this.txtCiPaciente.Text);

            if(dataListado.Rows.Count!=0)
            {
                MessageBox.Show("Ya el Paciente C.I: " + this.txtCiPaciente.Text + " está ingresado", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCiPaciente.Text = string.Empty;
                this.txtCiPaciente.Focus();
            }

            Mostrar();
        }

    }
}
