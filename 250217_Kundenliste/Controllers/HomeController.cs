using _250217_Kundenliste.Data;
using _250217_Kundenliste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _250217_Kundenliste.Controllers
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

        public IActionResult Index()
        {
            //Kunden in der Liste speichern und der View returnen
            var kunden = _context.Kunden.Include(k => k.ArtikelListe).ToList();
            return View(kunden);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kunde kunde)
        {
            //neuen Kunden zur DB hinzufügen
            if(kunde != null)
            {
                _context.Kunden.Add(kunde);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(kunde);
        }

        //den richtigen Kunden anhand der ID finden und returnen
        public IActionResult ManageArticles(int id)
        {
            var kunde = _context.Kunden.Include(k => k.ArtikelListe).FirstOrDefault(k => k.Id == id);
            if (kunde == null) return NotFound();
            return View(kunde);
        }

        [HttpPost]
        public IActionResult AddArticle(int kundeId, Artikel artikel)
        {
            var kunde = _context.Kunden.Include(k => k.ArtikelListe).FirstOrDefault(k => k.Id == kundeId);
            if (kunde == null) return NotFound();

            //Datum auf heute setzen
            artikel.Erstellungsdatum = DateTime.Now;

            //Artikel zur Liste hinzufügen und speichern
            kunde.ArtikelListe.Add(artikel);
            _context.SaveChanges();
            return RedirectToAction("ManageArticles", new { id = kundeId });
        }

        [HttpPost]
        public IActionResult RemoveArticle(int kundeId, int artikelId)
        {
            //Kunden und Artikel finden
            var kunde = _context.Kunden.Include(k => k.ArtikelListe).FirstOrDefault(k => k.Id == kundeId);
            if (kunde == null) return NotFound();
            var artikel = kunde.ArtikelListe.FirstOrDefault(a => a.Id == artikelId);

            //Artikel entfernen und speichern
            if (artikel != null)
            {
                //kunde.ArtikelListe.Remove(artikel);
                _context.Artikel.Remove(artikel);
                _context.SaveChanges();
            }

            return RedirectToAction("ManageArticles", new { id = kundeId });
        }

        [HttpPost]
        public IActionResult EditArticle(int kundeId, Artikel artikel)
        {
            //Kunden und Artikel finden
            var kunde = _context.Kunden.Include(k => k.ArtikelListe).FirstOrDefault(k => k.Id == kundeId);
            if (kunde == null) return NotFound();
            var existingArtikel = kunde.ArtikelListe.FirstOrDefault(a => a.Id == artikel.Id);

            if (existingArtikel == null) return NotFound();

            //Artikel bearbeiten und speichern
            existingArtikel.Name = artikel.Name;
            existingArtikel.Beschreibung = artikel.Beschreibung;
            existingArtikel.Preis = artikel.Preis;
            existingArtikel.Lagerbestand = artikel.Lagerbestand;

            _context.SaveChanges();
            return RedirectToAction("ManageArticles", new { id = kundeId });
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
