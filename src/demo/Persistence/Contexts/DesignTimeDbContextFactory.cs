
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
{


    public BaseDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<BaseDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer("Server=localhost;Database=EventDb;User Id=SA;Password=Password123;MultipleActiveResultSets=true;Encrypt=false");

        return new(dbContextOptionsBuilder.Options);


    }
}