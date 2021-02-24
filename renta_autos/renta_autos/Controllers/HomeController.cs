﻿using renta_autos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace renta_autos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new Contexto())
            {
                var data = context.Vehiculos.ToList();
                ViewBag.datos = data;

                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}