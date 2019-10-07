using PatronRepositorio.UI.Consultas;
using PatronRepositorio.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEmpleados rEmpleados = new rEmpleados();
            rEmpleados.MdiParent = this;
            rEmpleados.Show();
        }

        private void EmpleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cEmpleados cEmpleados = new cEmpleados();
            cEmpleados.MdiParent = this;
            cEmpleados.Show();
        }
    }
}
