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
    public partial class Examenes : Form
    {
        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;

        private bool Titulo;

        public Examenes()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.label6, "Laboratorio de referencia");
            this.toolTip1.SetToolTip(this.btnAnular, "Anular");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar");
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
            this.toolTip1.SetToolTip(this.btnNuevo, "Agregar nuevo");
            this.toolTip1.SetToolTip(this.label1, "Valores normales en mujeres");
            this.toolTip1.SetToolTip(this.label5, "Valores normales en hombres");

        }



        private void Examenes_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Deshabilitar();
            this.Botones();


            //combobox
            cbIDGrupoExamen.DataSource=  MGrupoExamen.MostrarCombobox();
            cbIDGrupoExamen.DisplayMember = "Nombre";
            cbIDGrupoExamen.ValueMember = "ID";
            cbIDGrupoExamen.SelectedIndex = -1;

            cbLabRef.DataSource = MLabRef.MostrarCombobox();
            cbLabRef.DisplayMember = "Nombre";
            cbLabRef.ValueMember = "ID";
            cbLabRef.SelectedIndex = -1;
            //


            OcultarColumnas();


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








        // Funciones



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
            this.txtUnidades.Enabled = true;
            this.txtValNorHombres.Enabled = true;
            this.txtValNorMujeres.Enabled = true;
            this.txtPrecio1.Enabled = true;
            this.txtPrecio2.Enabled = true;
            this.dtPlazoEntrega.Enabled = true;
            this.cbIDGrupoExamen.Enabled = true;
            this.rbTituloNo.Enabled = true;
            this.rbTituloSi.Enabled = true;
            this.cbLabRef.Enabled = true;
            this.txtPrecioRef.Enabled = true;
            this.richObservaciones.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(608, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtUnidades.Enabled = false;
            this.txtValNorHombres.Enabled = false;
            this.txtValNorMujeres.Enabled = false;
            this.txtPrecio1.Enabled = false;
            this.txtPrecio2.Enabled = false;
            this.dtPlazoEntrega.Enabled = false;
            this.rbTituloNo.Enabled = false;
            this.rbTituloSi.Enabled = false;
            this.cbIDGrupoExamen.Enabled = false;
            this.cbLabRef.Enabled = false;
            this.txtPrecioRef.Enabled = false;
            this.richObservaciones.Enabled = false;
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
            

            this.txtNombre.Text = string.Empty;
            this.txtUnidades.Text = string.Empty;
            this.txtValNorHombres.Text = string.Empty;
            this.txtValNorMujeres.Text = string.Empty;
            this.txtPrecio1.Text = string.Empty;
            this.txtPrecio2.Text = string.Empty;
            this.dtPlazoEntrega.Text = string.Empty;
            this.cbIDGrupoExamen.SelectedIndex = -1;
            this.cbLabRef.Text = string.Empty;
            this.txtPrecioRef.Text = string.Empty;
            this.richObservaciones.Text = string.Empty;

            
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
            if (txtUnidades.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtUnidades, "Inserta Unidades");
            }
            if (txtValNorHombres.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtValNorHombres, "Inserta un valor");
            }
            if (txtValNorMujeres.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtValNorMujeres, "Inserta un valor");
            }
            if (txtPrecio1.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtPrecio1, "Inserta un precio");
            }
            if (txtPrecio2.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtPrecio2, "Inserta un precio");
            }
            if (cbIDGrupoExamen.Text == "") {
                error = false;
                errorProvider1.SetError(cbIDGrupoExamen, "Selecciona un grupo de examenes");
            }
            if (cbLabRef.Text == "")
            {
                error = false;
                errorProvider1.SetError(cbLabRef, "Selecciona un Laboratorio de Referencia");
            }
            return error;
        }
        //Cuando se llenen, se retira el error
        private void SinErrores()
        {
            errorProvider1.Clear();
        }



        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MExamen.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            Anulados();
        }


        private void Buscar()
        {
            this.Mostrar();
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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MExamen.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de pacientes");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del paciente");
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MExamen.Anular(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de pacientes");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del paciente");
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


                    if (rbTituloSi.Checked == true)
                    {
                        Titulo = true;
                    }
                    else if (rbTituloNo.Checked == true)
                    {
                        Titulo = false;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione si lleva Titulo", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    Rpta = MExamen.Insertar(this.txtNombre.Text, this.txtUnidades.Text, Convert.ToDouble(this.txtValNorHombres.Text), Convert.ToDouble(this.txtValNorMujeres.Text), Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Convert.ToDateTime(dtPlazoEntrega.Text), this.richObservaciones.Text, Convert.ToInt32(cbIDGrupoExamen.SelectedValue), Titulo, Convert.ToInt32(cbLabRef.SelectedValue), Convert.ToInt32(txtPrecioRef.Text));
                }
                else
                {
                    //Vamos a modificar un Paciente
                    Rpta = MExamen.Editar(ID, this.txtNombre.Text, this.txtUnidades.Text, Convert.ToDouble(this.txtValNorHombres.Text), Convert.ToDouble(this.txtValNorMujeres.Text), Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Convert.ToDateTime(dtPlazoEntrega.Text), this.richObservaciones.Text, Convert.ToInt32(cbIDGrupoExamen.SelectedValue), Titulo, Convert.ToInt32(cbLabRef.SelectedValue), Convert.ToInt32(txtPrecioRef.Text));
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
                //this.txtCedula.ReadOnly = true;    no se cual campo poner en readonly en este caso :(
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }





        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false; //ID 
            this.dataListado.Columns[3].Visible = false; //val hombre 
            this.dataListado.Columns[4].Visible = false; //val mujer 
            this.dataListado.Columns[7].Visible = false; //plazo entrega 
            this.dataListado.Columns[8].Visible = false; //observacion 
            this.dataListado.Columns[9].Visible = false; //id grupo 
            this.dataListado.Columns[10].Visible = false; //titulo 
            this.dataListado.Columns[11].Visible = false; //id lab ref 
            this.dataListado.Columns[15].Visible = false;

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
                    dataListado.Rows[fila].Cells["Unidades"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Precio1"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Precio2"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Precio_Referencia"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["GrupoExamen"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["LabRef"].Style.ForeColor = Color.Red;
                    dataListado.Rows[fila].Cells["Nombre"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Unidades"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Precio1"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Precio2"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["Precio_Referencia"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["GrupoExamen"].Style.SelectionBackColor = Color.Brown;
                    dataListado.Rows[fila].Cells["LabRef"].Style.SelectionBackColor = Color.Brown;
                }
            }
        }







        // Eventos






        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

            //EliminarErrores();
            //if (verificacion())
            //{
            //    MessageBox.Show("¡Guardado satisfactoriamente!", "Almacenando...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
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

        private void txtValNorHombres_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            this.Habilitar();

            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);

            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtUnidades.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Unidades"].Value);
            this.txtValNorHombres.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Valor_Hombre"].Value);
            this.txtValNorMujeres.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Valor_Mujer"].Value);
            this.txtPrecio1.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio1"].Value);
            this.txtPrecio2.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio2"].Value);
            this.txtPrecioRef.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio_Referencia"].Value);
            this.richObservaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Observacion"].Value);
            this.cbIDGrupoExamen.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID_Grupo_Examen"].Value);
            this.cbLabRef.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID_Lab_Referencia"].Value);


            if (Convert.ToString(this.dataListado.CurrentRow.Cells["Titulo"].Value) == "True")
            {
                rbTituloSi.Checked = true;
                rbTituloNo.Checked = false;
            }
            else if (Convert.ToString(this.dataListado.CurrentRow.Cells["Titulo"].Value) == "False")
            {
                rbTituloSi.Checked = false;
                rbTituloNo.Checked = true;
            }

            
            txtNombre.Focus();
            Editar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            if (valid.soloLetras(e))
            {
                errorProvider1.SetError(txtNombre, "En este campo solo se pueden ingresar letras");
            }
        }

        private void TxtPrecio1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPrecio1, "");
            if (valid.soloNumerosyPuntos(e))
            {
                errorProvider1.SetError(txtPrecio1, "En este campo solo se pueden ingresar Numeros y puntos");
            }
        }

        private void TxtPrecio2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPrecio2, "");
            if (valid.soloNumerosyPuntos(e))
            {
                errorProvider1.SetError(txtPrecio2, "En este campo solo se pueden ingresar Numeros y puntos");
            }
        }

        private void TxtPrecioRef_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtPrecioRef, "");
            if (valid.soloNumerosyPuntos(e))
            {
                errorProvider1.SetError(txtPrecioRef, "En este campo solo se pueden ingresar Numeros y puntos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

    }
}
