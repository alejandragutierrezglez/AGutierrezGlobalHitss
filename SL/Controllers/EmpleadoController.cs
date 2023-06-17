using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        // GET: Empleado
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = (empleado.IdEmpleado == null) ? 0 : empleado.IdEmpleado;          
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.Sucursal = new ML.Sucursal();
            empleado.Sucursal.IdSucursal = (empleado.Sucursal.IdSucursal == null) ? 0 : empleado.Sucursal.IdSucursal;
            empleado.FechaInicio = (empleado.FechaInicio == null) ? "" : empleado.FechaInicio;
            empleado.FechaFin = (empleado.FechaFin == null) ? "" : empleado.FechaFin;        

            ML.Result result = BL.Empleado.GetAll(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}