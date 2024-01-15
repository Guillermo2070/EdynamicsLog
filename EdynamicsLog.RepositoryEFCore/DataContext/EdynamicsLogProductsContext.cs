using EdynamicsLog.Entities.POCOs;
using Microsoft.EntityFrameworkCore;

namespace EdynamicsLog.RepositoryEFCore.DataContext
{
    public class EdynamicsLogProductsContext : DbContext
    {
        public EdynamicsLogProductsContext(DbContextOptions<EdynamicsLogBussinessContext> options) : base(options) { }

        public EdynamicsLogProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
