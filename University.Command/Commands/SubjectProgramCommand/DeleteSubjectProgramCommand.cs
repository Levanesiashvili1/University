using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectProgramModels;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectProgramCommand
{
    public class DeleteSubjectProgramCommand : CommandBase
    {
        private readonly DeleteSubjectProgramModel _model;
        public DeleteSubjectProgramCommand(RepositoryProvider repositoryProvider, DeleteSubjectProgramModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var delete = await _repositoryProvider.SubjectProgrames.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _model.Id);
            if (delete != null)
            {

            }

            delete.Delete();

            _repositoryProvider.SubjectProgrames.Update(delete);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("წარმატებით წაიშალა");

        }
    }
}
