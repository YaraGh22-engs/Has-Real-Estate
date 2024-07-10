

namespace Has_Real_Estate.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public int OwnerPhone { get; set; }
        [ForeignKey(nameof(AppUser))]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public Governorate Governorate { get; set; }
        public string City { get; set; }        
        public string Street { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Area { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NFloor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBedroom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBath { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NLivingRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NReceptionRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBalcone { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NGarage { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NKitchen { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NFoodRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NDepot { get; set; }
        public byte[] Cover { get; set; }
        public string? ExtraFeatures { get; set; }
        public bool IsApproved { get; set; } = false; 
        public bool ForRent { get; set; } = false;
        public bool ForSale { get; set; } = false;
        public Category Category { get; set; } = default!;
        public MethodPay MethodPay { get; set; }
        public LegalType LegalType { get; set; }
        public CompleteBuildingState CompleteBuildingState { get; set; }
 
        //navigation
        public List<EstateImages>? EstateImages { get; set; } = new List<EstateImages>(); 
        public List<SavedProperty>? SavedProperties { get; set; } = new List<SavedProperty>();
        public List<Comment>? Comments { get; set; } = new List<Comment> ();


    }
    public enum Category
    {
        Appartement,
        House,
        Villa,
        Farm,
        Office
    }
    public enum MethodPay
    {
        Cash,
        Loan,
        Installment_payment
    }
    public enum LegalType
    {
        Green,
        White,
        Endowments,
        Agriculture,
        Violation
    }
    public enum CompleteBuildingState
    {
        UnderConstruction,
        MidComplete,
        Complete
    }
    public enum Governorate
    {
        Aleppo,
        Damascus,
        Daraa,
        Deir_ez_Zor,
        Hama,
        Hasakah,
        Homs,
        Idlib,
        Latakia,
        Quneitra,
        Raqqah,
        Rif_Dimashq,
        Suwayda,
        Tartus,
    }
}
