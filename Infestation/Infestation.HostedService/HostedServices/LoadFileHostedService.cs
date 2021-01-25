using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        private readonly IRestApiExampleClient _restClient;
        private readonly IMemoryCache _cache;

        public LoadFileHostedService(IRestApiExampleClient restClient, IMemoryCache memoryCache)
        {
            _restClient = restClient;
            _cache = memoryCache;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
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

                await Task.Delay(TimeSpan.FromMinutes(2));
            }
        }
    }
}
