using Infestation.Models.Repositories.Interfaces;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infestation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHumanRepository _humanRepository;
        private readonly ICountryRepository _countryRepository;

        public HomeController(ILogger<HomeController> logger,
            IHumanRepository humanRepository,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            var humans = _humanRepository.GetAllHumans();
            var countries = _countryRepository.GetAllCountries();
            return View(new HomeInfoViewModel { Humans = humans, Countries = countries });
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