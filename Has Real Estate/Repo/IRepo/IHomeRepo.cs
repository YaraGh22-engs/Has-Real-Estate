

namespace Has_Real_Estate.Repo.IRepo
{
    public interface IHomeRepo
    {
        IEnumerable<Estate> GetHomes();
        IEnumerable<HomeImages> GetAllImages(int homeId);
        Estate GetById(int homeId);
        int Create(CreateHomeVM viewModel);
        int Update(UpdateHomeVM viewModel);
        int UpdateHomeImages(UpdateHomeImagesVM viewModel);
        int DeleteHomeImage(int homeId, string image);
    }
}
