using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodStore_mvc.Models;

namespace FoodStore_mvc.Controllers
{
    public class HomeController : Controller
    {

        List<string> GetStringList()
        {
            List<string> names = new List<string>();
            string[] namesArray = { "John", "Paul", "Ringo", "George" };
            names.InsertRange(0, namesArray);
            return names;
        }

        public ActionResult Index(string fname, string lname, string email, int reps)
        {


      //      string greeting = "";
        //    for (int i = 0; i < reps; i++)
          //  {
            //    greeting += "Hello " + fname +  lname + " at " + email;
           // }
          //  return greeting;


            // Store data with ViewData dictionary.
            ViewData["fname"] = fname;
            ViewData["lname"] = lname;
            ViewData["email"] = email;
            ViewData["reps"] = reps;

            ViewData["my_list"] = GetStringList();

            // Store data using ViewBag properties.
            ViewBag.MyVariableProperty = "ViewBag is a weird name!";
            ViewBag.MyViewBagList = GetStringList();

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
    }
}
