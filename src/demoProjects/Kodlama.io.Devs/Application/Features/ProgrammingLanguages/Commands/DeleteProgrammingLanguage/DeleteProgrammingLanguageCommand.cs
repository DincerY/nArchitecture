using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand,DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            private readonly IMapper _mapper;
            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
                _mapper = mapper;
            }
            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage =await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

                _programmingLanguagesBusinessRules.ProgrammingLanguageShouldExistWhenDeleted(programmingLanguage);

                ProgrammingLanguage deletedProgrammingLanguage =
                    await _programmingLanguageRepository.DeleteAsync(programmingLanguage);

                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
                return deletedProgrammingLanguageDto;
            }
        }


    }
}
