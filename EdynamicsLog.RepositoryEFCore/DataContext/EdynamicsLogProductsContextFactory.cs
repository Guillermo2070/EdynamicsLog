using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EdynamicsLog.RepositoryEFCore.DataContext
{
    public class EdynamicsLogProductsContextFactory : IDesignTimeDbContextFactory<EdynamicsLogProductsContext>
    {
        public EdynamicsLogProductsContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<EdynamicsLogProductsContext>();

            OptionBuilder.UseSqlServer("Server=FELIPEQUINTERO\\SQLEXPRESS;Database=EdynamicsLogProducts;User ID=sa;Password=2070;Encrypt=False;");

            return new EdynamicsLogProductsContext(OptionBuilder.Options);
        }
    }
}
