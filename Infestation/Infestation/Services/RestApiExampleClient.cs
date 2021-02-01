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
                    request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
                    request.AddQueryParameter("imageName", image.FileName);
                    client.Execute(request);
                }
                catch (ObjectDisposedException)
                {
                    //TODO: Add logging here and supress
                }
                catch
                {
                    throw;
                }
            }
        }

        public void UploadFile(string imageName, byte[] image)
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.POST);
            try
            {
                request.AddJsonBody(Convert.ToBase64String(image));
                request.AddQueryParameter("imageName", imageName);
                client.Execute(request);
            }
            catch
            {
                //TODO: return thwrowing exception after testing
                //throw;
            }            
        }
    }
}
