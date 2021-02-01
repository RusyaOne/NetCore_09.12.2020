using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class ImageProcessingChannel
    {
        private Channel<(string, byte[])> _channel;

        public ImageProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<(string, byte[])>();
        }

        public async Task Write(IFormFile image)
        {
            using (var stream = new MemoryStream())
            {
                image.CopyTo(stream);
                await _channel.Writer.WriteAsync((image.FileName, stream.ToArray()));
            }
        }

        public (string, byte[]) Read()
        {
            (string, byte[]) image;
            _channel.Reader.TryRead(out image);
            return image;
        }

        public IAsyncEnumerable<(string, byte[])> ReadAll()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}