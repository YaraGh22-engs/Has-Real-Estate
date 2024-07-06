namespace Has_Real_Estate.Repo.IRepo
{
    public interface IAdminOperationsRepo
    {
        IEnumerable<Estate> GetAllEstates();
       
        Task ToggleApprovementStatus(int estateId);
    }
}
