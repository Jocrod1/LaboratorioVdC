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
    public partial class TipoPaciente : Form
    {

        private int ID;
        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        public TipoPaciente()
        {
            InitializeComponent();
            //Específicaciones de botones
            this.toolTip1.SetToolTip(this.btnAnular, "Anular acción");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
            this.toolTip1.SetToolTip(this.btnNuevo, "Ingresar");
            this.toolTip1.SetToolTip(this.txtBuscar, "Buscador");

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


        private void Habilitar()
        {
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Enabled = true;
            this.txtPorcentaje.Enabled = true;
            this.cbTipoPrecio.Enabled = true;
            this.txtTipoPago.Enabled = true;

            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(349, PanelIngreso.Size.Height);
            this.txtNombre.Focus();

        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtPorcentaje.Enabled = false;
            this.cbTipoPrecio.Enabled = false;
            this.txtTipoPago.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
        }

        
        private void Limpiar()
        {
            //aca hace falta el id de la empresa para limpiarlo
            this.txtNombre.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.cbTipoPrecio.SelectedIndex = -1;
            this.txtTipoPago.Text = string.Empty;
        }



        private void Mostrar()
        {

            dataListado.DataSource = MTipoPaciente.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            Anulados();
        }


        //Validar datos al ingresar
        private bool validar()
        {

            bool error = true;
            if (txtNombre.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtNombre, "Inserta un nombre");
            }
            if (cbTipoPrecio.Text == "")
            {
                error = false;
                errorProvider1.SetError(cbTipoPrecio, "Selecciona un tipo de precio");
            }
            if (txtPorcentaje.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtPorcentaje, "Inserta un porcentaje");
            }
            if (txtTipoPago.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtTipoPago, "Inserta un Tipo de Pago");
            }
            return error;
        }
        //Cuando se llenen, se retira el error
        private void SinErrores()
        {
            errorProvider1.Clear();
        }


        private void Guardar()
        {
            try
            {
                string Rpta = "";

                if (this.IsNuevo)
                {

                    Rpta = MTipoPaciente.Insertar(ID, this.txtNombre.Text, Convert.ToInt32(cbTipoPrecio.Text), Convert.ToDouble(this.txtPorcentaje.Text), this.txtTipoPago.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MTipoPaciente.Editar(ID, this.txtNombre.Text, Convert.ToInt32(cbTipoPrecio.Text), Convert.ToDouble(this.txtPorcentaje.Text), this.txtTipoPago.Text);
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


        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false; //ID 
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[5].Visible = false;

            //renombrar las otras 
            this.dataListado.Columns[1].HeaderText = "Nombre";
            this.dataListado.Columns[2].HeaderText = "Tipo de Precio";
            this.dataListado.Columns[4].HeaderText = "Tipo de Pago";

        }

        private void Anulados()
        {
            string estadotabla;

            for (int fila = 0; fila <= dataListado.Rows.Count - 1; fila++)
            {
                estadotabla = Convert.ToString(this.dataListado.Rows[fila].Cells["Estado"].Value);

                if (estadotabla == "ANULADO")
                {
                    dataListado.Rows[fila].Cells["Nombre"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["TipoPrecio"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["TipoPago"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Nombre"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["TipoPrecio"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["TipoPago"].Style.SelectionBackColor = Color.Brown;
                }
            }
        }



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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular los " + NumeroSeleccionado + " Registros de Tipo de Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente Desea Anular el Registro de los Tipo de Paciente?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MTipoPaciente.Anular(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Anularon Correctamente los Registros de Tipos de Paciente");
                        }
                        else
                        {
                            this.MensajeOK("Se Anuló Correctamente el Registro de Tipos de Paciente");
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

            this.OcultarColumnas();


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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (!validar())
            {
                MensajeError("Falta ingresar algunos datos, serán remarcados");
            }
            else
            {
                Guardar();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["porcentaje"].Value);
            this.cbTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoprecio"].Value);
            this.txtTipoPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipopago"].Value);

       
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
            this.Deshabilitar();
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Habilitar();
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.cbTipoPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoPrecio"].Value);
            this.txtPorcentaje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Porcentaje"].Value);
            this.txtTipoPago.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoPago"].Value);
            Editar();
            txtNombre.Focus();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        private void TxtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPorcentaje, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtPorcentaje, "En este campo solo se pueden ingresar Numeros");
            }
        }

        private void TxtTipoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtTipoPago, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtTipoPago, "En este campo solo se pueden ingresar letras");
            }
        }

    }
}


