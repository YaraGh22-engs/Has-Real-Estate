namespace Has_Real_Estate.Models
{
    public class SavedProperty
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        public Estate Estate { get; set; } = default!;

        //bool IsAdded {  get; set; }=true;
    }
}
