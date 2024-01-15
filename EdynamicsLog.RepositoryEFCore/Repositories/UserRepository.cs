using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.RepositoryEFCore.DataContext;

namespace EdynamicsLog.RepositoryEFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly EdynamicsLogBussinessContext Context;

        public UserRepository(EdynamicsLogBussinessContext context) => Context = context;

        public void CreateUserByOrganization(User user)
        {
            Context.Add(user);
        }

        public IEnumerable<User> GetUsers(string slugTenatOrganization)
        {
            return Context.Users.Where(u => u.SlugTenatOrganization == slugTenatOrganization).ToList();
        }

        public User GetSlugTenant(string email, string password)
        {
            return Context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
