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

            Deshabilitar();



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
            this.txtCiMedico.Enabled = false;
            this.cbCedula.Focus();
        }



        private void Habilitar()
        {
            this.txtCiMedico.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtClinica.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(320, PanelIngreso.Size.Height);
            this.txtNombre.Focus();
        }

        private void Deshabilitar()
        {
            this.txtCiMedico.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtClinica.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
        }

        //Validar datos al ingresar
        private bool validar()
        {

            bool error = true;
            if (txtCiMedico.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtCiMedico, "Inserta una cedula");
            }
            if (txtNombre.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtNombre, "Inserta un nombre");
            }
            if (txtClinica.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtClinica, "Inserta la clinica y Hospital");
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

                    Rpta = MMedico.Insertar(this.ID, (this.cbCedula.Text + this.txtCiMedico.Text), this.txtNombre.Text, this.txtClinica.Text);
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MMedico.Editar(this.ID, (this.cbCedula.Text + this.txtCiMedico.Text), this.txtNombre.Text, this.txtClinica.Text);
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
                this.txtCiMedico.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
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

                this.btnCancelar.Enabled = true;
                btnNuevo.Visible = false;
                PanelIngreso.Size = new Size(320, PanelIngreso.Size.Height);
            }
            else
            {
                this.Deshabilitar();
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                btnNuevo.Visible = true;
                PanelIngreso.Size = new Size(320, PanelIngreso.Size.Height);
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
            dataListado.ClearSelection();
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
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
                    Opcion = MessageBox.Show("¿Realmente Desea Anular el Registro de Medico?", "Laboratorio Clinico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MMedico.Anular(Convert.ToInt32(item.Cells[0].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se Anularon Correctamente los Registros de Medico");
                        }
                        else
                        {
                            this.MensajeOK("Se Anuló Correctamente el Registro del Medico");
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Deshabilitar();
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
            Habilitar();
            this.ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IDMedico"].Value);

            //cedula
            string Cedula = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula"].Value);
            this.cbCedula.Text = Cedula.Substring(0, 2);
            this.txtCiMedico.Text = Cedula.Remove(0, 2);
            //

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtClinica.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClinicaOHospital"].Value);
            Editar();
            txtNombre.Focus();
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
                dataListado.DataSource = MMedico.CedulaUnica((this.cbCedula.Text+this.txtCiMedico.Text));

                if (dataListado.Rows.Count != 0)
                {
                    MessageBox.Show("Ya el Medico C.I: " + (this.cbCedula.Text + this.txtCiMedico.Text) + "está ingresado", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCedula.SelectedIndex!=-1)
            {
                txtCiMedico.Enabled = true;
                txtCiMedico.Focus();
            }
        }

        private void TxtCiMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar Numeros");
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }
    }
}
