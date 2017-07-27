using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercuryNorth.Controllers
{
    public class HomeController : Controller
    {
        Random _random = new Random();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Machine = Environment.MachineName;
            ViewBag.FoundingYear = _random.Next(1940, 1991);
            return View();
        }
    }
}