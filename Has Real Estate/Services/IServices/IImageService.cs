namespace Has_Real_Estate.Services.IServices
{
    public interface IImageService
    {
        string SaveImgInServer(IFormFile file);
        string GetImagePath(string image);
        byte[] SaveImageInDatabase(IFormFile file);
    }
}
