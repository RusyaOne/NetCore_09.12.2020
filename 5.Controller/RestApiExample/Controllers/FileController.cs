using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    public class FileController : ControllerBase
    {
        [HttpGet("File")]
        public FileContentResult GetFile()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/TerrainImage55.jpg");
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpPost("File")]
        public void UploadFile([FromBody]string file, [FromQuery]string fileName, [FromServices]IWebHostEnvironment webHost)
        {
            var fileBytes = Convert.FromBase64String(file);
            var filePath = Path.Combine(webHost.WebRootPath, fileName);
            System.IO.File.WriteAllBytes(filePath, fileBytes);
        }
    }
}
