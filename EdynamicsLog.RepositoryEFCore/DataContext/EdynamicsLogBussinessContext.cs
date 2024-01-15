using EdynamicsLog.Entities.POCOs;
using Microsoft.EntityFrameworkCore;

namespace EdynamicsLog.RepositoryEFCore.DataContext
{
    public class EdynamicsLogBussinessContext : DbContext
    {
        public EdynamicsLogBussinessContext(DbContextOptions<EdynamicsLogBussinessContext> options) : base(options) { }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
