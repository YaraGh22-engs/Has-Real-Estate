namespace Has_Real_Estate.Models
{
    public class SavedProperty
    {
        public int Id { get; set; }
        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        Estate Estate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        AppUser User { get; set; }
        //bool IsAdded {  get; set; }=true;
    }
}
