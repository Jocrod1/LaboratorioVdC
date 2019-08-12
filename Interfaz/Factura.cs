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


            CargarResumenExamenesSeleccionados(); //esto es para cargar los examenes seleccionados al dgv de la parte Finalizar


                


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



            // aqui añado las columnas al otro datagrid

            DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            columnaNombre.HeaderText = "Nombre";

            dgvSeleccionados.Columns.Add(columnaNombre);

            DataGridViewTextBoxColumn columnaPrecio1 = new DataGridViewTextBoxColumn();
            columnaPrecio1.HeaderText = "Precio1";

            dgvSeleccionados.Columns.Add(columnaPrecio1);

            DataGridViewTextBoxColumn columnaPrecio2 = new DataGridViewTextBoxColumn();
            columnaPrecio2.HeaderText = "Precio2";

            dgvSeleccionados.Columns.Add(columnaPrecio2);



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

        }








        private void CargarResumenExamenesSeleccionados() 
        {

            //esto es para cargar el datagrid (dgvConclusionExamenes) con los datos del otro datagrid (dgvSeleccionados)

            dgvResumenExamenes.Rows.Clear();

            if (dgvSeleccionados.Rows.Count > 0)
            {
                for (int i = 0; i < dgvSeleccionados.Rows.Count; i++)
                {
                    if (dgvSeleccionados.Rows[i].Cells[0].Value != null)
                    {
                        this.dgvResumenExamenes.Rows.Add();
                        this.dgvResumenExamenes.Rows[i].Cells[0].Value = dgvSeleccionados.Rows[i].Cells[0].Value.ToString();
                        this.dgvResumenExamenes.Rows[i].Cells[1].Value = dgvSeleccionados.Rows[i].Cells[1].Value.ToString();
                        this.dgvResumenExamenes.Rows[i].Cells[2].Value = dgvSeleccionados.Rows[i].Cells[2].Value.ToString();
                    }
                }
            } 
        
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
            }



        }




        private void Mostrar(string buscartxt)
        {
            dgvExamenes.DataSource = MExamen.Mostrar(buscartxt);
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
                dgvSeleccionados.Rows.Add(item.Cells["Nombre"].Value, item.Cells["Precio1"].Value, item.Cells["Precio2"].Value);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dgvSeleccionados.SelectedRows)
            {
                dgvSeleccionados.Rows.RemoveAt(item.Index);
            }

        }


       

        private void btnImprimir_Click(object sender, EventArgs e)
        {





        }

        private void txtBuscarExamen_TextChanged(object sender, EventArgs e)
        {
            Mostrar(txtBuscarExamen.Text);
        }

        private void txtBuscarSeleccionados_TextChanged(object sender, EventArgs e)
        {
            Mostrar(txtBuscarSeleccionados.Text);
        } 
                  




    }
}
