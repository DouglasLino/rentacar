using renta_autos.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace renta_autos.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: Vehiculos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarDatos(bool isDelete = false)
        {
            ViewBag.Delete = isDelete;
            using (var context = new Contexto())
            {
                var data = context.Vehiculos.ToList();
                ViewBag.datos = data;

                return View();
            }
        }

        public ActionResult CreateOrUpdateVehiculo(int Id_vehiculo = 0)
        {
            if (Id_vehiculo > 0)
            {
                using (var context = new Contexto())
                {
                    var data = context.Vehiculos.Where(x => x.Id_vehiculo == Id_vehiculo).FirstOrDefault();
                    return View(data);
                }
            }
            else
            {
                Vehiculos model = new Vehiculos();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult CreateOrUpdateVehiculo(Vehiculos model)
        {

            if (ModelState.IsValid)
            {
                //model.Promedio = (model.Nota1 + model.Nota2 + model.Nota3) / 3;
                //model.Estado = model.Promedio >= 6 ? "Aprobado" : "Reprobado";

                var IsNew = model.Id_vehiculo == 0 ? true : false;

                if (IsNew)
                {
                    using (var context = new Contexto())
                    {
                        context.Vehiculos.Add(model);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contexto())
                    {
                        var data = context.Vehiculos.Where(x => x.Id_vehiculo == model.Id_vehiculo).FirstOrDefault();

                        data.Placa = model.Placa;
                        data.Anio = model.Anio;
                        data.Transmision = model.Transmision;
                        data.Precio_hora = model.Precio_hora;
                        data.Estado = model.Estado;
                        data.Id_marca = model.Id_marca;
                        data.Id_modelo = model.Id_modelo;
                        data.Id_tipo_vehiculo = model.Id_tipo_vehiculo;

                        context.SaveChanges();
                    }
                }

                ViewBag.IsNew = IsNew;

                return View("Correcto");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult DeleteVehiculo(int Id_vehiculo)
        {
            using (var context = new Contexto())
            {
                var data = context.Vehiculos.Where(x => x.Id_vehiculo == Id_vehiculo).FirstOrDefault();

                context.Vehiculos.Remove(data);
                context.SaveChanges();
            }

            return RedirectToAction("MostrarDatos", new { isDelete = true });
        }

        public ActionResult ImprimirPDF()
        {
            using (var context = new Contexto())
            {
                var data = context.Vehiculos.ToList();

                ViewBag.datos = data;
            }

            return new ViewAsPdf("IndexPdf")
            {
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins(10, 20, 10, 20),
                FileName = "ListadoVehiculos.pdf"
            };
        }




    }
}