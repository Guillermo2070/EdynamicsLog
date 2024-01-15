namespace EdynamicsLog.Entities.Interfaces
{
    public interface IUnitOfWorkProducts
    {
        Task<int> SaveChanges();
    }
}
