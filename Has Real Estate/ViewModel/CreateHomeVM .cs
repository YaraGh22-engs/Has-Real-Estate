namespace Has_Real_Estate.ViewModel
{
    public class CreateHomeVM : BaseHomeVM
    {
        public IFormFile FormCover { get; set; }
        public List<IFormFile> FormFiles { get; set; }
    }
}
