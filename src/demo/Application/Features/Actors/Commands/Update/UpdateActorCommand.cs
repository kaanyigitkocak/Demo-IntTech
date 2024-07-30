using Application.Features.Actors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Actors.Commands.Update;

public class UpdateActorCommand : IRequest<UpdatedActorResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, UpdatedActorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        private readonly ActorBusinessRules _actorBusinessRules;

        public UpdateActorCommandHandler(IMapper mapper, IActorRepository actorRepository,
                                         ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<UpdatedActorResponse> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            Actor? actor = await _actorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _actorBusinessRules.ActorShouldExistWhenSelected(actor);
            actor = _mapper.Map(request, actor);

            await _actorRepository.UpdateAsync(actor!);

            UpdatedActorResponse response = _mapper.Map<UpdatedActorResponse>(actor);
            return response;
        }
    }
}