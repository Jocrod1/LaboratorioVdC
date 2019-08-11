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


            dgvExamenes.DataSource = MExamen.Mostrar("");

            //este es el evento load
            /*

            string connectionString = "Data Source= MIRLU-PC\\SQLEXPRESS; Initial Catalog= LabVdC; Integrated Security= true";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Examen", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dgvExamenes.DataSource = dtbl;









                //creando la columna check
                DataGridViewCheckBoxColumn dgvcCheckBox = new DataGridViewCheckBoxColumn();
                dgvcCheckBox.HeaderText = "Seleccionado";

                dgvExamenes.Columns.Add(dgvcCheckBox);


                foreach (DataGridViewColumn column in dgvExamenes.Columns)
                {
                    if (column.Index.Equals(dgvExamenes.Columns.Count - 1)) //aqui se pone que la columna de Seleccionar, se pueda editar
                    {
                        column.ReadOnly = false;
                    }
                    else
                    {
                        column.ReadOnly = true;  ///y las demas no
                    }
                }


            } //fin del using

    */



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

            //aqui va el codigo de pasar registros de un dgv a otro
            //wait for it uwu

        }
                  




    }
}
