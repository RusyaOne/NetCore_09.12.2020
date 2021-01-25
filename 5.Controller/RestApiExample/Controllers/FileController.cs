using BasicInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicInfo.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        //private INewsRepository _newsRepository { get; }

        //public FileController(INewsRepository newsRepository)
        //{
        //    _newsRepository = newsRepository;
        //}

        [HttpGet("File")]
        public FileContentResult GetFile()
        {

        }
    }
}