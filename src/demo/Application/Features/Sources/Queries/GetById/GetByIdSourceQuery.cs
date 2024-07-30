using Application.Features.Sources.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sources.Queries.GetById;

public class GetByIdSourceQuery : IRequest<GetByIdSourceResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSourceQueryHandler : IRequestHandler<GetByIdSourceQuery, GetByIdSourceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceBusinessRules _sourceBusinessRules;

        public GetByIdSourceQueryHandler(IMapper mapper, ISourceRepository sourceRepository, SourceBusinessRules sourceBusinessRules)
        {
            _mapper = mapper;
            _sourceRepository = sourceRepository;
            _sourceBusinessRules = sourceBusinessRules;
        }

        public async Task<GetByIdSourceResponse> Handle(GetByIdSourceQuery request, CancellationToken cancellationToken)
        {
            Source? source = await _sourceRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sourceBusinessRules.SourceShouldExistWhenSelected(source);

            GetByIdSourceResponse response = _mapper.Map<GetByIdSourceResponse>(source);
            return response;
        }
    }
}