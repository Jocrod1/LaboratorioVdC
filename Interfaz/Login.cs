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
        public Login()
        {
            InitializeComponent();

            txtusuario.Text = @"Numero de Cedula";
            txtcontraseña.Text = "Contraseña";
            txtcontraseña.UseSystemPasswordChar = false;
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
            }
            txtcontraseña.UseSystemPasswordChar = true;

        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals(""))
            {
                txtcontraseña.UseSystemPasswordChar = false;
                txtcontraseña.Text = "Contraseña";
            }
        }

        //Validación de campos del login 
        private bool valid()
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
                errorProvider2.SetError(txtcontraseña, "¡Escribe tu contraseña!");
            }
            return error;
        }
        //Eliminación de los errores 
        private void SinErrores()
        {
            errorProvider1.SetError(txtcontraseña, "");
            errorProvider2.SetError(txtusuario, "");
        } 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SinErrores();
            if (valid())
            {
                MessageBox.Show("¡Ingresando al sistema!", "Accediendo...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 
            Acceso();
        }

        private void Acceso()
        {
            DataTable Datos = MUsuario.Login(this.txtusuario.Text, this.txtcontraseña.Text);

            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("Datos incorrectos o la cuenta no existe", "Laboratorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtcontraseña.Clear();
            }
            else
            {

                string Cedula = Datos.Rows[0][0].ToString();
                string Nombre = Datos.Rows[0][1].ToString();
                string Acceso = Datos.Rows[0][2].ToString();

                MessageBox.Show("Bienvenido/a " + Nombre, "Laboratorio", MessageBoxButtons.OK);

            }
        }

    }
}
