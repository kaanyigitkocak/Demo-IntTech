using Application.Features.Actors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Actors.Queries.GetById;

public class GetByIdActorQuery : IRequest<GetByIdActorResponse>
{
    public Guid Id { get; set; }

    public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQuery, GetByIdActorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        private readonly ActorBusinessRules _actorBusinessRules;

        public GetByIdActorQueryHandler(IMapper mapper, IActorRepository actorRepository, ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<GetByIdActorResponse> Handle(GetByIdActorQuery request, CancellationToken cancellationToken)
        {
            Actor? actor = await _actorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _actorBusinessRules.ActorShouldExistWhenSelected(actor);

            GetByIdActorResponse response = _mapper.Map<GetByIdActorResponse>(actor);
            return response;
        }
    }
}