using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Text.Json;
using Uebung.Data;
using Uebung.Models;

namespace Uebung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public ActionResult UploadJson(HttpPostedFileBase jsonFile)
        {
            if (jsonFile != null && jsonFile.ContentLength > 0)
            {
                try
                {
                    using (var stream = jsonFile.InputStream)
                    {
                        var person = JsonSerializer.Deserialize<Person>(stream);
                        ViewBag.Message = $"Datei erfolgreich geladen: {person.Name}, {person.Alter} Jahre alt.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Fehler beim Verarbeiten der Datei: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Message = "Bitte wählen Sie eine JSON-Datei aus.";
            }

            return View("Index");
        }


        public IActionResult Index()
        {
            var objekte = _context.Objekte.ToList();
            return View(objekte);
        }
        public IActionResult Create()
        {
            var objekt = new Objekt();
            return View(objekt);
        }
        [HttpPost]
        public IActionResult Create(Objekt objekt)
        {
            if(ModelState.IsValid) {
                _context.Objekte.Add(objekt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objekt);
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
