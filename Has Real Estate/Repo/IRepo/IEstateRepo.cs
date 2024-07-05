

namespace Has_Real_Estate.Repo.IRepo
{
    public interface IEstateRepo
    {
        IEnumerable<Estate> GetEstates(); 
        IEnumerable<Estate> GetEstatesByUserId();
        Estate GetById(int estateId);
        IEnumerable<EstateImages> GetAllImages(int estateId); 
        int Create(CreateEstateVM viewModel);
        int Update(UpdateEstateVM viewModel);
        int UpdateEstateImages(UpdateEstateImagesVM viewModel);
        int DeleteEstateImage(int estateId, string image);
        bool Delete(int id);
    }
}
