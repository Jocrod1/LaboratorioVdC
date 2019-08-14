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
    public partial class Perfil : Form
    {


        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;



        public Perfil()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {

            this.Mostrar();
            this.Deshabilitar();
            this.Botones();




        }







        //metodos



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
                        Rpta = MPerfil.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros de pacientes?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro del paciente?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MPerfil.Anular(Convert.ToInt32(item.Cells["IdPaciente"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de pacientes");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del paciente");
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

                    Rpta = MPerfil.Insertar(this.txtNombre.Text, Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Convert.ToInt32(txtTitulo.Text), Convert.ToInt32(cbLabRef.Text), Convert.ToInt32(txtPrecioRef.Text));
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MPerfil.Editar(ID, this.txtNombre.Text, Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Convert.ToInt32(txtTitulo.Text), Convert.ToInt32(cbLabRef.Text), Convert.ToInt32(txtPrecioRef.Text));
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



        //mensajes
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

        private void Habilitar()
        {
            this.txtNombre.Enabled = true;
            this.cbLabRef.Enabled = true;
            this.txtPrecio1.Enabled = true;
            this.txtPrecio2.Enabled = true;
            this.txtTitulo.Enabled = true;
            this.txtPrecioRef.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(311, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.cbLabRef.Enabled = false;
            this.txtPrecio1.Enabled = false;
            this.txtPrecio2.Enabled = false;
            this.txtTitulo.Enabled = false;
            this.txtPrecioRef.Enabled = false;
            btnNuevo.Visible = false;
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
            this.txtNombre.Text= string.Empty;
            this.cbLabRef.SelectedIndex = -1;
            this.txtPrecio1.Text = string.Empty;
            this.txtPrecio2.Text = string.Empty;
            this.txtTitulo.Text = string.Empty;
            this.txtPrecioRef.Text = string.Empty;
        }


        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MPerfil.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }





    }
}
