//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public Nullable<int> IdSucursal { get; set; }
    
        public virtual Sucursal Sucursal { get; set; }
    }
}
