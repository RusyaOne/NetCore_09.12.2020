using BasicInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository { get; }

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index(string name)
        {
            ViewData["name"] = name;
            return View();
        }

        public IActionResult Show(int id)
        {
            ViewData["news"] = _newsRepository.GetNews().Single(news => news.Id == id).Title;
            return View();
        }
    }
}