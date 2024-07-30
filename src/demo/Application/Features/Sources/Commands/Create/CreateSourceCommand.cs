using Application.Features.Sources.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sources.Commands.Create;

public class CreateSourceCommand : IRequest<CreatedSourceResponse>
{
    public string Name { get; set; }

    public class CreateSourceCommandHandler : IRequestHandler<CreateSourceCommand, CreatedSourceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceBusinessRules _sourceBusinessRules;

        public CreateSourceCommandHandler(IMapper mapper, ISourceRepository sourceRepository,
                                         SourceBusinessRules sourceBusinessRules)
        {
            _mapper = mapper;
            _sourceRepository = sourceRepository;
            _sourceBusinessRules = sourceBusinessRules;
        }

        public async Task<CreatedSourceResponse> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
        {
            Source source = _mapper.Map<Source>(request);

            await _sourceRepository.AddAsync(source);

            CreatedSourceResponse response = _mapper.Map<CreatedSourceResponse>(source);
            return response;
        }
    }
}