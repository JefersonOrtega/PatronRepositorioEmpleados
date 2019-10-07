using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public int Sueldo { get; set; }
        public int Incentivo { get; set; }

        public Empleados()
        {
            EmpleadoId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            Sueldo = 0;
            Incentivo = 0;
        }
    }
}
