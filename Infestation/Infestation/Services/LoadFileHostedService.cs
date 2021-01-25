using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        private readonly IRestApiExampleClient _client;
        private readonly IMemoryCache _cache;

        public LoadFileHostedService(IRestApiExampleClient client, IMemoryCache cache)
        {
            _client = client;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
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

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}