using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFileBytes();

        public void UploadFile([NotNull]IFormFile image);
    }
}
