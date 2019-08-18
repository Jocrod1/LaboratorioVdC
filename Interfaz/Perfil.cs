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
    public partial class Perfil : Form
    {


        private DataTable TablaSeleccionados;
        private DataTable TablaSeleccionados2;

        private bool Titulo;

        //Variable que nos indica si vamos a insertar un nuevo trabajador
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un trabajador
        private bool IsEditar = false;

        private int ID;
        private int IDDetalle;


        DataTable tabla_seleccionados = new DataTable();


        public Perfil()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {

            this.Mostrar();
            this.Deshabilitar();
            this.Botones();

            crearTabla();


            cbLabRef.DataSource = MLabRef.Mostrar("");
            cbLabRef.DisplayMember = "Nombre";
            cbLabRef.ValueMember = "ID";
            cbLabRef.SelectedIndex = -1;


            dgvExamenes.DataSource = MExamen.Mostrar("");




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

        //metodos

        private void crearTabla()
        {



            //esto es para añadir las columnas a la TablaSeleccionados

            this.TablaSeleccionados = new DataTable("Detalle");
            this.TablaSeleccionados.Columns.Add("IDExamen", System.Type.GetType("System.Int32"));
            this.TablaSeleccionados.Columns.Add("Nombre", System.Type.GetType("System.String"));
            //this.TablaSeleccionados.Columns.Add("Precio1", System.Type.GetType("System.String"));
            //this.TablaSeleccionados.Columns.Add("Precio2", System.Type.GetType("System.String"));


            dgvSeleccionados.DataSource = this.TablaSeleccionados;


            //esto es para añadir las columnas a la otra TablaSeleccionados (esto es para buscar por letra en dgvSeleccionados)

            this.TablaSeleccionados2 = new DataTable("Detalle");
            this.TablaSeleccionados2.Columns.Add("IDExamen", System.Type.GetType("System.Int32"));
            this.TablaSeleccionados2.Columns.Add("Nombre", System.Type.GetType("System.String"));
            //this.TablaSeleccionados2.Columns.Add("Precio1", System.Type.GetType("System.String"));
            //this.TablaSeleccionados2.Columns.Add("Precio2", System.Type.GetType("System.String"));


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
                    Opcion = MessageBox.Show("¿Realmente desea eliminar los " + NumeroSeleccionado + " registros de perfiles?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea eliminar el registro del perfil?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MPerfil.Eliminar(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se eliminaron correctamente los registros de perfiles");
                        }
                        else
                        {
                            this.MensajeOK("Se eliminó correctamente el registro del perfil");
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
                    Opcion = MessageBox.Show("¿Realmente desea anular los " + NumeroSeleccionado + " registros de perfiles?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    Opcion = MessageBox.Show("¿Realmente desea anular el registro del perfil?", "Laboratorio Clínico Virgen de Coromoto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";

                    foreach (DataGridViewRow item in this.dataListado.SelectedRows)
                    {
                        Rpta = MPerfil.Anular(Convert.ToInt32(item.Cells["ID"].Value));
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (NumeroSeleccionado > 1)
                        {
                            this.MensajeOK("Se anularon correctamente los registros de perfiles");
                        }
                        else
                        {
                            this.MensajeOK("Se anuló correctamente el registro del perfil");
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


                    //esto es para añadir las columnas a la TablaSeleccionados

                    this.tabla_seleccionados = new DataTable("Detalle");
                    this.tabla_seleccionados.Columns.Add("IDExamen", System.Type.GetType("System.Int32"));


                    //agrega los examenes
                    foreach (DataGridViewRow item in this.dgvSeleccionados.Rows)
                    {
                        tabla_seleccionados.Rows.Add(item.Cells["IDExamen"].Value);
                    }

                    if(rbTituloSi.Checked==true)
                    {
                        Titulo = true;
                    }
                    else if(rbTituloNo.Checked==true)
                    {
                        Titulo = false;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione si lleva Titulo", "Laboratorio Virgen de Coromoto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    Rpta = MPerfil.Insertar( this.txtNombre.Text, Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Titulo, Convert.ToInt32(cbLabRef.SelectedValue), Convert.ToInt32(txtPrecioRef.Text), tabla_seleccionados);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(ID));
                    Rpta = MPerfil.EliminarDetalle(ID);

                    if(Rpta.Equals("OK"))
                    {
                        //Vamos a modificar un Paciente
                        Rpta = MPerfil.Editar(ID, this.txtNombre.Text, Convert.ToDouble(this.txtPrecio1.Text), Convert.ToDouble(this.txtPrecio2.Text), Titulo, Convert.ToInt32(cbLabRef.SelectedValue), Convert.ToInt32(txtPrecioRef.Text), tabla_seleccionados);

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

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
        

        private void Habilitar()
        {
            this.txtNombre.Enabled = true;
            this.cbLabRef.Enabled = true;
            this.txtPrecio1.Enabled = true;
            this.txtPrecio2.Enabled = true;
            this.txtPrecioRef.Enabled = true;
            btnNuevo.Visible = false;
            PanelIngreso.Size = new Size(608, PanelIngreso.Size.Height);
        }

        private void Deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.cbLabRef.Enabled = false;
            this.txtPrecio1.Enabled = false;
            this.txtPrecio2.Enabled = false;
            this.txtPrecioRef.Enabled = false;
            btnNuevo.Visible = true;
            PanelIngreso.Size = new Size(0, PanelIngreso.Size.Height);
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
            this.txtNombre.Text= string.Empty;
            this.cbLabRef.SelectedIndex = -1;
            this.txtPrecio1.Text = string.Empty;
            this.txtPrecio2.Text = string.Empty;
            this.txtPrecioRef.Text = string.Empty;
        }


        private void Mostrar()
        {
            //MUsuario.Mostrar(txtBuscar.Text);

            dataListado.DataSource = MPerfil.Mostrar(txtBuscar.Text);
            dataListado.ClearSelection();
            // this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void txtBuscarExamenes_TextChanged(object sender, EventArgs e)
        {
            dgvExamenes.DataSource = MExamen.Mostrar(txtBuscarExamen.Text);
        }

        private void txtBuscarSeleccionados_TextChanged(object sender, EventArgs e)
        {
            BuscarTabla(txtBuscarSeleccionados.Text);
        }



        private void BuscarTabla(string TextoBuscar)
        {
            dgvSeleccionados.DataSource = null;
            TablaSeleccionados2.Clear();
            foreach (DataRow item in TablaSeleccionados.Rows)
            {
                string Nombre = Convert.ToString(item[0]);
                if (TextoBuscar.Length > 0)
                {
                    if (TextoBuscar.Length <= Nombre.Length)
                    {
                        string NombreCortado = Nombre.Substring(0, TextoBuscar.Length);
                        if (NombreCortado == TextoBuscar)
                        {
                            TablaSeleccionados2.Rows.Add(item[0], item[1]);
                        }
                    }
                }


            }

            if (txtBuscarSeleccionados.Text.Length == 0)
            {
                this.dgvSeleccionados.DataSource = this.TablaSeleccionados;
            }
            else
            {
                this.dgvSeleccionados.DataSource = this.TablaSeleccionados2;
            }

            OcultarColumnasPrecio(Convert.ToInt32(this.cbLabRef.SelectedValue));
        }



        private void OcultarColumnasPrecio(int tipo_precio)
        {
            if (tipo_precio == 1)
            {
                //oculto columnas de precio2

                this.dgvExamenes.Columns[6].Visible = false;
                this.dgvSeleccionados.Columns[2].Visible = false;


            }
            else if (tipo_precio == 2)
            {
                //oculta columnas de precio1
                this.dgvExamenes.Columns[5].Visible = false;
                this.dgvSeleccionados.Columns[1].Visible = false;
            }



        }





        //eventos
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            //agrega los examenes
            foreach (DataGridViewRow item in this.dgvExamenes.SelectedRows)
            {
                TablaSeleccionados.Rows.Add(item.Cells["ID"].Value, item.Cells["Nombre"].Value);
            }


            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dgvSeleccionados.DataSource = this.TablaSeleccionados;


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvSeleccionados.SelectedRows)
            {
                dgvSeleccionados.Rows.RemoveAt(item.Index);
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItems();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Habilitar();

            ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            IDDetalle = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ID"].Value);
            var standard = MPerfil.MostrarDetalle(IDDetalle);

            foreach (var item in standard) {
                TablaSeleccionados.Rows.Add(item.IDExamen, item.NombreExamen);
            }

            //dgvSeleccionados.DataSource = MPerfil.MostrarDetalle(IDDetalle);

            this.cbLabRef.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["LabRef"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtPrecio1.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio1"].Value);
            this.txtPrecio2.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio2"].Value);
            this.cbLabRef.SelectedValue = Convert.ToInt32(this.dataListado.CurrentRow.Cells["LabRef"].Value);
            this.txtPrecioRef.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PrecioRef"].Value);

            if(Convert.ToString(this.dataListado.CurrentRow.Cells["Titulo"].Value)=="True")
            {
                rbTituloSi.Checked = true;
                rbTituloNo.Checked = false;
            }
            else if (Convert.ToString(this.dataListado.CurrentRow.Cells["Titulo"].Value) == "False")
            {
                rbTituloSi.Checked = false;
                rbTituloNo.Checked = true;
            }

            //Editar();
            txtNombre.Focus();
            Editar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularItems();
        }
    }
}
