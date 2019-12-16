using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_27_MVC_Core.Models;

namespace Lab_27_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        // MVC didnt like the list being static
        public static List<string> MyList = new List<string>();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MyAction()
        {
            ViewBag.MyItem = "This is some data";
            ViewData["AnotherItem"] = "And some more data";

            MyList.Add("List Item 1");
            MyList.Add("List Item 2");
            MyList.Add("List Item 3");
            MyList.Add("List Item 4");

            ViewBag.myList = MyList;

            return View(MyList);
        }
    }
}