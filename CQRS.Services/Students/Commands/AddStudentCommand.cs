using CQRS.Services.Data_Store;
using CQRS.Services.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Services.Students.Commands
{
    public class AddStudentCommand : IRequest<Student>
    {
        public string Name { get; set; }
    }


    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly MockDB mockDB;

        public AddStudentCommandHandler(MockDB mockDB)
        {
            this.mockDB = mockDB;
        }

        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student { Id = new Random().Next(1, 1000), Name = request.Name };
            this.mockDB.AddStudent(student);
            return Task.FromResult(student);
        }

    }

}
