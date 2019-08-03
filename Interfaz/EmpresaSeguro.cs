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
    public partial class EmpresaSeguro : Form
    {


        private int ID;

        private string RespuestaEmision;

        LimitantesDeIngreso valid = new LimitantesDeIngreso();


        public EmpresaSeguro()
        {
            InitializeComponent();
        }


        // funciones


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




        //Variable que nos indica si vamos a insertar una nueva empresa
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar una nueva empresa
        private bool IsEditar = false;




        //Habilita los botones
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


        //Limpia los campos
        private void Limpiar()
        {
            //aca hace falta el id de la empresa para limpiarlo
            this.txtNombre.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.txtTipoPrecio.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtRIF.Text = string.Empty;
            this.txtNIT.Text = string.Empty;
            this.txtContacto.Text = string.Empty;
            this.rbEmisionSi.Checked = false;
            this.rbEmisionNo.Checked = false;


        }


        private void Mostrar()
        {
            

            dataListado.DataSource = MEmpresaSeguro.Mostrar(txtBuscar.Text);
            //this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void MostrarNombre()
        {

            dataListado.DataSource = MEmpresaSeguro.MostrarNombre(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);

        }


        private void Habilitar()
        {
            this.txtNombre.Enabled = true;
            this.txtPorcentaje.Enabled = true;
            this.txtTipoPrecio.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtRIF.Enabled = true;
            this.txtNIT.Enabled = true;
            this.txtContacto.Enabled = true;
            this.rbEmisionNo.Enabled = true;
            this.rbEmisionSi.Enabled = true;

            this.txtNombre.Focus();

        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtPorcentaje.Enabled = false;
            this.txtTipoPrecio.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtRIF.Enabled = false;
            this.txtNIT.Enabled = false;
            this.txtContacto.Enabled = false;
            this.rbEmisionNo.Enabled = false;
            this.rbEmisionSi.Enabled = false;
        }



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
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar los " + NumeroSeleccionado + " Registros de Empresas?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de las empresas?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MEmpresaSeguro.Eliminar(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de empresas");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del empresas");
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " Registros de empresas/seguros?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro de la empresas/Seguros?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MEmpresaSeguro.Editar(Convert.ToInt32(item.Cells["ID"].Value), "ANULADO", 0, 0, "ANULADO", "ANULADO", "ANULADO", "ANULADO", "ANULADO");
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de trabajadores");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del trabajador");
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


        // Eventos



        private void EmpresasYSeguros_Load(object sender, EventArgs e)
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
            this.Deshabilitar();
            //Establece los botones
            this.Botones();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtNombre.Focus();
        }






        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtNombre.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar();
                this.txtNombre.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a editar");
            }
        }





        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 1)
            {
                this.Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 0)
            {
                this.MostrarNombre();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 1)
            {
                this.Mostrar();
            }
            else if (cbBuscar.SelectedIndex == 0)
            {
                this.MostrarNombre();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["porcentaje"].Value);
            this.txtTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoPrecio"].Value);
            this.txtRIF.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["RIF"].Value);
            this.txtNIT.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NIT"].Value);
            this.txtContacto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["contacto"].Value);

            if (Convert.ToString(this.dataListado.CurrentRow.Cells["emision"].Value) == "Sí" )
            {
                rbEmisionSi.Checked = true;
            }
            else if (Convert.ToString(this.dataListado.CurrentRow.Cells["emision"].Value) == "No")
            {
                rbEmisionNo.Checked = true;
            }
            


            //this.tabControl1.SelectedIndex = 1; //Esto es para que al darle doble click, lleve a la tab de "Mantenimiento"
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }






        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            

            try
            {
            


            if (rbEmisionNo.Checked)
            {
                RespuestaEmision = "No";
            }
            else if (rbEmisionSi.Checked)
            {
                RespuestaEmision = "Si";
            }
            else
            {
                RespuestaEmision = "Sin Seleccionar";
            }



                //La variable que almacena si se insertó
                //o se modificó la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || RespuestaEmision == "Sin Seleccionar" || this.txtPorcentaje.Text == string.Empty || this.txtDireccion.Text == string.Empty || this.txtRIF.Text == string.Empty || this.txtNIT.Text == string.Empty || this.txtContacto.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar una empresa
                        Rpta = MEmpresaSeguro.Insertar(ID, this.txtNombre.Text, Convert.ToDouble(this.txtPorcentaje.Text), Convert.ToInt32(this.txtTipoPrecio.Text), RespuestaEmision, this.txtDireccion.Text, this.txtRIF.Text, this.txtNIT.Text, this.txtContacto.Text);

                    }
                    else
                    { 
                        //Vamos a modificar una empresa
                        Rpta = MEmpresaSeguro.Editar(ID, this.txtNombre.Text, Convert.ToDouble(this.txtPorcentaje.Text), Convert.ToInt32(this.txtTipoPrecio.Text), RespuestaEmision, this.txtDireccion.Text, this.txtRIF.Text, this.txtNIT.Text, this.txtContacto.Text);
                        ID = 0;
                    }


                    //Si la respuesta fue OK, fue porque se modificó
                    //o insertó la empresa
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
                    this.txtNombre.Text = ""; 
                    this.ID = 0;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }









        

    }
}
