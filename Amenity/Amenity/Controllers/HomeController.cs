using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amenity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Rate myAmenities!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Tweet()
        {
            return View();
        }
    }
}
