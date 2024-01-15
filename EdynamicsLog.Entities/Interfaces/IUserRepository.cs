using EdynamicsLog.Entities.POCOs;

namespace EdynamicsLog.Entities.Interfaces
{
    public interface IUserRepository
    {
        void CreateUserByOrganization(User user);

        IEnumerable<User> GetUsers(string slugTenatOrganization);

        User GetSlugTenant(string email, string password);
    }
}
