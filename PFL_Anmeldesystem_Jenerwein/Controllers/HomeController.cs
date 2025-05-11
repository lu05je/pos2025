using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFL_Anmeldesystem_Jenerwein.Data;
using PFL_Anmeldesystem_Jenerwein.Models;
using System.Diagnostics;

namespace PFL_Anmeldesystem_Jenerwein.Controllers
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

        public async Task<IActionResult> Index()
        {
            var registrations = await _context.Registrations.Include(r => r.Department).ToListAsync();
            return View(registrations);
        }

        public IActionResult Register()
        {
            //neue Registration erstellen & an View liefern
            var registration = new Registration();

            //Abteilungen initialisieren
            registration.DepartmentOptions = new List<SelectListItem>{
                new SelectListItem { Value = "INF", Text = "Informatik" },
                new SelectListItem { Value = "ET", Text = "Elektrotechnik" },
                new SelectListItem { Value = "BT", Text = "Bautechnik" }
              };

            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.RegistrationDate = DateTime.Now;

                var departmentChoice = registration.DepartmentChoice;
                if (!string.IsNullOrEmpty(departmentChoice))
                {
                    //Abteilung in der DB suchen
                    var department = await _context.Departments.FirstOrDefaultAsync(d => d.Name == departmentChoice);
                    if (department == null)
                    {
                        // Falls Abteilung noch nicht existiert, erstellen
                        department = new Department { Name = departmentChoice };
                        _context.Departments.Add(department);
                        await _context.SaveChangesAsync();
                    }
                    registration.DepartmentId = department.Id;
                }

                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(registration);
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
