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
using System.Data.SqlClient;

namespace Interfaz
{
    public partial class Factura : Form
    {

        public DateTime ValorFUR;

        public int Edad;

        public int IDPacienteActual = 0;

        public string CedulaCompleta;

        public Factura()
        {
            InitializeComponent();
        }


        private DataTable TablaSeleccionados;
        private DataTable TablaSeleccionados2;


        private DataTable TablaResultadosCI;


        private void Factura_Load(object sender, EventArgs e)
        {


            cbTipoPaciente.DataSource = MTipoPaciente.Mostrar("");
            cbTipoPaciente.DisplayMember = "Nombre";
            cbTipoPaciente.ValueMember = "ID";
            cbTipoPaciente.SelectedIndex = -1;


            cbMedico.DataSource = MMedico.Mostrar("");
            cbMedico.DisplayMember = "Nombre";
            cbMedico.ValueMember = "IdMedico";
            cbMedico.SelectedIndex = -1;

            cbIdEmpresa.DataSource = MEmpresaSeguro.Mostrar("");
            cbIdEmpresa.DisplayMember = "Nombre";
            cbIdEmpresa.ValueMember = "ID";
            cbIdEmpresa.SelectedIndex = -1;

            cbIdBanco.DataSource = MBanco.Mostrar("");
            cbIdBanco.DisplayMember = "Nombre";
            cbIdBanco.ValueMember = "ID";
            cbIdBanco.SelectedIndex = -1;



            lblMotivo.Hide();   //oculta el motivo, para luego que se seleccione el rb si/no
            txtMotivo.Hide();



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

            dgvPerfiles.DataSource = MPerfil.Mostrar("");



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

            dgvSeleccionados.DataSource = this.TablaSeleccionados;


            //esto es para añadir las columnas a la otra TablaSeleccionados (esto es para buscar por letra en dgvSeleccionados

            this.TablaSeleccionados2 = new DataTable("ExamenesSeleccionados2");
            this.TablaSeleccionados2.Columns.Add("Nombre", System.Type.GetType("System.String"));
            this.TablaSeleccionados2.Columns.Add("Precio1", System.Type.GetType("System.Double"));
            this.TablaSeleccionados2.Columns.Add("Precio2", System.Type.GetType("System.Double"));

            

        }




        private void CargarResumenExamenesSeleccionados() 
        {

            ////esto es para cargar el datagrid (dgvConclusionExamenes) con los datos del otro datagrid (dgvSeleccionados)

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

                OcultarColumnasPrecio(Convert.ToInt32(cbTipoPaciente.SelectedValue));
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
            this.dtNacimiento.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.dateTimePickerFUR.Text = string.Empty;
            this.txtSexo.SelectedIndex = -1;
        }



        private void Guardar()
        {

            CedulaCompleta = this.cbCedula.Text + this.txtCiPaciente.Text;

            try
            {
                string Rpta = "";

                Rpta = MPaciente.Insertar(this.txtNombre.Text, Convert.ToDateTime(dtNacimiento.Text), this.txtSexo.Text, (this.cbCedula.Text + this.txtCiPaciente.Text), txtTelefono.Text, ValorFUR);


                //Si la respuesta fue OK, fue porque se modificó
                //o insertó el Trabajador
                //de forma correcta
                
                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }



            try
            {
                string Rpta2 = "";

                IDPacienteActual = MPaciente.CedulaUnica(CedulaCompleta)[0].IdPaciente;

                //terminar lo siguiente, cuando ya tenga todo lo de orden listo. porque hay que ingresar orden antes, para tener la IdOrden

                //Rpta2 = MFactura.Insertar(IDPacienteActual, Convert.ToInt32(this.cbTipoPaciente.SelectedValue), Convert.ToInt32(cbIdEmpresa.SelectedValue), 69,  );

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




        private void OcultarColumnasPrecio(int tipo_precio)
        {
                if (tipo_precio==1)
                {
                    //oculto columnas de precio2
                    
                    this.dgvExamenes.Columns[6].Visible = false;
                    this.dgvSeleccionados.Columns[2].Visible = false; 
                    
                       
                }
                else if (tipo_precio==2)
                {
                    //oculta columnas de precio1
                    this.dgvExamenes.Columns[5].Visible = false;
                    this.dgvSeleccionados.Columns[1].Visible = false; 
                }
            


            //extraer todos los registros de TipoPaciente (en un data table maybe?)
            //hacer un loop donde trate de coincidir el nombre que esta en la tabla con el nombre que esta seleccionado en el cb
            //y luego de eso se hace un if donde observa cual es el precio, y de una vez ocultara las columnas correspondientes

            //usar esto mismo para sumar los precios para sacar el total

            //if (precio == 1)
            //{

            //    //ocultar columnas de precio 2

            //}
            //else if (precio == 2)
            //{

            //    //ocultar columnas de precio 1

            //}

        }



        private void CalcularEdad()
        {
            DateTime FechaActual = DateTime.Now.Date;
            MessageBox.Show("La fecha de hoy es: " + FechaActual.ToString("dd/mm/yyyy") + "");
            DateTime Nacimiento = DateTime.Parse(dtNacimiento.Text);
            Edad = FechaActual.Year - Nacimiento.Year;

            if (FechaActual.Month < Nacimiento.Month)
            {
                Edad--;
            }
            else if ((FechaActual.Month == Nacimiento.Month)
                       && (FechaActual.Day < Nacimiento.Day))
            {
                Edad--;
            }


            MessageBox.Show("Su edad es: " + Edad + " :) ");


        }


        private void OcultarFUR()
        {


            if (txtSexo.Text == "Femenino" && !chkFUR.Checked)  // no tiene FUR
            {
                ValorFUR = Convert.ToDateTime(null);
                dateTimePickerFUR.Hide();
                dateTimePickerFUR.Enabled = false;
                chkFUR.Enabled = true;
            }
            else if (txtSexo.Text == "Femenino" && chkFUR.Checked)  // si tiene FUR
            {
                ValorFUR = Convert.ToDateTime(dateTimePickerFUR.Text);
                dateTimePickerFUR.Show();
                dateTimePickerFUR.Enabled = true;
                chkFUR.Enabled = true;
            }


            if (txtSexo.Text == "Masculino")  //si es un hombre
            {
                ValorFUR = Convert.ToDateTime(null);
                chkFUR.Checked = false;
                chkFUR.Enabled = false;
                dateTimePickerFUR.Hide();

            }

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
                            TablaSeleccionados2.Rows.Add(item[0], item[1], item[2]);
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

            OcultarColumnasPrecio(Convert.ToInt32(this.cbTipoPaciente.SelectedValue));
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



            //agrega los examenes
            foreach (DataGridViewRow item in this.dgvExamenes.SelectedRows)
            {
                TablaSeleccionados.Rows.Add(item.Cells["Nombre"].Value, item.Cells["Precio1"].Value, item.Cells["Precio2"].Value);
            }
            

            //agrega los perfiles
            foreach (DataGridViewRow item in this.dgvPerfiles.SelectedRows)
            {
                TablaSeleccionados.Rows.Add(item.Cells["Nombre"].Value, item.Cells["Precio1"].Value, item.Cells["Precio2"].Value);
            }

            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dgvSeleccionados.DataSource = this.TablaSeleccionados;



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
            BuscarTabla(txtBuscarSeleccionados.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtCiPaciente_Leave(object sender, EventArgs e)
        {
            

            //buscar en la DB si ya existe esta ci

                int cant_registros;

                cant_registros = MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text).Count;

                if (cant_registros != 0)
                {
                    DialogResult respuesta = MessageBox.Show("Ya el Paciente C.I: " + (this.cbCedula.Text + this.txtCiPaciente.Text) + " está ingresado. \n ¿Desea cargar los datos del paciente existente? ", "Laboratorio Virgen de Coromoto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (respuesta == DialogResult.Yes)
                    {

                        this.TablaResultadosCI = new DataTable("ResultadoCI");
                        this.TablaResultadosCI.Columns.Add("Nombre", System.Type.GetType("System.String"));
                        this.TablaResultadosCI.Columns.Add("Precio1", System.Type.GetType("System.Double"));
                        this.TablaResultadosCI.Columns.Add("Precio2", System.Type.GetType("System.Double"));

                        
                        txtNombre.Text = MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text)[0].Nombre;
                        txtSexo.Text = MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text)[0].Sexo;
                        txtTelefono.Text = MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text)[0].Telefono;

                        this.chkFUR.Enabled = true;
                        this.dateTimePickerFUR.Enabled = true;


                        if (Convert.ToDateTime(MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text)[0].FUR) == Convert.ToDateTime(null))  // si no hay FUR 
                        {

                            this.chkFUR.Checked = false;
                            this.dateTimePickerFUR.Hide();

                        }
                        else   // si hay algun valor en FUR
                        {
                            this.chkFUR.Checked = true;
                            this.dateTimePickerFUR.Show();
                            this.dateTimePickerFUR.Text = Convert.ToString(Convert.ToDateTime(MPaciente.CedulaUnica(this.cbCedula.Text + this.txtCiPaciente.Text)[0].FUR));
                        }



                    }
                    else if (respuesta == DialogResult.No)
                    {
                        txtCiPaciente.Focus();
                    }


                }

        


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dgvSeleccionados.SelectedRows)
            {
                dgvSeleccionados.Rows.RemoveAt(item.Index);
            }

        }

        private void txtSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarFUR();
        }

        private void dtNacimiento_Leave(object sender, EventArgs e)
        {
            CalcularEdad();
        }

        private void chkFUR_CheckedChanged(object sender, EventArgs e)
        {
            OcultarFUR();
        }

        private void dateTimePickerFUR_ValueChanged(object sender, EventArgs e)
        {
            OcultarFUR();
        }

        private void lblExoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (lblExoSi.Checked == true)
            {
                lblMotivo.Show();
                txtMotivo.Show();

                rbContado.Enabled = false;
                rbCredito.Enabled = false;

                cbIdBanco.Enabled = false;
                txtNumCHoT.Enabled = false;
                txtRecEmergencia.Enabled = false;
                txtDescuento.Enabled = false;
                txtAbonar.Enabled = false;
            }
        }

        private void lblExoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (lblExoNo.Checked == true)
            {
                txtMotivo.Clear();
                lblMotivo.Hide();
                txtMotivo.Hide();

                rbContado.Enabled = true;
                rbCredito.Enabled = true;

                cbIdBanco.Enabled = true;
                txtNumCHoT.Enabled = true;
                txtRecEmergencia.Enabled = true;
                txtDescuento.Enabled = true;
                txtAbonar.Enabled = true;

            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
                dgvPerfiles.ClearSelection();

                dgvExamenes.ClearSelection();
            

        }

        
                  




    }
}
