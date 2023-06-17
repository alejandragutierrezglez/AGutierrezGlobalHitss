using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Empleado resEmpleado = new ML.Empleado();
            empleado.IdEmpleado = (empleado.IdEmpleado == null) ? 0 : empleado.IdEmpleado;
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.Sucursal.IdSucursal = (empleado.Sucursal.IdSucursal == null) ? 0 : empleado.Sucursal.IdSucursal;
            empleado.FechaInicio = (empleado.FechaInicio == null) ? "" : empleado.FechaInicio;
            empleado.FechaFin = (empleado.FechaFin == null) ? "" : empleado.FechaFin;

            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezGlobalHitssEntities context = new DL.AGutierrezGlobalHitssEntities())
                {
                    var query = context.EmpleadoGetAll(empleado.IdEmpleado, empleado.Nombre, empleado.Sucursal.IdSucursal,empleado.FechaInicio, empleado.FechaFin).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            empleado = new ML.Empleado();
                            empleado.IdEmpleado = item.IdEmpleado;
                            empleado.Nombre = item.Nombre;
                            empleado.Apellidos = item.Apellidos;
                            empleado.Direccion = item.Direccion;
                            empleado.Edad = item.Edad.Value;
                            empleado.Telefono = item.Telefono;
                            empleado.Sexo = item.Sexo;
                            empleado.FechaIngreso = item.FechaIngreso.Value;
                            empleado.Salario = item.Salario.Value;

                            empleado.Sucursal = new ML.Sucursal();
                            empleado.Sucursal.IdSucursal = item.IdSucursal;
                            empleado.Sucursal.Nombre = item.NombreSucursal;

                            result.Objects.Add(empleado);
                            result.Correct = true;

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
    }
}
