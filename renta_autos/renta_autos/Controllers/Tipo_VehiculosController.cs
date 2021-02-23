using renta_autos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace renta_autos.Controllers
{
    public class Tipo_VehiculosController : Controller
    {
        // GET: Tipo_Vehiculos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateOrUpdateTipo(int Id = 0)
        {
            if (Id > 0)
            {
                using (var context = new Contexto())
                {
                    var data = context.TipoVehiculos.Where(x => x.Id_tipo_vehiculo == Id).FirstOrDefault();
                    return View(data);
                }
            }
            else
            {
                TipoVehiculos model = new TipoVehiculos();
                return View(model);
            }


        }
        [HttpPost]
        public ActionResult CreateOrUpdateTipo(TipoVehiculos model)
        {

            if (ModelState.IsValid)
            {

                var IsNew = model.Id_tipo_vehiculo == 0 ? true : false;

                if (IsNew)
                {
                    using (var context = new Contexto())
                    {
                        context.TipoVehiculos.Add(model);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contexto())
                    {
                        var data = context.TipoVehiculos.Where(x => x.Id_tipo_vehiculo == model.Id_tipo_vehiculo).FirstOrDefault();

                        data.Tipo_vehiculo = model.Tipo_vehiculo;
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

        public ActionResult MostrarDatos(bool isDelete = false)
        {
            ViewBag.Delete = isDelete;
            using (var context = new Contexto())
            {
                var data = context.TipoVehiculos.ToList();
                ViewBag.datos = data;

                return View();
            }
        }
        public ActionResult DeleteTipo(int Id_tipo_vehiculo)
        {
            using (var context = new Contexto())
            {
                var data = context.TipoVehiculos.Where(x => x.Id_tipo_vehiculo == Id_tipo_vehiculo).FirstOrDefault();

                context.TipoVehiculos.Remove(data);
                context.SaveChanges();
            }

            return RedirectToAction("MostrarDatos", new { isDelete = true });
        }





    }
}