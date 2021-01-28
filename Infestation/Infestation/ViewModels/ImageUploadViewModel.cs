using Microsoft.AspNetCore.Http;

namespace Infestation.ViewModels
{
    public class ImageUploadViewModel
    {
        public IFormFile Image { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage 
    {
        Upload,
        Completed
    }
}