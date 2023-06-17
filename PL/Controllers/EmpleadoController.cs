using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Sucursal= new ML.Sucursal();

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            ML.Result resultSucursales = BL.Sucursal.GetAll();
            empleado.Sucursal.Sucursales = resultSucursales.Objects;
            try
            {
                using (var client = new HttpClient())
                {
                    string str = System.Configuration.ConfigurationManager.AppSettings["WebApi"];
                    client.BaseAddress = new Uri(str);

                    var responseTask = client.GetAsync("Empleado/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Empleado resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    empleado.Empleados = result.Objects;
                    empleado.Sucursal.Sucursales = resultSucursales.Objects;
                }

            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return View(empleado);
        }

        [HttpPost]

        public ActionResult GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll(empleado);
            empleado.Sucursal = new ML.Sucursal();
            ML.Result resultSucursales = BL.Sucursal.GetAll();

            if (result.Correct)

            {
                empleado.Empleados = result.Objects;
                empleado.Sucursal.Sucursales = resultSucursales.Objects;

                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }
    }



}