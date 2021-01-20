using Infestation.Models.Repositories.Interfaces;
using Infestation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infestation.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMessageSender _messageSender;

        public NewsController(INewsRepository newsRepository,
            IMessageSender messageSender)
        {
            _newsRepository = newsRepository;
            _messageSender = messageSender;
        }

        public IActionResult Index()
        {
            return View(_newsRepository.GetNews());
        }

        public IActionResult Send()
        {
            _messageSender.SendMessage();
            return RedirectToAction("Index", "Home");
        }
    }
}