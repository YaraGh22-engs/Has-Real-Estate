using Has_Real_Estate.Repo.IRepo;

namespace Has_Real_Estate.Repo
{
    public class AdminOperationsRepo : IAdminOperationsRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstateRepo _estateRepo;
        public AdminOperationsRepo(ApplicationDbContext context , IEstateRepo estateRepo)
        {
            _context = context;
            _estateRepo = estateRepo;
        }
        public IEnumerable<Estate> GetAllEstates()
        {
           var estates= _context.Estates?.Include(x=>x.EstateImages).ToList();
            return estates;
        }

        

        public async Task ToggleApprovementStatus(int estateId)
        {
            var es = await _context.Estates.FindAsync(estateId);
             
            es.IsApproved = !es.IsApproved;
            await _context.SaveChangesAsync();
        }
    }
}
