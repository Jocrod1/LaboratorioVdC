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
        LimitantesDeIngreso vali = new LimitantesDeIngreso();
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
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
            vali.soloNumeros(e);
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloLetras(e);
        }
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloNumeros(e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloNumeros(e);
        }
        private void txtIdMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloNumeros(e);
        }
        private void txtNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloNumeros(e);
        }



    }
}
