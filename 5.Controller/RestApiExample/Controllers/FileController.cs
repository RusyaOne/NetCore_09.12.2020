using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    public class FileController : Controller
    {
        [HttpGet("File")]
        public FileContentResult GetTerrainImage()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/TerrainImage55.jpg");
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpPost("File")]
        public void UploadImage([FromBody]string image, [FromQuery]string imageName, [FromServices]IWebHostEnvironment webHostEnvironment)
        {
            string imagePath = Path.Combine(webHostEnvironment.WebRootPath, imageName);
            byte[] imageContent = Convert.FromBase64String(image);
            System.IO.File.WriteAllBytes(imagePath, imageContent);
        }
    }
}