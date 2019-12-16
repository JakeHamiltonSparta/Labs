using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_32_MVC_Core_Entity_Framework.Models;

namespace Lab_32_MVC_Core_Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        public List<string> MyList = new List<string>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            return View();
        }

        public IActionResult MyData()
        {
            MyList = new List<string>() {"A", "B", "C"};
            return View(MyList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
