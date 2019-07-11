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

        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        public Paciente()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtCiPaciente.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (valid())
            {
                MessageBox.Show("¡Paciente guardado satisfactoriamente!", "Almacenado...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            string Rpta = "";
            try
            {
                if (this.IsNuevo)
                {

                    Rpta = MPaciente.Insertar(Convert.ToInt32(""),this.txtNombre.Text, Convert.ToInt32(txtEdad.Text), this.txtSexo.Text, txtTelefono.Text, Convert.ToDateTime(dateTimePickerFUR), txtNroHab.Text, Convert.ToInt32(txtIdMedico.Text));

                }
                else
                {
                    //Vamos a modificar un Trabajador
                    Rpta = MPaciente.Editar(Convert.ToInt32(this.txtID.Text), this.txtNombre.Text, Convert.ToInt32(txtEdad.Text), this.txtSexo.Text, txtTelefono.Text, Convert.ToDateTime(dateTimePickerFUR), txtNroHab.Text, Convert.ToInt32(txtIdMedico.Text));
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
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
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
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar los " + NumeroSeleccionado + " Registros de Trabajadores?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar el Registro del Trabajador?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MPaciente.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Eliminaron Correctamente los Registros de Trabajadores");
                        }
                        else
                        {
                            this.MensajeOK("Se Eliminó Correctamente el Registro del Trabajador");
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

        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void Habilitar()
        {
            this.txtCiPaciente.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtSexo.Enabled = true;
            this.txtEdad.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.dateTimePickerFUR.Enabled = true;
            this.txtNroHab.Enabled = true;
            this.txtIdMedico.Enabled = true;
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
            this.txtIdMedico.Enabled = false;
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
            this.txtIdMedico.Text = string.Empty;
        }

        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MPaciente.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Validacioneees
        private bool valid()
        {
            bool error = true;
            if (txtCiPaciente.Text == "")
            {
                error = false;
                error1.SetError(txtCiPaciente, "Ingresa la cédula del paciente");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                error2.SetError(txtNombre, "Nombre del paciente.");
            }
            if (txtSexo.Text == "")
            {
                error = false;
                error3.SetError(txtSexo, "Asigna un género");
            }
            if (txtEdad.Text == "")
            {
                error = false;
                error4.SetError(txtEdad, "Ingresa la edad del paciente.");
            }
            if (txtTelefono.Text == "")
            {
                error = false;
                error5.SetError(txtTelefono, "Agrega un número teléfonico");
            }
            if (dateTimePickerFUR.Text == "")
            {
                error = false;
                error6.SetError(dateTimePickerFUR, "Fecha de hoy");
            }
            if (txtNroHab.Text == "")
            {
                error = false;
                error7.SetError(txtNroHab, "El número de habitación");
            }
            if (txtIdMedico.Text == "")
            {
                error = false;
                error8.SetError(txtIdMedico, "Agrega el ID del médico");
            }
            return error;
        }
        //Eliminación de los errores 
        private void SinErrores()
        {
            error1.SetError(txtCiPaciente, "");
            error2.SetError(txtNombre, "");
            error3.SetError(txtSexo, "");
            error4.SetError(txtEdad,"");
            error5.SetError(txtTelefono,"");
            error6.SetError(dateTimePickerFUR,"");
            error7.SetError(txtNroHab,"");
            error8.SetError(txtIdMedico,"");
        }


    }
}
