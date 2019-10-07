using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();

            empleado.EmpleadoId = 0;
            empleado.Fecha = DateTime.Now;
            empleado.Nombres = "Jose Miguel";
            empleado.Direccion = "Calle Duarte #10";
            empleado.Telefono = "809-577-0333";
            empleado.Celular = "829-687-9863";
            empleado.Cedula = "402-00000000-0";
            empleado.Sueldo = 15000;
            empleado.Incentivo = 2500;
           

            Assert.IsTrue(repositorio.Guardar(empleado));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}