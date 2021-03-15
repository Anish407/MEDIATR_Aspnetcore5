using CQRS.Services.Data_Store;
using CQRS.Services.Models;
using MediatR;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Services.Students.Queries
{
    public class StudentQuery : IRequest<IEnumerable<Student>>
    {


    }

    public class StudentHandler : IRequestHandler<StudentQuery, IEnumerable<Student>>
    {
        public StudentHandler(MockDB dB)
        {
            DB = dB;
        }

        public MockDB DB { get; }

        public async Task<IEnumerable<Student>> Handle(StudentQuery request, CancellationToken cancellationToken)  => DB.GetStudents();
    }



}
