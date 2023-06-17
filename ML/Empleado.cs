using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public int? IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal Salario { get; set; }
        public List<object> Empleados { get; set; }
        public ML.Sucursal Sucursal { get; set; }
        
    }
}
