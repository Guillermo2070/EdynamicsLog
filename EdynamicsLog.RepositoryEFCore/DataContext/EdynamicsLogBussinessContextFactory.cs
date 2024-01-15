using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EdynamicsLog.RepositoryEFCore.DataContext
{
    public class EdynamicsLogBussinessContextFactory : IDesignTimeDbContextFactory<EdynamicsLogBussinessContext>
    {
        public EdynamicsLogBussinessContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<EdynamicsLogBussinessContext>();

            OptionBuilder.UseSqlServer("Server=FELIPEQUINTERO\\SQLEXPRESS;Database=EdynamicsLogBussiness;User ID=sa;Password=2070;Encrypt=False;");

            return new EdynamicsLogBussinessContext(OptionBuilder.Options);
        }
    }
}
