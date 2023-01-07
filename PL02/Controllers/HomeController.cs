using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PL02.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;

namespace PL02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment e)
        {
            _logger = logger;
            _he = e;
        }

        public IActionResult Index()
        {
            DocFiles Files = new DocFiles();
            return View(Files.GetFiles(_he));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile Name)
        {
            if (ModelState.IsValid)
            {
                string destination = Path.Combine(
                        _he.ContentRootPath, "wwwroot/Documents/", Path.GetFileName(Name.FileName));
                FileStream fs = new FileStream(destination, FileMode.Create);
                Name.CopyTo(fs);
                fs.Close();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Download(string id)
        {
            //id is the filename
            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);
            string mimeType;
            new FileExtensionContentTypeProvider().TryGetContentType(id, out mimeType);
            return File(fileBytes, mimeType);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
