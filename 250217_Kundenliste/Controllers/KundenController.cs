using _250217_Kundenliste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using _250217_Kundenliste.Data;
using Microsoft.EntityFrameworkCore;

namespace _250217_Kundenliste.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class KundenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KundenController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Init Methode
        [HttpPost("Init")]
        public IActionResult Init()
        {
            //Prüfen, ob "kunden-artikel.json" existiert
            if (!System.IO.File.Exists("kunden-artikel.json"))
            {
                return NotFound("File not found");
            }

            //wenn ja, Daten deserialisieren und in DB speichern
            var jsonData = System.IO.File.ReadAllText("kunden-artikel.json");
            var kunden = JsonSerializer.Deserialize<List<Kunde>>(jsonData);

            if (kunden != null)
            {
                _context.Kunden.AddRange(kunden);
                _context.SaveChanges();
            }

            return Ok("Initialized");
        }

        //Get Methode
        [HttpGet]
        public IActionResult GetKunden()
        {
            //Die ersten 10 Kunden aus der Datenbank zurückgeben
            var kunden = _context.Kunden.Include(k => k.ArtikelListe).Take(10).ToList();
            if (kunden == null || kunden.Count == 0)
            {
                return NotFound("Keine Kunden gefunden.");
            }
            return Ok(kunden);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
