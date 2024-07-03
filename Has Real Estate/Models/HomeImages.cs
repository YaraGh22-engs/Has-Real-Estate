

namespace Has_Real_Estate.Models
{
    public class HomeImages
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("Home")]
        public int EstateId { get; set; }
        public Estate? Estate { get; set; }
    }
}
