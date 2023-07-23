using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectModels;
using University.Command.CommandModels.SubjectProgramModels;
using University.Command.CommandModels.UserModels;
using University.Domain.Entities.SubjectPrograms;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectProgramCommand
{
    public class CreateSubjectProgramCommand : CommandBase
    {
        private readonly CreateSubjectProgramModel _model;
        public CreateSubjectProgramCommand(RepositoryProvider repositoryProvider, CreateSubjectProgramModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            if (!_repositoryProvider.Subjects.GetQueryable().Any(x=> x.Id == _model.SubjectId))
            {
                return Result.Error("ასეთი საგანი არ  არსებობს");
            }
            var subjectProgram = new SubjectProgram()
            {
                Description = _model.Description,
                BookName = _model.BookName,
                BookPages = _model.BookPages,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                SubjectId = _model.SubjectId,

            };


            _repositoryProvider.SubjectProgrames.Create(subjectProgram);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success(subjectProgram);

        }
    }
}
