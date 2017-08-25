using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mercurynorth_netcore.Models;

namespace mercurynorth_netcore.Controllers
{
    public class HomeController : Controller
    {
        Random _random = new Random();

        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Machine = Environment.MachineName;
            ViewBag.FoundingYear = _random.Next(1940, 1991);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
