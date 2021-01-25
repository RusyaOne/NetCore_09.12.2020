using Microsoft.AspNetCore.Http;

namespace Infestation.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFile();
        public void UploadFile(IFormFile file);
    }
}
