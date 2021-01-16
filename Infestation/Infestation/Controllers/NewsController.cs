using Infestation.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infestation.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository m_newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            m_newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View(m_newsRepository.GetNews());
        }
    }
}