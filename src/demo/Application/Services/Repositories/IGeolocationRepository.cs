using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGeolocationRepository : IAsyncRepository<Geolocation, Guid>, IRepository<Geolocation, Guid>
{
}