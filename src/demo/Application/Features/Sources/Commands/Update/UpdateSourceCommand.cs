using Application.Features.Sources.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sources.Commands.Update;

public class UpdateSourceCommand : IRequest<UpdatedSourceResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateSourceCommandHandler : IRequestHandler<UpdateSourceCommand, UpdatedSourceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceBusinessRules _sourceBusinessRules;

        public UpdateSourceCommandHandler(IMapper mapper, ISourceRepository sourceRepository,
                                         SourceBusinessRules sourceBusinessRules)
        {
            _mapper = mapper;
            _sourceRepository = sourceRepository;
            _sourceBusinessRules = sourceBusinessRules;
        }

        public async Task<UpdatedSourceResponse> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
        {
            Source? source = await _sourceRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sourceBusinessRules.SourceShouldExistWhenSelected(source);
            source = _mapper.Map(request, source);

            await _sourceRepository.UpdateAsync(source!);

            UpdatedSourceResponse response = _mapper.Map<UpdatedSourceResponse>(source);
            return response;
        }
    }
}