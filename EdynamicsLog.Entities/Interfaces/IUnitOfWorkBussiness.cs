namespace EdynamicsLog.Entities.Interfaces
{
    public interface IUnitOfWorkBussiness
    {
        Task<int> SaveChanges();
    }
}
