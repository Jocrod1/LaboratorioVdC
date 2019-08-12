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
using System.Data.SqlClient;

namespace Interfaz
{
    public partial class Factura : Form
    {


        public Factura()
        {
            InitializeComponent();
        }


        private DataTable TablaSeleccionados;




        private void Factura_Load(object sender, EventArgs e)
        {





            //como comienza el tabcontrol: en examenes y con el btn regresar desactivado
            tabControl1.SelectedIndex = 0;
            this.btnRetroceder.Enabled = false;
            this.btnRetroceder.BackColor = Color.LightGray;
            lblFaseActual.Text = "Exámenes";

            
            //esto es para hacer que los headers del tabcontrol se oculten
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;



            CrearColumnasDgv(); //eso es para cargar los dgv con la bd y añadir las columnas



            crearTabla();


                


        }




        private void CrearColumnasDgv()
        {

            //aqui se carga dgvExamenes con la tabla Examenes
            dgvExamenes.DataSource = MExamen.Mostrar("");


            //// creando la columna check
            // DataGridViewCheckBoxColumn dgvcCheckBox1 = new DataGridViewCheckBoxColumn();
            // dgvcCheckBox1.HeaderText = "Seleccionado";

            // dgvExamenes.Columns.Add(dgvcCheckBox1);

            // foreach (DataGridViewColumn column in dgvExamenes.Columns)
            // {
            //     if (column.Index.Equals(dgvExamenes.Columns.Count - 1)) //aqui se pone que la columna de Seleccionar, se pueda editar
            //     {
            //         column.ReadOnly = false;
            //     }
            //     else
            //     {
            //         column.ReadOnly = true;  ///y las demas no
            //     }
            // }



            //// aqui añado las columnas al otro datagrid dgvSeleccionados

            //DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            //columnaNombre.HeaderText = "Nombre";

            //dgvSeleccionados.Columns.Add(columnaNombre);

            //DataGridViewTextBoxColumn columnaPrecio1 = new DataGridViewTextBoxColumn();
            //columnaPrecio1.HeaderText = "Precio1";

            //dgvSeleccionados.Columns.Add(columnaPrecio1);

            //DataGridViewTextBoxColumn columnaPrecio2 = new DataGridViewTextBoxColumn();
            //columnaPrecio2.HeaderText = "Precio2";

            //dgvSeleccionados.Columns.Add(columnaPrecio2);



            //aqui añado la columna del checkbox al otro datagrid


            //DataGridViewCheckBoxColumn dgvcCheckBox2 = new DataGridViewCheckBoxColumn();
            //dgvcCheckBox2.HeaderText = "Seleccionado";

            //dgvSeleccionados.Columns.Add(dgvcCheckBox2);


            //foreach (DataGridViewColumn column in dgvSeleccionados.Columns)
            //{
            //    if (column.Index.Equals(dgvSeleccionados.Columns.Count - 1)) //aqui se pone que la columna de Seleccionar, se pueda editar
            //    {
            //        column.ReadOnly = false;
            //    }
            //    else
            //    {
            //        column.ReadOnly = true;  ///y las demas no
            //    }
            //}


            //// aqui añado las columnas al otro datagrid dgvResumenExamenes

            //DataGridViewTextBoxColumn columnaNombreR = new DataGridViewTextBoxColumn();
            //columnaNombreR.HeaderText = "Nombre";

            //dgvResumenExamenes.Columns.Add(columnaNombreR);

            //DataGridViewTextBoxColumn columnaPrecio1R = new DataGridViewTextBoxColumn();
            //columnaPrecio1R.HeaderText = "Precio1";

            //dgvResumenExamenes.Columns.Add(columnaPrecio1R);

            //DataGridViewTextBoxColumn columnaPrecio2R = new DataGridViewTextBoxColumn();
            //columnaPrecio2R.HeaderText = "Precio2";

            //dgvResumenExamenes.Columns.Add(columnaPrecio2R);


        }





        private void crearTabla()
        {



            //esto es para añadir las columnas a la TablaSeleccionados

            this.TablaSeleccionados = new DataTable("ExamenesSeleccionados");
            this.TablaSeleccionados.Columns.Add("Nombre", System.Type.GetType("System.String"));
            this.TablaSeleccionados.Columns.Add("Precio1", System.Type.GetType("System.Double"));
            this.TablaSeleccionados.Columns.Add("Precio2", System.Type.GetType("System.Double"));
            
            

            

        }










        private void CargarResumenExamenesSeleccionados() 
        {


            ////esto es para cargar el datagrid (dgvConclusionExamenes) con los datos del otro datagrid (dgvSeleccionados)

            this.dgvResumenExamenes.Rows.Clear();

            this.dgvResumenExamenes.DataSource = this.TablaSeleccionados;
        
        }







        private void CambiarTab(int ValorASumar)
        {
            int tabActual = tabControl1.SelectedIndex;

            int tabSiguiente = tabActual + ValorASumar;

            
            //verificara los extremos
            if (tabSiguiente >= 2) 
            {
                tabControl1.SelectedIndex = 2;
                this.btnContinuar.Enabled = false;   //como llega al tope, se desactiva el boton
                this.btnContinuar.BackColor = Color.LightGray;
                
            }
            else if (tabSiguiente <= 0)
            {
                tabControl1.SelectedIndex = 0;
                this.btnRetroceder.Enabled = false;  //como llega al tope, se desactiva el boton
                this.btnRetroceder.BackColor = Color.LightGray;
            }
            else
            {
                tabControl1.SelectedIndex = tabSiguiente;  //realiza el cambio de tab
                this.btnRetroceder.Enabled = true;               //se activan los botones para que vuelvan a estar normal
                this.btnContinuar.Enabled = true;
                this.btnContinuar.BackColor = Color.PaleGreen;
                this.btnContinuar.ForeColor = Color.DarkGreen;
                this.btnRetroceder.BackColor = Color.PaleGreen;
                this.btnRetroceder.ForeColor = Color.DarkGreen;
                
            }









            // esto es para cambiar el lbl del form

            if (tabControl1.SelectedIndex == 0)
            {
                lblFaseActual.Text = "Exámenes";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                lblFaseActual.Text = "Paciente";
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                lblFaseActual.Text = "Finalizar";


                lblCiPac.Text = (this.cbCedula.Text + this.txtCiPaciente.Text);
                lblNombre.Text = txtNombre.Text;
                //lblPrecioTotal.Text =;

                CargarResumenExamenesSeleccionados(); //esto es para cargar los examenes seleccionados al dgv de la parte Finalizar







            }



        }




        private void Limpiar()
        {
            this.txtCiPaciente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtSexo.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.dateTimePickerFUR.Text = string.Empty;
            this.txtSexo.SelectedIndex = -1;
        }



        private void Guardar()
        {
            try
            {
                string Rpta = "";


                    Rpta = MPaciente.Insertar(this.txtNombre.Text, Convert.ToInt32(txtEdad.Text), this.txtSexo.Text, (this.cbCedula.Text + this.txtCiPaciente.Text), txtTelefono.Text, Convert.ToDateTime(dateTimePickerFUR.Text),"");
                
                //Si la respuesta fue OK, fue porque se modificó
                //o insertó el Trabajador
                //de forma correcta
                
                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            CambiarTab(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CambiarTab(-1);

        }




        private void btnAnadir_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dgvExamenes.SelectedRows)
            {
                TablaSeleccionados.Rows.Add(item.Cells["Nombre"].Value, item.Cells["Precio1"].Value, item.Cells["Precio2"].Value);
            }



            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dgvSeleccionados.DataSource = this.TablaSeleccionados;


            //foreach (DataGridViewRow item in this.dgvExamenes.SelectedRows)
            //{
            //    dgvSeleccionados.Rows.Add(item.Cells["Nombre"].Value, item.Cells["Precio1"].Value, item.Cells["Precio2"].Value);
            //}

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dgvSeleccionados.SelectedRows)
            {
                dgvSeleccionados.Rows.RemoveAt(item.Index);
            }

        }





       

        private void btnImprimir_Click(object sender, EventArgs e)   // Aqui esta la funcion de guardar pac e imprimir
        {


            Guardar(); //aqui esta guardar paciente 


        }

        private void txtBuscarExamen_TextChanged(object sender, EventArgs e)
        {
            dgvExamenes.DataSource = MExamen.Mostrar(txtBuscarExamen.Text);
        }

        private void txtBuscarSeleccionados_TextChanged(object sender, EventArgs e)
        {
            dgvSeleccionados.DataSource = MExamen.Mostrar(txtBuscarSeleccionados.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

                  




    }
}
