using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class UploadFileHostedService : BackgroundService
    {
        private readonly IRestApiExampleClient _client;
        private readonly ImageProcessingChannel _channel;

        public UploadFileHostedService(IRestApiExampleClient client, ImageProcessingChannel channel)
        {
            _client = client;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await foreach((string ImageName, byte[] Image) image in _channel.ReadAll())
                {
                    _client.UploadFile(image.ImageName, image.Image);
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}