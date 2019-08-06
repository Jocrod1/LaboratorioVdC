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
    public partial class Medico : Form
    {
        private int ID;
        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        public Medico()
        {
            InitializeComponent();
        }

        private void Medico_Load(object sender, EventArgs e)
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
 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se insertó
                //o se modificó la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtCiMedico.Text== string.Empty || this.txtClinica.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Medico
                        Rpta = MMedico.Insertar(ID, this.txtCiMedico.Text, this.txtNombre.Text, this.txtClinica.Text);

                    }
                    else
                    {
                        //Vamos a modificar un Medico
                        Rpta = MMedico.Editar(ID, this.txtCiMedico.Text, this.txtNombre.Text, this.txtClinica.Text);
                        ID = 0;
                        
                    }
                    //Si la respuesta fue OK, fue porque se modificó
                    //o insertó el medico
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
                    this.txtCiMedico.Text = "";
                    this.ID = 0;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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




        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;




        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtCiMedico.Focus();
        }



        private void Habilitar()
        {
            this.txtCiMedico.ReadOnly = false;
            this.txtCiMedico.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtClinica.Enabled = true;
            this.txtCiMedico.Focus();
        }

        private void Deshabilitar()
        {
            this.txtCiMedico.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtClinica.Enabled = false;
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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular los " + NumeroSeleccionado + " Registros de Medicos?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Anular el Registro del Medico?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MMedico.Editar(Convert.ToInt32(item.Cells["IDMedico"].Value), Convert.ToString(item.Cells["Cedula"].Value), "ANULADO", "ANULADO");
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

        private void Limpiar()
        {
            //aca hace falta el id del medico para limpiarlo
            this.txtCiMedico.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtClinica.Text = string.Empty;
        }

        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MMedico.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
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
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar los " + NumeroSeleccionado + " Registros de Trabajadores?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar el Registro de Medico?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MMedico.Eliminar(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Eliminaron Correctamente los Registros de Medico");
                        }
                        else
                        {
                            this.MensajeOK("Se Eliminó Correctamente el Registro del Medico");
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




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtCiMedico.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar();
                this.txtCiMedico.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a editar");
            }
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
            
                this.Mostrar();  //buscar por nombre
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
                this.Mostrar();  //buscar por nombre
            
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IDMedico"].Value);
            this.txtCiMedico.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtClinica.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClinicaOHospital"].Value);

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        private void txtCiMedico_Leave(object sender, EventArgs e)
        {
            CedulaUnica();
        }

        private void CedulaUnica()
        {
            try
            {
                if (!IsNuevo)
                    return;
                dataListado.DataSource = MMedico.CedulaUnica(this.txtCiMedico.Text);

                if (dataListado.Rows.Count != 0)
                {
                    MessageBox.Show("Ya el Medico C.I: " + this.txtCiMedico.Text + "está ingresado", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCiMedico.Text = string.Empty;
                    this.txtCiMedico.Focus();
                }

                Mostrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la Conexion de la BD", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
