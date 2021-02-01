using Infestation.Services;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRestApiExampleClient _client;
        private readonly IMemoryCache _cache;
        private readonly ImageProcessingChannel _channel;

        public ImageController(IRestApiExampleClient client, IMemoryCache cache, ImageProcessingChannel channel)
        {
            _client = client;
            _cache = cache;
            _channel = channel;
        }

        public IActionResult Get()
        {
            var cacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            var imageBytes = _cache.Get<byte[]>(cacheKey);

            if (imageBytes == null)
            {
                imageBytes = _client.GetFileBytes();
                var options = new MemoryCacheEntryOptions();
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2); 
                _cache.Set<byte[]>(cacheKey, imageBytes, options);
            }

            return new FileContentResult(imageBytes, "image/jpeg");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            var model = new ImageUploadViewModel();
            model.UploadStage = UploadStage.Upload;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImageUploadViewModel viewModel)
        {
            if (viewModel.Image?.Length > 0)
            {
                await _channel.Write(viewModel.Image);                
                viewModel.Image = null;
                viewModel.UploadStage = UploadStage.Completed;
            }

            return View(viewModel);
        }
    }
}