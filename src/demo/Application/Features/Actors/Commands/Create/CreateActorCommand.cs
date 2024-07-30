using Application.Features.Actors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Actors.Commands.Create;

public class CreateActorCommand : IRequest<CreatedActorResponse>
{
    public string Name { get; set; }

    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, CreatedActorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        private readonly ActorBusinessRules _actorBusinessRules;

        public CreateActorCommandHandler(IMapper mapper, IActorRepository actorRepository,
                                         ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<CreatedActorResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            Actor actor = _mapper.Map<Actor>(request);

            await _actorRepository.AddAsync(actor);

            CreatedActorResponse response = _mapper.Map<CreatedActorResponse>(actor);
            return response;
        }
    }
}