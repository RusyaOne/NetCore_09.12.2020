namespace Infestation.ViewModels
{
    public class ImageUploadViewModel
    {
        public byte[] Image { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage 
    {
        Upload,
        Completed
    }
}