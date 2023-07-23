﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.ExamModels;
using University.Domain.Entities.Exams;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.ExamCommands
{
    public class CreateExamCommand : CommandBase
    {
        private readonly CreateExamModel _model;
        public CreateExamCommand(RepositoryProvider repositoryProvider, CreateExamModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var Lecturer = await _repositoryProvider.Lecturers.GetQueryable().FirstOrDefaultAsync(x => x.Id == _model.LecturerId);
            if (Lecturer == null)
            {
                return Result.Error("ლექტორი ვერ მოიძებნა");
            }

            var Subject = await _repositoryProvider.Subjects.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _model.SubjectId); 
            if (Subject == null)
            {
                return Result.Error("საგანი ვერ მოიძებნა");

            }
            var exam = new Exam()
            {
                Type = _model.Type,
                MinimalResult = _model.MinimalResult,
                MaximalResult = _model.MaximalResult,
                LecturerId = _model.LecturerId,
                SubjectId = _model.SubjectId,

            };

            _repositoryProvider.Exams.Create(exam);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success(exam);
        }
    }
}
