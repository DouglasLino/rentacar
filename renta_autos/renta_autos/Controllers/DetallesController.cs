using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using renta_autos.Models;
using Rotativa;

namespace renta_autos.Controllers
{
    public class DetallesController : Controller
    {
        // GET: Detalles
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateUpdate(int Id_alquiler = 0, Vehiculos v= null)
        {

            if(v != null)
            {
                ViewBag.vehiculo = v;
            }

            if (Id_alquiler > 0)
            {
                using (var context = new Contexto())
                {
                    var data = context.Alquileres.Where(x => x.Id_alquiler == Id_alquiler).FirstOrDefault();
                    return View(data);

                }
            }
            else
            {
                Alquiler alquiler = new Alquiler();
                return View(alquiler);
            }
        }


        [HttpPost]
        public ActionResult CreateUpdate(Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                //alquiler.Total = ()

                var Nuevo = alquiler.Id_alquiler == 0 ? true : false;

                if (Nuevo)
                {
                    using (var context = new Contexto())
                    {
                        context.Alquileres.Add(alquiler);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contexto())
                    {
                        var data = context.Alquileres.Where(x => x.Id_alquiler == alquiler.Id_alquiler).FirstOrDefault();
                        data.Cliente = alquiler.Cliente;
                        data.Telefono = alquiler.Telefono;
                        data.Dui = alquiler.Dui;
                        data.Fecha_inicio = alquiler.Fecha_inicio;
                        data.Fecha_fin = alquiler.Fecha_fin;
                        data.Total = alquiler.Total;


                        context.SaveChanges();
                    }

                }

                return View("Enviados");
            }
            else
            {
                return View(alquiler);
            }
        }


        public ActionResult MostrarDetalle()
        {
            using (var context = new Contexto())
            {
                var data = context.Alquileres.ToList();
                ViewBag.datos = data;

                return View();
            }
        }

        public ActionResult Imprimir()
        {
            using (var context = new Contexto())
            {
                var data = context.Alquileres.ToList();
                ViewBag.datos = data;
            }

            return new ViewAsPdf("PDF")
            {
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins(10, 20, 10, 20),
                FileName = "Factura.pdf"
            };
        }

        public ActionResult Alquilar(int Id_vehiculo) {

            using (var context = new Contexto())
            {
              
                var data = context.Vehiculos.Where(x => x.Id_vehiculo == Id_vehiculo).FirstOrDefault();
                data.Estado = false;
                return RedirectToAction("CreateUpdate", data);

            }
        }
    }

}