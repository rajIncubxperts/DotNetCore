using Microsoft.EntityFrameworkCore;
using Non_GenericTask.Data;
using Non_GenericTask.Models;
using Non_GenericTask.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Non_GenericTask.Services
{
    public class StudentImplantation : IStudent
    {

        private readonly ApplicationDbContext _Context;


        public StudentImplantation(ApplicationDbContext Context)
        {
            _Context = Context;       // with Dependency Injection
        }
        public StudentImplantation()
        { 
            _Context = new();    // Context Object 
        }
        public async Task<Student> AddStudent(Student student)
        {
            var result = await  _Context.Students.AddAsync(student);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> DeleteStudent(int Id)
        {
            var result = await _Context.Students.Where(s=> s.Id==Id).FirstOrDefaultAsync();
           if(result!= null)
            {
                _Context.Students.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Student> GetStudent(int Id)
        {
            return await _Context.Students.FirstOrDefaultAsync(s=>s.Id ==  Id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _Context.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student) 
        {
            var result = await _Context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (result != null)
            {
                result.Name = student.Name;
                result.Age = student.Age;
                result.Name = student.Name;
                await _Context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
