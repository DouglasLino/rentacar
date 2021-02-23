using renta_autos.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult CreateOrUpdateMarca(int Id=0)
        {
            if (Id > 0)
            {
                using(var context = new Contexto ())
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
                    using (var context = new Contexto())
                    {
                        context.Marcas.Add(model);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contexto())
                    {
                        var data = context.Marcas.Where(x => x.Id_marca == model.Id_marca).FirstOrDefault();

                        data.Marca = model.Marca;
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
        
         public ActionResult MostrarDatos(bool isDelete=false)
        {
            ViewBag.Delete = isDelete;
            using (var context = new Contexto())
            {
                var data = context.Marcas.ToList();
                ViewBag.datos = data;

                return View();
            }
        } 
         public ActionResult DeleteMarca(int id)
        {
            using (var context = new Contexto())
            {
                var data = context.Marcas.Where(x => x.Id_marca == id).FirstOrDefault();

                context.Marcas.Remove(data);
                context.SaveChanges();
            }

            return RedirectToAction("MostrarDatos", new {isDelete=true });
        }

        public ActionResult ImprimirPDF()
        {
            using (var context = new Contexto())
            {
                var data = context.Marcas.ToList();

                ViewBag.datos = data;
            }

            return new ViewAsPdf("IndexPdf")
            {
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins(10,20,10,20),
                FileName = "Notas.pdf"
            };
        }



    }
}