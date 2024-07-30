using Application.Features.Sources.Constants;
using Application.Features.Sources.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sources.Commands.Delete;

public class DeleteSourceCommand : IRequest<DeletedSourceResponse>
{
    public Guid Id { get; set; }

    public class DeleteSourceCommandHandler : IRequestHandler<DeleteSourceCommand, DeletedSourceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceBusinessRules _sourceBusinessRules;

        public DeleteSourceCommandHandler(IMapper mapper, ISourceRepository sourceRepository,
                                         SourceBusinessRules sourceBusinessRules)
        {
            _mapper = mapper;
            _sourceRepository = sourceRepository;
            _sourceBusinessRules = sourceBusinessRules;
        }

        public async Task<DeletedSourceResponse> Handle(DeleteSourceCommand request, CancellationToken cancellationToken)
        {
            Source? source = await _sourceRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sourceBusinessRules.SourceShouldExistWhenSelected(source);

            await _sourceRepository.DeleteAsync(source!);

            DeletedSourceResponse response = _mapper.Map<DeletedSourceResponse>(source);
            return response;
        }
    }
}