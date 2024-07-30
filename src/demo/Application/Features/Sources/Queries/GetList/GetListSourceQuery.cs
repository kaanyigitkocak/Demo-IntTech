using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Sources.Queries.GetList;

public class GetListSourceQuery : IRequest<GetListResponse<GetListSourceListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSourceQueryHandler : IRequestHandler<GetListSourceQuery, GetListResponse<GetListSourceListItemDto>>
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IMapper _mapper;

        public GetListSourceQueryHandler(ISourceRepository sourceRepository, IMapper mapper)
        {
            _sourceRepository = sourceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSourceListItemDto>> Handle(GetListSourceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Source> sources = await _sourceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSourceListItemDto> response = _mapper.Map<GetListResponse<GetListSourceListItemDto>>(sources);
            return response;
        }
    }
}