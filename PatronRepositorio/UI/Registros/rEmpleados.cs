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

namespace PatronRepositorio.UI.Registros
{
    public partial class rEmpleados : Form
    {
        public rEmpleados()
        {
            InitializeComponent();
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void REmpleados_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            EmpleadoIDnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            NombreTextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;
            
            MyErrorProvider.Clear();
        }


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private Empleados LlenarClase() //del form a la base de datos
        {
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = Convert.ToInt32(EmpleadoIDnumericUpDown.Value);
            empleado.Fecha = FechaDateTimePicker.Value;
            empleado.Nombres = NombreTextBox.Text;
            empleado.Direccion = DirecciontextBox.Text;
            empleado.Telefono = TelefonomaskedTextBox.Text;
            empleado.Celular = CelularmaskedTextBox.Text;
            empleado.Cedula = CedulamaskedTextBox.Text;
            empleado.Sueldo = Convert.ToInt32(SueldotextBox.Text);
            empleado.Incentivo = Convert.ToInt32(IncentivotextBox.Text);
           

            return empleado;
        }

        private void LLenarCampo(Empleados empleado)
        {
            EmpleadoIDnumericUpDown.Value = empleado.EmpleadoId;
            FechaDateTimePicker.Value = empleado.Fecha;
            NombreTextBox.Text = empleado.Nombres;
            DirecciontextBox.Text = empleado.Direccion;
            TelefonomaskedTextBox.Text = empleado.Telefono;
            CelularmaskedTextBox.Text = empleado.Celular;
            CedulamaskedTextBox.Text = empleado.Cedula;
            SueldotextBox.Text = Convert.ToString(empleado.Sueldo);
            IncentivotextBox.Text = Convert.ToString(empleado.Incentivo);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados empleado = repositorio.Buscar((int)EmpleadoIDnumericUpDown.Value);
            return (empleado != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "El campo direccion no pude estar vacio");
                DirecciontextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularmaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CelularmaskedTextBox, "El campo no pude estar vacio");
                DirecciontextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulamaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                MyErrorProvider.SetError(SueldotextBox, "El campo Sueldo no pude estar vacio");
                DirecciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Empleados empleado;
            bool paso = false;

            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            if (!Validar())
                return;

            empleado = LlenarClase();

            //Determinar si es guargar o modificar
            if (EmpleadoIDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(empleado);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un empleado que no existe");
                    return;
                }
                paso = repositorio.Modificar(empleado);

            }

            //Informar el resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(EmpleadoIDnumericUpDown.Text, out id);

            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Limpiar();

            if (repositorio.Buscar(id) != null)
            {
                if (repositorio.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MyErrorProvider.SetError(EmpleadoIDnumericUpDown, "No se puede eliminar un empleado que no existe");
                EmpleadoIDnumericUpDown.Focus();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(EmpleadoIDnumericUpDown.Text, out id);

            Empleados  empleado = new Empleados();

            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            Limpiar();

            empleado = repositorio.Buscar(id);

            if (empleado != null)
            {
                LLenarCampo(empleado);
            }
            else
            {
                MessageBox.Show("Estudiante No encontrado");
            }
        }
    }
}
