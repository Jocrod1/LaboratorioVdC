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
    public partial class Egresos : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();
        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        public Egresos()
        {
            InitializeComponent();
          
            this.toolTip1.SetToolTip(this.btnAnular, "Anular");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
            this.toolTip1.SetToolTip(this.btnNuevo, "Agregar");
        }

        private void Egresos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
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

        //botones

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar();
            this.txtNombre.Focus();
            ID = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
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
            this.Habilitar();
            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.cbEquivalencia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Equivalencia"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio"].Value);
            this.txtPrecioEmpresa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Empresa"].Value);
            this.txtTipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            this.txtCuentaContable.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cuenta_Contable"].Value);
            Editar();
            this.txtNombre.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        //metodos


        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false; //ID 
            this.dataListado.Columns[7].Visible = false;


            //renombrar las otras 
            this.dataListado.Columns[1].HeaderText = "Nombre Egreso";
            this.dataListado.Columns[4].HeaderText = "Precio para Empresa";
            this.dataListado.Columns[6].HeaderText = "Cuenta Contable";
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
                    dataListado.Rows[fila].Cells["Equivalencia"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Precio"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Precio_Empresa"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Tipo"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Cuenta_Contable"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Nombre"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Equivalencia"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Precio"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Precio_Empresa"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Tipo"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Cuenta_Contable"].Style.SelectionBackColor = Color.Brown;
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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de egresos?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del egreso?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MEgresos.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de egresos");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del egreso");
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros de egresos?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro del egreso?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MEgresos.Anular(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de egresos");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del egreso");
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

                    Rpta = MEgresos.Insertar(this.txtNombre.Text, this.cbEquivalencia.Text, float.Parse(this.txtPrecio.Text), float.Parse(this.txtPrecioEmpresa.Text), Convert.ToInt32(this.txtTipo.Text), float.Parse(this.txtCuentaContable.Text));
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MEgresos.Editar(ID, this.txtNombre.Text, this.cbEquivalencia.Text, float.Parse(this.txtPrecio.Text), float.Parse(this.txtPrecioEmpresa.Text), Convert.ToInt32(this.txtTipo.Text), float.Parse(this.txtCuentaContable.Text));
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
            this.cbEquivalencia.Enabled = true;
            this.txtPrecio.Enabled = true;
            this.txtPrecioEmpresa.Enabled = true;
            this.txtTipo.Enabled = true;
            this.txtCuentaContable.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(362, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.cbEquivalencia.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtPrecioEmpresa.Enabled = false;
            this.txtTipo.Enabled = false;
            this.txtCuentaContable.Enabled = false;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
            btnNuevo.Visible = true;
        }

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

        private void Limpiar()
        {
            ID = 0;
            this.txtNombre.Text = string.Empty;
            this.cbEquivalencia.SelectedIndex = -1;
            this.txtPrecio.Text = string.Empty;
            this.txtPrecioEmpresa.Text = string.Empty;
            this.txtTipo.Text = string.Empty;
            this.txtCuentaContable.Text = string.Empty;
        }

        private void Mostrar()
        {
            dataListado.DataSource = MEgresos.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            Anulados();
        }

        private void Buscar()
        {
            Mostrar();
        }

        private void txtCuentaContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtCuentaContable, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtCuentaContable, "En este campo solo se pueden ingresar números");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar números");
            }
        }

        private void txtPrecioEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPrecioEmpresa, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtPrecioEmpresa, "En este campo solo se pueden ingresar números");
            }
        }


    }
}
