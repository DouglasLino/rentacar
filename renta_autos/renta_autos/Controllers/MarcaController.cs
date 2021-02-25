using renta_autos.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace renta_autos.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrUpdateMarca(int Id = 0)
        {
            if (Id > 0)
            {
                using (var context = new Contextoss())
                {
                    var data = context.Marcas.Where(x => x.Id_marca == Id).FirstOrDefault();
                    return View(data);
                }
            }
            else
            {
                Marcas model = new Marcas();
                return View(model);
            }


        }
        [HttpPost]
        public ActionResult CreateOrUpdateMarca(Marcas model)
        {

            if (ModelState.IsValid)
            {

                var IsNew = model.Id_marca == 0 ? true : false;

                if (IsNew)
                {
                    using (var context = new Contextoss())
                    {
                        context.Marcas.Add(model);
                        context.SaveChanges();
                        ViewBag.IsNew = IsNew;
                        Thread.Sleep(2000);
                        return RedirectToAction("CreateOrUpdateMarca");
                    }
                }
                else
                {
                    using (var context = new Contextoss())
                    {
                        var data = context.Marcas.Where(x => x.Id_marca == model.Id_marca).FirstOrDefault();

                        data.Marca = model.Marca;
                        context.SaveChanges();
                        ViewBag.IsNew = IsNew;
                        Thread.Sleep(2000);
                        return RedirectToAction("MostrarDatos");
                    }
                }


                // Marcas m = new Marcas()

            }
            else
            {
                return View(model);
            }



        }

        public ActionResult MostrarDatos()
        {

            using (var context = new Contextoss())
            {
                var data = context.Marcas.ToList();
                ViewBag.datos = data;

                return View();
            }
        }
        public ActionResult DeleteMarca(int id_marca)
        {
            using (var context = new Contextoss())
            {
                var data = context.Marcas.Where(x => x.Id_marca == id_marca).FirstOrDefault();

                context.Marcas.Remove(data);
                context.SaveChanges();
            }
            Thread.Sleep(1000);
            return RedirectToAction("MostrarDatos");
        }





    }
}