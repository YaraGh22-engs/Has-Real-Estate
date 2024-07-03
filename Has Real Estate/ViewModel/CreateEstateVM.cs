namespace Has_Real_Estate.ViewModel
{
    public class CreateEstateVM : BaseEstateVM
    {
        public IFormFile FormCover { get; set; }
        public List<IFormFile> FormFiles { get; set; }
    }
}
