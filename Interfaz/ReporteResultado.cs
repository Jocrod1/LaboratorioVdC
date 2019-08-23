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
    public partial class ReporteResultado : Form
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public ReporteResultado()
        {
            InitializeComponent();
        }

        private void ReporteResultado_Load(object sender, EventArgs e)
        {
            this.reporte_facturaTableAdapter.Fill(this.DataSet.reporte_factura, ID);

            this.reportViewer1.RefreshReport();
        }
    }
}
