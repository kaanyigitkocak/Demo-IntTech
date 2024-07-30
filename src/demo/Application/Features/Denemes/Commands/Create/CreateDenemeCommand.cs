using Application.Features.Denemes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Denemes.Commands.Create;

public class CreateDenemeCommand : IRequest<CreatedDenemeResponse>
{
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public class CreateDenemeCommandHandler : IRequestHandler<CreateDenemeCommand, CreatedDenemeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDenemeRepository _denemeRepository;
        private readonly DenemeBusinessRules _denemeBusinessRules;

        public CreateDenemeCommandHandler(IMapper mapper, IDenemeRepository denemeRepository,
                                         DenemeBusinessRules denemeBusinessRules)
        {
            _mapper = mapper;
            _denemeRepository = denemeRepository;
            _denemeBusinessRules = denemeBusinessRules;
        }

        public async Task<CreatedDenemeResponse> Handle(CreateDenemeCommand request, CancellationToken cancellationToken)
        {
            Deneme deneme = _mapper.Map<Deneme>(request);

            await _denemeRepository.AddAsync(deneme);

            CreatedDenemeResponse response = _mapper.Map<CreatedDenemeResponse>(deneme);
            return response;
        }
    }
}