using Infestation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Infestation.Controllers
{
    [Route("[controller]")]
    public class HumanController : Controller
    {
        private IHumanRepository _humanRepository { get; }

        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }

        [Route("[action]/{id?}")]
        public IActionResult Index(int id)
        {
            ViewData["Humans"] = _humanRepository.GetAllHumans().Where(human => human.Id == id).ToList();
            return View();
        }

        [Route("countries/{humanId:int:min(1)}")]
        public IActionResult Country(int humanId)
        {
            var human = _humanRepository.GetAllHumans().First(human => human.Id == humanId);
            ViewData["CountryName"] = human.Country.Name;
            return View();
        }

        public IActionResult DeleteHuman(int humanId)
        {
            try
            {
                _humanRepository.DeleteHuman(humanId);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return View();
        }
    }
}