using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }




        // weas para que se vea bonito, para que se coloque la descripcion en el txtbox si no se ha rellenado
        private void txtUserEnter(object sender, EventArgs e)
        {
            if(txtboxUsuario.Text.Equals(@"Nombre de usuario"))
            {
                txtboxUsuario.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtboxUsuario.Text.Equals(""))
            {
                txtboxUsuario.Text = @"Nombre de usuario";
            }
        }

        private void txtPassEnter(object sender, EventArgs e)
        {
            if (txtboxContrasena.Text.Equals("Contrasena"))
            {
                txtboxContrasena.Text = "";
            }
        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtboxContrasena.Text.Equals(""))
            {
                txtboxContrasena.Text = "Contrasena";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }




    }
}
