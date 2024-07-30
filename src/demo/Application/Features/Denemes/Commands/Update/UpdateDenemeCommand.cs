using Application.Features.Denemes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Denemes.Commands.Update;

public class UpdateDenemeCommand : IRequest<UpdatedDenemeResponse>
{
    public Guid Id { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public class UpdateDenemeCommandHandler : IRequestHandler<UpdateDenemeCommand, UpdatedDenemeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDenemeRepository _denemeRepository;
        private readonly DenemeBusinessRules _denemeBusinessRules;

        public UpdateDenemeCommandHandler(IMapper mapper, IDenemeRepository denemeRepository,
                                         DenemeBusinessRules denemeBusinessRules)
        {
            _mapper = mapper;
            _denemeRepository = denemeRepository;
            _denemeBusinessRules = denemeBusinessRules;
        }

        public async Task<UpdatedDenemeResponse> Handle(UpdateDenemeCommand request, CancellationToken cancellationToken)
        {
            Deneme? deneme = await _denemeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _denemeBusinessRules.DenemeShouldExistWhenSelected(deneme);
            deneme = _mapper.Map(request, deneme);

            await _denemeRepository.UpdateAsync(deneme!);

            UpdatedDenemeResponse response = _mapper.Map<UpdatedDenemeResponse>(deneme);
            return response;
        }
    }
}