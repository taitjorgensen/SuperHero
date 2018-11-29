using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SuperHeroes! All About SuperHeroes!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We don't have contact info... if necessary, we will contact you.";

            return View();
        }
    }
}