using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace DijitalErpAPI.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var build = new DbContextOptionsBuilder<RepositoryContext>().UseNpgsql(config.GetConnectionString("sqlConnection"), prj => prj.MigrationsAssembly("DijitalErpAPI"));

            return new RepositoryContext(build.Options);
        }
    }
}
