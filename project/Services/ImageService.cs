using project.IServices;

namespace project.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private List<string> AllowedExtensions = new() { ".jpg", ".jpeg", ".png" };

        //Max Photo Size is 2MB
        private int MaxAllowedFileSize = 2145728;

        public string SaveImages(IFormFile ImgFile)
        {
            try
            {
                if (ImgFile is not null)
                {
                    var ImgFileExtension = AllowedExtensions.Contains(Path.GetExtension(ImgFile.FileName));

                    //Check Extension
                    if (!ImgFileExtension)
                        return null;

                    //Check File Size
                    if (ImgFile.Length > MaxAllowedFileSize)
                        return null;

                    //New Names
                    var ImgFileNewName = Guid.NewGuid() + Path.GetExtension(ImgFile.FileName);

                    //Generating Paths
                    var ImgFilePath = Path.Combine($"{_webHostEnvironment.WebRootPath}/images/Products", ImgFileNewName);

                    //Physical Copying
                    using var stream = System.IO.File.Create(ImgFilePath);
                    ImgFile.CopyTo(stream);
                    stream.Dispose();

                    var image = $"/images/Products/{ImgFileNewName}";

                    return image;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string UpdateImages(IFormFile formFile, string OldPhotoName)
        {
            try
            {
                if (formFile is not null)
                {
                    var idPhotoExtension = AllowedExtensions.Contains(Path.GetExtension(formFile.FileName));

                    //Check Extension
                    if (!idPhotoExtension)
                        return null;

                    //Check File Size
                    if (formFile.Length > MaxAllowedFileSize)
                        return null;

                    //New Names
                    var PhotoNewName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);

                    //Generating Paths

                    var OldPhotoPath = $"{_webHostEnvironment.WebRootPath}{OldPhotoName}";

                    var NewPhotoPath = Path.Combine($"{_webHostEnvironment.WebRootPath}/images/Products", PhotoNewName);

                    //DeleteOldPhoto 
                    if (System.IO.File.Exists(OldPhotoPath))
                        System.IO.File.Delete(OldPhotoPath);

                    //Physical Copying
                    using var IdPhotostream = System.IO.File.Create(NewPhotoPath);
                    formFile.CopyTo(IdPhotostream);

                    var image = $"/images/Products/{PhotoNewName}";

                    return image;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public bool DeleteImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    var fullImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));

                    if (System.IO.File.Exists(fullImagePath))
                    {
                        System.IO.File.Delete(fullImagePath);
                        return true; 
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }

    }
}
