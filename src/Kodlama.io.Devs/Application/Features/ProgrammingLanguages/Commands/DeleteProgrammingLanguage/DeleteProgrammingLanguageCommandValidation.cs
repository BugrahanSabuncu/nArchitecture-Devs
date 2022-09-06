using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidation : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
