using Microsoft.AspNetCore.Mvc;
using RestApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _repository { get; }

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("News")]
        public IEnumerable<News> GetNews([FromServices] INewsRepository repo)
        {
            return repo.GetAllNews();
        }

        [HttpPost("News")]
        public void CreateNews(News news)
        {
            _repository.CreateNews(news);
        }
    }
}
