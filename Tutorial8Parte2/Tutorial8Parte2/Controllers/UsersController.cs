using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutorial8Parte2.Data;
using Tutorial8Parte2.Models;

namespace Tutorial8Parte2.Controllers
{
    public class UsersController : Controller
    {
        private readonly Class8bContext_Database _context;

        public UsersController(Class8bContext_Database context)
        {
            _context = context;
        }

       public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login (string username, string password)
        {
            if(ModelState.IsValid)
            {
                User u = _context.User.SingleOrDefault(u => u.username == username && u.password == password);
                if (u == null)
                    ModelState.AddModelError("username", "username or password are wrong");
                else
                {
                    //the user  is authenticated
                    //the session variable "user" is created to recover the user identify at each request
                    HttpContext.Session.SetString("user", username);
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".Class8b.Session");
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Preferences()
        {
            ViewBag.mode = HttpContext.Request.Cookies["viewMode"] ?? "light";
            return View();
        }

        [HttpPost]
        public IActionResult Preferences(string mode)
        {
            HttpContext.Response.Cookies.Append("viewMode", mode, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
            return RedirectToAction("Index", "Home");
        }

    }
}
