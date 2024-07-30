using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Application.Services.Repositories;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BaseDb123"));
            });
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());


        services.AddScoped<IDenemeRepository, DenemeRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IGeolocationRepository, GeolocationRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<ISourceRepository, SourceRepository>();
        return services;
    }
}
