using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PL01.Controllers
{
    public class ExemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection formData)
        {
            //action used to process the form submission
            ViewData["text_inserted"] = formData["name"]; //tranfer data to the view 
            ViewData["other_text_inserted"] = formData["age"];

            return View("Index2"); //uses another view  instead of using the default view name
                                   //ususally the same name  as the method - Index
        }
        public string Exemplo()
        {
            return "Isto é um exemplo.";
        }
        public IActionResult Exemplo02()
        {
            return View();
        }
    }
}
