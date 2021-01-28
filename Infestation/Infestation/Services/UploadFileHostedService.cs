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
                IFormFile image = _channel.Read();
                if (image != null)
                {
                    _client.UploadFile(image);
                }

                await Task.Delay(TimeSpan.FromSeconds(15));
            }
        }
    }
}