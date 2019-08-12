using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Metodos;

namespace Interfaz
{
    public partial class Trabajador : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

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
            this.Habilitar();
            this.cbCedula.SelectedIndex = 0;
            this.cbCedula.Focus();
            txtCiTrabajador.Enabled = true;
        }

        //Validar datos al ingresar
        private bool validar()
        {
            
            bool error = true;
            if (txtCiTrabajador.Text == "")
            {
                error = false;
                Provider1.SetError(txtCiTrabajador, "Agrega el CI del trabajador");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                Provider1.SetError(txtNombre, "Inserta un nombre");
            }
            if (txtContrasena.Text == "")
            {
                error = false;
                Provider1.SetError(txtContrasena, "¡Crea una contraseña!");
            }
            if (cbAcceso.Text == "") {
                Provider1.SetError(cbAcceso, "Elige un tipo de acceso para este usuario");
            }
            if (txtCorreo.Text != "" && !valid.IsValidEmail(txtCorreo.Text)){
                Provider1.SetError(txtCorreo, "Ingrese un correo correcto");
            } 
            return error;
        }
        //Cuando se llenen, se retira el error
        private void SinErrores()
        {
            Provider1.Clear();
        }
        private void Limpiar()
        {
            this.txtCiTrabajador.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtContrasena.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.cbAcceso.SelectedIndex = -1;

        }


        private void Habilitar()
        {
            this.txtCiTrabajador.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtContrasena.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtCorreo.Enabled = true;
            this.cbAcceso.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(352, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtCiTrabajador.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtContrasena.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.cbAcceso.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
        }




        //Habilita los botones
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


















        private void Trabajador_Load(object sender, EventArgs e)
        {

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





            cbBuscar.SelectedIndex = 0;
            //Para ubicar al formulario en la parte superior del contenedor
            this.Top = 0;
            this.Left = 0;
            //Le decimos al DataGridView que no auto genere las columnas
            //this.datalistado.AutoGenerateColumns = false;
            //Llenamos el DataGridView con la informacion
            //de todos nuestros Trabajadores
            this.Mostrar();
            //Deshabilita los controles
            this.Deshabilitar();
            //Establece los botones
            this.Botones();
        }





        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MUsuario.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
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

        void Buscar() {
            if (cbBuscar.SelectedIndex == 0)
            {
                this.Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 1)
            {
                this.Buscar_Nombre();
            }
        }

        
        private void EliminarItems() {

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
                        Rpta = MUsuario.Eliminar(Convert.ToString(item.Cells["cedula"].Value));
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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular los " + NumeroSeleccionado + " Registros de Trabajadores?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Anular el Registro del Trabajador?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MUsuario.Anular(Convert.ToString(item.Cells["cedula"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Anularon Correctamente los Registros de Trabajadores");
                        }
                        else
                        {
                            this.MensajeOK("Se Anuló Correctamente el Registro del Trabajador");
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






        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //no existe ID en trabajador OJO
            Habilitar();
            //cedula
            string Cedula = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.cbCedula.Text = Cedula.Substring(0, 2);
            this.txtCiTrabajador.Text = Cedula.Remove(0, 2);
            //

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.txtContrasena.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Contraseña"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Correo"].Value);
            Editar();
            txtNombre.Focus();
        }




        private void Editar()
        {
            //Si no ha seleccionado un trabajador no puede modificar
            if (!txtCiTrabajador.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.txtCiTrabajador.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SinErrores();
                //La variable que almacena si se insertó
                //o se modificó la tabla
                string Rpta = "";
                if (!validar())
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Trabajador 

                        Rpta = MUsuario.Insertar((this.cbCedula.Text + this.txtCiTrabajador.Text), this.txtNombre.Text, this.txtContrasena.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbAcceso.SelectedItem.ToString());

                    }
                    else
                    {
                        //Vamos a modificar un Trabajador
                        Rpta = MUsuario.Editar((this.cbCedula.Text + this.txtCiTrabajador.Text), this.txtNombre.Text, this.txtContrasena.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, cbAcceso.SelectedItem.ToString());
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            SinErrores();
            this.Botones();
            this.Limpiar();
            this.Deshabilitar();
            this.txtCiTrabajador.Text = string.Empty;
        }

        private void DataListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                EliminarItems();
            }
        }

        private void cbAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Entrada
        private void txtCiTrabajador_KeyPress(object sender, KeyPressEventArgs e)
        {
            Provider1.SetError(txtCiTrabajador, "");
            if (valid.soloNumeros(e)) {
                Provider1.SetError(txtCiTrabajador, "En este campo solo se pueden ingresar numeros");
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Provider1.SetError(txtNombre, "");
            if (valid.soloLetras(e)) {
                Provider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Provider1.SetError(txtTelefono, "");
            if (valid.soloNumeros(e))
            {
                Provider1.SetError(txtTelefono, "En este campo solo se pueden ingresar numeros");
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBuscar.Text == "Cedula") {
                Provider1.SetError(txtBuscar, "");
                if (valid.soloNumeros(e))
                {
                    Provider1.SetError(txtBuscar, "En este campo solo se pueden ingresar numeros");
                }
            }
            if (cbBuscar.Text == "Nombre") {
                Provider1.SetError(txtBuscar, "");
                if (valid.soloLetras(e))
                {
                    Provider1.SetError(txtBuscar, "En este campo solo se pueden ingresar letras");
                }
            }
        }



        private void CedulaUnica()
        {
            try
            {
                if (!IsNuevo)
                    return;
                dataListado.DataSource = MUsuario.CedulaUnica(this.txtCiTrabajador.Text);

                if (dataListado.Rows.Count != 0)
                {
                    MessageBox.Show("Ya el Trabajador C.I: " + (this.cbCedula.Text+this.txtCiTrabajador.Text) + " está ingresado", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCiTrabajador.Text = string.Empty;
                    this.txtCiTrabajador.Focus();
                }

                Mostrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la Conexion de la BD", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtCiTrabajador_Leave(object sender, EventArgs e)
        {
            CedulaUnica();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //en construccion(?)
        }

        private void cbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCedula.SelectedIndex!=-1)
            {
                if(IsNuevo==true || IsEditar==true)
                {
                    txtCiTrabajador.Enabled = true;
                    txtCiTrabajador.Focus();
                }
            }
        }
    }
}
