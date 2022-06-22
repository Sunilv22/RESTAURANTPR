using Microsoft.AspNetCore.Mvc;
using RESTAURANTPROJ.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
namespace RESTAURANTPROJ.Controllers
{
    public class RestaurantController1 : Controller
    {
        restaurantContext dc = new restaurantContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewMenu()
        {
            var res = from t in dc.Menus
                      select t;
            return View(res);

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Registration r)
        {
            if (ModelState.IsValid)
            {
                dc.Registrations.Add(r);
                int c = dc.SaveChanges();
                if (c > 0)
                {
                    ViewData["reg"] = "Registration successfully";
                }
                else
                {
                    ViewData["reg"] = "Sorry! Your Registration failed";
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(string Username,string password)
        {

           var res =(from t in dc.Registrations
                     where t.Username == Username && t.Password == password select t).Count();

            if (res > 0)
            {
               

                ViewData["msg"] = "login successfully";

            }
            else
            {
                ViewData["msg"] = "Invalid User";

            }
            return View();
        }
       
    }
}
