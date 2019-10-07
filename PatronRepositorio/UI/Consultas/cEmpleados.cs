using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio.UI.Consultas
{
    public partial class cEmpleados : Form
    {
        public cEmpleados()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Empleados>();
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        {

                            listado = repositorio.GetList(p => true);
                            break;
                        }

                    case 1: //Id
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = repositorio.GetList(p => p.EmpleadoId == id);
                            break;
                        }

                    case 2: //Nombre
                        {
                            listado = repositorio.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                            break;
                        }

                    case 5: //Cedula
                        {
                            listado = repositorio.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                            break;
                        }

                    case 6: //Sueldo
                        {
                            float sueldo = Convert.ToSingle(CriterioTextBox.Text);
                            listado = repositorio.GetList(p => p.Sueldo == sueldo);
                            break;
                        }
                }
                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
