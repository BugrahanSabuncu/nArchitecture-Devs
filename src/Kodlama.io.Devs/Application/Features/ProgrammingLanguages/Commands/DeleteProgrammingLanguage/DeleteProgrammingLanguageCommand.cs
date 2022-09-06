using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class DeleteProgrammingLanguageCommandHandler :IRequestHandler<DeleteProgrammingLanguageCommand,DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgrammingLanguage entity = await _programmingLanguageRepository.GetAsync(p => p.Name == request.Name);
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(entity);
                DeletedProgrammingLanguageDto programmingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

                return programmingLanguageDto;
            }

           
        }
    }
}
