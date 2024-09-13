namespace project.IServices
{
    public interface IImageService
    {
        string SaveImages(IFormFile formFile);
        string UpdateImages(IFormFile formFile, string OldPhotoPath);
        bool DeleteImage(string imagePath);
    }
}
