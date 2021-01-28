using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class ImageProcessingChannel
    {
        private Channel<IFormFile> _channel;

        public ImageProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public void Write(IFormFile image)
        {
            _channel.Writer.WriteAsync(image);
        }

        public IFormFile Read()
        {
            IFormFile image;
            _channel.Reader.TryRead(out image);
            return image;
        }
    }
}