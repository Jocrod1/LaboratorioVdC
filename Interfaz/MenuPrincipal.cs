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
    public partial class MenuPrincipal : Form
    {
        private Boolean Arrastrar = false;
        private int MouseDownX;
        private int MouseDownY;

        public MenuPrincipal()
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Barra_MouseDown(object sender, MouseEventArgs e)
        {
            Arrastrar = true;
            MouseDownX = e.X;
            MouseDownY = e.Y;
        }
        private void Barra_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastrar = false;
        }
        private void Barra_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastrar == true)
            {
                Point temp = new Point();
                temp.X = this.Location.X + (e.X - MouseDownX);
                temp.Y = this.Location.Y + (e.Y - MouseDownY);
                this.Location = temp;
            }
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            tiempo_continuo.Start();
        }

        private void tiempo_continuo_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnregistrar_compra_Click(object sender, EventArgs e)
        {
        }

        private void btnarticulos_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
