using CQRS.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Services.Data_Store
{
    public class MockDB
    {


        private ICollection<Student>  Students= new List<Student>
            {
                new Student{ Id=1, Name="Jiya"},
                new Student{ Id=2, Name="Anish"},
                new Student { Id = 3, Name = "Jeeba" }
            };

        public IEnumerable<Student> GetStudents() => Students;

        public void AddStudent(Student student) => Students.Add(student);

    }
}
