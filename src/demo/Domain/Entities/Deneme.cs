using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Deneme : Entity<Guid>
{

    public string? ActivationKey { get; set; }

    public bool IsVerified { get; set; }

    public Deneme()
    {

    }


}
