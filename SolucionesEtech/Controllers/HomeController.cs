using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolucionesEtech.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Viajeros";

            return View();
        }

        public ActionResult Viajes()
        {
            LogicaNegocio.lnAereoPuerto lnAereoPuerto = new LogicaNegocio.lnAereoPuerto();
            ViewBag.AereoPuertos = lnAereoPuerto.ObtenerAereoPuertos();
            ViewBag.Title = "Viajes";

            return View();
        }
    }
}
