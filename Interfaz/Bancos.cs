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
    public partial class Bancos : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        public Bancos()
        {
            InitializeComponent();
        }

        private void Bancos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
            this.Botones();
        }

        //Botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtNombre.Focus();
        }
        //Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        //Editar
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
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de bancos?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del banco?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MBanco.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Eliminaron Correctamente los Registros de Bancos");
                        }
                        else
                        {
                            this.MensajeOK("Se Eliminó Correctamente el Registro del Banco");
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

                    Rpta = MBanco.Insertar(this.txtNombre.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MBanco.Editar(ID, this.txtNombre.Text);
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
        //

        private void Habilitar()
        {
            this.txtNombre.Enabled = true;
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
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
            ID = 0;
            this.txtNombre.Text = string.Empty;
        }

        private void Mostrar()
        {
            dataListado.DataSource = MBanco.Mostrar(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void Buscar()
        {
            this.Mostrar();
        }




        //validaciones
        private void txtIDBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeros(e);
        }





    }
}
