using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infestation.Services
{
    public class RestApiExampleClient : IRestApiExampleClient
    {
        public byte[] GetFileBytes()
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.GET);
            byte[] content = client.Execute(request).RawBytes;
            return content;
        }

        public void UploadFile(IFormFile image)
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.POST);
            using (var stream = new MemoryStream())
            {
                try
                {
                    image.CopyTo(stream);
                }
                catch (Exception e)
                {
                    var message = e.Message;
                }
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
                request.AddQueryParameter("imageName", image.FileName);
                client.Execute(request);
            }
        }
    }
}
