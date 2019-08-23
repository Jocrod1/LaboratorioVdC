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
    public partial class Login : Form
    {

        LimitantesDeIngreso valid = new LimitantesDeIngreso();

        private bool ojos = true;
        public Login()
        {
            InitializeComponent();

            this.toolTip1.SetToolTip(this.pictureBox1, "Cédula");
            this.toolTip1.SetToolTip(this.pictureBox2, "Contraseña");
            this.toolTip1.SetToolTip(this.mostrar_contraseña, "Mostrar");
            
            

            txtusuario.Text = @"Numero de Cedula";
            txtcontraseña.Text = "Contraseña";
            txtcontraseña.UseSystemPasswordChar = false;

            txtusuario.Focus();
        }
        // weas para que se vea bonito, para que se coloque la descripcion en el txtbox si no se ha rellenado
        private void txtUserEnter(object sender, EventArgs e)
        {
            if(txtusuario.Text.Equals(@"Numero de Cedula"))
            {
                txtusuario.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtusuario.Text.Equals(""))
            {
                txtusuario.Text = @"Numero de Cedula";
            }
        }

        private void txtPassEnter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals("Contraseña"))
            {
                txtcontraseña.Text = "";
                txtcontraseña.UseSystemPasswordChar = true;
            }
            mostrar_contraseña.Visible = true;



        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals(""))
            {
                txtcontraseña.UseSystemPasswordChar = false;
                txtcontraseña.Text = "Contraseña";

            }
            ojos = false;
            mostrar_contraseña.Visible = false;

        }

        //Validación de campos del login 
        private bool validar()
        {
            bool error = true;
            if (txtusuario.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtusuario, "Agrega tu nombre de usuario");
            }
            if (txtcontraseña.Text == "")
            {
                error = false;
                errorProvider1.SetError(txtcontraseña, "¡Escribe tu contraseña!");
            }
            return error;
        }
        //Eliminación de los errores 
        private void SinErrores()
        {
            errorProvider1.Clear();
        } 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acceso();
        }

        private void Acceso()
        {
            SinErrores();
            if (validar())
            {
                MessageBox.Show("¡Ingresando al sistema!", "Accediendo...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 

            DataTable Datos = MUsuario.Login((this.cbCedula.Text+this.txtusuario.Text), this.txtcontraseña.Text);

            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("Datos incorrectos o la cuenta no existe", "Laboratorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtcontraseña.Clear();
            }
            else
            {
                var lista = MTurno.Mostrar("");

                TimeSpan hora = DateTime.Now.TimeOfDay;

                bool isbetween;
                int IDTurno = 0;

                foreach (var item in lista)
                {
                    isbetween = item.Comienzo < hora && hora < item.Final;
                    if (isbetween)
                    {
                        IDTurno = item.ID;
                        break;
                    }
                }
                if (IDTurno == 0) {
                    IDTurno = 1;
                }

                MRegistroAcceso.Insertar(0, Datos.Rows[0][0].ToString(), IDTurno, DateTime.Now);

                MenuInicio.cedula = Datos.Rows[0][0].ToString();
                MenuInicio.nombre = Datos.Rows[0][1].ToString();
                MenuInicio.acceso = Datos.Rows[0][2].ToString();

                //esto es para ponerle valor en factura al id del trabajador
                //Factura.id_trabajador= Datos.Rows[0][0].ToString();

                MessageBox.Show("Bienvenido/a " + Datos.Rows[0][1].ToString(), "Laboratorio", MessageBoxButtons.OK);

                MenuInicio Menu = new MenuInicio();
                Menu.Show();
                Menu.WindowState = FormWindowState.Maximized;
                this.Hide();

            }
        }

        private void mostrar_contraseña_Click(object sender, EventArgs e)
        {


            if(ojos==true)
            {
                mostrar_contraseña.BackgroundImage = Properties.Resources.substract;
                txtcontraseña.UseSystemPasswordChar = false;
                ojos = false;
            }
            else
            {
                mostrar_contraseña.BackgroundImage = Properties.Resources.view;
                txtcontraseña.UseSystemPasswordChar = true;
                ojos = true;
            }

        }

        private void txtcontraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Acceso();
            }
        }

        private void txtusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcontraseña.Focus();
            }
        }

        private void cbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCedula.SelectedIndex!=-1)
            {
                txtusuario.Enabled = true;
                txtusuario.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtusuario.Focus();
        }

        private void Txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(txtusuario, "");
            if (valid.soloNumeros(e))
            {
                errorProvider1.SetError(txtusuario, "En este campo solo se pueden ingresar números");
            }
        }
    }
}
