using Application.Features.Denemes.Constants;
using Application.Features.Denemes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Denemes.Commands.Delete;

public class DeleteDenemeCommand : IRequest<DeletedDenemeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDenemeCommandHandler : IRequestHandler<DeleteDenemeCommand, DeletedDenemeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDenemeRepository _denemeRepository;
        private readonly DenemeBusinessRules _denemeBusinessRules;

        public DeleteDenemeCommandHandler(IMapper mapper, IDenemeRepository denemeRepository,
                                         DenemeBusinessRules denemeBusinessRules)
        {
            _mapper = mapper;
            _denemeRepository = denemeRepository;
            _denemeBusinessRules = denemeBusinessRules;
        }

        public async Task<DeletedDenemeResponse> Handle(DeleteDenemeCommand request, CancellationToken cancellationToken)
        {
            Deneme? deneme = await _denemeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _denemeBusinessRules.DenemeShouldExistWhenSelected(deneme);

            await _denemeRepository.DeleteAsync(deneme!);

            DeletedDenemeResponse response = _mapper.Map<DeletedDenemeResponse>(deneme);
            return response;
        }
    }
}