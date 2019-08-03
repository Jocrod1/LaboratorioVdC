﻿using System;
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
    public partial class TipoPaciente : Form
    {

        private int ID;
        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        public TipoPaciente()
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


        private void Habilitar()
        {
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Enabled = true;
            this.txtPorcentaje.Enabled = true;
            this.cbTipoPrecio.Enabled = true;
            this.txtEquiv.Enabled = true;
            this.txtTipoPago.Enabled = true;
            this.txtNoCopias.Enabled = true;

            this.txtNombre.Focus();

        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtPorcentaje.Enabled = false;
            this.cbTipoPrecio.Enabled = false;
            this.txtEquiv.Enabled = false;
            this.txtTipoPago.Enabled = false;
            this.txtNoCopias.Enabled = false;
        }

        
        private void Limpiar()
        {
            //aca hace falta el id de la empresa para limpiarlo
            this.txtNombre.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.cbTipoPrecio.SelectedIndex = -1;
            this.txtEquiv.Text = string.Empty;
            this.txtTipoPago.Text = string.Empty;
            this.txtNoCopias.Text = string.Empty;
        }



        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MTipoPaciente.Mostrar(txtBuscar.Text);
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
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar los " + NumeroSeleccionado + " Registros de Tipo de Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Eliminar el Registro de los Tipo de Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MTipoPaciente.Eliminar(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Eliminaron Correctamente los Registros de Tipos de Paciente");
                        }
                        else
                        {
                            this.MensajeOK("Se Eliminó Correctamente el Registro de Tipos de Paciente");
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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular los " + NumeroSeleccionado + " Registros de Tipo Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Anular el Registro de la Tipo de Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                       // Rpta = MTipoPaciente.Editar(Convert.ToInt32(item.Cells["ID"].Value), "ANULADO", "ANULADO", 0, 0, "ANULADO", 0);
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Anularon Correctamente los Registros de Tipo de paciente");
                        }
                        else
                        {
                            this.MensajeOK("Se Anuló Correctamente el Registro de Tipo de paciente");
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




        private void TipoPaciente_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {



                //La variable que almacena si se insertó
                //o se modificó la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtPorcentaje.Text == string.Empty || this.txtEquiv.Text == string.Empty || this.cbTipoPrecio.SelectedIndex == -1 || this.txtPorcentaje.Text == string.Empty || this.txtTipoPago.Text == string.Empty || this.txtNoCopias.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un tipo de pac
                        Rpta = MTipoPaciente.Insertar(ID, this.txtNombre.Text, this.txtEquiv.Text, Convert.ToInt32(this.cbTipoPrecio.Text), Convert.ToDouble(this.txtPorcentaje.Text), this.txtTipoPago.Text, Convert.ToInt32(this.txtNoCopias.Text));

                    }
                    else
                    {
                        //Vamos a modificar un tipo de pac
                        Rpta = MTipoPaciente.Editar(ID, this.txtNombre.Text, this.txtEquiv.Text, Convert.ToInt32(this.cbTipoPrecio.Text), Convert.ToDouble(this.txtPorcentaje.Text), this.txtTipoPago.Text, Convert.ToInt32(this.txtNoCopias.Text));
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
                    this.txtNombre.Text = ""; //aqui antes estaba "ci medico" y se ponia en blanco por alguna razon
                    this.ID = 0;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtEquiv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["equivalencia"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["porcentaje"].Value);
            this.cbTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoprecio"].Value);
            this.txtNoCopias.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nocopia"].Value);
            this.txtTipoPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipopago"].Value);

            this.tabControl1.SelectedIndex = 1; //Esto es para que al darle doble click, lleve a la tab de "Mantenimiento"
       
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
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

















    }
}


