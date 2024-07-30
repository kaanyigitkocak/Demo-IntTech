using Application.Features.Actors.Constants;
using Application.Features.Actors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Actors.Commands.Delete;

public class DeleteActorCommand : IRequest<DeletedActorResponse>
{
    public Guid Id { get; set; }

    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, DeletedActorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        private readonly ActorBusinessRules _actorBusinessRules;

        public DeleteActorCommandHandler(IMapper mapper, IActorRepository actorRepository,
                                         ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<DeletedActorResponse> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            Actor? actor = await _actorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _actorBusinessRules.ActorShouldExistWhenSelected(actor);

            await _actorRepository.DeleteAsync(actor!);

            DeletedActorResponse response = _mapper.Map<DeletedActorResponse>(actor);
            return response;
        }
    }
}