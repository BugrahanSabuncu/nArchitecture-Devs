using MediatR;
using Domain.Entities;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services;
using AutoMapper;
using Application.Features.ProgrammingLanguages.Rules;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);              

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createadProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);

                CreatedProgrammingLanguageDto programmingLanguageDto=_mapper.Map<CreatedProgrammingLanguageDto>(createadProgrammingLanguage);

                return programmingLanguageDto;
            }
        }
    }
}
