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
    public partial class Trabajador : Form
    {

        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;


        public Trabajador()
        {
            InitializeComponent();
        }

        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }



        private void Limpiar()
        {
            this.txtCiTrabajador.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtContrasena.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtCiTrabajador.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtContrasena.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.cbAcceso.Enabled = Valor;
            this.txtCorreo.Enabled = Valor;
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }





        private void Trabajador_Load(object sender, EventArgs e)
        {
            //Para ubicar al formulario en la parte superior del contenedor
            this.Top = 0;
            this.Left = 0;
            //Le decimos al DataGridView que no auto genere las columnas
            //this.datalistado.AutoGenerateColumns = false;
            //Llenamos el DataGridView con la informacion
            //de todos nuestros Trabajadores
            this.Mostrar();
            //Deshabilita los controles
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
        }



        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MUsuario.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar_Nombre()
        {
            //MUsuario.Buscar_Nombre(txtBuscar.Text);

            dataListado.DataSource = MUsuario.Buscar_Nombre(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                this.Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 1)
            {
                this.Buscar_Nombre();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                int NumeroSeleccionado=0;
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
                        Rpta = MUsuario.Eliminar(Convert.ToString(item.Cells["cedula"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if(NumeroSeleccionado>1)
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


        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCiTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.txtContrasena.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Contraseña"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Correo"].Value);

            this.tabControl1.SelectedIndex = 1; //Esto es para que al darle doble click, lleve a la tab de "Mantenimiento"
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se inserto 
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || txtContrasena.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtContrasena, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Trabajador 

                        Rpta = MUsuario.Insertar(this.txtCiTrabajador.Text, this.txtNombre.Text, this.txtContrasena.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbAcceso.SelectedIndex );

                    }
                    else
                    {
                        //Vamos a modificar un Trabajador
                        Rpta = MUsuario.Editar(this.txtCiTrabajador.Text, this.txtNombre.Text, this.txtContrasena.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbAcceso.SelectedIndex);
                    }
                    //Si la respuesta fue OK, fue porque se modifico 
                    //o inserto el Trabajador
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
                    this.txtCiTrabajador.Text = "";

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un producto no puede modificar
            if (!this.txtCiTrabajador.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtCiTrabajador.Text = string.Empty;
        }


    }
}
