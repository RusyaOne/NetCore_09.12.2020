using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class RestApiExampleClient : IRestApiExampleClient
    {
        public byte[] GetFile()
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.GET);
            var response = client.Execute(request);
            var content = response.RawBytes;
            return content;
        }

        public void UploadFile([MaybeNull] IFormFile file)
        {
            if (file == null)
                return;

            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.POST);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
            }

            request.AddQueryParameter("fileName", file.FileName);
            var response = client.Execute(request);
        }
    }
}