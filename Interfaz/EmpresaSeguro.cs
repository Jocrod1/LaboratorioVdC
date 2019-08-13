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


        //Limpia los campos
        private void Limpiar()
        {
            //aca hace falta el id de la empresa para limpiarlo
            this.txtNombre.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtRIF.Text = string.Empty;
            this.txtNIT.Text = string.Empty;
            this.txtContacto.Text = string.Empty;
            this.cbEmisionRel.SelectedIndex = -1;
            this.cbTipoPrecio.SelectedIndex = -1;


        }


        private void Mostrar()
        {
            

            dataListado.DataSource = MEmpresaSeguro.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            //this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void MostrarNombre()
        {

            dataListado.DataSource = MEmpresaSeguro.MostrarNombre(txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);

        }



        private void Buscar()
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                this.MostrarNombre();
            }
            else if (cbBuscar.SelectedIndex == 1)
            {
                this.Mostrar();
            }
        }     



        private void Habilitar()
        {
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Enabled = true;
            this.txtPorcentaje.Enabled = true;
            this.cbTipoPrecio.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtRIF.Enabled = true;
            this.txtNIT.Enabled = true;
            this.txtContacto.Enabled = true;
            this.cbEmisionRel.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(350, PanelIngreso.Size.Height);

            this.txtNombre.Focus();

        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtPorcentaje.Enabled = false;
            this.cbTipoPrecio.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtRIF.Enabled = false;
            this.txtNIT.Enabled = false;
            this.cbEmisionRel.Enabled = false;
            this.txtContacto.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
        }






        private void Guardar()
        {





            try
            {



                string Rpta = "";

                if (this.IsNuevo)
                {



                    Rpta = MEmpresaSeguro.Insertar(ID, this.txtNombre.Text, Convert.ToDouble(txtPorcentaje.Text), Convert.ToInt32(this.cbTipoPrecio.Text), this.cbEmisionRel.Text, this.txtDireccion.Text, this.txtRIF.Text, this.txtNIT.Text, this.txtContacto.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MEmpresaSeguro.Editar(ID, this.txtNombre.Text, Convert.ToDouble(txtPorcentaje.Text), Convert.ToInt32(this.cbTipoPrecio.Text), this.cbEmisionRel.Text, this.txtDireccion.Text, this.txtRIF.Text, this.txtNIT.Text, this.txtContacto.Text);
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
                this.txtNombre.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular los " + NumeroSeleccionado + " Registros de Empresas?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro de las empresas?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MEmpresaSeguro.Anular(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de empresas");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del empresas");
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


            this.cbBuscar.SelectedIndex = 0;

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
            this.Deshabilitar();
        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["porcentaje"].Value);
            this.cbTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoPrecio"].Value);
            this.txtRIF.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["RIF"].Value);
            this.txtNIT.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NIT"].Value);
            this.txtContacto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["contacto"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.cbEmisionRel.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["emision"].Value);



        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }






        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Habilitar();
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Porcentaje"].Value);
            this.cbTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoPrecio"].Value);
            this.cbEmisionRel.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Emision"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtRIF.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["RIF"].Value);
            this.txtNIT.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NIT"].Value);
            this.txtContacto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Contacto"].Value);


            Editar();
        }


    }
}
