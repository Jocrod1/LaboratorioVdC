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
    public partial class MenuInicio : Form
    {
        private int childFormNumber = 0;

        public static string cedula, nombre, acceso;

        public MenuInicio()
        {
            InitializeComponent();


        }

        private void MenuInicio_Load(object sender, EventArgs e)
        {
            label_cedula.Text=cedula;
            label_nombre.Text=nombre;
            label_acceso.Text = acceso;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void RegistroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Paciente frmPaciente = new Paciente();
            frmPaciente.MdiParent = this;
            frmPaciente.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajador frmtrabajador = new Trabajador();
            frmtrabajador.MdiParent = this;
            frmtrabajador.Show();

        }


        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paciente frm = new Paciente(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void resultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos frm = new CargarDatos(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura frm = new Factura(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Presupuesto frm = new Presupuesto(); //.GetInstancia();
            //frm.MdiParent = this;
            //frm.Show();
            ////frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void exámenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Examenes frm = new Examenes(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfil frm = new Perfil(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void empesasYSegurosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpresaSeguro frm = new EmpresaSeguro(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medico frm = new Medico(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tiposDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoPaciente frm = new TipoPaciente(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tablaDeBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bancos frm = new Bancos(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tablaDeGruposDeExámenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrupoExamen frm = new GrupoExamen(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tablaDeLabReferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabRef frm = new LabRef(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tablaDeEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Egresos frm = new Egresos(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void tablaDeBioanalistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bioanalista frm = new Bioanalista(); //.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            //frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }





    }
}
