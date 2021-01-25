using Infestation.Services;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class ResourcesController : Controller
    {        
        private readonly IRestApiExampleClient _restClient;
        private readonly FileProcessingChannel _channel;
        private readonly IMemoryCache _cache;

        public ResourcesController(IRestApiExampleClient restClient, IMemoryCache cache, FileProcessingChannel channel)
        {
            _cache = cache;
            _restClient = restClient;
            _channel = channel;
        }

        public FileContentResult Get()
        {
            var cacheKey = $"image_{DateTime.UtcNow:yyyy_mm_dd}";
            var image = _cache.Get<byte[]>(cacheKey);

            if (image == null)
            {
                image = _restClient.GetFile();
                var memoryCacheEntry = new MemoryCacheEntryOptions();
                memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                _cache.Set<byte[]>(cacheKey, image, memoryCacheEntry); 
            }

            return new FileContentResult(image, "image/jpeg");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            var viewModel = new ResourceUploadViewModel();
            viewModel.UploadStage = UploadStage.Upload;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Upload(ResourceUploadViewModel viewModel)
        {
            var entryOptions = new MemoryCacheEntryOptions();
            entryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

            if (viewModel.File?.Length > 0)
            {
                _channel.SetAsync(viewModel.File);
                viewModel.File = null;
                viewModel.UploadStage = UploadStage.Comleted;
            }

            return View(viewModel);
        }
    }
}