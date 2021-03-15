using CQRS.Services.Data_Store;
using CQRS.Services.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Services.Students.Queries
{
    public class StudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set;}
    }

    public class StudentByIdHandler : IRequestHandler<StudentByIdQuery, Student>
    {
        private readonly MockDB dB;

        public StudentByIdHandler(MockDB dB)
        {
            this.dB = dB;
        }


        public Task<Student> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
            => Task.FromResult( dB.GetStudents().FirstOrDefault(i => i.Id == request.Id));
      
    }

}
