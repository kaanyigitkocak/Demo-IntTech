using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Denemes.Queries.GetList;

public class GetListDenemeQuery : IRequest<GetListResponse<GetListDenemeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDenemeQueryHandler : IRequestHandler<GetListDenemeQuery, GetListResponse<GetListDenemeListItemDto>>
    {
        private readonly IDenemeRepository _denemeRepository;
        private readonly IMapper _mapper;

        public GetListDenemeQueryHandler(IDenemeRepository denemeRepository, IMapper mapper)
        {
            _denemeRepository = denemeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDenemeListItemDto>> Handle(GetListDenemeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Deneme> denemes = await _denemeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDenemeListItemDto> response = _mapper.Map<GetListResponse<GetListDenemeListItemDto>>(denemes);
            return response;
        }
    }
}