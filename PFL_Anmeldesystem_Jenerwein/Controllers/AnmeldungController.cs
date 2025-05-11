using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFL_Anmeldesystem_Jenerwein.Data;
using PFL_Anmeldesystem_Jenerwein.Models;
using System.Text.Json;

namespace PFL_Anmeldesystem_Jenerwein.Controllers
{
    [Route("api/Anmeldung")]
    [ApiController]
    public class AnmeldungController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnmeldungController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Seed")]
        public async Task<IActionResult> Seed()
        {
            //Prüfen, ob bereits Abteilungen in der DB existieren
            if (_context.Departments.Any())
            {
                return Ok("Datenbank bereits befüllt.");
            }

            //Abteilungen anlegen
            var deptINF = new Department { Name = "INF", Longname = "Die tolle Informatik-Abteilung" };
            var deptET = new Department { Name = "ET", Longname = "Elektrotechnik ist immer cool" };
            var deptBT = new Department { Name = "BT", Longname = "Bautechnik geht auch" };

            _context.Departments.AddRange(deptINF, deptET, deptBT);
            await _context.SaveChangesAsync();

            //Zuordnung von Abteilungskürzel zu Dateinamen
            var deptFiles = new Dictionary<string, (Department department, string filename)>
            {
                { "INF", (deptINF, "INF-Registrations.json") },
                { "ET",  (deptET,  "ET-Registrations.json") },
                { "BT",  (deptBT,  "BT-Registrations.json") }
            };

            foreach (var entry in deptFiles)
            {
                Department department = entry.Value.department;
                string filename = entry.Value.filename;

                if (System.IO.File.Exists(filename))
                {
                    var jsonData = System.IO.File.ReadAllText(filename);
                    var registrations = JsonSerializer.Deserialize<List<Registration>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (registrations != null)
                    {
                        foreach (var reg in registrations)
                        {
                            if (reg.RegistrationDate == DateTime.MinValue)
                            {
                                reg.RegistrationDate = DateTime.Now;
                            }
                            //Setze den Foreign Key explizit und lösche den Navigationsverweis
                            reg.DepartmentId = department.Id;
                            reg.Department = null;
                            _context.Registrations.Add(reg);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
            return Ok("Seed erfolgreich durchgeführt.");
        }

        [HttpGet("GetAllFromDepartments")]
        public async Task<IActionResult> GetAllFromDepartments([FromBody] List<string> departmentNames)
        {
            if (departmentNames == null || departmentNames.Count == 0)
            {
                return BadRequest("Keine Abteilungen angegeben.");
            }

            var departments = await _context.Departments
                .Where(d => departmentNames.Contains(d.Name))
                .Include(d => d.Registrations)
                .ToListAsync();

            return Ok(departments);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
