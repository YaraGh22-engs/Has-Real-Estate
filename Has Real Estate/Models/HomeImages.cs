

namespace Has_Real_Estate.Models
{
    public class HomeImages
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("Home")]
        public int HomeId { get; set; }
        public Home? Home { get; set; }
    }
}
