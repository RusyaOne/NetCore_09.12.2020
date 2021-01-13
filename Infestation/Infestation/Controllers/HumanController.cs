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

        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            if (ModelState.IsValid)
            {
                _humanRepository.AddHuman(human);
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