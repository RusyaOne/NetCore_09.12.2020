using Infestation.Models;
using Infestation.Models.Repositories;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Infestation.Controllers
{
    public class HumanController : Controller
    {
        private readonly IHumanRepository _humanRepository;
        private readonly ICountryRepository _countryRepository;

        public HumanController(IHumanRepository humanRepository,
            ICountryRepository countryRepository)
        {
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index(int? humanId)
        {
            IEnumerable<HumanIndexViewModel> humans;

            if (humanId == null)
            {
                humans = _humanRepository.GetAllHumans().Select(
                    human => new HumanIndexViewModel 
                    { 
                        Id = human.Id,
                        FirstName = human.FirstName,
                        LastName = human.LastName,
                        Age = human.Age,
                        CountryName = human.Country.Name
                    }).ToList();
            }
            else
            {
                humans = _humanRepository.GetAllHumans().Where(human => human.Id == humanId).Select(
                    human => new HumanIndexViewModel
                    {
                        Id = human.Id,
                        FirstName = human.FirstName,
                        LastName = human.LastName,
                        Age = human.Age,
                        CountryName = human.Country.Name
                    }).ToList();
            }

            return View(humans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new HumanCreateViewModel { Countries = _countryRepository.GetAllCountries() });
        }

        [HttpPost]
        public IActionResult Create(HumanCreateViewModel humanCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                _humanRepository.AddHuman(humanCreateViewModel.Human);
            }

            return View();
        }

        public IActionResult Delete(int humanId)
        {
            try
            {
                _humanRepository.RemoveHuman(humanId);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return View();
        }
    }
}