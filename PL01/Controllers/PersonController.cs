using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PL01.Models;

namespace PL01.Controllers
{
    public class PersonController : Controller
    {
        // GET: PersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(collection["name"]) == true)
        //        {
        //            ModelState.AddModelError("name", "Mandatory Field");
        //        }
        //        if (string.IsNullOrEmpty(collection["age"]) == true)
        //        {
        //            ModelState.AddModelError("age", "Mandatory Field");
        //        }
        //        else
        //        {
        //            int aux;
        //            try
        //            {
        //                aux = int.Parse(collection["age"]);
        //                if (aux < 18 || aux > 100)
        //                {
        //                    ModelState.AddModelError("age", "age should be between 18 and 100");
        //                }
        //            }
        //            catch (FormatException)
        //            {
        //                ModelState.AddModelError("age", "Must indicate an integer value");
        //            }
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            process information
        //            transfers information to another action
        //            TempData["values"] = collection["name"] + " [" + collection["age"] + "]";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            if model has errors, it returns to the form view and show the errors
        //            return View();
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Create(Person NewPerson)
        {
            if (ModelState.IsValid)
            {
                //process information
                //transfers information to another action
                TempData["values"] = NewPerson.Name + " [" + NewPerson.Age + "]";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //if model has errors, it returns to the form view and show the errors
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
