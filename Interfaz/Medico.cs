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
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        public Medico()
        {
            InitializeComponent();
        }

       


        private bool validarr()
        {
            bool error = true;
            if (txtCiMedico.Text == "")
            {
                error = false;
                err1.SetError(txtCiMedico, "Cédula del médico");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                err2.SetError(txtNombre, "No olvides el nombre del médico");
            }
            if (txtContrasena.Text == "")
            {
                error = false;
                err3.SetError(txtContrasena, "Crea una contraseña que no puedas olvidar");
            }
            if (richDireccion.Text == "")
            {
                error = false;
                err4.SetError(richDireccion, "Escribe una dirección");
            }
            if (txtTelefono.Text == "")
            {
                error = false;
                err5.SetError(txtTelefono, "Inserta un número telefónico");
            }
            if (txtCorreo.Text == "")
            {
                error = false;
                err6.SetError(txtCorreo, "Agrega un correo electrónico");
            }
            if (cbAcceso.Text == "")
            {
                error = false;
                err7.SetError(cbAcceso, "Selecciona su nivel de acceso.");
            }
            return error;
        }
        //Eliminación de los errores 
        private void ChaoErr()
        {
            err1.SetError(txtCiMedico, "");
            err2.SetError(txtNombre, "");
            err3.SetError(txtContrasena, "");
            err4.SetError(richDireccion, "");
            err5.SetError(txtTelefono, "");
            err6.SetError(txtCorreo, "");
            err7.SetError(cbAcceso, "");
        } 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ChaoErr();
            if (validarr())
            {
                MessageBox.Show("¡Guardado en la base de datos!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            this.Habilitar(true);
            this.txtNombre.Focus();
        }




        private void Limpiar()
        {
            this.txtCiMedico.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.richDireccion.Text = string.Empty;
            this.txtContrasena.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;

        }



        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtCiMedico.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.richDireccion.ReadOnly = !Valor;
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
                        Rpta = MMedico.Eliminar(item.Cells[0].Value);
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




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
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
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
        }




        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MMedico.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }











    }
}
