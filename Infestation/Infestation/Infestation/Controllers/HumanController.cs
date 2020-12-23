using Infestation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infestation.Controllers
{
    public class HumanController : Controller
    {
        private InfestationDbContext _context { get; }

        public HumanController(InfestationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewData["Humans"] = _context.Humans.Where(human => human.Id == id).ToList();
            return View();
        }

        public IActionResult Country(int humanId)
        {
            var human = _context.Humans.First(human => human.Id == humanId);
            ViewData["CountryName"] = human.Country.Name;
            return View();
        }
    }
}