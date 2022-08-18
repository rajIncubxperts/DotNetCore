using Non_GenericTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Non_GenericTask.Repository
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int Id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int Id);
       
    }
}
