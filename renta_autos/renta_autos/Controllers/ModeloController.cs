using renta_autos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace renta_autos.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateOrUpdateModelos(int Id = 0)
        {
            if (Id > 0)
            {
                using (var context = new Contextoss())
                {
                    var data = context.Modelos.Where(x => x.Id_modelo == Id).FirstOrDefault();
                    return View(data);
                }
            }
            else
            {
                Modelos model = new Modelos();
                return View(model);
            }


        }
        [HttpPost]
        public ActionResult CreateOrUpdateModelos(Modelos model)
        {

            if (ModelState.IsValid)
            {

                var IsNew = model.Id_modelo == 0 ? true : false;

                if (IsNew)
                {
                    using (var context = new Contextoss())
                    {
                        context.Modelos.Add(model);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contextoss())
                    {
                        var data = context.Modelos.Where(x => x.Id_modelo == model.Id_modelo).FirstOrDefault();

                        data.Modelo = model.Modelo;
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
            using (var context = new Contextoss())
            {
                var data = context.Modelos.ToList();
                ViewBag.datos = data;

                return View();
            }
        }
        public ActionResult DeleteModelo(int Id_modelo)
        {
            using (var context = new Contextoss())
            {
                var data = context.Modelos.Where(x => x.Id_modelo == Id_modelo).FirstOrDefault();

                context.Modelos.Remove(data);
                context.SaveChanges();
            }

            return RedirectToAction("MostrarDatos", new { isDelete = true });
        }





    }
}
    
