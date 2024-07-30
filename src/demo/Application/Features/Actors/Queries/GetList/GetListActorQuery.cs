using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Actors.Queries.GetList;

public class GetListActorQuery : IRequest<GetListResponse<GetListActorListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListActorQueryHandler : IRequestHandler<GetListActorQuery, GetListResponse<GetListActorListItemDto>>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public GetListActorQueryHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListActorListItemDto>> Handle(GetListActorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Actor> actors = await _actorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListActorListItemDto> response = _mapper.Map<GetListResponse<GetListActorListItemDto>>(actors);
            return response;
        }
    }
}